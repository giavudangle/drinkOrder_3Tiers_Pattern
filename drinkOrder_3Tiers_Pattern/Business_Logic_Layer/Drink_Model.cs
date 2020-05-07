using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace drinkOrder_3Tiers_Pattern.Business_Logic_Layer
{
    class Drink_Model
    {
        public DataTable GetListDrink()
        {
            try
            {
                DrinkDataProvider drink_Data_Provider = new DrinkDataProvider();
                return drink_Data_Provider.FetchListDrinks();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }

        public void AddDrink(string drinkID, string drinkName, int price, int active)
        {
            try
            {
                DrinkDataProvider drink_Data_Provider = new DrinkDataProvider();
                drink_Data_Provider.AddDrink(drinkID, drinkName, price, active);
                return; // Important
            }
            catch
            {
                throw;
            }
        }

        public void DeleteDrink(string drinkID)
        {
            try
            {
                DrinkDataProvider drink_Data_Provider = new DrinkDataProvider();
                drink_Data_Provider.DeleteDrink(drinkID);
                return;
            }
            catch
            {
                throw;
            }
        }

        public void EditDrink(string drinkID, string drinkName, int active, int price)
        {
            try
            {
                DrinkDataProvider drink_Data_Provider = new DrinkDataProvider();
                drink_Data_Provider.EditDrink(drinkID, drinkName, active, price);
                return; // Important
            }
            catch
            {
                throw;
            }
        }


    }
}
