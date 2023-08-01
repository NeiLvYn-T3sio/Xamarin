using NeilvynSampleBlueprint.Mobile.Models;
using NeilvynSampleBlueprint.Mobile.Xamarin.Common.ViewModels.Base;

namespace NeilvynSampleBlueprint.Mobile.Xamarin.Common.Models
{
    public class UserItemModel : NotifyPropertyChanged
    {
        public UserItemModel(User user)
        {
            Name = user.Name;
            Age = user.Age;
            AvatarUrl = user.AvatarUrl;
            AvatarColorHex = user.Color;
            StatusMessage = user.StatusMessage;
        }

        private string _name;

        public string Name
        {
            get => _name;
            set => SetProperty(ref _name, value);
        }

        private int _age;

        public int Age
        {
            get => _age;
            set => SetProperty(ref _age, value);
        }

        private string _avatarUrl;

        public string AvatarUrl
        {
            get => _avatarUrl;
            set => SetProperty(ref _avatarUrl, value);
        }

        private string _avatarColorHex;

        public string AvatarColorHex
        {
            get => _avatarColorHex;
            set => SetProperty(ref _avatarColorHex, value);
        }

        private string _statusMessage;

        public string StatusMessage
        {
            get => _statusMessage;
            set => SetProperty(ref _statusMessage, value);
        }
    }
}