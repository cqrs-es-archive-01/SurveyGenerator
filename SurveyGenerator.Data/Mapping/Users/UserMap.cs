
using SurveyGenerator.Core.Domaine.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace SurveyGenerator.Data.Mapping.Users
{
    public class UserMap : SurveyEntityTypeConfiguration<User>
    {
        public UserMap()
        {
            ToTable("USERS");

            Property(a => a.CreatedOn).IsRequired();
            Property(a => a.Email).IsRequired().HasMaxLength(100);
            Property(a => a.AccessLogin).IsRequired().HasMaxLength(50);

            HasMany<Permission>(a => a.Permissions)
                .WithMany(a => a.Users)
                .Map(cs =>
                {
                    cs.MapLeftKey("UserId");
                    cs.MapRightKey("PermissionId");
                    cs.ToTable("USERS_PERMISSIONS");
                });
        }
    }
}
