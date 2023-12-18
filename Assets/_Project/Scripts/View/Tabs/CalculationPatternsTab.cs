using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace CountersAnalysis
{
    public class CalculationPatternsTab : ContentWindow
    {
        [SerializeField] private PatternDataItem _dataItemPrefab;
        [SerializeField] private DataItemHolder _itemHolder;
        [SerializeField] private Button _addPatternButton;
        [SerializeField] private Button _removePatternButton;
        [SerializeField] private Button _addToPatternButton;
        [SerializeField] private Button _removeFromPatternButton;

        public event Action onAddClick;
        public event Action<int> onRemoveClick;
        public event Action<int> onAddToPatternClick;
        public event Action<int> onRemoveFromPatternClick;

        public void init()
        {
            _itemHolder.init(_dataItemPrefab);

            _addPatternButton.onClick.AddListener(addClick);
            _removePatternButton.onClick.AddListener(removeData);
            _addToPatternButton.onClick.AddListener(addToPatternClick);
            _removeFromPatternButton.onClick.AddListener(removeFromPatternClick);
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

        private void addToPatternClick()
        {
            if (_itemHolder.selected == null)
                return;

            onAddToPatternClick?.Invoke(_itemHolder.selected.id);
        }

        private void removeFromPatternClick()
        {
            if (_itemHolder.selected == null)
                return;

            onRemoveFromPatternClick?.Invoke(_itemHolder.selected.id);
        }

        private void removeData()
        {
            if (_itemHolder.selected == null)
                return;

            onRemoveClick?.Invoke(_itemHolder.selected.id);
            _itemHolder.removeSelected();
        }

        private void OnDestroy()
        {
            _addPatternButton.onClick.RemoveAllListeners();
            _addToPatternButton.onClick.RemoveAllListeners();
            _removePatternButton.onClick.RemoveAllListeners();
            _removeFromPatternButton.onClick.RemoveAllListeners();
            onAddClick = null;
            onRemoveClick = null;
            onAddToPatternClick = null;
            onRemoveFromPatternClick = null;
        }
    }
}