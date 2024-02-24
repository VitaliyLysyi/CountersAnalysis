using System;
using UnityEngine;
using UnityEngine.UI;

namespace CountersAnalysis
{
    public class CalculationsWindow : ContentWindow
    {
        [Header("Buttons")]
        [SerializeField] private Button _runCalculationButton;
        [SerializeField] private Button _deelteResultButton;

        public event Action onCalculationRun;

        public void init()
        {
            _runCalculationButton.onClick.AddListener(invokeRunCalculation);
        }

        private void invokeRunCalculation()
        {
            onCalculationRun?.Invoke();
        }

        private void OnDestroy()
        {
            _runCalculationButton.onClick.RemoveAllListeners();
            onCalculationRun = null;
        }
    }
}