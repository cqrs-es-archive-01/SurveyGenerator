using System.Data.Entity.ModelConfiguration;
using SurveyGenerator.Core.Domaine.Surveys.Questions;
using System;
using System.Collections.Generic;
using System.Text;

namespace SurveyGenerator.Data.Mapping.Surveys.Questions
{
   public  class QuestionOptionMapping: SurveyEntityTypeConfiguration<QuestionOption>
    {
        public QuestionOptionMapping()
        {
            this.ToTable("QUESTION_OPTIONS");

            this.HasKey(a => a.Id);
            this.Property(a => a.Timestamp).IsRowVersion();
            this.Property(a => a.Order).IsRequired();
            this.Property(a => a.Url).HasMaxLength(250);
            this.Property(a => a.CreatedOn).IsRequired();
            this.Property(a => a.Description).HasMaxLength(250);
            this.Property(a => a.Label).HasMaxLength(150);

        }
     
    }
}
