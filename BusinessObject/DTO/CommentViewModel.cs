using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject.DTO
{
    public class CommentViewModel
    {
        public int Comment_Id { get; set; }
        public int Book_id { get; set; }
        public int User_Id { get; set; }
        public string User_Name { get; set; }
        public string Content { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
