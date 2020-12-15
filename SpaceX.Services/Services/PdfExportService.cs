using iTextSharp.text;
using iTextSharp.text.pdf;
using SpaceX.Models;
using SpaceX.Services.Contracts;
using System.Collections.Generic;
using System.IO;

namespace SpaceX.Services
{
    /// <summary>
    /// A service class which contains methods for populating data into an Pdf file
    /// </summary>
    public class PdfExportService : IPdfExportService
    {
        #region Public Methods

        public byte[] Export(List<LaunchPlan> launchPlans)
        {
            Document document = new Document();
            PdfPTable pdfTable = new PdfPTable(8);
            PdfPCell pdfCell = new PdfPCell();
            Font fontStyle = new Font();
            MemoryStream memoryStream = new MemoryStream();

            document.SetPageSize(PageSize.A4);
            document.SetMargins(5f, 5f, 20f, 5f);

            SetAlignment(pdfTable);

            fontStyle = FontFactory.GetFont("Tahoma", 8f, 1);
            PdfWriter docWrite = PdfWriter.GetInstance(document, memoryStream);

            document.Open();

            pdfTable.SetWidths(this.ChangeColumnSize(8));

            RenderHeaders(pdfTable);
            AddSpaceBetweenTables(2, pdfTable);
            RenderPdfDocument(launchPlans, pdfTable, fontStyle);

            AddTableHeader(pdfTable);

            document.Add(pdfTable);

            document.Close();

            return memoryStream.ToArray();
        }

        #endregion

        #region Private Methods

        private void RenderHeaders(PdfPTable pdfTable)
        {
            AddHeader(pdfTable);
        }

        private void AddTableHeader(PdfPTable pdfTable)
        {
            pdfTable.HeaderRows = 2;
            this.AddSpaceBetweenTables(2, pdfTable);
        }

        private PdfPTable AddLogo()
        {
            int maxColumn = 1;
            PdfPTable pdfPTable = new PdfPTable(maxColumn);
            PdfPCell pdfCell = new PdfPCell();

            string path = "https://res.cloudinary.com/dpc0sub89/image/upload/v1607747243/SpaceX/Space-X_owyf13.png";

            string imgCombine = Path.Combine(path);
            Image img = Image.GetInstance(imgCombine);

            pdfCell = new PdfPCell(img);
            pdfCell.Colspan = maxColumn;
            pdfCell.HorizontalAlignment = Element.ALIGN_LEFT;
            pdfCell.Border = 0;
            pdfCell.ExtraParagraphSpace = 0;

            pdfPTable.AddCell(pdfCell);

            pdfPTable.CompleteRow();

            return pdfPTable;
        }

        private PdfPTable SetPageTitle()
        {
            int maxColumn = 8;
            PdfPTable pdfPTable = new PdfPTable(maxColumn);
            Font fontStyle = new Font();
            PdfPCell pdfCell = new PdfPCell();

            fontStyle = FontFactory.GetFont("Tahoma", 18f, 1);
            pdfCell = new PdfPCell(new Phrase("SpaceX Launch data", fontStyle));
            pdfCell.Colspan = maxColumn;
            pdfCell.HorizontalAlignment = Element.ALIGN_CENTER;
            pdfCell.Border = 0;
            pdfCell.ExtraParagraphSpace = 0;
            pdfPTable.AddCell(pdfCell);
            pdfPTable.CompleteRow();

            return pdfPTable;
        }

        private void AddSpaceBetweenTables(int numCount, PdfPTable pdfTable)
        {
            Font fontStyle = new Font();

            for (int i = 1; i < numCount; i++)
            {
                AddEmptyRow(pdfTable, string.Empty, fontStyle, 8);
            }
        }

        private void RenderPdfDocument(List<LaunchPlan> launchPlans, PdfPTable pdfTable, Font fontStyle)
        {
            this.RenderHeader(pdfTable, fontStyle);
            this.RenderBody(launchPlans, pdfTable, fontStyle);
        }

