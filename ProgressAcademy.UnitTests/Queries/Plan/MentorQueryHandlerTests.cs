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
    public void Handle_GetMentorById_ShouldReturnNull_WhenMentorNotFound()
    {
        // Arrange
        var mockRepository = new Mock<IMentorRepository>();
        var mentorId = 1;
        var query = new GetMentorByIdQuery
        {
            MentorId = mentorId
        };

        mockRepository.Setup(repo => repo.GetMentorById(mentorId)).Returns((Domain.Models.Mentor)null);

        var queryHandler = new MentorQueryHandler(mockRepository.Object);

// Act
        var result = queryHandler.Handle(query);

// Assert
        Assert.IsNull(result);
           
    }

    [TestMethod]
    public void Handle_GetAllMentors_ShouldReturnEmptyList_WhenNoMentorsFound()
    {
        // Arrange
        var mockRepository = new Mock<IMentorRepository>();
        var query = new GetAllMentorsQuery();

        mockRepository.Setup(repo => repo.GetAllMentors()).Returns(new List<Domain.Models.Mentor>());

        var queryHandler = new MentorQueryHandler(mockRepository.Object);

// Act
        var result = queryHandler.Handle(query);

// Assert
        Assert.IsNotNull(result);
        CollectionAssert.AreEqual(new List<Domain.Models.Mentor>(), result.ToList());
    }
}