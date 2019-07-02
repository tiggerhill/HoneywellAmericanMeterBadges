using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace HoneywellAmericanMeterBadges.Orders
{
    public partial class frmOrders : Form
    {
        public frmOrders()
        {
            InitializeComponent();
        }
        private void FrmOrders_Load(object sender, EventArgs e)
        {
            // This line of code loads data into the 'honeywellAmericanMeterBadgesDataSet.Requirements' table. You can move, or remove it, as needed.
            this.requirementsTableAdapter.Fill(this.honeywellAmericanMeterBadgesDataSet.Requirements);
            // This line of code loads data into the 'honeywellAmericanMeterBadgesDataSet.FinishedBadgeNumbersCUST' table. You can move, or remove it, as needed.
            this.finishedBadgeNumbersCUSTTableAdapter.Fill(this.honeywellAmericanMeterBadgesDataSet.FinishedBadgeNumbersCUST);
            // This line of code loads data into the 'honeywellAmericanMeterBadgesDataSet.FinishedBadgeNumbersMFG' table. You can move, or remove it, as needed.
            this.finishedBadgeNumbersMFGTableAdapter.Fill(this.honeywellAmericanMeterBadgesDataSet.FinishedBadgeNumbersMFG);
            this.ClearCustBadgeData();
            this.ClearMfgBadgeData();
        }

        private Order order;
        private Customers.Customers customer;
        private Check4Duplicates duplicates;
        private Order mfgSerials;
        private Order custSerials;
        private BadgesFinished.FinishedBadge finishedDetailsMFG;
        private BadgesFinished.FinishedBadge finishedDetailsCUST;

        // global variables to pass info to add/modify orders form
        public static string SetValueForOrderNumber = "";
        public static string SetValueForCustomerNumber = "";
        public static string SetValueForOrderNotes = "";

        private void BtnEnterOrderNumber_Click(object sender, EventArgs e)
        {
            if (Validator.IsPresent(txtOrderNumber))
            {
                SetOrderForm();
                EnterOrderNumber();
            }
            else
            {
                // nothing needed
            }
        }
        private void EnterOrderNumber()
        {
            string orderNumber = txtOrderNumber.Text;

            this.GetOrderDetails(orderNumber);

            if (order == null)
            {
                btnAddOrder.Enabled = true;
            }
            else
            {
                string customerNumber = order.CustomerNumber;
                this.GetCustomerDetails(customerNumber);

                btnModifyOrder.Enabled = true;
                btnDeleteOrder.Enabled = true;
                txtCustNumber.Text = order.CustomerNumber;
                txtCustName.Text = customer.CustomerName;
                txtOrderNotes.Text = order.OrderNotes;
                txtCustNotes.Text = customer.CustomerNotes;
                txtReqCode.Text = customer.RequirementCode;

                if (order.MfgQuantity > 0)
                {
                    cboMfgFinished.Text = order.MfgFinishedBadge;
                    cboMfgRequirement.Text = order.MfgRequirementCode;
                    txtMfgYear.Text = order.MfgYear;
                    if (order.MfgYearInclude == "Y")
                    {
                        rbMfgYearYes.Checked = true;
                    }
                    else
                    {
                        rbMfgYearNo.Checked = true;
                    }
                    txtMfgPrefix.Text = order.MfgPrefix;
                    if (order.MfgPrefixInclude == "Y")
                    {
                        rbMfgPrefixYes.Checked = true;
                    }
                    else
                    {
                        rbMfgPrefixNo.Checked = true;
                    }
                    txtMfgBeginning.Text = order.MfgBeginningSerial.ToString();
                    txtMfgEnding.Text = order.MfgEndingSerial.ToString();
                    txtMfgCount.Text = order.MfgQuantity.ToString();
                    txtMfgBadgeNotes.Text = order.MfgNotes;

                    string statusMfg = order.MfgStatus;
                    lblMfgStatusIntro.Visible = true;
                    lblMfgStatus.Visible = true;
                    lblMfgStatus.Text = statusMfg;
                    if (statusMfg == "RESERVED" || statusMfg == "Reserved")
                    {
                        lblMfgStatusChange.Visible = true;
                        btnMfgStatusChange.Visible = true;
                    }

                    btnAddMfgBadges.Enabled = false;
                    btnModifyMfgBadges.Enabled = true;
                    btnDeleteMfgBadges.Enabled = true;
                }
                else
                {
                    this.ClearMfgBadgeData();
                    btnAddMfgBadges.Enabled = true;
                    btnModifyMfgBadges.Enabled = false;
                    btnDeleteMfgBadges.Enabled = false;
                }

                if (order.CustQuantity > 0)
                {
                    cboCustFinished.Text = order.CustFinishedBadge;
                    txtCustPrefix.Text = order.CustPrefix;
                    if (order.CustPrefixInclude == "Y")
                    {
                        rbCustPrefixYes.Checked = true;
                    }
                    else
                    {
                        rbCustPrefixNo.Checked = true;
                    }
                    txtCustSuffix.Text = order.CustSuffix;
                    if (order.CustSuffixInclude == "Y")
                    {
                        rbCustPrefixYes.Checked = true;
                    }
                    else
                    {
                        rbCustSuffixNo.Checked = true;
                    }
                    txtCustBeginning.Text = order.CustBeginningSerial.ToString();
                    txtCustEnding.Text = order.CustEndingSerial.ToString();
                    txtCustCount.Text = order.CustQuantity.ToString();
                    txtCustBadgeNotes.Text = order.CustNotes;

                    string statusCust = order.CustStatus;
                    lblCustStatusIntro.Visible = true;
                    lblCustStatus.Visible = true;
                    lblCustStatus.Text = statusCust;
                    if (statusCust == "RESERVED" || statusCust == "Reserved")
                    {
                        lblCustStatusChange.Visible = true;
                        btnCustStatusChange.Visible = true;
                    }

                    btnAddCustBadges.Enabled = false;
                    btnModifyCustBadges.Enabled = true;
                    btnDeleteCustBadges.Enabled = true;
                }
                else
                {
                    this.ClearCustBadgeData();
                    btnAddCustBadges.Enabled = true;
                    btnModifyCustBadges.Enabled = false;
                    btnDeleteCustBadges.Enabled = false;
                }
            }
        }
        private void SetOrderForm()
        {
            // ensure clean start
            SetValueForOrderNumber = txtOrderNumber.Text;
            txtOrderNotes.Text = "";
            txtCustNumber.Text = "";
            txtCustName.Text = "";
            txtCustNotes.Text = "";
            btnAddOrder.Enabled = false;
            btnModifyOrder.Enabled = false;
            btnDeleteOrder.Enabled = false;
            this.ClearMfgBadgeData();
            this.ClearCustBadgeData();            
        }
        private void GetOrderDetails(string orderNumber)
        {
            try
            {
                order = OrdersDB.GetOrderDetails(orderNumber);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString());
            }
        }
        private void GetCustomerDetails(string customerNumber)
        {
            try
            {
                customer = Customers.CustomersDB.GetCustomerDetails(customerNumber);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString());
            }
        }
        private void BtnAddOrder_Click(object sender, EventArgs e)
        {
            SetValueForCustomerNumber = txtOrderNumber.Text;

            frmAddModifyOrders form = new frmAddModifyOrders
            {
                addOrder = true
            };
            DialogResult result = form.ShowDialog();
            if (result == DialogResult.OK)
            {
                order = form.order;
            }
        }
        private void BtnModifyOrder_Click(object sender, EventArgs e)
        {
            SetValueForCustomerNumber = txtCustNumber.Text;
            SetValueForOrderNumber = txtOrderNumber.Text;
            SetValueForOrderNotes = txtOrderNotes.Text;

            frmAddModifyOrders form = new frmAddModifyOrders
            {
                addOrder = false
            };
            DialogResult result = form.ShowDialog();
            if (result == DialogResult.OK)
            {
                order = form.order;
            }
        }
        private void BtnAddMfgBadges_Click(object sender, EventArgs e)
        {
            cboMfgFinished.Enabled = true;
            lblMfgBlank.Enabled = true;
            cboMfgRequirement.Enabled = true;
            txtMfgYear.Enabled = true;
            gbMfgYear.Enabled = true;
            gbMfgPrefix.Enabled = true;
            rbMfgYearYes.Enabled = true;
            rbMfgYearNo.Enabled = true;
            txtMfgPrefix.Enabled = true;
            rbMfgPrefixYes.Enabled = true;
            rbMfgPrefixNo.Enabled = true;
            txtMfgBeginning.Enabled = true;
            txtMfgEnding.Enabled = true;
            txtMfgCount.Enabled = true;
            txtMfgBadgeNotes.Enabled = true;
            btnMfgVerify.Enabled = true;
            btnMfgCancel.Enabled = true;
            
            // add some defaults to make testing easier
            txtMfgYear.Text = "19";
            txtMfgPrefix.Text = "Z";
            txtMfgBeginning.Text = "51";
            txtMfgEnding.Text = "100";
            txtMfgCount.Text = "50";
            txtMfgBadgeNotes.Text = "details added to make dev testing quicker";
        }
        private void BtnAddCustomerBadges_Click(object sender, EventArgs e)
        {
            cboCustFinished.Enabled = true;
            lblCustBlank.Enabled = true;
            txtCustPrefix.Enabled = true;
            gbCustPrefix.Enabled = true;
            gbCustSuffix.Enabled = true;
            rbCustPrefixYes.Enabled = true;
            rbCustPrefixNo.Enabled = true;
            txtCustSuffix.Enabled = true;
            rbCustSuffixYes.Enabled = true;
            rbCustSuffixNo.Enabled = true;
            txtCustBeginning.Enabled = true;
            txtCustEnding.Enabled = true;
            txtCustCount.Enabled = true;
            txtCustBadgeNotes.Enabled = true;
            btnCustVerify.Enabled = true;
            btnCustCancel.Enabled = true;
        }        
        private void BtnMfgVerify_Click(object sender, EventArgs e)
        {
            if (IsValidMfgBadgeEntries())
            {
                string prefix = Convert.ToString(txtMfgPrefix.Text);
                char includePrefix = 'N';
                if (prefix != "")
                {
                    if (rbMfgPrefixYes.Checked == true)
                    {
                        includePrefix = 'Y';
                    }
                }

                char includeYear = 'N';
                if (rbMfgYearYes.Checked == true)
                {
                    includeYear = 'Y';
                }                

                // if verifying the serial numbers ONLY:
                if (includePrefix == 'N' && includeYear == 'N')
                {
                    MfgVerifySerialsOnly();
                }

                // if verifying the prefix with the serial numbers
                else if (includePrefix == 'Y' && includeYear == 'N')
                {
                    MfgVerifySerialsAndPrefix();
                }

                // if verifying the year with the serial numbers
                else if (includePrefix == 'N' && includeYear == 'Y')
                {
                    MfgVerifySerialsAndYear();
                }

                // if verifying the prefix with the serial numbers and year
                else if (includePrefix == 'Y' && includeYear == 'Y')
                {
                    MfgVerifySerialsPrefixAndYear();
                }
            }
            else
            {
                btnMfgSave.Enabled = false;
            }
        }
        private void MfgVerifySerialsPrefixAndYear()
        {
            int mfgBeginning = Convert.ToInt32(txtMfgBeginning.Text);
            int mfgEnding = Convert.ToInt32(txtMfgEnding.Text);
            int mfgYear = Convert.ToInt32(txtMfgYear.Text);
            int orderNumber = Convert.ToInt32(txtOrderNumber.Text);
            string mfgPrefix = txtMfgPrefix.Text;

            try
            {
                duplicates = Duplicates.Check4DuplicatesDB.MfgVerifySerialPrefixAndYear(mfgBeginning, mfgEnding, mfgPrefix, mfgYear, orderNumber);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString());
            }

            bool duplicateResults = duplicates.DuplicatesYN;
            if (duplicateResults == true)
            {
                MessageBox.Show("There is overlap with \n\n"
                    + "    Order # " + duplicates.OrderNumber + "\n"
                    + "    Year " + duplicates.Year + "\n"
                    + "    Prefix " + duplicates.Prefix + "\n"
                    + "    Serial #'s " + duplicates.Beginning + " - " + duplicates.Ending);
                btnMfgSave.Enabled = false;
            }
            else
            {
                MessageBox.Show("There are no duplicates.  Please be certain to save this info.");
                btnMfgSave.Enabled = true;
            }
        }
        private void MfgVerifySerialsAndYear()
        {
            int mfgBeginning = Convert.ToInt32(txtMfgBeginning.Text);
            int mfgEnding = Convert.ToInt32(txtMfgEnding.Text);
            int mfgYear = Convert.ToInt32(txtMfgYear.Text);
            int orderNumber = Convert.ToInt32(txtOrderNumber.Text);
            try
            {
                duplicates = Duplicates.Check4DuplicatesDB.MfgVerifySerialandYear(mfgBeginning, mfgEnding, mfgYear, orderNumber);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString());
            }

            bool duplicateResults = duplicates.DuplicatesYN;
            if (duplicateResults == true)
            {
                MessageBox.Show("There is overlap with \n\n"
                    + "    Order # " + duplicates.OrderNumber + "\n"
                    + "    Year " + duplicates.Year + "\n"
                    + "    Serial #'s " + duplicates.Beginning + " - " + duplicates.Ending);
                btnMfgSave.Enabled = false;
            }
            else
            {
                MessageBox.Show("There are no duplicates.  Please be certain to save this info.");
                btnMfgSave.Enabled = true;
            }
        }
        private void MfgVerifySerialsAndPrefix()
        {
            int mfgBeginning = Convert.ToInt32(txtMfgBeginning.Text);
            int mfgEnding = Convert.ToInt32(txtMfgEnding.Text);
            int orderNumber = Convert.ToInt32(txtOrderNumber.Text);
            string mfgPrefix = txtMfgPrefix.Text;
            try
            {
                duplicates = Duplicates.Check4DuplicatesDB.MfgVerifySerialAndPrefix(mfgBeginning, mfgEnding, orderNumber, mfgPrefix);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString());
            }

            bool duplicateResults = duplicates.DuplicatesYN;
            if (duplicateResults == true)
            {
                MessageBox.Show("There is overlap with \n\n"
                    + "    Order # " + duplicates.OrderNumber + "\n"
                    + "    Prefix " + duplicates.Prefix + "\n"
                    + "    Serial #'s " + duplicates.Beginning + " - " + duplicates.Ending);
                btnMfgSave.Enabled = false;
            }
            else
            {
                MessageBox.Show("There are no duplicates.  Please be certain to save this info.");
                btnMfgSave.Enabled = true;
            }
        }
        private void MfgVerifySerialsOnly()
        {
            int mfgBeginning = Convert.ToInt32(txtMfgBeginning.Text);
            int mfgEnding = Convert.ToInt32(txtMfgEnding.Text);
            int orderNumber = Convert.ToInt32(txtOrderNumber.Text);
            try
            {
                duplicates = Duplicates.Check4DuplicatesDB.MfgVerifySerialOnly(mfgBeginning, mfgEnding, orderNumber);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString());
            }

            bool duplicateResults = duplicates.DuplicatesYN;
            if (duplicateResults == true)
            {
                MessageBox.Show("There is overlap with \n\n"
                    + "    Order # " + duplicates.OrderNumber + "\n"
                    + "    Prefix (N/A, or Not Included) " + "\n"
                    + "    Serial #'s " + duplicates.Beginning + " - " + duplicates.Ending);
                btnMfgSave.Enabled = false;
            }
            else
            {
                MessageBox.Show("There are no duplicates.  Please be certain to save this info.");
                btnMfgSave.Enabled = true;
            }
        }
        private void BtnCustVerify_Click(object sender, EventArgs e)
        {
            if (IsValidCustBadgeEntries())
            {
                string prefix = Convert.ToString(txtCustPrefix.Text);
                char includePrefix = 'N';
                if (prefix != "")
                {
                    if (rbCustPrefixYes.Checked == true)
                    {
                        includePrefix = 'Y';
                    }
                }
                string suffix = Convert.ToString(txtCustSuffix.Text);
                char includeSuffix = 'N';
                if (suffix != "")
                {
                    if (rbCustSuffixYes.Checked == true)
                    {
                        includeSuffix = 'Y';
                    }
                }
                // if verifying the serial numbers ONLY:
                if (includePrefix == 'N' && includeSuffix == 'N')
                {
                    CustVerifySerialsOnly();
                }
                // if verifying the prefix with the serial numbers
                else if (includePrefix == 'Y' && includeSuffix == 'N')
                {
                    CustVerifySerialsAndPrefix();
                }
                // if verifying the suffix with the serial numbers
                else if (includePrefix == 'N' && includeSuffix == 'Y')
                {
                    CustVerifySerialsAndSuffix();
                }
                // if verifying the prefix and suffix with the serial numbers
                else if (includePrefix == 'Y' && includeSuffix == 'Y')
                {
                    CustVerifySerialsPrefixAndSuffix();
                }
            }
            else
            {
                btnCustSave.Enabled = false;
            }
        }
        private void CustVerifySerialsOnly()
        {
            int custBeginning = Convert.ToInt32(txtCustBeginning.Text);
            int custEnding = Convert.ToInt32(txtCustEnding.Text);
            int orderNumber = Convert.ToInt32(txtOrderNumber.Text);
            string custNumber = txtCustNumber.Text;
            try
            {
                duplicates = Duplicates.Check4DuplicatesDB.CustVerifySerialOnly(custBeginning, custEnding, orderNumber, custNumber);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString());
            }

            bool duplicateResults = duplicates.DuplicatesYN;
            if (duplicateResults == true)
            {
                MessageBox.Show("There is overlap with \n\n"
                    + "    Order # " + duplicates.OrderNumber + "\n"
                    + "    Customer # " + duplicates.CustNumber + "\n"
                    + "    Serial #'s " + duplicates.Beginning + " - " + duplicates.Ending);
                btnCustSave.Enabled = false;
            }
            else
            {
                MessageBox.Show("There are no duplicates.  Please be certain to save this info.");
                btnCustSave.Enabled = true;
            }
        }
        private void CustVerifySerialsAndPrefix()
        {
            int custBeginning = Convert.ToInt32(txtCustBeginning.Text);
            int custEnding = Convert.ToInt32(txtCustEnding.Text);
            int orderNumber = Convert.ToInt32(txtOrderNumber.Text);
            string custNumber = txtCustNumber.Text;
            string custPrefix = txtCustPrefix.Text;
            try
            {
                duplicates = Duplicates.Check4DuplicatesDB.CustVerifySerialAndPrefix(custBeginning, custEnding, orderNumber, custNumber, custPrefix);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString());
            }

            bool duplicateResults = duplicates.DuplicatesYN;
            if (duplicateResults == true)
            {
                MessageBox.Show("There is overlap with \n\n"
                    + "    Order # " + duplicates.OrderNumber + "\n"
                    + "    Customer # " + duplicates.CustNumber + "\n"
                    + "    Prefix " + duplicates.Prefix + "\n"
                    + "    Serial #'s " + duplicates.Beginning + " - " + duplicates.Ending);
                btnCustSave.Enabled = false;
            }
            else
            {
                MessageBox.Show("There are no duplicates.  Please be certain to save this info.");
                btnCustSave.Enabled = true;
            }
        }
        private void CustVerifySerialsAndSuffix()
        {
            int custBeginning = Convert.ToInt32(txtCustBeginning.Text);
            int custEnding = Convert.ToInt32(txtCustEnding.Text);
            int orderNumber = Convert.ToInt32(txtOrderNumber.Text);
            string custNumber = txtCustNumber.Text;
            string custSuffix = txtCustSuffix.Text;
            try
            {
                duplicates = Duplicates.Check4DuplicatesDB.CustVerifySerialAndSuffix(custBeginning, custEnding, orderNumber, custSuffix, custNumber);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString());
            }

            bool duplicateResults = duplicates.DuplicatesYN;
            if (duplicateResults == true)
            {
                MessageBox.Show("There is overlap with \n\n"
                    + "    Order # " + duplicates.OrderNumber + "\n"
                    + "    Customer # " + duplicates.CustNumber + "\n"
                    + "    Suffix " + duplicates.Suffix + "\n"
                    + "    Serial #'s " + duplicates.Beginning + " - " + duplicates.Ending);
                btnCustSave.Enabled = false;
            }
            else
            {
                MessageBox.Show("There are no duplicates.  Please be certain to save this info.");
                btnCustSave.Enabled = true;
            }
        }
        private void CustVerifySerialsPrefixAndSuffix()
        {
            int custBeginning = Convert.ToInt32(txtMfgBeginning.Text);
            int custEnding = Convert.ToInt32(txtMfgEnding.Text);
            int orderNumber = Convert.ToInt32(txtOrderNumber.Text);
            string custPrefix = txtMfgPrefix.Text;
            string custSuffix = txtCustSuffix.Text;
            string custNumber = txtCustNumber.Text;

            try
            {
                duplicates = Duplicates.Check4DuplicatesDB.CustVerifySerialPrefixAndSuffix(custBeginning, custEnding, orderNumber, custPrefix, custSuffix, custNumber);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString());
            }

            bool duplicateResults = duplicates.DuplicatesYN;
            if (duplicateResults == true)
            {
                MessageBox.Show("There is overlap with \n\n"
                    + "    Order # " + duplicates.OrderNumber + "\n"
                    + "    Customer # " + duplicates.CustNumber + "\n"
                    + "    Prefix " + duplicates.Prefix + "\n"
                    + "    Suffix " + duplicates.Suffix + "\n"
                    + "    Serial #'s " + duplicates.Beginning + " - " + duplicates.Ending);
                btnMfgSave.Enabled = false;
            }
            else
            {
                MessageBox.Show("There are no duplicates.  Please be certain to save this info.");
                btnMfgSave.Enabled = true;
            }
        }
        private bool IsValidMfgBadgeEntries()
        {
            return
            // TODO - something for the two combo-boxes?
            Validator.HasYear(txtMfgYear) &&
            Validator.IsPresent(txtMfgPrefix) &&
                
            // TODO - is prefix always required?  ?????
            // TODO - if prefix is not required, change radio button to NA?
            // TODO - do anything with these two combo-boxes?
                
            // TODO - convert from string to int?  only if not validating these are ints to begin with
            Validator.IsInt32(txtMfgBeginning) &&
            Validator.IsInt32(txtMfgEnding) &&

            Validator.IsInt32(txtMfgCount) &&
            Validator.VerifyCount(txtMfgBeginning, txtMfgEnding, txtMfgCount) &&

            Validator.IsPresent(cboMfgFinished) &&
            Validator.IsPresent(cboMfgRequirement);
        }
        private bool IsValidCustBadgeEntries()
        {
            return
            Validator.IsInt32(txtCustBeginning) &&
            Validator.IsInt32(txtCustEnding) &&

            Validator.IsInt32(txtCustCount) &&
            Validator.VerifyCount(txtCustBeginning, txtCustEnding, txtCustCount);
        }
        private void BtnMfgCancel_Click(object sender, EventArgs e)
        {
            this.ClearMfgBadgeData();
            this.EnterOrderNumber();
        }
        private void BtnCustCancel_Click(object sender, EventArgs e)
        {
            this.ClearCustBadgeData();
            this.EnterOrderNumber();
        }        
        private void BtnDeleteOrder_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you certain you want to delete this order, vs. cancelling?","Confirm",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (result == DialogResult.OK)
            {
                string orderNumber = txtOrderNumber.Text;
                OrdersDB.DeleteOrder(orderNumber);
                MessageBox.Show("Order has been deleted.");

                this.ClearOrderDetails();
                this.ClearCustBadgeData();
                this.ClearMfgBadgeData();
            }
        }
        private void BtnClearAll_Click(object sender, EventArgs e)
        {
            this.ClearOrderDetails();
            this.ClearCustBadgeData();
            this.ClearMfgBadgeData();
        }
        private void ClearOrderDetails()
        {
            txtOrderNumber.Text = "";
            txtOrderNotes.Text = "";
            txtCustNumber.Text = "";
            txtCustName.Text = "";
            txtCustNotes.Text = "";
            btnAddOrder.Enabled = false;
            btnModifyOrder.Enabled = false;
            btnDeleteOrder.Enabled = false;
        }
        private void ClearMfgBadgeData()
        {
            cboMfgFinished.Text = "Select";
            cboMfgFinished.Enabled = false;
            lblMfgBlank.Text = "00000P000";
            lblMfgBlank.Enabled = false;
            cboMfgRequirement.Text = "Select";
            cboMfgRequirement.Enabled = false;
            txtMfgYear.Text = "";
            txtMfgYear.Enabled = false;
            rbMfgYearNo.Checked = true;
            gbMfgYear.Enabled = false;
            rbMfgPrefixYes.Checked = true;
            gbMfgPrefix.Enabled = false;
            txtMfgPrefix.Text = "";
            txtMfgPrefix.Enabled = false;
            txtMfgBeginning.Text = "";
            txtMfgBeginning.Enabled = false;
            txtMfgEnding.Text = "";
            txtMfgEnding.Enabled = false;
            txtMfgCount.Text = "";
            txtMfgCount.Enabled = false;
            txtMfgBadgeNotes.Text = "";
            txtMfgBadgeNotes.Enabled = false;
            lblMfgStatusIntro.Visible = false;
            lblMfgStatus.Visible = false;
            lblMfgStatusChange.Visible = false;
            btnMfgStatusChange.Visible = false;
            btnMfgVerify.Enabled = false;
            btnMfgSave.Enabled = false;
            btnMfgCancel.Enabled = false;
            btnAddMfgBadges.Enabled = true;
            btnModifyMfgBadges.Enabled = false;
            btnDeleteMfgBadges.Enabled = false;
        }
        private void ClearCustBadgeData()
        {
            cboCustFinished.Text = "Select";
            cboCustFinished.Enabled = false;
            lblCustBlank.Text = "00000P000";
            lblCustBlank.Enabled = false;
            txtCustPrefix.Text = "";
            txtCustPrefix.Enabled = false;
            rbCustPrefixNo.Checked = true;
            gbCustPrefix.Enabled = false;
            txtCustSuffix.Text = "";
            txtCustSuffix.Enabled = false;
            rbCustSuffixNo.Checked = true;
            gbCustSuffix.Enabled = false;
            txtCustBeginning.Text = "";
            txtCustBeginning.Enabled = false;
            txtCustEnding.Text = "";
            txtCustEnding.Enabled = false;
            txtCustCount.Text = "";
            txtCustCount.Enabled = false;
            txtCustBadgeNotes.Text = "";
            txtCustBadgeNotes.Enabled = false;
            lblCustStatusIntro.Visible = false;
            lblCustStatus.Visible = false;
            lblCustStatusChange.Visible = false;
            btnCustStatusChange.Visible = false;
            btnCustVerify.Enabled = false;
        }    
        private void BtnMfgSave_Click(object sender, EventArgs e)
        {
            // follow the way i did it on frmAddModifyFinishedBadges.cs
            if (IsValidMfgBadgeEntries())
            {
                mfgSerials = new Order();
                this.GetMfgSerialsFormData(mfgSerials);
                try
                {
                    if (!Serials.SerialsMfg.SaveMfgBadgeEntries(mfgSerials))
                    {
                        MessageBox.Show("?", "Database Error");
                        this.DialogResult = DialogResult.Retry;
                    }
                    else
                    {
                        MessageBox.Show("Success.");
                        btnAddMfgBadges.Enabled = false;
                        btnModifyMfgBadges.Enabled = true;
                        btnDeleteMfgBadges.Enabled = true;

                        cboMfgFinished.Enabled = false;
                        lblMfgBlank.Enabled = false;
                        cboMfgRequirement.Enabled = false;
                        txtMfgYear.Enabled = false;
                        gbMfgYear.Enabled = false;
                        gbMfgPrefix.Enabled = false;
                        rbMfgYearYes.Enabled = false;
                        rbMfgYearNo.Enabled = false;
                        txtMfgPrefix.Enabled = false;
                        rbMfgPrefixYes.Enabled = false;
                        rbMfgPrefixNo.Enabled = false;
                        txtMfgBeginning.Enabled = false;
                        txtMfgEnding.Enabled = false;
                        txtMfgCount.Enabled = false;
                        txtMfgBadgeNotes.Enabled = false;

                        btnMfgVerify.Enabled = false;
                        btnMfgCancel.Enabled = false;
                        btnMfgSave.Enabled = false;

                        EnterOrderNumber();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, ex.GetType().ToString());
                }
            }
        }
        private void GetMfgSerialsFormData(Order mfg)
        {
            mfg.OrderNumber = txtOrderNumber.Text;
            mfg.MfgFinishedBadge = cboMfgFinished.SelectedValue.ToString();
            mfg.MfgRequirementCode = cboMfgRequirement.SelectedValue.ToString();
            mfg.MfgYear = txtMfgYear.Text;
                if (rbMfgYearYes.Checked)
                {
                    mfg.MfgYearInclude = "Y";
                }
                else
                {
                    mfg.MfgYearInclude = "N";
                }
            if (txtMfgPrefix.Text != "")
            {
                mfg.MfgPrefix = txtMfgPrefix.Text;
                if (rbMfgPrefixYes.Checked)
                {
                    mfg.MfgPrefixInclude = "Y";
                }
                else
                {
                    mfg.MfgPrefixInclude = "N";
                }
            }
            
            mfg.MfgBeginningSerial = Convert.ToInt32(txtMfgBeginning.Text);
            mfg.MfgEndingSerial = Convert.ToInt32(txtMfgEnding.Text);
            mfg.MfgQuantity = Convert.ToInt32(txtMfgCount.Text);
            mfg.MfgNotes = txtMfgBadgeNotes.Text;            
        }
        private void BtnDeleteMfgBadges_Click(object sender, EventArgs e)
        {
            mfgSerials = new Order();
            mfgSerials.OrderNumber = txtOrderNumber.Text;
            try
            {
                if (!Serials.SerialsMfg.DeleteMfgBadgeEntries(mfgSerials))
                {
                    MessageBox.Show("?", "Database Error");
                    this.DialogResult = DialogResult.Retry;
                }
                else
                {
                    MessageBox.Show("!","Success.");
                    this.SetOrderForm();
                    this.DialogResult = DialogResult.OK;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString());
            }
        }
        private void BtnModifyMfgBadges_Click(object sender, EventArgs e)
        {
            cboMfgFinished.Enabled = true;
            lblMfgBlank.Enabled = true;
            cboMfgRequirement.Enabled = true;

            gbMfgYear.Enabled = true;
            txtMfgYear.Enabled = true;            
            rbMfgYearYes.Enabled = true;
            rbMfgYearNo.Enabled = true;

            gbMfgPrefix.Enabled = true;
            txtMfgPrefix.Enabled = true;
            rbMfgPrefixYes.Enabled = true;
            rbMfgPrefixNo.Enabled = true;

            txtMfgBeginning.Enabled = true;
            txtMfgEnding.Enabled = true;
            txtMfgCount.Enabled = true;
            txtMfgBadgeNotes.Enabled = true;

            btnMfgVerify.Enabled = true;
            btnMfgCancel.Enabled = true;
            btnMfgSave.Enabled = false;
        }
        private void BtnCustSave_Click(object sender, EventArgs e)
        {
            if (IsValidCustBadgeEntries())
            {
                custSerials = new Order();
                this.GetCustSerialsFormData(custSerials);
                try
                {
                    if (!Serials.SerialsCust.SaveCustBadgeEntries(custSerials))
                    {
                        MessageBox.Show("?", "Database Error");
                        this.DialogResult = DialogResult.Retry;
                    }
                    else
                    {
                        MessageBox.Show("Success.");
                        btnAddCustBadges.Enabled = false;
                        btnModifyCustBadges.Enabled = true;
                        btnDeleteCustBadges.Enabled = true;

                        cboCustFinished.Enabled = false;
                        txtCustPrefix.Enabled = false;
                        gbCustPrefix.Enabled = false;
                        rbCustPrefixYes.Enabled = false;
                        rbCustPrefixNo.Enabled = false;
                        txtCustSuffix.Enabled = false;
                        gbCustSuffix.Enabled = false;
                        rbCustSuffixYes.Enabled = false;
                        rbCustSuffixNo.Enabled = false;
                        txtCustBeginning.Enabled = false;
                        txtCustEnding.Enabled = false;
                        txtCustCount.Enabled = false;
                        txtCustBadgeNotes.Enabled = false;

                        btnCustVerify.Enabled = false;
                        btnCustSave.Enabled = false;
                        btnCustCancel.Enabled = false;

                        EnterOrderNumber();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, ex.GetType().ToString());
                }
            }
        }
        private void GetCustSerialsFormData(Order cust)
        {
            cust.OrderNumber = txtOrderNumber.Text;
            cust.CustFinishedBadge = cboCustFinished.SelectedValue.ToString();
            if (txtCustPrefix.Text != "")
            {
                cust.CustPrefix = txtCustPrefix.Text;
                if (rbCustPrefixYes.Checked)
                {
                    cust.CustPrefixInclude = "Y";
                }
                else
                {
                    cust.CustPrefixInclude = "N";
                }
            }
            else
            {
                cust.CustPrefix = "";
                cust.CustPrefixInclude = "";
            }
            if (txtCustSuffix.Text != "")
            {
                cust.CustSuffix = txtCustSuffix.Text;
                if (rbCustSuffixYes.Checked)
                {
                    cust.CustSuffixInclude = "Y";
                }
                else
                {
                    cust.CustSuffixInclude = "N";
                }
            }
            else
            {
                cust.CustSuffix = "";
                cust.CustSuffixInclude = "";
            }
            
            cust.CustBeginningSerial = Convert.ToInt32(txtCustBeginning.Text);
            cust.CustEndingSerial = Convert.ToInt32(txtCustEnding.Text);
            cust.CustQuantity = Convert.ToInt32(txtCustCount.Text);
            cust.CustNotes = txtCustBadgeNotes.Text;
        }
        private void BtnModifyCustBadges_Click(object sender, EventArgs e)
        {
            cboCustFinished.Enabled = true;

            gbCustPrefix.Enabled = true;
            txtCustPrefix.Enabled = true;
            rbCustPrefixYes.Enabled = true;
            rbCustPrefixNo.Enabled = true;

            gbCustSuffix.Enabled = true;
            txtCustSuffix.Enabled = true;
            rbCustSuffixYes.Enabled = true;
            rbCustSuffixNo.Enabled = true;

            txtCustBeginning.Enabled = true;
            txtCustEnding.Enabled = true;
            txtCustCount.Enabled = true;
            txtCustBadgeNotes.Enabled = true;

            btnCustVerify.Enabled = true;
            btnCustCancel.Enabled = true;
            btnCustSave.Enabled = false;
        }
        private void BtnDeleteCustBadges_Click(object sender, EventArgs e)
        {
            custSerials = new Order();
            custSerials.OrderNumber = txtOrderNumber.Text;
            try
            {
                if (!Serials.SerialsCust.DeleteCustBadgeEntries(custSerials))
                {
                    MessageBox.Show("?", "Database Error");
                    this.DialogResult = DialogResult.Retry;
                }
                else
                {
                    MessageBox.Show("!", "Success.");
                    this.SetOrderForm();
                    this.DialogResult = DialogResult.OK;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString());
            }
        }
        private void BtnMfgStatusChange_Click(object sender, EventArgs e)
        {
            int orderNumber = Convert.ToInt32(txtOrderNumber.Text);
            Serials.SerialsMfg.MfgBadgeStatusComplete(orderNumber);
            EnterOrderNumber();
            lblMfgStatusChange.Visible = false;
            btnMfgStatusChange.Visible = false;
        }
        private void BtnCustStatusChange_Click(object sender, EventArgs e)
        {
            int orderNumber = Convert.ToInt32(txtOrderNumber.Text);
            Serials.SerialsCust.CustBadgeStatusComplete(orderNumber);
            EnterOrderNumber();
            lblCustStatusChange.Visible = false;
            btnCustStatusChange.Visible = false;
        }
        private void MfgChanges(object sender, EventArgs e)
        {
            btnMfgSave.Enabled = false;
        }
        private void CustChanges(object sender, EventArgs e)
        {
            btnCustSave.Enabled = false;
        }
        private void CboMfgFinished_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblMfgBlank.Text = ""; // in case new info doesn't show up, old info will be gone
            try
            {
                string finishedNumber = cboMfgFinished.SelectedValue.ToString();
                this.GetMfgBadgeDetails(finishedNumber);
                lblMfgBlank.Text = finishedDetailsMFG.BlankBadgeNumber.ToString();
            }
            catch (Exception)
            {
                //throw;
            } 
        }

        private void GetMfgBadgeDetails(string finishedNumberMFG)
        {
            try
            {
                finishedDetailsMFG = BadgesFinished.FinishedBadgesDB.GetFinishedDetailsMFG(finishedNumberMFG);
                //lblMfgBlank.Text = finishedDetailsMFG.BlankBadgeNumber.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString());
            }
        }

        private void CboCustFinished_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblCustBlank.Text = ""; // in case new info doesn't show up, old info will be gone
            try
            {
                string finishedNumber = cboCustFinished.SelectedValue.ToString();
                this.GetCustBadgeDetails(finishedNumber);
                lblCustBlank.Text = finishedDetailsCUST.BlankBadgeNumber.ToString();
            }
            catch (Exception)
            {
                //throw;
            }
        }

        private void GetCustBadgeDetails(string finishedNumberCUST)
        {
            try
            {
                finishedDetailsCUST = BadgesFinished.FinishedBadgesDB.GetFinishedDetailsCUST(finishedNumberCUST);

                //lblMfgBlank.Text = finishedDetailsMFG.BlankBadgeNumber.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString());
            }
        }

        // TODO - handle 2 vs 4 digit years
    }
}
