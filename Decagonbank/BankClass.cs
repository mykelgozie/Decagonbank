using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Decagonbank
{
    class BankClass
    {


            //List contains all customer accounts 
            private List<Customer> allAccounts = new List<Customer>();


            //add new Customer 
            public void AddAccount(Customer account)
            {

                allAccounts.Add(account);

            }

            //Process customer login
            public Customer login(string email, string password)
            {

                Customer loginAcct = null;

                foreach (var account in allAccounts)
                {

                    if (account.Email == email && account.Password == password)
                    {

                        loginAcct = account;

                    }


                }

                if (loginAcct == null)
                {


                    throw new ArgumentOutOfRangeException(" Invalid Account ");




                }
                else
                {

                    return loginAcct;
                }


            }

            
             //add new Customer 
            public void  AddCustomer(string name, string email, string type, string password) {


            Customer cus = new Customer(name, email, type, password);
             AddAccount(cus);


            }

            //find  a particular account and return account if found
            public Customer FindAccount(int accountnum )
            {

            Customer data = null;

            foreach (var item in allAccounts)
            {
                if (item.Acctnumber == accountnum)
                {

                    data = item;

                }

            }


            if (data == null)
            {

                throw new ArgumentOutOfRangeException(" Invalid Account ");


            }
            else
            {

                return data;

            }

            }

            //get all registered account
            public void GetAllAccount()
            {

            Console.WriteLine("Accounts Currently Created");

                    foreach (var item in allAccounts)
                    {

                Console.WriteLine( item.Name + " " + item.Acctnumber );



                    }


            }



        }
}
