using MediatR;

namespace ProgressAcademy.Application.Queries.Lesson
{
    /// <summary>
    /// Represents a query used to retrieve all lessons.
    /// </summary>
    public class GetAllLessonsQuery : IRequest<IEnumerable<Domain.Models.Lesson>>
    {
    }

}