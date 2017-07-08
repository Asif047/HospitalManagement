using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.IO;


using System.Data.SqlClient;

namespace Hospital_Management_System
{
    public partial class InsertPatientInfo : Form
    {

        private SqlConnection cn = new SqlConnection();
        private SqlCommand cmd = new SqlCommand();
        private SqlDataReader dr;
        private SqlParameter picture;


        public InsertPatientInfo()
        {
            InitializeComponent();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            PatientZone pz = new PatientZone();
            pz.Show();
        }




        private void open()
        {
            try
            {
                OpenFileDialog f = new OpenFileDialog();
                f.InitialDirectory = "F:/Picture/";
                f.Filter = "All Files|*.*|JPEGs|*.jpg|Bitmaps|*.bmp|GIFs|*.gif";
                f.FilterIndex = 2;
                if (f.ShowDialog() == DialogResult.OK)
                {
                    pictureBox1.Image = Image.FromFile(f.FileName);
                    pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                    pictureBox1.BorderStyle = BorderStyle.Fixed3D;
                    //label1.Text = f.SafeFileName.ToString();
                }
            }
            catch { }
        }



        private void BrowseButton_Click(object sender, EventArgs e)
        {
            open();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {


            MemoryStream ms = new MemoryStream();
            pictureBox1.Image.Save(ms, pictureBox1.Image.RawFormat);
            byte[] a = ms.GetBuffer();
            ms.Close();
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@picture", a);
            cn.Open();
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" )
            {
                if (textBox5.Text.Length > 11 || textBox5.Text.Length < 11)
                    MessageBox.Show("Phone number must of 11 character long");
                else
                {
                    cmd.CommandText = "insert into Patient (PatientName,GardianName,Age,Gender,PresentAddress,PhoneNumber,CabinNo,Disease,PatientImg) values ('" + textBox1.Text.ToString() + "','" + textBox2.Text.ToString() + "','" + textBox3.Text.ToString() + "','" + comboBox1.Text.ToString() + "','" + textBox4.Text.ToString() + "','" + textBox5.Text.ToString() + "','" + textBox6.Text.ToString() + "','" + textBox7.Text.ToString() + "',@picture)";

                    MessageBox.Show("Information Saved");
                    cmd.ExecuteNonQuery();
                }
             
               
            }

            else
            {
                MessageBox.Show("Please insert all informations");
            }
            
           
            cn.Close();
            
            pictureBox1.Image = null;
           


          
           

        }

        private void InsertPatientInfo_Load(object sender, EventArgs e)
        {
            cn.ConnectionString = @"Data Source=TANMOY\SQLEXPRESS;Initial Catalog=HospitalDb;Integrated Security=True";
            cmd.Connection = cn;
            
            picture = new SqlParameter("@picture", SqlDbType.Image);
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
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
    }
}
