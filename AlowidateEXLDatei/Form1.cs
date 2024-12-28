using System.Data;
using ClosedXML.Excel;
using System.Windows.Forms;

namespace AlowidateEXLDatei
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private string excelDateipfad = "C:\\Users\\khale\\Desktop\\Alowidat Name Exel Neu.xlsx";
        public void ExcelInDataGridViewLaden()
        {
            using (var workbook = new XLWorkbook(excelDateipfad))
            {
                // Erster Tabellenblatt wird geladen
                var worksheet = workbook.Worksheet(1);
                DataTable dt = new DataTable();

                // Kopiere die Kopfzeilen
                bool ersteZeile = true;
                foreach (var row in worksheet.RowsUsed())
                {
                    if (ersteZeile)
                    {
                        foreach (var cell in row.Cells())
                        {
                            dt.Columns.Add(cell.Value.ToString());
                        }
                        ersteZeile = false;
                    }
                    else
                    {
                        dt.Rows.Add();
                        int i = 0;
                        foreach (var cell in row.Cells())
                        {
                            dt.Rows[dt.Rows.Count - 1][i] = cell.Value;
                            i++;
                        }
                    }
                }

                // Daten in DataGridView laden
                dataGridView1.DataSource = dt;
            }
        }

        private void Form1_Load(object sender, System.EventArgs e)
        {
            ExcelInDataGridViewLaden();
        }
    }
}
