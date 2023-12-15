using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace CountersAnalysis
{
    public class CounterPackageTab : ContentWindow
    {
        [SerializeField] private PackageDataItem _dataItemPrefab;
        [SerializeField] private DataItemHolder _itemHolder;
        [SerializeField] private Button _addPackageButton;
        [SerializeField] private Button _deletePackageButton;

        public event Action onAddPackageClick;
        public event Action<int> onRemovePackageClick;

        public void init()
        {
            _itemHolder.init(_dataItemPrefab);

            _addPackageButton.onClick.AddListener(() => onAddPackageClick?.Invoke());
            _deletePackageButton.onClick.AddListener(removeData);
        }

        public void showData(RegisterElementData registerElementData)
        {
            _itemHolder.create(registerElementData);
        }

        public void showData(List<RegisterElementData> dataList)
        {
            foreach (RegisterElementData data in dataList)
            {
                showData(data);
            }
        }

        private void removeData()
        {
            if (_itemHolder.selected == null)
                return;

            onRemovePackageClick?.Invoke(_itemHolder.selected.id);
            _itemHolder.removeSelected();
        }

        private void OnDestroy()
        {
            _addPackageButton.onClick.RemoveAllListeners();
            _deletePackageButton.onClick.RemoveAllListeners();
            onRemovePackageClick = null;
            onRemovePackageClick = null;
        }
    }
}