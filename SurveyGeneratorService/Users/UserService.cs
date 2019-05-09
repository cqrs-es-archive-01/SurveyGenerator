using SurveyGenerator.Core.Data;
using SurveyGenerator.Core.Domaine.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SurveyGenerator.Core.Utilities;

namespace SurveyGenerator.Service.Users
{
    public partial class UserService : IUserService
    {
        #region Fields

        private readonly IRepository<User> _userRepository;

        #endregion

        #region Ctor

        public UserService(IRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }

        #endregion

        #region Methods

        public void DeleteUser(User user)
        {
            if (user == null)
                throw new ArgumentNullException("user");

            user.Deleted = true;
            user.DeletedOn = DateTime.Now;
            UpdateUser(user);
        }

        public IPagedList<User> GetAllUsers(int pageIndex, int pageSize, bool deleted = false)
        {
            var users = _userRepository.All(pageIndex, pageSize, (a) => a.Deleted != deleted);
            return users;
        }


        public User GetUserById(Guid userId)
        {
            return _userRepository.FindByKey(userId);
        }

        public void InsertUser(User user)
        {
            if (user == null)
                throw new ArgumentNullException("user");

            _userRepository.Insert(user);
        }

        public void UpdateUser(User user)
        {
            if (user == null)
                throw new ArgumentNullException("user");

            _userRepository.Update(user);
        }


        #endregion

    }
}
