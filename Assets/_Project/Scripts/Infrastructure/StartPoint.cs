using UnityEngine;

namespace CountersAnalysis
{
    public class StartPoint : MonoBehaviour
    {
        [SerializeField] private MainWindow _mainWindowContentPanel;
        [SerializeField] private RegistredDataConfigWindow _registeredDataConfigWindow;
        [SerializeField] private MakeConsumptionPackageWindow _makeConsumptionPackageWindow;
        private CountersPackageRegister _packageRegister;
        private DataPresenter _dataController;

        private void Start()
        {
            _mainWindowContentPanel.init();

            _registeredDataConfigWindow.hide();
            _makeConsumptionPackageWindow.hide();

            _packageRegister = new CountersPackageRegister();
            _packageRegister.loadRegister();

            _dataController = new DataPresenter();
            _dataController.init(
                _packageRegister, 
                _mainWindowContentPanel,
                _registeredDataConfigWindow,
                _makeConsumptionPackageWindow
                );
        }
    }
}