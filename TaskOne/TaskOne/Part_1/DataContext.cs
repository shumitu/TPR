using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Task_1.Part_1
{
    public class DataContext
    {
        public List<Register> lists;
        public Dictionary<int, Catalog> catalogs;
        public ObservableCollection<Event> events;
        public List<StatusDescription> descriptions;


        public DataContext()
        {
            lists = new List<Register>();
            catalogs = new Dictionary<int, Catalog>();
            events = new ObservableCollection<Event>();
            descriptions = new List<StatusDescription>();
        }
    }
}