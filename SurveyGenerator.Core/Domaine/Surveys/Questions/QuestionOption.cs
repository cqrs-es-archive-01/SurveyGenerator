using SurveyGenerator.Core.Domaine.Surveys.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace SurveyGenerator.Core.Domaine.Surveys.Questions
{
    public class QuestionOption : BaseEntity
    {
        public Guid Id { get; set; }

        public int Order { get; set; }
        public string Label { get; set; }
        public string Url { get; set; }
        public String Description { get; set; }

        public Guid QuestionId { get; set; }
        public virtual Question Question { get; set; }

        public virtual ICollection<ResponseOption> ResponseOptions { get; set; }
    }
}
