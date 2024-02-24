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
        public int coefficient;

        [XmlElement("note")]
        public string note;

        [XmlElement("Scale")]
        public List<CounterScaleData> scales;

        [XmlElement("HasError")]
        public bool hasError;

        [XmlElement("ErrorNote")]
        public string errorNote;
    }
}

// TEMP REFERENCE:
//< Counter Number = "8799225" >
//      < note > Лицевой счет 802585, Шагінська Марія Пилипівна</note>
//		<Scale Value="16241.7680" IsActive="true"   />
//		<Scale Value="16241.4180" ZoneType="1" IsActive="true"   />
//		<Scale Value="0.0000" ZoneType="2" IsActive="true"   />
//		<Scale Value="0.0000" ZoneType="3" IsActive="true"   />
//	</Counter>