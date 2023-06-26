using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace CountersAnalysis
{
    public class MainWindow : ContentPanel
    {
        [SerializeField] private PackageHolder _packageHolderPrefab;
        [SerializeField] private Transform _observerPanelTransform;
        [SerializeField] private Button _addNewPackageButton;
        [SerializeField] private Button _extractByNumbers;
        private List<PackageHolder> _packageHolders;

        public Action onAddNewPackageClick;
        public Action onExtractByNumbersClick;

        private void Start()
        {
            _addNewPackageButton.onClick.AddListener(() => onAddNewPackageClick?.Invoke());
            _extractByNumbers.onClick.AddListener(() => onExtractByNumbersClick?.Invoke());
        }

        public void addPackageHoldersList(CountersPackageData package)
        {
            PackageHolder packageHolder = Instantiate(_packageHolderPrefab, _observerPanelTransform);
            packageHolder.init(package);
            //_packageHolders.Add(packageHolder);
        }
    }
}