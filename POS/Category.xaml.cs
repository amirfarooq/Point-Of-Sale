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
    /// Interaction logic for Category.xaml
    /// </summary>
    public partial class Category : UserControl
    {

        string sqlstring = (@"Data Source=DESKTOP-8PS13HC\SQLEXPRESS; Initial Catalog=POS; Integrated Security=True;");
        static int PK_ID;

        public Category()
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
            string sqlquery = "select * from category";
            SqlCommand cmd = new SqlCommand(sqlquery, con);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            datagrid1.ItemsSource = dt.DefaultView;
            con.Close();
        }
        //Method for Fill Combobox after change selected item of another combobox.
        private void ComboBox_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            //  int cnname1 = combobox1.SelectedIndex;
            //  int cname2 = cnname1 + 1;
            // SqlConnection con = new SqlConnection(sqlstring);
            // con.Open();
            /// string sqlquery = "select * from employees_State where Countryname='" + cname2 + "'";
            // SqlCommand cmd = new SqlCommand(sqlquery, con);
            // SqlDataReader sdr = cmd.ExecuteReader();
            //// if (sdr.Read())
            //  {
            //      string cnname = sdr.GetString(2);
            //      combobox2.Items.Add(cnname);
            //  }
            //  con.Close();
        }
        //Method for fill combobox
        void fillcombobox()
        {
            // SqlConnection con = new SqlConnection(sqlstring);
            // con.Open();
            // string sqlquery = "select * from employees_Country";
            //SqlCommand cmd = new SqlCommand(sqlquery, con);
            // SqlDataAdapter adp = new SqlDataAdapter(cmd);
            // DataTable dt = new DataTable();
            // adp.Fill(dt);
            // combobox1.DataContext = dt;
            // if (dt.Rows.Count > 0)
            // {
            ////     combobox1.Items.Add(dt.Rows[0]["name"].ToString());
            //      combobox1.Items.Add(dt.Rows[1]["name"].ToString());
            //  }
            // con.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (btnsubmit.Content == "Update")
            {
                //Code for updating data
                SqlConnection con = new SqlConnection(sqlstring);
                con.Open();
                string sqlquery = "update category set name=@name where id='" + PK_ID + "'";
                SqlCommand cmd = new SqlCommand(sqlquery, con);
                cmd.Parameters.AddWithValue("@name", txtname.Text);
                cmd.ExecuteNonQuery();
                filldatagrid();
                clearcontrol();
            }
            else
            {
                //Code for inserting data
                SqlConnection con = new SqlConnection(sqlstring);
                con.Open();
                string sqlquery = "insert into category (name) values (@name)";
                SqlCommand cmd = new SqlCommand(sqlquery, con);
                cmd.Parameters.AddWithValue("@name", txtname.Text);
                cmd.ExecuteNonQuery();
                filldatagrid();
                clearcontrol();
            }
        }
        //Method for clear data from control
        private void clearcontrol()
        {
            txtname.Text = string.Empty;
           
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {

            var id1 = (DataRowView)datagrid1.SelectedItem; //get specific ID from          DataGrid after click on Edit button in DataGrid  
            PK_ID = Convert.ToInt32(id1.Row["id"].ToString());
            SqlConnection con = new SqlConnection(sqlstring);
            con.Open();
            string sqlquery = "select * from category where id='" + PK_ID + "' ";
            SqlCommand cmd = new SqlCommand(sqlquery, con);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                txtname.Text = dt.Rows[0]["name"].ToString(); 
            }
            btnsubmit.Content = "Update";
        }
        //Code for Deleting data
        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            var id1 = (DataRowView)datagrid1.SelectedItem;  //Get specific ID From                DataGrid after click on Delete Button.
            PK_ID = Convert.ToInt32(id1.Row["id"].ToString());
            SqlConnection con = new SqlConnection(sqlstring);
            con.Open();
            string sqlquery = "delete from category where id='" + PK_ID + "' ";
            SqlCommand cmd = new SqlCommand(sqlquery, con);
            cmd.ExecuteNonQuery();
            filldatagrid();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            cat.Children.Clear();
            Dashboard db = new Dashboard();
            Grid.SetRowSpan(db, 3);
            Grid.SetColumnSpan(db, 2);
            cat.Children.Add(db);
        }
    }
}
