using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject.Models
{
    public class Book
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)] 
        public int Book_Id { get; set; }
        [Required]
        [StringLength(255)]
        public string? Title { get; set; }
        [Required]
        [StringLength(255)]
        public string? Alte_Title { get; set; }
        [Required]
        public  string? Description { get; set; }
       
        public int? AuthorId { get; set; }
        public Author? Author { get; set; }
        
        public int? CategoryId { get; set; }
        [Required]
        public string CoverImage { get; set; }
        [Required]
        
        public int ViewCount { get; set; }
        public int status { get; set; }
        [RegularExpression(@"^(0?[1-9]|[12][0-9]|3[01])/-[/-]\d{4}$")]
        private DateTime _createdDate;
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
        public int Rating_id { get; set; }
        public int? IsTrending { get; set; }
        public Category? Category { get; set; }

        public List<Rating>? Ratings { get; set; }
        public List<UserBook>? UserBook { get; set; }

        public List<Comment>? Comments { get; set; }

        public List<Chapter>? Chapters { get; set; }
        public LeaderBoard? Leaderboards { get; set; }
    }
}
