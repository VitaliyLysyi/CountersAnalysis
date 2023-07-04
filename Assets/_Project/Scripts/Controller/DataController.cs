using System;
using System.IO;
using UnityEditor;
using UnityEngine;

namespace CountersAnalysis
{
    public class DataController
    {
        private MainWindow _mainWindow;
        private CountersPackageRegister _packageRegister;

        public void init(CountersPackageRegister packageRegister, MainWindow mainWindow)
        {
            _mainWindow = mainWindow;
            _packageRegister = packageRegister;

            if (!_packageRegister.isEmpty)
            {
                foreach (RegistredPackageData registerData in _packageRegister.registerData)
                {
                    _mainWindow.displayRegistredData(registerData);
                }
            }

            Application.quitting += onAppClose;
            _mainWindow.onAddNewPackageClick += importNewCountersPackageData;
            //_mainWindow.onExtractByNumbersClick += extractNewPackageByNumbers;
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

        private void onAppClose()
        {
            Application.quitting -= onAppClose;
            _mainWindow.onAddNewPackageClick -= importNewCountersPackageData;
        }

        //private void importNewCountersPackage()
        //{
        //    string path = EditorUtility.OpenFilePanel("Import new CountersPackage", "", "xml");
        //    bool wrongPath = !path.Contains(".xml");
        //    if (wrongPath)
        //    {
        //        Debug.Log("DataController: " + "WrongPath!");
        //        return;
        //    }

        //    CountersPackageData counterPackageData = DataHandler.loadXML<CountersPackageData>(path, true);
        //    _mainWindow.addPackageData(counterPackageData);
        //    _packageRegister.addPackage(counterPackageData, path);
        //    _packageRegister.saveRegister();
        //}

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

        //private CounterData getCounterByNumber(List<CounterData> counters, string number)
        //{
        //    foreach (CounterData counter in counters)
        //    {
        //        if (counter.number == number)
        //        {
        //            return counter;
        //        }
        //    }

        //    return default(CounterData);
        //}
    }
}