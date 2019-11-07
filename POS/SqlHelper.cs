using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS
{
    
    public class SqlHelper
    {
        public static SqlConnection con = null;
        public void Connection_String() {
            con = new SqlConnection(@"Data Source=DESKTOP-8PS13HC\SQLEXPRESS; Initial Catalog=Point_Of_Sales; Integrated Security=True;");
            //con.Open();
        }
    }
}
