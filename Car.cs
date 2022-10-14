using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using VehiclePurchaseSystem;

namespace VehiclePurchaseSystem
{
     public class Car 
    {
        public static List<Car> m_lstCars = DeSerializeXMLFileToList();
        
        private uint m_carID;
        private string m_make;
        private string m_model;
        private uint m_carPrice;

        //properties
        public static List<Car> LstCars {
            get  { return m_lstCars;  }
            set { m_lstCars = value;  }
        }
        public uint CarID
        {
            get { return m_carID; }
            set { m_carID = value; }
        }
        public string Make {
            get { return m_make;  } 
            set { m_make = value;  } 

        }
        public string Model
        {
            get { return m_model; }
            set { m_model = value; }
        }
        public uint CarPrice
        {
            get { return m_carPrice; }
            set { m_carPrice = value; }
        }

        //constuctor
        /*
        public Car(uint nCarID, string stMake, string stModel, uint nCarPrice)
        {
            CarID = nCarID;
            Make = stMake;
            Model = stModel;
            CarPrice = nCarPrice;
        }
        */

        public static void SerializeListToXMLFile()
        {
            List<Car> lstCars = new List<Car>()
            {
            new Car{CarID = 15, Make = "Honda", Model = "Civic", CarPrice = 150000 },
            new Car{CarID =  2, Make =  "Suzuki", Model = "Cultus",CarPrice =  20000},
            new Car{CarID = 4 ,Make = "Toyota", Model = "Land Cruiser", CarPrice = 1000000 },
            new Car{CarID= 1, Make =  "Honda", Model = "City", CarPrice = 15000}

             };        
            var xmlSerializer = new XmlSerializer(typeof(List<Car>));
            using (var writer = new StreamWriter(@"C:\Users\mmoiz\Desktop\Practice\XMLfolder\CarInInventory.xml")) {
                xmlSerializer.Serialize(writer, lstCars);
            }

        }
        public static List<Car> DeSerializeXMLFileToList() {
            var xmlSerializer = new XmlSerializer(typeof(List<Car>));
            using (var reader = new StreamReader(@"C:\Users\mmoiz\Desktop\Practice\XMLfolder\CarInInventory.xml")) {
                var lstCars = (List<Car>) xmlSerializer.Deserialize(reader);
                return lstCars;
            }
        } 


    }
}
