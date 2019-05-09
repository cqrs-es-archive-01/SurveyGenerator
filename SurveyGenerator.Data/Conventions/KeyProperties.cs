using System;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace SurveyGenerator.Data.Conventions
{
    public class KeyProperties:Convention
    {
        public KeyProperties()
        {
            Properties<Guid>().Where(a => a.Name == "Id").Configure(a => a.IsKey());
        }
    }
}
