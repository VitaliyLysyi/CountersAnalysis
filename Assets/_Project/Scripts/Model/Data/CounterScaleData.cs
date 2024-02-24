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

        [XmlAttribute("ErrorNote")]
        public string errorNote;
    }
}
// TEMP REFERENCE:
//  <Scale Value="9768.048" ZoneType="0" IsActive="true" IsBackward="false" CalculationError="false" />
//  < Scale Value = "8768.0480" IsActive = "true" />
//  < Scale Value = "8768.0480" ZoneType = "1" IsActive = "true" />