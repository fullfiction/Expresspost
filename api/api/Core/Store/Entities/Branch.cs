using System;

namespace api.Core.Store.Entities
{
    public class Branch : Entity
    {
        public bool IsStore { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string State { get; set; }
        public string Email { get; set; }
        public string Phonenumber { get; set; }
        public string ZipCode { get; set; }
        public long CountryId { get; set; }
        public long CompanyId { get; set; }

        public Country Country { get; set; }
        public Company Company { get; set; }
    }
}
