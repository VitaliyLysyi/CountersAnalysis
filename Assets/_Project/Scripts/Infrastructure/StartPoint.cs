using UnityEngine;

namespace CountersAnalysis
{
    public class StartPoint : MonoBehaviour
    {
        [SerializeField] private CounterPackageTab _counterPackagaTab;
        [SerializeField] private CalculationPatternsTab _calculationPatternsTab;
        [SerializeField] private InputFieldWindow _inputFieldWindow;

        private void Start()
        {
            _counterPackagaTab.init();
            _calculationPatternsTab.init();
            _inputFieldWindow.hide();

            Presenter presenter = new Presenter();
            presenter.init(
                _counterPackagaTab,
                _calculationPatternsTab,
                _inputFieldWindow
                );

            presenter.start();
        }
    }
}