using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SurveyGenerator.Data;
using SurveyGenerator.Data.Data;
using SurveyGenerator.Core.Domaine.Users;
using SurveyGenerator.Service.Users;
using System.Runtime.Remoting.Contexts;
using System.Linq;

namespace SurveyGenerator.Service.Test
{
    [TestClass]
    public class UserServiceTest
    {
        private SurveyGeneratorContext _generatorContext;
        private GenericRepository<User> _userRepository;

        private IUserService _userService;

        [TestMethod]
        public void DoesUserServiceBringUsers()
        {
            //Arrange
            _generatorContext = new SurveyGeneratorContext();
            _userRepository = new GenericRepository<User>(_generatorContext);
            _userService = new UserService(_userRepository);
            //Act 
            var users = _userService.GetAllUsers();

            //Assert
            Assert.AreEqual(users.Count(), 0);
        }
        [TestMethod]
        public void InsertUserTest()
        {
            //Arrange
            DateTime dt = Convert.ToDateTime(DateTime.Now);

            _generatorContext = new SurveyGeneratorContext();
            _userRepository = new GenericRepository<User>(_generatorContext);
            _userService = new UserService(_userRepository);

            User newUser = new User
            {
                AccessLogin = "AccessLoginTest",
                CreatedOn = DateTime.Now,
                Deleted = false,
                Id = Guid.NewGuid(),
                FirstName = "FirstName",
                LastName = "LastName",
                ModifiedOn = DateTime.Now,
                Timestamp = BitConverter.GetBytes(dt.Ticks),
                Email = "email@gmail.com"
            };
            //Act 
            _userService.InsertUser(newUser);

            //Assert
            var user = _userService.GetUserById(newUser.Id);
            Assert.AreEqual(newUser.Id, user.Id);
        }

        [TestMethod]
        public void DeleteUserTest()
        {
            //Arrange
            _generatorContext = new SurveyGeneratorContext();
            _userRepository = new GenericRepository<User>(_generatorContext);
            var users = _userRepository.All();

            //Assert 
            _userRepository.Delete(users);

            //Act
            var usersAfterDelete = _userRepository.All();
            Assert.AreEqual(usersAfterDelete.Count(), 0);
        }
    }
}
