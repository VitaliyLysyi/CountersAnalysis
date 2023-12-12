using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace CountersAnalysis
{
    public class PackageDataItem : DataItem
    {
        [SerializeField] private Button _deleteButton;
        [SerializeField] private TextMeshProUGUI _nameText;
        [SerializeField] private TextMeshProUGUI _noteText;
        [SerializeField] private TextMeshProUGUI _dateText;

        public override void init(RegisterElementData registerElement)
        {
            _id = registerElement.registerID;
            _nameText.text = registerElement.name;
            _noteText.text = registerElement.registerID.ToString();
            _dateText.text = registerElement.date.ToString();

        }
    }
}