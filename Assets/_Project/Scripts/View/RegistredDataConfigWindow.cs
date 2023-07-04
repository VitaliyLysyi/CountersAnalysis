using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace CountersAnalysis
{
    public class RegistredDataConfigWindow : ContentPanel
    {
        [SerializeField] private Button _closeButton;
        [SerializeField] private TextMeshProUGUI _packageNameText;
        [SerializeField] private TextMeshProUGUI _noteText;
        [SerializeField] private TextMeshProUGUI _dateText;
        [SerializeField] private TextMeshProUGUI _packageTypeText;
        [SerializeField] private TextMeshProUGUI _headCounterText;
        [SerializeField] private TextMeshProUGUI _counterCountText;

        private void Start()
        {
            _closeButton.onClick.AddListener(hide);
        }

        public void init(RegistredPackageData packageData)
        {
            _packageNameText.text = packageData.name;
            _noteText.text = packageData.note;
            _dateText.text = packageData.date.ToString();
            _packageTypeText.text = packageData.packageType;
            _headCounterText.text = packageData.headCounterNumber;
            _counterCountText.text = packageData.countersCount.ToString();
        }

        private void OnDestroy()
        {
            _closeButton.onClick.RemoveAllListeners();
        }
    }
}