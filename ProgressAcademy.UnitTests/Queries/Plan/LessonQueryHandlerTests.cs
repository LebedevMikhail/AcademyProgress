using ProgressAcademy.Application.Queries.Lesson;
using ProgressAcademy.Domain.Models;
using ProgressAcademy.Domain.Repositories;
using ProgressAcademy.Handlers.Queries;

namespace ProgressAcademy.UnitTests.Queries.Plan;

using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

[TestClass]
public class LessonQueryHandlerTests
{
    [TestMethod]
    public void Handle_GetLessonById_ShouldReturnLesson()
    {
        // Arrange
        var mockRepository = new Mock<ILessonRepository>();
        var lessonId = 1;
        var query = new GetLessonByIdQuery
        {
            LessonId = lessonId
        };
        var expectedLesson = new Lesson { Id = lessonId, Title = "Test Lesson" };

        mockRepository.Setup(repo => repo.GetLessonById(lessonId)).Returns(expectedLesson);

        var queryHandler = new LessonQueryHandler(mockRepository.Object);

        // Act
        var result = queryHandler.Handle(query);

        // Assert
        Assert.IsNotNull(result);
        Assert.AreEqual(expectedLesson, result);
    }

    [TestMethod]
    public void Handle_GetLessonById_ShouldThrowArgumentNullException_WhenQueryIsNull()
    {
        var mockRepository = new Mock<ILessonRepository>();
        var queryHandler = new LessonQueryHandler(mockRepository.Object);
        GetLessonByIdQuery query = null;
        
        Assert.ThrowsException<ArgumentNullException>(() => queryHandler.Handle(query));
    }

    [TestMethod]
    public void Handle_GetLessonById_ShouldThrowArgumentNullException_WhenLessonIdIsZero()
    {
        var mockRepository = new Mock<ILessonRepository>();
        var query = new GetLessonByIdQuery
        {
            LessonId = 0
        };
        var queryHandler = new LessonQueryHandler(mockRepository.Object);

        // Act and Assert
        Assert.ThrowsException<ArgumentNullException>(() => queryHandler.Handle(query));
    }

    [TestMethod]
    public void Handle_GetAllLessons_ShouldReturnListOfLessons()
    {
        // Arrange
        var mockRepository = new Mock<ILessonRepository>();
        var query = new GetAllLessonsQuery();
        var expectedLessons = new List<Lesson>
        {
            new Lesson { Id = 1, Title = "Lesson 1" },
            new Lesson { Id = 2, Title = "Lesson 2" },
            new Lesson { Id = 3, Title = "Lesson 3" }
        };

        mockRepository.Setup(repo => repo.GetAllLessons()).Returns(expectedLessons);

        var queryHandler = new LessonQueryHandler(mockRepository.Object);

        // Act
        var result = queryHandler.Handle(query);

        // Assert
        Assert.IsNotNull(result);
        CollectionAssert.AreEqual(expectedLessons, result.ToList());
    }

    [TestMethod]
    public void Handle_GetAllLessons_ShouldThrowArgumentNullException_WhenQueryIsNull()
    {
        var mockRepository = new Mock<ILessonRepository>();
        var queryHandler = new LessonQueryHandler(mockRepository.Object);
        GetAllLessonsQuery query = null;
        
        Assert.ThrowsException<ArgumentNullException>(() => queryHandler.Handle(query));
    }[TestMethod]
    public void Handle_GetLessonById_ShouldThrowArgumentNullException_WhenLessonRepositoryReturnsNull()
    {
        // Arrange
        var mockRepository = new Mock<ILessonRepository>();
        var lessonId = 1;
        var query = new GetLessonByIdQuery
        {
            LessonId = lessonId
        };

        mockRepository.Setup(repo => repo.GetLessonById(lessonId)).Returns((Lesson)null);

        var queryHandler = new LessonQueryHandler(mockRepository.Object);

        // Act and Assert
        Assert.ThrowsException<ArgumentNullException>(() => queryHandler.Handle(query));
    }

    [TestMethod]
    public void Handle_GetAllLessons_ShouldReturnEmptyList_WhenLessonRepositoryReturnsNull()
    {
        // Arrange
        var mockRepository = new Mock<ILessonRepository>();
        var query = new GetAllLessonsQuery();
        var expectedLessons = new List<Lesson>();
        mockRepository.Setup(repo => repo.GetAllLessons()).Returns(expectedLessons);

        var queryHandler = new LessonQueryHandler(mockRepository.Object);

        // Act
        var result = queryHandler.Handle(query);

        // Assert
        Assert.IsNotNull(result);
        CollectionAssert.AreEqual(expectedLessons, result.ToList());
    }

    [TestMethod]
    public void Handle_GetAllLessons_ShouldHandleRepositoryException()
    {
        // Arrange
        var mockRepository = new Mock<ILessonRepository>();
        var query = new GetAllLessonsQuery();
        var expectedLessons = new List<Lesson>();
        mockRepository.Setup(repo => repo.GetAllLessons()).Returns(expectedLessons);

        var queryHandler = new LessonQueryHandler(mockRepository.Object);

        // Act and Assert
        Assert.ThrowsException<Exception>(() => queryHandler.Handle(query));
    }
}