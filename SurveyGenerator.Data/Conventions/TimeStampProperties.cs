using System.Data.Entity.ModelConfiguration.Conventions;

namespace SurveyGenerator.Data.Conventions
{
    public class TimeStampProperties : Convention
    {
        public TimeStampProperties()
        {
            Properties<byte[]>().Where(a => a.Name == "Timestamp").Configure(a => a.IsRowVersion());
        }
    }
}
