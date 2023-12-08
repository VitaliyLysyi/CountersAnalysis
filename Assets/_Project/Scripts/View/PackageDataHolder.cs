using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace CountersAnalysis
{
    public class PackageDataHolder : MonoBehaviour
    {
        [SerializeField] private Button _deleteButton;
        [SerializeField] private TextMeshProUGUI _nameText;
        [SerializeField] private TextMeshProUGUI _noteText;
        [SerializeField] private TextMeshProUGUI _dateText;
        private RegisterElementData _registerElementData;

        public event Action<int> onDeleteButtonClick;

        public void init(RegisterElementData registerElement)
        {
            _deleteButton.onClick.AddListener(() => onDeleteButtonClick?.Invoke(_registerElementData.registerID));

            _nameText.text = registerElement.name;
            _noteText.text = registerElement.note;
            _dateText.text = registerElement.date.ToString();
        }

        public int id => _registerElementData.registerID;

        private void OnDestroy()
        {
            _deleteButton.onClick.RemoveAllListeners();
        }
    }
}