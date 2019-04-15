
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

            HasKey(a => a.Id);
            Property(a => a.CreatedOn).IsRequired();
            Property(a => a.ResponseValue).HasMaxLength(500);
            Property(a => a.Timestamp).IsRowVersion();

            HasRequired(a => a.Response)
                .WithMany(a => a.ResponseItems)
                .HasForeignKey(a => a.ResponseId);
        }
    }
}
