using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using CursProject.Classes;
using uno;
using unoidl.com.sun.star.lang;
using unoidl.com.sun.star.uno;
using unoidl.com.sun.star.bridge;
using unoidl.com.sun.star.frame;
using unoidl.com.sun.star.text;
using unoidl.com.sun.star.beans;
using unoidl.com.sun.star.sheet;
using unoidl.com.sun.star.container;

namespace CursProject.Doc
{
    public class CalcGenerator
    {
        private static readonly string Dir = Application.StartupPath + "\\CalcFiles";

        public static void ExportTrips(List<Trip> trips)
        {
            string fileName = Dir + "\\" + GetFileName();
            if (File.Exists(fileName))
            {
                DialogResult dialogResult = MessageBox.Show(string.Format("Договор {0} уже существует. Пересоздать новый договор?", fileName), "Замена договора",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                if (dialogResult != DialogResult.OK)
                {
                    return;
                }

                try
                {
                    File.Delete((string)fileName);
                }
                catch (System.Exception)
                {
                    MessageBox.Show(string.Format("В настоящий момент используется файл:\r\n{0}\r\nДля создания договора закройте пожалуйста файл.", fileName),
                        "Невозможно создать договор", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            var oStrap = uno.util.Bootstrap.bootstrap();
            var oServMan = (XMultiServiceFactory)oStrap.getServiceManager();
            var oDesk = (XComponentLoader)oServMan.createInstance("com.sun.star.frame.Desktop");

            string url = @"private:factory/scalc";
            var propVals = new PropertyValue[1];
            propVals[0] = new PropertyValue { Name = "Hidden", Value = new Any(true) };

            var oDoc = oDesk.loadComponentFromURL(url, "_blank", 0, propVals);

            var oSheets = ((XSpreadsheetDocument)oDoc).getSheets();
            var oSheetsIA = (XIndexAccess)oSheets;
            var oSheet = (XSpreadsheet)oSheetsIA.getByIndex(0).Value;

            var oCell = oSheet.getCellByPosition(0, 0); 
            ((XText)oCell).setString("Тур");

            oCell = oSheet.getCellByPosition(1, 0);
            ((XText)oCell).setString("Дата отбытия");

            oCell = oSheet.getCellByPosition(2, 0); 
            ((XText)oCell).setString("Дата возвращения");

            oCell = oSheet.getCellByPosition(3, 0);
            ((XText)oCell).setString("Кол-во ночей");

            oCell = oSheet.getCellByPosition(4, 0); 
            ((XText)oCell).setString("Кол-во туров");

            oCell = oSheet.getCellByPosition(5, 0);
            ((XText)oCell).setString("Цена");

            for (int i = 0; i < trips.Count; i++)
            {
                var trip = trips[i];
                oCell = oSheet.getCellByPosition(0, i + 1);
                ((XText)oCell).setString(trip.Tour.ToString());

                oCell = oSheet.getCellByPosition(1, i + 1);
                ((XText)oCell).setString(trip.DateDeparture.ToShortDateString());

                oCell = oSheet.getCellByPosition(2, i + 1);
                ((XText) oCell).setString(trip.DateArival.ToShortDateString());

                oCell = oSheet.getCellByPosition(3, i + 1);
                ((XText) oCell).setString(trip.Nights.ToString());

                oCell = oSheet.getCellByPosition(4, i + 1);
                ((XText) oCell).setString(trip.Amount.ToString());

                oCell = oSheet.getCellByPosition(5, i + 1);
                ((XText) oCell).setString(trip.TotalPrice.ToString());
            }

            ((XStorable)oDoc).storeAsURL("file:///" + fileName.Replace("\\", "/"), propVals);
            oDoc.dispose();

            Process.Start(fileName);
        }

        private static string GetFileName()
        {
            return string.Format("{0}.ods", Guid.NewGuid()).Replace(" ", "_");
        }
    }
}