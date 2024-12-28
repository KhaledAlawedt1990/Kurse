using System;
using System.Data;
using System.Data.SqlClient;
using System.Net.Http.Headers;
using System.Resources;

namespace DataAdapterConsole
{
    internal class Program
    {
        static string _connectionLink = "Server=.;Database = ContactDB; user id = sa; password = se123456";
        static DataTable _dataTable1;
        
        static SqlDataAdapter _dataAdapter;
        static DataSet _dataset;
        static void FillDataSetWithDataFromDataSource()
        {
            // Create a new DataSet
             _dataset = new DataSet();

            // open the connection
            SqlConnection _connection;
            // Create a new dataAdapter with Select query and connection string .
            string query = @"Select * From Contacts";
           // string query = @"Select * From Countrays";
            _dataAdapter = new SqlDataAdapter(query, _connectionLink);
            _connection = new SqlConnection(_connectionLink);

            try
            {
                _connection.Open();
                _dataAdapter.SelectCommand.Connection = _connection;
                // Fill the dataset with data from the DataSource.
                _dataAdapter.Fill(_dataset, "Contacts");
                //_dataAdapter.Fill(_dataset, "Countrays");
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                _connection.Close();
            }

            //Display the Data From the DataSet.
            _dataTable1 = _dataset.Tables["Contacts"];

            foreach (DataRow row in _dataTable1.Rows)
            {
                Console.WriteLine("ContactID: {0},\t FirstName: {1},\t LastName: {2}",
                    row["ContactID"], row["FirstName"], row["LastName"]);

            }
            Console.WriteLine();


            DataRow[] Results = _dataTable1.Select("ContactID = 1");

            foreach(var rowRecord in Results )
            {
                rowRecord.Delete();
            }
            _dataTable1.AcceptChanges();

            foreach (DataRow row in _dataTable1.Rows)
            {
                Console.WriteLine("ContactID: {0},\t FirstName: {1},\t LastName: {2}",
                    row["ContactID"], row["FirstName"], row["LastName"]);

            }
            Console.WriteLine();

            _connection.Open();
            _dataAdapter.UpdateCommand.Connection = _connection;
            _dataAdapter.Update(_dataset, "Contacts");

            _connection.Close();


        }

        //static void SaveChangedDataInDataSource()
        //{
        //    try
        //    {
        //        _connection.Open();

        //        _dataAdapter.UpdateCommand.Connection = _connection;
        //        _dataAdapter.Update(_dataset,"Contacts");
        //    }
        //    catch(Exception ex)
        //    {
        //        Console.WriteLine(ex.Message);
        //    }
        //    finally
        //    {
        //        _connection.Close();
        //    }
            

        //}

        //static void DataSorting()
        //{
        //    _dataTable1.DefaultView.Sort = "FirstName Asc";
        //    _dataTable1 = _dataTable1.DefaultView.ToTable();

        //    foreach (DataRow row in _dataTable1.Rows)
        //    {
        //        Console.WriteLine("ContactID: {0},\t FirstName: {1},\t LastName: {2}",
        //            row["ContactID"], row["FirstName"], row["LastName"]);

        //    }

        //    SaveChangedDataInDataSource();
        //}

        static void Main(string[] args)
        {
            FillDataSetWithDataFromDataSource();
            Console.WriteLine();
            //DataSorting();


            Console.ReadLine();
        }
    }
}
