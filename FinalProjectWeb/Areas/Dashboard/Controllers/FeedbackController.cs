using Business.Abstract;
using DataAccess.Concrete;
using Entities.Concrete.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FinalProjectWeb.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]
    [Authorize]
    public class FeedbackController : Controller
    {

        private readonly IFeedbackService _feedbackService;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public FeedbackController(IFeedbackService feedbacService, IWebHostEnvironment webHostEnvironment)
        {
            _feedbackService = feedbacService;
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Index()
        {
            var data = _feedbackService.GetAll().Data;

            return View(data);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(FeedbackCreateDto dto, IFormFile photoUrl)
        {
            var result = _feedbackService.Add(dto, photoUrl, _webHostEnvironment.WebRootPath);
            if (!result.IsSuccess)
            {
                ModelState.AddModelError("", result.Message);
                return View();
            }
            return RedirectToAction("Index");

        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var data = _feedbackService.GetById(id).Data;

            return View(data);
        }

        [HttpPost]
        public IActionResult Edit(FeedbackUpdateDto dto, IFormFile photoUrl)
        {
            var result = _feedbackService.UpDate(dto, photoUrl, _webHostEnvironment.WebRootPath);

            if (!result.IsSuccess)
            {
                ModelState.AddModelError("", result.Message);
                return View();
            }
            return RedirectToAction("Index");


        }
        [HttpPost]
        public IActionResult Delete(int id)
        {
            var result = _feedbackService.Delete(id);
            if (!result.IsSuccess)
            {
                ModelState.AddModelError("", result.Message);

                return View(result);
            }
            return RedirectToAction("Index");



        }
    }
}
