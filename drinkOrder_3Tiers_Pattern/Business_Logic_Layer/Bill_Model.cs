using drinkOrder_3Tiers_Pattern.Data_Access_Layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace drinkOrder_3Tiers_Pattern.Business_Logic_Layer
{
    class Bill_Model
    {
        public void AddBill(string orderID)
        {
            try
            {
                BillDataProvider bill_Data_Provider = new BillDataProvider();
                DateTime dateTime = DateTime.Now;
                bill_Data_Provider.AddBill(orderID, dateTime);
                return; // Important
            }
            catch
            {
                throw;
            }
        }

    }
}
