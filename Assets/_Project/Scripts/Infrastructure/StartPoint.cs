using UnityEngine;

namespace CountersAnalysis
{
    public class StartPoint : MonoBehaviour
    {
        [SerializeField] private CounterPackageTab _counterPackagaTab;
        [SerializeField] private CalculationPatternsTab _calculationPatternsTab;
        [SerializeField] private CalculationResultTab _calculationResultTab;
        [SerializeField] private InputFieldWindow _inputFieldWindow;

        private void Start()
        {
            _counterPackagaTab.init();
            _calculationPatternsTab.init();
            _calculationResultTab.init();
            _inputFieldWindow.hide();

            Presenter presenter = new Presenter();
            presenter.init(
                _counterPackagaTab,
                _calculationPatternsTab,
                _calculationResultTab,
                _inputFieldWindow
                );

            presenter.start();
        }
    }
}