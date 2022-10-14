using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehiclePurchaseSystem
{
    internal class CarManager : VehicleBase
    {
        public static void AddCars(Car c)
        {
            Car.LstCars.Add(c);
        }
        public static void GetInventory()
        {
            foreach (Car item in 
                Car.LstCars)
            {
                Console.WriteLine($"Car ID: {item.CarID} \n\t Make: {item.Make}, Model: {item.Model} " + $" Price: {item.CarPrice} ");
            }
        }
        //overriding
        public override void getCarInfo(uint nCarID)
        {
            int i = 0;
            bool b = false;
            for (i = 0; i < Car.LstCars.Count; i++)
            {
                if (nCarID== Car.LstCars[i].CarID)
                {
                    b = true;
                    break;
                }
            }
            if (b)
            {
                Console.WriteLine($"The Car Details are:\n\t Make: {Car.LstCars[i].Make}, Model: {Car.LstCars[i].Model}, Price: {Car.LstCars[i].CarPrice} ");
            }
            else
            {
                Console.WriteLine("Enter a Valid Car ID");
            }
        }

        public static void PurchaseCar(uint nCustomerID, uint nCarId)
        {
            int nCustomerIndex = -1;
            int nCarIndex = -1;
            for (int i = 0; i < Car.LstCars.Count; i++)
            {
                if (nCarId== Car.LstCars[i].CarID)
                {
                    nCarIndex = i;
                    break;
                }
            }
            for (int i = 0; i < Accounts.LstAccounts.Count; i++)
            {
                if (nCustomerID == Accounts.LstAccounts[i].CustomerID)
                {
                    nCustomerIndex = i;
                    break;
                }
            }
            if (nCustomerIndex == -1 || nCarIndex == -1)
            {
                Console.WriteLine("Enter Valid Customer ID" + " or Car ID");
            }
            else
            {
                if (Car.LstCars[nCarIndex].CarPrice< Accounts.LstAccounts[nCustomerIndex].Balance)
                {
                    Accounts.LstAccounts[nCustomerIndex].Balance -= Car.LstCars[nCarIndex].CarPrice;
                    Console.WriteLine($"Remaining balance for Customer ID:{Accounts.LstAccounts[nCustomerIndex].CustomerID}");
                }
                else
                {
                    Console.WriteLine("You have insufficient Balance");
                }
            }
        }
    }
}
