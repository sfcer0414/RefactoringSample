using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefactoringSample
{
    public class Customer
    {
        private string _name;                                 // 姓名
        private List<Rental> _rentals = new List<Rental>();               // 租借記錄

        public Customer(string name)
        {
            _name = name;
        }

        public void addRental(Rental arg)
        {
            _rentals.Add(arg);
        }

        public string getName()
        {
            return _name;
        }

        public string statement()
        {
            double totalAmount = 0;                     // 總消費金額
            int frequentRenterPoints = 0;       // 常客積點
            var rentals = _rentals.GetEnumerator();
            string result = "Rental Record for " + getName() + "\n";

            while (rentals.MoveNext())
            {
                double thisAmount = 0;
                Rental each = (Rental)rentals.Current; // 取得一筆租借記錄

                thisAmount = amountFor(each);        // 計算一筆租片費用                

                // add frequent renter points（累加 常客積點）
                frequentRenterPoints++;
                // add bonus for a two day new release rental
                if ((each.getMovie().getPriceCode() == Movie.NEW_RELEASE) &&
                   each.getDaysRented() > 1)
                    frequentRenterPoints++;

                // show figures for this rental（顯示此筆租借資料）
                result += "\t" + each.getMovie().getTitle() + "\t" +
                    thisAmount.ToString() + "\n";
                totalAmount += thisAmount;

            }

            // add footer lines（結尾列印）
            result += "Amount owed is " + totalAmount.ToString() + "\n";
            result += "You earned " + frequentRenterPoints.ToString() +
                    " frequent renter points";
            return result;
        }

        private double amountFor(Rental aRental)
        {    // 計算一筆租片費用
            double result = 0;
            switch (aRental.getMovie().getPriceCode())
            {
                case Movie.REGULAR:           // 普通片
                    result += 2;
                    if (aRental.getDaysRented() > 2)
                        result += (aRental.getDaysRented() - 2) * 1.5;
                    break;
                case Movie.NEW_RELEASE:               // 新片
                    result += aRental.getDaysRented() * 3;
                    break;
                case Movie.CHILDRENS:         // 兒童片
                    result += 1.5;
                    if (aRental.getDaysRented() > 3)
                        result += (aRental.getDaysRented() - 3) * 1.5;
                    break;
            }
            return result;
        }
    }
}
