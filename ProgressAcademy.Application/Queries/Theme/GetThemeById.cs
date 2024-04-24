using MediatR;

namespace ProgressAcademy.Application.Queries.Theme
{
    /// <summary>
    /// Query to retrieve a theme by its ID.
    /// </summary>
    public class GetThemeByIdQuery : IRequest<Domain.Models.Theme>
    {
        /// <summary>
        /// The ID of the theme to retrieve.
        /// </summary>
        public int ThemeId { get; set; }
    }
}