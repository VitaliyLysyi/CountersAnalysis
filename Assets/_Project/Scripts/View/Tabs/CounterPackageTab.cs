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

        [SerializeField] private RegistrableItemHolder _newItemHolder;
        [SerializeField] private RegistrableDataItem _newDataItemPrefab;

        public void init()
        {
            _itemHolder.init(_dataItemPrefab);

            _addPackageButton.onClick.AddListener(addClick);
            _deletePackageButton.onClick.AddListener(removeData);


            _newItemHolder.init(_newDataItemPrefab);
        }

        public void showData(RegistrableData registerElementData)
        {
            //_itemHolder.create(registerElementData);

            _newItemHolder.create(registerElementData);
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
            //if (_itemHolder.selected == null)
            //    return;

            //onRemoveClick?.Invoke(_itemHolder.selected.id);
            //_itemHolder.removeSelected();

            if (_newItemHolder.selected == null)
                return;

            onRemoveClick?.Invoke(_newItemHolder.selected.id);
            _newItemHolder.remove(new RegistrableData());
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