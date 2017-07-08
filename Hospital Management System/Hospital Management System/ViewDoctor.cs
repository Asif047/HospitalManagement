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
    public partial class ViewDoctor : Form
    {

        SqlConnection cn = new SqlConnection("Data Source=TANMOY\\SQLEXPRESS;Initial Catalog=HospitalDb;Integrated Security=True");


        private SqlCommand cmd = new SqlCommand();

        public ViewDoctor()
        {
            InitializeComponent();
        }



        void Display()
        {
            SqlDataAdapter sda = new SqlDataAdapter("select * from Doctor", cn);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.Rows.Clear();
            foreach (DataRow item in dt.Rows)
            {
                int n = dataGridView1.Rows.Add();
                dataGridView1.Rows[n].Cells[0].Value = item["DoctorId"].ToString();
                dataGridView1.Rows[n].Cells[1].Value = item[1].ToString();
                dataGridView1.Rows[n].Cells[2].Value = item[2].ToString();
                dataGridView1.Rows[n].Cells[3].Value = item[3].ToString();
                dataGridView1.Rows[n].Cells[4].Value = item[4].ToString();
                dataGridView1.Rows[n].Cells[5].Value = item[5].ToString();
                dataGridView1.Rows[n].Cells[6].Value = item[6].ToString();
               
            }


            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
           
        }




        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void ViewDoctor_Load(object sender, EventArgs e)
        {
            cn.ConnectionString = @"Data Source=TANMOY\SQLEXPRESS;Initial Catalog=HospitalDb;Integrated Security=True";
            cmd.Connection = cn;

            Display();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            Doctorszone pz = new Doctorszone();
            pz.Show();
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            textBox1.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            textBox4.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            textBox5.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            textBox6.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
            textBox7.Text = dataGridView1.SelectedRows[0].Cells[6].Value.ToString();

          
        }

        private void UpdateDoctor_Click(object sender, EventArgs e)
        {
            cn.Open();

            SqlCommand cmd = new SqlCommand(@"UPDATE Doctor SET DoctorName='" + textBox2.Text + "',Department='" + textBox3.Text + "',Address='" + textBox4.Text + "',PhoneNo='" + textBox5.Text + "',EmergencyNo='" + textBox6.Text + "',AuthorizedWard='" + textBox7.Text + "' WHERE (DoctorId=" + textBox1.Text + ")", cn);

            cmd.ExecuteNonQuery();
            cn.Close();

            Display();
        }

        private void DeleteDoctor_Click(object sender, EventArgs e)
        {
            cn.Open();

            cmd.CommandText = "DELETE FROM Doctor WHERE(DoctorId = " + textBox1.Text + ")";

            cmd.ExecuteNonQuery();
            cn.Close();

            Display();
        }

        private void label1_Click(object sender, EventArgs e)
        {

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

        private void textBox7_KeyPress(object sender, KeyPressEventArgs e)
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
