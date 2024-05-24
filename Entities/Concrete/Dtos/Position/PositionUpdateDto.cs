using Entities.Concrete.TableModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.Dtos
{
    public class PositionUpdateDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public static Position ToPosition(PositionUpdateDto dto)
        {
            Position position = new()
            {
                Id=dto.Id,
                Name = dto.Name,
            };
            return position;
        }
    }
}
