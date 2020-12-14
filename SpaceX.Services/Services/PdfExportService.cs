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
        #region Declarations

        private Font fontStyle;

        private PdfPTable pdfTable = new PdfPTable(8);

        private PdfPCell pdfCell;

        #endregion

        #region Public Methods

        public byte[] Export(List<LaunchPlan> launchPlans)
        {
         
            MemoryStream memoryStream = new MemoryStream();

            Document document = new Document();

            document.SetPageSize(PageSize.A4);
            document.SetMargins(5f, 5f, 20f, 5f);

            SetAlignment(pdfTable);

            fontStyle = FontFactory.GetFont("Tahoma", 8f, 1);
            PdfWriter docWrite = PdfWriter.GetInstance(document, memoryStream);

            document.Open();

            pdfTable.SetWidths(this.ChangeColumnSize(8));

            RenderHeaders();
            AddSpaceBetweenTables(2);
            RenderPdfDocument(launchPlans);

            AddTableHeader(pdfTable);

            document.Add(pdfTable);

            document.Close();

            return memoryStream.ToArray();
        }

        #endregion

        #region Private Methods

        private void RenderHeaders()
        {
            AddHeader(pdfTable);
        }

        private void AddTableHeader(PdfPTable _pdfTable)
        {
            _pdfTable.HeaderRows = 2;
            this.AddSpaceBetweenTables(2);
        }

        private PdfPTable AddLogo()
        {
            int maxColumn = 1;
            PdfPTable pdfPTable = new PdfPTable(maxColumn);

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
            int maxColumn = 6;
            PdfPTable pdfPTable = new PdfPTable(maxColumn);

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

        private void AddSpaceBetweenTables(int numCount)
        {
            for (int i = 1; i < numCount; i++)
            {
                AddEmptyRow(pdfTable, string.Empty, fontStyle, 8);
            }
        }

        private void RenderPdfDocument(List<LaunchPlan> launchPlans)
        {
            this.RenderHeader();
            this.RenderBody(launchPlans);
        }

        private void RenderHeader()
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

        private void SetAlignment(PdfPTable _pdfTable)
        {
            _pdfTable.WidthPercentage = 100;
            _pdfTable.HorizontalAlignment = Element.ALIGN_LEFT;
            _pdfTable.KeepTogether = true;
        }

        private void RenderBody(List<LaunchPlan> launchPlans)
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

        private void AddHeader(PdfPTable _pdfTable)
        {
            _pdfTable.AddCell(new PdfPCell(this.AddLogo())
            {
                Colspan = 1,
                Border = 0
            });

            _pdfTable.AddCell(new PdfPCell(this.SetPageTitle())
            {
                Colspan = 10,
                Border = 0
            });

            _pdfTable.CompleteRow();
        }

        private void AddEmptyRow(PdfPTable _pdfTable, string cellText, Font _fontStyle, int _maxColumn)
        {
            _pdfTable.AddCell(new PdfPCell(new Phrase(cellText, _fontStyle))
            {
                Colspan = _maxColumn,
                Border = 0,
                ExtraParagraphSpace = 10,
            });

            _pdfTable.CompleteRow();
        }

        private void StyleTableHeader(PdfPTable _pdfTable, string cellText, Font fontStyleBold)
        {
            _pdfTable.AddCell(new PdfPCell(new Phrase(cellText, fontStyleBold))
            {
                HorizontalAlignment = Element.ALIGN_CENTER,
                VerticalAlignment = Element.ALIGN_MIDDLE,
                BackgroundColor = BaseColor.Gray
            });
        }

        private void StyleTableBody(PdfPTable _pdfTable, string cellText, Font _fontStyle)
        {
            _pdfTable.AddCell(new PdfPCell(new Phrase(cellText, _fontStyle))
            {
                HorizontalAlignment = Element.ALIGN_CENTER,
                VerticalAlignment = Element.ALIGN_MIDDLE,
                BackgroundColor = BaseColor.White
            });
        }

        #endregion
    }
}