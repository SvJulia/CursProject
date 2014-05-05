using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using CursProject.Classes;
using CursProject.Helpers;
using MigraDoc.DocumentObjectModel.IO;
using MigraDoc.DocumentObjectModel.Shapes;
using MigraDoc.Rendering;
using MigraDoc.DocumentObjectModel;
using PdfSharp.Pdf;
using MigraDoc.DocumentObjectModel.Tables;

namespace CursProject.Doc
{
    public class PdfGenerator
    {
        private static readonly string Dir = Application.StartupPath + "\\PdfFiles";

        public static void MakeInvoice(TripClient tc)
        {
            FileHelper.CreateDirectory(Dir);
            var fileName = Dir + "\\" + GetFileName(tc);
            if (File.Exists(fileName))
            {
                DialogResult dialogResult = MessageBox.Show(string.Format("Счёт на оплату {0} уже существует. Пересоздать новый счёт?", fileName), "Замена договора",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                if (dialogResult != DialogResult.OK)
                {
                    return;
                }

                try
                {
                    File.Delete(fileName);
                }
                catch (Exception)
                {
                    MessageBox.Show(string.Format("В настоящий момент используется файл:\r\n{0}\r\nДля создания счёта закройте пожалуйста файл.", fileName),
                        "Невозможно создать счёт", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            // Create a MigraDoc document
            var document = Documents.CreateInvoice(tc);

            //string ddl = MigraDoc.DocumentObjectModel.IO.DdlWriter.WriteToString(document);
            DdlWriter.WriteToFile(document, "MigraDoc.mdddl");

            var renderer = new PdfDocumentRenderer(true, PdfFontEmbedding.Always);
            renderer.Document = document;

            renderer.RenderDocument();

            // Save the document...
            renderer.PdfDocument.Save(fileName);
            // ...and start a viewer.
            Process.Start(fileName);
        }

        public static string MakeOffer(List<Trip> trips)
        {
            FileHelper.CreateDirectory(Dir);
            var fileName = Dir + "\\" + GetFileName();
            if (File.Exists(fileName))
            {
                try
                {
                    File.Delete(fileName);
                }
                catch (Exception)
                {
                    MessageBox.Show(string.Format("В настоящий момент используется файл:\r\n{0}\r\nДля создания счёта закройте пожалуйста файл.", fileName),
                        "Невозможно создать счёт", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return "";
                }
            }

            // Create a MigraDoc document
            var document = Documents.CreateOffer(trips);

            //string ddl = MigraDoc.DocumentObjectModel.IO.DdlWriter.WriteToString(document);
            DdlWriter.WriteToFile(document, "MigraDoc.mdddl");

            var renderer = new PdfDocumentRenderer(true, PdfFontEmbedding.Always);
            renderer.Document = document;

            renderer.RenderDocument();

            // Save the document...
            renderer.PdfDocument.Save(fileName);
            // ...and start a viewer.
            return fileName;
        }

        private static string GetFileName()
        {
            return string.Format("{0}.pdf", Guid.NewGuid()).Replace(" ", "_");
        }

        private static string GetFileName(TripClient tc)
        {
            return string.Format("{0}_{1}.pdf", tc.Id, tc.Client.Fio).Replace(" ", "_");
        }
    }

    class Documents
    {
        public static Document CreateInvoice(TripClient tc)
        {
            // Create a new MigraDoc document
            var document = new Document { Info = { Title = string.Format("Договор №{0}", tc.Id) } };

            DefineStyles(document);
            DefineContentSection(document);

            var paragraph = document.LastSection.AddParagraph(string.Format("СЧЕТ №{0} от {1} г.", tc.Id, tc.SaleDate.ToShortDateString()), "Heading3");
            paragraph.Format.Alignment = ParagraphAlignment.Center;

            document.LastSection.AddParagraph();
            paragraph = document.LastSection.AddParagraph();
            paragraph.AddText("Заказчик: Иванов Иван Иванович");

            paragraph = document.LastSection.AddParagraph();
            paragraph.AddText(string.Format("Платильщик: {0}; p/c: {1}", tc.Fio, tc.Client.AccountNumber));

            AddInvoiceTable(document, tc);

            paragraph = document.LastSection.AddParagraph();
            paragraph.AddText(string.Format("Всего наименований 1, на сумму {0},00 RUB", tc.TotalPrice));
            paragraph = document.LastSection.AddParagraph();
            paragraph.AddText(StringHelper.RurPhrase(tc.TotalPrice));

            document.LastSection.AddParagraph();
            document.LastSection.AddParagraph();

            AddStamp(document);

            return document;
        }

        public static Document CreateOffer(List<Trip> trips)
        {
            // Create a new MigraDoc document
            var document = new Document { Info = { Title = "Спецпредложения!" } };

            DefineStyles(document);
            DefineContentSection(document);

            var paragraph = document.LastSection.AddParagraph("Спецпредложения!", "Heading3");
            paragraph.Format.Alignment = ParagraphAlignment.Center;

            AddOfferTable(document, trips);

            return document;
        }

        public static void AddStamp(Document document)
        {
            Paragraph paragraph = document.LastSection.AddParagraph("Директор ");

            Image image = paragraph.AddImage("stamp.png");
            image.Width = "3cm";

            paragraph.AddText(" Иванов И.И.");
            paragraph.Format.Alignment = ParagraphAlignment.Center;
        }



        private static void AddInvoiceTable(Document document, TripClient tc)
        {
            document.LastSection.AddParagraph();

            var table = new Table();
            table.Borders.Width = 0.75;

            Column column = table.AddColumn(Unit.FromCentimeter(0.5F));
            column.Format.Alignment = ParagraphAlignment.Center;

            table.AddColumn(Unit.FromCentimeter(7));
            table.AddColumn(Unit.FromCentimeter(3));
            table.AddColumn(Unit.FromCentimeter(2));
            table.AddColumn(Unit.FromCentimeter(2));

            Row row = table.AddRow();
            row.Shading.Color = Colors.PaleGoldenrod;
            row.Cells[0].AddParagraph("№");
            row.Cells[1].AddParagraph("Наименование товара");
            row.Cells[2].AddParagraph("Кол-во, шт.");
            row.Cells[3].AddParagraph("Цена");
            row.Cells[4].AddParagraph("Стоимость");

            row = table.AddRow();
            row.Cells[0].AddParagraph("1");
            row.Cells[1].AddParagraph(string.Format("Оплата по договору №{0} от {1} за туристические услуги", tc.Id, tc.SaleDate.ToShortDateString()));
            row.Cells[2].AddParagraph("1");
            row.Cells[3].AddParagraph(tc.TotalPrice.ToString());
            row.Cells[4].AddParagraph(tc.TotalPrice.ToString());

            row = table.AddRow();
            var paragraf = row.Cells[0].AddParagraph("Итого:");
            paragraf.Format.Alignment = ParagraphAlignment.Right;
            row.Cells[0].MergeRight = 3;
            row.Cells[4].AddParagraph(tc.TotalPrice.ToString());

            table.SetEdge(0, 0, 5, 3, Edge.Box, MigraDoc.DocumentObjectModel.BorderStyle.Single, 1.5, Colors.Black);


            document.LastSection.AddParagraph(" ");
            document.LastSection.AddParagraph(" ");
            document.LastSection.Add(table);
            document.LastSection.AddParagraph(" ");
            document.LastSection.AddParagraph(" ");
        }

        private static void AddOfferTable(Document document, List<Trip> trips)
        {
            document.LastSection.AddParagraph();

            var table = new Table();
            table.Borders.Width = 0.75;

            Column column = table.AddColumn(Unit.FromCentimeter(0.5F));
            column.Format.Alignment = ParagraphAlignment.Center;

            table.AddColumn(Unit.FromCentimeter(7));
            table.AddColumn(Unit.FromCentimeter(3));
            table.AddColumn(Unit.FromCentimeter(3));
            table.AddColumn(Unit.FromCentimeter(1));
            table.AddColumn(Unit.FromCentimeter(1));
            table.AddColumn(Unit.FromCentimeter(2));

            Row row = table.AddRow();
            row.Shading.Color = Colors.PaleGoldenrod;
            row.Cells[0].AddParagraph("№");
            row.Cells[1].AddParagraph("Тур");
            row.Cells[2].AddParagraph("Дата отбытия");
            row.Cells[3].AddParagraph("Дата возвращения");
            row.Cells[4].AddParagraph("Кол-во ночей");
            row.Cells[5].AddParagraph("Кол-во туров");
            row.Cells[6].AddParagraph("Цена");

            for (int i = 0; i < trips.Count; i++)
            {
                row = table.AddRow();
                row.Cells[0].AddParagraph(i.ToString());
                row.Cells[1].AddParagraph(trips[i].ToString());
                row.Cells[2].AddParagraph(trips[i].DateDeparture.ToShortDateString());
                row.Cells[3].AddParagraph(trips[i].DateArival.ToShortDateString());
                row.Cells[4].AddParagraph(trips[i].Nights.ToString());
                row.Cells[5].AddParagraph(trips[i].Amount.ToString());
                row.Cells[6].AddParagraph(trips[i].TotalPrice.ToString());
            }

            table.SetEdge(0, 0, 7, trips.Count + 1, Edge.Box, MigraDoc.DocumentObjectModel.BorderStyle.Single, 1.5, Colors.Black);

            document.LastSection.AddParagraph(" ");
            document.LastSection.AddParagraph(" ");
            document.LastSection.Add(table);
            document.LastSection.AddParagraph(" ");
            document.LastSection.AddParagraph(" ");
        }

        static void DefineStyles(Document document)
        {
            // Get the predefined style Normal.
            Style style = document.Styles["Normal"];
            // Because all styles are derived from Normal, the next line changes the 
            // font of the whole document. Or, more exactly, it changes the font of
            // all styles and paragraphs that do not redefine the font.
            style.Font.Name = "Times New Roman";

            // Heading1 to Heading9 are predefined styles with an outline level. An outline level
            // other than OutlineLevel.BodyText automatically creates the outline (or bookmarks) 
            // in PDF.

            style = document.Styles["Heading1"];
            style.Font.Name = "Tahoma";
            style.Font.Size = 20;
            style.Font.Bold = true;
            style.Font.Color = Colors.DarkBlue;
            style.ParagraphFormat.PageBreakBefore = true;
            style.ParagraphFormat.SpaceAfter = 6;

            style = document.Styles["Heading2"];
            style.Font.Size = 18;
            style.Font.Bold = true;
            style.ParagraphFormat.PageBreakBefore = false;
            style.ParagraphFormat.SpaceBefore = 6;
            style.ParagraphFormat.SpaceAfter = 6;

            style = document.Styles["Heading3"];
            style.Font.Size = 16;
            style.Font.Bold = true;
            style.Font.Italic = true;
            style.ParagraphFormat.SpaceBefore = 6;
            style.ParagraphFormat.SpaceAfter = 3;

            style = document.Styles[StyleNames.Header];
            style.ParagraphFormat.AddTabStop("16cm", MigraDoc.DocumentObjectModel.TabAlignment.Right);

            style = document.Styles[StyleNames.Footer];
            style.ParagraphFormat.AddTabStop("8cm", MigraDoc.DocumentObjectModel.TabAlignment.Center);

            // Create a new style called TextBox based on style Normal
            style = document.Styles.AddStyle("TextBox", "Normal");
            style.Font.Size = 14;
            style.ParagraphFormat.Alignment = ParagraphAlignment.Justify;
            style.ParagraphFormat.Borders.Width = 2.5;
            style.ParagraphFormat.Borders.Distance = "3pt";

            //TODO: Colors
            style.ParagraphFormat.Shading.Color = Colors.SkyBlue;

            // Create a new style called TOC based on style Normal
            style = document.Styles.AddStyle("TOC", "Normal");
            style.ParagraphFormat.AddTabStop("16cm", MigraDoc.DocumentObjectModel.TabAlignment.Right, TabLeader.Dots);
            style.ParagraphFormat.Font.Color = Colors.Blue;
        }

        /// <summary>
        /// Defines page setup, headers, and footers.
        /// </summary>
        static void DefineContentSection(Document document)
        {
            Section section = document.AddSection();
            section.PageSetup.OddAndEvenPagesHeaderFooter = true;
            section.PageSetup.StartingNumber = 1;

            // Create a paragraph with centered page number. See definition of style "Footer".
            var paragraph = new Paragraph();
            paragraph.AddTab();
            paragraph.AddPageField();

            // Add paragraph to footer for odd pages.
            section.Footers.Primary.Add(paragraph);
            // Add clone of paragraph to footer for odd pages. Cloning is necessary because an object must
            // not belong to more than one other object. If you forget cloning an exception is thrown.
            section.Footers.EvenPage.Add(paragraph.Clone());
        }
    }
}