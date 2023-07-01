using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace CountersAnalysis
{
    public class CountersPackageRegister
    {
        private int _lastID;
        private string _registerDataFilePath;
        private List<PackageRegisterElementData> _registerData;

        private string DEFALULT_PATH = Application.persistentDataPath + "/";

        public void addPackage(CountersPackage package)
        {
            PackageRegisterElementData registerData = new PackageRegisterElementData();
            registerData.registerID = ++_lastID;
            registerData.name = package.name;
            registerData.packageType = package.type;
            registerData.note = package.note;
            registerData.date = package.date;
            registerData.path = DEFALULT_PATH /*+ "CountersPackages/"*/ + package.name + ".xml";
            registerData.headCounterNumber = package.headCounter.number;
            registerData.countersCount = package.countersCount;
            _registerData.Add(registerData);
            package.save(registerData.path);
            saveRegister();
        }

        public PackageRegisterElementData getRegistredElement(int id)
        {
            return _registerData.FirstOrDefault(element => element.registerID == id);
        }

        public void loadRegister(string path)
        {
            PackageRegisterData packageRegisterData = DataHandler.loadXML<PackageRegisterData>(path);
            if (packageRegisterData.Equals(default(PackageRegisterData)))
            {
                packageRegisterData = new PackageRegisterData();
                packageRegisterData.registerData = new List<PackageRegisterElementData>();
            }

            _lastID = packageRegisterData.lastID;
            _registerData = packageRegisterData.registerData;
            _registerDataFilePath = path;
        }

        public void saveRegister()
        {
            PackageRegisterData packageRegisterData = new PackageRegisterData();
            packageRegisterData.lastID = _lastID;
            packageRegisterData.registerData = _registerData;
            DataHandler.saveXML<PackageRegisterData>(packageRegisterData, _registerDataFilePath);
        }

        public bool isEmpty => _registerData.Count == 0 ? true : false;

        public List<PackageRegisterElementData> registerData => _registerData;

        public int lastID => _lastID;
    }
}