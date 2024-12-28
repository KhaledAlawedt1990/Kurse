using System;
using System.ComponentModel.Design;
using System.Data;
using System.Data.SqlClient;
using System.Runtime.InteropServices;
using System.Runtime.Remoting;

namespace ContactsDataAccessLayer
{
    public class clsCountryData
    {
        public static bool FindCountryByName(string CountrayName, ref int CountryID)
        {
            bool isFound = false;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ServerConnection);
            string query = @"Select * From Countrays
                                           Where Countray_Name = @CountrayName";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@CountrayName", CountrayName);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if(reader.Read())
                {
                    isFound = true;

                    CountryID = (int)reader["CountrayID"];

                }
                reader.Close();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                isFound = false;
            }
            finally
            {
                connection.Close();
            }
            return isFound;
        }

        public static bool FindCountryByID(int CountryID, ref string name)
        {
            bool isFound = false;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ServerConnection);
            string query = @"Select * From Countrays
                                           Where CountrayID = @CountrayID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@CountrayID",CountryID);

            try
            {
                connection.Open();
                 SqlDataReader reader = command.ExecuteReader();

                if(reader.Read())
                {
                    isFound = true;
                    name = (string)reader["Countray_Name"];
                }
                reader.Close();
            }
            catch (Exception ex)
            {
               // Console.WriteLine(ex.Message);
                isFound = false;
            }
            finally
            {
                connection.Close();
            }
            return isFound;
        }

        public static bool IsCountryExist(string CountrayName)
        {
            bool isFound = false;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ServerConnection);
            string query = @"Select Find=1 From Countrays
                                           Where Countray_Name = @CountrayName";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@CountrayName", CountrayName);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                isFound = reader.HasRows;
              
                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                isFound = false;
            }
            finally
            {
                connection.Close();
            }
            return isFound;
        }

        public static bool IsCountryExistByID(int id)
        {
            bool isFound = false;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ServerConnection);
            string query = @"Select Find=1 From Countrays
                                           Where CountrayID = @CountrayID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@CountrayID", id);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                isFound = reader.HasRows;

                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                isFound = false;
            }
            finally
            {
                connection.Close();
            }
            return isFound;
        }

        public static int AddNewCountry(string CountryName)
        {
            int CountryID = -1;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ServerConnection);
            string query = @"INSERT INTO COUNTRAYS(Countray_Name)
                            Values (@Countray_Name);
                            SELECT SCOPE_IDENTITY()";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Countray_Name", CountryName);

            try
            {
                connection.Open();
                object result = command.ExecuteScalar();
                if(result != null && int.TryParse(result.ToString(), out int InsertedID))
                {
                    CountryID = InsertedID;
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                connection.Close();
            }
            return CountryID;
                         
        }

        public static bool UpdateCountry(int ID, string countryName)
        {
            int rowAffected = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ServerConnection);
            string query = @"Update Countrays 
                               Set Countray_Name = @countryName
                               Where CountrayID = @CountrayID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@countryName", countryName); 

            try
            {
                connection.Open();
                rowAffected = command.ExecuteNonQuery();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                connection.Close();
            }

            return (rowAffected > 1);
        }
    }
}
