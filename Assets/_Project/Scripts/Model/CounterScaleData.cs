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
        public int zoneNumber;

        [XmlAttribute("IsActive")]
        public bool isActive;

        [XmlAttribute("IsBackward")]
        public bool isBackward;

        [XmlAttribute("CalculationError")]
        public bool isErrored;
    }
}