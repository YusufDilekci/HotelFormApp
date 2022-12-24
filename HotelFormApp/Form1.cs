using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HotelFormApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        NpgsqlConnection connect = new NpgsqlConnection("server=localHost;port=5432;UserId=postgres;password=2134;database=postgres");
        string tableName = "\"HotelManagement\".\"Hotel\"";


        private void button1_Click(object sender, EventArgs e)
        {
            string selectedColumns = "\"hotelNo\", \"hotelChainCode\", \"name\"";
            string query = $"select {selectedColumns} from {tableName}";
            NpgsqlDataAdapter adapt = new NpgsqlDataAdapter(query, connect);
            DataSet ds = new DataSet();
            adapt.Fill(ds);

            //connect.CLose()
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void button2_Click(object sender, EventArgs e)
        {
            connect.Open();
            NpgsqlCommand command1 = new NpgsqlCommand($"insert into {tableName} values(@hotelno, @hotelchaincode, @name)", connect);
            command1.Parameters.AddWithValue("hotelno", int.Parse(textBox1.Text));
            command1.Parameters.AddWithValue("hotelchaincode", int.Parse(textBox2.Text));
            command1.Parameters.AddWithValue("name", textBox3.Text);
            command1.ExecuteNonQuery();
            connect.Close();
            MessageBox.Show("GuestInformation insert operation has been done successfully");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            connect.Open();
            NpgsqlCommand command2 = new NpgsqlCommand($"Delete from {tableName} where \"hotelNo\"=@hotelno", connect);
            command2.Parameters.AddWithValue("hotelno", int.Parse(textBox1.Text));
            command2.ExecuteNonQuery();
            connect.Close();
            MessageBox.Show("GuestInformation delete operation has been done successfully");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            connect.Open();
            NpgsqlCommand command3 = new NpgsqlCommand($"UPDATE {tableName} SET \"name\" = @name WHERE \"hotelNo\" = @hotelno", connect);
            command3.Parameters.AddWithValue("hotelno", int.Parse(textBox1.Text));
            command3.Parameters.AddWithValue("name", textBox3.Text);
            command3.ExecuteNonQuery();
            connect.Close();
            MessageBox.Show("GuestInformation update operation has been done successfully");
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
