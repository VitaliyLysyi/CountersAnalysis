using System;
using UnityEngine;

namespace CountersAnalysis
{
    public class ContentPanel : MonoBehaviour
    {
        public event Action onShow;
        public event Action onHide;

        protected void onShowInvoke() => onShow?.Invoke();

        protected void onHideInvoke() => onHide?.Invoke();

        public virtual void show()
        {
            gameObject.SetActive(true);
            onShowInvoke();
        }

        public virtual void hide()
        {
            gameObject.SetActive(false);
            onHideInvoke();
        }
    }
}