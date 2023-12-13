using UnityEngine;

namespace CountersAnalysis
{
    public class StartPoint : MonoBehaviour
    {
        [SerializeField] private CounterPackageTab _counterPackagaTab;
        [SerializeField] private CalculationPatternsTab _calculationPatternsTab;

        private void Start()
        {
            _counterPackagaTab.init();
            _calculationPatternsTab.init();

            Presenter presenter = new Presenter();
            presenter.init(
                _counterPackagaTab,
                _calculationPatternsTab
                );

            presenter.start();
        }
    }
}