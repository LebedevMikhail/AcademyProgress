using MediatR;
using ProgressAcademy.Application.Queries.Mentee;
using ProgressAcademy.Domain.Models;
using ProgressAcademy.Domain.Repositories;

namespace ProgressAcademy.Handlers.Queries;

/// <summary>
/// Handles queries related to 'Mentee' entities by fetching data from the mentee repository.
/// </summary>
public class MenteeQueryHandler : 
             IRequestHandler<GetAllMenteesQuery, IEnumerable<Mentee>>, 
             IRequestHandler<GetMenteeByIdQuery, Mentee>
{
    private readonly IMenteeRepository _menteeRepository;

    /// <summary>
    /// Initializes a new instance of the <see cref="MenteeQueryHandler"/> class.
    /// </summary>
    /// <param name="menteeRepository">The repository for accessing mentee data.</param>
    public MenteeQueryHandler(IMenteeRepository menteeRepository)
    {
        _menteeRepository = menteeRepository;
    }

    /// <summary>
    /// Retrieves a mentee by their unique identifier.
    /// </summary>
    /// <param name="query">The query containing the ID of the mentee to retrieve.</param>
    /// <returns>The <see cref="Mentee"/> object if found; otherwise, null.</returns>
    /// <exception cref="ArgumentNullException">Thrown if the query is null or the MenteeID is zero.</exception>
    public async Task<Mentee> Handle(GetMenteeByIdQuery query, CancellationToken cancellationToken)
    {
        if(query == null || query.MenteeId == 0)
        {
            throw new ArgumentNullException("GetMenteeByIdQuery must not be null or the MenteeID value is zero.");
        }
        return await _menteeRepository.GetMenteeByIdAsync(query.MenteeId, cancellationToken);
    }

    /// <summary>
    /// Retrieves all mentees.
    /// </summary>
    /// <param name="query">The query to retrieve all mentees.</param>
    /// <returns>An enumerable collection of <see cref="Mentee"/>.</returns>
    /// <exception cref="ArgumentNullException">Thrown if the query is null.</exception>
    public async Task<IEnumerable<Mentee>> Handle(GetAllMenteesQuery query, CancellationToken cancellationToken)
    {
        if(query == null)
        {
            throw new ArgumentNullException("GetAllMenteesQuery must not be null.");
        }
        return await _menteeRepository.GetAllMenteesAsync(cancellationToken);
    }
}