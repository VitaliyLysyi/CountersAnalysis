using System;
using System.Collections.Generic;
using UnityEngine;

namespace CountersAnalysis
{
    public class Presenter
    {
        private CounterPackagesWindow _packagesUITab;
        private PatternsWindow _patternsUITab;
        private CalculationsWindow _resultUITab;
        private InputFieldWindow _inputFieldWindow;
        private DataHandler _dataHandler;
        private Register _dataRegister;

        public void init(
            CounterPackagesWindow counterPackageTab,
            PatternsWindow calculationPatternsTab,
            CalculationsWindow calculationResultTab,
            InputFieldWindow inputFieldWindow
            )
        {
            _dataRegister = new Register();
            _dataHandler = new DataHandler();
            _packagesUITab = counterPackageTab;
            _patternsUITab = calculationPatternsTab;
            _resultUITab = calculationResultTab;
            _inputFieldWindow = inputFieldWindow;
            eventsSubscribe();
        }

        private void eventsSubscribe()
        {
            Application.quitting += eventsUnsubscribe;
            Application.quitting += _dataRegister.saveData;

            _packagesUITab.onAddClick += importCounterPackage;
            _packagesUITab.onRemoveClick += _dataRegister.remove;

            _patternsUITab.onAddClick += addNewCalculationPattern;
            _patternsUITab.onAddToPatternClick += addToPatternClick;
            _patternsUITab.onRemoveFromPatternClick += removeFromPatternClick;
            _patternsUITab.onRemoveClick += _dataRegister.remove;
        }

        private void eventsUnsubscribe()
        {
            Application.quitting -= eventsUnsubscribe;
            Application.quitting -= _dataRegister.saveData;

            _packagesUITab.onAddClick -= importCounterPackage;
            _packagesUITab.onRemoveClick -= _dataRegister.remove;

            _patternsUITab.onAddClick -= addNewCalculationPattern;
            _patternsUITab.onAddToPatternClick -= addToPatternClick;
            _patternsUITab.onRemoveFromPatternClick -= removeFromPatternClick;
            _patternsUITab.onRemoveClick -= _dataRegister.remove;
        }

        public void start()
        {
            _dataRegister.load();

            _packagesUITab.showData(_dataRegister.getAllByType(RegistredDataType.CountersPackage));
            _patternsUITab.showData(_dataRegister.getAllByType(RegistredDataType.CalculationPattern));
        }

        private void importCounterPackage()
        {
            try
            {
                string path = DialogService.choseFile("Import new CountersPackage", "", "xml");
                CountersPackage countersPackage = _dataHandler.importPackage(path);
                _dataRegister.add(countersPackage);
                _packagesUITab.showData(countersPackage.getRegistrableData());
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
                _patternsUITab.showData(_dataRegister.getLast());
            }
            catch (Exception exception)
            {
                DialogService.showMessage("Saving failed:", exception.Message);
            }
        }

        private void addToPatternClick(int id)
        {
            string title = "¬каж≥ть номери л≥чильник≥в";
            _inputFieldWindow.show(title, "", inputString => addToPattern(inputString, id));
        }

        private void addToPattern(string text, int id)
        {
            List<string> counterNumbers = _dataHandler.clearSplit(text);
            List<CounterData> counterDatas = _dataHandler.createByNumbers(counterNumbers);

            RegistrableData registrableData = _dataRegister.getData(id);
            CalculationPattern pattern = _dataHandler.openPattern(registrableData);
            pattern.addCounter(counterDatas);
            _dataHandler.savePattern(pattern);
        }

        private void removeFromPatternClick(int id)
        {
            string title = "¬каж≥ть номери л≥чильник≥в";
            _inputFieldWindow.show(title, "", inputString => removeFromPattern(inputString, id));
        }

        private void removeFromPattern(string text, int id)
        {
            List<string> counterNumbers = _dataHandler.clearSplit(text);
            List<CounterData> counterDatas = _dataHandler.createByNumbers(counterNumbers);

            RegistrableData registrableData = _dataRegister.getData(id);
            CalculationPattern pattern = _dataHandler.openPattern(registrableData);
            pattern.removeCounter(counterDatas);
            _dataHandler.savePattern(pattern);
        }
    }
}