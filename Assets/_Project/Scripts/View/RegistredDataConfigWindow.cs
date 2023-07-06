using System;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

namespace CountersAnalysis
{
    public class RegistredDataConfigWindow : ContentPanel
    {
        [Header("Text Fields")]
        [SerializeField] private TextMeshProUGUI _packageNameText;
        [SerializeField] private TextMeshProUGUI _noteText;
        [SerializeField] private TextMeshProUGUI _dateText;
        [SerializeField] private TextMeshProUGUI _packageTypeText;
        [SerializeField] private TextMeshProUGUI _headCounterText;
        [SerializeField] private TextMeshProUGUI _counterCountText;
        [Header("Buttons")]
        [SerializeField] private Button _closeButton;
        [SerializeField] private Button _deleteButton;
        private int _dataID;

        public event Action<int> onDeleteClick;

        private void Start()
        {
            _closeButton.onClick.AddListener(hide);
            _deleteButton.onClick.AddListener(onDeleteClickInvoke);
        }

        public void init(RegistredPackageData packageData)
        {
            _dataID = packageData.registerID;
            _packageNameText.text = packageData.name;
            _noteText.text = packageData.note;
            _dateText.text = packageData.date.ToString();
            _packageTypeText.text = packageData.packageType;
            _headCounterText.text = packageData.headCounterNumber;
            _counterCountText.text = packageData.countersCount.ToString();
        }

        private void onDeleteClickInvoke()
        {
            bool deltePermission = EditorUtility.DisplayDialog("Delete Package", "Delete confirm?", "Yes", "No");
            if (!deltePermission)
            {
                return;
            }

            onDeleteClick?.Invoke(_dataID);
            hide();
        }

        private void OnDestroy()
        {
            _closeButton.onClick.RemoveAllListeners();
            _deleteButton.onClick.RemoveAllListeners();
        }
    }
}