using drinkOrder_3Tiers_Pattern.Business_Logic_Layer;
using drinkOrder_3Tiers_Pattern.Presentation_Layer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace drinkOrder_3Tiers_Pattern
{
    public partial class Form1 : Form
    {
        private readonly Drink_Model DRINK_MODEL = new Drink_Model();
        private readonly Order_Model ORDER_MODEL = new Order_Model();

        public Form1()
        {
            InitializeComponent();
            loadData_Drink();
            loadData_Order();
        }

        public void loadData_Drink()
        {            
            DataTable dt = DRINK_MODEL.GetListDrink();
            listDataDrink.DataSource = dt;
            this.listDataDrink.Columns[0].HeaderText = "Product ID";
            this.listDataDrink.Columns[1].HeaderText = "Product Name";
            this.listDataDrink.Columns[2].HeaderText = "Product Price";
            this.listDataDrink.Columns[3].HeaderText = "Product Status";
        }

        public void loadData_Order()
        {
            DataTable dt = ORDER_MODEL.GetListOrderDetail();
        
            listOrder.DataSource = dt;


            this.listOrder.Columns[0].HeaderText = "Order ID";
            this.listOrder.Columns[1].HeaderText = "Product ID";
            this.listOrder.Columns[2].HeaderText = "Product Name";
            this.listOrder.Columns[3].HeaderText = "Quantity";
            this.listOrder.Columns[4].HeaderText = "Sale(%)";
            this.listOrder.Columns[5].HeaderText = "Date Order";

        }

        private void listDataDrink_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (listDataDrink.SelectedRows[0].Cells[0].Value.ToString()== "")
            {
                textBox_productID.Enabled = true;
                textBox_productID.Text = listDataDrink.SelectedRows[0].Cells[0].Value.ToString();
                textBox_Name.Text = listDataDrink.SelectedRows[0].Cells[1].Value.ToString();
                textBox_price.Text = listDataDrink.SelectedRows[0].Cells[2].Value.ToString();
                textBox_status.Text = listDataDrink.SelectedRows[0].Cells[3].Value.ToString();
            }
            else
            {
                textBox_productID.Enabled = false;
                textBox_productID.Text = listDataDrink.SelectedRows[0].Cells[0].Value.ToString();
                textBox_Name.Text = listDataDrink.SelectedRows[0].Cells[1].Value.ToString();
                textBox_price.Text = listDataDrink.SelectedRows[0].Cells[2].Value.ToString();
                textBox_status.Text = listDataDrink.SelectedRows[0].Cells[3].Value.ToString();
            }
            
        }

        /* Some front end stuff */
        private void resetContent_ListDrink()
        {
            textBox_Name.Text = "";
            textBox_price.Text = "";
            textBox_productID.Text = "";
            textBox_status.Text = "";
        }
        private bool isValid()
        {
            if (textBox_Name.Text == string.Empty)
            {
                MessageBox.Show("Require product name!", "Failed",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                return false;
            }
            if (textBox_price.Text == string.Empty)
            {
                MessageBox.Show("Require Price!", "Failed",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                return false;
            }
            if (textBox_productID.Text == string.Empty)
            {
                MessageBox.Show("Require product ID!", "Failed",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                return false;
            }
            if (textBox_status.Text == string.Empty)

            {
                MessageBox.Show("Require VALID Status!", "Failed",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                return false;
            }
            return true;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (isValid())
            {

                string drinkID = textBox_productID.Text;
                string drinkName = textBox_Name.Text;
                int price = int.Parse(textBox_price.Text);
                int status = int.Parse(textBox_status.Text);
                DRINK_MODEL.AddDrink(drinkID, drinkName, price, status);
                loadData_Drink();
                MessageBox.Show("Add Product Sucessfully");
                resetContent_ListDrink();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string drinkID = textBox_productID.Text;
            DRINK_MODEL.DeleteDrink(drinkID);
            loadData_Drink();
            MessageBox.Show("Delete Product Sucessfully");
            resetContent_ListDrink();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            string drinkID = textBox_productID.Text;
            string drinkName = textBox_Name.Text;

            int ex = 0;
            int.TryParse(this.textBox_status.Text, out ex);
            int price = int.Parse(textBox_price.Text);
         
           
            

            DRINK_MODEL.EditDrink(drinkID, drinkName, ex, price);
            loadData_Drink();
            MessageBox.Show("Edit Product Sucessfully");
            resetContent_ListDrink();
        }

        private void btn_AddOrder_Click(object sender, EventArgs e)
        {
            AddOrder_Form addOrder_Form = new AddOrder_Form(this);
            addOrder_Form.Show();
            this.Visible = false;
            

          
            addOrder_Form.FormClosing += new FormClosingEventHandler(_addOrderClosing);
        }

        private void _addOrderClosing(object sender,FormClosingEventArgs e)
        {
            loadData_Order();
        }

        private void btn_Calculate_Click(object sender, EventArgs e)
        {
            double res = 0;
            // res = (productPrice * quantity) * (salePercent/100)

            string ID = listOrder.SelectedRows[0].Cells[1].Value.ToString();
            Drink_Model DRINK_MODEL = new Drink_Model();
            int getMoney = DRINK_MODEL.GetPrice_FromID(ID);
           
            int quantity = (int) listOrder.SelectedRows[0].Cells[3].Value;
            int sale = (int)listOrder.SelectedRows[0].Cells[4].Value;
            
            double hihi = sale * 1.0 / 100;
            int temp = getMoney * quantity;
            res = temp - (temp * hihi);
            MessageBox.Show(res.ToString() + " VND", "Giá trị đơn hàng là", MessageBoxButtons.OK, MessageBoxIcon.Information);
           
        }

        private void btn_DeleteOrder_Click(object sender, EventArgs e)
        {
                       
            string orderID = listOrder.SelectedRows[0].Cells[0].Value.ToString();
            ORDER_MODEL.DeleteOrder(orderID);
            loadData_Order();
            MessageBox.Show("Delete Order Successfully!");
        }

        private void listOrder_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        
    }
}
