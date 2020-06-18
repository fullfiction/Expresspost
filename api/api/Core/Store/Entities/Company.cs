using System.Collections.Generic;

namespace api.Core.Store.Entities
{
    public class Company : Entity
    {
        public string Name { get; set; }
        public long? ParentId { get; set; }

        public Company Parent { get; set; }
        public virtual List<Company> Childs { get; set; }
        public virtual List<CompanyCountry> Countries { get; set; }
        public virtual List<Branch> Branches { get; set; }
    }
}
