using MediatR;
using ProgressAcademy.Application.Commands.Theme;
using ProgressAcademy.Application.Queries.Theme;
using ProgressAcademy.Domain.Repositories;

namespace ProgressAcademy.Handlers.Commands.Theme
{
    /// <summary>
    /// Handler for commands related to themes.
    /// </summary>
    public class ThemeCommandHandler:
        IRequestHandler<CreateThemeCommand>,
        IRequestHandler<UpdateThemeCommand>,
        IRequestHandler<DeleteThemeCommand>
{
        private readonly IThemeRepository _themeRepository;

        public ThemeCommandHandler(IThemeRepository themeRepository)
        {
            _themeRepository = themeRepository ?? throw new ArgumentNullException(nameof(themeRepository));;;
        }

        /// <summary>
        /// Handles the creation of a new theme.
        /// </summary>
        /// <param name="command">CreateThemeCommand object containing theme details.</param>
        public async Task Handle(CreateThemeCommand command, CancellationToken cancellationToken)
        {
            var theme = new Domain.Models.Theme
            {
                Title = command.Title,
                Questions = command.Questions
            };
           await _themeRepository.CreateThemeAsync(theme, cancellationToken);
        }

        /// <summary>
        /// Handles the update of an existing theme.
        /// </summary>
        /// <param name="command">UpdateThemeCommand object containing updated theme details.</param>
        public async Task Handle(UpdateThemeCommand command, CancellationToken cancellationToken)
        {
            var theme = new Domain.Models.Theme
            {
                Id = command.ThemeId,
                Title = command.Title,
                Questions = command.Questions
            };
           await _themeRepository.UpdateThemeAsync(theme, cancellationToken);
        }

        /// <summary>
        /// Handles the deletion of an existing theme.
        /// </summary>
        /// <param name="command">DeleteThemeCommand object containing the ID of the theme to be deleted.</param>
        public async Task Handle(DeleteThemeCommand command, CancellationToken cancellationToken)
        {
            await _themeRepository.DeleteThemeAsync(command.ThemeId, cancellationToken);
        }
    }
}