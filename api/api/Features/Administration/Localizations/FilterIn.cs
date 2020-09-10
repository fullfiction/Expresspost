using System;
using System.Linq;
using api.Core.Models;
using api.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Features.Administration.Localizations
{
    public class FilterIn : BaseFilterIn<Localization>
    {
        public string Key { get; set; }
        public string Context { get; set; }
        public string Locale { get; set; }
        public string Value { get; set; }

        public override IQueryable<Localization> Apply(IQueryable<Localization> queryable)
        {
            queryable = base.Apply(queryable);
            return queryable.Where(x => (Key == null || EF.Functions.Like(x.Key.ToUpper(), $"%{Key.ToUpper()}%")) &&
                                        (Context == null || EF.Functions.Like(x.Key.ToUpper(), $"%{Context.ToUpper()}%")) && 
                                        (Locale == null || EF.Functions.Like(x.Locale.ToUpper(), $"%{Locale.ToUpper()}%")) && 
                                        (Value == null || EF.Functions.Like(x.Value.ToUpper(), $"%{Value.ToUpper()}%")));
        }
    }
}
