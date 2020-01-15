using SaveTime.DataModel.Marker;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaveTime.DataModel.Organization
{
    public class Employer : IEntity, IAccountOwner
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual Account Account { get; set; }
    }
}
