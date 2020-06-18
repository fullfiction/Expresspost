using System.Linq;
using api.Core.Store.Entities;
using api.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Features.Administration.Branches
{
    public class FilterIn : BaseFilterIn<Branch>
    {
        public bool? IsStore { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string State { get; set; }
        public string Email { get; set; }
        public string Phonenumber { get; set; }
        public string ZipCode { get; set; }
        public long? CountryId { get; set; }
        public long? CompanyId { get; set; }

        public override IQueryable<Branch> Apply(IQueryable<Branch> queryable)
        {
            queryable = base.Apply(queryable);
            return queryable.Where(x => (IsStore == null || x.IsStore == IsStore)
                                    &&  (AddressLine1 == null || EF.Functions.Like(x.AddressLine1.ToUpper(), $"%{AddressLine1.ToUpper()}%"))
                                    &&  (AddressLine2 == null || EF.Functions.Like(x.AddressLine1.ToUpper(), $"%{AddressLine1.ToUpper()}%"))
                                    &&  (Email == null || EF.Functions.Like(x.Email.ToUpper(), $"%{Email.ToUpper()}%"))
                                    &&  (Phonenumber == null || EF.Functions.Like(x.Phonenumber.ToUpper(), $"%{Phonenumber.ToUpper()}%"))
                                    &&  (ZipCode == null || EF.Functions.Like(x.ZipCode.ToUpper(), $"%{ZipCode.ToUpper()}%"))
                                    &&  (State == null || EF.Functions.Like(x.State.ToUpper(), $"%{State.ToUpper()}%"))
                                    &&  (CountryId == null || x.CountryId == CountryId)
                                    &&  (CompanyId == null || x.CompanyId == CompanyId)
                                    );
        }
    }
}
