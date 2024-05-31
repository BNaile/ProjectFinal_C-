using Entities.Concrete.TableModels;

namespace Entities.Concrete.Dtos
{
    public class FeedbackCreateDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public static Feedback ToFeedback(FeedbackCreateDto dto)
        {
            Feedback feedback = new()
            {
                Title=dto.Title,
                Description=dto.Description,
               
            };

            return feedback;    
        }
    }
}
