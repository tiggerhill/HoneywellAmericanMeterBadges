using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;

namespace HoneywellAmericanMeterBadges.Serials
{
    public class SerialsMfg
    {
        public static bool SaveMfgBadgeEntries(Orders.Order orderMfgBadges)
        {
            OleDbConnection connection = SerialsDatabaseDB.GetConnection();

            string modifyStatement
                = "UPDATE Orders SET "
                + "MfgFinishedBadge = @Finished, "
                + "MfgRequirementCode = @Required, "
                + "MfgYear = @Year, "                
                + "MfgYearInclude = @YearInclude, "
                + "MfgPrefix = @Prefix, "
                + "MfgPrefixInclude = @PrefixInclude, "
                + "MfgBeginningSerial = @Beginning, "
                + "MfgEndingSerial = @Ending, "
                + "MfgQuantity = @Quantity, "
                + "MfgStatus = @Status, "
                + "MfgNotes = @Notes "
                + "WHERE OrderNumber = @OrderNumber";

            OleDbCommand modifyCommand =
                new OleDbCommand(modifyStatement, connection);

            modifyCommand.Parameters.AddWithValue
                ("@Finished", orderMfgBadges.MfgFinishedBadge);
            modifyCommand.Parameters.AddWithValue
                ("Required", orderMfgBadges.MfgRequirementCode);
            modifyCommand.Parameters.AddWithValue
                ("@Year", orderMfgBadges.MfgYear);
            modifyCommand.Parameters.AddWithValue
                ("@YearInclude", orderMfgBadges.MfgYearInclude);
            modifyCommand.Parameters.AddWithValue
                ("@Prefix", orderMfgBadges.MfgPrefix);
            modifyCommand.Parameters.AddWithValue
                ("@PrefixInclude", orderMfgBadges.MfgPrefixInclude);
            modifyCommand.Parameters.AddWithValue
                ("@Beginning", orderMfgBadges.MfgBeginningSerial);
            modifyCommand.Parameters.AddWithValue
                ("@Ending", orderMfgBadges.MfgEndingSerial);
            modifyCommand.Parameters.AddWithValue
                ("@Quantity", orderMfgBadges.MfgQuantity);
            modifyCommand.Parameters.AddWithValue
                ("@Status", "Reserved");
            //("@Status", orderMfgBadges.MfgStatus);
            modifyCommand.Parameters.AddWithValue
                ("@Notes", orderMfgBadges.MfgNotes);
            modifyCommand.Parameters.AddWithValue
                ("@OrderNumber", orderMfgBadges.OrderNumber);

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

        public static bool DeleteMfgBadgeEntries(Orders.Order orderMfgBadges)
        {
            OleDbConnection connection = SerialsDatabaseDB.GetConnection();

            string deleteStatement
                = "UPDATE Orders SET "
                + "MfgFinishedBadge = @Finished, "
                + "MfgRequirementCode = @Required, "
                + "MfgYear = @Year, "
                + "MfgYearInclude = @YearInclude, "
                + "MfgPrefix = @Prefix, "
                + "MfgPrefixInclude = @PrefixInclude, "
                + "MfgBeginningSerial = @Beginning, "
                + "MfgEndingSerial = @Ending, "
                + "MfgQuantity = @Quantity, "
                + "MfgStatus = @Status, "
                + "MfgNotes = @Notes "
                + "WHERE OrderNumber = @OrderNumber";

            OleDbCommand deleteCommand =
                new OleDbCommand(deleteStatement, connection);

            deleteCommand.Parameters.AddWithValue
                ("@Finished", "");
            deleteCommand.Parameters.AddWithValue
                ("Required", "");
            deleteCommand.Parameters.AddWithValue
                ("@Year", "");
            deleteCommand.Parameters.AddWithValue
                ("@YearInclude", "");
            deleteCommand.Parameters.AddWithValue
                ("@Prefix", "");
            deleteCommand.Parameters.AddWithValue
                ("@PrefixInclude", "");
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
                ("@OrderNumber", orderMfgBadges.OrderNumber);

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

        public static void MfgBadgeStatusComplete(int orderNumber)
        {
            OleDbConnection connection = SerialsDatabaseDB.GetConnection();

            string updateStatusStatement
                = "UPDATE Orders SET "
                + "MfgStatus = @Status "
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
