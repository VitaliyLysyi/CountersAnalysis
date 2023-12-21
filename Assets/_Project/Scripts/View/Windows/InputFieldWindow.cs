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

        public void show(string title, string input, Action<string> onConfirm, Action onCancel = null, bool canEditText = true)
        {
            show();
            _titleText.text = title;
            _inputField.text = input;
            _inputField.isRichTextEditingAllowed = canEditText;

            _confirmButton.onClick.AddListener(() =>
            {
                hide();
                onConfirm?.Invoke(_inputField.text);
            });

            _cancelButton.onClick.AddListener(() =>
            {
                hide();
                onCancel?.Invoke();
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