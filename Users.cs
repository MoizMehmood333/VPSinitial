using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using VehiclePurchaseSystem;
using ViechlePurchaseSystem.CacheLayer;

namespace ViechlePurchaseSystem
{
    public class Users
    {
        public static Cache cacheInstance = Cache.GetCache();

        private uint m_userId;
        private string m_userPassword;

        public uint UserId { get { return m_userId; } set { m_userId = value; } }
        public string UserPassword {get { return m_userPassword; } set { m_userPassword = value; } }
        private static bool m_loginStatus = false;
        public static bool LoginStatus
        {
            get {return m_loginStatus; }
            set { m_loginStatus= value; }

        }




        /*
        public static void SerializeListToXMLFile()
        {
            List<Users> lstUsers = new List<Users>()
            {
            new Users{UserId = 123, UserPassword = "12345"},

            new Users{UserId = 456, UserPassword = "12345"},
            new Users{UserId = 1, UserPassword = "12345"},
            new Users{ UserId = 2 , UserPassword = "6789"}
            };
            var xmlSerializer = new XmlSerializer(typeof(List<Users>));
            using (var writer = new StreamWriter(@"C:\Users\mmoiz\Desktop\Practice\XMLfolder\AllUsers.xml"))
            {
                xmlSerializer.Serialize(writer, lstUsers);
            }

        }

        */


        public static void RegisterUser() 
        {
            Console.WriteLine("For Registration please enter the following Details: \n");
            Console.WriteLine("Enter User ID");
            uint nUserId = Convert.ToUInt32(Console.ReadLine());
            Console.WriteLine("\nEnter User Password");
            string stUserPassword = Console.ReadLine();

            cacheInstance.LstUsers.Add(new Users { UserId = nUserId, UserPassword = stUserPassword});
            Console.WriteLine("\n\n Your have registered Successfully!");
        }

        public static void LoginUser() {
            cacheInstance.DeSerializeXMLFiles();
            
            Console.WriteLine("Please Enter the User ID: ");
            uint nUserId = Convert.ToUInt32(Console.ReadLine());
            
            Console.WriteLine("Please Enter the User Login Password: ");
            string stPassword = Console.ReadLine();
            

           for (int i = 0; i < cacheInstance.LstUsers.Count; i++)
            {

                if (nUserId == cacheInstance.LstUsers[i].UserId && stPassword == cacheInstance.LstUsers[i].UserPassword)
                {
                    LoginStatus = true;
                    break;
                }
            }


            if (LoginStatus)
            {
                cacheInstance.DeSerializeXMLFiles();
            }
            else
            {
                Console.WriteLine("You are not a valid user");
                Console.WriteLine("If you want to register, Enter 1.\n If you want to exit, Enter 0 ");
                uint nInput = Convert.ToUInt32(Console.ReadLine());
                if (nInput == 1)
                {
                    RegisterUser();
                    Console.WriteLine("To Enter the ,Application you will have to Re-Enter the Login Details");
                }
                else
                {
                    Console.WriteLine("Thanks for visiting the application");

                }
            }
        }
           
    
    }
}
