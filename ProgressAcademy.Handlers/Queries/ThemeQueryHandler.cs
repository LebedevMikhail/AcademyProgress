using MediatR;
using ProgressAcademy.Application.Queries.Theme;
using ProgressAcademy.Domain.Models;
using ProgressAcademy.Domain.Repositories;

namespace ProgressAcademy.Handlers.Queries
{
    /// <summary>
    /// Handles queries related to themes.
    /// </summary>
    public class ThemeQueryHandler: 
             IRequestHandler<GetAllThemesQuery, IEnumerable<Theme>>, 
             IRequestHandler<GetThemeByIdQuery, Theme>
    {
        private readonly IThemeRepository _themeRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="ThemeQueryHandler"/> class.
        /// </summary>
        /// <param name="themeRepository">The theme repository.</param>
        public ThemeQueryHandler(IThemeRepository themeRepository)
        {
            _themeRepository = themeRepository ?? throw new ArgumentNullException(nameof(themeRepository));
        }

        /// <summary>
        /// Handles the query to retrieve all themes.
        /// </summary>
        /// <returns>A list of themes.</returns>
        public async Task<IEnumerable<Theme>> Handle(GetAllThemesQuery query, CancellationToken cancellationToken)
        {
            if (query == null)
            {
                throw new ArgumentNullException(nameof(query));
            }

            return await _themeRepository.GetAllThemesAsync(cancellationToken);
        }

        /// <summary>
        /// Handles the query to retrieve a theme by its ID.
        /// </summary>
        /// <param name="query">The query specifying the theme ID.</param>
        /// <returns>The theme corresponding to the specified ID.</returns>
        public async Task<Theme> Handle(GetThemeByIdQuery query, CancellationToken cancellationToken)
        {
            if (query == null)
            {
                throw new ArgumentNullException(nameof(query));
            }

            return await _themeRepository.GetThemeByIdAsync(query.ThemeId, cancellationToken);
        }
    }
}
