using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

namespace CountersAnalysis
{
    public class CountersPackageRegister
    {
        private int _lastID;
        private List<PackageRegisterElementData> _registerData;

        public void addPackage(CountersPackage package)
        {
            PackageRegisterElementData registerElement = getRegistredElement(package.name);
            bool elementNotRegistred = registerElement.Equals(default(PackageRegisterElementData));
            if (!elementNotRegistred)
            {
                throw new Exception("Package already registred!");
            }

            string registredPath = Constants.REGISTRED_PACKAGES_DIRECTORY + "/" + package.name + ".xml";
            PackageRegisterElementData registerData = new PackageRegisterElementData(package, ++_lastID, registredPath);
            _registerData.Add(registerData);

            package.save(registerData.path);
            saveRegister();
        }

        public PackageRegisterElementData getRegistredElement(int id)
        {
            return _registerData.FirstOrDefault(element => element.registerID == id);
        }

        public PackageRegisterElementData getRegistredElement(string name)
        {
            return _registerData.FirstOrDefault(element => element.name == name);
        }

        public void loadRegister()
        {
            string path = Constants.DEFAULT_REGISTER_FILE_PATH;
            Debug.Log("Register path: " + path);
            PackageRegisterData packageRegisterData = DataHandler.loadXML<PackageRegisterData>(path);

            bool registerDataNotExist = packageRegisterData.Equals(default(PackageRegisterData));
            if (registerDataNotExist)
            {
                createRegister();
                return;
            }

            _lastID = packageRegisterData.lastID;
            _registerData = packageRegisterData.registerData;

        }

        private void createRegister()
        {
            _lastID = 0;
            _registerData = new List<PackageRegisterElementData>();

            if (!Directory.Exists(Constants.REGISTRED_PACKAGES_DIRECTORY))
            {
                Directory.CreateDirectory(Constants.REGISTRED_PACKAGES_DIRECTORY);
            }
        }

        public void saveRegister()
        {
            PackageRegisterData packageRegisterData = new PackageRegisterData(_lastID, _registerData);
            string path = Constants.DEFAULT_REGISTER_FILE_PATH;
            DataHandler.saveXML<PackageRegisterData>(packageRegisterData, path);
        }

        public bool isEmpty => _registerData.Count == 0 ? true : false;

        public List<PackageRegisterElementData> registerData => _registerData;

        public PackageRegisterElementData lastRegistredData => _registerData.LastOrDefault();
    }
}