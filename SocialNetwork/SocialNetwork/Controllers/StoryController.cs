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
        private IStoryRepository _storyRepository;
        private IGroupRepository _groupRepository;
        public Func<string> GetUserId; //For testing
        public Func<int, int> GetPageCountByItemCount; //For testing

        public StoryController(IStoryRepository storyRepository, IGroupRepository groupRepository)
        {
            _storyRepository = storyRepository;
            _groupRepository = groupRepository;
            GetUserId = () => User.Identity.GetUserId();
            GetPageCountByItemCount =  Extensions.GetPageCountByItemCount;
        }
        // GET: Story
        public async Task<ActionResult> Index(int page = 1)
        {
            try
            {
                string id = GetUserId();
                StoryViewModel viewModel = new StoryViewModel();
                viewModel.UserStories = _storyRepository.GetAllByUserId(id, page);
                viewModel.pageCount = GetPageCountByItemCount( _storyRepository.GetItemCountByUserId(id));
                return View(viewModel);
            }
            catch (Exception ex)
            {
                return View("Error");
            }
        }

        // GET: Story/Details/5
        public async Task<ActionResult> Details(int id)
        {
            try
            {
                StoryDetailViewModel viewModel = new StoryDetailViewModel();
                viewModel.story = _storyRepository.Find(id);
                return View(viewModel);
            }
            catch (Exception ex)
            {
                return View("Error");
            }
        }

        [Authorize]
        // GET: Story/Create
        public async Task<ActionResult> Create()
        {
            StoryCreateEditViewModel model = new StoryCreateEditViewModel();
            model.Groups = _groupRepository.GetAll();
            model.IsValid = true;
            return View(model);
        }

        [Authorize]
        // POST: Story/Create
        [HttpPost]
        public async Task<ActionResult> Create(StoryCreateEditViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    string id = User.Identity.GetUserId();
                    Story storyModel = model.Convert();
                    storyModel.UserId = id;
                    _storyRepository.Add(storyModel);
                    int memberCount = _storyRepository.GetGroupMemberCount(model.GroupId);
                    int storyCount = _storyRepository.GetGroupStoryCount(model.GroupId);
                    _groupRepository.UpdateCounts(model.GroupId, memberCount, storyCount);
                    return RedirectToAction("Index");
                }
                model.IsValid = false;
                return View(model);
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        public async Task<ActionResult> Edit(int id)
        {
            try
            {
                StoryCreateEditViewModel model = new StoryCreateEditViewModel(_storyRepository.Find(id));
                model.Groups = _groupRepository.GetAll();
                model.OldGroupId = model.GroupId;
                model.IsValid = true;
                return View(model);
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        // POST: Story/Edit/5
        [HttpPost]
        public async Task<ActionResult> Edit(int id, StoryCreateEditViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _storyRepository.Update(model.Convert(id));
                    int memberCount = _storyRepository.GetGroupMemberCount(model.GroupId);
                    int storyCount = _storyRepository.GetGroupStoryCount(model.GroupId);
                    _groupRepository.UpdateCounts(model.GroupId, memberCount, storyCount);
                    int memberCountOld = _storyRepository.GetGroupMemberCount(model.OldGroupId);
                    int storyCountOld = _storyRepository.GetGroupStoryCount(model.OldGroupId);
                    _groupRepository.UpdateCounts(model.OldGroupId, memberCountOld, storyCountOld);
                    return RedirectToAction("Index");
                }
                model.IsValid = false;
                return View(model);
            }
            catch
            {
                return View();
            }
        }
    }
}
