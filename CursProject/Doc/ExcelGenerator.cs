using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using CursProject.Classes;
using Excel = Microsoft.Office.Interop.Excel;

namespace CursProject.Doc
{
    public class ExcelGenerator
    {
        private static readonly string Dir = Application.StartupPath + "\\ExcelFiles";

        public static void ExportTrips(List<TripClient> tcs)
        {
            string fileName = Dir + "\\" + GetFileName();
            if (File.Exists(fileName))
            {
                try
                {
                    File.Delete(fileName);
                }
                catch (Exception)
                {
                    MessageBox.Show(string.Format("В настоящий момент используется файл:\r\n{0}\r\nДля создания договора закройте пожалуйста файл.", fileName),
                        "Невозможно создать договор", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            Random random = new Random();
            Excel.Application xla = new Excel.Application();
            xla.Visible = true;
            Excel.Workbook wb = xla.Workbooks.Add(Excel.XlSheetType.xlWorksheet);

            Excel.Worksheet ws = (Excel.Worksheet)xla.ActiveSheet;

            // Now create the chart.
            Excel.ChartObjects chartObjs = (Excel.ChartObjects)ws.ChartObjects();
            Excel.ChartObject chartObj = chartObjs.Add(512, 80, 300, 300);
            Excel.Chart xlChart = chartObj.Chart;
            xlChart.ChartType = Excel.XlChartType.xlLine;

            // generate some random data
            ws.Cells[2, 2] = "Результативность работы фирмы за период с  _________  по  __________";
            ws.Cells[4, 3] = "№";
            ws.Cells[4, 4] = "Кол-во туров";
            ws.Cells[4, 5] = "Выручка";
            for (int i = 0; i < tcs.Count; i++)
            {
                ws.Cells[5 + i, 3] = i + 1;
                ws.Cells[5 + i, 4] = 1;
                ws.Cells[5 + i, 5] = tcs[i].TotalPrice;
            }

            Excel.Range xValues = ws.Range["C5", "C" + (5 + tcs.Count - 1)];
            Excel.Range values = ws.Range["E5", "E" + (5 + tcs.Count - 1)];

            Excel.SeriesCollection seriesCollection = xlChart.SeriesCollection();

            Excel.Series series1 = seriesCollection.NewSeries();
            series1.XValues = xValues;
            series1.Values = values; 

        }

        private static string GetFileName()
        {
            return string.Format("{0}.xls", Guid.NewGuid()).Replace(" ", "_");
        }
    }
}