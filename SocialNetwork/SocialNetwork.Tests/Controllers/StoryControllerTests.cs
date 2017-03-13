using Microsoft.VisualStudio.TestTools.UnitTesting;
using SocialNetwork.Models;
using SocialNetwork.Repositories;
using System.Collections.Generic;
using Moq;
using System.Linq;
using SocialNetwork.Controllers;
using System.Web.Mvc;
using SocialNetwork.ViewModels;
using System.Security.Claims;
using System.Security.Principal;

namespace SocialNetwork.Tests.Controllers
{
    [TestClass]
    public class WhenRequestingTheStoryPage
    {
        private Mock<IGroupRepository> _groupRepository = new Mock<IGroupRepository>();
        private Mock<IStoryRepository> _storyRepository = new Mock<IStoryRepository>();
        private List<Group> _groups = new List<Group>
            {
                new Group {Id = 1, Description = "Description1", Name = "Name1", MemberCount = 1, StoryCount = 1 },
                new Group {Id = 2, Description = "Description2", Name = "Name2", MemberCount = 2, StoryCount = 2 },
                new Group {Id = 3, Description = "Description3", Name = "Name3", MemberCount = 3, StoryCount = 3 }
            };
        private List<Story> _stories = new List<Story>
            {
                new Story {Id = 1, Description = "Description1", Title = "Title1", Content = "Content1", GroupId = 1, UserId = "UserId1" },
                new Story {Id = 2, Description = "Description2", Title = "Title2", Content = "Content2", GroupId = 2, UserId = "UserId1" },
                new Story {Id = 3, Description = "Description3", Title = "Title3", Content = "Content3", GroupId = 3, UserId = "UserId2" }
            };

        [TestMethod]
        public void ThenReturnTheStoryViewModel()
        {
            // Arrange
            _storyRepository.Setup(e => e.GetAll()).Returns(_stories.AsQueryable());
            _storyRepository.Setup(e => e.GetAllByUserId(It.IsAny<string>())).Returns(_stories.Where(x => x.UserId == "UserId1").AsQueryable());
            _groupRepository.Setup(e => e.GetAll()).Returns(_groups.AsQueryable());
            var controller = new StoryController(_storyRepository.Object, _groupRepository.Object)
            {
                GetUserId = () => "UserId1"
            };

            // Act
            var actionResultTask = controller.Index();
            actionResultTask.Wait();
            var result = actionResultTask.Result as ViewResult;
            var model = result.Model as StoryViewModel;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(2, model.UserStories.Count());
        }

        [TestMethod]
        public void ThenReturnStoryDetailViewModel()
        {
            // Arrange
            _storyRepository.Setup(e => e.Find(It.IsAny<int>())).Returns(_stories.Where(x => x.Id == 2).FirstOrDefault());
            var controller = new StoryController(_storyRepository.Object, _groupRepository.Object);

            // Act
            var actionResultTask = controller.Details(2);
            actionResultTask.Wait();
            var result = actionResultTask.Result as ViewResult;
            var model = result.Model as StoryDetailViewModel;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(2, model.story.Id);

        }

        [TestMethod]
        public void ThenReturnStoryCreateEditViewModelCreate()
        {
            // Arrange
            _storyRepository.Setup(e => e.GetAll()).Returns(_stories.AsQueryable());
            var controller = new StoryController(_storyRepository.Object, _groupRepository.Object);

            // Act

            var actionResultTask = controller.Create();
            actionResultTask.Wait();
            var result = actionResultTask.Result as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result.Model, typeof(StoryCreateEditViewModel));

        }

        [TestMethod]
        public void ThenReturnStoryCreateEditViewModelEdit()
        {
            // Arrange
            _storyRepository.Setup(e => e.GetAll()).Returns(_stories.AsQueryable());
            _storyRepository.Setup(e => e.Find(It.IsAny<int>())).Returns(_stories.Where(x => x.Id == 2).FirstOrDefault());
            var controller = new StoryController(_storyRepository.Object, _groupRepository.Object);

            // Act

            var actionResultTask = controller.Edit(2);
            actionResultTask.Wait();
            var result = actionResultTask.Result as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result.Model, typeof(StoryCreateEditViewModel));

        }

    }
}
