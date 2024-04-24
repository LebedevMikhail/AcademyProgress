using MediatR;

namespace ProgressAcademy.Application.Queries.Theme
{
    /// <summary>
    /// Query to retrieve all themes.
    /// </summary>
    public class GetAllThemesQuery : IRequest<IEnumerable<Domain.Models.Theme>>
    {
    }
}