using Business.Abstract;
using Entities.Concrete.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FinalProjectWeb.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]
    [Authorize]
    public class TeamController : Controller
    {
        private readonly ITeamService _teamService;
        private readonly IPositionService _positionService;
        public TeamController(ITeamService teamService, IPositionService positionService)
        {
            _teamService = teamService;
            _positionService = positionService;
        }

        public IActionResult Index()
        {
            var data = _teamService.GetTeamWithPositionCategories().Data;

            return View(data);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewData["TeamCategorie"] = _positionService.GetAll().Data;
            return View();
        }

        [HttpPost]
        public IActionResult Create(TeamCreateDto dto)
        {
            ViewData["TeamCategorie"] = _positionService.GetAll().Data;
            var result = _teamService.Add(dto);
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
            ViewData["TeamCategorie"] = _positionService.GetAll().Data;
            var data = _teamService.GetById(id).Data;

            return View(data);
        }

        [HttpPost]
        public IActionResult Edit(TeamUpdateDto dto)
        {
            ViewData["TeamCategorie"] = _positionService.GetAll().Data;
            var result = _teamService.UpDate(dto);

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
            var result = _teamService.Delete(id);
            if (!result.IsSuccess)
            {
                ModelState.AddModelError("", result.Message);
                return View(result);
            }
                return RedirectToAction("Index");

           

        }
    }
}
