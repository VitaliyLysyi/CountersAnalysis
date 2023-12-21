using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace CountersAnalysis
{
    public class RegistrableItemHolder : MonoBehaviour, IItemHolder<RegistrableData>
    {
        private RegistrableDataItem _itemPrefab;
        private RegistrableDataItem _currentSelected;
        private List<RegistrableDataItem> _items = new List<RegistrableDataItem>();

        public void init(IDataItem<RegistrableData> item)
        {
            _itemPrefab = (RegistrableDataItem)item;
        }

        public void create(RegistrableData data)
        {
            RegistrableDataItem item = Instantiate(_itemPrefab, transform);
            item.init(data);
            item.onClick += select;
            _items.Add(item);
        }

        public void remove(RegistrableData data)
        {
            if (_currentSelected == null)
                return;

            _currentSelected.onClick -= select;
            _items.Remove(_currentSelected);
            Destroy(_currentSelected.gameObject);
            _currentSelected = null;
        }

        private void select(int id)
        {
            if (_currentSelected?.id == id)
                return;

            _currentSelected?.hideOutline();
            _currentSelected = get(id);
            _currentSelected?.showOutline();
        }

        private RegistrableDataItem get(int id) => _items.FirstOrDefault(item => item.id == id);

        public RegistrableDataItem selected => _currentSelected;
    }
}