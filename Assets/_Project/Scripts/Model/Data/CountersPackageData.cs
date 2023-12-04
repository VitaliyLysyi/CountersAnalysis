using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace CountersAnalysis
{
    [Serializable]
    [XmlRoot("Package")]
    public struct CountersPackageData
    {
        [XmlAttribute("Date")]
        public DateTime date;

        [XmlAttribute("ValueIsFirstEvent")]
        public bool valueIsFirstEvent;

        [XmlElement("note")]
        public string note;

        [XmlElement("HeadCounter")]
        public CounterData headCounter;

        [XmlElement("Counter")]
        public List<CounterData> counters;
    }
}