using System;
using System.Data;
using System.Linq;

public class clsClass
{


    public static void GetDataTable()
    {
        DataTable ClientDataTable = new DataTable();

        //ClientDataTable.Columns.Add("ID", typeof(int));
        //ClientDataTable.Columns.Add("Name", typeof(string));
        //ClientDataTable.Columns.Add("Country", typeof(string));
        //ClientDataTable.Columns.Add("BirthDate", typeof(DateTime));
        //ClientDataTable.Columns.Add("Salary", typeof(Decimal));

        DataColumn dtColumn = new DataColumn();

        dtColumn.DataType = typeof(int);
        dtColumn.ColumnName = "ID";
        dtColumn.AutoIncrement = true;
        dtColumn.AutoIncrementSeed = 1;
        dtColumn.AutoIncrementStep = 1;
        dtColumn.Caption = "Client ID";
        dtColumn.ReadOnly = true;
        dtColumn.Unique = true;
        ClientDataTable.Columns.Add(dtColumn);

        dtColumn = new DataColumn();
        dtColumn.DataType = typeof(string);
        dtColumn.ColumnName = "Name";
        dtColumn.Caption = "Name";
        dtColumn.AllowDBNull = false;
        ClientDataTable.Columns.Add(dtColumn);

        dtColumn = new DataColumn();
        dtColumn.DataType = typeof(string);
        dtColumn.ColumnName = "Country";
        dtColumn.Caption = "Name";
        dtColumn.AllowDBNull = false;
        ClientDataTable.Columns.Add(dtColumn);

        dtColumn = new DataColumn();
        dtColumn.DataType = typeof(DateTime);
        dtColumn.ColumnName = "BirthDate";
        dtColumn.Caption = "BithDate";
        dtColumn.AllowDBNull = false;
        ClientDataTable.Columns.Add(dtColumn);

        dtColumn = new DataColumn();
        dtColumn.DataType = typeof(Double);
        dtColumn.ColumnName = "Salary";
        dtColumn.Caption = "Salary";
        dtColumn.AllowDBNull = false;
        ClientDataTable.Columns.Add(dtColumn);

        // Primary Key Defination....
        DataColumn[] PrimaryKey = new DataColumn[1];
        PrimaryKey[0] = ClientDataTable.Columns["iD"];
        ClientDataTable.PrimaryKey = PrimaryKey;
         

        ClientDataTable.Rows.Add(null, "Khaled Alawedat", "Syrien", DateTime.Now, 300);
        ClientDataTable.Rows.Add(null, "Mohammad Alawedat", "Syrien", DateTime.Now, 2500);
        ClientDataTable.Rows.Add(null, "Khadijah Alawedat", "Syrien", DateTime.Now, 2500);
        ClientDataTable.Rows.Add(null, "Bailassan Alawedat", "Deutschland", DateTime.Now, 1200);
        ClientDataTable.Rows.Add(null, "Hamssa Alawedat", "Deutschland", DateTime.Now, 2);

      

        int ClientCount = 0;
        double SumSalary = 0;
        double AvgSalary = 0;
        double MaxSalary = 0;
        double MinSalary = 0;

        ClientCount = ClientDataTable.Rows.Count;
        SumSalary = Convert.ToDouble(ClientDataTable.Compute("Sum(Salary)", string.Empty));
        AvgSalary = Convert.ToDouble(ClientDataTable.Compute("Avg(Salary)", string.Empty));
        MaxSalary = Convert.ToDouble(ClientDataTable.Compute("Max(Salary)", string.Empty));
        MinSalary = Convert.ToDouble(ClientDataTable.Compute("Min(Salary)", string.Empty));

        
            foreach (DataRow row in ClientDataTable.Rows)
            {
                Console.WriteLine("ID: {0}\t, Name: {1}\t,      Country: {2}\t, BirthDate: {3}\t," +
                     "Salary: {4}", row["ID"], row["Name"], row["Country"], row["BirthDate"],
                       row["Salary"]);
            }

        // Update Contact

        DataRow[] result = ClientDataTable.Select("ID = 1");

        foreach (var RecordRow in result)
        {
            RecordRow["Name"] = "Maha Fadi";
            RecordRow["Salary"] = 5000;
        }
        ClientDataTable.AcceptChanges();

        Console.WriteLine("\n\nContact List  after Updating ID = 1\n");

        foreach (DataRow row in ClientDataTable.Rows)
        {
            Console.WriteLine("ID: {0}\t, Name: {1}\t,      Country: {2}\t, BirthDate: {3}\t," +
                 "Salary: {4}", row["ID"], row["Name"], row["Country"], row["BirthDate"],
                   row["Salary"]);
        }

        ClientDataTable.Clear();


        //    // Delete Contact 
        //DataRow[] result;
        //result = ClientDataTable.Select("ID = 2");

        //foreach(var RecordRow in result)
        //{
        //    RecordRow.Delete();
        //}
        //ClientDataTable.AcceptChanges();

        //Console.WriteLine("\n\nContact List after Deleting ID = 2\n" );
        //foreach (DataRow row in ClientDataTable.Rows)
        //{
        //    Console.WriteLine("ID: {0}\t, Name: {1}\t,      Country: {2}\t, BirthDate: {3}\t," +
        //         "Salary: {4}", row["ID"], row["Name"], row["Country"], row["BirthDate"],
        //           row["Salary"]);
        //}

        // // Descending Orgenize
        // ClientDataTable.DefaultView.Sort = "ID Desc";
        //ClientDataTable = ClientDataTable.DefaultView.ToTable();

        //Console.WriteLine("\n\nClient List Sorted by ID Descending\n");

        //foreach (DataRow row in ClientDataTable.Rows)
        //{
        //    Console.WriteLine("ID: {0}\t, Name: {1}\t,      Country: {2}\t, BirthDate: {3}\t," +
        //         "Salary: {4}", row["ID"], row["Name"], row["Country"], row["BirthDate"],
        //           row["Salary"]);
        //}

        // //Ascending Orgenize
        //ClientDataTable.DefaultView.Sort = "Name Asc";
        //ClientDataTable = ClientDataTable.DefaultView.ToTable();

        //Console.WriteLine("\n\nClient List Sorted by Name Ascending\n");
        //foreach (DataRow row in ClientDataTable.Rows)
        //{
        //    Console.WriteLine("ID: {0}\t, Name: {1}\t,      Country: {2}\t, BirthDate: {3}\t," +
        //         "Salary: {4}", row["ID"], row["Name"], row["Country"], row["BirthDate"],
        //           row["Salary"]);
        //}

        //Console.WriteLine();
        //    Console.WriteLine("Client Count = " + ClientCount);
        //    Console.WriteLine("Sum Salary = " + SumSalary);
        //    Console.WriteLine("Avg Salary = " + AvgSalary);
        //    Console.WriteLine("Max Salary = " + MaxSalary);
        //    Console.WriteLine("Min Salary = " + MinSalary);


        //Console.WriteLine("\n\nClient Data With Fitering");

        //ClientCount = ClientDataTable.Rows.Count;
        //SumSalary = Convert.ToDouble(ClientDataTable.Compute("Sum(Salary)", "Country = 'Syrien' "));
        //AvgSalary = Convert.ToDouble(ClientDataTable.Compute("Avg(Salary)", "Salary < 1000"));
        //MaxSalary = Convert.ToDouble(ClientDataTable.Compute("Max(Salary)", "Country = 'Deutschland' "));
        //MinSalary = Convert.ToDouble(ClientDataTable.Compute("Min(Salary)", "Country = 'Deutschland' "));

        //Console.WriteLine();
        //Console.WriteLine("Client Count = " + ClientCount);
        //Console.WriteLine("Sum Salary = " + SumSalary);
        //Console.WriteLine("Avg Salary = " + AvgSalary);
        //Console.WriteLine("Max Salary = " + MaxSalary);
        //Console.WriteLine("Min Salary = " + MinSalary);


        //DataRow[] resultRows;

        //resultRows = ClientDataTable.Select("Country = 'Syrien'");

        //Console.WriteLine("\n\nFilter \"Syrien\" Client\n");

        //ClientCount = resultRows.Count();
        //Console.WriteLine("Result Count = " + ClientCount);

        //foreach (DataRow row in resultRows)
        //{
        //    Console.WriteLine("ID: {0}\t, Name: {1}\t,      Country: {2}\t, BirthDate: {3}\t," +
        //         "Salary: {4}", row["ID"], row["Name"], row["Country"], row["BirthDate"],
        //           row["Salary"]);
        //}




        //resultRows = ClientDataTable.Select("Country = 'Deutschland' ");
        //ClientCount = resultRows.Count();

        //Console.WriteLine("\n\nFilter \"Deuschland\" Client\n");
        //Console.WriteLine("Result Count = " + ClientCount);

        //foreach (DataRow row in resultRows)
        //{
        //    Console.WriteLine("ID: {0}\t, Name: {1}\t,      Country: {2}\t, BirthDate: {3}\t," +
        //         "Salary: {4}", row["ID"], row["Name"], row["Country"], row["BirthDate"],
        //           row["Salary"]);
        //}

        //resultRows = ClientDataTable.Select("Salary = '2500' ");
        //ClientCount = resultRows.Count();

        //Console.WriteLine("\n\nFilter \"Salary = 2500\" Client\n");
        //Console.WriteLine("Result Count = " + ClientCount);

        //foreach (DataRow row in resultRows)
        //{
        //    Console.WriteLine("ID: {0}\t, Name: {1}\t,      Country: {2}\t, BirthDate: {3}\t," +
        //         "Salary: {4}", row["ID"], row["Name"], row["Country"], row["BirthDate"],
        //           row["Salary"]);
        //}

        //resultRows = ClientDataTable.Select("Salary = '2500' and Country = 'Syrien' ");
        //ClientCount = resultRows.Count();

        //Console.WriteLine("\n\nFilter \"Salary = 2500 and Country = Syrien\" Client\n");
        //Console.WriteLine("Result Count = " + ClientCount);

        //foreach (DataRow row in resultRows)
        //{
        //    Console.WriteLine("ID: {0}\t, Name: {1}\t,      Country: {2}\t, BirthDate: {3}\t," +
        //         "Salary: {4}", row["ID"], row["Name"], row["Country"], row["BirthDate"],
        //           row["Salary"]);
        //}



        //resultRows = ClientDataTable.Select("Country = 'Deutschland' ");
        //ClientCount = resultRows.Count();

        //Console.WriteLine("\n\nFilter \"Deuschland\" Client\n");
        //Console.WriteLine("Result Count = " + ClientCount);

        //foreach (DataRow row in resultRows)
        //{
        //    Console.WriteLine("ID: {0}\t, Name: {1}\t,      Country: {2}\t, BirthDate: {3}\t," +
        //         "Salary: {4}", row["ID"], row["Name"], row["Country"], row["BirthDate"],
        //           row["Salary"]);
        //}

        //resultRows = ClientDataTable.Select("Salary = '2500' ");
        //ClientCount = resultRows.Count();

        //Console.WriteLine("\n\nFilter \"Deuschland\" Client\n");
        //Console.WriteLine("Result Count = " + ClientCount);

        //foreach (DataRow row in resultRows)
        //{
        //    Console.WriteLine("ID: {0}\t, Name: {1}\t,      Country: {2}\t, BirthDate: {3}\t," +
        //         "Salary: {4}", row["ID"], row["Name"], row["Country"], row["BirthDate"],
        //           row["Salary"]);
        //}



    }

    static void Main(string[] args)
    {

        GetDataTable();

        Console.ReadLine();
    }
}
   

