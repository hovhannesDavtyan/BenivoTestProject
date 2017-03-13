using Microsoft.VisualStudio.TestTools.UnitTesting;
using SocialNetwork.Models;
using SocialNetwork.Repositories;
using System.Collections.Generic;
using Moq;
using System.Linq;
using SocialNetwork.Controllers;
using System.Web.Mvc;
using SocialNetwork.ViewModels;
using System.Threading.Tasks;

namespace SocialNetwork.Tests.Controllers
{
    [TestClass]
    public class WhenRequestingTheGroupPage
    {
        private List<Group> _groups = new List<Group>
            {
                new Group {Id = 1, Description = "Description1", Name = "Name1", MemberCount = 1, StoryCount = 1 },
                new Group {Id = 2, Description = "Description2", Name = "Name2", MemberCount = 2, StoryCount = 2 },
                new Group {Id = 3, Description = "Description3", Name = "Name3", MemberCount = 3, StoryCount = 3 }
            };
        [TestMethod]
        public void ThenReturnGroupViewModel()
        {
            // Arrange
            var _groupRepository = new Mock<IGroupRepository>();
            _groupRepository.Setup(e => e.GetAll()).Returns(_groups.AsQueryable());
            var controller = new GroupController(_groupRepository.Object);
            // Act
            var actionResultTask = controller.Index();
            actionResultTask.Wait();
            var result = actionResultTask.Result as ViewResult;
            var model = result.Model as GroupViewModel;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(3, model.Groups.Count());
        }

    }
}
