using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;

namespace HoneywellAmericanMeterBadges.Customers
{
    public class CustomersDB
    {
        public static Customers GetCustomerDetails(string customerNumber)
        {
            OleDbConnection connection = SerialsDatabaseDB.GetConnection();
            string selectStatement
                = "SELECT CustomerNumber, CustomerName, "
                + "CustomerStatus, RequirementCode, Notes "
                + "FROM Customers "
                + "WHERE CustomerNumber = @CustomerNumber";
            OleDbCommand selectCommand =
                new OleDbCommand(selectStatement, connection);
            selectCommand.Parameters.AddWithValue("@CustomerNumber", customerNumber);

            try
            {
                connection.Open();
                OleDbDataReader dataReader =
                    selectCommand.ExecuteReader(CommandBehavior.SingleRow);
                if (dataReader.Read())
                {
                    Customers customer = new Customers
                    {
                        CustomerNumber = dataReader["CustomerNumber"].ToString(),
                        CustomerName = dataReader["CustomerName"].ToString(),
                        CustomerNotes = dataReader["Notes"].ToString(),
                        CustomerStatus = dataReader["CustomerStatus"].ToString(),
                        RequirementCode = dataReader["RequirementCode"].ToString()
                    };
                    return customer;
                }
                else
                {
                    return null;
                }
            }
            catch (OleDbException ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
            }
        }
        public static void AddCustomer(Customers customer)
        {
            OleDbConnection connection = SerialsDatabaseDB.GetConnection();
            string insertStatement
                = "INSERT INTO [Customers] "
                + "(CustomerNumber, CustomerName, CustomerStatus, RequirementCode, Notes) "
                + "VALUES (@CustNum, @CustName, @CustStatus, @Requirement, @Notes)";
            OleDbCommand insertCommand =
                new OleDbCommand(insertStatement, connection);
            insertCommand.Parameters.AddWithValue
                ("@CustNum",customer.CustomerNumber);
            insertCommand.Parameters.AddWithValue
                ("@CustName",customer.CustomerName );
            insertCommand.Parameters.AddWithValue
                ("@CustStatus", "Active");
            insertCommand.Parameters.AddWithValue
                ("@Requirement",customer.RequirementCode);
            insertCommand.Parameters.AddWithValue
                ("@Notes", customer.CustomerNotes);

            connection.Open();
            insertCommand.ExecuteNonQuery();
            connection.Close();
        }

        public static bool UpdateCustomer(Customers oldCustomer, Customers newCustomer)
        {
            OleDbConnection connection = SerialsDatabaseDB.GetConnection();
            string updateStatement
                = "UPDATE Customers SET "
                + "CustomerNumber = @NewCustomerNumber, "
                + "CustomerName = @NewCustomerName, "
                + "CustomerStatus = @NewCustomerStatus, "
                + "RequirementCode = @NewRequirementCode, "
                + "Notes = @NewNotes "
                + "WHERE CustomerNumber = @OldCustomerNumber";
            OleDbCommand updateCommand = new OleDbCommand(updateStatement, connection);
            updateCommand.Parameters.AddWithValue ("@NewCustomerNumber", newCustomer.CustomerNumber);
            updateCommand.Parameters.AddWithValue ("@NewCustomerName", newCustomer.CustomerName);
            updateCommand.Parameters.AddWithValue ("@NewCustomerStatus", newCustomer.CustomerStatus);
            updateCommand.Parameters.AddWithValue ("@NewRequirementCode", newCustomer.RequirementCode);
            updateCommand.Parameters.AddWithValue ("@NewNotes", newCustomer.CustomerNotes);
            updateCommand.Parameters.AddWithValue ("@OldCustomerNumber", oldCustomer.CustomerNumber);

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
