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

        public static CounterScaleData calculateConsumption(int coeficient, CounterScaleData startScale, CounterScaleData endScale)
        {
            CounterScaleData scale = new CounterScaleData();
            scale.zoneNumber = endScale.zoneNumber;
            scale.isActive = endScale.isActive;
            scale.isBackward = endScale.isBackward;

            bool valuesAvailable = startScale.value != 0 && endScale.value != 0;
            if (valuesAvailable)
            {
                scale.value = (endScale.value - startScale.value) * coeficient;
                scale.isErrored = false;
            }
            else
            {
                scale.value = 0;
                scale.isErrored = true;
            }

            return scale;
        }
    }
}