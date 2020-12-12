using iTextSharp.text;
using iTextSharp.text.pdf;
using SpaceX.Models;
using SpaceX.Services.Contracts;
using System.Collections.Generic;
using System.IO;

namespace SpaceX.Services
{
    public class CreatePdfFileService : ICreatePdfFileService
    {
        #region Declaration

        int _maxColumn = 8;

        Document _document;
        Font _fontStyle;

        PdfPTable _pdfTable = new PdfPTable(8);
        PdfPTable _secondPdfTable = new PdfPTable(8);
        PdfPTable _thirdPdfTable = new PdfPTable(8);

        PdfPCell _pdfCell;
        MemoryStream _memoryStream = new MemoryStream();

        List<LaunchPlan> _launchPlans = new List<LaunchPlan>();

        #endregion

        public byte[] ReportToPdf(List<LaunchPlan> launchPlans)
        {
            _launchPlans = launchPlans;

            _document = new Document();
            _document.SetPageSize(PageSize.A4);
            _document.SetMargins(5f, 5f, 20f, 5f);

            _pdfTable.WidthPercentage = 100;
            _pdfTable.HorizontalAlignment = Element.ALIGN_LEFT;

            _secondPdfTable.WidthPercentage = 100;
            _secondPdfTable.HorizontalAlignment = Element.ALIGN_LEFT;

            _thirdPdfTable.WidthPercentage = 100;
            _thirdPdfTable.HorizontalAlignment = Element.ALIGN_LEFT;

            _fontStyle = FontFactory.GetFont("Tahoma", 8f, 1);
            PdfWriter docWrite = PdfWriter.GetInstance(_document, _memoryStream);

            _document.Open();

            _pdfTable.SetWidths(this.ChangeColumnSize(_maxColumn));
            _secondPdfTable.SetWidths(this.ChangeColumnSize(_maxColumn));
            _thirdPdfTable.SetWidths(this.ChangeColumnSize(_maxColumn));

            this.ReportHeader();
            this.EmptyRow(2);
            this.ReportBody();

            _pdfTable.HeaderRows = 2;
            this.EmptyRow(2);

            _secondPdfTable.HeaderRows = 2;
            this.EmptyRow(2);

            _thirdPdfTable.HeaderRows = 2;
            this.EmptyRow(2);

            _document.Add(_pdfTable);
            _document.Add(_secondPdfTable);
            _document.Add(_thirdPdfTable);

            _document.Close();

            return _memoryStream.ToArray();
        }

        #region Report Extension Methods

        #region Report Header

        private void ReportHeader()
        {
            AddHeader(_pdfTable);
            AddHeader(_secondPdfTable);
            AddHeader(_thirdPdfTable);
        }

        #endregion

        #region Add Logo

        private PdfPTable AddLogo()
        {
            int maxColumn = 1;
            PdfPTable pdfPTable = new PdfPTable(maxColumn);

            string path = "https://res.cloudinary.com/dpc0sub89/image/upload/v1607747243/SpaceX/Space-X_owyf13.png";

            string imgCombine = Path.Combine(path);
            Image img = Image.GetInstance(imgCombine);

            _pdfCell = new PdfPCell(img);
            _pdfCell.Colspan = maxColumn;
            _pdfCell.HorizontalAlignment = Element.ALIGN_LEFT;
            _pdfCell.Border = 0;
            _pdfCell.ExtraParagraphSpace = 0;

            pdfPTable.AddCell(_pdfCell);

            pdfPTable.CompleteRow();

            return pdfPTable;
        }

        #endregion

        #region Set Page Title

