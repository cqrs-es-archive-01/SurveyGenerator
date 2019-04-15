
using SurveyGenerator.Core.Domaine.Surveys.Questions;
using System;
using System.Collections.Generic;
using System.Text;

namespace SurveyGenerator.Data.Mapping.Surveys
{
    public class SurveyMapping : SurveyEntityTypeConfiguration<Survey>
    {
        public SurveyMapping()
        {
            ToTable("SURVEYS");

            HasKey(a => a.Id);
            Property(a => a.CreatedOn).IsRequired();
            Property(a => a.Description).HasMaxLength(250);
            Property(a => a.Footer).HasMaxLength(500);
            Property(a => a.Header).HasMaxLength(500);
            Property(a => a.Timestamp).IsRowVersion();
            Property(a => a.Title).HasMaxLength(150).IsRequired();
            Property(a => a.Type).IsRequired();

            HasRequired(a => a.User)
                .WithMany(a => a.Surveys)
                .HasForeignKey(a => a.UserId);


        }
    }
}
