using System;
using UnityEngine;

namespace CountersAnalysis
{
    public class Presenter
    {
        private CounterPackageTab _counterPackageTab;
        private CalculationPatternsTab _calculationPatternsTab;
        private DataHandler _dataHandler;
        private Register _dataRegister;

        public void init(
            CounterPackageTab counterPackageTab,
            CalculationPatternsTab calculationPatternsTab
            )
        {
            _dataRegister = new Register();
            _dataHandler = new DataHandler();
            _counterPackageTab = counterPackageTab;
            _calculationPatternsTab = calculationPatternsTab;
            eventsSubscribe();
        }

        public void start()
        {
            _dataRegister.load();

            _counterPackageTab.show(_dataRegister.getAllByType(RegistredDataType.CountersPackage));
            _calculationPatternsTab.show(_dataRegister.getAllByType(RegistredDataType.CalculationPattern));
        }

        private void importCounterPackage()
        {
            try
            {
                string path = DialogService.choseFile("Import new CountersPackage", "", "xml");
                CountersPackage countersPackage = _dataHandler.importPackage(path);
                _dataRegister.add(countersPackage);
                _counterPackageTab.show(countersPackage.getRegistrableData());
            }
            catch (Exception exception)
            {
                DialogService.showMessage("Import failed:", exception.Message);
            }
        }

        private void addNewCalculationPattern()
        {
            try
            {
                string path = DialogService.saveFile("Name", "Enter File Name", Constants.DEFAULT_DATA_PATH, "xml");
                CalculationPattern calculationPattern = _dataHandler.createCalculationPattern(path);
                _dataRegister.add(calculationPattern);
                _calculationPatternsTab.show(_dataRegister.getLast());
            }
            catch (Exception exception)
            {
                DialogService.showMessage("Saving failed:", exception.Message);
            }
        }

        private void addCountersToPattern(int id)
        {
            MyDebugger.logRegisterElementDeployed(_dataRegister.getElement(id));
        }

        private void eventsSubscribe()
        {
            Application.quitting += eventsUnsubscribe;
            Application.quitting += _dataRegister.saveData;

            _counterPackageTab.onAddPackageClick += importCounterPackage;
            _counterPackageTab.onRemovePackageClick += _dataRegister.remove;

            _calculationPatternsTab.onAddPatternClick += addNewCalculationPattern;
            _calculationPatternsTab.onAddToPatternClick += addCountersToPattern;
            _calculationPatternsTab.onRemovePatternClick += _dataRegister.remove;
        }

        private void eventsUnsubscribe()
        {
            Application.quitting -= eventsUnsubscribe;
            Application.quitting -= _dataRegister.saveData;

            _counterPackageTab.onAddPackageClick -= importCounterPackage;
            _counterPackageTab.onRemovePackageClick -= _dataRegister.remove;

            _calculationPatternsTab.onAddPatternClick -= addNewCalculationPattern;
            _calculationPatternsTab.onAddToPatternClick -= addCountersToPattern;
            _calculationPatternsTab.onRemovePatternClick -= _dataRegister.remove;
        }
    }
}