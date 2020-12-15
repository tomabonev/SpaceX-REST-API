using iTextSharp.text;
using iTextSharp.text.pdf;
using SpaceX.Services.DTO;
using System.Collections.Generic;
using System.IO;

namespace SpaceX.Services.IO
{
    /// <summary>
    /// This class expose functionality for exporting data into .pdf format
    /// </summary>
    public class PdfExportService : IExportService
    {
        #region Public Methods

        public byte[] Export(List<LaunchPlan> launchPlans)
        {
            Document document = new Document();
            PdfPTable pdfTable = new PdfPTable(8);

            using (MemoryStream stream = new MemoryStream())
            {

                document.SetPageSize(PageSize.A4);
                document.SetMargins(5f, 5f, 20f, 5f);

                SetAlignment(pdfTable);

                Font fontStyle = FontFactory.GetFont("Tahoma", 8f, 1);

                PdfWriter docWrite = PdfWriter.GetInstance(document, stream);

                try
                {
                    document.Open();

                    pdfTable.SetWidths(this.ChangeColumnSize(8));

                    RenderData(launchPlans, pdfTable, fontStyle);

                    document.Add(pdfTable);

                    document.Close();
                }
                finally
                {
                    document.Close();
                }

                return stream.ToArray();
            }
        }

        #endregion

        #region Private Methods

        private void RenderData(List<LaunchPlan> launchPlans, PdfPTable pdfTable, Font fontStyle)
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