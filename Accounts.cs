using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Http.Headers;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using VehiclePurchaseSystem;

namespace VehiclePurchaseSystem
{

    //seperated the class where that is handling the data and made a seperate class where processing has to be done. 
     public class Accounts 
    {
        private static List<Accounts> m_lstAccounts = DeSerializeXMLFileToList();
        //Property for private List
        public static List<Accounts> LstAccounts{
            get { return m_lstAccounts; }
            set { m_lstAccounts = value; } 
        }

        //member variables
        private uint m_customerID;
        private uint m_balance;
        private string m_customerName;



        //Properties for private variables
        public uint CustomerID
        {
            get { return m_customerID; }
            set { m_customerID = value; }
        }
        public uint Balance
        {
            get { return m_balance; }
            set { m_balance = value; }
        }
        //public string CustomerName
        //{
        //    get { return customerName; }
        //    set { customerName = value; }
        //}
        public string CustomerName
        {
            get { return m_customerName; }
            set { m_customerName = value; }
        }
        //Constructor
     /*
        public Accounts(uint nCustomerID, uint nBalance, string stCustomerName)
        {
            //accessing those priavte variables using getter and setter 
            CustomerID = nCustomerID;
            Balance = nBalance;
            CustomerName = stCustomerName;
        }
     */
        public static void SerializeListToXMLFile() {


            List<Accounts> lstAccount = new List<Accounts> {
            new Accounts{
                    CustomerID = 2,
                    Balance = 150205,
                    CustomerName = "Muhammad Moiz"
                },
                new Accounts{
                    CustomerID = 15,
                    Balance = 4000000,
                    CustomerName = "Ali"
                },
                new Accounts{
                    CustomerID = 40,
                    Balance = 1502444,
                    CustomerName = "Faizan"
                },
                new Accounts{
                    CustomerID = 1,
                    Balance = 12500,
                    CustomerName = "Imran"
                },
                new Accounts{
                    CustomerID = 3,
                    Balance = 20,
                    CustomerName = "Dieago"
                }
            };
            var xmlSerializer = new XmlSerializer(typeof(List<Accounts>));
            using (var writer = new StreamWriter(@"C:\Users\mmoiz\Desktop\Practice\XMLfolder\Accounts.xml")) {
                xmlSerializer.Serialize(writer, lstAccount);
            }
        }

        public static List<Accounts> DeSerializeXMLFileToList() {
            var xmlSerialize = new XmlSerializer(typeof(List<Accounts>));
            using (var reader = new StreamReader(@"C:\Users\mmoiz\Desktop\Practice\XMLfolder\Accounts.xml")) {
                var accounts = (List<Accounts>) xmlSerialize.Deserialize(reader);
                return accounts; 
            }
        }
    }
}

