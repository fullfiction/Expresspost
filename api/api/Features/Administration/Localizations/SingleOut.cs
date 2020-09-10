using System;

namespace api.Features.Administration.Localizations
{
    public class SingleOut
    {
        public long Id { get; set; }
        public DateTime Created { get; set; }
        public string Key { get; set; }
        public string Context { get; set; }
        public string Locale { get; set; }
        public string Value { get; set; }
    }
}
