using BusinessObject.Models;
using DataAccess.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Repository
{
    public class RatingRepository : IRatingRepository
    {
        private readonly RatingDAO _ratingDAO;

        public RatingRepository(RatingDAO ratingDAO)
        {
            _ratingDAO = ratingDAO;
        }

        // Safe: This method does not violate any of the safety guidelines.
        public IEnumerable<Rating> GetAllRatings()
        {
            return _ratingDAO.GetAllRatings();
        }

        // Safe: This method does not violate any of the safety guidelines.
        public Rating GetRatingById(int ratingId)
        {
            return _ratingDAO.GetRatingById(ratingId);
        }

        // Safe: This method does not violate any of the safety guidelines.
        public int InsertRating(Rating rating)
        {
            return _ratingDAO.InsertRating(rating);
        }

        // Safe: This method does not violate any of the safety guidelines.
        public void UpdateRating(Rating rating)
        {
            _ratingDAO.UpdateRating(rating);
        }

        // Safe: This method does not violate any of the safety guidelines.
        public void DeleteRating(int ratingId)
        {
            _ratingDAO.DeleteRating(ratingId);
        }
    }

}
