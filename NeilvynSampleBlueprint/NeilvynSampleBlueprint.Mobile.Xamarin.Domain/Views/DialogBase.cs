using System;
using System.Diagnostics.CodeAnalysis;
using Rg.Plugins.Popup.Pages;

namespace NeilvynSampleBlueprint.Mobile.Xamarin.Domain.Views
{
    [ExcludeFromCodeCoverage]
    public abstract class DialogBase : PopupPage, IViewModelTypeExposed
    {
        public abstract Type ViewModelType { get; }
    }
}