using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using CursProject.Classes;
using Microsoft.Office.Interop.Word;
using Application = System.Windows.Forms.Application;

namespace CursProject.Helpers
{
    public class WordHelper
    {
        private static object _ = Type.Missing;
        private static object _endOfDoc = "\\endofdoc"; /* \endofdoc is a predefined bookmark */

        private static readonly string DocDir = Application.StartupPath + "\\DocFiles";
        private static readonly string DogovorDummy = Application.StartupPath + "\\Dogovor.doc";

        public static void MakeDogovor(TripClient tc)
        {
            object fileName = DocDir + "\\" + GetFileName(tc);
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
                FileHelper.CopyFile(DocDir, DogovorDummy, GetFileName(tc));

                document = word.Documents.Open(ref fileName, ref _, ref _, ref _, ref _, ref _, ref _, ref _, ref _, ref _, ref _, ref _, ref _, ref _, ref _,
                    ref _);
                document.Activate();

                FindAndReplace(document, "#number#", tc.Id.ToString());
                FindAndReplace(document, "#date#", DateTime.Now.ToShortDateString());
                FindAndReplace(document, "#clientFio#", tc.Fio);
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
                InsertTable(document, "#excursionsTable#", tc.Trip.Tour.TourExcursions.Select(p => p.Excursion).ToList());

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

        private static string GetMonth(int month)
        {
            switch (month)
            {
                case 1:
                    return "января";
                case 2:
                    return "февраля";
                case 3:
                    return "марта";
                case 4:
                    return "апреля";
                case 5:
                    return "мая";
                case 6:
                    return "июня";
                case 7:
                    return "июля";
                case 8:
                    return "августа";
                case 9:
                    return "сентября";
                case 10:
                    return "октября";
                case 11:
                    return "ноября";
                case 12:
                    return "декабря";
                default:
                    return "нет такого месяца";
            }
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

        private static string GetFileName(Client client)
        {
            string year = DateTime.Now.Year.ToString();
            string month = DateTime.Now.Month.ToString();
            if (month.Length == 1)
            {
                month = "0" + month;
            }

            string day = DateTime.Now.Day.ToString();
            if (day.Length == 1)
            {
                day = "0" + day;
            }

            return string.Format("{0}_{1}{2}{3}.doc", client.Fio, year, month, day).Replace(" ", "_");
        }

        #region RurPhrase

        private static string RurPhrase(decimal money)
        {
            return CurPhrase(money, "рубль", "рубля", "рублей", "копейка", "копейки", "копеек");
        }

        private static string NumPhrase(ulong Value, bool IsMale)
        {
            if (Value == 0UL)
            {
                return "Ноль";
            }
            string[] dek1 =
            {
                "", " од", " дв", " три", " четыре", " пять", " шесть", " семь", " восемь", " девять", " десять", " одиннадцать", " двенадцать",
                " тринадцать", " четырнадцать", " пятнадцать", " шестнадцать", " семнадцать", " восемнадцать", " девятнадцать"
            };
            string[] dek2 = { "", "", " двадцать", " тридцать", " сорок", " пятьдесят", " шестьдесят", " семьдесят", " восемьдесят", " девяносто" };
            string[] dek3 = { "", " сто", " двести", " триста", " четыреста", " пятьсот", " шестьсот", " семьсот", " восемьсот", " девятьсот" };
            string[] Th = { "", "", " тысяч", " миллион", " миллиард", " триллион", " квадрилион", " квинтилион" };
            string str = "";
            for (byte th = 1; Value > 0; th++)
            {
                var gr = (ushort) (Value % 1000);
                Value = (Value - gr) / 1000;
                if (gr > 0)
                {
                    var d3 = (byte) ((gr - gr % 100) / 100);
                    var d1 = (byte) (gr % 10);
                    var d2 = (byte) ((gr - d3 * 100 - d1) / 10);
                    if (d2 == 1)
                    {
                        d1 += 10;
                    }
                    bool ismale = (th > 2) || ((th == 1) && IsMale);
                    str = dek3[d3] + dek2[d2] + dek1[d1] + EndDek1(d1, ismale) + Th[th] + EndTh(th, d1) + str;
                }
            }

            str = str.Substring(1, 1).ToUpper() + str.Substring(2);
            return str;
        }

        private static string CurPhrase(decimal money, string word1, string word234, string wordmore, string sword1, string sword234, string swordmore)
        {
            money = decimal.Round(money, 2);
            decimal decintpart = decimal.Truncate(money);
            ulong intpart = decimal.ToUInt64(decintpart);
            string str = NumPhrase(intpart, true) + " ";
            var endpart = (byte) (intpart % 100UL);
            if (endpart > 19)
            {
                endpart = (byte) (endpart % 10);
            }
            switch (endpart)
            {
                case 1:
                    str += word1;
                    break;
                case 2:
                case 3:
                case 4:
                    str += word234;
                    break;
                default:
                    str += wordmore;
                    break;
            }
            byte fracpart = decimal.ToByte((money - decintpart) * 100M);
            str += " " + ((fracpart < 10) ? "0" : "") + fracpart + " ";
            if (fracpart > 19)
            {
                fracpart = (byte) (fracpart % 10);
            }
            switch (fracpart)
            {
                case 1:
                    str += sword1;
                    break;
                case 2:
                case 3:
                case 4:
                    str += sword234;
                    break;
                default:
                    str += swordmore;
                    break;
            }
            ;
            return str;
        }

        private static string EndTh(byte thNum, byte dek)
        {
            bool in234 = ((dek >= 2) && (dek <= 4));
            bool more4 = ((dek > 4) || (dek == 0));
            if (((thNum > 2) && in234) || ((thNum == 2) && (dek == 1)))
            {
                return "а";
            }
            if ((thNum > 2) && more4)
            {
                return "ов";
            }
            if ((thNum == 2) && in234)
            {
                return "и";
            }
            return "";
        }

        private static string EndDek1(byte dek, bool isMale)
        {
            if ((dek > 2) || (dek == 0))
            {
                return "";
            }

            if (dek == 1)
            {
                if (isMale)
                {
                    return "ин";
                }
                return "на";
            }

            if (isMale)
            {
                return "а";
            }
            return "е";
        }

        #endregion
    }
}