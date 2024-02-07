using ProgressAcademy.Application.Queries.Mentor;
using ProgressAcademy.Domain.Models;
using ProgressAcademy.Domain.Repositories;

namespace ProgressAcademy.Handlers.Queries;

public class MentorQueryHandler
{
    private readonly IMentorRepository _mentorRepository;
    
    public MentorQueryHandler(
        IMentorRepository mentorRepository)
    {
        _mentorRepository = mentorRepository;
    }

    public Mentor Handle(GetMentorByIdQuery query)
    {
        if(query == null || query.MentorId == 0)
        {
            throw new ArgumentNullException($"GetMentorByIdQuery must not be null or the MentorId value is zero ");
        }
        return  _mentorRepository.GetMentorById(query.MentorId);
    }

    public IEnumerable<Mentor> Handle(GetAllMentorsQuery query)
    {
        if(query == null )
        {
            throw new ArgumentNullException($"GetAllMentorsQuery must not be null");
        }
        return _mentorRepository.GetAllMentors();
    }
}