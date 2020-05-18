using System;

namespace api.Features.Administration.Admins
{
    public class ListOut
    {
        public long Id { get; set; }
        public string Username { get; set; }
        public bool IsActive { get; set; }
    }
}
