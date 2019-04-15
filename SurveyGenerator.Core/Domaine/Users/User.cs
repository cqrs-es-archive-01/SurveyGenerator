using SurveyGenerator.Core.Domaine.Surveys.Questions;
using SurveyGenerator.Core.Domaine.Surveys.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace SurveyGenerator.Core.Domaine.Users
{
    public class User: BaseEntity
    {
        public Guid Id { get; set; }
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public String Email { get; set; }
        public string AccessLogin { get; set; }

        public virtual ICollection<UserPermission> UserPermissions { get; set; }
        public virtual ICollection<Survey> Surveys { get; set; }
        public virtual ICollection<Response> Responses { get; set; }
        public virtual ICollection<Question> Questions { get; set; }

    }
}
