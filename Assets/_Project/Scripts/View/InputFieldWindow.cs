using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace CountersAnalysis
{
    public class InputFieldWindow : ContentWindow
    {
        [SerializeField] private TextMeshProUGUI _titleText;
        [SerializeField] private TMP_InputField _inputField;
        [SerializeField] private Button _confirmButton;
        [SerializeField] private Button _cancelButton;

        public void show(string title, string input, Action<string> onConfirm, Action onCancel)
        {
            show();
            _titleText.text = title;
            _inputField.text = input;

            _confirmButton.onClick.AddListener(() =>
            {
                hide();
                onConfirm(_inputField.text);
            });

            _cancelButton.onClick.AddListener(() =>
            {
                hide();
                onCancel();
            });
        }

        public override void hide()
        {
            base.hide();

            _confirmButton?.onClick.RemoveAllListeners();
            _cancelButton?.onClick.RemoveAllListeners();
        }
    }
}