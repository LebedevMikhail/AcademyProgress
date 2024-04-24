using MediatR;
using ProgressAcademy.Application.Queries.Mentor;
using ProgressAcademy.Domain.Models;
using ProgressAcademy.Domain.Repositories;

namespace ProgressAcademy.Handlers.Queries;

/// <summary>
/// Handles queries related to 'Mentor' entities by fetching data from the mentor repository.
/// </summary>
public class MentorQueryHandler : 
             IRequestHandler<GetAllMentorsQuery, IEnumerable<Mentor>>, 
             IRequestHandler<GetMentorByIdQuery, Mentor>
{
    private readonly IMentorRepository _mentorRepository;
    
    /// <summary>
    /// Initializes a new instance of the <see cref="MentorQueryHandler"/> class.
    /// </summary>
    /// <param name="mentorRepository">The repository for accessing mentor data.</param>
    public MentorQueryHandler(IMentorRepository mentorRepository)
    {
        _mentorRepository = mentorRepository ?? throw new ArgumentNullException(nameof(mentorRepository));
    }

    /// <summary>
    /// Retrieves a mentor by their unique identifier.
    /// </summary>
    /// <param name="query">The query containing the ID of the mentor to retrieve.</param>
    /// <returns>The <see cref="Mentor"/> object if found; otherwise, null.</returns>
    /// <exception cref="ArgumentNullException">Thrown if the query is null or the MentorId is zero.</exception>
    public async Task<Mentor> Handle(GetMentorByIdQuery query, CancellationToken cancellationToken)
    {
        if(query == null || query.MentorId == 0)
        {
            throw new ArgumentNullException("GetMentorByIdQuery must not be null or the MentorId value is zero.");
        }
        return await _mentorRepository.GetMentorByIdAsync(query.MentorId, cancellationToken);
    }

    /// <summary>
    /// Retrieves all mentors.
    /// </summary>
    /// <param name="query">The query to retrieve all mentors.</param>
    /// <returns>An enumerable collection of <see cref="Mentor"/>.</returns>
    /// <exception cref="ArgumentNullException">Thrown if the query is null.</exception>
    public async Task<IEnumerable<Mentor>> Handle(GetAllMentorsQuery query, CancellationToken cancellationToken)
    {
        if(query == null)
        {
            throw new ArgumentNullException("GetAllMentorsQuery must not be null.");
        }
        return await _mentorRepository.GetAllMentorsAsync(cancellationToken);
    }
}
