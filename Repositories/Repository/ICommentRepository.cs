using BusinessObject.DTO;
using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Repository
{
    public interface ICommentRepository
    {
        IEnumerable<Comment> GetAllComments();
        Comment GetCommentById(int commentId);
        int InsertComment(Comment comment);
        void UpdateComment(Comment comment);
        void DeleteComment(int commentId);
        IEnumerable<CommentViewModel> GetCommentByBookId(int bookId);
        int InsertComment2(int userId,int BookId, string content);
    }

}
