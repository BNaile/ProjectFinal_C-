using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.TableModels
{
    public class Position:BaseEntity
    {

        public string Name { get; set; }
        public List<Team> Teams { get; set; }

        public Position()
        {
            Teams = new List<Team>();
        }
    }
}
