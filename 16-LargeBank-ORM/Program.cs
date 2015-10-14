using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _16_LargeBank_ORM
{
    class Program
    {
        static string line = "_________________________________";
        static string space = "    ";
        static void Main(string[] args)
        {
            DisplayCustomerInfo();
            Console.WriteLine("Press enter to Exit");
            Console.ReadLine();
        }

        public static void DisplayCustomerInfo()
        {
            using (var db = new BigBankEntities())
            {
                //spits out information set in the query on the customers
                foreach (var customer in db.customers)
                {
                    Console.WriteLine("Customer Name: " + customer.FirstName + " " + customer.LastName);
                    Console.WriteLine("Accounts:");
                // Spits out information set in the query on the accounts
                    foreach (var account in customer.accounts)
                    {
                        Console.WriteLine(space + "#" + account.AccountNumber + " has $" + account.Balance.ToString());
                    }

                    Console.WriteLine("Total Balance $" + customer.accounts.Sum(a => a.Balance));
                    Console.WriteLine(line);
                }
            }
        }

    }
}
