using MongoDB.Driver;
using ProgressAcademy.Domain.Models;
using ProgressAcademy.Domain.Repositories;

namespace ProgressAcademy.Infrastructure.Repositories
{
    /// <summary>
    /// Implementation of the repository for managing themes in MongoDB.
    /// </summary>
    public class ThemeRepository : IThemeRepository
    {
        private readonly IMongoCollection<Theme> _themeCollection;

        /// <summary>
        /// Initializes a new instance of the <see cref="ThemeRepository"/> class.
        /// </summary>
        /// <param name="database">The MongoDB database.</param>
        public ThemeRepository(IMongoDatabase database)
        {
            _themeCollection = database.GetCollection<Theme>("themes");
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<Theme>> GetAllThemesAsync(CancellationToken cancellationToken)
        {
            return await _themeCollection.Find(_ => true).ToListAsync(cancellationToken);
        }

        /// <inheritdoc/>
        public async Task<Theme> GetThemeByIdAsync(int themeId, CancellationToken cancellationToken)
        {
            return await _themeCollection.Find(theme => theme.Id == themeId).FirstOrDefaultAsync(cancellationToken);
        }

        /// <inheritdoc/>
        public async Task CreateThemeAsync(Theme theme, CancellationToken cancellationToken)
        {
            if (theme == null)
            {
                throw new ArgumentNullException(nameof(theme));
            }
            var options = new InsertOneOptions
            {
                BypassDocumentValidation = true
            };
            await _themeCollection.InsertOneAsync(theme, options, cancellationToken);
        }

        /// <inheritdoc/>
        public async Task UpdateThemeAsync(Theme theme, CancellationToken cancellationToken)
        {
            if (theme == null)
            {
                throw new ArgumentNullException(nameof(theme));
            }

            var filter = Builders<Theme>.Filter.Eq(t => t.Id, theme.Id);
            var update = Builders<Theme>.Update
                .Set(t => t.Title, theme.Title)
                .Set(t => t.Questions, theme.Questions);

            await _themeCollection.UpdateOneAsync(filter, update, cancellationToken: cancellationToken);
        }

        /// <inheritdoc/>
        public async Task DeleteThemeAsync(int themeId, CancellationToken cancellationToken)
        {
            var filter = Builders<Theme>.Filter.Eq(t => t.Id, themeId);
            await _themeCollection.DeleteOneAsync(filter, cancellationToken);
        }
    }
}
