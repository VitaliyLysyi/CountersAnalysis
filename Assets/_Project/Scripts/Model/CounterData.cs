using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

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

        public string counterCSVString()
        {
            string result = string.Empty;
            result += number;
            result += ", " + note;
            foreach (var scale in scales)
            {
                result += ", " + Mathf.Round(scale.value);
            }
            return result;
        }

        public static CounterData makeCounterConsumptionData(CounterData fromCounter, CounterData toCounter)
        {
            CounterData consumptionData = new CounterData();
            consumptionData.number = toCounter.number;
            consumptionData.coeficient = toCounter.coeficient;
            consumptionData.note = toCounter.note;
            consumptionData.scales = new List<CounterScaleData>();

            int minLenght = Mathf.Min(fromCounter.scales.Count, toCounter.scales.Count);
            for (int i = 0; i < minLenght; i++)
            {
                bool boothScalesIsActive = fromCounter.scales[i].isActive && toCounter.scales[i].isActive;
                if (boothScalesIsActive)
                {
                    int coeficient = toCounter.coeficient == 0 ? 1 : toCounter.coeficient;
                    CounterScaleData scale = CounterScaleData.calculateConsumption(coeficient, fromCounter.scales[i], toCounter.scales[i]);
                    consumptionData.scales.Add(scale);
                }
                else
                {
                    CounterScaleData scale = toCounter.scales[i];
                    scale.value = 0;
                }
            }

            return consumptionData;
        }
    }
}