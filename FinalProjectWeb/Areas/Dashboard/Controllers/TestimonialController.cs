using Business.Abstract;
using Entities.Concrete.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace FinalProjectWeb.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]
    [Authorize]
    public class TestimonialController : Controller
    {
        private readonly ITestimonialService _testimonialService;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public TestimonialController(ITestimonialService testimonialService, IWebHostEnvironment webHostEnvironment)
        {
            _testimonialService = testimonialService;
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Index()
        {
            var data = _testimonialService.GetAll().Data;

            return View(data);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(TestimonialCreateDto dto, IFormFile UrlPhoto)
        {

            var result = _testimonialService.Add(dto, UrlPhoto, _webHostEnvironment.WebRootPath);
            if (!result.IsSuccess)
            {
                ModelState.AddModelError("", result.Message);
                return View(dto);
            }
            return RedirectToAction("Index");

        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var data = _testimonialService.GetById(id).Data;

            return View(data);
        }

        [HttpPost]
        public IActionResult Edit(TestimonialUpdateDto dto, IFormFile Name)
        {
            var result = _testimonialService.UpDate(dto, Name, _webHostEnvironment.WebRootPath);

            if (!result.IsSuccess)
            {
                ModelState.AddModelError("", result.Message);
                return View(dto);
            } 
                return RedirectToAction("Index");

            
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var result = _testimonialService.Delete(id);
            if (!result.IsSuccess)
            {
                ModelState.AddModelError("", result.Message);
                return View(result);
            }
                return RedirectToAction("Index");

          

        }
    }
}
