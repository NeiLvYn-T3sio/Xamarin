namespace NeilvynSampleBlueprint.Mobile.Domain.Persistance
{
    public interface IDatabaseFactory
    {
        string GetDatabasePath(string databaseName);
    }
}
