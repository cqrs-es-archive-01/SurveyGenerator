using SurveyGenerator.Core.Domaine.Users;
using SurveyGenerator.Core.Utilities;
using System;
using System.Collections.Generic;

namespace SurveyGenerator.Service.Users
{
    public interface IUserService
    {
        User GetUserById(Guid userId);
  
        void DeleteUser(User user);
  
        IEnumerable<User> GetAllUsers();
       
        void InsertUser(User user);
      
        void UpdateUser(User user);
    }
}
