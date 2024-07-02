namespace ProgressAcademy.Data.Config
{
    /// <summary>
    /// Class for configuring MongoDB database.
    /// </summary>
    public class MongoDbConfig
    {
        private readonly List<DataSeeder> _seeders;

        /// <summary>
        /// Initializes a new instance of the <see cref="MongoDbConfig"/> class.
        /// </summary>
        /// <param name="seeders">The data seeders to be used.</param>
        public MongoDbConfig(List<DataSeeder> seeders)
        {
            _seeders = seeders ?? throw new ArgumentNullException(nameof(seeders)); ;
        }

        /// <summary>
        /// Method for seeding all data.
        /// </summary>
        public async Task SeedDataAsync()
        {
            foreach (var seeder in _seeders)
            {
                await seeder.SeedDataAsync();
            }
        }
    }
}
