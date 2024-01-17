using ProgressAcademy.Domain.Models;

namespace ProgressAcademy.Domain.Repositories;

public interface IPlanRepository
{
    List<Plan?> GetAllPlans();
    Plan GetPlanById(int planId);
    void CreatePlan(Plan? plan);
    void UpdatePlan(Plan plan);
    void DeletePlan(int planId);
}