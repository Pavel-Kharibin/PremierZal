using System.Windows;

namespace PremierZal.App
{
    /// <summary>
    ///     Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        private readonly WebApiClient _client;

        public MainWindow()
        {
            InitializeComponent();

            _client = new WebApiClient("http://localhost:51295/");
        }


        private void buttonAddOrder_Click(object sender, RoutedEventArgs e)
        {
            var addOrderWindow = new AddOrderWindow {Owner = this};
            addOrderWindow.Show();
        }
    }
}