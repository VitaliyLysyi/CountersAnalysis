using System;
using UnityEngine;
using UnityEngine.UI;

namespace CountersAnalysis
{
    public class CalculationPatternsTab : ContentPanel
    {
        [SerializeField] private PatternDataItem _dataItemPrefab;
        [SerializeField] private DataItemHolder _itemHolder;
        [SerializeField] private Button _addPatternButton;

        public event Action onAddPatternClick;
        public event Action<int> onRemovePatternClick;

        public void init()
        {
            _itemHolder.init(_dataItemPrefab);
            _addPatternButton.onClick.AddListener(() => onAddPatternClick?.Invoke());
        }

        public void showData(RegisterElementData registerElementData)
        {
            _itemHolder.create(registerElementData);
        }

        private void removeData(int id)
        {
            _itemHolder.remove(id);
            onRemovePatternClick?.Invoke(id);
        }

        private void OnDestroy()
        {
            _addPatternButton.onClick.RemoveAllListeners();
            onRemovePatternClick = null;
        }
    }
}