using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace POS
{
    /// <summary>
    /// Interaction logic for add_product.xaml
    /// </summary>
    public partial class add_product : UserControl
    {
        SqlHelper con = new SqlHelper();
        static int PK_ID;

        public add_product()
        {
            InitializeComponent();
            fillcombobox(Combobox1);
            filldatagrid();
        }

        //Method for accessing data and fill datagrid
        private void filldatagrid()
        {
           
            con.Connection_String();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = SqlHelper.con;
            cmd.CommandText = "select * from Product";
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adp.Fill(dt);
          
        }
      
        //Method for fill combobox
        void fillcombobox(ComboBox comboBoxName)
        {   
            con.Connection_String();
            List<Category> list = new List<Category>();
            //con.Open();
            SqlCommand cmd = new SqlCommand("Select CategoryId,CategoryName FROM Category");
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    Combobox1.Items.Clear();
                    while (reader.Read())
                    {
                        Category rep = new Category();
                        rep.CategoryId = (reader["CategoryId"]).ToString();
                        rep.CategoryName = (reader["CategoryName"]).ToString();
                        list.Add(rep);
                        Combobox1.Items.Add(rep);
                    }
                }
            }
            }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            //  if (btnsubmit.Content == "Update")
            //{            //Code for updating data
            //  SqlConnection con = new SqlConnection(sqlstring);
            //con.Open();
            //string sqlquery = "update products set name=@name,description=@description,quantity=@quantity,price=@price,date=@date where id='" + PK_ID + "'";
            //SqlCommand cmd = new SqlCommand(sqlquery, con);
            //cmd.Parameters.AddWithValue("@name", txtname.Text);
            //cmd.Parameters.AddWithValue("@description", txtdescription.Text);
            //cmd.Parameters.AddWithValue("@quantity", txtquantity.Text);
            //cmd.Parameters.AddWithValue("@country", combobox1.SelectedValue);
            //cmd.Parameters.AddWithValue("@state", combobox2.SelectedValue);
            //cmd.Parameters.AddWithValue("@price", txtprice.Text);
            //cmd.Parameters.AddWithValue("@date", txtdate.Text);
            //cmd.ExecuteNonQuery();
            //filldatagrid();
            //clearcontrol();
            //}
            //else
            //{
            //Code for inserting data
                con.Connection_String();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = SqlHelper.con;

              cmd.CommandText = "insert into Product (CategoryId,CompanyId,UomId,Barcode,ProductName,Quantity,PurchasePrice,SalePrice,ReorderLevel,ReplenishLevel,ExpireDate) " +
                "values (@CategoryId,@CompanyId,@UomId,@Barcode,@ProductName,@Quantity,@PurchasePrice,@SalePrice,@ReorderLevel,@ReplenishLevel,@ExpireDate)";              
                cmd.Parameters.AddWithValue("@CategoryId",Combobox1.SelectedValue.ToString());
                cmd.Parameters.AddWithValue("@CompanyId",Combobox2.SelectedValue.ToString());
                cmd.Parameters.AddWithValue("@UomId",Combobox3.SelectedValue.ToString());
                cmd.Parameters.AddWithValue("@Barcode", txtBarcode.Text);
                cmd.Parameters.AddWithValue("@ProductName", txtProductName.Text);
                cmd.Parameters.AddWithValue("@Quantity", txtQuantity.Text);
                cmd.Parameters.AddWithValue("@PurchasePrice", txtPurchasePrice.Text);
                cmd.Parameters.AddWithValue("@SalePrice", txtSalePrice.Text);
                cmd.Parameters.AddWithValue("@ReorderLevel", txtReorderLevel.Text);
                cmd.Parameters.AddWithValue("@ReplenishLevel", txtReplenishLevel.Text);
                cmd.Parameters.AddWithValue("@ExpireDate", txtExpireDate.Text);
               // cmd.Parameters.AddWithValue("@IsActive", txtIsActive);
                cmd.ExecuteNonQuery();
                filldatagrid();
                clearcontrol();
                MessageBox.Show("Data Inserted Successfully");        
            //}
        }
        //Method for clear data from control
        private void clearcontrol()
        {
            Combobox1.Text = string.Empty;
            Combobox2.Text = string.Empty;
            Combobox3.Text = string.Empty;
            txtBarcode.Text = string.Empty;
            txtProductName.Text = string.Empty;
            txtQuantity.Text = string.Empty;
            txtPurchasePrice.Text = string.Empty;
            txtSalePrice.Text = string.Empty;
            txtReorderLevel.Text = string.Empty;
            txtReplenishLevel.Text = string.Empty;
            txtExpireDate.Text = string.Empty;
           // txtIsActive.IsChecked =Empty;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            prod.Children.Clear();
            get_products db = new get_products();
            Grid.SetRowSpan(db, 3);
            Grid.SetColumnSpan(db, 2);
            prod.Children.Add(db);
        }

        public class Category
        {
            public string CategoryId { get; set; }
            public string CategoryName { get; set; }
           
        }

    }
}
