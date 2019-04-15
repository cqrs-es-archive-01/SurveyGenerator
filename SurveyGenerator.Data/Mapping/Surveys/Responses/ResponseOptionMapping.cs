
using SurveyGenerator.Core.Domaine.Surveys.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace SurveyGenerator.Data.Mapping.Surveys.Responses
{
    public class ResponseOptionMapping : SurveyEntityTypeConfiguration<ResponseOption>
    {
        public ResponseOptionMapping()
        {
            ToTable("RESPONSE_OPTIONS");

            HasKey(a => new { a.ResponseItemId, a.QuestionOptionId });
            Property(a => a.Timestamp).IsRowVersion();
            Property(a => a.Other).IsRequired();

            HasRequired(a => a.QuestionOption)
                .WithMany(a => a.ResponseOptions)
                .HasForeignKey(a => a.QuestionOptionId);

            HasRequired(a => a.ResponseItem)
               .WithMany(a => a.Options)
               .HasForeignKey(a => a.ResponseItemId);
        }
    }
}
