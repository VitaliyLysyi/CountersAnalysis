using System;

namespace CountersAnalysis
{
    public class CountersPackage
    {
        private string _name;
        private string _packageType;

        private CountersPackageData _packageData;

        public CountersPackage(CountersPackageData packageData, string name)
        {
            _name = name;
            _packageData = packageData;
            _packageType = "default type";
        }

        public void save(string path)
        {
            DataHandler.saveXML(_packageData, path);
        }

        public string name => _name;
        public string type => _packageType;
        public string note => _packageData.note;
        public DateTime date => _packageData.date;
        public CounterData headCounter => _packageData.headCounter;
        public int countersCount => _packageData.counters.Count;
    }
}