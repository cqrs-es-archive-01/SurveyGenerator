using SurveyGenerator.Core.Domaine.Surveys.Questions;
using SurveyGenerator.Core.Domaine.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace SurveyGenerator.Core.Domaine.Surveys.Responses
{
    public class Response : BaseEntity
    {
        public Guid Id { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }
        public SurveyTypes Type { get; set; }
        public string Header { get; set; }
        public string Footer { get; set; }
        public Guid UserId { get; set; }
        public Guid SurveyId { get; set; }


        public virtual User User { get; set; }
        public virtual Survey Survey{ get; set; }
        public ICollection <ResponseItem> ResponseItems { get; set; }
    }
}
