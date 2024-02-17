using System;
using System.Collections.Generic;
using UnityEngine;

namespace CountersAnalysis
{
    public class View
    {
        private CounterPackagesWindow _packagesUITab;
        private PatternsWindow _patternsUITab;
        private CalculationsWindow _resultUITab;
        private InputFieldWindow _inputFieldWindow;

        public event Action<string> onImportCounterPackage;
        public event Action<string> onNewPatternCreate;
        public event Action<int> onRegistredDataRemove;

        public void init(
            CounterPackagesWindow counterPackageTab,
            PatternsWindow calculationPatternsTab,
            CalculationsWindow calculationResultTab,
            InputFieldWindow inputFieldWindow)
        {
            _packagesUITab = counterPackageTab;
            _patternsUITab = calculationPatternsTab;
            _resultUITab = calculationResultTab;
            _inputFieldWindow = inputFieldWindow;

            eventSubscribe();
        }

        private void eventSubscribe()
        {
            Application.quitting += eventUnsubscribe;

            _packagesUITab.onAddClick += tryInvokePackageImport;
            _packagesUITab.onRemoveClick += invokeRemoveData;

            _patternsUITab.onAddClick += tryInvokePatternCreation;
            _patternsUITab.onRemoveClick += invokeRemoveData;
        }

        private void eventUnsubscribe()
        {
            Application.quitting -= eventUnsubscribe;

            _packagesUITab.onAddClick -= tryInvokePackageImport;
            _packagesUITab.onRemoveClick -= invokeRemoveData;

            _patternsUITab.onAddClick -= tryInvokePatternCreation;
            _patternsUITab.onRemoveClick -= invokeRemoveData;
        }

        private void tryInvokePackageImport()
        {
            try
            {
                string dialogTitle = "Import new Counters Package";
                string path = DialogService.getFilePathWithExtension(dialogTitle, "", "xml");
                onImportCounterPackage?.Invoke(path);
            }
            catch (Exception exception)
            {
                DialogService.showMessage("Import failed:", exception.Message);
            }
        }

        private void tryInvokePatternCreation()
        {
            try
            {
                string defaultFileName = "NewCalculationPattern";
                string dialogTitle = "Enter file name for new Calculation Pattern";
                string path = DialogService.getSavedFilePathWithExtension(defaultFileName, dialogTitle, "", "xml");
                onNewPatternCreate?.Invoke(path);
            }
            catch (Exception exception)
            {
                DialogService.showMessage("Saving failed:", exception.Message);
            }
        }

        private void invokeRemoveData(int id)
        {
            onRegistredDataRemove?.Invoke(id);
        }

        public void showPackages(RegistrableData package)
        {
            _packagesUITab.showData(package);
        }

        public void showPackages(List<RegistrableData> packages)
        {
            packages.ForEach(package => _packagesUITab.showData(package));
        }

        public void showPatterns(RegistrableData pattern)
        {
            _patternsUITab.showData(pattern);
        }

        public void showPatterns(List<RegistrableData> patterns)
        {
            patterns.ForEach(pattern => _patternsUITab.showData(pattern));
        }

        public void showResults(List<RegistrableData> results)
        {

        }
    }
}