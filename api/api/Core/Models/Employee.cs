using System.Collections.Generic;

namespace api.Core.Models
{
    public class Employee : Entity
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }

        public virtual List<BranchEmployee> Branches {get; set;}
    }
}
