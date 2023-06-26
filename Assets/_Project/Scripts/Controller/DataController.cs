using System.Collections.Generic;
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
            _mainWindow.onExtractByNumbersClick += extractNewPackageByNumbers;
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

        private void extractNewPackageByNumbers() //TO DO
        {
            string path = EditorUtility.OpenFilePanel("Select TXT with counter numbers", "", "txt");
            bool wrongPath = !path.Contains(".txt");
            if (wrongPath)
            {
                Debug.Log("DataController: " + "WrongPath!");
                return;
            }

            List<string> numbers = DataHandler.readTExtFromFile(path);
            string packagePath = _packageRegister.registerData[0].path;
            CountersPackageData referencePackage = DataHandler.loadXML<CountersPackageData>(packagePath, true);
            CountersPackageData extractedPackage = extractPackageFromReference(referencePackage, numbers);
            MyLogger.LogPackage(extractedPackage);
        }

        private CountersPackageData extractPackageFromReference(CountersPackageData referencePackage, List<string> counterNumbers)
        {
            CountersPackageData resultPackage = new CountersPackageData();
            resultPackage.date = referencePackage.date;
            resultPackage.isFirstEventValue = referencePackage.isFirstEventValue;

            resultPackage.counters = new List<CounterData>();
            foreach (string counterNumber in counterNumbers)
            {
                CounterData counter = getCounterByNumber(referencePackage.counters, counterNumber);
                bool notDefault = !counter.Equals(default(CounterData));
                if (notDefault)
                {
                    resultPackage.counters.Add(counter);
                }
            }
            return resultPackage;
        }

        private CounterData getCounterByNumber(List<CounterData> counters, string number)
        {
            foreach (CounterData counter in counters)
            {
                if (counter.number == number)
                {
                    return counter;
                }
            }

            return default(CounterData);
        }
    }
}