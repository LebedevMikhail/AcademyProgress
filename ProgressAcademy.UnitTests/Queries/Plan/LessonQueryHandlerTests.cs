namespace ProgressAcademy.UnitTests.Queries.Plan;

using ProgressAcademy.Application.Queries.Lesson;
using ProgressAcademy.Domain.Models;
using ProgressAcademy.Domain.Repositories;
using ProgressAcademy.Handlers.Queries;
using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

[TestClass]
public class LessonQueryHandlerTests
{
    [TestMethod]
    public async Task Handle_GetLessonById_ShouldReturnLesson()
    {
        // Arrange
        var mockRepository = new Mock<ILessonRepository>();
        var lessonId = 1;
        var query = new GetLessonByIdQuery
        {
            LessonId = lessonId
        };
        var expectedLesson = new Lesson { Id = lessonId, Title = "Test Lesson" };
        var cancellationTokenSource = new CancellationTokenSource();
        mockRepository.Setup(repo => repo.GetLessonByIdAsync(lessonId, cancellationTokenSource.Token)).ReturnsAsync(expectedLesson);

        var queryHandler = new LessonQueryHandler(mockRepository.Object);

        // Act
        var result = await queryHandler.Handle(query, cancellationTokenSource.Token);

        // Assert
        Assert.IsNotNull(result);
        Assert.AreEqual(expectedLesson, result);
    }

    [TestMethod]
    public async Task Handle_GetLessonById_ShouldThrowArgumentNullException_WhenQueryIsNull()
    {
        var mockRepository = new Mock<ILessonRepository>();
        var queryHandler = new LessonQueryHandler(mockRepository.Object);
        GetLessonByIdQuery query = null;
        var cancellationTokenSource = new CancellationTokenSource();
        await Assert.ThrowsExceptionAsync<ArgumentNullException>(async () => await queryHandler.Handle(query, cancellationTokenSource.Token));
    }

    [TestMethod]
    public async Task Handle_GetLessonById_ShouldThrowArgumentNullException_WhenLessonIdIsZero()
    {
        var mockRepository = new Mock<ILessonRepository>();
        var query = new GetLessonByIdQuery
        {
            LessonId = 0
        };
        var cancellationTokenSource = new CancellationTokenSource();
        var queryHandler = new LessonQueryHandler(mockRepository.Object);

        await Assert.ThrowsExceptionAsync<ArgumentNullException>(async () => await queryHandler.Handle(query, cancellationTokenSource.Token));
    }

    [TestMethod]
    public async Task Handle_GetAllLessons_ShouldReturnListOfLessons()
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
        var cancellationTokenSource = new CancellationTokenSource();

        mockRepository.Setup(repo => repo.GetAllLessonsAsync(cancellationTokenSource.Token)).ReturnsAsync(expectedLessons);

        var queryHandler = new LessonQueryHandler(mockRepository.Object);

        // Act
        var result = await queryHandler.Handle(query, cancellationTokenSource.Token);

        // Assert
        Assert.IsNotNull(result);
        CollectionAssert.AreEqual(expectedLessons, result.ToList());
    }

    [TestMethod]
    public async Task Handle_GetAllLessons_ShouldThrowArgumentNullException_WhenQueryIsNull()
    {
        var mockRepository = new Mock<ILessonRepository>();
        var queryHandler = new LessonQueryHandler(mockRepository.Object);
        GetAllLessonsQuery query = null;
        var cancellationTokenSource = new CancellationTokenSource();
        await Assert.ThrowsExceptionAsync<ArgumentNullException>(async () => await queryHandler.Handle(query, cancellationTokenSource.Token));
    }

    [TestMethod]
    public async Task Handle_GetLessonById_ShouldThrowArgumentNullException_WhenLessonRepositoryReturnsNull()
    {
        var mockRepository = new Mock<ILessonRepository>();
        var lessonId = 1;
        GetLessonByIdQuery query = null;
        Lesson lesson = null;
        var cancellationTokenSource = new CancellationTokenSource();
        mockRepository.Setup(repo => repo.GetLessonByIdAsync(lessonId, cancellationTokenSource.Token)).ReturnsAsync(lesson);

        var queryHandler = new LessonQueryHandler(mockRepository.Object);

        await Assert.ThrowsExceptionAsync<ArgumentNullException>(async () => await queryHandler.Handle(query, cancellationTokenSource.Token));
    }

    [TestMethod]
    public async Task Handle_GetAllLessons_ShouldReturnEmptyList_WhenLessonRepositoryReturnsNull()
    {
        // Arrange
        var mockRepository = new Mock<ILessonRepository>();
        var query = new GetAllLessonsQuery();
        var expectedLessons = new List<Lesson>();
        var cancellationTokenSource = new CancellationTokenSource();
        mockRepository.Setup(repo => repo.GetAllLessonsAsync(cancellationTokenSource.Token)).ReturnsAsync(expectedLessons);

        var queryHandler = new LessonQueryHandler(mockRepository.Object);

        // Act
        var result = await queryHandler.Handle(query, cancellationTokenSource.Token);

        // Assert
        Assert.IsNotNull(result);
        CollectionAssert.AreEqual(expectedLessons, result.ToList());
    }

    [TestMethod]
    public async Task Handle_GetAllLessons_ShouldHandleRepositoryException()
    {
        // Arrange
        var mockRepository = new Mock<ILessonRepository>();
        GetAllLessonsQuery query = null;
        var expectedLessons = new List<Lesson>();
        var cancellationTokenSource = new CancellationTokenSource();
        mockRepository.Setup(repo => repo.GetAllLessonsAsync(cancellationTokenSource.Token)).ReturnsAsync(expectedLessons);

        var queryHandler = new LessonQueryHandler(mockRepository.Object);

        // Act and Assert
        await Assert.ThrowsExceptionAsync<ArgumentNullException>(async () => await queryHandler.Handle(query, cancellationTokenSource.Token));
    }
}