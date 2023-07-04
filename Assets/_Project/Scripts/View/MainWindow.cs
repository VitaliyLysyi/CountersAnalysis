using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace CountersAnalysis
{
    public class MainWindow : ContentPanel
    {
        [SerializeField] private RegistredDataHolder _registredDataHolderPrefab;
        [SerializeField] private RegistredDataConfigWindow _registredDataConfigWindow;
        [SerializeField] private Transform _observerPanelTransform;
        [SerializeField] private Button _addNewPackageButton;
        [SerializeField] private Button _extractByNumbers;
        private List<RegistredDataHolder> _registredDataHolders;

        public event Action onAddNewPackageClick;
        public event Action onExtractByNumbersClick;

        public void init()
        {
            _registredDataConfigWindow.hide();
            _registredDataHolders = new List<RegistredDataHolder>();
            _addNewPackageButton.onClick.AddListener(() => onAddNewPackageClick?.Invoke());
            _extractByNumbers.onClick.AddListener(() => onExtractByNumbersClick?.Invoke());
        }

        public void displayRegistredData(RegistredPackageData packageRegisterElementData)
        {
            RegistredDataHolder packageDataHolder = Instantiate(_registredDataHolderPrefab, _observerPanelTransform);
            packageDataHolder.init(packageRegisterElementData);
            packageDataHolder.onConfigButtonClick += registredDataConfigShow;
            _registredDataHolders.Add(packageDataHolder);
        }

        private void registredDataConfigShow(RegistredDataHolder registredDataHolder)
        {
            _registredDataConfigWindow.init(registredDataHolder.getRegistredData);
            _registredDataConfigWindow.show();
        }

        private void unsubscribeAllDataHolders()
        {
            foreach (RegistredDataHolder dataHolder in _registredDataHolders)
            {
                dataHolder.onConfigButtonClick -= registredDataConfigShow;
            }
        }

        private void OnDestroy()
        {
            if (_registredDataHolders.Count == 0)
            {
                unsubscribeAllDataHolders();
            }

            _addNewPackageButton.onClick.RemoveAllListeners();
            _extractByNumbers.onClick.RemoveAllListeners();
        }
    }
}