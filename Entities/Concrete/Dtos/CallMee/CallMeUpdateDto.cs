﻿using Entities.Concrete.TableModels;

namespace Entities.Concrete.Dtos
{
    public class CallMeUpdateDto
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string Title { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int Phone { get; set; }
        public int ServiceId { get; set; }
        public string CategoryName { get; set; }
        public static CallMe ToCallMe(CallMeUpdateDto dto)
        {
            CallMe callMeUpdate = new()
            {
                Id=dto.Id,
                Title = dto.Title,
                Description = dto.Description,
                Name = dto.Name,
                Email = dto.Email,
                Phone = dto.Phone,
               ServiceID = dto.ServiceId,
              
             
            };
            return callMeUpdate;
        }
    }
}
