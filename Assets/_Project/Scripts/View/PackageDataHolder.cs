using TMPro;
using UnityEngine;

namespace CountersAnalysis
{
    public class PackageDataHolder : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _packageNameText;
        [SerializeField] private TextMeshProUGUI _noteText;
        [SerializeField] private TextMeshProUGUI _dateText;
        private int _registerID;

        public void init(PackageRegisterElementData packageData)
        {
            _registerID = packageData.registerID;
            _packageNameText.text = packageData.name;
            _noteText.text = packageData.note;
            _dateText.text = packageData.date.ToString();
        }

        public int id => _registerID;
    }
}