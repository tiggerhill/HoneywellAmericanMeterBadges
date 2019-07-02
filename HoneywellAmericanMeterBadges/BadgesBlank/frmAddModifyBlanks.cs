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
    public partial class frmAddModifyBlanks : Form
    {
        public frmAddModifyBlanks()
        {
            InitializeComponent();
        }

        public bool addBlank;
        public BlankBadges blank;

        private void frmAddModifyBlanks_Load(object sender, EventArgs e)
        {
            // This line of code loads data into the 'honeywellAmericanMeterBadgesDataSet.Statuses' table. You can move, or remove it, as needed.
            this.statusesTableAdapter.Fill(this.honeywellAmericanMeterBadgesDataSet.Statuses);
            if (addBlank)
            {
                this.Text = "Add Blank Badge";
            }
            else
            {
                this.Text = "Modify Blank Badge";
                txtBlankNumber.Enabled = false;
                this.DisplayBlank();
            }
        }

        private void DisplayBlank()
        {
            txtBlankNumber.Text = blank.BlankBadgeNumber;
            txtBlankDesc.Text = blank.BlankDescription;
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            if (IsValidData())
            {
                if (addBlank)
                {
                    blank = new BlankBadges();
                    this.PutBlankData(blank);
                    try
                    {
                        BlankBadgesDB.AddBlankBadge(blank);
                        MessageBox.Show("Operation successful.", "Successful", MessageBoxButtons.OK,
                            MessageBoxIcon.None);
                        this.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, ex.GetType().ToString());
                    }
                }
                else
                {
                    BlankBadges newBlank = new BlankBadges
                    {
                        BlankBadgeNumber = blank.BlankBadgeNumber
                    };
                    this.PutBlankData(newBlank);
                    try
                    {
                        if (!BlankBadgesDB.UpdateBlank(blank, newBlank))
                        {
                            MessageBox.Show("?", "Database Error");
                            this.DialogResult = DialogResult.Retry;
                        }
                        else
                        {
                            blank = newBlank;
                            this.DialogResult = DialogResult.OK;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, ex.GetType().ToString());
                    }
                }
            }
        }

        private bool IsValidData()
        {
            return
                Validator.IsPresent(txtBlankNumber) &&
                Validator.IsPresent(txtBlankDesc) &&
                Validator.IsPresent(cbStatus);
        }

        private void PutBlankData(BlankBadges blank)
        {
            blank.BlankBadgeNumber = txtBlankNumber.Text;
            blank.BlankDescription = txtBlankDesc.Text;
            blank.BlankStatus = cbStatus.SelectedValue.ToString();
            // TODO - finish this section
        }

    }
}
