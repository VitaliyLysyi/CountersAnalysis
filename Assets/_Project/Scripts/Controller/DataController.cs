using System;
using System.IO;
using UnityEditor;
using UnityEngine;

namespace CountersAnalysis
{
    public class DataController
    {
        private MainWindow _mainWindow;
        private RegistredDataConfigWindow _configWindow;
        private MakeConsumptionPackageWindow _makeConsumptionPackageWindow;
        private CountersPackageRegister _packageRegister;

        public void init(
            CountersPackageRegister packageRegister, 
            MainWindow mainWindow,
            RegistredDataConfigWindow registerDataConfigWindow,
            MakeConsumptionPackageWindow makeConsumptionPackageWindow
            )
        {
            _mainWindow = mainWindow;
            _configWindow = registerDataConfigWindow;
            _makeConsumptionPackageWindow = makeConsumptionPackageWindow;
            _packageRegister = packageRegister;

            foreach (RegistredPackageData registerData in _packageRegister.registerData)
            {
                _mainWindow.displayRegistredData(registerData);
            }            

            Application.quitting += onAppClose;
            _mainWindow.onAddNewPackageClick += importNewCountersPackageData;
            _mainWindow.onOpenConfigWindowClick += showConfigWindow;
            _mainWindow.onMakeConsumptionPackageClick += showMakeConsumptionPackageWindow;
            _makeConsumptionPackageWindow.onAcceptButtonClick += createConsumptionPackage;
            _configWindow.onDeleteClick += deleteRegistredData;
        }

        private void importNewCountersPackageData()
        {
            try
            {
                string path = choseFilePathDialog("Import new CountersPackage", targetExtension: "xml");
                CountersPackage countersPackage = new CountersPackage(path);
                _packageRegister.addPackage(countersPackage);
                _mainWindow.displayRegistredData(_packageRegister.lastRegistredData);
            }
            catch (Exception exception)
            {
                Debug.LogWarning("Impoort failed: " + exception.Message);
            }
        }

        private string choseFilePathDialog(string title, string directory = "", string targetExtension = "")
        {
            string path = EditorUtility.OpenFilePanel(title, directory, targetExtension);
            if (targetExtension == "")
            {
                return path;
            }

            string fileExtension = Path.GetExtension(path);
            if (fileExtension == ("." + targetExtension))
            {
                return path;
            }

            throw new Exception("Wrong file path or extension");
        }

        private void showConfigWindow(int dataID)
        {
            RegistredPackageData packageData = _packageRegister.getRegistredElement(dataID);
            _configWindow.init(packageData);
            _configWindow.show();
        }

        private void deleteRegistredData(int dataID)
        {
            _packageRegister.removeRegistred(dataID);
            _mainWindow.removeDataHolder(dataID);
        }

        private void showMakeConsumptionPackageWindow()
        {
            _makeConsumptionPackageWindow.init(_packageRegister.registerData);
            _makeConsumptionPackageWindow.show();
        }

        private void createConsumptionPackage(string fromPackageName, string toPackageName)
        {
            RegistredPackageData fromPackageData = _packageRegister.getRegistredElement(fromPackageName);
            RegistredPackageData toPackageData = _packageRegister.getRegistredElement(toPackageName);
            CountersPackage fromPackage = new CountersPackage(fromPackageData.path);
            CountersPackage toPackage = new CountersPackage(toPackageData.path);
            CountersPackage consumptionPackage = CountersPackage.makeConsumptionPackage(fromPackage, toPackage);
            _packageRegister.addPackage(consumptionPackage);
            _mainWindow.displayRegistredData(_packageRegister.lastRegistredData);
        }

        private void onAppClose()
        {
            Application.quitting -= onAppClose;
            _mainWindow.onAddNewPackageClick -= importNewCountersPackageData;
            _mainWindow.onOpenConfigWindowClick -= showConfigWindow;
            _mainWindow.onMakeConsumptionPackageClick -= showMakeConsumptionPackageWindow;
            _configWindow.onDeleteClick -= deleteRegistredData;
        }

        //private void extractNewPackageByNumbers() //TO DO
        //{
        //    string path = EditorUtility.OpenFilePanel("Select TXT with counter numbers", "", "txt");
        //    bool wrongPath = !path.Contains(".txt");
        //    if (wrongPath)
        //    {
        //        Debug.Log("DataController: " + "WrongPath!");
        //        return;
        //    }

        //    List<string> numbers = DataHandler.readTExtFromFile(path);
        //    string packagePath = _packageRegister.registerData[0].path;
        //    CountersPackageData referencePackage = DataHandler.loadXML<CountersPackageData>(packagePath);
        //    CountersPackageData extractedPackage = extractPackageFromReference(referencePackage, numbers);
        //    MyLogger.LogPackage(extractedPackage);
        //}

        //private CountersPackageData extractPackageFromReference(CountersPackageData referencePackage, List<string> counterNumbers)
        //{
        //    CountersPackageData resultPackage = new CountersPackageData();
        //    resultPackage.date = referencePackage.date;
        //    resultPackage.isFirstEventValue = referencePackage.isFirstEventValue;

        //    resultPackage.counters = new List<CounterData>();
        //    foreach (string counterNumber in counterNumbers)
        //    {
        //        CounterData counter = getCounterByNumber(referencePackage.counters, counterNumber);
        //        bool notDefault = !counter.Equals(default(CounterData));
        //        if (notDefault)
        //        {
        //            resultPackage.counters.Add(counter);
        //        }
        //    }
        //    return resultPackage;
        //}
    }
}