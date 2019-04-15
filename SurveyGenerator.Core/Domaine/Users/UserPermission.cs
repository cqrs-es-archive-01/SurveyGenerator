using SurveyGenerator.Core.Domaine.Features;
using System;
using System.Collections.Generic;
using System.Text;

namespace SurveyGenerator.Core.Domaine.Users
{
    public class UserPermission :BaseEntity
    {
        public Guid UserId { get; set; }
        public Guid PermissionId { get; set; }

        public virtual User User { get; set; }
        public virtual Permission Permission { get; set; }
    }
}
