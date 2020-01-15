using SaveTime.DataModel.Marker;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaveTime.DataModel.Dictionary
{
    public class Service : IEntity
    {
        public int Id { get; set; }
        public string Title { get; set; }
    }
}
