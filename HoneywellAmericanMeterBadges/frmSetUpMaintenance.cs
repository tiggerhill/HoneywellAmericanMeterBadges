using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HoneywellAmericanMeterBadges
{
    public partial class frmSetUpMaintenance : Form
    {
        public frmSetUpMaintenance()
        {
            InitializeComponent();
        }

        private void BtnCustomers_Click(object sender, EventArgs e)
        {
            Form form = new Customers.frmCustomers();
            form.ShowDialog();
        }

        private void BtnRequirements_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Button not yet functional", "Button");
        }

        private void BtnFinishedBadges_Click(object sender, EventArgs e)
        {
            //Form form = new FinshedBadges.frmFinishedBadges();
            //form.ShowDialog();
        }

        private void BtnBlankBadges_Click(object sender, EventArgs e)
        {
            Form form = new BlankBadges.frmBlanks();
            form.ShowDialog();
        }

        private void BtnStatuses_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Button not yet functional", "Button");
        }
    }
}
