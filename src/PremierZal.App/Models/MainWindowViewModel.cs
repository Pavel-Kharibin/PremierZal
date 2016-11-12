using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using PremierZal.Common.Models;

namespace PremierZal.App.Models
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<Order> _dataSource;
        private int _sessionsCount;

        public ObservableCollection<Order> Orders
        {
            get { return _dataSource; }
            set
            {
                _dataSource = value;
                OnPropertyChanged();
            }
        }

        public int SessionsCount
        {
            get { return _sessionsCount; }
            set
            {
                _sessionsCount = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}