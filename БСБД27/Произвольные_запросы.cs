using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace БСБД27
{
    public partial class Произвольные_запросы : Form
    {
        public Произвольные_запросы()
        {
            InitializeComponent();
        }

        DataTable FillDataGridView(string sqlSelect)
        {
            SqlConnection connection = new SqlConnection(Properties.Settings.Default.БСБДConnectionString);
            SqlCommand command = connection.CreateCommand();
            command.CommandText = sqlSelect;
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = command;
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }

        private void Произвольные_запросы_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "бСБДDataSet1.Properties". При необходимости она может быть перемещена или удалена.
            this.propertiesTableAdapter.Fill(this.бСБДDataSet1.Properties);
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = FillDataGridView("SELECT * FROM [Properties]");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView2.DataSource = FillDataGridView("SELECT *, (SELECT COUNT(*) FROM [Buyers] WHERE [Buyers].[LawyerID] = [Sellers].[LawyerID]) AS DesiredCount FROM [Sellers];");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string sqlSelect = @"INSERT INTO Properties (RealtorID, SellerID, Price, Address) VALUES ('" + textBox1.Text + "', '" + textBox2.Text + "', '" + textBox3.Text + "', '" + textBox4.Text + "')";
            SqlConnection connection = new SqlConnection(Properties.Settings.Default.БСБДConnectionString);
            SqlCommand command = connection.CreateCommand();
            connection.Open();
            command.CommandText = sqlSelect;
            command.ExecuteNonQuery();
            connection.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string sqlSelect = @"DELETE FROM Properties WHERE ID = " + textBox5.Text;
            SqlConnection connection = new SqlConnection(Properties.Settings.Default.БСБДConnectionString);
            SqlCommand command = connection.CreateCommand();
            connection.Open();
            command.CommandText = sqlSelect;
            command.ExecuteNonQuery();
            connection.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string sqlSelect = @"UPDATE Properties SET Address = '" + textBox7.Text + "' WHERE ID = " + textBox6.Text;
            SqlConnection connection = new SqlConnection(Properties.Settings.Default.БСБДConnectionString);
            SqlCommand command = connection.CreateCommand();
            connection.Open();
            command.CommandText = sqlSelect;
            command.ExecuteNonQuery();
            connection.Close();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = FillDataGridView("SELECT Buyers.Name, Realtors.Name AS Realtor_Name FROM Buyers INNER JOIN Realtors ON Buyers.RealtorID = Realtors.ID");
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = FillDataGridView("SELECT ID, CAST(Price AS varchar(200)) + ' руб.' AS 'Price' FROM Properties");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string sqlSelect = "SELECT Properties.ID, Properties.Price";
            if (radioButton4.Checked)
                sqlSelect += ", Sellers.Name AS Seller_Name FROM Properties INNER JOIN Sellers ON Properties.SellerID = Sellers.ID";
            if (radioButton5.Checked)
                sqlSelect += ", Realtors.Name AS Realtor_Name FROM Properties INNER JOIN Realtors ON Properties.RealtorID = Realtors.ID";
            if (radioButton6.Checked)
                sqlSelect += " FROM Properties";
            if (checkBox1.Checked == true)
                if ((String.IsNullOrEmpty(textBox9.Text)) || (String.IsNullOrEmpty(textBox10.Text)))
                {
                    MessageBox.Show("Необходимо указать точное значение либо диапазон.");
                    return;
                }
                else
                    sqlSelect += " WHERE Properties.Price BETWEEN " + textBox9.Text + " AND " + textBox10.Text;
            else if (!String.IsNullOrEmpty(textBox8.Text))
                sqlSelect += " WHERE Properties.Price = " + textBox8.Text;
            else

            if (checkBox2.Checked)
                sqlSelect += " ORDER BY Properties.Price DESC";
            SqlConnection connection = new SqlConnection(Properties.Settings.Default.БСБДConnectionString);
            SqlCommand command = connection.CreateCommand();
            command.CommandText = sqlSelect;
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = command;
            DataTable table = new DataTable();
            //MessageBox.Show(sqlSelect, "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            adapter.Fill(table);
            dataGridView3.DataSource = table;
            if (table.Rows.Count == 0)
                MessageBox.Show("Нет значений.", "Информация.", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
