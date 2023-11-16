using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject.Models
{
    public class User
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int User_Id { get; set; }
        [Required]
        public string User_Name { get; set;}
        [Required]
        [RegularExpression(@"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+.[a-zA-Z0-9-.]+$")]
        public string User_Email { get; set;}
        [Required]
        public string User_Password { get; set;}
        [Required]
        [RegularExpression(@"^[0-9]*$")]
        public int User_Phone { get; set;}
        [Required]
        [Range(typeof(int), "0", "100")]
        public int User_age { get; set; }
        public string? User_Description { get; set; }
        [RegularExpression(@"^(0?[1-9]|[12][0-9]|3[01])/-[/-]\d{4}$")]
        private DateTime _createdDate = DateTime.Now;
        public DateTime CreatedDate
        {
            get
            {
                // Trả về giá trị backing field nếu nó khác null
                return _createdDate != null ? _createdDate : DateTime.Now;
            }
            set
            {
                // Gán giá trị vào backing field
                _createdDate = value;
            }
        }
        public List<UserBook>? UserBooks { get; set; }
        public List<Comment>? Comments { get; set; }
        public List<UserRole>? UseRoles { get; set; }
        public int Status { get; set; }

    }
}
