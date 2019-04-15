using SurveyGenerator.Core.Domaine.Surveys.Questions;
using System;
using System.Collections.Generic;
using System.Text;

namespace SurveyGenerator.Core.Domaine.Surveys.Responses
{
    public class ResponseOption:BaseEntity
    {
        public Guid ResponseItemId { get; set; }
        public Guid QuestionOptionId { get; set; }
        public bool Checked { get; set; }
        public bool Other { get; set; }

        public virtual ResponseItem ResponseItem { get; set; }
        public virtual QuestionOption QuestionOption { get; set; }

    }
}
