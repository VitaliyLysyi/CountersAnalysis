using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace CountersAnalysis
{
    public class TabsUI : MonoBehaviour
    {
        [Serializable]
        private class TabPanel
        {
            public Button button;
            public ContentPanel content;
        }

        [SerializeField] private List<TabPanel> _tabPanels;
        private TabPanel _currentPanel;

        private void Start()
        {
            initPanels();
        }

        private void initPanels()
        {
            foreach (var tab in _tabPanels)
            {
                tab.content.hide();
                tab.button.onClick.AddListener(() => switchPanels(tab));
            }

            _currentPanel = _tabPanels[0];
            _currentPanel.content.show();
        }

        private void switchPanels(TabPanel panel)
        {
            _currentPanel.content.hide();
            _currentPanel = panel;
            _currentPanel.content.show();
        }

        private void OnDestroy()
        {
            _tabPanels.ForEach(tab => tab.button.onClick.RemoveAllListeners());
        }
    }
}