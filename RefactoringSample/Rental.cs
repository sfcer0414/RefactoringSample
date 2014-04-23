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

        public double getCharge()
        {    // 計算一筆租片費用
            double result = 0;
            switch (getMovie().getPriceCode())
            {
                case Movie.REGULAR:           // 普通片
                    result += 2;
                    if (getDaysRented() > 2)
                        result += (getDaysRented() - 2) * 1.5;
                    break;
                case Movie.NEW_RELEASE:               // 新片
                    result += getDaysRented() * 3;
                    break;
                case Movie.CHILDRENS:         // 兒童片
                    result += 1.5;
                    if (getDaysRented() > 3)
                        result += (getDaysRented() - 3) * 1.5;
                    break;
            }
            return result;
        }
    }
}
