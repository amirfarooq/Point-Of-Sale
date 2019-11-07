﻿using System;
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
    /// Interaction logic for get_products.xaml
    /// </summary>
    public partial class get_products : UserControl
    {
        static int PK_ID;
        SqlHelper con = new SqlHelper();
        public get_products()
        {
            InitializeComponent();
            product();
        }

        public class products
        {
            public string name { get; set; }
            public string description { get; set; }
            public string quantity { get; set; }
            public string price { get; set; }
            public string date { get; set; }
        }

        private void product()
        {
            con.Connection_String();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = SqlHelper.con;
            cmd.CommandText = "select * from Product";            
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            datagrid1.ItemsSource = dt.DefaultView;
          //  con.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            prod.Children.Clear();
            add_product db = new add_product();
            Grid.SetRowSpan(db, 3);
            Grid.SetColumnSpan(db, 2);
            prod.Children.Add(db);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
        
            Category db = new Category();
            Grid.SetRowSpan(db, 3);
            Grid.SetColumnSpan(db, 2);
            prod.Children.Add(db);
        }
    }
}
