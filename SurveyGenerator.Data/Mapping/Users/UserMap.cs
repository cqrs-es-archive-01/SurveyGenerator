
using SurveyGenerator.Core.Domaine.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace SurveyGenerator.Data.Mapping.Users
{
    public class UserMap:SurveyEntityTypeConfiguration<User>
    {
        public UserMap()
        {
            ToTable("USERS");

            HasKey(a => a.Id);
            Property(a => a.CreatedOn).IsRequired();
            Property(a => a.Email).IsRequired().HasMaxLength(100);
            Property(a => a.FirstName).IsRequired().HasMaxLength(50);
            Property(a => a.LastName).IsRequired().HasMaxLength(50);
            Property(a => a.Timestamp).IsRowVersion();
            Property(a => a.AccessLogin).IsRequired().HasMaxLength(50);

        }
    }
}
