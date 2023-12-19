using UnityEngine;
using UnityEngine.UI;

namespace CountersAnalysis
{
    public class CalculationResultTab : ContentWindow
    {
        [SerializeField] private ResultDataItem _dataItemPrefab;
        [SerializeField] private DataItem _holderItemPrefab;
        [SerializeField] private DataItemHolder _itemHolder;
        [SerializeField] private Button _runCalculationButton;
        [SerializeField] private Button _deelteResultButton;

        public void init()
        {
            
        }
    }
}