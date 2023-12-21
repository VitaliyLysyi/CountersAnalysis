using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace CountersAnalysis
{
    public class RegistredDataHolder : MonoBehaviour
    {
        private RegistredItem _itemPrefab;
        private RegistredItem _currentSelected;
        private List<RegistredItem> _items;

        public void init(RegistredItem item)
        {
            _items = new List<RegistredItem>();
            _itemPrefab = item;
        }

        public void hold(RegistrableData data)
        {
            RegistredItem item = Instantiate(_itemPrefab, transform);
            item.init(data);
            item.onClick += select;
            _items.Add(item);
        }

        public void removeSelected()
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
            RegistredItem item = get(id);
            if (_currentSelected == item)
                return;

            _currentSelected?.hideOutline();
            _currentSelected = item;
            _currentSelected?.showOutline();
        }

        private RegistredItem get(int id) => _items.FirstOrDefault(item => item.id() == id);

        public RegistredItem selected() => _currentSelected;
    }
}