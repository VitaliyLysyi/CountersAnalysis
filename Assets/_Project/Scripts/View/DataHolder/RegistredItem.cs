using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

namespace CountersAnalysis
{
    [RequireComponent(typeof(SimpleOutline))]
    public class RegistredItem : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField] TextMeshProUGUI _dataID;
        [SerializeField] TextMeshProUGUI _name;
        [SerializeField] TextMeshProUGUI _path;
        [SerializeField] TextMeshProUGUI _date;
        [SerializeField] TextMeshProUGUI _type;
        [SerializeField] TextMeshProUGUI _note;
        private SimpleOutline _outline;
        private int _id;

        public event Action<int> onClick;

        public void init(RegistrableData data)
        {
            _dataID.text = data.registerID.ToString();
            _type.text = data.elementType.ToString();
            _date.text = data.date.ToString();
            _name.text = data.name;
            _path.text = data.path;
            _note.text = data.note;
            _id = data.registerID;

            initOutline();
        }

        private void initOutline()
        {
            if (_outline != null)
                return;

            _outline = GetComponent<SimpleOutline>();
            Color defaultColor = Constants.DEFAULT_OUTLINE_COLOR;
            Color outlineColor = Constants.SHOW_OUTLINE_COLOR;
            _outline.init(outlineColor, defaultColor);
            _outline.hide();
        }

        public void showOutline() => _outline.show();

        public void hideOutline() => _outline.hide();
        
        public int id() => _id;

        public void OnPointerClick(PointerEventData eventData)
        {
            onClick?.Invoke(_id);
        }
    }
}