using System;
using UnityEngine;

namespace CountersAnalysis
{
    public class Presenter
    {
        private CounterPackageTab _counterPackageTab;
        private CalculationPatternsTab _calculationPatternsTab;
        private Register _dataRegister;

        public void init(
            Register dataRegister,
            CounterPackageTab counterPackageTab,
            CalculationPatternsTab calculationPatternsTab
            )
        {
            _dataRegister = dataRegister;
            _dataRegister.load();

            _counterPackageTab = counterPackageTab;
            initCounterPackageTab();

            _calculationPatternsTab = calculationPatternsTab;
            //initCalculationPackageTab();

            eventSubscribe();
        }

        private void initCounterPackageTab()
        {
            _counterPackageTab.init();

            foreach (RegisterElementData element in _dataRegister.getAll())
            {
                _counterPackageTab.showData(element);
            }
        }

        private void initCalculationPackageTab()
        {
            _calculationPatternsTab.init();
            foreach (RegisterElementData element in _dataRegister.getAll())
            {
                _calculationPatternsTab.showData(element);
            }
        }

        private void importCounterPackage()
        {
            try
            {
                string path = DialogService.choseFile("Import new CountersPackage", "", "xml");
                CountersPackage countersPackage = DataHandler.getPackage(path);
                RegisterElementData registerElementData = DataHandler.getRegisterElementData(countersPackage);

                _dataRegister.add(registerElementData);
                _counterPackageTab.showData(_dataRegister.getLast());
            }
            catch (Exception exception)
            {
                DialogService.showMessage("Import failed:", exception.Message);
            }
        }

        private void eventSubscribe()
        {
            Application.quitting += eventUnsubscribe;

            _counterPackageTab.onAddPackageClick += importCounterPackage;
            _counterPackageTab.onRemovePackageClick += _dataRegister.remove;
        }

        private void eventUnsubscribe()
        {
            Application.quitting -= eventUnsubscribe;

            _counterPackageTab.onAddPackageClick -= importCounterPackage;
            _counterPackageTab.onRemovePackageClick -= _dataRegister.remove;
        }
    }
}