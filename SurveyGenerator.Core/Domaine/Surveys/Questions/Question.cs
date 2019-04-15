using SurveyGenerator.Core.Domaine.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace SurveyGenerator.Core.Domaine.Surveys.Questions
{
    public class Question : BaseEntity
    {
        public Guid Id { get; set; }

        public string Label { get; set; }
        public string Description { get; set; }
        public int Order { get; set; }
        public QuestionTypes Type { get; set; }
        public bool IsRequired { get; set; }
        public bool EnableOtherOption { get; set; }
        public string HelperText { get; set; }
        public string MininumRateDescription { get; set; }
        public string MaximumRateDescription { get; set; }


        public Guid? ParentId { get; set; }
        public virtual Question ParentQuestion { get; set; }
        public virtual ICollection<QuestionOption> Options { get; set; }
        public virtual ICollection<Question> Questions { get; set; }
        public Guid SurveyId { get; set; }
        public virtual Survey Survey { get; set; }

        public Guid UserId { get; set; }
        public virtual User User { get; set; }

    }
}
