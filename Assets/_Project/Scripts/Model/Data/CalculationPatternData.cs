using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace CountersAnalysis
{
    [Serializable]
    [XmlRoot("CalculationPattern")]
    public struct CalculationPatternData
    {
        [XmlElement("HeadCounter")]
        public CounterData headCounter;

        [XmlElement("Counter")]
        public List<CounterData> counters;
    }
}