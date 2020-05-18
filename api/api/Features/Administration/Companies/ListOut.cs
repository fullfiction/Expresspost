using System;

namespace api.Features.Administration.Companies
{
    public class ListOut
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public long ParentId { get; set; }
    }
}
