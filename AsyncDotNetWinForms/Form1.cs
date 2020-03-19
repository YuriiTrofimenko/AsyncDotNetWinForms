using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AsyncDotNetWinForms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            using (SqlConnection conn = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Disease;Integrated Security=True"))
            {
                conn.Open();
                SqlCommand selectCommand = conn.CreateCommand();
                selectCommand.CommandText = @"SELECT * FROM [Large_table_3]";
                IAsyncResult asyncResult = selectCommand.BeginExecuteReader();
                while (!asyncResult.IsCompleted)
                {
                    Console.Write(".");
                    Thread.Sleep(500);
                }
                Console.WriteLine();
                SqlDataReader reader =
                    selectCommand.EndExecuteReader(asyncResult);
                while (reader.Read())
                {
                    if (!((int)reader["id"] == 57863))
                    {
                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            Console.WriteLine(reader[i] + "    ");
                        }
                    }
                    else
                    {
                        reader.Close();
                        break;
                    }
                }
            }
        }
    }
}
