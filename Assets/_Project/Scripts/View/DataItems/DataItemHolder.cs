using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace CountersAnalysis
{
    public class DataItemHolder : MonoBehaviour
    {
        private DataItem _itemPrefab;
        private DataItem _currentSelected;
        private List<DataItem> _items = new List<DataItem>();

        public void init(DataItem dataItemPrefab)
        {
            _itemPrefab = dataItemPrefab;
        }

        public DataItem create(RegisterElementData registerElementData)
        {
            DataItem item = Instantiate(_itemPrefab, transform);
            item.init(registerElementData);
            item.onClicked += select;
            _items.Add(item);
            return item;
        }

        public void removeSelected()
        {
            if (_currentSelected == null) 
                return;

            _currentSelected.onClicked -= select;
            _items.Remove(_currentSelected);
            Destroy(_currentSelected.gameObject);
            _currentSelected = null;
        }

        private void select(int id)
        {
            if (_currentSelected?.id == id)
                return;

            _currentSelected?.deselect();
            _currentSelected = get(id);
            _currentSelected?.select();
        }

        private DataItem get(int id) => _items.FirstOrDefault(item => item.id == id);

        public DataItem selected => _currentSelected;
    }
}