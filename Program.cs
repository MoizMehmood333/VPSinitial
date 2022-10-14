// See https://aka.ms/new-console-template for more information
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.ConstrainedExecution;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using ViechlePurchaseSystem;
using ViechlePurchaseSystem.CacheLayer;

namespace VehiclePurchaseSystem
{
    public class PurchaseOfficer
    {

        enum CarSelection
        {
            Honda = 1,
            Toyota = 2,
            Suzuki = 3,
            BMW = 4,
            Mercedes = 5,
            AstonMartin = 6,
            Porsche = 7
        }

        public static void Main(string[] args)
        {
            Cache cacheObject = Cache.GetCache();
            cacheObject.DeSerializeXMLFiles();
            Console.WriteLine("Hello World");
            /*

            Accounts.SerializeListToXMLFile();
            Car.SerializeListToXMLFile();
            
            int nCont = 0;
            int nOption = 0;
            do
            {
                try
                {




                    Console.WriteLine($"Choose an Option: \n" +
                        $"1: Want to Check Accounts? \n" +
                        $"2: Want to Check Details of an account using User ID? \n" +
                        $"3: Want to check how many customers with same name do we have? \n" +
                        $"4: Want to Check car Inventory? \n" +
                        $"5: Want to Purchase the car? \n" +
                        $"6: Want to check usage of Enums? ");
                    nOption = Convert.ToInt32(Console.ReadLine());
                    if (nOption > 0 && nOption < 8)
                    {
                        switch (nOption)
                        {
                            case 1:
                                {
                                    Console.WriteLine("\n\nEnter the Admin Password to  check the account details.\n");
                                    int nPass = 12345;
                                    int nInput = Convert.ToInt32(Console.ReadLine());
                                    if (nInput == nPass) {
                                        AccountManager.GetAccounts();
                                    }
                                    else {
                                        Console.WriteLine("You are not authorized to check the account details. \n");
                                    }
                                    
                                    Console.WriteLine("Do you still want to continue? 0 for No, 1 for yes");
                                    nCont = Convert.ToInt32(Console.ReadLine());
                                    Console.Clear();
                                    break;
                                }
                            case 2:
                                {
                                    
                                    Console.WriteLine("Enter User ID: ");
                                    uint nID = Convert.ToUInt32(Console.ReadLine());
                                    AccountManager.GetAccountDetails(nID);

                                    Console.WriteLine("Do you still want to continue? 0 for No, 1 for yes");
                                    nCont = Convert.ToInt32(Console.ReadLine());
                                    Console.Clear();

                                    break;
                                }
                            case 3:
                                {
                                    Console.WriteLine("Enter Customer ID / Customer Name : ");
                                    var nID = Console.ReadLine();
                                    AccountManager.GetAccountDetails(nID);
                                    Console.WriteLine("Do you still want to continue? 0 for No, 1 for yes");
                                    nCont = Convert.ToInt32(Console.ReadLine());
                                    Console.Clear();



                                    break;
                                }
                            case 4:
                                {
                                    CarManager.GetInventory();
                                    Console.WriteLine("Do you still want to continue? 0 for No, 1 for yes");
                                    nCont = Convert.ToInt32(Console.ReadLine());
                                    Console.Clear();

                                    break;
                                }
                            case 5:
                                {

                                    Console.WriteLine("Enter Customer ID who is purchasing the car: ");
                                    uint nCustomerId = Convert.ToUInt32(Console.ReadLine());

                                    Console.WriteLine("Enter Car ID that the customer wants to purchase: ");
                                    uint nCarId = Convert.ToUInt32(Console.ReadLine());
                                    CarManager.PurchaseCar(nCustomerId, nCarId);
                                    Console.WriteLine("Do you still want to continue? 0 for No, 1 for yes");
                                    nCont = Convert.ToInt32(Console.ReadLine());
                                    Console.Clear();

                                    break;
                                }
                            case 6:
                                {
                                    Console.WriteLine("Which Manufacturer Cars are you looking for? Enter the number which you select");
                                    Console.WriteLine("1 for Honda \n" +
                                        "2 for Toyota\n" +
                                        "3 for Suzuki\n" +
                                        "4 for BMW \n " +
                                        "5 for Mercedes \n" +
                                        "6 for Aston Martin\n" +
                                        "7 for Porsche");
                                    int nOptEnum = Convert.ToInt32(Console.ReadLine());
                                    string carSelected = "";
                                    if (nOptEnum > 0 && nOptEnum <8) {

                                        switch (nOptEnum)
                                        {
                                            case 1:
                                                carSelected = CarSelection.Honda.ToString();
                                                break;
                                            case 2:
                                                carSelected = CarSelection.Toyota.ToString();
                                                break;
                                            case 3:
                                                carSelected = CarSelection.Suzuki.ToString();
                                                break;
                                            case 4:
                                                carSelected = CarSelection.BMW.ToString();
                                                break;
                                            case 5:
                                                carSelected = CarSelection.Mercedes.ToString();
                                                break;
                                            case 6:
                                                carSelected = CarSelection.AstonMartin.ToString();
                                                break;
                                            case 7:
                                                carSelected = CarSelection.Porsche.ToString();
                                                break;
                                        }
                                        foreach (Car car in Car.LstCars)
                                        {
                                            if (carSelected.ToLower().Equals(car.Make.ToLower()))
                                            {
                                                Console.WriteLine($"Car ID: {car.CarID}, Car Make: {car.Make}, Car Model: {car.Model}, Car Price: {car.CarPrice}");

                                            }
                                        }
                                    }
                                    else {
                                        Console.WriteLine("Enter a Right Option!!");
                                    }

                                    

                                    Console.WriteLine("Do you still want to continue? 0 for No, 1 for yes");
                                    nCont = Convert.ToInt32(Console.ReadLine());
                                    Console.Clear();

                                    break;
                                }

                            case 7:
                                {
                                    Console.WriteLine(Convert.ToInt32(CarSelection.Honda));
                                    Console.WriteLine(Convert.ToInt32(CarSelection.Honda));
                                    Console.WriteLine("Do you still want to continue? 0 for No, 1 for yes");
                                    nCont = Convert.ToInt32(Console.ReadLine());
                                    Console.Clear();

                                    break;
                                }


                        }
                    } 
                    else
                    {
                        Console.WriteLine("Choose a correct option");
                        Console.WriteLine("Do you still want to continue? 0 for No, 1 for yes");
                        nCont = Convert.ToInt32(Console.ReadLine());
                        Console.Clear();

                    }

                }
                catch (Exception e)
                {
                    Console.WriteLine("An error occured!");
                    Console.WriteLine("Please Enter a valid input !! \n");

                    Console.WriteLine("Do you still want to continue? 0 for No, 1 for yes");
                    nCont = Convert.ToInt32(Console.ReadLine());
                
                }
            } while (nCont == 1);
            */
        }

    }
}
