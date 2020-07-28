using System;
using System.Collections.Generic;
using System.Text;

namespace Decagonbank
{
    class BankClass
    {


        
            private List<Customer> allAccounts = new List<Customer>();

            public void AddAccount(Customer account)
            {

                allAccounts.Add(account);

            }

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

            public void  AddCustomer(string name, string email, string type, string password) {


            Customer cus = new Customer(name, email, type, password);
             AddAccount(cus);


            }

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
        }
}
