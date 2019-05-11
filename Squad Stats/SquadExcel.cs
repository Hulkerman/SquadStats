using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;

namespace Squad_Stats
{
    public class SquadExcel
    {
        static Excel.Application m_squadExcelApp = new Excel.Application();
        Excel.Workbook m_squadWorkbook = m_squadExcelApp.Workbooks.Open("C:/SquadStats/csgostats.xlsx");
        Excel.Worksheet m_entrySheet = m_squadExcelApp.Worksheets.Item[1] as Excel.Worksheet;
        public Excel.Workbook getSquadWorkbook()
        {
            return m_squadWorkbook;
        }

        public void enterTrainStats()
        {
            Excel.Range entryRange = m_entrySheet.UsedRange;
            int entryRow = entryRange.Rows.Count + 2;
            m_entrySheet.Cells[entryRow, 1] = "here";           // For Testing purposes.
            m_squadExcelApp.Application.ActiveWorkbook.Save();
            m_squadExcelApp.Application.Quit();
            m_squadExcelApp.Quit();
        }
    }
}
