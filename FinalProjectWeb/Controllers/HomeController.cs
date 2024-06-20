using Business.Abstract;
using FinalProjectWeb.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace FinalProjectWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly IAboutService _aboutService;
        private readonly IAboutCountService _aboutCountService;
        private readonly IBusinessCatService _bussinesCatService;
        private readonly ICallMeService _callMeService;
        private readonly ICallMeInterestedService _callMeInterestedService;
        private readonly IContactService _contactService;
        private readonly IExpertiseService _expertiseService;
        private readonly IFeedbackService _feedbackService;
        private readonly IIntroService _introService;
        private readonly IIntroCatService _introCatService;
        private readonly IPhotoService _photoService;
        private readonly IPhotoCategoryService _photoCategoryService;
        private readonly IPositionService _positionService;
        private readonly IQualityService _qualityService;
        private readonly IServicePackage _servicePackage;
        private readonly IServicePackageDescription _servicePackageDescription;
        private readonly ITeamService _teamService;
        private readonly ITestimonialService _testimonialService;

        public HomeController(IAboutService aboutService,
            IAboutCountService aboutCountService,
            IBusinessCatService bussinesCatService,
            ICallMeService callMeService,
            ICallMeInterestedService callMeInterestedService,
            IContactService contactService,
            IExpertiseService expertiseService,
            IFeedbackService feedbackService,
            IIntroService introService,
            IPhotoService photoService,
            IPhotoCategoryService photoCategoryService,
            IPositionService positionService,
            IQualityService qualityService,
            IServicePackage servicePackage,
            IServicePackageDescription servicePackageDescription,
            ITeamService teamService,
            ITestimonialService testimonialService,
            IIntroCatService introCatService)
        {
            _aboutService = aboutService;
            _aboutCountService = aboutCountService;
            _bussinesCatService = bussinesCatService;
            _callMeService = callMeService;
            _callMeInterestedService = callMeInterestedService;
            _contactService = contactService;
            _expertiseService = expertiseService;
            _feedbackService = feedbackService;
            _introService = introService;
            _photoService = photoService;
            _photoCategoryService = photoCategoryService;
            _positionService = positionService;
            _qualityService = qualityService;
            _servicePackage = servicePackage;
            _servicePackageDescription = servicePackageDescription;
            _teamService = teamService;
            _testimonialService = testimonialService;
            _introCatService = introCatService;
        }

        public IActionResult Index()
        {
            var about = _aboutService.GetAll().Data;
            var aboutcountservice = _aboutCountService.GetAll().Data;
            var bussinescategorieservice = _bussinesCatService.GetAll().Data;
            var callmeservice = _callMeService.GetAll().Data;
            var calmeinterestedservice = _callMeInterestedService.GetAll().Data;
            var contactservice = _contactService.GetAll().Data;
            var expertiseservice = _expertiseService.GetAll().Data;
            var feedbackservice = _feedbackService.GetAll().Data;
            var introcatservice = _introService.GetAll().Data;
            var photoservice = _photoService.GetPhotMeWithCategory().Data;
            var photocategoryservice = _photoCategoryService.GetAll().Data;
            var positionservice = _positionService.GetAll().Data;
            var qualityservice = _qualityService.GetAll().Data;
            var servicepackage = _servicePackage.GetAll().Data;
            var servicepackagedescription = _servicePackageDescription.GetServiceWithServicePackages().Data;
            var teamservice = _teamService.GetTeamWithPositionCategories().Data;
            var testmonialservice = _testimonialService.GetAll().Data;
            var Introcat=_introCatService.GetAll().Data;
            var Intro = _introService.GetAll().Data;

            HomeViewModels homeViewModels = new()
            {
                AboutsDtos = about,
                AboutCountDtos = aboutcountservice,
                BussinesCategoryDtos = bussinescategorieservice,
                CallMeDtos = callmeservice ,
                CallMeInterestedDtos = calmeinterestedservice,
                ContactDtos = contactservice,
                ExpertiseDtos = expertiseservice,
                FeedbackDtos = feedbackservice,
                IntroDtos = Intro,
                PhotosDtos = photoservice,
                PhotoCategoryDtos = photocategoryservice,
                PositionDtos = positionservice,
                QualityDtos = qualityservice,
                ServicePackageDtos = servicepackage,
                ServicePackageDescriptionDtos = servicepackagedescription,
                TeamDtos = teamservice,
                TestimonialDtos = testmonialservice,
                IntroCats = Introcat,
            };

            return View(homeViewModels);
        }
    } 
}

