using System.IO;

namespace CountersAnalysis
{
    public class CountersPackage : IRegistrable
    {
        private RegistrableData _registrableData;
        private CountersPackageData _packageData;

        public CountersPackage() { }

        public CountersPackage(CountersPackageData packageData, string path)
        {
            _packageData = packageData;

            _registrableData.path = path;
            _registrableData.name = Path.GetFileNameWithoutExtension(path);
            _registrableData.elementType = RegistredDataType.CountersPackage.ToString();
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