        private void RenderHeader(PdfPTable pdfTable, Font fontStyle)
        {
            var fontStyleBold = FontFactory.GetFont("Tahoma", 9f, 1);
            fontStyle = FontFactory.GetFont("Tahoma", 9f, 0);

            StyleTableHeader(pdfTable, "Flight Number", fontStyleBold);
            StyleTableHeader(pdfTable, "Mission Name", fontStyleBold);
            StyleTableHeader(pdfTable, "Mission Id", fontStyleBold);
            StyleTableHeader(pdfTable, "Launch UTC Time", fontStyleBold);
            StyleTableHeader(pdfTable, "Launch Success", fontStyleBold);
            StyleTableHeader(pdfTable, "Site Name", fontStyleBold);
            StyleTableHeader(pdfTable, "Rocket Name", fontStyleBold);
            StyleTableHeader(pdfTable, "Rocket Type", fontStyleBold);

            pdfTable.CompleteRow();
        }

        #endregion

        #region Private Methods

        private void SetAlignment(PdfPTable pdfTable)
        {
            pdfTable.WidthPercentage = 100;
            pdfTable.HorizontalAlignment = Element.ALIGN_LEFT;
            pdfTable.KeepTogether = true;
        }

        private void RenderBody(List<LaunchPlan> launchPlans, PdfPTable pdfTable, Font fontStyle)
        {
            foreach (var plan in launchPlans)
            {
                var missionId = string.Join(" ", plan.MissionId);

                StyleTableBody(pdfTable, plan.FlightNumber, fontStyle);
                StyleTableBody(pdfTable, plan.MissionName, fontStyle);
                StyleTableBody(pdfTable, missionId, fontStyle);
                StyleTableBody(pdfTable, plan.LaunchDateUtc.UtcDateTime.ToString(), fontStyle);
                StyleTableBody(pdfTable, plan.LaunchSuccess, fontStyle);
                StyleTableBody(pdfTable, plan.LaunchSite.SiteName, fontStyle);
                StyleTableBody(pdfTable, plan.Rocket.RocketName, fontStyle);
                StyleTableBody(pdfTable, plan.Rocket.RocketType, fontStyle);

                pdfTable.CompleteRow();
            }
        }

        private float[] ChangeColumnSize(int _maxColumn)
        {
            float[] sizes = new float[_maxColumn];

            for (var i = 0; i < _maxColumn; i++)
            {
                if (i == 0)
                {
                    sizes[i] = 25;
                }
                else
                {
                    sizes[i] = 40;
                }
            }

            return sizes;
        }

        private void AddHeader(PdfPTable pdfTable)
        {
            pdfTable.AddCell(new PdfPCell(this.AddLogo())
            {
                Colspan = 1,
                Border = 0
            });

            pdfTable.AddCell(new PdfPCell(this.SetPageTitle())
            {
                Colspan = 10,
                Border = 0
            });

            pdfTable.CompleteRow();
        }

        private void AddEmptyRow(PdfPTable pdfTable, string cellText, Font _fontStyle, int _maxColumn)
        {
            pdfTable.AddCell(new PdfPCell(new Phrase(cellText, _fontStyle))
            {
                Colspan = _maxColumn,
                Border = 0,
                ExtraParagraphSpace = 10,
            });

            pdfTable.CompleteRow();
        }

        private void StyleTableHeader(PdfPTable pdfTable, string cellText, Font fontStyleBold)
        {
            pdfTable.AddCell(new PdfPCell(new Phrase(cellText, fontStyleBold))
            {
                HorizontalAlignment = Element.ALIGN_CENTER,
                VerticalAlignment = Element.ALIGN_MIDDLE,
                BackgroundColor = BaseColor.Gray
            });
        }

        private void StyleTableBody(PdfPTable pdfTable, string cellText, Font _fontStyle)
        {
            pdfTable.AddCell(new PdfPCell(new Phrase(cellText, _fontStyle))
            {
                HorizontalAlignment = Element.ALIGN_CENTER,
                VerticalAlignment = Element.ALIGN_MIDDLE,
                BackgroundColor = BaseColor.White
            });
        }

        #endregion
    }
}