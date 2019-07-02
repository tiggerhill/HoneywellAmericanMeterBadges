using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;

namespace HoneywellAmericanMeterBadges.Serials
{
    public class SerialsCust
    {
        public static bool SaveCustBadgeEntries(Orders.Order orderCustBadges)
        {
            OleDbConnection connection = SerialsDatabaseDB.GetConnection();

            string modifyStatement
                = "UPDATE Orders SET "
                + "CustFinishedBadge = @Finished, "
                + "CustPrefix = @Prefix, "
                + "CustPrefixInclude = @PrefixInclude, "
                + "CustSuffix = @Suffix, "
                + "CustSuffixInclude = @SuffixInclude, "
                + "CustBeginningSerial = @Beginning, "
                + "CustEndingSerial = @Ending, "
                + "CustQuantity = @Quantity, "
                + "CustStatus = @Status, "
                + "CustNotes = @Notes "
                + "WHERE OrderNumber = @OrderNumber";

            OleDbCommand modifyCommand =
                new OleDbCommand(modifyStatement, connection);

            modifyCommand.Parameters.AddWithValue
                ("@Finished", orderCustBadges.CustFinishedBadge);
            modifyCommand.Parameters.AddWithValue
                ("@Prefix", orderCustBadges.CustPrefix);
            modifyCommand.Parameters.AddWithValue
                ("@PrefixInclude", orderCustBadges.CustPrefixInclude);
            modifyCommand.Parameters.AddWithValue
                ("@Suffix", orderCustBadges.CustSuffix);
            modifyCommand.Parameters.AddWithValue
                ("@SuffixInclude", orderCustBadges.CustSuffixInclude);
            modifyCommand.Parameters.AddWithValue
                ("@Beginning", orderCustBadges.CustBeginningSerial);
            modifyCommand.Parameters.AddWithValue
                ("@Ending", orderCustBadges.CustEndingSerial);
            modifyCommand.Parameters.AddWithValue
                ("@Quantity", orderCustBadges.CustQuantity);
            modifyCommand.Parameters.AddWithValue
                ("@Status", "Reserved");
                // TODO  ("@Status", orderMfgBadges.CustStatus);
            modifyCommand.Parameters.AddWithValue
                ("@Notes", orderCustBadges.CustNotes);
            modifyCommand.Parameters.AddWithValue
                ("@OrderNumber", orderCustBadges.OrderNumber);

            try
            {
                connection.Open();
                int count = modifyCommand.ExecuteNonQuery();
                if (count > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
            }
        }

        public static bool DeleteCustBadgeEntries(Orders.Order orderCustBadges)
        {
            OleDbConnection connection = SerialsDatabaseDB.GetConnection();

            string deleteStatement
                = "UPDATE Orders SET "
                + "CustFinishedBadge = @Finished, "
                + "CustPrefix = @Prefix, "
                + "CustPrefixInclude = @PrefixInclude, "
                + "CustSuffix = @Suffix, "
                + "CustSuffixInclude = @SuffixInclude, "
                + "CustBeginningSerial = @Beginning, "
                + "CustEndingSerial = @Ending, "
                + "CustQuantity = @Quantity, "
                + "CustStatus = @Status, "
                + "CustNotes = @Notes "
                + "WHERE OrderNumber = @OrderNumber";

            OleDbCommand deleteCommand =
                new OleDbCommand(deleteStatement, connection);

            deleteCommand.Parameters.AddWithValue
                ("@Finished", "");
            deleteCommand.Parameters.AddWithValue
                ("@Prefix", "");
            deleteCommand.Parameters.AddWithValue
                ("@PrefixInclude", "");
            deleteCommand.Parameters.AddWithValue
                ("@Suffix", "");
            deleteCommand.Parameters.AddWithValue
                ("@SuffixInclude", "");
            deleteCommand.Parameters.AddWithValue
                ("@Beginning", 0);
            deleteCommand.Parameters.AddWithValue
                ("@Ending", 0);
            deleteCommand.Parameters.AddWithValue
                ("@Quantity", 0);
            deleteCommand.Parameters.AddWithValue
                ("@Status", "");
            deleteCommand.Parameters.AddWithValue
                ("@Notes", "");
            deleteCommand.Parameters.AddWithValue
                ("@OrderNumber", orderCustBadges.OrderNumber);

            try
            {
                connection.Open();
                int count = deleteCommand.ExecuteNonQuery();
                if (count > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
            }
        }

        public static void CustBadgeStatusComplete(int orderNumber)
        {
            OleDbConnection connection = SerialsDatabaseDB.GetConnection();

            string updateStatusStatement
                = "UPDATE Orders SET "
                + "CustStatus = @Status "
                + "WHERE OrderNumber = @OrderNumber";

            OleDbCommand updateCommand =
               new OleDbCommand(updateStatusStatement, connection);

            updateCommand.Parameters.AddWithValue
                ("@Status", "Complete");
            updateCommand.Parameters.AddWithValue
                ("@OrderNumber", orderNumber);

            try
            {
                connection.Open();
                int count = updateCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
            }
        }
    }
}
