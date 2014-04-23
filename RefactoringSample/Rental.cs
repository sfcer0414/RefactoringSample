using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefactoringSample
{
    public class Rental
    {
        /// <summary>
        /// 影片
        /// </summary>
        private Movie _movie;
        /// <summary>
        /// 租期
        /// </summary>
        private int _daysRented;

        public Rental(Movie movie, int daysRented)
        {
            _movie = movie;
            _daysRented = daysRented;
        }

        public int getDaysRented()
        {
            return _daysRented;
        }

        public Movie getMovie()
        {
            return _movie;
        }
    }
}
