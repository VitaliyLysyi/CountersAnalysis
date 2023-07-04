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
        private RegistredPackageData _registredData;

        public event Action<RegistredDataHolder> onConfigButtonClick;

        public void init(RegistredPackageData registredData)
        {
            _registredData = registredData;
            _packageNameText.text = registredData.name;
            _noteText.text = registredData.note;
            _dateText.text = registredData.date.ToString();
            _configButton.onClick.AddListener(() => onConfigButtonClick?.Invoke(this));
        }

        public int id => _registredData.registerID;

        public RegistredPackageData getRegistredData => _registredData;

        private void OnDestroy()
        {
            _configButton.onClick.RemoveAllListeners();
        }
    }
}