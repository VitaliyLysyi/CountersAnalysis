using TMPro;
using UnityEngine;

namespace CountersAnalysis
{
    public class PackageHolder : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _packageNameText;
        [SerializeField] private TextMeshProUGUI _noteText;
        [SerializeField] private TextMeshProUGUI _dateText;
        private CountersPackageData _packageData;
        
        public void init(CountersPackageData package)
        {
            _packageData = package;
            _packageNameText.text = package.ToString();
            _noteText.text = package.note;
            _dateText.text = package.date.ToString();
        }
    }
}