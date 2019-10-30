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
    /// Interaction logic for Employees.xaml
    /// </summary>
    public partial class Employees : UserControl
    {
        string sqlstring = (@"Data Source=DESKTOP-8PS13HC\SQLEXPRESS; Initial Catalog=POS; Integrated Security=True;");
        static int PK_ID;

        public Employees()
        {
            InitializeComponent();        
            filldatagrid();
        }

        //Method for accessing data and fill datagrid
        private void filldatagrid()
        {
            SqlConnection con = new SqlConnection(sqlstring);
            con.Open();
            string sqlquery = "select * from employees";
            SqlCommand cmd = new SqlCommand(sqlquery, con);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            datagrid_emp.ItemsSource = dt.DefaultView;
            con.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
              if (btnsubmit.Content == "Update")
           {
           // Code for updating data
              SqlConnection con = new SqlConnection(sqlstring);
            con.Open();
            string sqlquery = "update employees set name=@name,adress=@adress,cnic=@cnic,phone=@phone,salary=@salary where id='" + PK_ID + "'";
            SqlCommand cmd = new SqlCommand(sqlquery, con);
            cmd.Parameters.AddWithValue("@name", txtname.Text);
            cmd.Parameters.AddWithValue("@adress", txtadress.Text);
            cmd.Parameters.AddWithValue("@cnic", txtcnic.Text);
            cmd.Parameters.AddWithValue("@phone", txtphone.Text);
            cmd.Parameters.AddWithValue("@salary", txtsalary.Text);
            cmd.ExecuteNonQuery();
            filldatagrid();
            clearcontrol();
            }
            else
            {
            //Code for inserting data
            SqlConnection con = new SqlConnection(sqlstring);
            con.Open();
            string sqlquery = "insert into employees (name,adress,cnic,phone,salary) values (@name,@adress,@cnic,@phone,@salary)";
            SqlCommand cmd = new SqlCommand(sqlquery, con);
            cmd.Parameters.AddWithValue("@name", txtname.Text);
            cmd.Parameters.AddWithValue("@adress", txtadress.Text);
            cmd.Parameters.AddWithValue("@cnic", txtcnic.Text);
            cmd.Parameters.AddWithValue("@phone", txtphone.Text);
            cmd.Parameters.AddWithValue("@salary", txtsalary.Text);
            cmd.ExecuteNonQuery();
            clearcontrol();
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {

            var id1 = (DataRowView)datagrid_emp.SelectedItem; //get specific ID from          DataGrid after click on Edit button in DataGrid  
            PK_ID = Convert.ToInt32(id1.Row["id"].ToString());
            SqlConnection con = new SqlConnection(sqlstring);
            con.Open();
            string sqlquery = "select * from employees where id='" + PK_ID + "' ";
            SqlCommand cmd = new SqlCommand(sqlquery, con);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                txtname.Text = dt.Rows[0]["name"].ToString();
                txtadress.Text = dt.Rows[0]["adress"].ToString();
                txtcnic.Text = dt.Rows[0]["cnic"].ToString();
                txtphone.Text = dt.Rows[0]["phone"].ToString();
                txtsalary.Text = dt.Rows[0]["salary"].ToString();
            }
            btnsubmit.Content = "Update";
        }

        //Code for Deleting data
        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            var id1 = (DataRowView)datagrid_emp.SelectedItem;  //Get specific ID From                DataGrid after click on Delete Button.
            PK_ID = Convert.ToInt32(id1.Row["id"].ToString());
            SqlConnection con = new SqlConnection(sqlstring);
            con.Open();
            string sqlquery = "delete from employees where id='" + PK_ID + "' ";
            SqlCommand cmd = new SqlCommand(sqlquery, con);
            cmd.ExecuteNonQuery();
            filldatagrid();
        }

        //Method for clear data from control
        private void clearcontrol()
        {
            txtname.Text = string.Empty;
            txtadress.Text = string.Empty;
            txtcnic.Text = string.Empty;
            txtphone.Text = string.Empty;
            txtsalary.Text = string.Empty;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            employee.Children.Clear();
            Dashboard db = new Dashboard();
            Grid.SetRowSpan(db, 3);
            Grid.SetColumnSpan(db, 2);
            employee.Children.Add(db);
        }

     
    }
}
