using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Server2
{
    public partial class Form1 : Form
    {
        private SqlConnection SqlConnection = null;
        private SqlCommandBuilder builder = null;
        private SqlDataAdapter adapter = null;
        private DataSet dataSet = null;
        public Form1()
        {
            InitializeComponent();
            Load();
        }
        private string GetConnectinString()
        {
            return ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }
        private void Load()
        {
            SqlConnection connection = new SqlConnection(GetConnectinString());
            connection.Open();

            string query = "select * from Cargo ORDER BY NameSender";
            SqlCommand command = new SqlCommand(query, connection);
            SqlDataReader reader = command.ExecuteReader();

            List<string[]> data = new List<string[]>();
            while (reader.Read())
            {
                data.Add(new string[16]);

                data[data.Count - 1][0] = reader[0].ToString();
                data[data.Count - 1][1] = reader[1].ToString();
                data[data.Count - 1][2] = reader[2].ToString();
                data[data.Count - 1][3] = reader[3].ToString();
                data[data.Count - 1][4] = reader[4].ToString();
                data[data.Count - 1][3] = reader[3].ToString();
                data[data.Count - 1][6] = reader[6].ToString();
                data[data.Count - 1][7] = reader[7].ToString();
                data[data.Count - 1][8] = reader[8].ToString();
                data[data.Count - 1][9] = reader[9].ToString();
                data[data.Count - 1][10] = reader[10].ToString();
                data[data.Count - 1][11] = reader[11].ToString();
                data[data.Count - 1][12] = reader[12].ToString();
                data[data.Count - 1][13] = reader[13].ToString();
                data[data.Count - 1][14] = reader[14].ToString();
            }
            reader.Close();
            connection.Close();
            dataGridView1.Rows.Clear();
            foreach (string[] ink in data)
                dataGridView1.Rows.Add(ink);
        }
    }
}
