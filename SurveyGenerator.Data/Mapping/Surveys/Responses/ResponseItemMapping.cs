
using SurveyGenerator.Core.Domaine.Surveys.Questions;
using System;
using System.Collections.Generic;
using System.Text;

namespace SurveyGenerator.Data.Mapping.Surveys.Responses
{
    public class QuestionReponseMapping : SurveyEntityTypeConfiguration<ResponseItem>
    {
        public QuestionReponseMapping()
        {
            ToTable("RESPONSES_ITEMS");

            Property(a => a.CreatedOn).IsRequired();
            Property(a => a.ResponseValue).HasMaxLength(500);

            HasRequired(a => a.Response)
                .WithMany(a => a.ResponseItems)
                .HasForeignKey(a => a.ResponseId);

            HasRequired(a => a.Question)
                .WithMany(a => a.ResponseItems)
                .HasForeignKey(a => a.QuestionId)
                .WillCascadeOnDelete(false);
        }
    }
}
