
using System.IO;
using Windows.Storage;
using NeilvynSampleBlueprint.Mobile.App.Repositories;

namespace NeilvynSampleBlueprint.Mobile.App.UWP.Database
{
    public class DatabaseFactoryUwp : IDatabaseFactory
    {
        public string GetDatabasePath(string databaseName)
        {
            return Path.Combine(ApplicationData.Current.LocalFolder.Path, databaseName);
        }
    }
}
