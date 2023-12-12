using System;
using UnityEngine;
using UnityEngine.UI;

namespace CountersAnalysis
{
    public class CounterPackageTab : ContentPanel
    {
        [SerializeField] private PackageDataItem _dataItemPrefab;
        [SerializeField] private DataItemHolder _itemHolder;
        [SerializeField] private Button _addPackageButton;

        public event Action onAddPackageClick;
        public event Action<int> onRemovePackageClick;

        public void init()
        {
            _itemHolder.init(_dataItemPrefab);
            _addPackageButton.onClick.AddListener(() => onAddPackageClick?.Invoke());
        }

        public void showData(RegisterElementData registerElementData)
        {
            _itemHolder.create(registerElementData);
        }

        private void removeData(int id)
        {
            _itemHolder.remove(id);
            onRemovePackageClick?.Invoke(id);
        }

        private void OnDestroy()
        {
            _addPackageButton.onClick.RemoveAllListeners();
            onRemovePackageClick = null;
        }
    }
}