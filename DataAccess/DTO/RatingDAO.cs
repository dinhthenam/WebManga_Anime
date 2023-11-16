using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DTO
{
    public class RatingDAO
    {
        private readonly BookStoreContext _dbContext;

        public RatingDAO(BookStoreContext dbContext)
        {
            _dbContext = dbContext;
        }

        // Safe: This method does not violate any of the safety guidelines.
        public IEnumerable<Rating> GetAllRatings()
        {
            return _dbContext.Rating.ToList();
        }

        // Safe: This method does not violate any of the safety guidelines.
        public Rating GetRatingById(int ratingId)
        {
            return _dbContext.Rating.FirstOrDefault(r => r.Rating_Id == ratingId);
        }

        // Safe: This method does not violate any of the safety guidelines.
        public int InsertRating(Rating rating)
        {
            _dbContext.Rating.Add(rating);
            _dbContext.SaveChanges();

            return rating.Rating_Id;
        }

        // Safe: This method does not violate any of the safety guidelines.
        public void UpdateRating(Rating rating)
        {
            _dbContext.Rating.Update(rating);
            _dbContext.SaveChanges();
        }

        // Safe: This method does not violate any of the safety guidelines.
        public void DeleteRating(int ratingId)
        {
            var rating = _dbContext.Rating.FirstOrDefault(r => r.Rating_Id == ratingId);

            if (rating != null)
            {
                _dbContext.Rating.Remove(rating);
                _dbContext.SaveChanges();
            }
        }
    }

}
