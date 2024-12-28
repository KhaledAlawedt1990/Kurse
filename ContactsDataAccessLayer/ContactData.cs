
using System;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.Eventing.Reader;
using System.Runtime.InteropServices;


namespace ContactsDataAccessLayer
{
    public class clsContactData
    {
       
       public static bool GetContactByID(int ID,  ref string FirstName,
             ref string LastName, ref string Email, ref string Phone,
             ref int CountrayID, ref string Adresse, ref string imagepath)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ServerConnection);
            string query = @"Select * From Contacts 
                                       Where ContactID = @ContactID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ContactID", ID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if(reader.Read())
                {
                    isFound = true;
                    

                    FirstName = (string)reader["FirstName"];
                   LastName = (string)reader["LastName"];
                    Email = (string)reader["Email"];
                   Phone = (string)reader["Phone"];
                   CountrayID = (int)reader["CountrayID"];

                    if (reader["Adresse"] != System.DBNull.Value)
                    {
                        Adresse = (string)reader["Adresse"];
                    }
                    else
                        Adresse = Convert.ToString(System.DBNull.Value);
                    if (reader["ImagePath"] != System.DBNull.Value)
                        imagepath = (string)reader["ImagePath"];
                    else
                        imagepath = Convert.ToString(System.DBNull.Value);
                }
                else
                {
                    isFound = false;
                }

                reader.Close();
            }
            catch(Exception ex)
            {
                isFound = false;
            }
            finally
            {
                connection.Close();
            }

            return isFound;
        }

        public static int AddNewContact(string FirstName, string LastName,
           string Email, string Phone, int CountryID, string Address,string imagePath)
        {
            //this function will return the new contact id if succeeded and -1 if not.
            int ContactID = -1;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ServerConnection);

            string query = @"INSERT INTO Contacts (FirstName, LastName, Email, Phone, CountrayID,Adresse,ImagePath)
                            VALUES (@FirstName, @LastName, @Email, @Phone, @CountrayID,@Address,@imagePath);
                            SELECT SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@FirstName", FirstName);
            command.Parameters.AddWithValue("@LastName", LastName);
            command.Parameters.AddWithValue("@Email", Email);
            command.Parameters.AddWithValue("@Phone", Phone);
            command.Parameters.AddWithValue("@CountrayID", CountryID);
            if (!string.IsNullOrEmpty(Address))
            {
                command.Parameters.AddWithValue("@Address", Address);
            }
            else
                command.Parameters.AddWithValue("@Address", System.DBNull.Value);

            if (!string.IsNullOrEmpty(imagePath))
                command.Parameters.AddWithValue("@imagePath", imagePath);
            else
                command.Parameters.AddWithValue("@imagePath", System.DBNull.Value);



            try
            {
                connection.Open();

                object result = command.ExecuteScalar();


                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                {
                    ContactID = insertedID;
                }
            }

            catch (Exception ex)
            {
                Console.WriteLine( ex.Message);

            }

            finally
            {
                connection.Close();
            }


            return ContactID;
        }

        public static bool UpdateContact(int ID, string firsname, string lastname,
            string email, string phone, int countrayID, string address,string imagePath)
        {
            int rowsAffencted = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ServerConnection);

            string query = @"Update Contacts 
                                     Set FirstName = @firstName,
                                         LastName =  @LastName,
                                         Email = @Email,
                                         Phone =  @Phone,
                                         CountrayID = @CountrayID,
                                         Adresse = @Adresse,
                                         ImagePath = @imagePath
                                         Where ContactID = @ContactID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ContactID", ID);
            command.Parameters.AddWithValue("@firstName", firsname);
            command.Parameters.AddWithValue("@LastName", lastname);
            command.Parameters.AddWithValue("@Email", email);
            command.Parameters.AddWithValue("@Phone", phone);
            command.Parameters.AddWithValue("@CountrayID", countrayID);
            if (!string.IsNullOrEmpty(address))
                command.Parameters.AddWithValue("@Adresse", address);
            else
                command.Parameters.AddWithValue("@Adresse", System.DBNull.Value);

            if (!string.IsNullOrEmpty(imagePath))
                command.Parameters.AddWithValue("@imagePath", imagePath);
            else
                command.Parameters.AddWithValue("@imagePath", System.DBNull.Value);

            try
            {
                connection.Open();

                rowsAffencted = command.ExecuteNonQuery();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                connection.Close();
            }

            return (rowsAffencted > 0);
        }

        public static bool DeleteContact(int ContactID)
        {
            int rowAffected = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ServerConnection);

            string query = @"Delete From Contacts
                                        Where ContactID = @ContactID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ContactID", ContactID);

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

            return (rowAffected > 0);
        }

        public static DataTable GetAllContact()
        {
            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ServerConnection);

            string query = @"Select * From Contacts";

            SqlCommand command = new SqlCommand(query, connection);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if(reader.HasRows)
                {
                    dt.Load(reader);
                }
                reader.Close();
            }

            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                connection.Close();
            }
            return dt;
        }

        public static bool IsContactExist(int ID)
        {
            bool IsFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ServerConnection);
            string query = @"Select Found=1 from Contacts 
                                                 Where ContactID = @ContactID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ContactID", ID);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                IsFound = reader.HasRows;

                reader.Close();
            }
            catch(Exception ex)
            {
                IsFound = false;
                Console.WriteLine(ex.Message);
            }
            finally
            {
                connection.Close();
            }
            return IsFound;
        }
    }

   
}
