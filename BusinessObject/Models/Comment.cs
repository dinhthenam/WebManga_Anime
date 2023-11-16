using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject.Models
{
    public class Comment
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Comment_Id { get; set; }
        [Required]
        public int Book_id { get; set; }
        [Required]
        public int User_Id { get; set; }
        [Required]
        public string content { get; set; }
        [RegularExpression(@"^(0?[1-9]|[12][0-9]|3[01])/-[/-]\d{4}$")]
        private DateTime _createdDate = DateTime.Now;
        public DateTime CreatedDate
        {
            get
            {
              
                return _createdDate != null ? _createdDate : DateTime.Now;
            }
            set
            {
                _createdDate = value;
            }
        }
        public User? User { get; set; }
        public Book? Book { get; set; }
    }
}
