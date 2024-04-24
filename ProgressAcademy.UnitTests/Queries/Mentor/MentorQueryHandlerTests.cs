using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ProgressAcademy.Application.Queries.Mentor;
using ProgressAcademy.Domain.Repositories;
using ProgressAcademy.Handlers.Queries;

namespace ProgressAcademy.UnitTests.Queries.Mentor;

[TestClass]
public class MentorQueryHandlerTests
{
    [TestMethod]
    public async Task Handle_GetMentorById_ShouldReturnMentor()
    {
        
        var mockRepository = new Mock<IMentorRepository>();
        var mentorId = 1;
        var query = new GetMentorByIdQuery
        {
            MentorId = mentorId
        };
        var expectedMentor = new Domain.Models.Mentor { Id = mentorId, FullName = "Test Mentor" };
        var cancellationTokenSource = new CancellationTokenSource();
        mockRepository.Setup(repo => repo.GetMentorByIdAsync(It.IsAny<int>(), It.IsAny<CancellationToken>())).ReturnsAsync(expectedMentor);

        var queryHandler = new MentorQueryHandler(mockRepository.Object);

        var result = await queryHandler.Handle(query, cancellationTokenSource.Token);

        
        Assert.IsNotNull(result);
        Assert.AreEqual(expectedMentor, result);
    }

    [TestMethod]
    public async Task Handle_GetAllMentors_ShouldReturnListOfMentors()
    {
        
        var mockRepository = new Mock<IMentorRepository>();
        var query = new GetAllMentorsQuery();
        var expectedMentors = new List<Domain.Models.Mentor>
        {
            new() { Id = 1, FullName = "Mentor 1" },
            new() { Id = 2, FullName = "Mentor 2" },
            new() { Id = 3, FullName = "Mentor 3" }
        };
        var cancellationTokenSource = new CancellationTokenSource();
        mockRepository.Setup(repo => repo.GetAllMentorsAsync(It.IsAny<CancellationToken>())).ReturnsAsync(expectedMentors);

        var queryHandler = new MentorQueryHandler(mockRepository.Object);
        
        var result = await queryHandler.Handle(query, cancellationTokenSource.Token);
        
        Assert.IsNotNull(result);
        CollectionAssert.AreEqual(expectedMentors, result.ToList());
    }

    [TestMethod]
    public async Task Handle_GetMentorById_ShouldReturnNull_WhenMentorNotFound()
    {
        var mockRepository = new Mock<IMentorRepository>();
        var mentorId = 1;
        var query = new GetMentorByIdQuery
        {
            MentorId = mentorId
        };
        var cancellationTokenSource = new CancellationTokenSource();
        Domain.Models.Mentor mentor = null;
        mockRepository.Setup(repo => repo.GetMentorByIdAsync(It.IsAny<int>(), It.IsAny<CancellationToken>())).ReturnsAsync(mentor);
        var queryHandler = new MentorQueryHandler(mockRepository.Object);
        
        var result = await queryHandler.Handle(query, cancellationTokenSource.Token);

        Assert.IsNull(result);
    }

    [TestMethod]
    public async Task Handle_GetAllMentors_ShouldReturnEmptyList_WhenNoMentorsFound()
    {
        var mockRepository = new Mock<IMentorRepository>();
        var query = new GetAllMentorsQuery();
        var cancellationTokenSource = new CancellationTokenSource();
        mockRepository.Setup(repo => repo.GetAllMentorsAsync(It.IsAny<CancellationToken>())).ReturnsAsync(new List<Domain.Models.Mentor>());
        var queryHandler = new MentorQueryHandler(mockRepository.Object);

        var result = await queryHandler.Handle(query, cancellationTokenSource.Token);

        Assert.IsNotNull(result);
        CollectionAssert.AreEqual(new List<Domain.Models.Mentor>(), result.ToList());
    }
}