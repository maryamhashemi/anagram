using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using System.Runtime.InteropServices;
using System.IO;
using System.Reflection;

namespace anagram
{
    public partial class Form2 : Form
    {
        //Store the words of Moien Dictionary in words Datatable
        public DataTable words = new DataTable();
        
        public Form2()
        {
            InitializeComponent(); 
        }

        private void Form2_Shown(object sender, EventArgs e)
        {
            //read persian words from .xlsx file and store them in dataTable 
            Excel.Application xlApp;
            Excel.Workbook xlWorkBook;
            Excel.Worksheet xlWorkSheet;
            Excel.Range range;

            xlApp = new Excel.Application();
            string currentDirectory = Directory.GetCurrentDirectory();
            string filePath = System.IO.Path.Combine(currentDirectory, "PersianWords.xlsx");
            xlWorkBook = xlApp.Workbooks.Open(filePath, 0, true, 5, "", "", true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
            xlWorkSheet = xlWorkBook.Sheets[1];
            range = xlWorkSheet.UsedRange;


            words.Columns.Add("moeinWords", typeof(string));
            words.Columns.Add("sorted", typeof(string));

            string str;
            int percent;

            //32646
            for (int i = 5; i <=32646 ; i++)
            {
                str = (range.Cells[i, 2]).Value2;
                DataRow dr = words.NewRow();
                dr["moeinWords"] = str;
                dr["sorted"] = new string(str.OrderBy(c => c).ToArray());
                words.Rows.Add(dr);
                progressBar1.PerformStep();
                percent = (progressBar1.Value*100) / 32646 ;
                label1.Text = percent.ToString() + "%";
                if (percent % 4 == 0)
                    label3.Text = "Loading Moein Dictionary ";
                else if(percent % 4 == 1)
                    label3.Text = "Loading Moein Dictionary .";
                else if (percent % 4 == 2)
                    label3.Text = "Loading Moein Dictionary ..";
                else
                    label3.Text = "Loading Moein Dictionary ...";

            }
            GC.Collect();
            GC.WaitForPendingFinalizers();

            Marshal.ReleaseComObject(range);
            Marshal.ReleaseComObject(xlWorkSheet);

            xlWorkBook.Close();
            Marshal.ReleaseComObject(xlWorkBook);

            xlApp.Quit();
            Marshal.ReleaseComObject(xlApp);

            this.Hide();
            Form1 fr1 = new Form1(words);
            fr1.Show();
        }
    }
}
