using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject.Models
{
    public class UserRole
    {
        [Key] public int User_Id { get; set; }
        [Key] public int Role_Id { get;set; }
        public User User { get; set; }
        public Role Role { get; set; }
    }
}
