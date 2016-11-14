using System.ComponentModel;

namespace Lancer1WPF
{
    public class DataItem : INotifyPropertyChanged
    {
        private string _name;
        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged("Name");
                OnPropertyChanged("FullName");
            }
        }

        private int _order;
        public int Order
        {
            get { return _order; }
            set
            {
                _order = value;
                OnPropertyChanged("Order");
                OnPropertyChanged("FullName");
            }
        }

        public DataItem(string name, int order)
        {
            Name = name;
            Order = order;
        }

        public override string ToString()
        {
            return string.Format("{0} {1}.", Name, Order);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}