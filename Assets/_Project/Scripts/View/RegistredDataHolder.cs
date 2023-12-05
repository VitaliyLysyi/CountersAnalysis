using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace CountersAnalysis
{
    public class RegistredDataHolder : MonoBehaviour
    {
        [SerializeField] private Button _configButton;
        [SerializeField] private TextMeshProUGUI _packageNameText;
        [SerializeField] private TextMeshProUGUI _noteText;
        [SerializeField] private TextMeshProUGUI _dateText;
        private int _dataID;

        public event Action<int> onConfigButtonClick;

        public void init(RegisterElementData registredData)
        {
            _dataID = registredData.registerID;
            _packageNameText.text = registredData.name;
            _noteText.text = registredData.note;
            _dateText.text = registredData.date.ToString();
            _configButton.onClick.AddListener(() => onConfigButtonClick?.Invoke(_dataID));
        }

        public int id => _dataID;

        private void OnDestroy()
        {
            _configButton.onClick.RemoveAllListeners();
        }
    }
}