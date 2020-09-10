using System;

namespace api.Core.Models
{
    public class Localization : Entity
    {
        public string Context { get; set; }
        public string Key { get; set; }
        public string Locale { get; set; }
        public string Value { get; set; }
    }
}
