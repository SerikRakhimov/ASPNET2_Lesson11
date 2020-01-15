using SaveTime.DataModel.Marker;
using SaveTime.DataModel.Organization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaveTime.DataModel.Business
{
    public class Client : IEntity, IAccountOwner
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual Account Account { get; set; }
    }
}
