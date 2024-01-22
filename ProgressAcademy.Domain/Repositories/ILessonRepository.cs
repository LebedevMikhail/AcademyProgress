using ProgressAcademy.Domain.Models;

namespace ProgressAcademy.Domain.Repositories;

public interface ILessonRepository {
        List<Lesson> GetAllLessons();
        Lesson GetLessonById(int lessonId);
        void CreateLesson(Lesson lesson);
        void UpdateLesson(Lesson lesson);
        void DeleteLesson(int lessonId);
    }