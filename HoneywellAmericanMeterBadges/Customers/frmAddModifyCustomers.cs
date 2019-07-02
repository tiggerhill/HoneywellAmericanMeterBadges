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
    public partial class frmAddModifyCustomers : Form
    {
        public frmAddModifyCustomers()
        {
            InitializeComponent();
        }

        public bool addCustomer;
        public Customers customer;

        private void FrmAddModifyCustomers_Load(object sender, EventArgs e)
        {
            // This line of code loads data into the 'honeywellAmericanMeterBadgesDataSet.Requirements' table. You can move, or remove it, as needed.
            this.requirementsTableAdapter.Fill(this.honeywellAmericanMeterBadgesDataSet.Requirements);
            if (addCustomer)
            {
                this.Text = "Add Customer Details";
            }
            else
            {
                this.Text = "Modify Customer Details";
                txtCustomerNumber.Enabled = false;
                this.DisplayCustomer();
            }
        }

        private void DisplayCustomer()
        {
            txtCustomerNumber.Text = customer.CustomerNumber;
            txtCustomerName.Text = customer.CustomerName;
            txtCustomerNotes.Text = customer.CustomerNotes;
        }

        private void BtnAccept_Click(object sender, EventArgs e)
        {
            if (IsValidData())
            {
                if (addCustomer)
                {
                    customer = new Customers();
                    this.PutCustomerData(customer);
                    try
                    {
                        CustomersDB.AddCustomer(customer);
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
                    Customers updateCustomer = new Customers
                    {
                        //CustomerNumber = customer.CustomerNumber
                    };
                    this.PutCustomerData(updateCustomer);
                    try
                    {
                        if (!CustomersDB.UpdateCustomer(customer, updateCustomer))
                        {
                            MessageBox.Show("?", "Database Error");
                            this.DialogResult = DialogResult.Retry;
                        }
                        else
                        {
                            customer = updateCustomer;
                            MessageBox.Show("Operation successful.", "Successful", MessageBoxButtons.OK, 
                                MessageBoxIcon.None);
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
                Validator.IsPresent(txtCustomerNumber) &&
                Validator.IsPresent(txtCustomerName);
        }

        private void PutCustomerData(Customers customer)
        {
            customer.CustomerNumber = txtCustomerNumber.Text;
            customer.CustomerName = txtCustomerName.Text;
            customer.CustomerNotes = txtCustomerNotes.Text;
            customer.CustomerStatus = cboCustStatus.SelectedItem.ToString();
            customer.RequirementCode = cboRequirement.SelectedValue.ToString();
        }
    }
}
