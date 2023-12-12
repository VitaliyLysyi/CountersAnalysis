using TMPro;
using UnityEngine;

namespace CountersAnalysis
{
    public class PatternDataItem : DataItem
    {
        [SerializeField] private TextMeshProUGUI _nameText;
        [SerializeField] private TextMeshProUGUI _noteText;

        public override void init(RegisterElementData registerElement)
        {
            _id = registerElement.registerID;
            _nameText.text = registerElement.name;
            _noteText.text = registerElement.registerID.ToString();
        }
    }
}