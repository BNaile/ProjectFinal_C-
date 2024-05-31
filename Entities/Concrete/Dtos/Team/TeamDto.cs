using Entities.Concrete.TableModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.Dtos
{
    public class TeamDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }

        public string FacebookUrl { get; set; }

        public string TwitterUrl { get; set; }

        public int PositionId { get; set; }

        public string PositionName { get; set; }

        public static List<TeamDto> Toteam(Team team)
        {
            TeamDto dto = new TeamDto()
            {
                Id = team.Id,
                Name = team.Name,
                SurName = team.SurName,
                FacebookUrl=team.FacebookLink,
                TwitterUrl=team.TwitterLink,
                PositionId=team.PositionId
            };
            List<TeamDto> dtoList = new List<TeamDto>();
            dtoList.Add(dto);
            return dtoList;
        }
    }
}
