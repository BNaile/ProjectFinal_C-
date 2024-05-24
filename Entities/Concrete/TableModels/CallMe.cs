using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.TableModels
{
    public class CallMe:BaseEntity
    {
        public string Description { get; set; }
        public string Title { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int Phone { get; set; }
        public int ServiceID { get; set; }
        public virtual ServicePackage ServiceCategory { get; set; }
        public List<CallMeInterested> CallMeInterested { get; set; }
        public CallMe()
        {
            CallMeInterested = new List<CallMeInterested>();
        }
    }
}
