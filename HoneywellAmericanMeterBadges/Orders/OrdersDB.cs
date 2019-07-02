using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;

namespace HoneywellAmericanMeterBadges.Orders
{
    public class OrdersDB
    {
        public static Order GetOrderDetails(string orderNumber)
        {
            OleDbConnection connection = SerialsDatabaseDB.GetConnection();
            string selectStatement
                = "SELECT OrderNumber, OrderNotes, CustomerNumber, "
                + "MfgFinishedBadge, MfgRequirementCode, MfgYear, MfgYearInclude, "
                + "MfgPrefix, MfgPrefixInclude, MfgBeginningSerial, MfgEndingSerial, "
                + "MfgQuantity, MfgStatus, MfgNotes, "
                + "CustFinishedBadge, CustPrefix, CustPrefixInclude, CustSuffix, "
                + "CustSuffixInclude, CustBeginningSerial, CustEndingSerial, CustQuantity, "
                + "CustStatus, CustNotes "
                + "FROM Orders "
                + "WHERE OrderNumber = @OrderNumber";
            OleDbCommand selectCommand =
                new OleDbCommand(selectStatement, connection);
            selectCommand.Parameters.AddWithValue("@OrderNumber", orderNumber);

            try
            {
                connection.Open();
                OleDbDataReader datareader =
                    selectCommand.ExecuteReader(CommandBehavior.SingleRow);
                if (datareader.Read())
                {
                    Order order = new Order
                    {
                        OrderNumber = datareader["OrderNumber"].ToString(),
                        CustomerNumber = datareader["CustomerNumber"].ToString(),
                        OrderNotes = datareader["OrderNotes"].ToString(),

                        MfgFinishedBadge = datareader["MfgFinishedBadge"].ToString(),
                        MfgRequirementCode = datareader["MfgRequirementCode"].ToString(),
                        MfgYear = datareader["MfgYear"].ToString(),
                        MfgYearInclude = (datareader["MfgYearInclude"].ToString()),
                        MfgPrefix = datareader["MfgPrefix"].ToString(),
                        MfgPrefixInclude = (datareader["MfgPrefixInclude"].ToString()),
                        MfgBeginningSerial = Convert.ToInt32(datareader["MfgBeginningSerial"]),
                        MfgEndingSerial = Convert.ToInt32(datareader["MfgEndingSerial"]),
                        MfgQuantity = Convert.ToInt32(datareader["MfgQuantity"]),
                        MfgStatus = datareader["MfgStatus"].ToString(),
                        MfgNotes = datareader["MfgNotes"].ToString(),

                        CustFinishedBadge = datareader["CustFinishedBadge"].ToString(),
                        CustPrefix = datareader["CustPrefix"].ToString(),
                        CustPrefixInclude = (datareader["CustPrefixInclude"].ToString()),
                        CustSuffix = datareader["CustSuffix"].ToString(),
                        CustSuffixInclude = (datareader["CustSuffixInclude"].ToString()),
                        CustBeginningSerial = Convert.ToInt32(datareader["CustBeginningSerial"]),
                        CustEndingSerial = Convert.ToInt32(datareader["CustEndingSerial"]),
                        CustQuantity = Convert.ToInt32(datareader["CustQuantity"]),
                        CustStatus = datareader["CustStatus"].ToString(),
                        CustNotes = datareader["CustNotes"].ToString()
                    };
                return order;
                }
                else
                {
                    return null;
                }
            }
            catch (OleDbException ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString());
                throw ex;
            }
            finally
            {
                connection.Close();
            }
        }

        public static void AddNewOrder(Order order)
        {
            OleDbConnection connection = SerialsDatabaseDB.GetConnection();
            string insertStatement
                = "INSERT INTO [Orders] "
                + "(OrderNumber, OrderNotes, CustomerNumber) "
                + "VALUES (@OrderNum, @OrderNotes, @CustNum)";
            OleDbCommand insertCommand =
                new OleDbCommand(insertStatement, connection);
            insertCommand.Parameters.AddWithValue
                ("@OrderNum", order.OrderNumber);
            insertCommand.Parameters.AddWithValue
                ("@OrderNotes", order.OrderNotes);            
            insertCommand.Parameters.AddWithValue
                ("@CustNum", order.CustomerNumber);

            connection.Open();
            insertCommand.ExecuteNonQuery();
            connection.Close();
        }

        public static void DeleteOrder (string orderNumber)
        {
            OleDbConnection connection = SerialsDatabaseDB.GetConnection();
            string deleteStatement
                = "DELETE * "
                + "FROM Orders "
                + "WHERE OrderNumber = @OrderNumber";
            OleDbCommand deleteCommand =
                new OleDbCommand(deleteStatement, connection);
            deleteCommand.Parameters.AddWithValue("@OrderNumber", orderNumber);

            try
            {
                connection.Open();
                OleDbDataReader datareader =
                    deleteCommand.ExecuteReader(CommandBehavior.SingleRow);
                // TODO Does this delete from all tables????
                // TODO add option to cancel order, vs. deleting
            }
            catch (OleDbException ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString());
            }
            finally
            {
                connection.Close();
            }
        }

        public static bool UpdateOrder(Order oldOrder, Order newOrder)
        {
            OleDbConnection connection = SerialsDatabaseDB.GetConnection();
            string updateStatement
                = "UPDATE Orders SET "
                + "OrderNumber = @NewOrderNumber, "
                + "CustomerNumber = @NewCustomerNumber, "
                + "OrderNotes = @NewOrderNotes"
                + "FROM Orders "
                + "WHERE OrderNumber = @OldOrderNumber";
            OleDbCommand updateCommand = new OleDbCommand(updateStatement, connection);
            updateCommand.Parameters.AddWithValue("@NewOrderNumber", newOrder.OrderNumber);
            updateCommand.Parameters.AddWithValue("@NewCustomerNumber", newOrder.CustomerNumber);
            updateCommand.Parameters.AddWithValue("@NewOrderNotes", newOrder.OrderNotes);
            updateCommand.Parameters.AddWithValue("@OrderNumber", oldOrder.OrderNumber);

            try
            {
                connection.Open();
                int count = updateCommand.ExecuteNonQuery();
                if (count > 0)
                    return true;
                else
                    return false;
            }
            catch (OleDbException ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString());
                throw ex;
            }
            finally
            {
                connection.Close();
            }
        }
    }
}
