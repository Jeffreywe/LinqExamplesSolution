using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqExamples {
    /// <summary>
    /// This class is an example of Linq, the numbers variable is an array
    /// </summary>
    class Program {
        static void Main(string[] args) {

            int[] ints = new int[] {
            869,842,861,672,757,144,397,110,109,111,
            104,348,551,624,141,887,792,395,281,737,
            612,740,574,313,672,404,523,507,843,164,
            233,115,338,905,378,761,169,666,354,453,
            501,469,406,948,417,149,909,334,321,645,
            370,933,483,770,681,631,108,151,726,876,
            869,464,827,678,240,971,903,709,380,246,
            733,915,503,474,445,866,152,447,560,387,
            726,314,477,523,483,452,250,966,677,442,
            841,278,406,787,710,769,570,145,555,774
        };


            List<Customer> customers = new List<Customer>() { // creates an array, or list, both the same
                new Customer() { Id = 1, Name = "MAX", Sales = 1000 },
                new Customer() { Id = 2, Name = "PG", Sales = 1000000 },
                new Customer() { Id = 3, Name = "Microsoft", Sales = 500000 },
                new Customer() { Id = 4, Name = "Amazon", Sales = 10000000 },
                new Customer() { Id = 5, Name = "Google", Sales = 5004000 },
            };

            List<Order> orders = new List<Order>() {
                new Order() { Id = 1, Description = "1st order",
                                Total = 1000, CustomerId = 2 },
                new Order() { Id = 2, Description = "2nd order",
                                Total = 2000, CustomerId = 5 },
                new Order() { Id = 3, Description = "3rd order",
                                Total = 3000, CustomerId = 1 }
            };

            var customerOrders = from o in orders
                                 join c in customers // joins orders to customers, not customers to orders
                                 on o.CustomerId equals c.Id // when joining tables and column id you join with equals not the sign
                                 orderby o.Total descending
                                 select new {
                                     o.Id, o.Description, 
                                     Amount = o.Total, // aliases as amount instead of total
                                     Customer = c.Name
                                 };
            foreach(var co in customerOrders) {
            Console.WriteLine($"{co.Id,-5}{co.Description,-30}" + // goes thru and returns the 4 columns
                $"{co.Amount,7:c}{co.Customer,25}");
            }


            var orderedCustomers = from c in customers // creates variable oC and creates c variable from customers
                                   orderby c.Sales descending // orders by c.Sales in descending
                                   select new { // selects new {} columns we want
                                       c.Name, c.Sales
                                   };
            foreach(var c in orderedCustomers) { // goes thru each in orderCus and gets ready for console.writeline
                Console.WriteLine($"{c.Name,-15} {c.Sales,15:c}"); // gets values of c variable and stores in console.writeline, ,-15,15 makes values returned spreadout
            }


            // numbers is an array
            int[] numbers = { 23, 28, 225, 35, 500, 22, 15,
                                -63, 7, 88, 53, -1, 12, 17 };

            int total = numbers.Sum(); // gets sum of numbers array
            //Console.WriteLine($"Total is {numbers.Sum()}"); // another way to write the line above


            var qnbrs = from n in numbers
                        where n < 200
                        orderby n
                        select n;


            int[] numLT200 = numbers
                                .Where(t => t < 200)
                                .ToArray();


            int[] numGT50LT100 = numbers
                                .Where(up => up > 50 &&  up < 100) // .Where greater than &&(and) less than
                                .ToArray();


            // example of the .Where clause that does the same thing as foreach statement below, less code, the .ToArray turns the numbers into another array
            int[] numbers2 = numbers
                                .Where(n => n % 2 == 1) // sets condition of array values to be fetched
                                .OrderByDescending(x => x) // orders fetched values from array
                                .ToArray(); // converts numbers to new array
            foreach(int n1 in numbers2) { // goes thru array of numbers and places them in n1
            Console.Write($"{n1} "); // returns n1 values stored inside
            }
            // adds odd numbers to total variable
            int total1 = 0;
            foreach(int n in numbers) {
                if(n % 2 == 1) {
                    total1 += n;
                    Console.Write($"{n} ");
                    // Console.Write shows each odd number in a space
                }
            }
                // prints total odd numbers, has to be outside of the foreach scope
                Console.WriteLine(total);                
        }
    }
}
