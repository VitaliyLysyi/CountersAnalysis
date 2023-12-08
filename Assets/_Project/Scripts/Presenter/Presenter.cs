using System;
using UnityEngine;

namespace CountersAnalysis
{
    public class Presenter
    {
        private CounterPackageTab _counterPackageTab;
        private Register _dataRegister;

        public void init(
            Register dataRegister,
            CounterPackageTab counterPackageTab
            )
        {
            _dataRegister = dataRegister;
            _dataRegister.load();

            _counterPackageTab = counterPackageTab;
            initCounterPackageTab();

            eventSubscribe();
        }

        private void initCounterPackageTab()
        {
            _counterPackageTab.init();

            foreach (RegisterElementData element in _dataRegister.getAll())
            {
                _counterPackageTab.add(element);
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
                _counterPackageTab.add(_dataRegister.getLast());
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
        }

        private void eventUnsubscribe()
        {
            Application.quitting -= eventUnsubscribe;

            _counterPackageTab.onAddPackageClick -= importCounterPackage;
        }
    }
}