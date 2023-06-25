using UnityEditor;
using UnityEngine;

namespace CountersAnalysis
{
    public class DataController
    {
        private MainWindow _mainWindow;
        private PackageRegister _packageRegister;

        public void init(PackageRegister packageRegister, MainWindow mainWindow)
        {
            _mainWindow = mainWindow;
            _packageRegister = packageRegister;

            unpackPackageRegister();

            _mainWindow.onAddNewPackageClick += importNewCountersPackage;
        }

        private void unpackPackageRegister()
        {
            if (_packageRegister.isEmpty)
            {
                Debug.Log("DataController: " + "Register is empty");
                return;
            }

            foreach (RegisterElementData registerData in _packageRegister.registerData)
            {
                string path = registerData.path;
                CountersPackageData counterPackageData = DataHandler.loadXML<CountersPackageData>(path, true);
                _mainWindow.addPackageHoldersList(counterPackageData);
            }
        }

        private void importNewCountersPackage()
        {
            string path = EditorUtility.OpenFilePanel("Import new CountersPackage", "", "xml");
            bool wrongPath = !path.Contains(".xml");
            if (wrongPath)
            {
                Debug.Log("DataController: " + "WrongPath!");
                return;
            }

            CountersPackageData counterPackageData = DataHandler.loadXML<CountersPackageData>(path, true);
            _mainWindow.addPackageHoldersList(counterPackageData);
            _packageRegister.addPackage(counterPackageData, path);
            _packageRegister.saveRegister();
        }
    }
}