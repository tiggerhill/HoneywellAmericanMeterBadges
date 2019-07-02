using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HoneywellAmericanMeterBadges.Customers
{
    public partial class frmCustomers : Form
    {
        public frmCustomers()
        {
            InitializeComponent();
        }

        private Customers custDetails;

        private void FrmCustomers_Load(object sender, EventArgs e)
        {
            // This line of code loads data into the 'honeywellAmericanMeterBadgesDataSet.Customers' table. You can move, or remove it, as needed.
            this.customersTableAdapter.Fill(this.honeywellAmericanMeterBadgesDataSet.Customers);
        }

        private void BtnGetDetails_Click(object sender, EventArgs e)
        {
            if (Validator.IsPresent(txtCustomerNumber))
            {
                string customerNumber = txtCustomerNumber.Text;
                this.GetCustomerDetails(customerNumber);
                if (custDetails == null)
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
                    txtName.Text = custDetails.CustomerName;
                    txtNotes.Text = custDetails.CustomerNotes;
                    txtStatus.Text = custDetails.CustomerStatus;
                    txtRequirement.Text = custDetails.RequirementCode;
                }
            }
        }

        private void GetCustomerDetails(string custNumber)
        {
            try
            {
                custDetails = CustomersDB.GetCustomerDetails(custNumber);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString());
            }
        }

        private void ClearCustomerForm()
        {
            txtCustomerNumber.Text = "";
            txtName.Text = "";
            txtNotes.Text = "";
            txtStatus.Text = "";
            btnAdd.Enabled = false;
            btnDelete.Enabled = false;
            btnModify.Enabled = false;
            txtCustomerNumber.Focus();
        }


        private void BtnDelete_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This button will eventually change Customer Status to Inactive");
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            frmAddModifyCustomers form = new frmAddModifyCustomers
            {
                addCustomer = true
                // TODO pass customer # from referring form
            };
            DialogResult result = form.ShowDialog();
            if (result == DialogResult.OK)
            {
                custDetails = form.customer;
            }
        }

        private void BtnModify_Click(object sender, EventArgs e)
        {
            frmAddModifyCustomers form = new frmAddModifyCustomers
            {
                addCustomer = false,
                customer = custDetails
            };
            DialogResult result = form.ShowDialog();
            if (result == DialogResult.OK)
            {
                custDetails = form.customer;
            }
        }

        public void DisplayResults()
        {
            txtName.Text = custDetails.CustomerName;
            txtNotes.Text = custDetails.CustomerNotes;
        }
    }
}
