using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.OleDb;

namespace HoneywellAmericanMeterBadges.BadgesFinished
{
    public class FinishedBadgesDB
    {
        public static FinishedBadge GetFinishedDetailsMFG(string finishedNumber)
        {
            OleDbConnection connection = SerialsDatabaseDB.GetConnection();
            string selectStatement
                = "SELECT FinishedBadgeNumber, FinishedDescription, "
                + "BlankBadgeNumber, Status "
                + "FROM FinishedBadgeNumbersMFG "
                + "WHERE FinishedBadgeNumber = @FinishedNumber";
            OleDbCommand selectCommand =
                new OleDbCommand(selectStatement, connection);
            selectCommand.Parameters.AddWithValue("@FinishedNumber", finishedNumber);

            try
            {
                connection.Open();
                OleDbDataReader dataReader =
                    selectCommand.ExecuteReader(CommandBehavior.SingleRow);
                if (dataReader.Read())
                {
                    FinishedBadge finishedBadge = new FinishedBadge
                    {
                        FinishedBadgeNumber = dataReader["FinishedBadgeNumber"].ToString(),
                        FinishedDescription = dataReader["FinishedDescription"].ToString(),
                        FinishedStatus = dataReader["Status"].ToString(),
                        BlankBadgeNumber = dataReader["BlankBadgeNumber"].ToString()
                    };
                    return finishedBadge;
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

        public static FinishedBadge GetFinishedDetailsCUST(string finishedNumber)
        {
            OleDbConnection connection = SerialsDatabaseDB.GetConnection();
            string selectStatement
                = "SELECT FinishedBadgeNumber, FinishedDescription, "
                + "BlankBadgeNumber, Status "
                + "FROM FinishedBadgeNumbersCUST "
                + "WHERE FinishedBadgeNumber = @FinishedNumber";
            OleDbCommand selectCommand =
                new OleDbCommand(selectStatement, connection);
            selectCommand.Parameters.AddWithValue("@FinishedNumber", finishedNumber);

            try
            {
                connection.Open();
                OleDbDataReader dataReader =
                    selectCommand.ExecuteReader(CommandBehavior.SingleRow);
                if (dataReader.Read())
                {
                    FinishedBadge finishedBadge = new FinishedBadge
                    {
                        FinishedBadgeNumber = dataReader["FinishedBadgeNumber"].ToString(),
                        FinishedDescription = dataReader["FinishedDescription"].ToString(),
                        FinishedStatus = dataReader["Status"].ToString(),
                        BlankBadgeNumber = dataReader["BlankBadgeNumber"].ToString()
                    };
                    return finishedBadge;
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
        public static void AddFinishedBadge(FinishedBadge finishedBadge)
        {
            OleDbConnection connection = SerialsDatabaseDB.GetConnection();
            string insertStatement
                = "INSERT INTO [FinishedBadgeNumbers] "
                + "(FinishedBadgeNumber, MfgCustOrCam, FinishedDescription, "
                + "BlankBadgeNumber, Status) "
                + "VALUES (@Finished, @Type, @Desc, @Blank, @Status)";
            OleDbCommand insertCommand =
                new OleDbCommand(insertStatement, connection);
            insertCommand.Parameters.AddWithValue
                ("@Finished", finishedBadge.FinishedBadgeNumber);
            insertCommand.Parameters.AddWithValue
                ("@Desc", finishedBadge.FinishedDescription);
            insertCommand.Parameters.AddWithValue
                ("@Blank", finishedBadge.BlankBadgeNumber);
            insertCommand.Parameters.AddWithValue
                ("@Status", finishedBadge.FinishedStatus);

            connection.Open();
            insertCommand.ExecuteNonQuery();
            connection.Close();
        }

        public static bool UpdateFinished(FinishedBadge oldFinished, FinishedBadge newFinished)
        {
            OleDbConnection connection = SerialsDatabaseDB.GetConnection();
            string updateStatement
                = "UPDATE FinishedBadgeNumbers SET "
                + "FinishedBadgeNumber = @NewFinishedNumber, "
                + "MfgCustOrCam = @NewMfgCustOrCam, "
                + "FinishedDescription = @NewFinishedDescription, "
                + "BlankBadgeNumber = @NewBlankBadgeNumber, "
                + "Status = @NewStatus "
                + "WHERE FinishedBadgeNumber = @OldFinishedNumber";

            OleDbCommand updateCommand =
                new OleDbCommand(updateStatement, connection);

            updateCommand.Parameters.AddWithValue
                ("@NewFinishedNumber", newFinished.FinishedBadgeNumber);
            updateCommand.Parameters.AddWithValue
                ("@NewFinishedDescription", newFinished.FinishedDescription);
            updateCommand.Parameters.AddWithValue
                ("@NewBlankBadgeNumber", newFinished.BlankBadgeNumber);
            updateCommand.Parameters.AddWithValue
                ("@NewStatus", newFinished.FinishedStatus);
            updateCommand.Parameters.AddWithValue
                ("OldFinishedNumber", oldFinished.FinishedBadgeNumber);

            try
            {
                connection.Open();
                int count = updateCommand.ExecuteNonQuery();
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
    }
}
