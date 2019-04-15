
using SurveyGenerator.Core.Domaine.Features;

namespace SurveyGenerator.Data.Mapping.Features
{
    public class PermissionFeatureMap : SurveyEntityTypeConfiguration<PermissionFeature>
    {
        public PermissionFeatureMap()
        {
            ToTable("PERMISSION_FEATURES");
            HasKey(a => new { a.FeatureId, a.PermissionId });
            Property(a => a.Timestamp).IsRowVersion();

            Property(a => a.ActionType).IsRequired();

            HasRequired(a => a.Feature)
            .WithMany(a => a.PermissionFeatures)
            .HasForeignKey(a => a.FeatureId);

            HasRequired(a => a.Permission)
                   .WithMany(a => a.PermissionFeatures)
                   .HasForeignKey(a => a.PermissionId);
        }
    }
}