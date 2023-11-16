using BusinessObject.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DTO
{
    public class AuthorDAO
    {
        
        
            private readonly BookStoreContext _dbContext;

            public AuthorDAO(BookStoreContext dbContext)
            {
                _dbContext = dbContext;
            }

            public IEnumerable<Author> GetAllAuthors()
            {
                return _dbContext.Authors.ToList();
            }

            public Author GetAuthorById(int authorId)
            {
                return _dbContext.Authors.FirstOrDefault(a => a.Author_Id == authorId);
            }

            public int InsertAuthor(Author author)
            {
                _dbContext.Authors.Add(author);
                _dbContext.SaveChanges();

                return author.Author_Id;
            }

            public void UpdateAuthor(Author author)
            {
                _dbContext.Authors.Update(author);
                _dbContext.SaveChanges();
            }

            public void DeleteAuthor(int authorId)
            {
                var author = _dbContext.Authors.FirstOrDefault(a => a.Author_Id == authorId);

                if (author != null)
                {
                    _dbContext.Authors.Remove(author);
                    _dbContext.SaveChanges();
                }
            }
        }

    }

