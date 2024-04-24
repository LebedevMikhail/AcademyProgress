using MediatR;
using ProgressAcademy.Domain.Models;

namespace ProgressAcademy.Application.Commands.Theme
{
    /// <summary>
    /// Command to create a new theme.
    /// </summary>
    public class CreateThemeCommand: IRequest
    {
        /// <summary>
        /// The title of the theme to create.
        /// </summary>
        public string? Title { get; set; }

        /// <summary>
        /// The list of questions associated with the theme.
        /// </summary>
        public List<IQuestionAnswer>? Questions { get; set; }
    }
}