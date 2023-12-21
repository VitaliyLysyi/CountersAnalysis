using UnityEngine;
using UnityEngine.UI;

namespace CountersAnalysis
{
    public class SimpleOutline : MonoBehaviour
    {
        [SerializeField] private Image _outlineImage;
        private Color _outlineColor;
        private Color _defaultColor;

        public void init(Color outlineColor, Color defaultColor)
        {
            _outlineColor = outlineColor;
            _defaultColor = defaultColor;
        }

        public void show() => _outlineImage.color = _outlineColor;

        public void hide() => _outlineImage.color = _defaultColor;
    }
}