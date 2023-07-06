using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace CountersAnalysis
{
    public class MakeConsumptionPackageWindow : ContentPanel
    {
        [SerializeField] private Button _closeButton;
        [SerializeField] private Button _acceptButton;
        [SerializeField] private TMP_Dropdown _fromPackageDropdown;
        [SerializeField] private TMP_Dropdown _toPackageDropdown;

        public event Action onAcceptButtonClick;

        private void Start()
        {
            _closeButton.onClick.AddListener(hide);
        }

        private void OnDestroy()
        {
            _closeButton.onClick.RemoveAllListeners();
        }
    }
}