using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace CountersAnalysis
{
    [Serializable]
    [XmlRoot("Counter")]
    public struct CounterData
    {
        [XmlAttribute("Number")]
        public string number;

        [XmlAttribute("Coeficient")]
        public int coeficient;

        [XmlElement("note")]
        public string note;

        [XmlElement("Scale")]
        public List<CounterScaleData> scales;
    }
}