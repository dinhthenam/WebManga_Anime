using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DTO
{
    public class AuthorService
    {
        
        
            public bool IsUserInRole(User user, string role)
            {
                return user.UseRoles.Any(ur => ur.Role.Role_Name == role);
            }
        
    }
}
