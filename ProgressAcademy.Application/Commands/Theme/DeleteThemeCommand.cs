using MediatR;

namespace ProgressAcademy.Application.Queries.Theme
{
    /// <summary>
    /// Command to delete a theme.
    /// </summary>
    public class DeleteThemeCommand: IRequest
    {
        /// <summary>
        /// The ID of the theme to delete.
        /// </summary>
        public int ThemeId { get; set; }
    }
}