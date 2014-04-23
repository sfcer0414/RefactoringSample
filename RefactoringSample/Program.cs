using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefactoringSample
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Refactoring, a First Example, step1");

            Movie m1 = new Movie("Seven", Movie.NEW_RELEASE);
            Movie m2 = new Movie("Terminator", Movie.REGULAR);
            Movie m3 = new Movie("Star Trek", Movie.CHILDRENS);

            Rental r1 = new Rental(m1, 4);
            Rental r2 = new Rental(m1, 2);
            Rental r3 = new Rental(m3, 7);
            Rental r4 = new Rental(m2, 5);
            Rental r5 = new Rental(m3, 3);

            Customer c1 = new Customer("老王");
            c1.addRental(r1);
            c1.addRental(r4);

            Customer c2 = new Customer("小黃");
            c2.addRental(r1);
            c2.addRental(r3);
            c2.addRental(r2);

            Customer c3 = new Customer("阿吳");
            c3.addRental(r3);
            c3.addRental(r5);

            Customer c4 = new Customer("小林");
            c4.addRental(r2);
            c4.addRental(r3);
            c4.addRental(r5);

            Console.WriteLine(c1.statement());
            Console.WriteLine(c2.statement());
            Console.WriteLine(c3.statement());
            Console.WriteLine(c4.statement());

            Console.Read();
        }
    }
}
