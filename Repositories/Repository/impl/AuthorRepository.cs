using BusinessObject.Models;
using DataAccess.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Repository
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly AuthorDAO _authorDAO;

        public AuthorRepository(AuthorDAO authorDAO)
        {
            _authorDAO = authorDAO;
        }

        public IEnumerable<Author> GetAllAuthors()
        {
            return _authorDAO.GetAllAuthors();
        }

        public Author GetAuthorById(int authorId)
        {
            return _authorDAO.GetAuthorById(authorId);
        }

        public int InsertAuthor(Author author)
        {
            return _authorDAO.InsertAuthor(author);
        }

        public void UpdateAuthor(Author author)
        {
            _authorDAO.UpdateAuthor(author);
        }

        public void DeleteAuthor(int authorId)
        {
            _authorDAO.DeleteAuthor(authorId);
        }
    }

}
