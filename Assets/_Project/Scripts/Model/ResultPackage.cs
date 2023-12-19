using System.IO;

namespace CountersAnalysis
{
    public class ResultPackage : IRegistrable
    {
        private RegistrableData _registrableData;
        private ResultPackageData _packageData;

        public ResultPackage() { }

        public ResultPackage(ResultPackageData packageData, string path)
        {
            _packageData = packageData;

            _registrableData.path = path;
            _registrableData.name = Path.GetFileNameWithoutExtension(path);
            _registrableData.elementType = RegistredDataType.ResultPackage.ToString();
        }

        public void addPackage(CountersPackage package)
        {
            RegistrableData regitrableData = package.getRegistrableData();
            _packageData.packages.Add(regitrableData);
        }

        public RegistrableData getRegistrableData()
        {
            return _registrableData;
        }

        public void updateRegistrableData(RegistrableData registrableData)
        {
            _registrableData = registrableData;
        }
    }
}