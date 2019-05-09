using System;
using System.Collections.Generic;

namespace SurveyGenerator.Core.Domaine.Routes
{
    public class Route:BaseEntity
    {
        public Guid Id { get; set; }
        public String Label { get; set; }
        public String Description { get; set; }
        public String Routing { get; set; }

        public virtual ICollection<PermissionRoute> PermissionRoutes { get; set; }
    }
}
