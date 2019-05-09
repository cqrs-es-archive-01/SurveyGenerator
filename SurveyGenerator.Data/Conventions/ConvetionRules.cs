using System.Data.Entity;

namespace SurveyGenerator.Data.Conventions
{
    public static class ConventionRules
    {
        public static void Apply(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.AddAfter<StringLabelProperties>(new KeyProperties());

            modelBuilder.Conventions.AddAfter<KeyProperties>(new StringDescriptionProperties());

            modelBuilder.Conventions.AddAfter<StringDescriptionProperties>(new StringUrlProperties());

            modelBuilder.Conventions.AddAfter<StringUrlProperties>(new StringTitleProperties());

            modelBuilder.Conventions.AddAfter<StringTitleProperties>(new TimeStampProperties());

        }
    }
}
