using SurveyGenerator.Core.Domaine.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyGenerator.Data.Data.Users
{
    public class UserData
    {
        private SurveyGeneratorContext _generatorContext;

        public UserData(SurveyGeneratorContext generatorContext)
        {
            _generatorContext = generatorContext;
        } 

        public void InsertUser(User user)
        {
            //use this method instead of the one in GenericRepository
            //inserting a user must insert also perimissions,
        }
    }
}
