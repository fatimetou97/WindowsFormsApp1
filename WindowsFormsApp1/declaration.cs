using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace WindowsFormsApp1
{
    class declaration
    {

public static SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-QTLF4OF;Initial Catalog=data;Integrated Security=True");
       

        public static SqlCommand cmd = new SqlCommand("SELECT * FROM medicaments",con);
        public static SqlDataAdapter dap = new SqlDataAdapter(cmd);
       
/*
        public static SqlCommand cmd2 = new SqlCommand("insert into [medicaments] values(@id, @n, @ty)", con);
        public static SqlDataAdapter dap2 = new SqlDataAdapter(cmd2);
        public static SqlCommandBuilder cd = new SqlCommandBuilder(dap2);*/
    }
}
