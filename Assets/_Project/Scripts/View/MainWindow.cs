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
        private List<PackageHolder> _packageHolders;

        public Action onAddNewPackageClick;

        private void Start()
        {
            _addNewPackageButton.onClick.AddListener(() => onAddNewPackageClick?.Invoke());
        }

        public void addPackageHoldersList(CountersPackageData package)
        {
            PackageHolder packageHolder = Instantiate(_packageHolderPrefab, _observerPanelTransform);
            packageHolder.init(package);
        }
    }
}