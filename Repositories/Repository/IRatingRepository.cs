using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Repository
{
    public interface IRatingRepository
    {
        IEnumerable<Rating> GetAllRatings();
        Rating GetRatingById(int ratingId);
        int InsertRating(Rating rating);
        void UpdateRating(Rating rating);
        void DeleteRating(int ratingId);
    }

}
