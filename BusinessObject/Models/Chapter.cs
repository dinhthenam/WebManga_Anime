using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject.Models
{
    public class Chapter
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)] 
        public int Chapter_Id { get; set; }
        [Required] 
        public int Book_Id { get; set; }

        [Required]
        [RegularExpression(@"^[0-9]*$")]
        public int ChapterNumber { get; set; }
        [Required]
        [StringLength(50)]
        [RegularExpression(@"^[a-zA-Zàáạảãâầấậẩẫăằắặẳẵèéẹẻẽêềếệểễìíịỉĩòóọỏõôồốộổỗơờớợởỡùúụủũưừứựửữỳýỵỷỹđ]+$")]
        public string Title { get; set; }
        [Required]
        public string Content { get; set; }

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
