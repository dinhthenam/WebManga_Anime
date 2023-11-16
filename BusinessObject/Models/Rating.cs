using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject.Models
{
    public class Rating
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Rating_Id { get; set; }
        
        public int Book_Id { get; set; }

        public int User_Id { get; set; }
        [Required]
        [Range(typeof(int), "1", "5")]
        public int Rate { get; set; }
        [Required]
        public string Review { get; set; }
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
        public Book Book { get; set; }


    }
}
