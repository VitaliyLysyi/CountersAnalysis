using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace CountersAnalysis
{
    public class UITabComponent : MonoBehaviour
    {
        [Serializable]
        private class ButtonTabPair
        {
            public Button button;
            public ContentWindow content;
        }

        [SerializeField] private List<ButtonTabPair> _tabs;
        private ButtonTabPair _currentTab;

        private void Start()
        {
            initPanels();
        }

        private void initPanels()
        {
            foreach (var tab in _tabs)
            {
                tab.content.hide();
                tab.button.onClick.AddListener(() => switchTabs(tab));
            }

            _currentTab = _tabs[0];
            _currentTab.content.show();
        }

        private void switchTabs(ButtonTabPair tab)
        {
            _currentTab.content.hide();
            _currentTab = tab;
            _currentTab.content.show();
        }

        private void OnDestroy()
        {
            _tabs.ForEach(tab => tab.button.onClick.RemoveAllListeners());
        }
    }
}