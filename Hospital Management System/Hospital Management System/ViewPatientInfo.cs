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
    public partial class ViewPatientInfo : Form
    {
        SqlConnection cn = new SqlConnection("Data Source=TANMOY\\SQLEXPRESS;Initial Catalog=HospitalDb;Integrated Security=True");


        private SqlCommand cmd = new SqlCommand();
        private SqlDataReader dr;
        private SqlParameter picture;

       

        public ViewPatientInfo()
        {
            InitializeComponent();

        }



       /* void Fillcombo()
        {
            String con = "Data Source=Asif-PC\\SQLEXPRESS;Integrated Security=True";
            String query="select * from Patient";
            SqlConnection conDataBase=new SqlConnection(con);
            SqlCommand cmd=new SqlCommand(query,conDataBase);
            SqlDataReader myReader;



            try
            {
                conDataBase.Open();
                myReader=cmd.ExecuteReader();

                while(myReader.Read())
                {
                    int pId=myReader.GetString("PatientId");
                    comboBox1.Items.Add(pId);
                }

            }
            catch{}

        }*/




        void Display()
        {
            SqlDataAdapter sda = new SqlDataAdapter("select * from Patient", cn);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.Rows.Clear();
            foreach (DataRow item in dt.Rows)
            {
                int n = dataGridView1.Rows.Add();
                dataGridView1.Rows[n].Cells[0].Value = item["PatientId"].ToString();
                dataGridView1.Rows[n].Cells[1].Value = item[1].ToString();
                dataGridView1.Rows[n].Cells[2].Value = item[2].ToString();
                dataGridView1.Rows[n].Cells[3].Value = item[3].ToString();
                dataGridView1.Rows[n].Cells[4].Value = item[4].ToString();
                dataGridView1.Rows[n].Cells[5].Value = item[5].ToString();
                dataGridView1.Rows[n].Cells[6].Value = item[6].ToString();
                dataGridView1.Rows[n].Cells[7].Value = item[7].ToString();
                dataGridView1.Rows[n].Cells[8].Value = item[8].ToString();
                dataGridView1.Rows[n].Cells[9].Value = item[9].ToString();
            }


            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
            textBox9.Text = "";
        }





        /*private void loadpicture()
        {
            cn.Open();

            int n = dataGridView1.Rows.Add();
            cmd.CommandText = "select PatientImg from Patient where Patientid='" + dataGridView1.Rows[n].Cells[0].Value + "'";
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            SqlCommandBuilder cbd = new SqlCommandBuilder(da);
            DataSet ds = new DataSet();
            da.Fill(ds);
            cn.Close();
            byte[] ap = (byte[])(ds.Tables[0].Rows[0]["PatientImg"]);
            MemoryStream ms = new MemoryStream(ap);
            pictureBox1.Image = Image.FromStream(ms);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.BorderStyle = BorderStyle.Fixed3D;
            //label1.Text = listBox2.Text.ToString();
            ms.Close();
        }*/





        private void Form3_Load(object sender, EventArgs e)
        {
            cn.ConnectionString = @"Data Source=TANMOY\SQLEXPRESS;Initial Catalog=HospitalDb;Integrated Security=True";
            cmd.Connection = cn;

            picture = new SqlParameter("@picture", SqlDbType.Image);

            //loadpicture();
            Display();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            PatientZone pz = new PatientZone();
            pz.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            cn.Open();

           SqlCommand cmd=new SqlCommand(@"UPDATE Patient SET PatientName='" + textBox2.Text+ "',GardianName='" + textBox3.Text + "',Age='" + textBox4.Text + "',Gender='" + textBox5.Text + "',PresentAddress='" + textBox6.Text + "',PhoneNumber='" + textBox7.Text + "',CabinNo='" + textBox8.Text + "',Disease='" + textBox9.Text + "' WHERE (PatientId=" + textBox1.Text + ")",cn);

            cmd.ExecuteNonQuery();
            cn.Close();

            Display();
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
                    label1.Text = f.SafeFileName.ToString();
                }
            }
            catch { }
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

            textBox8.Text = dataGridView1.SelectedRows[0].Cells[7].Value.ToString();
            textBox9.Text = dataGridView1.SelectedRows[0].Cells[8].Value.ToString();







            try
            {
                SqlConnection cn = new SqlConnection("Data Source=TANMOY\\SQLEXPRESS;Initial Catalog=HospitalDb;Integrated Security=True");
                cn.Open();

                //Retrieve BLOB from database into DataSet.
                SqlCommand cmd = new SqlCommand("SELECT PatientImg FROM Patient", cn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds, "Patient");
                int c = ds.Tables["Patient"].Rows.Count;

                if (c > 0)
                {   //BLOB is read into Byte array, then used to construct MemoryStream,
                    //then passed to PictureBox.
                    Byte[] byteBLOBData = new Byte[0];
                    byteBLOBData = (Byte[])(ds.Tables["Patient"].Rows[0]["PatientImg"]);
                    MemoryStream stmBLOBData = new MemoryStream(byteBLOBData);
                    pictureBox1.Image = Image.FromStream(stmBLOBData);
                }
                cn.Close();
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message); }


        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           


        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            OpenFileDialog opf = new OpenFileDialog();            
            opf.Filter = "Choose Image(*.jpg; *.png; *.gif)|*.jpg; *.png; *.gif";            
            if (opf.ShowDialog() == DialogResult.OK)            
            {                 pictureBox1.Image = Image.FromFile(opf.FileName);  
            }

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            cn.Open();

            cmd.CommandText = "DELETE FROM Patient WHERE(PatientId = " + textBox1.Text + ")";

            cmd.ExecuteNonQuery();
            cn.Close();

            Display();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
        
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

        private void textBox8_KeyPress(object sender, KeyPressEventArgs e)
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
