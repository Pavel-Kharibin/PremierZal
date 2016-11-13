using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using PremierZal.Common.Annotations;

namespace PremierZal.Common.Models
{
    public class Session : INotifyPropertyChanged
    {
        private DateTime _degins;

        private string _name;
        public int Id { get; set; }

        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged();
            }
        }

        public DateTime Begins
        {
            get { return _degins; }
            set
            {
                _degins = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}