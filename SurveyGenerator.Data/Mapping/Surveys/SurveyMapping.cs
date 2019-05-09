
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

            Property(a => a.CreatedOn).IsRequired();
            Property(a => a.Footer).HasMaxLength(500);
            Property(a => a.Header).HasMaxLength(500);
            Property(a => a.Title).IsRequired();
            Property(a => a.Type).IsRequired();

            HasRequired(a => a.User)
                .WithMany(a => a.Surveys)
                .HasForeignKey(a => a.UserId)
                .WillCascadeOnDelete(false);


        }
    }
}
