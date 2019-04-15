using SurveyGenerator.Core.Domaine.Features;
using System;
using System.Collections.Generic;
using System.Text;

namespace SurveyGenerator.Core.Domaine.Users
{
    public class Permission: BaseEntity
    {
        public Guid Id { get; set; }
        public String Name { get; set; }
        public String Description { get; set; }

        public virtual ICollection<PermissionFeature> PermissionFeatures { get; set; }
        public virtual ICollection<UserPermission> UserPermissions { get; set; }

    }
}
