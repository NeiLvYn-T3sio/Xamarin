using NeilvynSampleBlueprint.Mobile.Xamarin.Common.Dialogs;
using NeilvynSampleBlueprint.Mobile.Xamarin.Domain.Views;
using System;
using System.Diagnostics.CodeAnalysis;

namespace NeilvynSampleBlueprint.Mobile.Xamarin.UI.Views.Dialogs
{
    [ExcludeFromCodeCoverage]
    public partial class AlertDialog 
    {
        public AlertDialog()
        {
            InitializeComponent();
        }
    }

    [ExcludeFromCodeCoverage]
    public class AlertDialogXaml : DialogBase
    {
        public override Type ViewModelType => typeof(AlertDialogModel);
    }
}