using SurveyGenerator.Core.Domaine.Surveys.Questions;
using System;
using System.Collections.Generic;
using System.Text;

namespace SurveyGenerator.Data.Mapping.Surveys.Questions
{
    public class QuestionMapping : SurveyEntityTypeConfiguration<Question>
    {
        public QuestionMapping()
        {
            ToTable("QUESTIONS");

            HasKey(a => a.Id);
            Property(a => a.CreatedOn).IsRequired();
            Property(a => a.Description).HasMaxLength(250);
            Property(a => a.HelperText).HasMaxLength(250);
            Property(a => a.Label).IsRequired().HasMaxLength(100);
            Property(a => a.MaximumRateDescription).HasMaxLength(20);
            Property(a => a.MininumRateDescription).HasMaxLength(20);
            Property(a => a.Timestamp).IsRowVersion();
            Property(a => a.IsRequired).IsRequired();
            Property(a => a.EnableOtherOption).IsRequired();

            HasOptional(a => a.ParentQuestion)
            .WithMany(a => a.Questions)
            .HasForeignKey(a => a.ParentId);

            //Has(a => a.Options)
            //.WithOne(a => a.Question)
            //.HasForeignKey(a => a.QuestionId);

            HasRequired(a => a.Survey)
                .WithMany(a => a.Questions)
                .HasForeignKey(a => a.SurveyId);
        }
    }
}
