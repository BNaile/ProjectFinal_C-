using Entities.Concrete.Dtos;
using Entities.Concrete.TableModels;

namespace FinalProjectWeb.ViewModels
{
    public class HomeViewModels
    {
        public List<About> AboutsDtos{ set; get; }
        public List<AboutCount> AboutCountDtos { set; get; }
        public List<BusinessCat> BussinesCategoryDtos { set; get; }
        public List<CallMe> CallMeDtos { set; get; }
        public List<CallMeInterested> CallMeInterestedDtos { set; get; }
        public List<Contact> ContactDtos { set; get; }
        public List<Expertise> ExpertiseDtos { set; get; }
        public List<Feedback> FeedbackDtos { set; get; }
        public List<Intro> IntroDtos { set; get; }

        public List<IntroCat>IntroCats { set; get; }
        public List<PhotoDto> PhotosDtos { set; get; }
        public List<PhotoCategoryDto> PhotoCategoryDtos { set; get; }
        public List<PositionDto> PositionDtos { set; get; }
        public List<Quality> QualityDtos { set; get; }
        public List<ServicePackage> ServicePackageDtos { set; get; }
        public List<ServicePackageDescription> ServicePackageDescriptionDtos { set; get; }
        public List<TeamDto> TeamDtos { set; get; }
        public List<Testimonial> TestimonialDtos { set; get; }
    }
}
