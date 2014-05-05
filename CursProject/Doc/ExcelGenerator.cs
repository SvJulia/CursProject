using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using CursProject.Classes;
using CursProject.Helpers;
using Excel = Microsoft.Office.Interop.Excel;

namespace CursProject.Doc
{
    public class ExcelGenerator
    {
        private static readonly string Dir = Application.StartupPath + "\\ExcelFiles";

        public static void ExportTrips(List<TripClient> tcs, DateTime from, DateTime to)
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
            from = from.Date.AddDays(1 - from.Day);
            to = to.Date.AddMonths(1).AddDays(-to.Day);

            ws.Cells[2, 2] = string.Format("Результативность работы фирмы за период с {0} по {1}", from, to);
            ws.Cells[4, 3] = "№";
            ws.Cells[4, 4] = "Кол-во туров";
            ws.Cells[4, 5] = "Выручка";

            int row = 5;
            for (var dateFrom = from; dateFrom <= to; dateFrom = dateFrom.AddMonths(1))
            {
                var dateTo = dateFrom.AddMonths(1).AddDays(-1);
                var trips = tcs.Where(t => t.SaleDate >= dateFrom && t.SaleDate <= dateFrom);
                ws.Cells[row, 3] = StringHelper.GetMonth(dateFrom.Month);
                ws.Cells[row, 4] = trips.Count();
                ws.Cells[row, 5] = trips.Sum(t => t.TotalPrice);
                row++;
            }

            Excel.Range xValues = ws.Range["C5", "C" + (row - 1)];
            Excel.Range values = ws.Range["E5", "E" + (row - 1)];

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