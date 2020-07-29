using Microsoft.VisualBasic;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.ComTypes;
using System.Threading;

namespace Decagonbank
{
    class Program
    {
        static void Main(string[] args)
        {
            Login:
            BankClass bank = new BankClass();
            Console.WriteLine("Welcome to Decagon Bank");
            Console.WriteLine("Enter 1 to Login");
            Console.WriteLine("Enter 2 to Create new account");
            string data = Console.ReadLine();

            try
            {
                NumberValidate(data);
            }
            catch (Exception e)
            {

                Console.WriteLine("Invalid Number Entered");
                return;
            }

            if ( Int32.Parse(data) == 1)
            {

                Console.WriteLine("Please Enter Your Email");
                string email = Console.ReadLine();
                string email1 = email.Trim();


                Console.WriteLine("Please Enter Your Password");
                string password = Console.ReadLine();
                string password1 = password.Trim();

                try
                {

                    bank.login(email1, password1);
                }
                catch (Exception e)
                {

                    Console.WriteLine("Invalid user");

                }

                Customer user = bank.login(email1, password1);

                Registered_login:

                Console.WriteLine(" Welcome  " + user.Name);
                Console.WriteLine(" Account Number  " + user.Acctnumber);
                Console.WriteLine(" Account Balance  " + user.Balance);





                Console.WriteLine(" Enter 1 to Transfer");
                Console.WriteLine(" Enter 2 to  Deposit");
                Console.WriteLine(" Enter 3 to  Withdraw");
                Console.WriteLine(" Enter 4 to  logout");
               


                string number = Console.ReadLine();

                try
                {
                    Validate(number);
                    if (Int32.Parse(number) != 1 && Int32.Parse(number) != 2 && Int32.Parse(number) != 3 && Int32.Parse(number) != 4)
                    {


                        throw new ArgumentOutOfRangeException(" Invalid Number Entered ");
                    }





                }
                catch (Exception e)
                {
                    Console.WriteLine("Invalid Number Entered ");
                    return;
                }

                int Entervalue = Int32.Parse(number);

                switch (Entervalue)
                {
                    case 1:

                        Console.WriteLine(" Please Enter Account Number to Tranfer money to");
                        string numtrans = Console.ReadLine();

                        Console.WriteLine("Enter Amount to Transfer");
                        string trans_amt = Console.ReadLine();

                        try
                        {
                            Validate(trans_amt);
                        }
                        catch (Exception e)
                        {

                            Console.WriteLine("Invalid Account");
                            return;
                        }
                        int amt_trans = Int32.Parse(trans_amt);


                        Console.WriteLine("Enter Name of Recipent");
                        string trans_name = Console.ReadLine();




                        Console.WriteLine("Enter Transaction detail ");
                        string trans_note = Console.ReadLine();


                       

                        try
                        {
                            Validate(numtrans);
                        }
                        catch (Exception e)
                        {

                            Console.WriteLine("Invalid Account");
                        }

                        int intnum = Int32.Parse(numtrans);
                        try
                        {
                            bank.FindAccount(intnum);
                        }
                        catch (Exception)
                        {

                            Console.WriteLine("Account Not found !");
                        }
                      

                        BankClass chek = new BankClass();
                        

                        user.TransferCash(amt_trans, intnum, trans_note, trans_name, bank);

                        user.TransactionHistory();






                        Console.WriteLine("Enter 1 to return to Menu");
                        string valone = Console.ReadLine();

                        try
                        {
                            Validate(valone);
                            if (Int32.Parse(valone) != 1)
                            {

                                throw new ArgumentOutOfRangeException(" Invalid Number Entered ");
                            }

                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("Invalid Number Entered ");
                            return;
                        }


                        int val1 = Int32.Parse(valone);

                        if (val1 == 1)
                        {

                            goto Registered_login;
                        }

                        break;

                    case 2:

                        Console.WriteLine("Enter Amount To Deposit");
                        string amount = Console.ReadLine();
                        try
                        {
                            Validate(amount);
                        }
                        catch (Exception e)
                        {

                            Console.WriteLine("Invalid Amount");
                        }

                        int depositAmt = Int32.Parse(amount);
                        Console.WriteLine("Enter Deposit Detail");
                        string note = Console.ReadLine();

                        user.DepositCash(depositAmt, user.Acctnumber, note, user.Name );

                        Console.WriteLine("Transaction History");
                        user.TransactionHistory();


                        Console.WriteLine("Enter 1 to return to Menu");
                        string enterdigit = Console.ReadLine();

                        try
                        {
                            Validate(enterdigit);
                            if (Int32.Parse(enterdigit) != 1)
                            {

                                throw new ArgumentOutOfRangeException(" Invalid Number Entered ");
                            }

                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("Invalid Number Entered ");
                            return;
                        }


                        int valdigit = Int32.Parse(enterdigit);

                        if (valdigit == 1)
                        {

                            goto Registered_login;
                        }





                        break;
                    case 3:
                        Console.WriteLine("Enter Amount to Withdraw");
                        string withdrawAmt = Console.ReadLine();

                        Console.WriteLine("Enter Withdrawer Details");
                        string detail = Console.ReadLine();


                        try
                        {
                            Validate(withdrawAmt);
                        }
                        catch (Exception e)
                        {

                            Console.WriteLine("Invalid Amount");
                            return;
                        }

                        
                        try
                        {
                            user.WithdrawCash(Int32.Parse(withdrawAmt), detail);
                        }
                        catch (Exception e)
                        {

                            Console.WriteLine(e.Message);
                           
                           
                        }

                        user.TransactionHistory();

                        Console.WriteLine("Enter 1 to return to Menu");
                        string enterval = Console.ReadLine();

                        try
                        {
                            Validate(enterval);
                            if (Int32.Parse(enterval) != 1)
                            {

                                throw new ArgumentOutOfRangeException(" Invalid Number Entered ");
                            }

                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("Invalid Number Entered ");
                            return;
                        }


                        int val = Int32.Parse(enterval);

                        if (val == 1)
                        {

                            goto Registered_login;
                        }







                        break;
                    case 4:

                        goto Login;

                        break;



                    default:
                        break;
                }













            }
            else if(Int32.Parse(data) == 2)
            {

               
                Register:

                    Console.WriteLine(" Please Enter Your Email");
                    string email = Console.ReadLine().Trim();
                    

                    Console.WriteLine(" Please Enter Your FullName ");
                    string name = Console.ReadLine();

                    Console.WriteLine(" Please Enter Your Password");
                    string password = Console.ReadLine().Trim();

                    Console.WriteLine("Ënter 1 for Savings Account");
                    Console.WriteLine("Ënter 2 for Current Account");

                    string accttype = Console.ReadLine();
                    string acct = "";


                    try
                    {
                        NumberValidate(accttype);
                    }
                    catch (Exception e)
                    {

                        Console.WriteLine("Invalid Number Entered");
                        return;

                    }

                    if (Int32.Parse(accttype) == 1)
                    {

                        acct = "SAVINGS";
                    }


                    if (Int32.Parse(accttype) == 2)
                    {

                        acct = "CURRENT";
                    }

                    bank.AddCustomer(name, email, acct, password);

                    bank.GetAllAccount();



                    Console.WriteLine("Congrats New Account Created ");
                    Console.WriteLine("Enter 1 to Create Another Acount");
                    Console.WriteLine("Enter 2 to Quit Registration and Login");
                    string result = Console.ReadLine();

                    try
                    {

                        NumberValidate(result);

                    }
                    catch (Exception e)
                    {

                        Console.WriteLine("Invalid Input");
                    }

                   int  digit = Int32.Parse(result);

                    if (digit == 1)
                    {
                    goto Register;
                    }
                    if (digit == 2)
                    {
                    goto Login;
                    }

            }








        }

        //validate and check for number integer and particular entry command
        static void NumberValidate(string value)
        {


            if (!Int32.TryParse(value, out int a))
            {


                throw new ArgumentOutOfRangeException(" Invalid Number Entered");
              

            }

            int inTransact = Int32.Parse(value);

            if (inTransact != 1 && inTransact != 2)
            {


                throw new ArgumentOutOfRangeException(" Invalid Number Entered ");
            }



        }

        //validate and check for integer only
        static void Validate(string value)
        {

            if (!Int32.TryParse(value, out int a))
            {


                throw new ArgumentOutOfRangeException(" Invalid Number Entered");


            }

        }
    }
}
