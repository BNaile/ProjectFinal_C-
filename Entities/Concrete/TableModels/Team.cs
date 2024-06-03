using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.TableModels
{
    public class Team:BaseEntity
    {
        public string Name { get; set; }
        public string SurName { get; set; }
        public string FacebookLink { get; set; }
        public string TwitterLink { get; set; }
        public int PositionId { get; set; }
        public string PhotoUrl { get; set; }
        public virtual Position Position { get; set; }
    }
}
