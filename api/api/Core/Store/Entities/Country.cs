using System;
using System.Collections.Generic;

namespace api.Core.Store.Entities
{
    public class Country : Entity
    {
        public string Name { get; set; }

        public virtual List<CompanyCountry> Companies { get; set; }
    }
}
