using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace CountersAnalysis
{
    public class PatternsWindow : ContentWindow
    {
        [Header("Buttons")]
        [SerializeField] private Button _addButton;
        [SerializeField] private Button _deleteButton;
        [SerializeField] private Button _addToPatternButton;
        [SerializeField] private Button _removeFromPatternButton;
        [Header("Content")]
        [SerializeField] private RegistredItem _dataItemPrefab;
        [SerializeField] private RegistredDataHolder _itemHolder;

        public event Action onAddClick;
        public event Action<int> onRemoveClick;
        public event Action<int> onAddToPatternClick;
        public event Action<int> onRemoveFromPatternClick;

        public void init()
        {
            _itemHolder.init(_dataItemPrefab);

            _addButton.onClick.AddListener(addClick);
            _deleteButton.onClick.AddListener(removeClick);
            _addToPatternButton.onClick.AddListener(addToPatternClick);
            _removeFromPatternButton.onClick.AddListener(removeFromPatternClick);
        }

        public void showData(RegistrableData registerElementData)
        {
            _itemHolder.hold(registerElementData);
        }

        private void addClick() => onAddClick?.Invoke();

        private void addToPatternClick()
        {
            if (_itemHolder.selected() == null)
                return;

            onAddToPatternClick?.Invoke(_itemHolder.selected().id());
        }

        private void removeFromPatternClick()
        {
            if (_itemHolder.selected() == null)
                return;

            onRemoveFromPatternClick?.Invoke(_itemHolder.selected().id());
        }

        private void removeClick()
        {
            RegistredItem selected = _itemHolder.selected();
            if (selected == null)
                return;

            onRemoveClick?.Invoke(selected.id());
            _itemHolder.removeSelected();
        }

        private void OnDestroy()
        {
            _addButton.onClick.RemoveAllListeners();
            _deleteButton.onClick.RemoveAllListeners();
            _addToPatternButton.onClick.RemoveAllListeners();
            _removeFromPatternButton.onClick.RemoveAllListeners();
            onAddClick = null;
            onRemoveClick = null;
            onAddToPatternClick = null;
            onRemoveFromPatternClick = null;
        }
    }
}