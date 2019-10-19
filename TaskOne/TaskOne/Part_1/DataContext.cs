using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Task_1.Part_1
{
    public class DataContext
    {
        public List<Register> lists = new List<Register>();


        public Dictionary<int, Catalog> catalogs = new Dictionary<int, Catalog>();


        public ObservableCollection<Event> events = new ObservableCollection<Event>();


        public List<StatusDescription> descriptions = new List<StatusDescription>();
    }
}
