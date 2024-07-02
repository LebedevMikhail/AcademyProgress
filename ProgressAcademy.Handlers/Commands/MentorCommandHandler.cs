using MediatR;
using ProgressAcademy.Application.Commands.Mentor;
using ProgressAcademy.Domain.Repositories;

namespace ProgressAcademy.Handlers.Commands;

/// <summary>
/// Handles mentor-related commands by delegating to the appropriate repository methods.
/// This class is responsible for executing operations against the data store based on the received commands.
/// </summary>
public class MentorCommandHandler :
        IRequestHandler<CreateMentorCommand>,
        IRequestHandler<UpdateMentorCommand>,
        IRequestHandler<DeleteMentorCommand>
{
    private readonly IMentorRepository _mentorRepository;

    /// <summary>
    /// Initializes a new instance of the MentorCommandHandler with a specific mentor repository.
    /// </summary>
    /// <param name="mentorRepository">The repository responsible for data access operations related to mentors.</param>
    public MentorCommandHandler(IMentorRepository mentorRepository)
    {
        _mentorRepository = mentorRepository ?? throw new ArgumentNullException(nameof(mentorRepository));
    }

    /// <summary>
    /// Handles the creation of a mentor.
    /// Validates the input command and invokes the repository to persist the new mentor.
    /// </summary>
    /// <param name="command">The command containing the data for the mentor to be created.</param>
    public async Task Handle(CreateMentorCommand command, CancellationToken cancellationToken)
    {
        if (command == null)
        {
            throw new ArgumentNullException($"CreateMentorCommand must not be null");
        }

        await _mentorRepository.CreateMentorAsync(command.Mentor, cancellationToken);
    }

    /// <summary>
    /// Handles updating an existing mentor.
    /// Validates the command and calls the repository to update the mentor's data.
    /// </summary>
    /// <param name="command">The command with the updated mentor information.</param>
    public async Task Handle(UpdateMentorCommand command, CancellationToken cancellationToken)
    {
        if (command == null)
        {
            throw new ArgumentNullException($"UpdateMentorCommand must not be null");
        }

        await _mentorRepository.UpdateMentorAsync(command.Mentor, cancellationToken);
    }

    /// <summary>
    /// Handles the deletion of a mentor by their unique identifier.
    /// Validates the command and requests the repository to remove the specified mentor.
    /// </summary>
    /// <param name="command">The command indicating which mentor to delete.</param>
    public async Task Handle(DeleteMentorCommand command, CancellationToken cancellationToken)
    {
        if (command == null)
        {
            throw new ArgumentNullException($"DeleteMentorCommand must not be null");
        }

        await _mentorRepository.DeleteMentorAsync(command.MentorId, cancellationToken);
    }
}