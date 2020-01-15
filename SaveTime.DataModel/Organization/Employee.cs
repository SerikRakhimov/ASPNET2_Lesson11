using SaveTime.DataModel.Dictionary;
using SaveTime.DataModel.Marker;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaveTime.DataModel.Organization
{
    public class Employee : IEntity, IAccountOwner
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [ForeignKey("Account")]
        public int AccountId { get; set; }
        public virtual Account Account { get; set; }
        [ForeignKey("Branch")]
        public int BranchId { get; set; }
        public virtual Branch Branch { get; set; }
        public virtual IList<Service> Services { get; set; } = new List<Service>();

    }
}