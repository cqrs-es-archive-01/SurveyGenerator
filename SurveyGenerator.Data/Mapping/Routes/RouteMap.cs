using SurveyGenerator.Core.Domaine.Routes;

namespace SurveyGenerator.Data.Mapping.Routes
{
    public class RouteMap : SurveyEntityTypeConfiguration<Route>
    {
        public RouteMap()
        {
            ToTable("ROUTES");
            Property(a => a.Routing).HasMaxLength(100).IsRequired();
            Property(a => a.CreatedOn).IsRequired();

            Property(a => a.CreatedOn).IsRequired();


        }
    }
}
