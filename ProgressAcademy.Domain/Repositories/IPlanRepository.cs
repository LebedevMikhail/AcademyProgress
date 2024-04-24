using ProgressAcademy.Domain.Models;

namespace ProgressAcademy.Domain.Repositories;

/// <summary>
/// Defines the interface for plan repository operations, encapsulating methods for managing plans within the system.
/// </summary>
public interface IPlanRepository
{
    /// <summary>
    /// Retrieves all plans registered in the system.
    /// </summary>
    /// <returns>A list of all plans.</returns>
    Task<IEnumerable<Plan>> GetAllPlansAsync(CancellationToken cancellationToken);

    /// <summary>
    /// Retrieves a specific plan by its unique identifier.
    /// </summary>
    /// <param name="planId">The unique identifier of the plan to retrieve.</param>
    /// <returns>The plan matching the provided identifier; null if not found.</returns>
    Task<Plan> GetPlanByIdAsync(int planId, CancellationToken cancellationToken);

    /// <summary>
    /// Creates a new plan and adds it to the system.
    /// </summary>
    /// <param name="plan">The plan to add to the system.</param>
    Task CreatePlanAsync(Plan plan, CancellationToken cancellationToken);

    /// <summary>
    /// Updates an existing plan's information in the system.
    /// </summary>
    /// <param name="plan">The plan with updated information.</param>
    Task UpdatePlanAsync(Plan plan, CancellationToken cancellationToken);

    /// <summary>
    /// Deletes a plan from the system based on its unique identifier.
    /// </summary>
    /// <param name="planId">The unique identifier of the plan to be deleted.</param>
    Task DeletePlanAsync(int planId, CancellationToken cancellationToken);
}
