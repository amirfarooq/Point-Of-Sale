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
    /// Interaction logic for Company.xaml
    /// </summary>
    public partial class Company : UserControl
    {
        SqlHelper con = new SqlHelper();
        static int PK_ID;
        public Company()
        {
            InitializeComponent();
            filldatagrid();
        }

        //Method for accessing data and fill datagrid
        private void filldatagrid()
        {
            con.Connection_String();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = SqlHelper.con;
            cmd.CommandText = "select * from Company";
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            Com_dg.ItemsSource = dt.DefaultView;
            // con.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (btnsubmit.Content == "Update")
            {
                //Code for updating data
                con.Connection_String();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = SqlHelper.con;
                cmd.CommandText = "update Uom set CompanyName=@CompanyName where id='" + PK_ID + "'";
                cmd.Parameters.AddWithValue("@CompanyName", txtCompanyName.Text);
                cmd.ExecuteNonQuery();
                filldatagrid();
                clearcontrol();
            }
            else
            {
                //Code for inserting data
                con.Connection_String();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = SqlHelper.con;
                cmd.CommandText = "insert into Uom (CompanyName) values (@CompanyName)";
                cmd.Parameters.AddWithValue("@CompanyName", txtCompanyName.Text);
                cmd.ExecuteNonQuery();
                filldatagrid();
                clearcontrol();
            }
        }
        //Method for clear data from control
        private void clearcontrol()
        {
            txtCompanyName.Text = string.Empty;

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {

            var id1 = (DataRowView)Com_dg.SelectedItem; //get specific ID from          DataGrid after click on Edit button in DataGrid  
            PK_ID = Convert.ToInt32(id1.Row["id"].ToString());
            con.Connection_String();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = SqlHelper.con;
            cmd.CommandText = "select * from Company where id='" + PK_ID + "' ";
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                txtCompanyName.Text = dt.Rows[0]["CompanyName"].ToString();
            }
            btnsubmit.Content = "Update";
        }
        //Code for Deleting data
        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            var id1 = (DataRowView)Com_dg.SelectedItem;  //Get specific ID From                DataGrid after click on Delete Button.
            PK_ID = Convert.ToInt32(id1.Row["CompanyId"].ToString());
            con.Connection_String();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = SqlHelper.con;
            cmd.CommandText = "delete from Company where id='" + PK_ID + "' ";
            cmd.ExecuteNonQuery();
            filldatagrid();
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            companygd.Children.Clear();
            get_products db = new get_products();
            Grid.SetRowSpan(db, 3);
            Grid.SetColumnSpan(db, 2);
            companygd.Children.Add(db);
        }

    }
}
