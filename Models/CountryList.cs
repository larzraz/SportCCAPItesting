using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace SportCCAPItesting.Models
{
    [XmlRoot(ElementName = "CountryList")]
    public class CountryList
    {
        [XmlElement(ElementName = "country")]
        public List<Country> Countries { get; set; }
    }

}
