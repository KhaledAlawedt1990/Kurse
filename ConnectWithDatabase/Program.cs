using System;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq.Expressions;
using System.Runtime.InteropServices;
using System.Security.Policy;
using System.Web;

public  class Program
    {

    static string connectingString = "Server=.;Database=ContactDB;user id = sa; password = se123456";

    static void PrintAllContacts()
    {
        SqlConnection connection = new SqlConnection(connectingString);

        string query = "Select * From NewContact";
        SqlCommand command = new SqlCommand(query, connection);

        try
        {
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            while(reader.Read())
            {
                int ContactID = (int)reader["ContactID"];
                string FirstName = (string)reader["FirstName"];
                string LastName = (string)reader["LastName"];
                string Email = (string)reader["Email"];
                string Phone = (string)reader["Phone"];
                string HausNumber = (string)reader["HausNumber"];
                int CountrayID = (int)reader["CountrayID"];

                Console.WriteLine("ContactID: " + ContactID);
                Console.WriteLine("FirstName: " + FirstName);
                Console.WriteLine("LastName: " + LastName);
                Console.WriteLine("Email: " + Email);
                Console.WriteLine("Phone: " + Phone);
                Console.WriteLine("HausNumber: " + HausNumber);
                Console.WriteLine("CountrayID: " + CountrayID);
                Console.WriteLine();

            }
            reader.Close();
            connection.Close();
        }
        catch(Exception ex)
        {
            Console.WriteLine("Error " + ex.Message);
        }


    }

    static void PrintAllContactWithFirstName(string firstname)
    {
        SqlConnection connection = new SqlConnection(connectingString);

        string query = "Select * From NewContact Where FirstName  = @FirstName";

        SqlCommand command = new SqlCommand(query, connection);
        command.Parameters.AddWithValue("@FirstName", firstname);
        try
        {
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

           while(reader.Read())
            {
                int ContactID = (int)reader["ContactID"];
                string FirstName = (string)reader["FirstName"];
                string LastName = (string)reader["LastName"];
                string Email = (string)reader["Email"];
                string Phone = (string)reader["Phone"];
                string HausNumber = (string)reader["HausNumber"];
                int CountrayID = (int)reader["CountrayID"];

                Console.WriteLine("ContactID: " + ContactID);
                Console.WriteLine("FirstName: " + FirstName);
                Console.WriteLine("LastName: " + LastName);
                Console.WriteLine("Email: " + Email);
                Console.WriteLine("Phone: " + Phone);
                Console.WriteLine("HausNumber: " + HausNumber);
                Console.WriteLine("CountrayID: " + CountrayID);
                Console.WriteLine();
            }
            reader.Close();
            connection.Close();
        }
        catch(Exception ex)
        {
            Console.WriteLine("Error, " + ex.Message);
        }
    }

    static void PrintAllContactWithFirstNameAndCountryID(string firstname, int countrayID)
    {
        SqlConnection connection = new SqlConnection(connectingString);
        string query = "Select * From NewContact where FirstName = @firstname and @CountrayID = countrayID";

        SqlCommand command = new SqlCommand(query, connection);
        command.Parameters.AddWithValue("@FirstName",firstname);
        command.Parameters.AddWithValue("@CountrayID", countrayID);

        try
        {
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while(reader.Read())
            {
                int ContactID = (int)reader["ContactID"];
                string FirstName = (string)reader["FirstName"];
                string LastName = (string)reader["LastName"];
                string Email = (string)reader["Email"];
                string Phone = (string)reader["Phone"];
                string HausNumber = (string)reader["HausNumber"];
                int CountrayID = (int)reader["CountrayID"];

                Console.WriteLine("ContactID: " + ContactID);
                Console.WriteLine("Name: " + FirstName + " " + LastName);
                Console.WriteLine("Email: " + Email);
                Console.WriteLine("Phone: " + Phone);
                Console.WriteLine("HausNumber: " + HausNumber);
                Console.WriteLine("CountrayID: " + CountrayID);
                Console.WriteLine();
            }
            reader.Close();
            connection.Close();
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error, " + ex.Message);
        }

    }

    static void PrintAllContactsStartWith(string startWith)
    {
        SqlConnection connection = new SqlConnection(connectingString);

        string query = "Select* From NewContact where FirstName like '' + @startWith + '%'";
        SqlCommand command = new SqlCommand(query, connection);
        command.Parameters.AddWithValue("@startWith", startWith);

        try
        {
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                int ContactID = (int)reader["ContactID"];
                string FirstName = (string)reader["FirstName"];
                string LastName = (string)reader["LastName"];
                string Email = (string)reader["Email"];
                string Phone = (string)reader["Phone"];
                string HausNumber = (string)reader["HausNumber"];
                int CountrayID = (int)reader["CountrayID"];

                Console.WriteLine("ContactID: " + ContactID);
                Console.WriteLine("Name: " + FirstName + " " + LastName);
                Console.WriteLine("Email: " + Email);
                Console.WriteLine("Phone: " + Phone);
                Console.WriteLine("HausNumber: " + HausNumber);
                Console.WriteLine("CountrayID: " + CountrayID);
                Console.WriteLine();
            }
        }
        catch(Exception ex)
        {
            Console.WriteLine("Error, " + ex.Message);
        }
    }

    static void PrintAllContactsEndWith(string endWith)
    {
        SqlConnection connection = new SqlConnection(connectingString);

        string query = "Select* From NewContact where FirstName like '%' + @endWith + ''";
        SqlCommand command = new SqlCommand(query, connection);
        command.Parameters.AddWithValue("@endWith", endWith);

        try
        {
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                int ContactID = (int)reader["ContactID"];
                string FirstName = (string)reader["FirstName"];
                string LastName = (string)reader["LastName"];
                string Email = (string)reader["Email"];
                string Phone = (string)reader["Phone"];
                string HausNumber = (string)reader["HausNumber"];
                int CountrayID = (int)reader["CountrayID"];

                Console.WriteLine("ContactID: " + ContactID);
                Console.WriteLine("Name: " + FirstName + " " + LastName);
                Console.WriteLine("Email: " + Email);
                Console.WriteLine("Phone: " + Phone);
                Console.WriteLine("HausNumber: " + HausNumber);
                Console.WriteLine("CountrayID: " + CountrayID);
                Console.WriteLine();
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error, " + ex.Message);
        }
    }

    static void PrintAllContactsContains(string contains)
    {
        SqlConnection connection = new SqlConnection(connectingString);

        string query = "Select* From NewContact where FirstName like '%' + @contains + '%'";
        SqlCommand command = new SqlCommand(query, connection);
        command.Parameters.AddWithValue("@contains", contains);

        try
        {
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                int ContactID = (int)reader["ContactID"];
                string FirstName = (string)reader["FirstName"];
                string LastName = (string)reader["LastName"];
                string Email = (string)reader["Email"];
                string Phone = (string)reader["Phone"];
                string HausNumber = (string)reader["HausNumber"];
                int CountrayID = (int)reader["CountrayID"];

                Console.WriteLine("ContactID: " + ContactID);
                Console.WriteLine("Name: " + FirstName + " " + LastName);
                Console.WriteLine("Email: " + Email);
                Console.WriteLine("Phone: " + Phone);
                Console.WriteLine("HausNumber: " + HausNumber);
                Console.WriteLine("CountrayID: " + CountrayID);
                Console.WriteLine();
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error, " + ex.Message);
        }
    }

    static string GetFirstName(int ContactID)
    {
        string FirstName = "";
        SqlConnection connection = new SqlConnection(connectingString);

        string query = "Select firstName From NewContact Where ContactID = @ContactID";
        SqlCommand command = new SqlCommand(query, connection);
        command.Parameters.AddWithValue("@ContactID", ContactID);

        try
        {
            connection.Open();
            object result = command.ExecuteScalar();

            if (result != null)
            {
                FirstName = result.ToString();
            }
            else
                FirstName = "";

            connection.Close();
        }
        catch(Exception ex)
        {
            Console.WriteLine("Error, " +  ex.Message);
        }

        return FirstName;
    }

    public struct stContact
    {
        public int ContactID;
        public string FirstName;
        public string LastName;
        public string Email;
        public string Phone;
        public string HausNumber;
        public int CountrayID;
    }

    static bool FindContactByID(int ContactID, ref stContact Contact)
    {
        bool IsFound = false;
        SqlConnection connection = new SqlConnection(connectingString);
        string query = "Select * From NewContact Where ContactID = @ContactID";

        SqlCommand command = new SqlCommand(query, connection);
        command.Parameters.AddWithValue("@ContactID", ContactID);

        try
        {
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            if(reader.Read())
            {
                IsFound = true;
                Contact.ContactID = (int)reader["ContactID"];
                Contact.FirstName = (string)reader["FirstName"];
                Contact.LastName = (string)reader["LastName"];
                Contact.Email = (string)reader["Email"];
                Contact.Phone = (string)reader["Phone"];
                Contact.HausNumber = (string)reader["HausNumber"];
                Contact.CountrayID = (int)reader["CountrayID"];
            }
            else
            {
                IsFound = false;
            }

            reader.Close();
            connection.Close();
        }
        catch(Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

        return IsFound;
    }

    static void  LookingForContact(int ContactID)
    {
        stContact Contact = new stContact();
        if (FindContactByID(ContactID, ref Contact))
        {
            Console.WriteLine("ContactID: " + Contact.ContactID);
            Console.WriteLine("Name: " + Contact.FirstName + " " + Contact.LastName);
            Console.WriteLine("Email: " + Contact.Email);
            Console.WriteLine("Phone: " + Contact.Phone);
            Console.WriteLine("HausNumber: " + Contact.HausNumber);
            Console.WriteLine("CountrayID: " + Contact.CountrayID);
            Console.WriteLine();
        }
        else
        {
            Console.WriteLine("Contact not found");
        }
    }

    public struct stContactData
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        public string Adresse { get; set; }
        public int CountrayID { get; set; }

    }
    static void AddNewContactAndGetID(stContactData NewContact)
    {
        SqlConnection connection = new SqlConnection(connectingString);
        string query = @"Insert into Contacts (FirstName, LastName, Email, Phone, CountrayID)
                       Values (@FirstName, @LastName, @Email, @Phone , @CountrayID)
                       SELECT SCOPE_IDENTITY()";
                   

        SqlCommand command = new SqlCommand(query, connection);
        command.Parameters.AddWithValue("@FirstName", NewContact.FirstName);
        command.Parameters.AddWithValue("@LastName", NewContact.LastName);
        command.Parameters.AddWithValue("@Email", NewContact.Email);
        command.Parameters.AddWithValue("@Phone",NewContact.Phone);
        command.Parameters.AddWithValue("@CountrayID", NewContact.CountrayID);

        try
        {
            connection.Open();
            object result = command.ExecuteScalar();

            if (result != null && int.TryParse(result.ToString(), out int InsertedID))
                Console.WriteLine("Newly inserted ID: " + InsertedID);

            else
                Console.WriteLine("Row Insertion failed ");

            connection.Close();
        }
        catch(Exception ex)
        {
            Console.WriteLine("Error, " + ex.Message);
        }


    }
    
    static void UpdateRecord(int ContactID, stContactData NewContact)
    {
        SqlConnection connection = new SqlConnection(connectingString);
        string query = @"Update Contacts
                          Set FirstName = @FirstName,
                              LastName = @LastName,
                              Email = @Email,
                              Phone = @Phone,
                              Adresse = @Adresse,
                              CountrayID = @CountrayID  
                              Where ContactID = @ContactID";

        SqlCommand command = new SqlCommand(query, connection);
        command.Parameters.AddWithValue("@ContactID", ContactID);
        command.Parameters.AddWithValue("@FirstName", NewContact.FirstName);
        command.Parameters.AddWithValue("@LastName", NewContact.LastName);
        command.Parameters.AddWithValue("@Email", NewContact.Email);
        command.Parameters.AddWithValue("@Phone", NewContact.Phone);
        command.Parameters.AddWithValue("@Adresse", NewContact.Adresse);
        command.Parameters.AddWithValue("@CountrayID", NewContact.CountrayID);

        try
        {
            connection.Open();
            int rowAffected = command.ExecuteNonQuery();
            if (rowAffected > 0)
                Console.WriteLine("Record updated seccessfully.");
            else
                Console.WriteLine("Record Updating Failed.");

            connection.Close();
        }
        catch(Exception ex)
        {
            Console.WriteLine("Error, " + ex.Message);
        }

    }

    static void DeleteContact(int ContactID)
    {
        SqlConnection connection = new SqlConnection(connectingString);
        string query = @"Delete From Contacts
                                   Where ContactID = @ContactID";
        SqlCommand command = new SqlCommand(query, connection);
        command.Parameters.AddWithValue("@ContactID", ContactID);

        try
        {
            connection.Open();
             object result = command.ExecuteNonQuery();
            if (result != null && int.TryParse(result.ToString(), out int DeletedID))
                Console.WriteLine("Record deleted successfully." + DeletedID);
            else
                Console.WriteLine("Record Deletion faild.");

            connection.Close();
        }
        catch(Exception ex)
        {
            Console.WriteLine("Error, " + ex.Message);
        }

    }


    static void DeleteMoreThanOneContacts(string ContactID)
    {
        SqlConnection connection = new SqlConnection(connectingString);
        string query = @"Delete From Contacts
                                   Where ContactID in (" + ContactID + ")";
        SqlCommand command = new SqlCommand(query, connection);
  

        try
        {
            connection.Open();
            object result = command.ExecuteNonQuery();
            if (result != null && int.TryParse(result.ToString(), out int DeletedID))
                Console.WriteLine("Record deleted successfully." + DeletedID);
            else
                Console.WriteLine("Record Deletion faild.");

            connection.Close();
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error, " + ex.Message);
        }

    }

    static void GetMoreThanOneContact(string ContactID)
    {

        SqlConnection connection = new SqlConnection(connectingString);
        string query = @"Select * From Contacts
                                        Where ContactID in (" + ContactID + ")";

        SqlCommand command = new SqlCommand(query, connection);

        try
        {
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            while(reader.Read())
            {
                string FirstName = (string)reader["FirstName"];
                string LastName = (string)reader["LastName"];
                string Email = (string)reader["Email"];
                string Phone = (string)reader["Phone"];
                string Adresse = (string)reader["Adresse"];
                int CountrayID = (int)reader["CountrayID"];

                Console.WriteLine("FirstName: " + FirstName);
                Console.WriteLine("LastName: " + LastName);
                Console.WriteLine("Email: " + Email);
                Console.WriteLine("Phone: " + Phone);
                Console.WriteLine("Adresse: " + Adresse);
                Console.WriteLine("CountrayID: " + CountrayID);
                Console.WriteLine();
            }
            connection.Close();
            reader.Close();
        }
        catch(Exception ex)
        {
            Console.WriteLine("Error, " + ex.Message);
        }
    }
    static void Main(string[] args)
    {
        GetMoreThanOneContact("7,8,16");

        Console.ReadLine();
    }
}
