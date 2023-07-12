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
        public bool isFirstEventValue;

        [XmlElement("note")]
        public string note;

        [XmlElement("HeadCounter")]
        public CounterData headCounter;

        [XmlElement("Counter")]
        public List<CounterData> counters;

        public List<string> packageCSVStringList()
        {
            List<string> list = new List<string>();
            list.Add("Date: " + date);
            list.Add("Note: " + note);
            list.Add("Number:, Check ID:, Customer, A+(1), A+(2), A+(3), A+(4), A-(1), A-(2), A-(3), A-(4)");
            list.Add("Head Counter: ");
            list.Add(headCounter.counterCSVString());
            list.Add("Counters: ");
            foreach (CounterData counter in counters)
            {
                list.Add(counter.counterCSVString());
            }
            return list;
        }
    }
}