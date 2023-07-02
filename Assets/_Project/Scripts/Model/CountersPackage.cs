using System;
using System.IO;

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

        public CountersPackage(string path)
        {
            _packageData = DataHandler.loadXML<CountersPackageData>(path);
            _path = path;
            _name = Path.GetFileNameWithoutExtension(path);
        }

        public void save(string path) => DataHandler.saveXML(_packageData, path);

        public void save() => save(_path);
    }
}