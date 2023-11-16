using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject.Models
{
    public class Role
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Role_Id { get; set; }
        [Required]
        [RegularExpression(@"^[a-zA-Z]+$")]
        public string Role_Name { get; set; }
        public List<UserRole> UseRoles { get; set;}
    }
}
