using BusinessObject.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DTO
{
    public class UserDAO
    {
        private readonly BookStoreContext _dbContext;

        public UserDAO(BookStoreContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<User> GetAllUsers()
        {
            return _dbContext.Users.ToList();
        }

        public User GetUserById(int userId)
        {
            return _dbContext.Users.FirstOrDefault(u => u.User_Id == userId);
        }

        public int InsertUser(User user)
        {
            if (_dbContext.Users.Any(u => u.User_Email == user.User_Email))
            { 
                throw new InvalidOperationException("Email must be unique.");
            }
            user.User_Id = 0;
            _dbContext.Users.Add(user);
            _dbContext.SaveChanges();

            return user.User_Id;
        }

        public void UpdateUser(User user)
        {
            _dbContext.Users.Update(user);
            _dbContext.SaveChanges();
        }

        public void DeleteUser(int userId)
        {
            var user = _dbContext.Users.FirstOrDefault(u => u.User_Id == userId);

            if (user != null)
            {
                _dbContext.Users.Remove(user);
                _dbContext.SaveChanges();
            }
        }
        public IEnumerable<User> GetUserByKeyword(string keyword) 
        {
            var users = _dbContext.Users.AsQueryable();

            if (!string.IsNullOrWhiteSpace(keyword))
            {
                users = users.Where(x => x.User_Name.Contains(keyword)
                                   || x.User_Email.Contains(keyword)
                                   || x.User_Description.Contains(keyword));
            }
            if (users == null)
                return null;
            return users.ToList();
        }
        public Role GetUserRole(int userId)
        {
            return _dbContext.UserRoles
                          .Where(ur => ur.User_Id == userId)
                          .Select(ur => ur.Role)
                          .FirstOrDefault();
        }
    }

}