
using SurveyGenerator.Core.Domaine;
using System.Data.Entity.ModelConfiguration;

namespace SurveyGenerator.Data.Mapping
{
    public class SurveyEntityTypeConfiguration<T> : EntityTypeConfiguration<T> where T : BaseEntity
    {
        protected SurveyEntityTypeConfiguration()
        {
            PostInitialize();
        }

        protected virtual void PostInitialize()
        {

        }

    }
}