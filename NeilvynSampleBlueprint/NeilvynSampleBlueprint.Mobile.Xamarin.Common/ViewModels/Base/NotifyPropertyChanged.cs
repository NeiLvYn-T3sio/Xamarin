using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace NeilvynSampleBlueprint.Mobile.Xamarin.Common.ViewModels.Base
{
    public class NotifyPropertyChanged : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public event PropertyChangingEventHandler PropertyChanging;

        protected void SetProperty<T>(ref T field, T newValue, Action onChanged = null, Action<T> onChanging = null, [CallerMemberName] string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(field, newValue))
            {
                return;
            }

            onChanging?.Invoke(newValue);

            OnPropertyChanging(newValue, propertyName);

            field = newValue;

            onChanged?.Invoke();

            OnPropertyChanged(propertyName);
        }

        public void OnPropertyChanging<T>(T newValue, [CallerMemberName] string propertyName = null)
        {
            PropertyIsChanging(propertyName, newValue);
            PropertyChanging?.Invoke(this, new PropertyChangingEventArgs(propertyName));
        }

        public void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyHasChanged(propertyName);
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public virtual void PropertyHasChanged(string propertyName)
        {

        }

        public virtual void PropertyIsChanging(string propertyName, object newValue)
        {

        }
    }
}
