using SurveyGenerator.Core.Domaine.Users;
using SurveyGenerator.Core.Utilities;
using System;

namespace SurveyGenerator.Service.Users
{
    public interface IUserService
    {
        User GetUserById(Guid userId);
  
        void DeleteUser(User user);
  
        IPagedList<User> GetAllUsers(int pageIndex, int pageSize, bool deleted = false);
       
        void InsertUser(User user);
      
        void UpdateUser(User user);
    }
}
