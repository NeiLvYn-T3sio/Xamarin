using NeilvynSampleBlueprint.Mobile.App.Business.Interfaces;
using System;
using System.IO;

namespace NeilvynSampleBlueprint.Mobile.App.iOS.Database
{
    public class DatabaseFactoryIos : IDatabaseFactory
    {
        public string GetDatabasePath(string databaseName)
        {
            string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);

            string libraryPath = Path.Combine(documentsPath, "..", "Library");

            return Path.Combine(libraryPath, databaseName);
        }
    }
}