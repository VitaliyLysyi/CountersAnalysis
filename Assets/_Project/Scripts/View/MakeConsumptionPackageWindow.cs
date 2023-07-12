using System;
using System.Collections.Generic;
using System.Linq;
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

        public event Action<string, string> onAcceptButtonClick;

        private void Start()
        {
            _closeButton.onClick.AddListener(hide);
            _acceptButton.onClick.AddListener(onAcceptButtonClickInvoke);
        }

        public void init(List<RegistredPackageData> registredData)
        {
            List<string> registredPackageNames = registredData
                .Select(registredPackageData => registredPackageData.name)
                .ToList();

            _fromPackageDropdown.ClearOptions();
            _toPackageDropdown.ClearOptions();
            _fromPackageDropdown.AddOptions(registredPackageNames);
            _toPackageDropdown.AddOptions(registredPackageNames);
        }

        private void onAcceptButtonClickInvoke()
        {
            int fromValueIndex = _fromPackageDropdown.value;
            string fromPackageName = _fromPackageDropdown.options[fromValueIndex].text;
            int toValueIndex = _toPackageDropdown.value;
            string toPackageName = _toPackageDropdown.options[toValueIndex].text;

            onAcceptButtonClick?.Invoke(fromPackageName, toPackageName);
            hide();
        }

        private void OnDestroy()
        {
            _closeButton.onClick.RemoveAllListeners();
            _acceptButton.onClick.RemoveAllListeners();
        }
    }
}