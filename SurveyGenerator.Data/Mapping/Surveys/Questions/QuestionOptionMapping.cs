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

            this.Property(a => a.Order).IsRequired();
            this.Property(a => a.CreatedOn).IsRequired();

        }
     
    }
}
