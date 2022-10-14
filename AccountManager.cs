using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using VehiclePurchaseSystem;


namespace VehiclePurchaseSystem
{
    //the class where Accounts data will be processed. 
    internal class AccountManager : IAccounts
    {
           

            public static void GetAccounts()
            {
                 
                foreach (Accounts account in Accounts.LstAccounts)
                {
                    Console.WriteLine($"Account ID: {account.CustomerID}\n\tCustomer Name: {account.CustomerName}, Account Balance:{account.Balance}");
                }
            }


            public static void CheckAccountBalance(uint nUserId)
            {
                for (int i = 0; i < Accounts.LstAccounts.Count; i++)
                {
                    if (nUserId== Accounts.LstAccounts[i].CustomerID)
                    {
                        Console.WriteLine($"Your Account Balance is: {Accounts.LstAccounts[i].Balance}");
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Enter a Valid User ID");
                    }
                }
            }

            public static void GetAccountDetails(uint nUserId)
            {
                bool bCheck = false;
                int nIndex = -1;
                    for (int i = 0; i < Accounts.LstAccounts.Count; i++)
                     {
                        if (nUserId == Accounts.LstAccounts[i].CustomerID)
                        {
                            nIndex = i;
                            bCheck= true;
                    
                            break;
                         }
                        else
                        {
                            bCheck= false;
                        }
                    }
                if (bCheck) {
                    Console.WriteLine($"Account ID: {Accounts.LstAccounts[nIndex].CustomerID}\n\t" +
                        $" Account Holder Name: {Accounts.LstAccounts[nIndex].CustomerName}, Balance: {Accounts.LstAccounts[nIndex].Balance}");
                }
                else {
                    Console.WriteLine("Enter a Valid User ID");
                }   
            }


            //method overloading
            public static void GetAccountDetails(string stUserName)
            {
            bool bCheck = false;
            int nIndex = -1;
            for (int i = 0; i < Accounts.LstAccounts.Count; i++)
                {
                    stUserName = stUserName.ToLower();
                    if (stUserName.Equals(Accounts.LstAccounts[i].CustomerName.ToLower()))
                    {
                    bCheck = false;
                    nIndex = i;
                        break;
                    }
                    else
                    {
                    bCheck = false;
                    }
                }
            if (bCheck)
            {
                Console.WriteLine($"Account ID: {Accounts.LstAccounts[nIndex].CustomerID}\n\t" +
                    $" Account Holder Name: {Accounts.LstAccounts[nIndex].CustomerName}, Balance: {Accounts.LstAccounts[nIndex].Balance}");
            }
            else
            {
                Console.WriteLine("Enter a Valid User ID");
            }
        }

            //adds account to the list
            public void AddAccount(Accounts a)
            {
                Accounts.LstAccounts.Add(a);
            }
            //overriding
            public void GetAccountName(uint nUserId)
            {
            }


        }
       
    }


