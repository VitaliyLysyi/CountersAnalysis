using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace CountersAnalysis
{
    public class DataItem : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField] private Image _backgroundImage;
        [SerializeField] private Color _backgroundColor;
        [SerializeField] private Color _outlineColor;
        protected int _id;

        public event Action<int> onClicked;

        public virtual void init(RegistrableData data) => _id = data.registerID;

        public void OnPointerClick(PointerEventData eventData)
        {
            onClicked?.Invoke(_id);
        }

        public void select() => _backgroundImage.color = _outlineColor;

        public void deselect() => _backgroundImage.color = _backgroundColor;

        public int id => _id;

        private void OnDestroy()
        {
            onClicked = null;
        }
    }
}