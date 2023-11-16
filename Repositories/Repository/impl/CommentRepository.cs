using BusinessObject.DTO;
using BusinessObject.Models;
using DataAccess.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Repository
{
    public class CommentRepository : ICommentRepository
    {
        private readonly CommentDAO _commentDAO;

        public CommentRepository(CommentDAO commentDAO)
        {
            _commentDAO = commentDAO;
        }

        // Safe: This method does not violate any of the safety guidelines.
        public IEnumerable<Comment> GetAllComments()
        {
            return _commentDAO.GetAllComments();
        }

        // Safe: This method does not violate any of the safety guidelines.
        public Comment GetCommentById(int commentId)
        {
            return _commentDAO.GetCommentById(commentId);
        }

        // Safe: This method does not violate any of the safety guidelines.
        public int InsertComment(Comment comment)
        {
            return _commentDAO.InsertComment(comment);
        }
        

        // Safe: This method does not violate any of the safety guidelines.
        public void UpdateComment(Comment comment)
        {
            _commentDAO.UpdateComment(comment);
        }

        // Safe: This method does not violate any of the safety guidelines.
        public void DeleteComment(int commentId)
        {
            _commentDAO.DeleteComment(commentId);
        }

        public IEnumerable<CommentViewModel> GetCommentByBookId(int bookId)
        {
            return _commentDAO.GetCommentByBookId(bookId);
        }

        public int InsertComment2(int userId, int BookId, string content)
        {
            return _commentDAO.InsertComment2(userId,BookId,content);
        }
    }

}