        private PdfPTable SetPageTitle()
        {
            int maxColumn = 6;
            PdfPTable pdfPTable = new PdfPTable(maxColumn);

            _fontStyle = FontFactory.GetFont("Tahoma", 18f, 1);
            _pdfCell = new PdfPCell(new Phrase("SpaceX Launch data", _fontStyle));
            _pdfCell.Colspan = maxColumn;
            _pdfCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfCell.Border = 0;
            _pdfCell.ExtraParagraphSpace = 0;
            pdfPTable.AddCell(_pdfCell);
            pdfPTable.CompleteRow();

            _fontStyle = FontFactory.GetFont("Tahoma", 14f, 1);
            _pdfCell = new PdfPCell(new Phrase("Specifications", _fontStyle));
            _pdfCell.Colspan = maxColumn;
            _pdfCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfCell.Border = 0;
            _pdfCell.ExtraParagraphSpace = 0;
            pdfPTable.AddCell(_pdfCell);
            pdfPTable.CompleteRow();

            return pdfPTable;
        }

        #endregion

        #region Empty Row

        private void EmptyRow(int nCount)
        {
            for (int i = 1; i < nCount; i++)
            {
                AddEmptyRow(_pdfTable, "", _fontStyle, _maxColumn);
                AddEmptyRow(_secondPdfTable, "", _fontStyle, _maxColumn);
                AddEmptyRow(_thirdPdfTable, "", _fontStyle, _maxColumn);
            }
        }

        #endregion

        #region Report Body

        private void ReportBody()
        {
            var fontStyleBold = FontFactory.GetFont("Tahoma", 9f, 1);
            _fontStyle = FontFactory.GetFont("Tahoma", 9f, 0);

            #region Detail Table Header

            AddCellHeader(_pdfTable, "Flight Number", fontStyleBold);
            AddCellHeader(_pdfTable, "Mission Name", fontStyleBold);
            AddCellHeader(_pdfTable, "Mission Id", fontStyleBold);
            AddCellHeader(_pdfTable, "Upcoming", fontStyleBold);
            AddCellHeader(_pdfTable, "Launch Year", fontStyleBold);
            AddCellHeader(_pdfTable, "Launch Date", fontStyleBold);
            AddCellHeader(_pdfTable, "Launch UTC Time", fontStyleBold);
            AddCellHeader(_pdfTable, "Local Time", fontStyleBold);

            AddCellHeader(_secondPdfTable, "Flight Number", fontStyleBold);
            AddCellHeader(_secondPdfTable, "Mission Name", fontStyleBold);
            AddCellHeader(_secondPdfTable, "Is Tentative", fontStyleBold);
            AddCellHeader(_secondPdfTable, "Max Precision", fontStyleBold);
            AddCellHeader(_secondPdfTable, "TBD", fontStyleBold);
            AddCellHeader(_secondPdfTable, "Launch Window", fontStyleBold);
            AddCellHeader(_secondPdfTable, "Ships", fontStyleBold);
            AddCellHeader(_secondPdfTable, "Launch Success", fontStyleBold);

            AddCellHeader(_thirdPdfTable, "Flight Number", fontStyleBold);
            AddCellHeader(_thirdPdfTable, "Mission Name", fontStyleBold);
            AddCellHeader(_thirdPdfTable, "Failure Time", fontStyleBold);
            AddCellHeader(_thirdPdfTable, "Failure Altitude", fontStyleBold);
            AddCellHeader(_thirdPdfTable, "Failure Reason", fontStyleBold);
            AddCellHeader(_thirdPdfTable, "Fire Date UTC", fontStyleBold);
            AddCellHeader(_thirdPdfTable, "Fire Date Unix", fontStyleBold);
            AddCellHeader(_thirdPdfTable, "Webcast LiftOff", fontStyleBold);

            _pdfTable.CompleteRow();
            _secondPdfTable.CompleteRow();
            _thirdPdfTable.CompleteRow();

            #endregion

            #region Detail Table Body

            foreach (var plan in _launchPlans)
            {
                var missionId = string.Join(" ", plan.MissionId);
                var ship = string.Join(" ", plan.Ships);
                var altitude = string.Join(" ", plan.LaunchFailureDetails.Altitude);

                AddCellToBody(_pdfTable, plan.FlightNumber, _fontStyle);
                AddCellToBody(_pdfTable, plan.MissionName, _fontStyle);
                AddCellToBody(_pdfTable, missionId, _fontStyle);
                AddCellToBody(_pdfTable, plan.Upcoming, _fontStyle);
                AddCellToBody(_pdfTable, plan.LaunchYear, _fontStyle);
                AddCellToBody(_pdfTable, plan.LaunchDateUnix, _fontStyle);
                AddCellToBody(_pdfTable, plan.LaunchDateUtc.UtcDateTime.ToString(), _fontStyle);
                AddCellToBody(_pdfTable, plan.LaunchDateLocal.LocalDateTime.ToString(), _fontStyle);

                AddCellToBody(_secondPdfTable, plan.FlightNumber, _fontStyle);
                AddCellToBody(_secondPdfTable, plan.MissionName, _fontStyle);
                AddCellToBody(_secondPdfTable, plan.IsTentative, _fontStyle);
                AddCellToBody(_secondPdfTable, plan.TentativeMaxPrecision, _fontStyle);
                AddCellToBody(_secondPdfTable, plan.Tbd, _fontStyle);
                AddCellToBody(_secondPdfTable, plan.LaunchWindow, _fontStyle);
                AddCellToBody(_secondPdfTable, ship, _fontStyle);
                AddCellToBody(_secondPdfTable, plan.LaunchSuccess, _fontStyle);

                AddCellToBody(_thirdPdfTable, plan.FlightNumber, _fontStyle);
                AddCellToBody(_thirdPdfTable, plan.MissionName, _fontStyle);
                AddCellToBody(_thirdPdfTable, plan.LaunchFailureDetails.Time, _fontStyle);
                AddCellToBody(_thirdPdfTable, altitude, _fontStyle);
                AddCellToBody(_thirdPdfTable, plan.LaunchFailureDetails.Reason, _fontStyle);
                AddCellToBody(_thirdPdfTable, plan.StaticFireDateUtc.ToString(), _fontStyle);
                AddCellToBody(_thirdPdfTable, plan.StaticFireDateUnix, _fontStyle);
                AddCellToBody(_thirdPdfTable, plan.Timeline?.WebcastLiftoff ?? null, _fontStyle);

                _pdfTable.CompleteRow();
                _secondPdfTable.CompleteRow();
                _thirdPdfTable.CompleteRow();
            }

            #endregion
        }

