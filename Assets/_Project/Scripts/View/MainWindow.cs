using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace CountersAnalysis
{
    public class MainWindow : ContentPanel
    {
        [SerializeField] private PackageDataHolder _packageDataHolderPrefab;
        [SerializeField] private Transform _observerPanelTransform;
        [SerializeField] private Button _addNewPackageButton;
        [SerializeField] private Button _extractByNumbers;
        private List<PackageDataHolder> _packageHolders;

        public Action onAddNewPackageClick;
        public Action onExtractByNumbersClick;

        private void Start()
        {
            _addNewPackageButton.onClick.AddListener(() => onAddNewPackageClick?.Invoke());
            _extractByNumbers.onClick.AddListener(() => onExtractByNumbersClick?.Invoke());
        }

        public void displayRegistredData(PackageRegisterElementData packageRegisterElementData)
        {
            PackageDataHolder packageDataHolder = Instantiate(_packageDataHolderPrefab, _observerPanelTransform);
            packageDataHolder.init(packageRegisterElementData);
            //_packageHolders.Add(packageHolder);
        }
    }
}