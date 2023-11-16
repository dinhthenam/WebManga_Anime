using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Repository
{
    public interface IChapterRepository
    {
        IEnumerable<Chapter> GetAllChapters();
        Chapter GetChapterById(int chapterId,int bookId);
        int InsertChapter(Chapter chapter);
        void UpdateChapter(Chapter chapter);
        void DeleteChapter(int chapterId);
        List<String> GetImage(int chapterId);
    }

}
