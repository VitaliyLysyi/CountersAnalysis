using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace CountersAnalysis
{
    public class CounterPackageTab : ContentPanel
    {
        [SerializeField] private PackageDataHolder _packageHolderPrefab;
        [SerializeField] private Transform _observerContentTransform;
        [SerializeField] private Button _addPackageButton;
        private List<PackageDataHolder> _packageHolders;

        public event Action onAddPackageClick;
        public event Action<int> onDeleteClick;

        public void init()
        {
            _packageHolders = new List<PackageDataHolder>();
            _addPackageButton.onClick.AddListener(() => onAddPackageClick?.Invoke());
        }

        public void add(RegisterElementData registerElementData)
        {
            PackageDataHolder holder = createHolder();
            holder.init(registerElementData);
            _packageHolders.Add(holder);
        }

        private PackageDataHolder createHolder()
        {
            return Instantiate(_packageHolderPrefab, _observerContentTransform);
        }

        private void OnDestroy()
        {
            _addPackageButton.onClick.RemoveAllListeners();
        }
    }
}