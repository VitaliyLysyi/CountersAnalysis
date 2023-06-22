using System.Collections.Generic;
using UnityEngine;

namespace CountersAnalysis
{
    public class Analysis : MonoBehaviour
    {
        private const string TEST_FILE_NAME = "TestFile";
        private const string REM_TEST_FILE_NAME = "RemTestFile";
        private const string TEST_PACKAGE_FILE_NAME = "TestSavedPackage";

        private void Start()
        {
            //fileSaveTest();
            //fileReadTest();
            readTestRemFile();
            //savePackageTest();
        }

        private void savePackageTest()
        {
            CountersPackageData countersPackage = new CountersPackageData();
            countersPackage.counters = new List<CounterData>();
            countersPackage.note = "Suka blyad!";

            for (int i = 0; i < 10;  i++)
            {
                CounterData counterData = new CounterData();
                counterData.number = i.ToString();

                counterData.scales = new List<CounterScale>();
                for (int j = 0; j < 4; j++)
                {
                    CounterScale counterScale = new CounterScale();
                    counterScale.zoneNumber = j;
                    counterData.scales.Add(counterScale);
                }

                countersPackage.counters.Add(counterData);
            }

            DataHandler.saveXML(countersPackage, TEST_PACKAGE_FILE_NAME);
        }

        private void readTestRemFile()
        {
            CountersPackageData countersPackage = new CountersPackageData();
            //countersPackage.counters = new List<CounterData>();
            countersPackage = DataHandler.loadXML<CountersPackageData>(REM_TEST_FILE_NAME);

            Debug.Log("Package: " + countersPackage);
            Debug.Log("Date: " + countersPackage.date);
            Debug.Log("Note: " + countersPackage.note);
            Debug.Log("Counters found: " + countersPackage.counters.Count);

            foreach (CounterData counter in countersPackage.counters)
            {
                Debug.Log("Number: " + counter.number);
            }
        }

        private void fileReadTest()
        {
            CounterData counterData = new CounterData();
            counterData = DataHandler.loadXML<CounterData>(TEST_FILE_NAME);
            Debug.Log("Object: " + counterData);
            Debug.Log("Number: " + counterData.number);
            Debug.Log("Note: " + counterData.note);
            foreach (CounterScale scale in counterData.scales)
            {
                Debug.Log("Zone: " + scale.zoneNumber);
            }
        }

        private void fileSaveTest()
        {
            CounterData counterData = new CounterData();
            counterData.number = "8855312";
            counterData.note = "Лицевой счет 317094, Гайда Олександра Стефанівна";
            counterData.scales = new List<CounterScale>();

            CounterScale counterScale = new CounterScale();
            counterScale.value = 8768.0480f;
            counterScale.isActive = true;
            counterData.scales.Add(counterScale);

            counterScale = new CounterScale();
            counterScale.value = 8768.0480f;
            counterScale.zoneNumber = 1;
            counterScale.isActive = true;
            counterData.scales.Add(counterScale);

            counterScale = new CounterScale();
            counterScale.value = 0f;
            counterScale.zoneNumber = 2;
            counterScale.isActive = true;
            counterData.scales.Add(counterScale);

            counterScale = new CounterScale();
            counterScale.value = 0f;
            counterScale.zoneNumber = 3;
            counterScale.isActive = true;
            counterData.scales.Add(counterScale);

            DataHandler.saveXML(counterData, TEST_FILE_NAME);
        }
    }
}