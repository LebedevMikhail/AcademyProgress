using MediatR;
using ProgressAcademy.Application.Commands.Mentee;
using ProgressAcademy.Domain.Models;
using ProgressAcademy.Domain.Repositories;

namespace ProgressAcademy.Handlers.Commands;

/// <summary>
/// Command handler dedicated to processing actions (create, update, delete)
/// related to mentees. It interacts with the mentee repository for data persistence.
/// </summary>
public class MenteeCommandHandler :
        IRequestHandler<CreateMenteeCommand>,
        IRequestHandler<UpdateMenteeCommand>,
        IRequestHandler<DeleteMenteeCommand>
{
    private readonly IMenteeRepository _menteeRepository;

    /// <summary>
    /// Initializes a new instance of the MenteeCommandHandler with a mentee repository.
    /// </summary>
    /// <param name="menteeRepository">The repository to interact with mentee data.</param>
    public MenteeCommandHandler(IMenteeRepository menteeRepository)
    {
        _menteeRepository = menteeRepository;
    }

    /// <summary>
    /// Handles the creation of a mentee.
    /// </summary>
    /// <param name="command">The command containing the mentee data to be created.</param>
    public async Task Handle(CreateMenteeCommand command, CancellationToken cancellationToken)
    {
        if (command == null)
        {
            throw new ArgumentNullException($"CreateMenteeCommand must not be null");
        }

        _menteeRepository.CreateMenteeAsync(command.Mentee, cancellationToken);
    }

    /// <summary>
    /// Handles the update of a mentee.
    /// </summary>
    /// <param name="command">The command containing the mentee data to be updated.</param>
    public async Task Handle(UpdateMenteeCommand command, CancellationToken cancellationToken)
    {
        if (command == null)
        {
            throw new ArgumentNullException($"UpdateMenteeCommand must not be null");
        }
        _menteeRepository.UpdateMenteeAsync(command.Mentee, cancellationToken);
    }

    /// <summary>
    /// Handles the deletion of a mentee by their ID.
    /// </summary>
    /// <param name="command">The command containing the ID of the mentee to be deleted.</param>
    public async Task Handle(DeleteMenteeCommand command, CancellationToken cancellationToken)
    {
        if (command == null)
        {
            throw new ArgumentNullException($"DeleteMenteeCommand must not be null");
        }
        _menteeRepository.DeleteMenteeAsync(command.MenteeId, cancellationToken);
    }
}
