using SocialNetwork.Models;
using SocialNetwork.Repositories;
using SocialNetwork.ViewModels;
using System;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace SocialNetwork.Controllers
{
    public class HomeController : Controller
    {
        private IRepository<Story> _storyRepository;
        private IRepository<User> _userrepository;
        public HomeController(IRepository<User> repository)
        {
            _userrepository = repository;
        }
        public async Task<ActionResult> Index()
        {
            MyStoryViewModel model = new MyStoryViewModel();
            model.Users = await _userrepository.GetAllAsync();
            return View(model);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}