using BusinessObject.Models;
using DataAccess.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly UserDAO _userDAO;

        public UserRepository(UserDAO userDAO)
        {
            _userDAO = userDAO;
        }

        public IEnumerable<User> GetAllUsers()
        {
            return _userDAO.GetAllUsers();
        }

        public User GetUserById(int userId)
        {
            return _userDAO.GetUserById(userId);
        }

        public int InsertUser(User user)
        {
            return _userDAO.InsertUser(user);
        }

        public void UpdateUser(User user)
        {
            _userDAO.UpdateUser(user);
        }

        public void DeleteUser(int userId)
        {
            _userDAO.DeleteUser(userId);
        }

        public IEnumerable<User> GetUserByKeyword(string keyword)
        {
            return _userDAO.GetUserByKeyword(keyword);
        }

        public Role GetUserRole(int userId)
        {
            return _userDAO.GetUserRole(userId);
        }
    }
}

