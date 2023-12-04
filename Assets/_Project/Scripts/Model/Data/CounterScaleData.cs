using System;
using System.Xml.Serialization;

namespace CountersAnalysis
{
    [Serializable]
    [XmlRoot("Scale")]
    public struct CounterScaleData
    {
        [XmlAttribute("Value")]
        public float value;

        [XmlAttribute("ZoneType")]
        public int zoneType;

        [XmlAttribute("IsActive")]
        public bool isActive;

        [XmlAttribute("IsBackward")]
        public bool isBackward;

        [XmlAttribute("IsError")]
        public bool isError;
    }
}