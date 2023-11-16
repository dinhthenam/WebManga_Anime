using BusinessObject.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DTO
{
    public class ChapterDAO
    {
        private readonly BookStoreContext _dbContext;

        public ChapterDAO(BookStoreContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Chapter> GetAllChapters()
        {
            return _dbContext.Chapters.ToList();
        }

        public Chapter GetChapterById(int chapterId, int bookId)
        {
            return _dbContext.Chapters.FirstOrDefault(c => c.Chapter_Id == chapterId && c.Book_Id == bookId);
        }
        public List<string> GetImage(int chapterId)
        {
            string imageFolderPath = _dbContext.Chapters.Where(c => c.Chapter_Id == chapterId)
                                 .Select(c => c.Content)
                                 .FirstOrDefault();
            List<string> imagePaths = new List<string>();

            foreach (string imageFile in Directory.GetFiles(imageFolderPath))
            {
                int bookDirIndex = imageFile.IndexOf("WebBookStore");
                string relativePath = imageFile.Substring(bookDirIndex);

                // Ghép với "/images" 
                string newPath = "/images/" + relativePath;
                newPath = newPath.Replace('\\', '/');
                imagePaths.Add(newPath);
            }
            return imagePaths;
        }

        public int InsertChapter(Chapter chapter)
        {
            _dbContext.Chapters.Add(chapter);
            _dbContext.SaveChanges();

            return chapter.Chapter_Id;
        }

        public void UpdateChapter(Chapter chapter)
        {
            _dbContext.Chapters.Update(chapter);
            _dbContext.SaveChanges();
        }

        public void DeleteChapter(int chapterId)
        {
            var chapter = _dbContext.Chapters.FirstOrDefault(c => c.Chapter_Id == chapterId);

            if (chapter != null)
            {
                _dbContext.Chapters.Remove(chapter);
                _dbContext.SaveChanges();
            }
        }
    }

}
