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
        return  _mentorRepository.GetMentorById(query.MentorId);
    }

    public IEnumerable<Mentor> Handle(GetAllMentorsQuery query)
    {
        return _mentorRepository.GetAllMentors();
    }
}