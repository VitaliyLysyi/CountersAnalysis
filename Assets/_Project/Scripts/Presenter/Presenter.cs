using System.Collections.Generic;
using UnityEngine;

namespace CountersAnalysis
{
    public class Presenter
    {
        private View _view;
        private DataHandler _dataHandler;
        private Register _dataRegister;

        public void init(View view)
        {
            _dataRegister = new Register();
            _dataHandler = new DataHandler();
            _view = view;

            eventsSubscribe();
        }

        private void eventsSubscribe()
        {
            Application.quitting += eventsUnsubscribe;
            Application.quitting += _dataRegister.saveData;

            _view.onImportCounterPackage += importCounterPackage;
            _view.onRegistredDataRemove += removeDataFromRegister;
            _view.onNewPatternCreate += createCalculationPattern;
            _view.onAddToPattern += addToPattern;
            _view.onRemoveFromPattern += removeFromPattern;
            _view.onCalculationRun += runTestCalculation;
        }

        private void eventsUnsubscribe()
        {
            Application.quitting -= eventsUnsubscribe;
            Application.quitting -= _dataRegister.saveData;

            _view.onImportCounterPackage -= importCounterPackage;
            _view.onRegistredDataRemove -= removeDataFromRegister;
            _view.onNewPatternCreate -= createCalculationPattern;
            _view.onAddToPattern -= addToPattern;
            _view.onRemoveFromPattern -= removeFromPattern;
            _view.onCalculationRun -= runTestCalculation;
        }

        public void start()
        {
            _dataRegister.load();

            List<RegistrableData> packages = _dataRegister.getAllByType(RegistredDataType.CountersPackage);
            List<RegistrableData> patterns = _dataRegister.getAllByType(RegistredDataType.CalculationPattern);
            _view.showPackages(packages);
            _view.showPatterns(patterns);
        }

        private void importCounterPackage(string path)
        {
            CountersPackage countersPackage = _dataHandler.importPackage(path);
            _dataRegister.add(countersPackage);

            RegistrableData packageRegistrableData = countersPackage.getRegistrableData();
            _view.showPackages(packageRegistrableData);
        }

        private void createCalculationPattern(string path)
        {
            CalculationPattern calculationPattern = _dataHandler.createCalculationPattern(path);
            _dataRegister.add(calculationPattern);

            RegistrableData patternRegistrableData = calculationPattern.getRegistrableData();
            _view.showPatterns(patternRegistrableData);
        }

        private void removeDataFromRegister(int id) => _dataRegister.remove(id);

        private void addToPattern(int id, string input)
        {
            List<string> counterNumbers = _dataHandler.clearSplit(input);
            List<CounterData> counterDatas = _dataHandler.createByNumbers(counterNumbers);

            RegistrableData registrableData = _dataRegister.getData(id);
            CalculationPattern pattern = _dataHandler.openPattern(registrableData);
            pattern.addCounter(counterDatas);
            _dataHandler.savePattern(pattern);
        }

        private void removeFromPattern(int id, string input)
        {
            List<string> counterNumbers = _dataHandler.clearSplit(input);
            List<CounterData> counterDatas = _dataHandler.createByNumbers(counterNumbers);

            RegistrableData registrableData = _dataRegister.getData(id);
            CalculationPattern pattern = _dataHandler.openPattern(registrableData);
            pattern.removeCounter(counterDatas);
            _dataHandler.savePattern(pattern);
        }

        private void runTestCalculation()
        {
            Debug.Log("TEST CALCULATION CLICK");
        }
    }
}