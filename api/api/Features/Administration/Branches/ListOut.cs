using System;

namespace api.Features.Administration.Branches
{
    public class ListOut
    {
        public long Id { get; set; }
        public bool IsStore { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string State { get; set; }
        public string Email { get; set; }
        public string Phonenumber { get; set; }
        public string ZipCode { get; set; }
        public long CountryId { get; set; }
        public long CompanyId { get; set; }
    }
}
