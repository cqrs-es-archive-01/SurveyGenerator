using System.Data.Entity;

namespace SurveyGenerator.Data
{
    public class SurveyGeneratorContextConfig : DbConfiguration
    {
        public SurveyGeneratorContextConfig()
        {
            this.SetDatabaseInitializer(new NullDatabaseInitializer<SurveyGeneratorContext>());
        }
    }
}
