using SocialNetwork.Models;
using SocialNetwork.Repositories;
using SocialNetwork.ViewModels;
using Microsoft.AspNet.Identity;
using System.Web.Mvc;
using System.Collections.Generic;
using System;
using System.Threading.Tasks;

namespace SocialNetwork.Controllers
{
    public class StoryController : Controller
    {
        private IStoryRepository _repository;
        private IGroupRepository _groupRepository;

        public StoryController(IStoryRepository repository, IGroupRepository groupRepository)
        {
            _repository = repository;
            _groupRepository = groupRepository;
        }
        // GET: Story
        public ActionResult Index()
        {
            string id = User.Identity.GetUserId();
            StoryViewModel viewModel = new StoryViewModel();
            viewModel.UserStories = _repository.GetAllByUserId(id);
            return View(viewModel);
        }

        // GET: Story/Details/5
        public ActionResult Details(int id)
        {
            StoryDetailViewModel viewModel = new StoryDetailViewModel();
            viewModel.story = _repository.Find(id);
            return View(viewModel);
        }

        [Authorize]
        // GET: Story/Create
        public ActionResult Create()
        {
            StoryCreateEditViewModel model = new StoryCreateEditViewModel();
            model.Groups = _groupRepository.GetAll();
            return View(model);
        }

        [Authorize]
        // POST: Story/Create
        [HttpPost]
        public async Task<ActionResult> Create(StoryCreateEditViewModel model)
        {
            try
            {
                string id = User.Identity.GetUserId();
                Story storyModel = model.Convert();
                storyModel.UserId = id;
                await _repository.AddAsync(storyModel);
                int memberCount = _repository.GetGroupMemberCount(model.GroupId);
                int storyCount = _repository.GetGroupStoryCount(model.GroupId);
                _groupRepository.UpdateCounts(model.GroupId, memberCount, storyCount);
                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                return View();
            }
        }
        
        public ActionResult Edit(int id)
        {
            StoryCreateEditViewModel model = new StoryCreateEditViewModel(_repository.Find(id));
            model.Groups = _groupRepository.GetAll();
            model.OldGroupId = model.GroupId;
            return View(model);
        }

        // POST: Story/Edit/5
        [HttpPost]
        public async Task<ActionResult> Edit(int id, StoryCreateEditViewModel model)
        {
            try
            {
                await _repository.UpdateAsync(model.Convert(id));
                int memberCount = _repository.GetGroupMemberCount(model.GroupId);
                int storyCount = _repository.GetGroupStoryCount(model.GroupId);
                _groupRepository.UpdateCounts(model.GroupId, memberCount, storyCount);
                int memberCountOld = _repository.GetGroupMemberCount(model.OldGroupId);
                int storyCountOld = _repository.GetGroupStoryCount(model.OldGroupId);
                _groupRepository.UpdateCounts(model.OldGroupId, memberCountOld, storyCountOld);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
