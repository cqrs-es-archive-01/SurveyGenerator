

using System.Data.Entity;

namespace SurveyGenerator.Data.Mapping
{
    public interface IMappingConfiguration
    {
        void ApplyConfiguration(DbModelBuilder modelBuilder);

    }
}