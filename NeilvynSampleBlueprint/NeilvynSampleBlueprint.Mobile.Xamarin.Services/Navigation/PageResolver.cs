using Autofac;
using Autofac.Core.Registration;
using NeilvynSampleBlueprint.Mobile.Xamarin.Common.Exceptions;
using NeilvynSampleBlueprint.Mobile.Xamarin.Domain.Navigation;
using NeilvynSampleBlueprint.Mobile.Xamarin.Domain.Views;
using Xamarin.Forms;

namespace NeilvynSampleBlueprint.Mobile.Xamarin.Services.Navigation
{
    public class PageResolver : IPageResolver
    {
        private readonly ILifetimeScope _scope;

        public PageResolver(ILifetimeScope scope)
        {
            _scope = scope;
        }

        public Page GetPageWithAttachedViewModel(string viewName)
        {
            try
            {
                var page = _scope.ResolveNamed<Page>(viewName);

                var viewModelType = (page as IViewModelTypeExposed)?.ViewModelType;
                
                if (viewModelType != null)
                {
                    page.BindingContext = _scope.Resolve(viewModelType);
                }

                return page;
            }
            catch (ComponentNotRegisteredException ex)
            {
                throw new PageNotYetImplementedException($"Page named {viewName} is not yet implemented.", ex);
            }
        }
        
        public DialogBase GetPopupPageWithAttachedViewModel(string popupName)
        {
            try
            {
                var page = _scope.ResolveNamed<DialogBase>(popupName);
                
                page.BindingContext = _scope.Resolve(page.ViewModelType);

                return page;
            }
            catch (ComponentNotRegisteredException ex)
            {
                throw new PageNotYetImplementedException($"Page named {popupName} is not yet implemented.", ex);
            }
        }
    }
}
