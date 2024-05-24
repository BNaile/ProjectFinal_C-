using Entities.Concrete.TableModels;
namespace Entities.Concrete.Dto
{
    public class AboutCreateDto
    {
        public string ShortDescription { get; set; }
        public string Title { get; set; }

        public static About ToAbout(AboutCreateDto dto)
        {
            About about = new() 
            
            {
                ShortDescription = dto.ShortDescription,
                
            };
            return about;
            
        }
       
    }
}
﻿
