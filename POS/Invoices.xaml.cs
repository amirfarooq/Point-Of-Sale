using System;
using System.Collections.Generic;
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
    /// Interaction logic for Invoices.xaml
    /// </summary>
    public partial class Invoices : UserControl
    {
        public Invoices()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ClearControls();
            Dashboard dv = new Dashboard();
            Grid.SetRowSpan(dv, 4);
            Grid.SetColumnSpan(dv, 4);
            //nam.Children.Add(dv);
        }
        private void ClearControls()
        {
          //  nam.Children.Clear();
        }
    }
}
