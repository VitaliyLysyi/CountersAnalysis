using System;
using System.Collections.Generic;
using UnityEngine;

namespace CountersAnalysis
{
    public class View
    {
        private CounterPackagesWindow _packagesTab;
        private PatternsWindow _patternsTab;
        private CalculationsWindow _resultsTab;
        private InputFieldWindow _inputFieldWindow;

        public event Action<string> onImportCounterPackage;
        public event Action<string> onNewPatternCreate;
        public event Action<int> onRegistredDataRemove;
        public event Action<int, string> onAddToPattern;
        public event Action<int, string> onRemoveFromPattern;

        public event Action onCalculationRun;

        public void init(
            CounterPackagesWindow counterPackageWindow,
            PatternsWindow calculationPatternsWindow,
            CalculationsWindow calculationResultWindow,
            InputFieldWindow inputFieldWindow)
        {
            _packagesTab = counterPackageWindow;
            _patternsTab = calculationPatternsWindow;
            _resultsTab = calculationResultWindow;
            _inputFieldWindow = inputFieldWindow;

            eventSubscribe();
        }

        private void eventSubscribe()
        {
            Application.quitting += eventUnsubscribe;

            _packagesTab.onAddClick += tryInvokePackageImport;
            _packagesTab.onRemoveClick += invokeRemoveData;

            _patternsTab.onAddClick += tryInvokePatternCreation;
            _patternsTab.onRemoveClick += invokeRemoveData;
            _patternsTab.onAddToPatternClick += addToPatternDialog;
            _patternsTab.onRemoveFromPatternClick += removeFromPatternDialog;

            _resultsTab.onCalculationRun += invokeCalculation;
        }

        private void eventUnsubscribe()
        {
            Application.quitting -= eventUnsubscribe;

            _packagesTab.onAddClick -= tryInvokePackageImport;
            _packagesTab.onRemoveClick -= invokeRemoveData;

            _patternsTab.onAddClick -= tryInvokePatternCreation;
            _patternsTab.onRemoveClick -= invokeRemoveData;
            _patternsTab.onAddToPatternClick -= addToPatternDialog;
            _patternsTab.onRemoveFromPatternClick -= removeFromPatternDialog;

            _resultsTab.onCalculationRun -= invokeCalculation;
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

        private void addToPatternDialog(int id)
        {
            string title = "¬каж≥ть номери л≥чильник≥в";
            string defaultInput = string.Empty;
            _inputFieldWindow.show(title, defaultInput, inputCallback =>
            {
                onAddToPattern?.Invoke(id, inputCallback);
            });
        }

        private void removeFromPatternDialog(int id)
        {
            string title = "¬каж≥ть номери л≥чильник≥в";
            string defaultInput = string.Empty;
            _inputFieldWindow.show(title, defaultInput, inputCallback =>
            {
                onRemoveFromPattern?.Invoke(id, inputCallback);
            });
        }

        private void invokeCalculation()
        {
            onCalculationRun?.Invoke();
        }

        public void showPackages(RegistrableData package)
        {
            _packagesTab.showData(package);
        }

        public void showPackages(List<RegistrableData> packages)
        {
            packages.ForEach(package => _packagesTab.showData(package));
        }

        public void showPatterns(RegistrableData pattern)
        {
            _patternsTab.showData(pattern);
        }

        public void showPatterns(List<RegistrableData> patterns)
        {
            patterns.ForEach(pattern => _patternsTab.showData(pattern));
        }

        public void showResults(List<RegistrableData> results)
        {

        }
    }
}