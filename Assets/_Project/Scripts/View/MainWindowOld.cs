using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace CountersAnalysis
{
    public class MainWindowOld : ContentPanel
    {
        [SerializeField] private RegistredDataHolder _registredDataHolderPrefab;
        [SerializeField] private Transform _observerPanelTransform;
        [SerializeField] private Button _addNewPackageButton;
        [SerializeField] private Button _makeConsumptionPackageButton;
        private List<RegistredDataHolder> _registredDataHolders;

        public event Action onAddNewPackageClick;
        public event Action onMakeConsumptionPackageClick;
        public event Action<int> onOpenConfigWindowClick;

        public void init()
        {
            _registredDataHolders = new List<RegistredDataHolder>();
            _addNewPackageButton.onClick.AddListener(() => onAddNewPackageClick?.Invoke());
            _makeConsumptionPackageButton.onClick.AddListener(() => onMakeConsumptionPackageClick?.Invoke());
        }

        public void displayRegistredData(RegisterElementData packageRegisterElementData)
        {
            RegistredDataHolder packageDataHolder = Instantiate(_registredDataHolderPrefab, _observerPanelTransform);
            packageDataHolder.init(packageRegisterElementData);
            packageDataHolder.onConfigButtonClick += onOpenConfigWindowInvoke;
            _registredDataHolders.Add(packageDataHolder);
        }

        public void removeDataHolder(int dataID)
        {
            RegistredDataHolder holder = _registredDataHolders.FirstOrDefault(element => element.id == dataID);
            _registredDataHolders.Remove(holder);
            Destroy(holder.gameObject);
        }

        private void onOpenConfigWindowInvoke(int dataID)
        {
            onOpenConfigWindowClick?.Invoke(dataID);
        }

        private void OnDestroy()
        {
            foreach (RegistredDataHolder dataHolder in _registredDataHolders)
            {
                dataHolder.onConfigButtonClick -= onOpenConfigWindowClick;
            }

            _addNewPackageButton.onClick.RemoveAllListeners();
            _makeConsumptionPackageButton.onClick.RemoveAllListeners();
        }
    }
}