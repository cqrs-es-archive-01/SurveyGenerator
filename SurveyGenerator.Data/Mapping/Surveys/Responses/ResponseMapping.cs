
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

            HasKey(a => a.Id);
            Property(a => a.CreatedOn).IsRequired();
            Property(a => a.Description).HasMaxLength(250);
            Property(a => a.Footer).HasMaxLength(500);
            Property(a => a.Header).HasMaxLength(500);
            Property(a => a.Timestamp).IsRowVersion();
            Property(a => a.Title).HasMaxLength(250);
            Property(a => a.Type).IsRequired();

            HasRequired(a => a.Survey)
                .WithMany(a => a.Responses)
                .HasForeignKey(a => a.SurveyId);

            HasRequired(a => a.User)
                .WithMany(a => a.Responses)
                .HasForeignKey(a => a.UserId);

        }
    }
}
