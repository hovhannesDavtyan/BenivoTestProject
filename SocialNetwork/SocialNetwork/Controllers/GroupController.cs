using Microsoft.AspNet.Identity;
using SocialNetwork.Models;
using SocialNetwork.Repositories;
using SocialNetwork.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SocialNetwork.Controllers
{
    public class GroupController : Controller
    {
        private IStoryRepository _storyRepository;
        private IRepository<Group> _groupRepository;

        public GroupController( IRepository<Group> groupRepository, IStoryRepository storyRepository)
        {
            _groupRepository = groupRepository;
            _storyRepository = storyRepository;
        }
        // GET: Group
        public ActionResult Index()
        {
            string id = User.Identity.GetUserId();
            GroupsViewModel viewModel = new GroupsViewModel();
            viewModel.Groups = _groupRepository.GetAll();
            return View(viewModel);
        }
    }
}
