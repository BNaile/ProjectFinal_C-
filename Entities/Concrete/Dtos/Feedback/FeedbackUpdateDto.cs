using Entities.Concrete.TableModels;

namespace Entities.Concrete.Dtos
{
    public class FeedbackUpdateDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
       
        public static Feedback ToFeedback(FeedbackUpdateDto dto)
        {
            Feedback feedback = new()
            {
               Id = dto.Id,
               Title = dto.Title,
               Description = dto.Description,
            
            };
            return feedback;
        }
    }
}
