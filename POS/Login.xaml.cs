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
using System.Windows.Shapes;

namespace POS
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-8PS13HC\SQLEXPRESS; Initial Catalog=POS; Integrated Security=True;");
            try
            {
                if (con.State == ConnectionState.Closed)
                    con.Open();
                string query = "Select Count(1) From users where username=@username And password=@password";
                SqlCommand sqlcmd = new SqlCommand(query, con);
                sqlcmd.CommandType = CommandType.Text;
                sqlcmd.Parameters.AddWithValue("@username", textBoxEmail.Text);
                sqlcmd.Parameters.AddWithValue("@password", passwordBox1.Password);
                int count = Convert.ToInt32(sqlcmd.ExecuteScalar());
                if (count == 1)
                {
                    MainWindow dashboard = new MainWindow();
                    dashboard.Show();
                    this.Close();
                }
                else {
                    MessageBox.Show("UserName or Password Incorrect!");
                }
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }

        }

        }
}
