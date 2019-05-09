using SurveyGenerator.Core.Domaine.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyGenerator.Core.Domaine.Routes
{
   public class PermissionRoute:BaseEntity
    {
        public Guid PermissionId { get; set; }
        public Guid RouteId { get; set; }
        public PermissionTypes ActionType { get; set; }
        public virtual Route Route { get; set; }
        public virtual Permission Permission { get; set; }

    }
}
