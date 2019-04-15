using SurveyGenerator.Core.Domaine.Surveys.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace SurveyGenerator.Core.Domaine.Surveys.Questions
{
    public class ResponseItem : BaseEntity
    {
        public Guid Id { get; set; }
        public Guid ResponseId { get; set; }
        public Guid QuestionId { get; set; }
        public string ResponseValue { get; set; }

        public Response Response { get; set; }
        public Question Question { get; set; }
        public virtual ICollection<ResponseOption> Options {get;set;}
    }
}
