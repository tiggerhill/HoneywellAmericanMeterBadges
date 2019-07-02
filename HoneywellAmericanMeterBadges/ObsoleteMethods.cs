using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoneywellAmericanMeterBadges
{
    class ObsoleteMethods
    {

        // WAS PART OF ORDERS.DB AddNewOrder
        //insertCommand.Parameters.AddWithValue
        //    ("@BadgeNum", order.FinishedBadgePartNumber);
        //insertCommand.Parameters.AddWithValue
        //    ("@Require", order.SpecialRequirements);
        //insertCommand.Parameters.AddWithValue
        //    ("@BadgeYear", order.BadgeYear);
        //insertCommand.Parameters.AddWithValue
        //    ("@Notes", order.AdditionalNotes);
        //insertCommand.Parameters.AddWithValue
        //    ("@Prefix", order.Prefix);
        //insertCommand.Parameters.AddWithValue
        //    ("@Beginning", order.BeginningSerial);
        //insertCommand.Parameters.AddWithValue
        //    ("@Ending", order.EndingSerial);
        //insertCommand.Parameters.AddWithValue
        //    ("@Quantity", order.Count);
        //insertCommand.Parameters.AddWithValue
        //    ("@Status", order.Status);

        // was part of SerialsManufacturingDB
        //public static string VerifyManufacturingSerialOnlyVer2(int count, int beginning)
        //{
        //    // Why not do Where SerialNumber IN YourCommaDelimitedListofNumbers? 
        //    // That way you return all the number from the database that match(already exist).

        //    // Two ways:

        //    // Get all the id's from the database SELECT SerialNumber FROM SerialNumbersMFG and then you 
        //    // can use linq list1.Intersect(list2)
        //    // As posted in the comment, most DB have the IN clause, so you can use the query like: 
        //    // SELECTSerialNumber FROM SerialNumbersMFG WHERE SerialNumber IN(1,2,3...) 
        //    // which will also do the required thing.
        //    // Since you mention that the DB can have hundreds of thousand of record I would suggest 
        //    // that second way is better.
        //    // Please use stringbuilder for concatenation.

        //    // Create comma delimited list of serials:

        //    string serialList = "";
        //    int currentSerial = beginning;
        //    string duplicateSerials = "";

        //    for (int i = 0; i < count; i++)
        //    {
        //        serialList += currentSerial + ",";
        //        currentSerial++;
        //    }
        //    serialList = serialList.Trim(',');

        //    OleDbConnection connection = BadgeDatabaseDB.GetConnection();
        //    string checkStatement
        //        = "SELECT SerialNumber, OrderNumber "
        //        + "FROM SerialNumbersMFG "
        //        + "WHERE SerialNumber IN (1, 2, 3)";
        //    OleDbCommand command =
        //        new OleDbCommand(checkStatement, connection);
        //    //command.Parameters.AddWithValue("@SerialList", 1);

        //    try
        //    {
        //        connection.Open();
        //        OleDbDataReader dataReader = command.ExecuteReader();

        //        if (dataReader.Read())
        //        {
        //            duplicateSerials += dataReader["OrderNumber"].ToString() + "\n";
        //        }

        //        //if (dataReader.HasRows)
        //        //{
        //        //    while (dataReader.Read())
        //        //    {
        //        //        duplicateSerials += dataReader.GetString(4);

        //        //    }
        //        //}

        //    }
        //    catch (OleDbException ex)
        //    {
        //        throw ex;
        //    }
        //    finally
        //    {
        //        connection.Close();
        //    }

        //    return duplicateSerials;
        //}

        // was part of SerialsManufacturingDB
        //public static string VerifyManufacturingSerialOnlyVer1(int count, int beginning)
        //{
        //    string duplicateSerials = "";
        //    int currentSerial = beginning;

        //    for (int i = 0; i < count; i++)
        //    {
        //        OleDbConnection connection = BadgeDatabaseDB.GetConnection();
        //        string checkStatement
        //            = "SELECT * "
        //            + "FROM SerialNumbersMFG "
        //            + "WHERE SerialNumber = @CurrentSerial";
        //        OleDbCommand command =
        //            new OleDbCommand(checkStatement, connection);
        //        command.Parameters.AddWithValue("@CurrentSerial", currentSerial);

        //        try
        //        {
        //            connection.Open();
        //            OleDbDataReader dataReader =
        //                command.ExecuteReader(CommandBehavior.SingleRow);
        //            if (dataReader.Read())
        //            {
        //                duplicateSerials +=
        //                    "Serial # " +
        //                    currentSerial +
        //                    " already exists in order # " +
        //                    dataReader["OrderNumber"].ToString() + "\n";
        //            }
        //            else { }
        //        }
        //        catch (OleDbException ex)
        //        {
        //            throw ex;
        //        }
        //        finally
        //        {
        //            connection.Close();
        //        }
        //        currentSerial++;
        //        i++;
        //    }
        //    return duplicateSerials;
        //}

        // was part of SerialsManufacturingDB
        //= $"SELECT SerialNumber, OrderNumber FROM SerialNumbersMFG WHERE SerialNumber IN ({string.Join(", ", serialsList)})";

        //private void GenerateManufacturingSerials(SerialsManufacturing.SerialsManufacturing serialManufacturing)
        //{
        //    int count = serialManufacturing.Count;
        //    int serialNumberMfg = Convert.ToInt32(serialManufacturing.BeginningSerial);

        //    int[] badgeSerialNumberMfg = new int[count];
        //    string badgeSerialNumbersMfgString = "";

        //    for (int i = 0; i < badgeSerialNumberMfg.Length; i++)
        //    {
        //        badgeSerialNumberMfg[i] = serialNumberMfg;

        //        badgeSerialNumbersMfgString +=
        //            serialNumberMfg + "|" +
        //            manufacturingSerial.OrderNumber + "|" +
        //            manufacturingSerial.CustomerNumber + "|" +
        //            manufacturingSerial.BadgeNumber + "|" +
        //            manufacturingSerial.RequirementCode + "|" +
        //            manufacturingSerial.Year + "|" +
        //            manufacturingSerial.IncludeYear + "|" +
        //            manufacturingSerial.Prefix + "|" +
        //            manufacturingSerial.IncludePrefix + "|" +
        //            manufacturingSerial.Notes + "\n";

        //        serialNumberMfg++;
        //    }
        //    MessageBox.Show(badgeSerialNumbersMfgString, "Mfg Serial Numbers");
        //}

        //string result = SerialsManufacturing.SerialsManufacturingDB.VerifyManufacturingSerialOnly
        //    (beginningSerial, endingSerial);
        //MessageBox.Show(result);


        // **** this was part of the SerialsManufacturingDB class that is no longer needed
        //public static string VerifyManufacturingSerialOnly(int beginning, int ending)
        //{
        //    OleDbConnection connection = BadgeDatabaseDB.GetConnection();

        //    string checkStatement
        //        = "SELECT OrderNumber, MfgBeginningSerial, MfgEndingSerial "
        //        + "FROM Orders "
        //        + "WHERE MfgBeginningSerial "
        //        + "BETWEEN @beginning AND @ending "
        //        + "OR MfgEndingSerial "
        //        + "BETWEEN @beginning AND @ending";

        //    OleDbCommand selectCommand =
        //        new OleDbCommand(checkStatement, connection);

        //    selectCommand.Parameters.AddWithValue("@beginning", beginning);
        //    selectCommand.Parameters.AddWithValue("@ending", ending);

        //    // default string if no duplicates found
        //    string duplicateSerials;

        //    try
        //    {
        //        connection.Open();
        //        OleDbDataReader dataReader = selectCommand.ExecuteReader();

        //        if (dataReader.Read())
        //        {
        //            duplicateSerials 
        //                = "There is overlap with: \n\n     Order #  "
        //                + dataReader["OrderNumber"].ToString()
        //                + "\n     Serial #'s "
        //                + dataReader["MfgBeginningSerial"].ToString()
        //                + " - "
        //                + dataReader["MfgEndingSerial"].ToString();
        //        }
        //        else
        //        {
        //            duplicateSerials = "No duplicates found. Please be sure to save your entries.";
        //        }
        //    }
        //    catch (OleDbException ex)
        //    {
        //        throw ex;
        //    }
        //    finally
        //    {
        //        connection.Close();
        //    }

        //    return duplicateSerials;
        //}

        //private void GetManufacturingBadgeData (SerialsManufacturing.SerialsManufacturing serialManufacturing)
        //{
        //    serialManufacturing.OrderNumber = txtOrderNumber.Text;
        //    serialManufacturing.CustomerNumber = txtCustNumber.Text;
        //    serialManufacturing.BadgeNumber = cboMfgFinished.SelectedValue.ToString();
        //    serialManufacturing.RequirementCode = cboMfgRequirements.SelectedValue.ToString();
        //    serialManufacturing.Year = txtMfgYear.Text;

        //    if (rbMfgYearYes.Checked == true)
        //    {
        //        serialManufacturing.IncludeYear = 'Y'; 
        //    }
        //    else
        //    {
        //        serialManufacturing.IncludeYear = 'N';
        //    }            

        //    if (serialManufacturing.Prefix != "")
        //    {
        //        serialManufacturing.Prefix = txtMfgPrefix.Text;
        //        if (rbMfgPrefixYes.Checked == true)
        //        {
        //            serialManufacturing.IncludePrefix = 'Y';
        //        }
        //        else
        //        {
        //            serialManufacturing.IncludePrefix = 'N';
        //        }
        //    }

        //    serialManufacturing.BeginningSerial = Convert.ToInt32(txtMfgBeginning.Text);
        //    serialManufacturing.EndingSerial = Convert.ToInt32(txtMfgEnding.Text);
        //    serialManufacturing.Count = Convert.ToInt32(txtMfgCount.Text);
        //    serialManufacturing.Notes = txtMfgBadgeNotes.Text;
        //    // serialManufacturing.Status - maybe don't need this one any longer
        //}     

    }
}
