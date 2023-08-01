using System;

namespace NeilvynSampleBlueprint.Mobile.Xamarin.Common.Dialogs
{
    public class ConfirmDialogParam
    {
        public event EventHandler<bool> ConfirmationCompleted;
        public ConfirmDialogParam(string message, string title, string positiveText, string negativeText)
        {
            Message = message;
            Title = title;
            PositiveText = positiveText;
            NegativeText = negativeText;
        }

        public string Message { get; }
        public string Title { get; }
        public string PositiveText { get; }
        public string NegativeText { get; }

        public void OnConfirm(bool answer)
        {
            ConfirmationCompleted?.Invoke(this, answer);
        }
    }
}