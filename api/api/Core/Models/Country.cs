using System;
using System.Collections.Generic;

namespace api.Core.Models
{
    public class Country : Entity
    {
        public string Name { get; set; }
        public virtual List<Branch> Branches {get; set;}
    }
}
