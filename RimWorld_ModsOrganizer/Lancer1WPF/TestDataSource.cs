using System;
using System.Collections.ObjectModel;

namespace Lancer1WPF
{
    public class TestDataSource
    {
        private readonly ObservableCollection<DataItem> _collection;

        public TestDataSource()
        {
            _collection = new ObservableCollection<DataItem>();
            for (var i = 0; i < 100; i++)
            {
                _collection.Add(new DataItem(string.Format("Test string {0}",i), 100-i));
            }
        }

        public ObservableCollection<DataItem> Items { get { return _collection; } }
    }
}
