using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Xml.Serialization;

namespace SportCCAPItesting.Models
{
    [XmlRoot(ElementName = "CountryList")]
    public class CountryList : BaseModel
    {
        private ObservableCollection<Country> _countries;

        [XmlElement(ElementName = "country")]
        public ObservableCollection<Country> Countries { get { return _countries; } set { _countries = value; OnPropertyChanged("Country"); } }
    }

}
