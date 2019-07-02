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

namespace HoneywellAmericanMeterBadges
{
    public partial class frmReviewReporting : Form
    {
        public frmReviewReporting()
        {
            InitializeComponent();
        }
        private Customers.Customers customerDetails;

        private void FrmReviewReporting_Load(object sender, EventArgs e)
        {
            this.LoadAllOrders();
        }
        private void BtnInfoByCustNum_Click(object sender, EventArgs e)
        {
            if (Validator.IsPresent(txtCustNumber))
            {
                lblCustName.Text = "";
                string custNumber = txtCustNumber.Text;
                try
                {
                    customerDetails = Customers.CustomersDB.GetCustomerDetails(custNumber);
                    if (customerDetails == null)
                    {
                        MessageBox.Show("No info found.", "Not Found");
                    }
                    else
                    {
                        lblCustName.Text = customerDetails.CustomerName;
                        //txtCustNotes.Text = customerDetails.CustomerNotes;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, ex.GetType().ToString());
                }

                OleDbConnection connection = SerialsDatabaseDB.GetConnection();
                string selectStatement
                    = "SELECT * "
                    + "FROM Orders "
                    + "WHERE CustomerNumber = @CustomerNumber";
                OleDbCommand selectCommand =
                    new OleDbCommand(selectStatement, connection);
                selectCommand.Parameters.AddWithValue("@CustomerNumber", custNumber);

                OleDbDataAdapter dataAdapter = new OleDbDataAdapter(selectCommand);
                //OleDbDataAdapter dataAdapter = new OleDbDataAdapter(selectStatement, connection);
                DataSet dataSet = new DataSet("OrdersByCustomer");
                connection.Open();
                dataAdapter.Fill(dataSet, "OrdersByCustomer");
                connection.Close();
                dgAllOrders.DataSource = dataSet;
                dgAllOrders.DataMember = "OrdersByCustomer";

                txtCustBadgeNum.Text = "";
                txtMfgBadgeNum.Text = "";
                txtSerialNum.Text = "";
                txtOrderNum.Text = "";
            }
        } 
        private void BtnInfoBySerialNum_Click(object sender, EventArgs e)
        {
            if (Validator.IsPresent(txtSerialNum))
            {
                string serialNum = txtSerialNum.Text;
                OleDbConnection connection = SerialsDatabaseDB.GetConnection();
                string selectStatement
                    = "SELECT * "
                    + "FROM Orders "
                    + "WHERE @SerialNum Between MfgBeginningSerial And MfgEndingSerial " 
                    + "OR @SerialNum Between CustBeginningSerial And CustEndingSerial";
                OleDbCommand selectCommand =
                    new OleDbCommand(selectStatement, connection);
                selectCommand.Parameters.AddWithValue("@SerialNum", serialNum);

                OleDbDataAdapter dataAdapter = new OleDbDataAdapter(selectCommand);
                DataSet dataSet = new DataSet("OrdersBySerialNum");
                connection.Open();
                dataAdapter.Fill(dataSet, "OrdersBySerialNum");
                connection.Close();
                dgAllOrders.DataSource = dataSet;
                dgAllOrders.DataMember = "OrdersBySerialNum";

                txtCustBadgeNum.Text = "";
                txtCustNumber.Text = "";
                txtMfgBadgeNum.Text = "";
                lblCustName.Text = "";
                txtOrderNum.Text = "";
            }
        }
        private void BtnInfoByMfgBadgeNum_Click(object sender, EventArgs e)
        {
            if (Validator.IsPresent(txtMfgBadgeNum))
            {
                string mfgNumber = txtMfgBadgeNum.Text;
                OleDbConnection connection = SerialsDatabaseDB.GetConnection();
                string selectStatement
                    = "SELECT * "
                    + "FROM Orders "
                    + "WHERE MfgFinishedBadge = @MfgFinished";
                OleDbCommand selectCommand =
                    new OleDbCommand(selectStatement, connection);
                selectCommand.Parameters.AddWithValue("@MfgFinished", mfgNumber);

                OleDbDataAdapter dataAdapter = new OleDbDataAdapter(selectCommand);
                DataSet dataSet = new DataSet("OrdersByMfgBadge");
                connection.Open();
                dataAdapter.Fill(dataSet, "OrdersByMfgBadge");
                connection.Close();
                dgAllOrders.DataSource = dataSet;
                dgAllOrders.DataMember = "OrdersByMfgBadge";

                txtCustBadgeNum.Text = "";
                txtCustNumber.Text = "";
                txtSerialNum.Text = "";
                lblCustName.Text = "";
                txtOrderNum.Text = "";
            }            
        }
        private void BtnInfoByCustBadgeNum_Click(object sender, EventArgs e)
        {
            if (Validator.IsPresent(txtCustBadgeNum))
            {
                string custNumber = txtCustBadgeNum.Text;
                OleDbConnection connection = SerialsDatabaseDB.GetConnection();
                string selectStatement
                    = "SELECT * "
                    + "FROM Orders "
                    + "WHERE CustFinishedBadge = @CustFinished";
                OleDbCommand selectCommand =
                    new OleDbCommand(selectStatement, connection);
                selectCommand.Parameters.AddWithValue("@CustFinished", custNumber);

                OleDbDataAdapter dataAdapter = new OleDbDataAdapter(selectCommand);
                DataSet dataSet = new DataSet("OrdersByCustBadge");
                connection.Open();
                dataAdapter.Fill(dataSet, "OrdersByCustBadge");
                connection.Close();
                dgAllOrders.DataSource = dataSet;
                dgAllOrders.DataMember = "OrdersByCustBadge";

                txtCustNumber.Text = "";
                txtMfgBadgeNum.Text = "";
                txtSerialNum.Text = "";
                lblCustName.Text = "";
                txtOrderNum.Text = "";
            }
        }
        private void BtnReset_Click(object sender, EventArgs e)
        {
            this.LoadAllOrders();
        }

        private void LoadAllOrders()
        {
            OleDbConnection connection = SerialsDatabaseDB.GetConnection();
            string selectStatement
                = "SELECT * "
                + "FROM Orders";
            OleDbCommand selectCommand =
                new OleDbCommand(selectStatement, connection);

            OleDbDataAdapter dataAdapter = new OleDbDataAdapter(selectCommand);
            DataSet dataSet = new DataSet("AllOrders");
            connection.Open();
            dataAdapter.Fill(dataSet, "AllOrders");
            connection.Close();
            dgAllOrders.DataSource = dataSet;
            dgAllOrders.DataMember = "AllOrders";

            txtCustBadgeNum.Text = "";
            txtCustNumber.Text = "";
            txtMfgBadgeNum.Text = "";
            txtSerialNum.Text = "";
            txtOrderNum.Text = "";
            lblCustName.Text = "";
        }

        private void BtnInfoByOrderNum_Click(object sender, EventArgs e)
        {
            if (Validator.IsPresent(txtOrderNum))
            {
                string orderNumber = txtOrderNum.Text;
                OleDbConnection connection = SerialsDatabaseDB.GetConnection();
                string selectStatement
                    = "SELECT * "
                    + "FROM Orders "
                    + "WHERE OrderNumber = @OrderNum";
                OleDbCommand selectCommand =
                    new OleDbCommand(selectStatement, connection);
                selectCommand.Parameters.AddWithValue("@OrderNum", orderNumber);

                OleDbDataAdapter dataAdapter = new OleDbDataAdapter(selectCommand);
                DataSet dataSet = new DataSet("OrdersByOrderNum");
                connection.Open();
                dataAdapter.Fill(dataSet, "OrdersByOrderNum");
                connection.Close();
                dgAllOrders.DataSource = dataSet;
                dgAllOrders.DataMember = "OrdersByOrderNum";

                txtCustNumber.Text = "";
                txtMfgBadgeNum.Text = "";
                txtSerialNum.Text = "";
                txtCustBadgeNum.Text = "";
                lblCustName.Text = "";
            }
        }

        // following KeyDown methods to accept enter buttons from txt fields
        private void TxtOrderNum_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnInfoByOrderNum.PerformClick();
                // these last two lines will stop the beep sound
                e.SuppressKeyPress = true;
                e.Handled = true;
            }
        }
        private void TxtCustNumber_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnInfoByCustNum.PerformClick();
                // these last two lines will stop the beep sound
                e.SuppressKeyPress = true;
                e.Handled = true;
            }
        }
        private void TxtSerialNum_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnInfoBySerialNum.PerformClick();
                // these last two lines will stop the beep sound
                e.SuppressKeyPress = true;
                e.Handled = true;
            }
        }
        private void TxtMfgBadgeNum_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnInfoByMfgBadgeNum.PerformClick();
                // these last two lines will stop the beep sound
                e.SuppressKeyPress = true;
                e.Handled = true;
            }
        }
        private void TxtCustBadgeNum_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnInfoByCustBadgeNum.PerformClick();
                // these last two lines will stop the beep sound
                e.SuppressKeyPress = true;
                e.Handled = true;
            }
        }
    }
}