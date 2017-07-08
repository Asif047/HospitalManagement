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
    public partial class Staffzone : Form
    {
        public Staffzone()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            StaffInsert pz = new StaffInsert();
            pz.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            StaffView pz = new StaffView();
            pz.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
            StartingOptions pz = new StartingOptions();
            pz.Show();
        }
    }
}
