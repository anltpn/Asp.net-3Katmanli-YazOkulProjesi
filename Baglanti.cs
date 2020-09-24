using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DataAccessLayer
{
    public class Baglanti
    {
        public static SqlConnection bagla = new SqlConnection(@"Data Source=DESKTOP-HG2TT45\SQLEXPRESS;
                                                    Initial Catalog=YazOkulu; 
                                                    User Id=sa; Password=qw-1");
    }
}
