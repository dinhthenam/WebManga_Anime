using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject.Models
{
    public class LeaderBoard
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int LeaderBoard_Id { get; set; }
        [Required]
        public int BookId { get; set; }
        public Book Book { get; set; }
        [Required]
        public int TotalRatings { get; set; }
        [Required]
        public int TotalReviews { get; set; }
        [Required]
        [Range(typeof(decimal), "1", "5")]
        public decimal AverageRating { get; set; }
    }
}
