using System.IO;

namespace CountersAnalysis
{
    public class CountersPackage : IRegistrable
    {
        private RegisterElementData _registrableData;
        private CountersPackageData _packageData;

        public CountersPackage() { }

        public CountersPackage(CountersPackageData packageData, string path)
        {
            _packageData = packageData;

            _registrableData.path = path;
            _registrableData.name = Path.GetFileNameWithoutExtension(path);
            _registrableData.elementType = RegistredDataType.CountersPackage.ToString();
        }

        public RegisterElementData getRegistrableData()
        {
            return _registrableData;
        }

        public void updateRegistrableData(RegisterElementData registrableData)
        {
            _registrableData = registrableData;
        }
    }
}