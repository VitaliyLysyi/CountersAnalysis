using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CountersAnalysis
{
    public class CountersPackage
    {
        private string _name;
        private string _packageType;
        private string _path;
        private CountersPackageData _packageData;

        public string path { get { return _path; } set { _path = path; } }
        public string name { get { return _name; } set { _name = name; } }
        public string type { get { return _packageType; } set { _packageType = type; } }
        public string note => _packageData.note;
        public DateTime date => _packageData.date;
        public CounterData headCounter => _packageData.headCounter;
        public int countersCount => _packageData.counters.Count;
        public List<string> packageCSVstring => _packageData.packageCSVStringList();

        public CountersPackage() { }

        public CountersPackage(string path)
        {
            _packageData = DataHandler.loadXML<CountersPackageData>(path);
            _path = path;
            _name = Path.GetFileNameWithoutExtension(path);
        }

        public static CountersPackage makeConsumptionPackage(CountersPackage fromPackage, CountersPackage toPackage)
        {
            CountersPackage consumptionPackage = new CountersPackage();
            consumptionPackage._name = fromPackage.name + "Consumption";
            consumptionPackage._packageType = "Consumption";

            consumptionPackage._packageData = new CountersPackageData();
            consumptionPackage._packageData.counters = new List<CounterData>();
            consumptionPackage._packageData.date = toPackage.date;
            consumptionPackage._packageData.isFirstEventValue = toPackage._packageData.isFirstEventValue;
            consumptionPackage._packageData.note = toPackage.note;
            consumptionPackage._packageData.headCounter = CounterData.makeCounterConsumptionData(fromPackage.headCounter, toPackage.headCounter);

            foreach (CounterData counter in toPackage._packageData.counters)
            {
                CounterData matchCounter = fromPackage._packageData.counters.FirstOrDefault(match => match.number == counter.number);
                bool found = !matchCounter.Equals(default(CounterData));

                if (found)
                {
                    CounterData counterConsumption = CounterData.makeCounterConsumptionData(matchCounter, counter);
                    consumptionPackage._packageData.counters.Add(counterConsumption);
                }
            }

            return consumptionPackage;
        }

        public void save(string path) => DataHandler.saveXML(_packageData, path);

        public void save() => save(_path);
    }
}