using NeilvynSampleBlueprint.Mobile.Domain.Persistance;
using System.IO;

namespace NeilvynSampleBlueprint.Mobile.App.Droid.Database
{
    public class DatabaseFactoryDroid : IDatabaseFactory
    {
        public string GetDatabasePath(string databaseName)
        {
            string documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);

            return Path.Combine(documentsPath, databaseName);
        }
    }
}