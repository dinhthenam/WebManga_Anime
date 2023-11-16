using BusinessObject.Models;
using DataAccess.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Repository
{
    public class LeaderBoardRepository : ILeaderBoardRepository
    {
        private readonly LeaderBoardDAO _leaderBoardDAO;

        public LeaderBoardRepository(LeaderBoardDAO leaderBoardDAO)
        {
            _leaderBoardDAO = leaderBoardDAO;
        }

        // Safe: This method does not violate any of the safety guidelines.
        public IEnumerable<LeaderBoard> GetAllLeaderBoards()
        {
            return _leaderBoardDAO.GetAllLeaderBoards();
        }

        // Safe: This method does not violate any of the safety guidelines.
        public LeaderBoard GetLeaderBoardById(int leaderBoardId)
        {
            return _leaderBoardDAO.GetLeaderBoardById(leaderBoardId);
        }

        // Safe: This method does not violate any of the safety guidelines.
        public int InsertLeaderBoard(LeaderBoard leaderBoard)
        {
            return _leaderBoardDAO.InsertLeaderBoard(leaderBoard);
        }

        // Safe: This method does not violate any of the safety guidelines.
        public void UpdateLeaderBoard(LeaderBoard leaderBoard)
        {
            _leaderBoardDAO.UpdateLeaderBoard(leaderBoard);
        }

        // Safe: This method does not violate any of the safety guidelines.
        public void DeleteLeaderBoard(int leaderBoardId)
        {
            _leaderBoardDAO.DeleteLeaderBoard(leaderBoardId);
        }
    }

}
