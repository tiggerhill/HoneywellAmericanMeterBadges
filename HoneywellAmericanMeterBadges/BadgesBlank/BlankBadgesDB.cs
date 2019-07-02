using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;


namespace HoneywellAmericanMeterBadges.BlankBadges
{
    public class BlankBadgesDB
    {
        public static BlankBadges GetBlankDetails(string blankNumber)
        {
            OleDbConnection connection = SerialsDatabaseDB.GetConnection();
            string selectStatement
                = "SELECT BlankBadgeNumber, BlankDescription, Status "
                + "FROM BlankBadgeNumbers "
                + "WHERE BlankBadgeNumber = @BlankNumber";
            OleDbCommand selectCommand =
                new OleDbCommand(selectStatement, connection);
            selectCommand.Parameters.AddWithValue("@BlankNumber", blankNumber);

            try
            {
                connection.Open();
                OleDbDataReader dataReader =
                    selectCommand.ExecuteReader(CommandBehavior.SingleRow);
                if (dataReader.Read())
                {
                    BlankBadges blankBadge = new BlankBadges
                    {
                        BlankBadgeNumber = dataReader["BlankBadgeNumber"].ToString(),
                        BlankDescription = dataReader["BlankDescription"].ToString(),
                        BlankStatus = dataReader["Status"].ToString()
                    };
                    return blankBadge;
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

        public static void AddBlankBadge(BlankBadges blank)
        {
            OleDbConnection connection = SerialsDatabaseDB.GetConnection();
            string insertStatement
                = "INSERT INTO [BlankBadgeNumbers] "
                + "(BlankBadgeNumber, BlankDescription, Status) "
                + "VALUES (@Blank, @BlankDesc, @Status)";
            OleDbCommand insertCommand =
                new OleDbCommand(insertStatement, connection);
            insertCommand.Parameters.AddWithValue
                ("@Blank", blank.BlankBadgeNumber);
            insertCommand.Parameters.AddWithValue
                ("@BlankDesc", blank.BlankDescription);
            insertCommand.Parameters.AddWithValue
                ("@Status", blank.BlankStatus);

            connection.Open();
            insertCommand.ExecuteNonQuery();
            connection.Close();
        }

        // TODO - maybe remove the updates to the primary keys??  I think so...
        // for ALL update methods
        public static bool UpdateBlank(BlankBadges oldBlank, BlankBadges newBlank)
        {
            OleDbConnection connection = SerialsDatabaseDB.GetConnection();
            string updateStatement
                = "UPDATE BlankBadgeNumbers SET "
                    + "BlankBadgeNumber = @NewBlankNumber, "
                    + "BlankDescription = @NewBlankDescription, "
                    + "Status = @NewStatus "
                + "WHERE BlankBadgeNumber = @OldBlankNumber";
            OleDbCommand updateCommand =
                new OleDbCommand(updateStatement, connection);
            updateCommand.Parameters.AddWithValue
                ("@NewBlankNumber", newBlank.BlankBadgeNumber);
            updateCommand.Parameters.AddWithValue
                ("@NewBlankDescription", newBlank.BlankDescription);
            updateCommand.Parameters.AddWithValue
                ("@NewStatus", newBlank.BlankStatus);
            updateCommand.Parameters.AddWithValue
                ("@OldBlankNumbner", oldBlank.BlankBadgeNumber);
            
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
                throw ex;
            }
            finally
            {
                connection.Close();
            }
        }

        public static bool DeleteBlankBadge(BlankBadges blank)
        {
            OleDbConnection connection = SerialsDatabaseDB.GetConnection();
            string deleteStatment
                = "DELETE FROM BlankBadgeNumbers "
                + "WHERE BlankBadgeNumber = @BlankNumber "
                + "AND BlankDescription = @Description";
            OleDbCommand deleteCommand =
                new OleDbCommand(deleteStatment, connection);
            deleteCommand.Parameters.AddWithValue
                ("@BlankNumber", blank.BlankBadgeNumber);
            deleteCommand.Parameters.AddWithValue
                ("@Description", blank.BlankDescription);
            try
            {
                connection.Open();
                int count = deleteCommand.ExecuteNonQuery();
                if (count > 0)
                    return true;
                else
                    return false;
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
    }
}
