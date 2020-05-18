using System;

namespace api.Core.Store.Entities
{
    public class CompanyCountry : Entity
    {
        public long CompanyId { get; set; }
        public long CountryId { get; set; }

        public Company Company { get; set; }
        public Country Country { get; set; }
    }
}
