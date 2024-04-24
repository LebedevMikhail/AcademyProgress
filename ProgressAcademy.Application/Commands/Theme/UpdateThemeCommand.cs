using MediatR;
using ProgressAcademy.Domain.Models;

namespace ProgressAcademy.Application.Queries.Theme
{
    /// <summary>
    /// Command to update an existing theme.
    /// </summary>
    public class UpdateThemeCommand: IRequest
    {
        /// <summary>
        /// The ID of the theme to update.
        /// </summary>
        public int ThemeId { get; set; }

        /// <summary>
        /// The updated title of the theme.
        /// </summary>
        public string? Title { get; set; }

        /// <summary>
        /// The updated list of questions associated with the theme.
        /// </summary>
        public List<IQuestionAnswer>? Questions { get; set; }
    }
}