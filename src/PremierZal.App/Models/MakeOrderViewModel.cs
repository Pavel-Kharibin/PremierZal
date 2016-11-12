using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using PremierZal.Common.Models;

namespace PremierZal.App.Models
{
    public class MakeOrderViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<Session> _dataSource;
        private Session _selectedSession;

        public MakeOrderViewModel(IEnumerable<Session> sessions)
        {
            _dataSource = new ObservableCollection<Session>(sessions);
            TicketsCount = 1;
        }

        public ObservableCollection<Session> Sessions
        {
            get { return _dataSource; }
            set
            {
                _dataSource = value;
                OnPropertyChanged();
            }
        }

        public int TicketsCount { get; set; }

        public Session SelectedSession
        {
            get { return _selectedSession ?? _dataSource.FirstOrDefault(); }
            set
            {
                _selectedSession = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void Reset()
        {
            _selectedSession = _dataSource.FirstOrDefault();
            TicketsCount = 1;
        }
    }
}