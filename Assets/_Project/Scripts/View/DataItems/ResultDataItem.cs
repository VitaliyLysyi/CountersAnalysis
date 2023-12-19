using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace CountersAnalysis
{
    public class ResultDataItem : DataItem
    {
        [SerializeField] private TextMeshProUGUI _nameText;
        [SerializeField] private TextMeshProUGUI _noteText;
        [SerializeField] private TextMeshProUGUI _dateText;
        [SerializeField] private DataItemHolder _holder;

        public override void init(RegistrableData data)
        {
            _id = data.registerID;

            _nameText.text = data.name;
            _noteText.text = data.note;
            _dateText.text = data.date.ToString();
        }

        public void init(RegistrableData resultData, List<RegistrableData> _packageDatas)
        {
            init(resultData);
        }
    }
}