using Entities.Concrete.TableModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.Dtos
{
    public class TeamUpdateDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public string  PhotoUrl { get; set; }
        public string FacebookUrl { get; set; }

        public string TwitterUrl { get; set; }

        public int PositionId { get; set; }
        public static Team ToTeam(TeamUpdateDto dto)
        {
            Team team = new()
            {
                Id= dto.Id, 
                Name = dto.Name,
                SurName = dto.SurName,
                PhotoUrl=dto.PhotoUrl,
                FacebookLink = dto.FacebookUrl,
                TwitterLink= dto.TwitterUrl,
                PositionId = dto.PositionId,
            };
            return team;
        }
    }
}
