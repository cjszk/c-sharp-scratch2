using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ {
    class Program {
        static void Main(string[] args) {
            int[] numbers = {0,1,2,3,4,5,6};

            var evenNumQuery = from num in numbers
                               where (num % 2) == 0
                               select num;
            foreach(int i in evenNumQuery)
                Console.WriteLine("{0} is an even number", i);

            List<Customer> customers = new List<Customer>();
            customers.Add(new Customer("Alan", "80911291", "ABC Street", 25.60m));
            customers.Add(new Customer("Bill","19872131","DEF Street",-32.1m));
            customers.Add(new Customer("Carl","29812371","GHI Street",-12.2m));
            customers.Add(new Customer("David","78612312","JKL Street",12.6m));

            var overdue =
                from cust in customers
                where cust.balance < 0
                orderby cust.balance ascending
                select new { cust.name, cust.balance };

            foreach (var cust in overdue)
                Console.WriteLine("Name = {0}, Balance = {1}", cust.name, cust.balance);

            Console.Read();
        }
    }
    class Customer {
        public decimal balance;
        public string name;
        public string id;
        public string address;
        public Customer(string Name, string Id, string Address, decimal Balance) {
            id = Id;
            address = Address;
            balance = Balance;
            name = Name;
        }

    }
}
