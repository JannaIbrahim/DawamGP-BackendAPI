using Dawam.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dawam.DAL.Data.Config
{
    public class WaqfConfiguration : IEntityTypeConfiguration<Waqf>
    {
        public void Configure(EntityTypeBuilder<Waqf> builder)
        {
            builder.Property(w => w.WaqfName).IsRequired();
           // builder.HasOne(w => w.WaqfCountry).WithMany().HasForeignKey(w => w.CountryId).OnDelete(DeleteBehavior.SetNull);
            //builder.HasOne(w => w.WaqfCity).WithMany().HasForeignKey(w => w.CityId).OnDelete(DeleteBehavior.SetNull);

            //throw new NotImplementedException();
        }
    }
}
