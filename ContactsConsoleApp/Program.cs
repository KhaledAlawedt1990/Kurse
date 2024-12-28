using System;
using System.Data;
using ContactsBusinessLayer;
using System.Data.SqlClient;
using System.Security.Policy;
using System.Diagnostics.PerformanceData;
using System.Xml.Linq;
using System.Management.Instrumentation;
internal class Program
{
    static string ConnectionString = "Server=.;Database=ContactDB; user id = sa; password = se123456";

    static void GetData()
    {
        SqlConnection connection = new SqlConnection(ConnectionString);
        string query = "Select * from Contacts";

        SqlCommand command = new SqlCommand(query, connection);
        try
        {
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while(reader.Read())
            {
                int ID = (int)reader["ContactID"];
               string  FirstName = (string)reader["FirstName"];
                string LastName = (string)reader["LastName"];
                string Email = (string)reader["Email"];
                string Phone = (string)reader["Phone"];
                int CountrayID = (int)reader["CountrayID"];
                string Adresse = (string)reader["Adresse"];
                string ImagePath = (string)reader["ImagePath"];

                Console.WriteLine("ID: " + ID);
                Console.WriteLine("FullName: " + FirstName + " " + LastName);
                Console.WriteLine("Email: " + Email);
                Console.WriteLine("Phone: " + Phone);
                Console.WriteLine("CountrayID: " + CountrayID);
                Console.WriteLine("Adresse: " + Adresse);
                Console.WriteLine("ImagePath: " + ImagePath);
                Console.WriteLine();
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
    }
    static void testFindContact(int ID)
    {
        clsContact contact = clsContact.Find(ID);
        
            if (contact != null)
            {
                Console.WriteLine("ID: " + ID);
                Console.WriteLine("FullName: "+contact.firstName + " " + contact.lastname);
                Console.WriteLine("Email: "+contact.email);
                Console.WriteLine("Phone: "+contact.phone);
                Console.WriteLine("Adresse: "+contact.addresse);
                Console.WriteLine("CountrayID: "+contact.countrayID);
                Console.WriteLine("ImagePath: " + contact.ImagePath);
            }
            else
                Console.WriteLine("Contact is not found");
        
    }

    static void testAddNewContact()
    {
        clsContact contact = new clsContact();

        contact.firstName = "Tawfik";
        contact.lastname = "Alawedat";
        contact.email = "Tawfik@";
        contact.phone = "654789";
        contact.countrayID = 1;
        contact.addresse = "";
        contact.ImagePath = "C:\\Users\\khale\\Desktop\\Fotos\\Foto1.jpg";

        if (contact.Save())
        {
            Console.WriteLine("Contact Added successfully with ContactID " + contact.ID);
        }
        else
            Console.WriteLine("Da stimmt was nicht");
    }

    static void testUpdateContact(int ID)
    {
        clsContact contact = clsContact.Find(ID);
        if(contact != null)
        {
            contact.firstName = "Bailassan";
            contact.lastname = "Alawedat";
            contact.email = "Bailassan@";
            contact.phone = "20130";
            contact.countrayID = 3;
            contact.addresse = "";
            contact.ImagePath = "C:\\Users\\khale\\Desktop\\Fotos\\Foto3.jpg";
        }
        if (contact.Save())
        {
            Console.WriteLine("Contact Updated successfully.");
        }
        else
            Console.WriteLine("Contact Updating faild");
    }

    static void testDeleteContact(int ID)
    {
        if (clsContact.IsContactExist(ID))
        {
            if (clsContact.DeleteContact(ID))
            {
                Console.WriteLine("Contact Deleted Successfully");
            }
            else
                Console.WriteLine("Contact Deletion failed");
        }
        else
        {
            Console.WriteLine("No, Contact with id = " + ID + " is not exist");
        }
    }

    static void GetAllContact()
    {
        DataTable dataTable = clsContact.GetAllContact();

        Console.WriteLine("All Contacts");
        foreach (DataRow row in dataTable.Rows)
        {
            Console.WriteLine($"{row["ContactID"]},   {row["FirstName"]} {row["LastName"]}");

        }
    }

    static void IsContactExist(int ID)
    {
        if (clsContact.IsContactExist(ID))
        {
            Console.WriteLine("Yes, Contact with id = " + ID + " is exist");
        }
        else
            Console.WriteLine("No, Contact with id = " + ID + " is not exist");
    }

    static void GetCountryByName(string name)
    {
        clsCountry country = clsCountry.FindByName(name);
        if(country != null)
        {
            Console.WriteLine("CountryID: " + country.CountryID);
            Console.WriteLine("CountryName: " + name);
        }
    }

    static void IsCountryExist(string CountrayName)
    {
        if (clsCountry.IsCountryExist(CountrayName))
        {
            Console.WriteLine("Yes, Country with CountryName [" + CountrayName + "] Exist");
        }
        else
            Console.WriteLine("No, Country with CountryName [" + CountrayName + "] dosn't exist"); 
    }

    static void AddNewCountry()
    {
        clsCountry country = new clsCountry();

        country.CountryName = "Sudan";

        if(country.Save())
        {
            Console.WriteLine("New Country added successfully with CountryID "+ country.CountryID); ;
        }
        else
        {
            Console.WriteLine("New Country Adding is faild");
        }
    }

    static void UpdateCountry(int id)
    {
        clsCountry country = clsCountry.FindByID(id);
        if (country != null)
        {
            country.CountryName = "Libien";
        }
        else
            Console.WriteLine("Country with CountryID " + id + " is not found");

        if (country.Save())
        {
            Console.WriteLine("Country updated successfully.");
        }
        else
            Console.WriteLine("Country Updat is faild.");




    }
   static void Main(string[] args)
   {
        //testAddNewContact();
        testUpdateContact(3);


        Console.ReadLine();
   }
}

