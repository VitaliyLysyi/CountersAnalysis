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

        public event Action onAddClick;
        public event Action<int> onRemoveClick;

        public void init()
        {
            _itemHolder.init(_dataItemPrefab);

            _addPackageButton.onClick.AddListener(addClick);
            _deletePackageButton.onClick.AddListener(removeData);
        }

        public void showData(RegistrableData registerElementData)
        {
            _itemHolder.create(registerElementData);
        }

        public void showData(List<RegistrableData> dataList)
        {
            foreach (RegistrableData data in dataList)
            {
                showData(data);
            }
        }

        private void addClick() => onAddClick?.Invoke();

        private void removeData()
        {
            if (_itemHolder.selected == null)
                return;

            onRemoveClick?.Invoke(_itemHolder.selected.id);
            _itemHolder.removeSelected();
        }

        private void OnDestroy()
        {
            _addPackageButton.onClick.RemoveAllListeners();
            _deletePackageButton.onClick.RemoveAllListeners();
            onRemoveClick = null;
            onRemoveClick = null;
        }
    }
}