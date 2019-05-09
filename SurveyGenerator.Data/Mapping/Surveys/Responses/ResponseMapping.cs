
using SurveyGenerator.Core.Domaine.Surveys.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace SurveyGenerator.Data.Mapping.Surveys.Responses
{
    public class ResponseMapping : SurveyEntityTypeConfiguration<Response>
    {
        public ResponseMapping()
        {
            ToTable("RESPONSES");

            Property(a => a.CreatedOn).IsRequired();
            Property(a => a.Footer).HasMaxLength(500);
            Property(a => a.Header).HasMaxLength(500);
            Property(a => a.Type).IsRequired();

            HasRequired(a => a.Survey)
                .WithMany(a => a.Responses)
                .HasForeignKey(a => a.SurveyId)
                .WillCascadeOnDelete(false);

            HasRequired(a => a.User)
                .WithMany(a => a.Responses)
                .HasForeignKey(a => a.UserId)
                .WillCascadeOnDelete(false);

        }
    }
}
