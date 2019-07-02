using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;

namespace HoneywellAmericanMeterBadges.Duplicates
{
    public class Check4DuplicatesDB
    {
        public static Check4Duplicates MfgVerifySerialOnly(int beginning, int ending, int orderNumber)
        {
            OleDbConnection connection = SerialsDatabaseDB.GetConnection();

            string checkStatement
                = "SELECT OrderNumber, MfgBeginningSerial, MfgEndingSerial "
                + "FROM Orders "
                + "WHERE ((OrderNumber <> @orderNumber) AND (MfgBeginningSerial Between @beginning And @ending)) "
                + "OR ((OrderNumber <> @orderNumber) AND (MfgEndingSerial Between @beginning And @ending)) " 
                + "OR ((OrderNumber <> @orderNumber) AND ((MfgBeginningSerial < @beginning) AND (MfgEndingSerial > @ending)))";

            OleDbCommand selectCommand = new OleDbCommand(checkStatement, connection);
            selectCommand.Parameters.AddWithValue("@orderNumber", orderNumber);
            selectCommand.Parameters.AddWithValue("@beginning", beginning);  
            selectCommand.Parameters.AddWithValue("@ending", ending);            

            try
            {
                connection.Open();
                OleDbDataReader dataReader = selectCommand.ExecuteReader();
                if (dataReader.Read())
                {
                    Check4Duplicates duplicatesYes = new Check4Duplicates
                    {
                        DuplicatesYN = true,
                        OrderNumber = dataReader["OrderNumber"].ToString(),
                        Beginning = dataReader["MfgBeginningSerial"].ToString(),
                        Ending = dataReader["MfgEndingSerial"].ToString()
                    };
                    return duplicatesYes;
                }
                else
                {
                    Check4Duplicates duplicatesNo = new Check4Duplicates
                    {
                        DuplicatesYN = false
                    };
                    return duplicatesNo;
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
        public static Check4Duplicates MfgVerifySerialAndPrefix(int beginning, int ending, int orderNumber, string prefix)
        {
            OleDbConnection connection = SerialsDatabaseDB.GetConnection();

            string checkStatement
                = "SELECT OrderNumber, MfgBeginningSerial, MfgEndingSerial, MfgPrefix "
                + "FROM Orders "
                + "WHERE ((OrderNumber <> @orderNumber) AND (MfgPrefix = @prefix) AND (MfgBeginningSerial BETWEEN @beginning AND @ending)) "
                + "OR ((OrderNumber <> @orderNumber) AND (MfgPrefix = @prefix) AND (MfgEndingSerial BETWEEN @beginning AND @ending))"
                + "OR ((OrderNumber <> @orderNumber) AND (MfgPrefix = @prefix) AND ((MfgBeginningSerial < @beginning) AND (MfgEndingSerial > @ending)))";

            OleDbCommand selectCommand =
                new OleDbCommand(checkStatement, connection);

            selectCommand.Parameters.AddWithValue("@orderNumber", orderNumber);
            selectCommand.Parameters.AddWithValue("@prefix", prefix);
            selectCommand.Parameters.AddWithValue("@beginning", beginning);
            selectCommand.Parameters.AddWithValue("@ending", ending);            

            try
            {
                connection.Open();
                OleDbDataReader dataReader = selectCommand.ExecuteReader();
                if (dataReader.Read())
                {
                    Check4Duplicates duplicatesYes = new Check4Duplicates
                    {
                        DuplicatesYN = true,
                        OrderNumber = dataReader["OrderNumber"].ToString(),
                        Beginning = dataReader["MfgBeginningSerial"].ToString(),
                        Ending = dataReader["MfgEndingSerial"].ToString(),
                        Prefix = dataReader["MfgPrefix"].ToString()
                    };
                    return duplicatesYes;
                }
                else
                {
                    Check4Duplicates duplicatesNo = new Check4Duplicates
                    {
                        DuplicatesYN = false
                    };
                    return duplicatesNo;
                }
            }
            catch (OleDbException ex)
            {
                throw ex;
            }
        }
        public static Check4Duplicates MfgVerifySerialandYear(int beginning, int ending, int year, int orderNumber)
        {
            OleDbConnection connection = SerialsDatabaseDB.GetConnection();

            string checkStatement
                = "SELECT OrderNumber, MfgBeginningSerial, MfgEndingSerial, MfgYear "
                + "FROM Orders "
                + "WHERE ((OrderNumber <> @orderNumber) AND (MfgYear = @year) AND (MfgBeginningSerial BETWEEN @beginning AND @ending)) "
                + "OR ((OrderNumber <> @orderNumber) AND (MfgYear = @year) AND (MfgEndingSerial BETWEEN @beginning AND @ending)) "
                + "OR ((OrderNumber <> @orderNumber) AND (MfgYear = @year) AND ((MfgBeginningSerial < @beginning) AND (MfgEndingSerial > @ending)))";

            OleDbCommand selectCommand =
                new OleDbCommand(checkStatement, connection);

            selectCommand.Parameters.AddWithValue("@orderNumber", orderNumber);
            selectCommand.Parameters.AddWithValue("@year", year);
            selectCommand.Parameters.AddWithValue("@beginning", beginning);
            selectCommand.Parameters.AddWithValue("@ending", ending);

            try
            {
                connection.Open();
                OleDbDataReader dataReader = selectCommand.ExecuteReader();

                if (dataReader.Read())
                {
                    Check4Duplicates duplicatesYes = new Check4Duplicates
                    {
                        DuplicatesYN = true,
                        OrderNumber = dataReader["OrderNumber"].ToString(),
                        Beginning = dataReader["MfgBeginningSerial"].ToString(),
                        Ending = dataReader["MfgEndingSerial"].ToString(),
                        Year = dataReader["MfgYear"].ToString()
                    };
                    return duplicatesYes;
                }
                else
                {
                    Check4Duplicates duplicatesNo = new Check4Duplicates
                    {
                        DuplicatesYN = false
                    };
                    return duplicatesNo;
                }
            }
            catch (OleDbException ex)
            {
                throw ex;
            }
        }
        public static Check4Duplicates MfgVerifySerialPrefixAndYear(int beginning, int ending, string prefix, int year, int orderNumber)
        {
            OleDbConnection connection = SerialsDatabaseDB.GetConnection();

            string checkStatement
                = "SELECT OrderNumber, MfgBeginningSerial, MfgEndingSerial, MfgPrefix, MfgYear "
                + "FROM Orders "
                + "WHERE ((OrderNumber <> @orderNumber) AND (MfgYear = @year) AND (MfgPrefix = @prefix) AND (MfgBeginningSerial BETWEEN @beginning AND @ending)) "
                + "OR ((OrderNumber <> @orderNumber) AND (MfgYear = @year) AND (MfgPrefix = @prefix) AND (MfgEndingSerial BETWEEN @beginning AND @ending)) "
                + "OR ((OrderNumber <> @orderNumber) AND (MfgYear = @year) AND (MfgPrefix = @prefix) AND ((MfgBeginningSerial < @beginning) AND (MfgEndingSerial > @ending)))";

            OleDbCommand selectCommand =
                new OleDbCommand(checkStatement, connection);

            selectCommand.Parameters.AddWithValue("@orderNumber", orderNumber);
            selectCommand.Parameters.AddWithValue("@year", year);
            selectCommand.Parameters.AddWithValue("@prefix", prefix);
            selectCommand.Parameters.AddWithValue("@beginning", beginning);
            selectCommand.Parameters.AddWithValue("@ending", ending);

            try
            {
                connection.Open();
                OleDbDataReader dataReader = selectCommand.ExecuteReader();
                if (dataReader.Read())
                {
                    Check4Duplicates duplicatesYes = new Check4Duplicates
                    {
                        DuplicatesYN = true,
                        OrderNumber = dataReader["OrderNumber"].ToString(),
                        Beginning = dataReader["MfgBeginningSerial"].ToString(),
                        Ending = dataReader["MfgEndingSerial"].ToString(),
                        Prefix = dataReader["MfgPrefix"].ToString(),
                        Year = dataReader["MfgYear"].ToString()
                    };
                    return duplicatesYes;
                }
                else
                {
                    Check4Duplicates duplicatesNo = new Check4Duplicates
                    {
                        DuplicatesYN = false
                    };
                    return duplicatesNo;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }


        public static Check4Duplicates CustVerifySerialOnly(int beginning, int ending, int orderNumber, string custNumber)
        {
            OleDbConnection connection = SerialsDatabaseDB.GetConnection();

            string checkStatement
                = "SELECT OrderNumber, CustBeginningSerial, CustEndingSerial, CustomerNumber "
                + "FROM Orders "
                + "WHERE ((OrderNumber <> @orderNumber) AND (CustomerNumber = @custNumber) AND (CustBeginningSerial Between @beginning AND @ending)) "
                + "OR ((OrderNumber <> @orderNumber) AND (CustomerNumber = @custNumber) AND (CustEndingSerial Between @beginning AND @ending)) "
                + "OR ((OrderNumber <> @orderNumber) AND (CustomerNumber = @custNumber) AND ((CustBeginningSerial < @beginning) AND (CustEndingSerial > @ending)))";

            OleDbCommand selectCommand = new OleDbCommand(checkStatement, connection);
            selectCommand.Parameters.AddWithValue("@orderNumber", orderNumber);
            selectCommand.Parameters.AddWithValue("@custNumber", custNumber);
            selectCommand.Parameters.AddWithValue("@beginning", beginning);
            selectCommand.Parameters.AddWithValue("@ending", ending);

            try
            {
                connection.Open();
                OleDbDataReader dataReader = selectCommand.ExecuteReader();
                if (dataReader.Read())
                {
                    Check4Duplicates duplicatesYes = new Check4Duplicates
                    {
                        DuplicatesYN = true,
                        OrderNumber = dataReader["OrderNumber"].ToString(),
                        CustNumber = dataReader["CustomerNumber"].ToString(),
                        Beginning = dataReader["CustBeginningSerial"].ToString(),
                        Ending = dataReader["CustEndingSerial"].ToString()
                    };
                    return duplicatesYes;
                }
                else
                {
                    Check4Duplicates duplicatesNo = new Check4Duplicates
                    {
                        DuplicatesYN = false
                    };
                    return duplicatesNo;
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
        public static Check4Duplicates CustVerifySerialAndPrefix(int beginning, int ending, int orderNumber, string custNumber, string prefix)
        {
            OleDbConnection connection = SerialsDatabaseDB.GetConnection();
            
            string checkStatement
                = "SELECT OrderNumber, CustBeginningSerial, CustEndingSerial, CustPrefix, CustomerNumber "
                + "FROM Orders "
                + "WHERE ((OrderNumber <> @orderNumber) AND (CustomerNumber = @custNumber) AND (CustPrefix = @prefix) AND (CustBeginningSerial Between @beginning AND @ending)) "
                + "OR ((OrderNumber <> @orderNumber) AND (CustomerNumber = @custNumber) AND (CustPrefix = @prefix) AND (CustEndingSerial Between @beginning AND @ending)) "
                + "OR ((OrderNumber <> @orderNumber) AND (CustomerNumber = @custNumber) AND (CustPrefix = @prefix) AND ((CustBeginningSerial < @beginning) AND (CustEndingSerial > @ending)))";

            OleDbCommand selectCommand = new OleDbCommand(checkStatement, connection);
            selectCommand.Parameters.AddWithValue("@orderNumber", orderNumber);
            selectCommand.Parameters.AddWithValue("@custNumber", custNumber);
            selectCommand.Parameters.AddWithValue("@prefix", prefix);
            selectCommand.Parameters.AddWithValue("@beginning", beginning);
            selectCommand.Parameters.AddWithValue("@ending", ending);

            try
            {
                connection.Open();
                OleDbDataReader dataReader = selectCommand.ExecuteReader();
                if (dataReader.Read())
                {
                    Check4Duplicates duplicatesYes = new Check4Duplicates
                    {
                        DuplicatesYN = true,
                        OrderNumber = dataReader["OrderNumber"].ToString(),
                        CustNumber = dataReader["CustomerNumber"].ToString(),
                        Beginning = dataReader["CustBeginningSerial"].ToString(),
                        Ending = dataReader["CustEndingSerial"].ToString(),
                        Prefix = dataReader["CustPrefix"].ToString()
                    };
                    return duplicatesYes;
                }
                else
                {
                    Check4Duplicates duplicatesNo = new Check4Duplicates
                    {
                        DuplicatesYN = false
                    };
                    return duplicatesNo;
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
        public static Check4Duplicates CustVerifySerialAndSuffix(int beginning, int ending, int orderNumber, string suffix, string custNumber)
        {
            OleDbConnection connection = SerialsDatabaseDB.GetConnection();

            string checkStatement
                = "SELECT OrderNumber, CustBeginningSerial, CustEndingSerial, CustSuffix, CustomerNumber "
                + "FROM Orders "
                + "WHERE ((OrderNumber <> @orderNumber) AND (CustomerNumber = @custNumber) AND (CustSuffix = @suffix) AND (CustBeginningSerial Between @beginning AND @ending)) "
                + "OR ((OrderNumber <> @orderNumber) AND (CustomerNumber = @custNumber) AND (CustSuffix = @suffix) AND (CustEndingSerial Between @beginning AND @ending)) "
                + "OR ((OrderNumber <> @orderNumber) AND (CustomerNumber = @custNumber) AND (CustSuffix = @suffix) AND ((CustBeginningSerial < @beginning) AND (CustEndingSerial > @ending)))";

            OleDbCommand selectCommand = new OleDbCommand(checkStatement, connection);
            selectCommand.Parameters.AddWithValue("@orderNumber", orderNumber);
            selectCommand.Parameters.AddWithValue("@custNumber", custNumber);
            selectCommand.Parameters.AddWithValue("@suffix", suffix);
            selectCommand.Parameters.AddWithValue("@beginning", beginning);
            selectCommand.Parameters.AddWithValue("@ending", ending);

            try
            {
                connection.Open();
                OleDbDataReader dataReader = selectCommand.ExecuteReader();
                if (dataReader.Read())
                {
                    Check4Duplicates duplicatesYes = new Check4Duplicates
                    {
                        DuplicatesYN = true,
                        OrderNumber = dataReader["OrderNumber"].ToString(),
                        CustNumber = dataReader["CustomerNumber"].ToString(),
                        Beginning = dataReader["CustBeginningSerial"].ToString(),
                        Ending = dataReader["CustEndingSerial"].ToString(),
                        Suffix = dataReader["CustSuffix"].ToString()
                    };
                    return duplicatesYes;
                }
                else
                {
                    Check4Duplicates duplicatesNo = new Check4Duplicates
                    {
                        DuplicatesYN = false
                    };
                    return duplicatesNo;
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
        public static Check4Duplicates CustVerifySerialPrefixAndSuffix(int beginning, int ending, int orderNumber, string prefix, string suffix, string custNumber)
        {
            OleDbConnection connection = SerialsDatabaseDB.GetConnection();

            string checkStatement
                = "SELECT OrderNumber, CustBeginningSerial, CustEndingSerial, CustPrefix, CustSuffix, CustomerNumber "
                + "FROM Orders "
                + "WHERE ((OrderNumber <> @orderNumber) AND (CustomerNumber = @custNumber) AND (CustPrefix = @prefix) AND (CustSuffix = @suffix) AND (CustBeginningSerial Between @beginning AND @ending)) "
                + "OR ((OrderNumber <> @orderNumber) AND (CustomerNumber = @custNumber) AND (CustPrefix = @prefix) AND (CustSuffix = @suffix) AND (CustEndingSerial Between @beginning AND @ending)) "
                + "OR ((OrderNumber <> @orderNumber) AND (CustomerNumber = @custNumber) AND (CustPrefix = @prefix) AND (CustSuffix = @suffix) AND ((CustBeginningSerial < @beginning) AND (CustEndingSerial > @ending)))";

            OleDbCommand selectCommand = new OleDbCommand(checkStatement, connection);
            selectCommand.Parameters.AddWithValue("@orderNumber", orderNumber);
            selectCommand.Parameters.AddWithValue("@custNumber", custNumber);
            selectCommand.Parameters.AddWithValue("@prefix", prefix);
            selectCommand.Parameters.AddWithValue("@suffix", suffix);
            selectCommand.Parameters.AddWithValue("@beginning", beginning);
            selectCommand.Parameters.AddWithValue("@ending", ending);

            try
            {
                connection.Open();
                OleDbDataReader dataReader = selectCommand.ExecuteReader();
                if (dataReader.Read())
                {
                    Check4Duplicates duplicatesYes = new Check4Duplicates
                    {
                        DuplicatesYN = true,
                        OrderNumber = dataReader["OrderNumber"].ToString(),
                        CustNumber = dataReader["CustomerNumber"].ToString(),
                        Beginning = dataReader["CustBeginningSerial"].ToString(),
                        Ending = dataReader["CustEndingSerial"].ToString(),
                        Prefix = dataReader["CustPrefix"].ToString(),
                        Suffix = dataReader["CustSuffix"].ToString()
                    };
                    return duplicatesYes;
                }
                else
                {
                    Check4Duplicates duplicatesNo = new Check4Duplicates
                    {
                        DuplicatesYN = false
                    };
                    return duplicatesNo;
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
    }
}
