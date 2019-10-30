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

        string sqlstring = (@"Data Source=DESKTOP-8PS13HC\SQLEXPRESS; Initial Catalog=POS; Integrated Security=True;");
        static int PK_ID;

        public add_product()
        {
            InitializeComponent();
            fillcombobox();
            filldatagrid();
        }

        //Method for accessing data and fill datagrid
        private void filldatagrid()
        {
            SqlConnection con = new SqlConnection(sqlstring);
            con.Open();
            string sqlquery = "select * from products";
            SqlCommand cmd = new SqlCommand(sqlquery, con);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adp.Fill(dt);
           // datagrid1.ItemsSource = dt.DefaultView;
            con.Close();
        }
        //Method for Fill Combobox after change selected item of another combobox.
      /*  private void ComboBox_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            int cnname1 = name.SelectedIndex;
            int cname2 = cnname1 ++;
            SqlConnection con = new SqlConnection(sqlstring);
            con.Open();
            string sqlquery = "select * from category where name='" + cname2 + "'";
            SqlCommand cmd = new SqlCommand(sqlquery, con);
            SqlDataReader sdr = cmd.ExecuteReader();
            if (sdr.Read())
            {
                string cnname = sdr.GetString(2);
                //combobox2.Items.Add(cnname);
            }
            
            con.Close();
        }*/
        //Method for fill combobox
        void fillcombobox()
        {
            SqlConnection con = new SqlConnection(sqlstring);
            con.Open();
            string sqlquery = "select * from category";
           SqlCommand cmd = new SqlCommand(sqlquery, con);
            SqlDataReader adp = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            while (adp.Read()) {
                string name = adp.GetString(1);
                cat_name.Items.Add(name);
            }
           // adp.Fill(dt);
            //name.DataContext = dt;
            //if (dt.Rows.Count > 0)
            //{
              // name.Items.Add(dt.Rows[0]["name"].ToString());
               //name.Items.Add(dt.Rows[1]["name"].ToString());
           // }
            con.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
          //  if (btnsubmit.Content == "Update")
            //{
                //Code for updating data
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
                SqlConnection con = new SqlConnection(sqlstring);
                con.Open();
                string sqlquery = "insert into products (cat_name,pro_name,quantity,price,date) values (@cat_name,@pro_name,@quantity,@price,@date)";
                SqlCommand cmd = new SqlCommand(sqlquery, con);
                cmd.Parameters.AddWithValue("@cat_name", cat_name.SelectedValue);
                cmd.Parameters.AddWithValue("pro_name", txtpro_name.Text);
                cmd.Parameters.AddWithValue("@quantity", txtquantity.Text);
                //  cmd.Parameters.AddWithValue("@country", combobox1.SelectedValue);
                //cmd.Parameters.AddWithValue("@state", combobox2.SelectedValue);
                cmd.Parameters.AddWithValue("@price", txtprice.Text);
                cmd.Parameters.AddWithValue("@date", date.Text);
                cmd.ExecuteNonQuery();
                filldatagrid();
                clearcontrol();
                MessageBox.Show("Data Inserted Successfully");
                con.Close();
            //}
        }
        //Method for clear data from control
        private void clearcontrol()
        {
            cat_name.Text = string.Empty;
            txtpro_name.Text = string.Empty;
            txtquantity.Text = string.Empty;
            txtprice.Text = string.Empty;
            date.Text = string.Empty;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            prod.Children.Clear();
            get_products db = new get_products();
            Grid.SetRowSpan(db, 3);
            Grid.SetColumnSpan(db, 2);
            prod.Children.Add(db);
        }

    }
}
