
using SurveyGenerator.Core.Domaine.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace SurveyGenerator.Data.Mapping.Users
{
    public class UserPermissionMap : SurveyEntityTypeConfiguration<UserPermission>
    {
        public UserPermissionMap()
        {
            ToTable("USER_PERMISSIONS");
            HasKey(a => new { a.UserId, a.PermissionId });
            Property(a => a.CreatedOn).IsRequired();
            Property(a => a.Timestamp).IsRowVersion();

            HasRequired(a => a.Permission)
                    .WithMany(a => a.UserPermissions)
                    .HasForeignKey(a => a.PermissionId);

            HasRequired(a => a.User)
                   .WithMany(a => a.UserPermissions)
                   .HasForeignKey(a => a.UserId);
        }
    }
}
