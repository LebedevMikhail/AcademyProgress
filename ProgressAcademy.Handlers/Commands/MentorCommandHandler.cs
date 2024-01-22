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
        _mentorRepository.CreateMentor(command.Mentor);
    }

    public void Handle(UpdateMentorCommand command)
    {
        _mentorRepository.UpdateMentor(command.Mentor);
    }

    public void Handle(DeleteMentorCommand command)
    {
        _mentorRepository.DeleteMentor(command.MentorId);
    }
}