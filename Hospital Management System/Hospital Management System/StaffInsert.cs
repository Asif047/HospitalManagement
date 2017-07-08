using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;

using System.Data.SqlClient;

namespace Hospital_Management_System
{
    public partial class StaffInsert : Form
    {

        private SqlConnection cn = new SqlConnection("Data Source=TANMOY\\SQLEXPRESS;Initial Catalog=HospitalDb;Integrated Security=True");
        private SqlCommand cmd = new SqlCommand();


        public StaffInsert()
        {
            InitializeComponent();
        }




        private void SaveButton_Click(object sender, EventArgs e)
        {
            cn.Open();
            if (textBox1.Text != "" && textBox5.Text != "" && textBox6.Text != "" && comboBox1.Text != "")
            {

                if ((textBox5.Text.Length > 11 || textBox5.Text.Length < 11) || (textBox6.Text.Length > 11 || textBox6.Text.Length < 11))
                    MessageBox.Show("Phone number must of 11 character long");

                else
                {
                    cmd.CommandText = "insert into Staff (StaffName,Gender,Age,Post,Address,PhoneNumber,EmergencyNumber) values ('" + textBox1.Text.ToString() + "','" + comboBox1.Text.ToString() + "','" + textBox2.Text.ToString() + "','" + textBox3.Text.ToString() + "','" + textBox4.Text.ToString() + "','" + textBox5.Text.ToString() + "','" + textBox6.Text.ToString() + "')";

                    MessageBox.Show("Information Saved");
                    cmd.ExecuteNonQuery();
                }
                
            }

            else
            {
                MessageBox.Show("Please insert all informations");
            }

            cn.Close();


}
        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void BrowseButton_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            this.Close();
            Staffzone pz = new Staffzone();
            pz.Show();
        }

        private void StaffInsert_Load(object sender, EventArgs e)
        {
            cn.ConnectionString = @"Data Source=TANMOY\SQLEXPRESS;Initial Catalog=HospitalDb;Integrated Security=True";
            cmd.Connection = cn;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar) || e.KeyChar == 8)
            {
                e.Handled = false;

            }
            else
            {
                e.Handled = true;
            }
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar) || e.KeyChar == 8)
            {
                e.Handled = false;

            }
            else
            {
                e.Handled = true;
            }
        }

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar) || e.KeyChar == 8)
            {
                e.Handled = false;

            }
            else
            {
                e.Handled = true;
            }
        }
    }
}
