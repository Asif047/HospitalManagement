using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Data.SqlClient;

namespace Hospital_Management_System
{
    public partial class InsertDoctorInfo : Form
    {

        private SqlConnection cn = new SqlConnection("Data Source=TANMOY\\SQLEXPRESS;Initial Catalog=HospitalDb;Integrated Security=True");
        private SqlCommand cmd = new SqlCommand();


        public InsertDoctorInfo()
        {
            InitializeComponent();
        }

        private void Doctors1_Load(object sender, EventArgs e)
        {
            cn.ConnectionString = @"Data Source=TANMOY\SQLEXPRESS;Initial Catalog=HospitalDb;Integrated Security=True";
            cmd.Connection = cn;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            Doctorszone pz = new Doctorszone();
            pz.Show();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {


           
            cn.Open();
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && textBox5.Text != "")
            {


                if ((textBox5.Text.Length > 11 || textBox5.Text.Length < 11) || (textBox4.Text.Length > 11 || textBox4.Text.Length < 11))
                    MessageBox.Show("Phone number must of 11 character long");

                else
                {
                    cmd.CommandText = "insert into Doctor (DoctorName,Department,Address,PhoneNo,EmergencyNo,AuthorizedWard) values ('" + textBox1.Text.ToString() + "','" + textBox2.Text.ToString() + "','" + textBox3.Text.ToString() + "','" + textBox4.Text.ToString() + "','" + textBox5.Text.ToString() + "','" + textBox6.Text.ToString() + "')";

                    MessageBox.Show("Information Saved");
                    cmd.ExecuteNonQuery();

                }


               
            }

            else
            {
                MessageBox.Show("Please insert all informations");
            }


            cn.Close();

            //pictureBox1.Image = null;


           

        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
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
