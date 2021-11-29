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
    public partial class frmAddModifyOrders : Form
    {
        public frmAddModifyOrders()
        {
            InitializeComponent();
        }

        public bool addOrder;
        public Order order;

        private void FrmAddModifyOrders_Load(object sender, EventArgs e)
        {
            BindDDL();

            if (addOrder)
            {
                this.Text = "Add New Order";
                txtOrderNumber.Text = frmOrders.SetValueForOrderNumber;
            }
            else
            {
                this.Text = "Modify Order";
                txtOrderNumber.Text = frmOrders.SetValueForOrderNumber;
                txtCustomerNumber.Text = frmOrders.SetValueForCustomerNumber;
                txtOrderNotes.Text = frmOrders.SetValueForOrderNotes;
            }
        }

        private void BtnAccept_Click(object sender, EventArgs e)
        {
            if (IsValidData())
            {
                if (addOrder)
                {
                    order = new Order();
                    PutOrderData(order);
                    try
                    {
                        OrdersDB.AddNewOrder(order);
                        MessageBox.Show("Operation Successful.", "Successful",
                            MessageBoxButtons.OK, MessageBoxIcon.None);
                        this.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, ex.GetType().ToString());
                    }
                }
                else
                {
                    Order updateOrder = new Order { };
                    this.PutOrderData(updateOrder);
                    try
                    {
                        if (!OrdersDB.UpdateOrder(order, updateOrder))
                        {
                            MessageBox.Show("?", "Database Error");
                            this.DialogResult = DialogResult.Retry;
                        }
                        else
                        {
                            order = updateOrder;
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
            else
            {
                // anything needed here?
            }
        }

        private bool IsValidData()
        {
            return
                Validator.IsPresent(txtOrderNumber) &&
                Validator.IsPresent(txtCustomerNumber);
        }

        private void PutOrderData(Order order)
        {
            order.OrderNumber = txtOrderNumber.Text;
            order.CustomerNumber = txtCustomerNumber.Text;
            order.OrderNotes = txtOrderNotes.Text;
        }

        // http://www.geekswithblogs.net/dotNETvinz/archive/2009/03/11/displaying-two-column-fields-in-dropdownlist-control.aspx
        // TODO - BindDDL stuff
        private void BindDDL()
        {
            DataTable dt = new DataTable();
            OleDbConnection connection = SerialsDatabaseDB.GetConnection();
            string selectStatement
                = "SELECT CustomerNumber + ' --- ' + CustomerName "
                + "AS CustNumName, CustomerNumber "
                + "FROM Customers";
            OleDbCommand selectCommand = new OleDbCommand(selectStatement, connection);
            OleDbDataAdapter dataAdapter = new OleDbDataAdapter(selectCommand);

            //try
            //{
            //    connection.Open();
            //    dataAdapter.Fill(dt);
            //    if (dt.Rows.Count > 0)
            //    {
            //        cboCustomers.DataSource = dt;
            //        cboCustomers.DisplayMember = "CustNumName";
            //        cboCustomers.ValueMember = "CustomerNumber";
            //        //cboCustomers.
            //    }

            //}
            //catch (Exception)
            //{

            //    throw;
            //}
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
