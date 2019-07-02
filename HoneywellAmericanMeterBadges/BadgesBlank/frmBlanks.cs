using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HoneywellAmericanMeterBadges.BlankBadges
{
    public partial class frmBlanks : Form
    {
        public frmBlanks()
        {
            InitializeComponent();
        }

        private BlankBadges blankDetails;

        private void frmBlanks_Load(object sender, EventArgs e)
        {
            // This line of code loads data into the 'honeywellAmericanMeterBadgesDataSet.BlankBadgeNumbers' table. You can move, or remove it, as needed.
            this.blankBadgeNumbersTableAdapter.Fill(this.honeywellAmericanMeterBadgesDataSet.BlankBadgeNumbers);
        }

        private void BtnGetDetails_Click(object sender, EventArgs e)
        {
            if (Validator.IsPresent(txtBlankPartNumber))
            {
                string blankNumber = txtBlankPartNumber.Text;
                this.GetBlankDetails(blankNumber);
                if (blankDetails == null)
                {
                    MessageBox.Show("No info found.", "Not Found");
                    btnAdd.Enabled = true;
                    btnModify.Enabled = false;
                    btnDelete.Enabled = false;
                }
                else
                {
                    btnModify.Enabled = true;
                    btnDelete.Enabled = true;
                    btnAdd.Enabled = false;
                    txtDescription.Text = blankDetails.BlankDescription;
                    txtStatus.Text = blankDetails.BlankStatus;
                }
            }
        }

        private void GetBlankDetails(string blankNumber)
        {
            try
            {
                blankDetails = BlankBadgesDB.GetBlankDetails(blankNumber);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString());
            }
        }

        private void ClearBlankForm()
        {
            txtBlankPartNumber.Text = "";
            txtDescription.Text = "";
            txtStatus.Text = "";
            btnAdd.Enabled = false;
            btnModify.Enabled = false;
            btnDelete.Enabled = false;
            txtBlankPartNumber.Focus();
        }

        public void DisplayResults()
        {
            txtDescription.Text = blankDetails.BlankDescription;
            txtStatus.Text = blankDetails.BlankStatus;
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            frmAddModifyBlanks form = new frmAddModifyBlanks
            {
                addBlank = true
            };
            DialogResult result = form.ShowDialog();
            if (result == DialogResult.OK)
            {
                blankDetails = form.blank;
            }
        }
        
        // TODO - how to get the Orders visual list to auto-refresh
        //private void BtnRefresh_Click(object sender, EventArgs e)
        //{
        //    this.Close();
        //    //Form form = new frmBlanks();
        //    //form.ShowDialog();
        //}


        private void BtnModify_Click(object sender, EventArgs e)
        {
            frmAddModifyBlanks form = new frmAddModifyBlanks
            {
                addBlank = false,
                blank = blankDetails
            };
            DialogResult result = form.ShowDialog();
            if (result == DialogResult.OK)
            {
                blankDetails = form.blank;
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Delete " + blankDetails.BlankBadgeNumber + "?",
                "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                try
                {
                    if (! BlankBadgesDB.DeleteBlankBadge(blankDetails))
                    {
                        MessageBox.Show("!", "Database Error");
                        this.GetBlankDetails(blankDetails.BlankBadgeNumber);
                        if (blankDetails != null)
                        {
                            this.DisplayResults();
                        }
                        else
                        {
                            this.ClearBlankForm();
                        }
                    }
                    else
                    {
                        this.ClearBlankForm();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, ex.GetType().ToString());
                }
            }
            
        }
       
    }
}
