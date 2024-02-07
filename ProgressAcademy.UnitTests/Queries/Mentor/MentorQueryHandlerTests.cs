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
    public void Handle_GetMentorById_ShouldReturnMentor()
    {
        
        var mockRepository = new Mock<IMentorRepository>();
        var mentorId = 1;
        var query = new GetMentorByIdQuery
        {
            MentorId = mentorId
        };
        var expectedMentor = new Domain.Models.Mentor { Id = mentorId, FullName = "Test Mentor" };
        
        mockRepository.Setup(repo => repo.GetMentorById(mentorId)).Returns(expectedMentor);

        var queryHandler = new MentorQueryHandler(mockRepository.Object);

                var result = queryHandler.Handle(query);

        
        Assert.IsNotNull(result);
        Assert.AreEqual(expectedMentor, result);
    }

    [TestMethod]
    public void Handle_GetAllMentors_ShouldReturnListOfMentors()
    {
        
        var mockRepository = new Mock<IMentorRepository>();
        var query = new GetAllMentorsQuery();
        var expectedMentors = new List<Domain.Models.Mentor>
        {
            new Domain.Models.Mentor { Id = 1, FullName = "Mentor 1" },
            new Domain.Models.Mentor { Id = 2, FullName = "Mentor 2" },
            new Domain.Models.Mentor { Id = 3, FullName = "Mentor 3" }
        };
        
        mockRepository.Setup(repo => repo.GetAllMentors()).Returns(expectedMentors);

        var queryHandler = new MentorQueryHandler(mockRepository.Object);
        
        var result = queryHandler.Handle(query);
        
        Assert.IsNotNull(result);
        CollectionAssert.AreEqual(expectedMentors, result.ToList());
    }
    [TestMethod]
    public void Handle_GetMentorById_ShouldReturnNull_WhenMentorNotFound()
    {
        var mockRepository = new Mock<IMentorRepository>();
        var mentorId = 1;
        var query = new GetMentorByIdQuery
        {
            MentorId = mentorId
        };
        mockRepository.Setup(repo => repo.GetMentorById(mentorId)).Returns((Domain.Models.Mentor)null);
        var queryHandler = new MentorQueryHandler(mockRepository.Object);
        
        var result = queryHandler.Handle(query);

        Assert.IsNull(result);
    }

    [TestMethod]
    public void Handle_GetAllMentors_ShouldReturnEmptyList_WhenNoMentorsFound()
    {
        var mockRepository = new Mock<IMentorRepository>();
        var query = new GetAllMentorsQuery();
        mockRepository.Setup(repo => repo.GetAllMentors()).Returns(new List<Domain.Models.Mentor>());
        var queryHandler = new MentorQueryHandler(mockRepository.Object);

        var result = queryHandler.Handle(query);

        Assert.IsNotNull(result);
        CollectionAssert.AreEqual(new List<Domain.Models.Mentor>(), result.ToList());
    }
}