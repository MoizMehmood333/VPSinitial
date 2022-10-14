using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehiclePurchaseSystem
{
    internal abstract class VehicleBase
    {
        string m_make;
        string m_model;
        uint m_year;
        uint m_veichlePrice;
        public abstract void getCarInfo(uint nCarID);
    }
}
