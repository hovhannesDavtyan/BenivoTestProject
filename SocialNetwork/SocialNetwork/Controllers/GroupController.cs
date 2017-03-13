using Microsoft.AspNet.Identity;
using SocialNetwork.Models;
using SocialNetwork.Repositories;
using SocialNetwork.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace SocialNetwork.Controllers
{
    public class GroupController : Controller
    {
        private IRepository<Group> _groupRepository;

        public GroupController(IRepository<Group> groupRepository)
        {
            _groupRepository = groupRepository;
        }
        // GET: Group
        public async Task<ActionResult> Index()
        {
            try
            {
                GroupViewModel viewModel = new GroupViewModel();
                viewModel.Groups =  _groupRepository.GetAll();
                return View(viewModel);
            }
            catch (Exception ex)
            {
                return View("Error");
            }
        }
    }
}
