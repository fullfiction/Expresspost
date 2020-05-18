using System;

namespace api.Features.Administration.Admins
{
    public class SingleOut
    {
        public long Id { get; set; }
        public string Username { get; set; }
        public bool IsActive { get; set; }
    }
}
