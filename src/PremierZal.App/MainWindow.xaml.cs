using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using PremierZal.App.Common;
using PremierZal.App.Models;
using PremierZal.Common.Models;

namespace PremierZal.App
{
    public partial class MainWindow
    {
        private readonly MakeOrderViewModel _makeOrderViewModel = new MakeOrderViewModel(Enumerable.Empty<Session>());
        private readonly Timer _timer = new Timer(Config.DataRefreshInterval);

        public MainWindow()
        {
            InitializeComponent();

            DataContext = new MainWindowViewModel();

            _timer.Elapsed += (sender, args) => { Dispatcher.Invoke(async () => { await UpdateModels(); }); };
        }

        private MainWindowViewModel Model => ((MainWindowViewModel) DataContext);

        private async Task UpdateModels()
        {
            _timer.Stop();

            var sessions = await ApiClient.GetSessionsAsync();
            Model.SessionsCount = sessions.Count();

            await UpdateOrders();

            UpdateSessions(sessions);

            _timer.Start();
        }

        private void UpdateSessions(IEnumerable<Session> sessions)
        {
            // Add new sessions
            foreach (var session in sessions.Where(ses => _makeOrderViewModel.Sessions.All(s => s.Id != ses.Id)))
            {
                _makeOrderViewModel.Sessions.Add(session);
            }

            // Remove deleted sessions
            var toRemove = _makeOrderViewModel.Sessions.Where(ses => sessions.All(s => s.Id != ses.Id)).ToList();
            foreach (var session in toRemove)
            {
                if (session.Id == _makeOrderViewModel.SelectedSession?.Id)
                {
                    _makeOrderViewModel.SelectedSession = _makeOrderViewModel.Sessions.FirstOrDefault();
                }
                _makeOrderViewModel.Sessions.Remove(session);
            }

            // Update sessions
            foreach (var session in _makeOrderViewModel.Sessions)
            {
                var newSession = sessions.First(s => s.Id == session.Id);

                session.Name = newSession.Name;
                session.Begins = newSession.Begins;
            }
        }

        private async Task UpdateOrders()
        {
            var orders = await ApiClient.GetOrdersAsync();

            if (Model.Orders== null)
                Model.Orders = new ObservableCollection<Order>(orders);
            else
            {
                // Add new orders
                foreach (var order in orders.Where(ord => Model.Orders.All(o => o.Id != ord.Id)))
                {
                    Model.Orders.Insert(0, order);
                }

                // Remove deleted orders
                var toRemove = Model.Orders.Where(ord => orders.All(o => o.Id != ord.Id)).ToList();
                foreach (var order in toRemove)
                {
                    Model.Orders.Remove(order);
                }

                // Update sessions names
                foreach (var order in Model.Orders)
                {
                    var newOrder = orders.FirstOrDefault(o => o.Id == order.Id);
                    order.Session.Name = newOrder.Session.Name;
                    order.Session.Begins = newOrder.Session.Begins;
                }
            }
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var progress = new ProgressWindow("Загрузка данных...") {Owner = this};
            progress.Show();
            await UpdateModels();
            progress.Close();

            BtnAddOrder.IsEnabled = true;
        }

        private async void BtnAddOrder_Click(object sender, RoutedEventArgs e)
        {
            var addOrderWindow = new AddOrderWindow(_makeOrderViewModel) {Owner = this};
            var result = addOrderWindow.ShowDialog();

            if (result.HasValue && result.Value)
            {
                var order = new Order
                {
                    SessionId = _makeOrderViewModel.SelectedSession.Id,
                    TicketsCount = _makeOrderViewModel.TicketsCount == 0 ? 1 : _makeOrderViewModel.TicketsCount,
                    Sold = DateTime.Now
                };

                var progress = new ProgressWindow("Оформление заказа...") {Owner = this};
                progress.Show();
                BtnAddOrder.IsEnabled = false;
                await ApiClient.AddOrderAsync(order);
                BtnAddOrder.IsEnabled = true;
                progress.Close();

                order.Session = _makeOrderViewModel.SelectedSession;

                await UpdateOrders();
            }

            _makeOrderViewModel.Reset();
        }
    }
}