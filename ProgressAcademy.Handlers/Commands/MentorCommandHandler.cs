using ProgressAcademy.Application.Commands.Mentor;
using ProgressAcademy.Domain.Repositories;

namespace ProgressAcademy.Handlers.Commands;

public class MentorCommandHandler {
    private readonly IMentorRepository _mentorRepository;

    public MentorCommandHandler(IMentorRepository mentorRepository)
    {
        _mentorRepository = mentorRepository;
    }

    public void Handle(CreateMentorCommand command)
    {
        if(command == null)
        {
            throw new ArgumentNullException($"CreateMentorCommand must not be null");
        }

        _mentorRepository.CreateMentor(command.Mentor);
    }

    public void Handle(UpdateMentorCommand command)
    {
        if(command == null)
        {
            throw new ArgumentNullException($"UpdateMentorCommand must not be null");
        }

        _mentorRepository.UpdateMentor(command.Mentor);
    }

    public void Handle(DeleteMentorCommand command)
    {
        if(command == null)
        {
            throw new ArgumentNullException($"DeleteMentorCommand must not be null");
        }

        _mentorRepository.DeleteMentor(command.MentorId);
    }
}