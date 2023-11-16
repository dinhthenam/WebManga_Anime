using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DTO
{
    public class LeaderBoardDAO
    {
        private readonly BookStoreContext _dbContext;

        public LeaderBoardDAO(BookStoreContext dbContext)
        {
            _dbContext = dbContext;
        }

        // Safe: This method does not violate any of the safety guidelines.
        public IEnumerable<LeaderBoard> GetAllLeaderBoards()
        {
            return _dbContext.Leaders.ToList();
        }

        // Safe: This method does not violate any of the safety guidelines.
        public LeaderBoard GetLeaderBoardById(int leaderBoardId)
        {
            return _dbContext.Leaders.FirstOrDefault(l => l.LeaderBoard_Id == leaderBoardId);
        }

        // Safe: This method does not violate any of the safety guidelines.
        public int InsertLeaderBoard(LeaderBoard leaderBoard)
        {
            _dbContext.Leaders.Add(leaderBoard);
            _dbContext.SaveChanges();

            return leaderBoard.LeaderBoard_Id;
        }

        // Safe: This method does not violate any of the safety guidelines.
        public void UpdateLeaderBoard(LeaderBoard leaderBoard)
        {
            _dbContext.Leaders.Update(leaderBoard);
            _dbContext.SaveChanges();
        }

        // Safe: This method does not violate any of the safety guidelines.
        public void DeleteLeaderBoard(int leaderBoardId)
        {
            var leaderBoard = _dbContext.Leaders.FirstOrDefault(l => l.LeaderBoard_Id == leaderBoardId);

            if (leaderBoard != null)
            {
                _dbContext.Leaders.Remove(leaderBoard);
                _dbContext.SaveChanges();
            }
        }
    }

}
