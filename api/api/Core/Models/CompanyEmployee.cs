namespace api.Core.Models
{
    public class BranchEmployee : Entity
    {
        public long EmployeeId { get; set; }
        public long BranchId { get; set; }
        public bool IsActive { get; set; }

        public Employee Employee { get; set; }
        public Branch Branch { get; set; }
    }
}
