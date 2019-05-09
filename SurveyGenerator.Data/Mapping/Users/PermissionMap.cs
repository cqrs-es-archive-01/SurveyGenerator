
using SurveyGenerator.Core.Domaine.Users;

namespace SurveyGenerator.Data.Mapping.Users
{
    public class PermissionMap : SurveyEntityTypeConfiguration<Permission>
    {
        public PermissionMap()
        {
            ToTable("PERMISSIONS");
            Property(a => a.CreatedOn).IsRequired();

        }
    }
}