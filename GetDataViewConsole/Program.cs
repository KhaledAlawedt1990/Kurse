using System.Data;

namespace GetDataViewConsole
{
    internal class Program
    {
        static DataTable? _ClientDataTable;
        static DataView? _ClientDataView;
        static void CreatDataTable()
        {
            _ClientDataTable = new DataTable();

            DataColumn dtColumn;
            dtColumn = new DataColumn();
            dtColumn.DataType = typeof(int);
            dtColumn.ColumnName = "ID";
            dtColumn.ReadOnly = true;
            dtColumn.AllowDBNull = false;
            dtColumn.AutoIncrement = true;
            dtColumn.AutoIncrementSeed = 1;
            dtColumn.AutoIncrementStep = 1;
            dtColumn.Caption = "Client ID";
            dtColumn.Unique = true;
            _ClientDataTable.Columns.Add(dtColumn);

            DataColumn[] PrimaryKey = new DataColumn[1];
            PrimaryKey[0] = _ClientDataTable.Columns["ID"];
            _ClientDataTable.PrimaryKey = PrimaryKey;

            dtColumn = new DataColumn();
            dtColumn.DataType = typeof(string);
            dtColumn.ColumnName = "Name";
            dtColumn.Caption = "Name";
            dtColumn.AllowDBNull = false;
            _ClientDataTable.Columns.Add(dtColumn);

            dtColumn = new DataColumn();
            dtColumn.DataType = typeof(string);
            dtColumn.ColumnName = "Country";
            dtColumn.Caption = "Country";
            dtColumn.AllowDBNull = false;
            _ClientDataTable.Columns.Add(dtColumn);

            dtColumn = new DataColumn();
            dtColumn.DataType = typeof(DateTime);
            dtColumn.ColumnName = "BirthDate";
            dtColumn.Caption = "BirthDate";
            dtColumn.AllowDBNull = false;
           _ClientDataTable.Columns.Add(dtColumn);

            dtColumn = new DataColumn();
            dtColumn.DataType = typeof(Double);
            dtColumn.ColumnName = "Salary";
            dtColumn.Caption = "Salary";
            dtColumn.AllowDBNull = false;
            _ClientDataTable.Columns.Add(dtColumn);

           _ClientDataTable.Rows.Add(null,"Khaled Alawedat","Syrien", DateTime.Now, 1255);
            _ClientDataTable.Rows.Add(null, "Khadijah Alawidat", "Syrien", DateTime.Now, 500);
            _ClientDataTable.Rows.Add(null, "Bailassan Alawedat", "Deutschland", DateTime.Now, 250);
            _ClientDataTable.Rows.Add(null, "Hamssa Alawedat", "Frankreich", DateTime.Now, 250);
            Console.WriteLine();
            foreach(DataRow row in  _ClientDataTable.Rows)
            {
                Console.WriteLine("ID:{0},\t Name: {1},\t Country: {2},\t BirthDate: {3},\t Salary: {4}",
                     row["ID"],row["Name"],row["Country"],row["BirthDate"],row["Salary"]);
            }

        }

        static void CereateDataView()
        {
           

            _ClientDataView = _ClientDataTable.DefaultView;

            Console.WriteLine("\nClient DataView:\n ");

            for (int i = 0; i < _ClientDataView.Count; i++)
            {
                Console.WriteLine("Client ID:{0},\t Name: {1},\t Country: {2}," +
                    " \tBirthDate: {3},\t Salary: {4}" +
                    _ClientDataView[i][0], _ClientDataView[i][1], _ClientDataView[i][2],
                    _ClientDataView[i][3], _ClientDataView[i][4]);

            }
            Console.WriteLine();
        }

        static void DataViewFilter()
        {
            _ClientDataView.RowFilter = "Country = 'Syrien' or Country = 'Frankreich'";

            Console.WriteLine("####Client List for DataView after Filtering 'Syrien' and 'Frankreich'");
            for (int i = 0; i < _ClientDataView.Count; i++)
            {
                Console.WriteLine("Client ID:{0},\t Name: {1},\t Country: {2},\t" +
                    " BirthDate: {3},\t " +
                    "Salary: {4}", _ClientDataView[i][0], _ClientDataView[i][1], _ClientDataView[i][2],
                    _ClientDataView[i][3], _ClientDataView[i][4]);

            }
            Console.WriteLine();
        }

