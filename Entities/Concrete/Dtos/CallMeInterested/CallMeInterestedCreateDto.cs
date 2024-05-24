using Entities.Concrete.TableModels;

namespace Entities.Concrete.Dtos
{
    public class CallMeInterestedCreateDto
    {
        public string Details { get; set; }
        public string CallMeCategoryName { get; set; }

        public static CallMeInterested ToCallMeInterested(CallMeInterestedCreateDto dto)
        {
            CallMeInterested callMeInterested = new()
            {
                Details = dto.Details,
              
            };
            return callMeInterested;
        }

    }
}
