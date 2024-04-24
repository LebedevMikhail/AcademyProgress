using ProgressAcademy.Domain.Models;

namespace ProgressAcademy.Domain.Repositories
{
    /// <summary>
    /// Interface for the repository handling operations related to themes.
    /// </summary>
    public interface IThemeRepository
    {
        /// <summary>
        /// Retrieves all themes.
        /// </summary>
        /// <returns>A list of themes.</returns>
        Task<IEnumerable<Theme>> GetAllThemesAsync(CancellationToken cancellationToken);

        /// <summary>
        /// Retrieves a theme by its ID.
        /// </summary>
        /// <param name="themeId">The ID of the theme to retrieve.</param>
        /// <returns>The theme corresponding to the provided ID.</returns>
        Task<Theme> GetThemeByIdAsync(int themeId, CancellationToken cancellationToken);

        /// <summary>
        /// Creates a new theme.
        /// </summary>
        /// <param name="theme">The theme to create.</param>
        Task CreateThemeAsync(Theme theme, CancellationToken cancellationToken);

        /// <summary>
        /// Updates an existing theme.
        /// </summary>
        /// <param name="theme">The updated theme.</param>
        Task UpdateThemeAsync(Theme theme, CancellationToken cancellationToken);

        /// <summary>
        /// Deletes a theme by its ID.
        /// </summary>
        /// <param name="themeId">The ID of the theme to delete.</param>
        Task DeleteThemeAsync(int themeId, CancellationToken cancellationToken);
    }
}
