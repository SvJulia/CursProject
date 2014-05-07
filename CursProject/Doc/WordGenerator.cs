using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using CursProject.Classes;
using CursProject.Helpers;
using Microsoft.Office.Interop.Word;
using Application = System.Windows.Forms.Application;

namespace CursProject.Doc
{
    public class WordGenerator
    {
        private static object _ = Type.Missing;
        private static object _endOfDoc = "\\endofdoc"; /* \endofdoc is a predefined bookmark */

        private static readonly string Dir = Application.StartupPath + "\\DocFiles";
        private static readonly string ContractDummy = Application.StartupPath + "\\Contract.doc";

        public static void MakeContract(TripClient tc)
        {
            object fileName = Dir + "\\" + GetFileName(tc);
            if (File.Exists((string) fileName))
            {
                DialogResult dialogResult = MessageBox.Show(string.Format("Договор {0} уже существует. Пересоздать новый договор?", fileName), "Замена договора",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                if (dialogResult != DialogResult.OK)
                {
                    return;
                }

                try
                {
                    File.Delete((string) fileName);
                }
                catch (Exception)
                {
                    MessageBox.Show(string.Format("В настоящий момент используется файл:\r\n{0}\r\nДля создания договора закройте пожалуйста файл.", fileName),
                        "Невозможно создать договор", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            var document = new Document();
            var word = new Microsoft.Office.Interop.Word.Application { Visible = true };
            word.NormalTemplate.Saved = true;

            try
            {
                FileHelper.CopyFile(Dir, ContractDummy, GetFileName(tc));

                document = word.Documents.Open(ref fileName, ref _, ref _, ref _, ref _, ref _, ref _, ref _, ref _, ref _, ref _, ref _, ref _, ref _, ref _,
                    ref _);
                document.Activate();

                FindAndReplace(document, "#number#", tc.Id.ToString());
                FindAndReplace(document, "#date#", tc.SaleDate.ToShortDateString());
                FindAndReplace(document, "#clientFio#", tc.Fio);
                FindAndReplace(document, "#directorsFio#", Settings.DirectorsFio);
                FindAndReplace(document, "#country#", tc.Trip.Tour.City.Country.ToString());
                FindAndReplace(document, "#city#", tc.Trip.Tour.City.ToString());
                FindAndReplace(document, "#dateFrom#", tc.Trip.DateDeparture.ToShortDateString());
                FindAndReplace(document, "#dateTo#", tc.Trip.DateArival.ToShortDateString());
                FindAndReplace(document, "#transport#", tc.Trip.Transport.ToString());
                FindAndReplace(document, "#hotel#", tc.Trip.Hotel.ToString());
                FindAndReplace(document, "#meal#", tc.Trip.Meal.ToString());
                FindAndReplace(document, "#humansCount#", "1");
                FindAndReplace(document, "#totalPrice#", tc.TotalPrice.ToString());
                FindAndReplace(document, "#passport#", tc.Client.DocData);
                FindAndReplace(document, "#email#", tc.Client.Email);
                FindAndReplace(document, "#accountNumber#", tc.Client.AccountNumber);
                FindAndReplace(document, "#address#", tc.Client.Address);
                FindAndReplace(document, "#phone#", tc.Client.Phone);


                FindAndReplace(document, "#fEmail#", Settings.Login);
                FindAndReplace(document, "#fDirectorsFio#", Settings.DirectorsFio);
                FindAndReplace(document, "#fAddress#", Settings.Address);
                FindAndReplace(document, "#fAccountNumber#", Settings.AccountNumber);
                FindAndReplace(document, "#fFirmName#", Settings.FirmName);
                FindAndReplace(document, "#fPhone#", Settings.Phone);

                var excursion = tc.Trip.Tour.TourExcursions.Select(p => p.Excursion).ToList();
                if (excursion.Any())
                {
                    InsertTable(document, "#excursionsTable#", excursion);
                }
                else
                {
                    FindAndReplace(document, "#excursionsTable#", "Без эксурсий");
                }

                document.Save();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Word Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                document.Application.Quit(ref _, ref _, ref _);
                word.Quit(ref _, ref _, ref _);
            }
        }

        private static void InsertTable(Document document, string tableText, List<Excursion> list)
        {
            bool isFound = false;
            do
            {
                isFound = false;
                Range range = document.Range();
                range.Find.Execute(tableText, Forward: true);
                if (range.Find.Found)
                {
                    isFound = true;
                    Table table = document.Tables.Add(range, list.Count + 1, 3, ref _, ref _);
                    table.AllowAutoFit = true;
                    table.AutoFitBehavior(WdAutoFitBehavior.wdAutoFitContent);

                    table.Cell(1, 1).Range.Text = "Название";
                    table.Cell(1, 2).Range.Text = "Описание";
                    table.Cell(1, 3).Range.Text = "Рейтинг";

                    for (int j = 0; j < list.Count; j++)
                    {
                        table.Cell(j + 2, 1).Range.Text = list[j].Name;
                        table.Cell(j + 2, 2).Range.Text = list[j].Description;
                        table.Cell(j + 2, 3).Range.Text = list[j].Rating.ToString();
                    }
                }
            } while (isFound);
        }

        private static void FindAndReplace(Document doc, string findText, string replaceText)
        {
            Range range = doc.Range();
            range.Find.Execute(findText, Replace: WdReplace.wdReplaceAll, ReplaceWith: replaceText);
        }

        private static string GetFileName(TripClient tc)
        {
            return string.Format("{0}_{1}.doc", tc.Id, tc.Client.Fio).Replace(" ", "_");
        }
    }
}