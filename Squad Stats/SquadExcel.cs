using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace Squad_Stats
{
    public class SquadExcel
    {
        static Excel.Application m_squadExcelApp;
        Excel.Workbook m_squadWorkbook;
        Excel.Worksheet m_entrySheet;
        string m_excelFile = @"C:\squadstats\excel\csgostats_entry.xlsx";

        public void DoSetup()
        {
            try
            {
                m_squadExcelApp = new Excel.Application();
                try
                {
                    m_squadWorkbook = m_squadExcelApp.Workbooks.Open(m_excelFile);
                    m_entrySheet = m_squadExcelApp.Worksheets.Item[1] as Excel.Worksheet;
                }
                catch (Exception)
                {
                    if (m_squadExcelApp.Workbooks.Count == 0)
                    {
                        m_squadWorkbook = m_squadExcelApp.Workbooks.Add();
                        m_entrySheet = m_squadExcelApp.Worksheets.Item[1] as Excel.Worksheet;
                        CreateLegend();
                        Save();
                    }
                    else
                    {
                        m_entrySheet = m_squadExcelApp.Worksheets.Item[1] as Excel.Worksheet;
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error while seting up excel.\nIt seems Excel isn't installed properly.\n\nOr maybe some other dumb shit. Who know honestly...");
            }
        }

        public void EnterStats(List<int> _playerPosList, List<object> _scoreArrayList)
        {
            int currentPlayerNumber = 0;
            foreach (int playerPos in _playerPosList)
            {
                EnterOnePlayerStatsColumn(playerPos, _scoreArrayList[currentPlayerNumber]);
                currentPlayerNumber++;
            }

            Save();

        }

        private void CreateLegend()
        {
            m_entrySheet.Cells[1, 1] = "RP";
            m_entrySheet.Cells[2, 1] = "K";
            m_entrySheet.Cells[3, 1] = "A";
            m_entrySheet.Cells[4, 1] = "D";
            m_entrySheet.Cells[5, 1] = "K/D";
            m_entrySheet.Cells[7, 1] = "K/R";
            m_entrySheet.Cells[8, 1] = "survivalr";
            m_entrySheet.Cells[9, 1] = "HS%";
            m_entrySheet.Cells[10, 1] = "ADR";
            m_entrySheet.Cells[12, 1] = "fk";
            m_entrySheet.Cells[13, 1] = "fd";
            m_entrySheet.Cells[15, 1] = "1v1";
            m_entrySheet.Cells[16, 1] = "1v2";
            m_entrySheet.Cells[17, 1] = "1v3";
            m_entrySheet.Cells[18, 1] = "1v4";
            m_entrySheet.Cells[19, 1] = "1v5";
            m_entrySheet.Cells[21, 1] = "rating";
        }

        private void EnterOnePlayerStatsColumn(int _playerPos, object _stats)
        {
            _playerPos++;
            IEnumerable statsForeachable = _stats as IEnumerable;
            string[] statsConvertedToArray = new string[34];
            int statNumber = 0;
            foreach (string stat in statsForeachable)
            {
                statsConvertedToArray[statNumber++] = stat;
            }
            m_entrySheet.Cells[1, _playerPos] = "WIP";
            m_entrySheet.Cells[2, _playerPos] = statsConvertedToArray[1];
            m_entrySheet.Cells[3, _playerPos] = statsConvertedToArray[3];
            m_entrySheet.Cells[4, _playerPos] = statsConvertedToArray[2];
            m_entrySheet.Cells[5, _playerPos] = Double.Parse(statsConvertedToArray[1]) / Double.Parse(statsConvertedToArray[2]);
            m_entrySheet.Cells[7, _playerPos] = "WIP";
            m_entrySheet.Cells[8, _playerPos] = "WIP";
            m_entrySheet.Cells[9, _playerPos] = statsConvertedToArray[7];
            m_entrySheet.Cells[10, _playerPos] = statsConvertedToArray[6];
            m_entrySheet.Cells[12, _playerPos] = statsConvertedToArray[8];
            m_entrySheet.Cells[13, _playerPos] = statsConvertedToArray[9];
            m_entrySheet.Cells[15, _playerPos] = statsConvertedToArray[26];
            m_entrySheet.Cells[16, _playerPos] = statsConvertedToArray[25];
            m_entrySheet.Cells[17, _playerPos] = statsConvertedToArray[24];
            m_entrySheet.Cells[18, _playerPos] = statsConvertedToArray[23];
            m_entrySheet.Cells[19, _playerPos] = statsConvertedToArray[22];
            m_entrySheet.Cells[21, _playerPos] = statsConvertedToArray[33];
        }

        public void Save()
        {
            try
            {
                m_squadWorkbook.SaveAs(m_excelFile, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Excel.XlSaveAsAccessMode.xlExclusive, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
            }
            catch (Exception)
            {
                MessageBox.Show("Error while saving Excel File", "Excel Error");
            }
        }

        public void Quit()
        {
            try
            {
                m_squadExcelApp.Application.Quit();
                m_squadExcelApp.Quit();
            }
            catch (Exception)
            {
                MessageBox.Show("Error while quitting Excel.", "Excel Error");
            }
        }
    }
}
