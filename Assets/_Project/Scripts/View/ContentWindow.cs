using System;
using UnityEngine;

namespace CountersAnalysis
{
    public class ContentWindow : MonoBehaviour
    {
        public event Action onShow;
        public event Action onHide;

        public virtual void show()
        {
            gameObject.SetActive(true);
            onShow?.Invoke();
        }

        public virtual void hide()
        {
            gameObject.SetActive(false);
            onHide?.Invoke();
        }
    }
}