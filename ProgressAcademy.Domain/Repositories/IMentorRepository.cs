using ProgressAcademy.Domain.Models;

namespace ProgressAcademy.Domain.Repositories;

public interface IMentorRepository {
    List<Mentor> GetAllMentors();
    Mentor GetMentorById(int mentorId);
    void CreateMentor(Mentor mentor);
    void UpdateMentor(Mentor mentor);
    void DeleteMentor(int mentorId);
}