        #endregion

        #region Change Column Size

        private float[] ChangeColumnSize(int _maxColumn)
        {
            float[] sizes = new float[_maxColumn];

            for (var i = 0; i < _maxColumn; i++)
            {
                if (i == 0) sizes[i] = 50;
                else sizes[i] = 50;
            }

            return sizes;
        }

        #endregion

        #region Add Header

        private void AddHeader(PdfPTable _pdfTable)
        {
            _pdfTable.AddCell(new PdfPCell(this.AddLogo())
            {
                Colspan = 1,
                Border = 0
            });

            _pdfTable.AddCell(new PdfPCell(this.SetPageTitle())
            {
                Colspan = _maxColumn - 1,
                Border = 0
            });

            _pdfTable.CompleteRow();
        }

        #endregion

        #region Add Empty Row

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

        #endregion

        #region Add Cell Header

        private void AddCellHeader(PdfPTable _pdfTable, string cellText, Font fontStyleBold)
        {
            _pdfTable.AddCell(new PdfPCell(new Phrase(cellText, fontStyleBold))
            {
                HorizontalAlignment = Element.ALIGN_CENTER,
                VerticalAlignment = Element.ALIGN_MIDDLE,
                BackgroundColor = BaseColor.Gray
            });
        }

        #endregion

        #region Add Cell To Body

        private void AddCellToBody(PdfPTable _pdfTable, string cellText, Font _fontStyle)
        {
            _pdfTable.AddCell(new PdfPCell(new Phrase(cellText, _fontStyle))
            {
                HorizontalAlignment = Element.ALIGN_CENTER,
                VerticalAlignment = Element.ALIGN_MIDDLE,
                BackgroundColor = BaseColor.White
            });
        }

        #endregion

        #endregion
    }
}