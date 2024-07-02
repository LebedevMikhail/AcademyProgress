using MongoDB.Driver;

namespace ProgressAcademy.Data.Config;

/// <summary>
/// Interface for classes responsible for seeding data.
/// </summary>
public abstract class DataSeeder
{
    protected readonly IMongoDatabase _database;
    public DataSeeder(IMongoDatabase database)
    {
        _database = database ?? throw new ArgumentNullException(nameof(database));
    }
    /// <summary>
    /// Method for seeding data.
    /// </summary>
    public abstract Task SeedDataAsync();

    protected async Task CreateCollectionIfNotExist(string collectionName)
    {
        var collectionList = await _database.ListCollectionNamesAsync();
        var collections = await collectionList.ToListAsync();

        if (!collections.Contains(collectionName))
        {
           await _database.CreateCollectionAsync(collectionName);
        }
    }
}