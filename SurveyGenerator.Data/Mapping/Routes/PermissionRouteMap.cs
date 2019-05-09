using SurveyGenerator.Core.Domaine.Routes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyGenerator.Data.Mapping.Routes
{
    public class PermissionRouteMap:SurveyEntityTypeConfiguration<PermissionRoute>
    {
        public PermissionRouteMap()
        {
            ToTable("PERMISSIONS_ROUTES");
            HasKey(a => new { a.RouteId, a.PermissionId });

            Property(a => a.ActionType).IsRequired();

            HasRequired(a => a.Route)
            .WithMany(a => a.PermissionRoutes)
            .HasForeignKey(a => a.RouteId);

            HasRequired(a => a.Permission)
                   .WithMany(a => a.PermissionRoutes)
                   .HasForeignKey(a => a.PermissionId);
        }
    }
}
