using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hospital_Management_System
{
    public partial class PatientZone : Form
    {
        public PatientZone()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
            StartingOptions so = new StartingOptions();
            so.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            InsertPatientInfo ip = new InsertPatientInfo();
            ip.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            ViewPatientInfo vp = new ViewPatientInfo();
            vp.Show();
        }
    }
}
