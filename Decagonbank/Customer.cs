using System;
using System.Collections.Generic;
using System.Text;

namespace Decagonbank
{
    class Customer
    {
        public int Id { get; set; }
        public int Acctnumber { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Type { get; set; }
        public string Opendate { get; set; }
        public  decimal Balance { 
            get {

                balance = 0;

                foreach (TransactionClass transact in allTransaction)
                {

                    balance = balance + transact.Amount;

                }

                return balance;

            } 
        }
        private decimal balance;

        private List<TransactionClass> allTransaction = new List<TransactionClass>();


        public Customer(string name, string email, string type, string password)
        {

            Random ranNum = new Random();
            this.Acctnumber = ranNum.Next(100, 500);
            this.Id = ranNum.Next(1, 100);
            this.Name = name;
            this.Email = email;
            this.Type = type;
            this.Password = password;
            //string note = "Initial Deposit";
            this.Opendate = DateTime.Now.ToString("MM/dd/yyyy");



            //DepositCash(cash, Acctnumber, note, Name);

           
           



        }




        public void DepositCash(decimal amount, int acctnum, string note, string name)
        {
            if (amount < 0)
            {

                throw new ArgumentOutOfRangeException(" Invalid amount ");

            }

            string date = DateTime.Now.ToString("MM/dd/yyyy");
            string type = "CREDIT";
            decimal cashBalance = Balance + amount;

            TransactionClass credit = new TransactionClass(amount, this.Acctnumber, note, date, name, type, cashBalance);
            allTransaction.Add(credit);



        }

        public void WithdrawCash(decimal amount, string note)
        {

            CheckAccount(amount);



            string date = DateTime.Now.ToString("MM/dd/yyyy");
            string type = "DEBIT";
            decimal cashBalance = Balance - amount;
            int acctNumber = this.Acctnumber;

            TransactionClass debit = new TransactionClass(-amount, acctNumber, note, date, this.Name, type, cashBalance);
            allTransaction.Add(debit);



        }

        public void TransferCash(decimal amount, int acctNumber, string note, string name, BankClass account)
        {
            CheckAccount(amount);

           
        Customer Acct = account.FindAccount(acctNumber);
            Acct.DepositCash(amount,this.Acctnumber, note,name);
            WithdrawCash(amount,note);


        }

        public void TransactionHistory()
        {
            Console.WriteLine($"Transaction   Amount  Acount       Name          Balance       Note      Date");
            foreach (TransactionClass transact in allTransaction)
            {


             
      Console.WriteLine($"{transact.Type, 10}{transact.Amount,8}{transact.Acctnumber,10}{transact.Name,12}{transact.TranBalance,15}{transact.Note, 15}{transact.Date,15}");

            }


        }


        public void CheckAccount(decimal value)
        {
            if (value < 1)
            {
                throw new ArgumentOutOfRangeException(" Invalid Amount ");
            }

            if (this.Type == "SAVING" && this.Balance - value < 100)
            {

                throw new ArgumentOutOfRangeException(" Account Minimum Balance should be 1000 ");

            }


            if (this.Type == "CURRENT" && this.Balance - value < 1000)
            {

                throw new ArgumentOutOfRangeException(" Account Minimum Balance should be 100 ");

            }


        }



    }
}
