namespace CountersAnalysis
{
    public class CountersPackage
    {
        private string _name;
        private string _path;
        private string _packageType;
        private CountersPackageData _packageData;

        public string name { get { return _name; } }
        public string path { get { return _path; } }
        public string packageType { get { return _packageType; } }
        public CountersPackageData data => _packageData;

        public CountersPackage() { }

        public CountersPackage(string name, string path, CountersPackageData packageData)
        {
            _name = name;
            _path = path;
            _packageData = packageData;
        }
    }
}