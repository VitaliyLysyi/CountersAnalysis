using UnityEngine;

namespace CountersAnalysis
{
    public class StartPoint : MonoBehaviour
    {
        [SerializeField] private CounterPackageTab _counterPackagaTab;
        [SerializeField] private CalculationPatternsTab _calculationPatternsTab;
        private Presenter _presenter;
        private Register _dataRegister;

        private void Start()
        {
            _dataRegister = new Register();

            _presenter = new Presenter();
            _presenter.init(
                _dataRegister,
                _counterPackagaTab,
                _calculationPatternsTab
                );
        }
    }
}