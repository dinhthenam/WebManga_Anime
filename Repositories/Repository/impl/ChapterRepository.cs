using BusinessObject.Models;
using DataAccess.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Repository
{
    public class ChapterRepository : IChapterRepository
    {
        private readonly ChapterDAO _chapterDAO;

        public ChapterRepository(ChapterDAO chapterDAO)
        {
            _chapterDAO = chapterDAO;
        }

        public IEnumerable<Chapter> GetAllChapters()
        {
            return _chapterDAO.GetAllChapters();
        }

        public Chapter GetChapterById(int chapterId, int bookId)
        {
            return _chapterDAO.GetChapterById(chapterId,bookId);
        }

        public int InsertChapter(Chapter chapter)
        {
            return _chapterDAO.InsertChapter(chapter);
        }

        public void UpdateChapter(Chapter chapter)
        {
            _chapterDAO.UpdateChapter(chapter);
        }

        public void DeleteChapter(int chapterId)
        {
            _chapterDAO.DeleteChapter(chapterId);
        }

        public List<string> GetImage(int chapterId)
        {
         return _chapterDAO.GetImage(chapterId);
        }
    }

}
