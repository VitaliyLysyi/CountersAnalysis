using System.Collections.Generic;

namespace CountersAnalysis
{
    public class PackageRegister
    {
        private string _registerFileName;
        private List<RegisterElementData> _registerData;

        public void addPackage(CountersPackageData packageData, string path)
        {
            RegisterElementData registerData = new RegisterElementData();
            registerData.path = path;
            _registerData.Add(registerData);
        }

        public void loadRegister(string path)
        {
            PackageRegisterData packageRegisterData = DataHandler.loadXML<PackageRegisterData>(path);
            if (packageRegisterData.Equals(default(PackageRegisterData)))
            {
                packageRegisterData = new PackageRegisterData();
                packageRegisterData.registerData = new List<RegisterElementData>();
            }

            _registerData = packageRegisterData.registerData;
            _registerFileName = path;
        }

        public void saveRegister()
        {
            PackageRegisterData packageRegisterData = new PackageRegisterData();
            packageRegisterData.registerData = _registerData;
            DataHandler.saveXML<PackageRegisterData>(packageRegisterData, _registerFileName);
        }

        public bool isEmpty => _registerData.Count == 0 ? true : false;

        public List<RegisterElementData> registerData => _registerData;
    }
}