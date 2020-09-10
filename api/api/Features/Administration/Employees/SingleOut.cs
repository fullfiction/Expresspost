using System;

namespace api.Features.Administration.Employees
{
    public class SingleOut
    {
        public long Id { get; set; }
        public DateTime Created { get; set; }
        public string Username { get; set; }
        public bool IsActive { get; set; }
    }
}
