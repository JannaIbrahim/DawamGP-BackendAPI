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
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasOne(u => u.country).WithMany().HasForeignKey(u => u.CountryId).OnDelete(DeleteBehavior.SetNull);
            

            //throw new NotImplementedException();
        }
    }
}
