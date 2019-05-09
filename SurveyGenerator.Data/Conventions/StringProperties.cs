using System.Data.Entity.ModelConfiguration.Conventions;

namespace SurveyGenerator.Data.Conventions
{
    public class StringLabelProperties : Convention
    {
        public StringLabelProperties()
        {
            Properties<string>().Where(a => a.Name == "Label" || a.Name.EndsWith("Name") || a.Name.StartsWith("Name"))
                                .Configure(a => a.HasMaxLength(50));

        }


    }

    public class StringDescriptionProperties : Convention
    {
        public StringDescriptionProperties()
        {
            Properties<string>().Where(a => a.Name == "Description")
                          .Configure(a => a.HasMaxLength(500));
        }

    }

    public class StringUrlProperties : Convention
    {
        public StringUrlProperties()
        {
            Properties<string>().Where(a => a.Name.Contains("Url"))
                          .Configure(a => a.HasMaxLength(150));
        }

    }
    public class StringTitleProperties : Convention
    {
        public StringTitleProperties()
        {
            Properties<string>().Where(a => a.Name.Contains("Title"))
                          .Configure(a => a.HasMaxLength(100));
        }

    }
}
