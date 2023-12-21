using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System;

namespace CountersAnalysis
{
    public class CounterPackagesWindow : ContentWindow
    {
        [Header("Buttons")]
        [SerializeField] private Button _addButton;
        [SerializeField] private Button _deleteButton;
        [Header("Content")]
        [SerializeField] private RegistredDataHolder _dataHolder;
        [SerializeField] private RegistredItem _registredItemPrefab;

        public event Action onAddClick;
        public event Action<int> onRemoveClick;

        public void init()
        {
            _dataHolder.init(_registredItemPrefab);

            _addButton.onClick.AddListener(addClick);
            _deleteButton.onClick.AddListener(removeClick);
        }

        public void showData(RegistrableData registerElementData)
        {
            _dataHolder.hold(registerElementData);
        }

        public void showData(List<RegistrableData> dataList)
        {
            foreach (RegistrableData data in dataList)
            {
                showData(data);
            }
        }

        private void addClick() => onAddClick?.Invoke();

        private void removeClick()
        {
            RegistredItem selected = _dataHolder.selected();
            if (selected == null)
                return;

            onRemoveClick?.Invoke(selected.id());
            _dataHolder.removeSelected();
        }

        private void OnDestroy()
        {
            _addButton.onClick.RemoveAllListeners();
            _deleteButton.onClick.RemoveAllListeners();
            onRemoveClick = null;
            onRemoveClick = null;
        }
    }
}