        static void DataViewSoting()
        {
            _ClientDataView.Sort = "Name Asc";

            Console.WriteLine("####Client List for DataView after sorting Name Asc");
            for (int i = 0; i < _ClientDataView.Count; i++)
            {
                Console.WriteLine("Client ID:{0},\t Name: {1},\t Country: {2},\t" +
                    " BirthDate: {3},\t " +
                    "Salary: {4}", _ClientDataView[i][0], _ClientDataView[i][1], _ClientDataView[i][2],
                    _ClientDataView[i][3], _ClientDataView[i][4]);

            }
            Console.WriteLine();
        }

        static void CreateDateTablesAndInsertToDataSet()
        {
            DataTable EmployeesDataTable = new DataTable("EmployeesDataTable");

            EmployeesDataTable.Columns.Add("ID", typeof(int));
            EmployeesDataTable.Columns.Add("Name", typeof(string));
            EmployeesDataTable.Columns.Add("Country", typeof(string));
            EmployeesDataTable.Columns.Add("BirthDate", typeof(DateTime));
            EmployeesDataTable.Columns.Add("Salary", typeof(double));


            EmployeesDataTable.Rows.Add(1, "Khaled Alawedat",   "Syrien", DateTime.Now, 1255);
            EmployeesDataTable.Rows.Add(2, "Khadijah Alawedat", "Italien", DateTime.Now, 250);  
            EmployeesDataTable.Rows.Add(3, "Bailassan Alawedat", "Deutschland", DateTime.Now, 250);
            EmployeesDataTable.Rows.Add(4, "Hamssa Alawedat",    "Frankreich", DateTime.Now, 250);

            Console.WriteLine("#####Employee Data in DataTable: ###\n");
            foreach(DataRow row in EmployeesDataTable.Rows)
            {
                Console.WriteLine("ID: {0},\t Name: {1},\t Country: {2},\t BirthDate: {3},\t" +
                    "Salary: {4}", row["ID"], row["Name"], row["Country"], row["BirthDate"], row["Salary"]);
            }
            Console.WriteLine();

            DataTable DepartmentsDataTable = new DataTable("DepartmentsDataTable");

            DepartmentsDataTable.Columns.Add("ID", typeof(int));
            DepartmentsDataTable.Columns.Add("DepartmentName", typeof(string));

            DepartmentsDataTable.Rows.Add(1, "IT");
            DepartmentsDataTable.Rows.Add(2, "Markting");
            DepartmentsDataTable.Rows.Add(3, "Programmig");

            Console.WriteLine("\n####Department DataTable###");
            foreach(DataRow row in DepartmentsDataTable.Rows)
            {
                Console.WriteLine("ID: {0},\t Name: {1}", row["ID"], row["DepartmentName"]);
            }
            Console.WriteLine();

            DataSet dataset = new DataSet();
            dataset.Tables.Add(EmployeesDataTable);
            dataset.Tables.Add(DepartmentsDataTable);

            Console.WriteLine("\n###Printing the Employees Data from the DataSet###");
            foreach(DataRow row in dataset.Tables["EmployeesDataTable"].Rows)
            {
                Console.WriteLine("ID: {0},\t Name: {1},\t Country: {2},\t BirthDate: {3},\t" +
                   "Salary: {4}", row["ID"], row["Name"], row["Country"], row["BirthDate"], row["Salary"]);
            }

            Console.WriteLine("\n###Printing the Department Data from the DataSet###");
            foreach(DataRow row in dataset.Tables["DepartmentsDataTable"].Rows)
            {
                Console.WriteLine("ID: {0},\t Department Name: {1}", row["ID"], row["DepartmentName"]);
            }

        
        }

        static void Main(string[] args)
        {
            //CreatDataTable();
            //CereateDataView();
            //DataViewSoting();
            //DataViewFilter();

            CreateDateTablesAndInsertToDataSet();

            Console.ReadLine();
        }
    }
}
