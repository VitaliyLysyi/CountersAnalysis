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
        [SerializeField] private Button _addToPatternButton;
        [SerializeField] private Button _removePatternButton;

        public event Action onAddPatternClick;
        public event Action<int> onRemovePatternClick;
        public event Action<int> onAddToPatternClick;

        public void init()
        {
            _itemHolder.init(_dataItemPrefab);

            _addPatternButton.onClick.AddListener(() => onAddPatternClick?.Invoke());
            _addToPatternButton.onClick.AddListener(() => onAddToPatternClick?.Invoke(_itemHolder.selected.id));
            _removePatternButton.onClick.AddListener(removeData);
        }

        public void showData(RegisterElementData registerElementData)
        {
            _itemHolder.create(registerElementData);
        }

        public void showData(List<RegisterElementData> dataList)
        {
            foreach(RegisterElementData data in dataList)
            {
                showData(data);
            }
        }

        private void removeData()
        {
            if (_itemHolder.selected == null)
                return;

            onRemovePatternClick?.Invoke(_itemHolder.selected.id);
            _itemHolder.removeSelected();
        }

        private void OnDestroy()
        {
            _addPatternButton.onClick.RemoveAllListeners();
            _addToPatternButton.onClick.RemoveAllListeners();
            _removePatternButton.onClick.RemoveAllListeners();
            onAddPatternClick = null;
            onAddToPatternClick = null;
            onRemovePatternClick = null;
        }
    }
}