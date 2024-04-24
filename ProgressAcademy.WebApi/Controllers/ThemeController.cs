using Microsoft.AspNetCore.Mvc;
using ProgressAcademy.Application.Commands.Theme;
using ProgressAcademy.Application.Queries.Theme;
using ProgressAcademy.Domain.Models;
using MediatR;

namespace ProgressAcademy.WebApi.Controllers
{
    /// <summary>
    /// Controller for managing themes.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class ThemeController : ControllerBase
    {
        private readonly IMediator _mediator;

        /// <summary>
        /// Constructor for ThemeController.
        /// </summary>
        /// <param name="mediator">The mediator service.</param>
        public ThemeController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        /// <summary>
        /// Retrieves all themes.
        /// </summary>
        /// <returns>A list of themes.</returns>
        [HttpGet("GetAllThemes")]
        [ProducesResponseType(typeof(IEnumerable<Theme>), 200)]
        public async Task<IActionResult> GetAllThemes()
        {
            var cancellationTokenSource = new CancellationTokenSource();
            var query = new GetAllThemesQuery();
            var result = await _mediator.Send(query, cancellationTokenSource.Token);
            return Ok(result);
        }

        /// <summary>
        /// Retrieves a theme by its ID.
        /// </summary>
        /// <param name="id">The ID of the theme to retrieve.</param>
        /// <returns>The theme with the specified ID.</returns>
        [HttpGet("GetThemeById")]
        [ProducesResponseType(typeof(Theme), 200)]
        public async Task<IActionResult> GetThemeById(int id)
        {
            var cancellationTokenSource = new CancellationTokenSource();
            var query = new GetThemeByIdQuery() { ThemeId = id };
            var result = await _mediator.Send(query, cancellationTokenSource.Token);
            return Ok(result);
        }

        /// <summary>
        /// Creates a new theme.
        /// </summary>
        /// <param name="theme">The theme to create.</param>
        /// <returns>An IActionResult indicating the result of the operation.</returns>
        [HttpPost]
        [ProducesResponseType(200)]
        public async Task<IActionResult> CreateTheme([FromBody] Theme theme)
        {
            var cancellationTokenSource = new CancellationTokenSource();
            var command = new CreateThemeCommand() { Questions = theme.Questions, Title = theme.Title };
            await _mediator.Send(command, cancellationTokenSource.Token);
            return Ok();
        }

        /// <summary>
        /// Updates an existing theme.
        /// </summary>
        /// <param name="theme">The updated theme.</param>
        /// <returns>An IActionResult indicating the result of the operation.</returns>
        [HttpPut]
        [ProducesResponseType(200)]
        public async Task<IActionResult> UpdateTheme([FromBody] Theme theme)
        {
            var cancellationTokenSource = new CancellationTokenSource();
            var command = new UpdateThemeCommand()
            {
                ThemeId = theme.Id,
                Questions = theme.Questions,
                Title = theme.Title
            };
            await _mediator.Send(command, cancellationTokenSource.Token);
            return Ok();
        }

        /// <summary>
        /// Deletes a theme by its ID.
        /// </summary>
        /// <param name="id">The ID of the theme to delete.</param>
        /// <returns>An IActionResult indicating the result of the operation.</returns>
        [HttpDelete]
        [ProducesResponseType(200)]

        public async Task<IActionResult> DeleteTheme(int id)
        {
            var cancellationTokenSource = new CancellationTokenSource();
            var command = new DeleteThemeCommand() { ThemeId = id };
            await _mediator.Send(command, cancellationTokenSource.Token);
            return Ok();
        }
    }
}
