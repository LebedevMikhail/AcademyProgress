using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ProgressAcademy.Application.Queries.Mentor;
using ProgressAcademy.Domain.Repositories;
using ProgressAcademy.Handlers.Queries;

namespace ProgressAcademy.UnitTests.Queries.Plan;

[TestClass]
public class MentorQueryHandlerTests
{
    [TestMethod]
    public async Task Handle_GetMentorById_ShouldReturnNull_WhenMentorNotFound()
    {
        // Arrange
        var mockRepository = new Mock<IMentorRepository>();
        var mentorId = 1;
        var query = new GetMentorByIdQuery
        {
            MentorId = mentorId
        };

        var cancellationTokenSource = new CancellationTokenSource();
        Domain.Models.Mentor mentor = null;
        mockRepository.Setup(repo => repo.GetMentorByIdAsync(mentorId, cancellationTokenSource.Token)).ReturnsAsync(mentor);

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
        mockRepository.Setup(repo => repo.GetAllMentorsAsync(cancellationTokenSource.Token)).ReturnsAsync(new List<Domain.Models.Mentor>());

        var queryHandler = new MentorQueryHandler(mockRepository.Object);

        var result = await queryHandler.Handle(query, cancellationTokenSource.Token);

        Assert.IsNotNull(result);
        CollectionAssert.AreEqual(new List<Domain.Models.Mentor>(), result.ToList());
    }
}