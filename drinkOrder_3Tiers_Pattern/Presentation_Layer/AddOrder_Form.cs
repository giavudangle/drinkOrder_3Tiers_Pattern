using drinkOrder_3Tiers_Pattern.Business_Logic_Layer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace drinkOrder_3Tiers_Pattern.Presentation_Layer
{
    public partial class AddOrder_Form : Form
    {
        private static readonly string connectionString = "Data Source=ADMIN;Initial Catalog=QLQUAN;Integrated Security=True";
        private static SqlConnection connection = new SqlConnection(connectionString);
        private Form parentForm;

        public Form1 obj = (Form1)Application.OpenForms["Form1"];
        public AddOrder_Form(Form parentForm)
        {
            this.parentForm = parentForm;
            InitializeComponent();
            loadDrink_ComboBox();
        }

        private void btn_AddOrder_Click(object sender, EventArgs e)
        {
            Bill_Model BILL_MODEL = new Bill_Model();
            Order_Model ORDER_MODEL = new Order_Model();
            Drink_Model DRINK_MODEL = new Drink_Model();

            string orderID = txt_OrderID.Text;
            string productID = DRINK_MODEL.GetID_FromName(cbx_Drinks.Text);
            int quantity = (int)num_Quantity.Value;
            int sale = (int)num_Sale.Value;

            BILL_MODEL.AddBill(orderID);
            ORDER_MODEL.AddOrder(orderID, productID, quantity, sale);
            

            MessageBox.Show("ADD ORDER SUCCESSFULLY!");
           //obj.loadData_Order(); -> Use it when we want callback MainForm :D 

            this.Close();
            this.parentForm.Visible = true;




        }
        

        // Too lazy to build 3 tier for this method ^^
        private void loadDrink_ComboBox()
        {
            SqlCommand command = new SqlCommand("SELECT TenHang FROM DRINKS", connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                cbx_Drinks.Items.Add(reader["TenHang"].ToString());
            }

            connection.Close();
            


        }

        private void btn_CancelOrder_Click(object sender, EventArgs e)
        {
            this.parentForm.Visible = true;
            this.Close();
        }
    }
}
