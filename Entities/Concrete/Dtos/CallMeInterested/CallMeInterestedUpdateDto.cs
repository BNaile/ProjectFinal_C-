using Entities.Concrete.TableModels;

namespace Entities.Concrete.Dtos
{
    public class CallMeInterestedUpdateDto
    {
        public int Id { get; set; }
        public string Details { get; set; }
        public string CallMeCategoryName { get; set; }
       
        public static CallMeInterested ToCallMeInterested(CallMeInterestedUpdateDto dto)
        {
            CallMeInterested callMeInterested = new()
            {
                Id = dto.Id,
                Details = dto.Details,
         

            };
            return callMeInterested;
        }

    }
}
