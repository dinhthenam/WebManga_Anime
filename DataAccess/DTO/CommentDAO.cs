using BusinessObject.DTO;
using BusinessObject.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DTO
{
    public class CommentDAO
    {
        private readonly BookStoreContext _dbContext;

        public CommentDAO(BookStoreContext dbContext)
        {
            _dbContext = dbContext;
        }

        // Safe: This method does not violate any of the safety guidelines.
        public IEnumerable<Comment> GetAllComments()
        {
            return _dbContext.Comments.ToList();
        }

        // Safe: This method does not violate any of the safety guidelines.
        public Comment GetCommentById(int commentId)
        {
            return _dbContext.Comments.FirstOrDefault(c => c.Comment_Id == commentId);
        }
        public IEnumerable<CommentViewModel> GetCommentByBookId(int bookId)
        {
            var comments = _dbContext.Comments
        .Where(c => c.Book_id == bookId)
        .Include(c => c.User) 
        .ToList();

            
            var commentViewModels = comments.Select(c => new CommentViewModel
            {
                Comment_Id = c.Comment_Id,
                Book_id = c.Book_id,
                User_Id = c.User_Id,
                User_Name = c.User.User_Name, 
                Content = c.content,
                CreatedDate = c.CreatedDate,
                
            }).ToList();

            return commentViewModels ;
        }

        // Safe: This method does not violate any of the safety guidelines.
        public int InsertComment(Comment comment)
        {
            _dbContext.Comments.Add(comment);
            _dbContext.SaveChanges();

            return comment.Comment_Id;
        }
        public int InsertComment2(int userId, int bookId, string content)
        {
            var comment = new Comment
            {
                User_Id = userId,
                Book_id = bookId,
                content = content,
                CreatedDate = DateTime.Now 
            };

            _dbContext.Comments.Add(comment);
            _dbContext.SaveChanges();

            return comment.Comment_Id;
        }

        // Safe: This method does not violate any of the safety guidelines.
        public void UpdateComment(Comment comment)
        {
            _dbContext.Comments.Update(comment);
            _dbContext.SaveChanges();
        }

        // Safe: This method does not violate any of the safety guidelines.
        public void DeleteComment(int commentId)
        {
            var comment = _dbContext.Comments.FirstOrDefault(c => c.Comment_Id == commentId);

            if (comment != null)
            {
                _dbContext.Comments.Remove(comment);
                _dbContext.SaveChanges();
            }
        }
    }

}
