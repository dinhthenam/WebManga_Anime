using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Repository
{
    public interface ILeaderBoardRepository
    {
        IEnumerable<LeaderBoard> GetAllLeaderBoards();
        LeaderBoard GetLeaderBoardById(int leaderBoardId);
        int InsertLeaderBoard(LeaderBoard leaderBoard);
        void UpdateLeaderBoard(LeaderBoard leaderBoard);
        void DeleteLeaderBoard(int leaderBoardId);
    }

}
