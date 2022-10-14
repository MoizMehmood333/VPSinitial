using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using VehiclePurchaseSystem;

namespace ViechlePurchaseSystem.CacheLayer
{
    public class Cache
    {
        private List<Users> m_lstUsers;
        private List<Car> m_lstCars;
        private List<Accounts> m_lstAccounts;

        public List<Users> LstUsers {
            get { return m_lstUsers; }
            set { m_lstUsers = value; }
        }
        public List<Car> LstCars
        {
            get { return m_lstCars; }
            set { m_lstCars = value; }
        }
        public List<Accounts> LstAccounts{
            get { return m_lstAccounts; }
            set { m_lstAccounts = value;  }
        }
        private static  Cache cacheInstance = new Cache(); 
        private Cache()
        {
        }

        public static Cache GetCache()
        {
            return cacheInstance;
        }



        public  void DeSerializeXMLFiles( )
        {

            if (LstUsers == null) {

                var userXmlSerializer = new XmlSerializer(typeof(List<Users>));

                using (var reader = new StreamReader(@"C:\Users\mmoiz\Desktop\Practice\XMLfolder\AllUsers.xml"))
                {
                    LstUsers = new List<Users>();
                    LstUsers = (List<Users>)userXmlSerializer.Deserialize(reader);

                }


            }
            bool boolValue = Users.LoginStatus;


           

            if (boolValue)
                {


                    var carXmlSerializer = new XmlSerializer(typeof(List<Car>));
                    var accountXmlSerializer = new XmlSerializer(typeof(List<Accounts>));

                    using (var reader = new StreamReader(@"C:\Users\mmoiz\Desktop\Practice\XMLfolder\CarInInventory.xml"))
                    {
                        LstCars = new List<Car>();
                        LstCars = (List<Car>)carXmlSerializer.Deserialize(reader);

                    }
                    using (var reader = new StreamReader(@"C:\Users\mmoiz\Desktop\Practice\XMLfolder\Accounts.xml"))
                    {
                        LstAccounts = new List<Accounts>();
                        LstAccounts = (List<Accounts>)accountXmlSerializer.Deserialize(reader);

                    }
                }          
        }
    }
}
