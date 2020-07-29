using System;
using System.Collections.Generic;
using System.Text;
using System.Transactions;

namespace Decagonbank
{
    class TransactionClass
    {

        public int Acctnumber { get; set; }
        public string Note { get; set; }
        public string Date { get; set; }
        public string Name { get; set; }
        public  string Type { get; set; }
        public decimal Amount { get; set; }
        public decimal TranBalance { get; set; }

        //Transaction 
        public TransactionClass(decimal amount , int acctNum, string note, string date , string name, string type, decimal balance )
        {
            this.Acctnumber = acctNum;
            this.Note = note;
            this.Date = date;
            this.Name = name;
            this.Type = type;
            this.Amount = amount;
            this.TranBalance = balance;

            
        }
    }
}
