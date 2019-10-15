using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace SportCCAPItesting.Models
{
    public class CountryGroup : ObservableCollection<Category>
    {
        public string Title { get; set; }
        public static IObservable<CountryGroup> All { private get; set; }
        public CountryGroup()
        {
            
    }
    }
}
