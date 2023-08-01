using System;

namespace NeilvynSampleBlueprint.Mobile.Xamarin.Common.Dialogs
{
    public class AlertDialogParam
    {
        public event EventHandler Closed;
        public AlertDialogParam(string message, string title, string closeText)
        {
            Message = message;
            Title = title;
            CloseText = closeText;
        }

        public string Message { get; }
        public string Title { get; }
        public string CloseText { get; }

        public void OnClose()
        {
            Closed?.Invoke(this, EventArgs.Empty);
        }
    }
}