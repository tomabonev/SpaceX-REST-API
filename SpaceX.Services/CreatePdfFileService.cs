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
        PdfPTable _fourthPdfTable = new PdfPTable(6);
        PdfPTable _fifthPdfTable = new PdfPTable(8);
        PdfPTable _firstStagePdfTable = new PdfPTable(11);
        PdfPTable _secondStagePartOnePdfTable = new PdfPTable(8);
        PdfPTable _secondStagePartTwoPdfTable = new PdfPTable(8);
        PdfPTable _secondStagePartThreePdfTable = new PdfPTable(9);
        PdfPTable _secondStagePartFourPdfTable = new PdfPTable(9);
        PdfPTable _linksListPartOnePdfTable = new PdfPTable(5);
        PdfPTable _linksListPartTwoPdfTable = new PdfPTable(5);
        PdfPTable _linksListPartThreePdfTable = new PdfPTable(4);
        PdfPTable _detailsPdfTable = new PdfPTable(3);
        PdfPTable _flickerPdfTable = new PdfPTable(3);

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

            SetAlignment(_pdfTable);
            SetAlignment(_secondPdfTable);
            SetAlignment(_thirdPdfTable);
            SetAlignment(_fourthPdfTable);
            SetAlignment(_fifthPdfTable);
            SetAlignment(_firstStagePdfTable);
            SetAlignment(_secondStagePartOnePdfTable);
            SetAlignment(_secondStagePartTwoPdfTable);
            SetAlignment(_secondStagePartThreePdfTable);
            SetAlignment(_secondStagePartFourPdfTable);
            SetAlignment(_linksListPartOnePdfTable);
            SetAlignment(_linksListPartTwoPdfTable);
            SetAlignment(_linksListPartThreePdfTable);
            SetAlignment(_detailsPdfTable);
            SetAlignment(_flickerPdfTable);

            _fontStyle = FontFactory.GetFont("Tahoma", 8f, 1);
            PdfWriter docWrite = PdfWriter.GetInstance(_document, _memoryStream);

            _document.Open();

            _pdfTable.SetWidths(this.ChangeColumnSize(_maxColumn));
            _secondPdfTable.SetWidths(this.ChangeColumnSize(_maxColumn));
            _thirdPdfTable.SetWidths(this.ChangeColumnSize(_maxColumn));
            _fourthPdfTable.SetWidths(this.ChangeColumnSize(6));
            _fifthPdfTable.SetWidths(this.ChangeColumnSize(8));
            _firstStagePdfTable.SetWidths(this.ChangeColumnSize(11));
            _secondStagePartOnePdfTable.SetWidths(this.ChangeColumnSize(8));
            _secondStagePartTwoPdfTable.SetWidths(this.ChangeColumnSize(8));
            _secondStagePartThreePdfTable.SetWidths(this.ChangeColumnSize(9));
            _secondStagePartFourPdfTable.SetWidths(this.ChangeColumnSize(9));
            _linksListPartOnePdfTable.SetWidths(this.ChangeColumnSize(5));
            _linksListPartTwoPdfTable.SetWidths(this.ChangeColumnSize(5));
            _linksListPartThreePdfTable.SetWidths(this.ChangeColumnSize(4));
            _detailsPdfTable.SetWidths(this.ChangeColumnSize(3));
            _flickerPdfTable.SetWidths(this.ChangeColumnSize(3));

            this.ReportHeader();
            this.SetEmptyRow(2);
            this.ReportBody();

            AddTableHeader(_pdfTable);
            AddTableHeader(_secondPdfTable);
            AddTableHeader(_thirdPdfTable);
            AddTableHeader(_fourthPdfTable);
            AddTableHeader(_fifthPdfTable);
            AddTableHeader(_firstStagePdfTable);
            AddTableHeader(_secondStagePartOnePdfTable);
            AddTableHeader(_secondStagePartTwoPdfTable);
            AddTableHeader(_secondStagePartThreePdfTable);
            AddTableHeader(_secondStagePartFourPdfTable);
            AddTableHeader(_linksListPartOnePdfTable);
            AddTableHeader(_linksListPartTwoPdfTable);
            AddTableHeader(_linksListPartThreePdfTable);
            AddTableHeader(_detailsPdfTable);
            AddTableHeader(_flickerPdfTable);

            _document.Add(_pdfTable);
            _document.Add(_secondPdfTable);
            _document.Add(_thirdPdfTable);
            _document.Add(_fourthPdfTable);
            _document.Add(_fifthPdfTable);
            _document.Add(_firstStagePdfTable);
            _document.Add(_secondStagePartOnePdfTable);
            _document.Add(_secondStagePartTwoPdfTable);
            _document.Add(_secondStagePartThreePdfTable);
            _document.Add(_secondStagePartFourPdfTable);
            _document.Add(_linksListPartOnePdfTable);
            _document.Add(_linksListPartTwoPdfTable);
            _document.Add(_linksListPartThreePdfTable);
            _document.Add(_detailsPdfTable);
            _document.Add(_flickerPdfTable);

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
            AddHeader(_fourthPdfTable);
            AddHeader(_fifthPdfTable);
            AddHeader(_firstStagePdfTable);
            AddHeader(_secondStagePartOnePdfTable);
            AddHeader(_secondStagePartTwoPdfTable);
            AddHeader(_secondStagePartThreePdfTable);
            AddHeader(_secondStagePartFourPdfTable);
            AddHeader(_linksListPartOnePdfTable);
            AddHeader(_linksListPartTwoPdfTable);
            AddHeader(_linksListPartThreePdfTable);
            AddHeader(_detailsPdfTable);
            AddHeader(_flickerPdfTable);
        }

        #endregion

        #region Add Table Header

        private void AddTableHeader(PdfPTable _pdfTable)
        {
            _pdfTable.HeaderRows = 2;
            this.SetEmptyRow(2);
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

        #region Set Table Alignment

        private void SetAlignment(PdfPTable _pdfTable)
        {
            _pdfTable.WidthPercentage = 100;
            _pdfTable.HorizontalAlignment = Element.ALIGN_LEFT;
        }

        #endregion

        #region Set Empty Row

        private void SetEmptyRow(int nCount)
        {
            for (int i = 1; i < nCount; i++)
            {
                AddEmptyRow(_pdfTable, "", _fontStyle, _maxColumn);
                AddEmptyRow(_secondPdfTable, "", _fontStyle, _maxColumn);
                AddEmptyRow(_thirdPdfTable, "", _fontStyle, _maxColumn);
                AddEmptyRow(_fourthPdfTable, "", _fontStyle, 6);
                AddEmptyRow(_fifthPdfTable, "", _fontStyle, 8);
                AddEmptyRow(_firstStagePdfTable, "", _fontStyle, 11);
                AddEmptyRow(_secondStagePartOnePdfTable, "", _fontStyle, 8);
                AddEmptyRow(_secondStagePartTwoPdfTable, "", _fontStyle, 8);
                AddEmptyRow(_secondStagePartThreePdfTable, "", _fontStyle, 9);
                AddEmptyRow(_secondStagePartFourPdfTable, "", _fontStyle, 9);
                AddEmptyRow(_linksListPartOnePdfTable, "", _fontStyle, 5);
                AddEmptyRow(_linksListPartTwoPdfTable, "", _fontStyle, 5);
                AddEmptyRow(_linksListPartThreePdfTable, "", _fontStyle, 4);
                AddEmptyRow(_detailsPdfTable, "", _fontStyle, 3);
                AddEmptyRow(_flickerPdfTable, "", _fontStyle, 3);
            }
        }

        #endregion

        #region Report Body

        private void ReportBody()
        {
            this.RenderHeader();
            this.RenderData();
        }

        #region Render Header
        private void RenderHeader()
        {
            var fontStyleBold = FontFactory.GetFont("Tahoma", 9f, 1);
            _fontStyle = FontFactory.GetFont("Tahoma", 9f, 0);

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

            AddCellHeader(_fourthPdfTable, "Flight Number", fontStyleBold);
            AddCellHeader(_fourthPdfTable, "Mission Name", fontStyleBold);
            AddCellHeader(_fourthPdfTable, "Flight Club", fontStyleBold);
            AddCellHeader(_fourthPdfTable, "Site Id", fontStyleBold);
            AddCellHeader(_fourthPdfTable, "Site Name", fontStyleBold);
            AddCellHeader(_fourthPdfTable, "Site Full Name", fontStyleBold);

            AddCellHeader(_fifthPdfTable, "Flight Number", fontStyleBold);
            AddCellHeader(_fifthPdfTable, "Rocket Id", fontStyleBold);
            AddCellHeader(_fifthPdfTable, "Rocket Name", fontStyleBold);
            AddCellHeader(_fifthPdfTable, "Rocket Type", fontStyleBold);
            AddCellHeader(_fifthPdfTable, "Reused", fontStyleBold);
            AddCellHeader(_fifthPdfTable, "Recovery Attempt", fontStyleBold);
            AddCellHeader(_fifthPdfTable, "Recovered", fontStyleBold);
            AddCellHeader(_fifthPdfTable, "Ship", fontStyleBold);

            AddCellHeader(_firstStagePdfTable, "Flight Number", fontStyleBold);
            AddCellHeader(_firstStagePdfTable, "Core Serial", fontStyleBold);
            AddCellHeader(_firstStagePdfTable, "Flight", fontStyleBold);
            AddCellHeader(_firstStagePdfTable, "Block", fontStyleBold);
            AddCellHeader(_firstStagePdfTable, "GridFins", fontStyleBold);
            AddCellHeader(_firstStagePdfTable, "Legs", fontStyleBold);
            AddCellHeader(_firstStagePdfTable, "Reused", fontStyleBold);
            AddCellHeader(_firstStagePdfTable, "Land", fontStyleBold);
            AddCellHeader(_firstStagePdfTable, "Landing intent", fontStyleBold);
            AddCellHeader(_firstStagePdfTable, "Landing type", fontStyleBold);
            AddCellHeader(_firstStagePdfTable, "Landing vehicle", fontStyleBold);

            AddCellHeader(_secondStagePartOnePdfTable, "Flight Number", fontStyleBold);
            AddCellHeader(_secondStagePartOnePdfTable, "Rocket Name", fontStyleBold);
            AddCellHeader(_secondStagePartOnePdfTable, "Payload Id", fontStyleBold);
            AddCellHeader(_secondStagePartOnePdfTable, "Norad Id", fontStyleBold);
            AddCellHeader(_secondStagePartOnePdfTable, "Reused", fontStyleBold);
            AddCellHeader(_secondStagePartOnePdfTable, "Customers", fontStyleBold);
            AddCellHeader(_secondStagePartOnePdfTable, "Nationality", fontStyleBold);
            AddCellHeader(_secondStagePartOnePdfTable, "Manufacturer", fontStyleBold);

            AddCellHeader(_secondStagePartTwoPdfTable, "Flight Number", fontStyleBold);
            AddCellHeader(_secondStagePartTwoPdfTable, "Rocket Name", fontStyleBold);
            AddCellHeader(_secondStagePartTwoPdfTable, "Payload Type", fontStyleBold);
            AddCellHeader(_secondStagePartTwoPdfTable, "Mass kg", fontStyleBold);
            AddCellHeader(_secondStagePartTwoPdfTable, "Mass lbs", fontStyleBold);
            AddCellHeader(_secondStagePartTwoPdfTable, "Orbit", fontStyleBold);
            AddCellHeader(_secondStagePartTwoPdfTable, "Reference System", fontStyleBold);
            AddCellHeader(_secondStagePartTwoPdfTable, "Regime", fontStyleBold);

            AddCellHeader(_secondStagePartThreePdfTable, "Flight Number", fontStyleBold);
            AddCellHeader(_secondStagePartThreePdfTable, "Rocket Name", fontStyleBold);
            AddCellHeader(_secondStagePartThreePdfTable, "Longtitude", fontStyleBold);
            AddCellHeader(_secondStagePartThreePdfTable, "Axis km", fontStyleBold);
            AddCellHeader(_secondStagePartThreePdfTable, "Eccentricity", fontStyleBold);
            AddCellHeader(_secondStagePartThreePdfTable, "Periapsis Km", fontStyleBold);
            AddCellHeader(_secondStagePartThreePdfTable, "Apoapsis Km", fontStyleBold);
            AddCellHeader(_secondStagePartThreePdfTable, "InclinationDeg", fontStyleBold);
            AddCellHeader(_secondStagePartThreePdfTable, "PeriodMin", fontStyleBold);

            AddCellHeader(_secondStagePartFourPdfTable, "Flight Number", fontStyleBold);
            AddCellHeader(_secondStagePartFourPdfTable, "Rocket Name", fontStyleBold);
            AddCellHeader(_secondStagePartFourPdfTable, "Lifespan Years", fontStyleBold);
            AddCellHeader(_secondStagePartFourPdfTable, "Epoch", fontStyleBold);
            AddCellHeader(_secondStagePartFourPdfTable, "Mean Motion", fontStyleBold);
            AddCellHeader(_secondStagePartFourPdfTable, "Raan", fontStyleBold);
            AddCellHeader(_secondStagePartFourPdfTable, "Arg Of Pericenter", fontStyleBold);
            AddCellHeader(_secondStagePartFourPdfTable, "Mean Anomaly", fontStyleBold);
            AddCellHeader(_secondStagePartFourPdfTable, "Block", fontStyleBold);

            AddCellHeader(_linksListPartOnePdfTable, "Flight Number", fontStyleBold);
            AddCellHeader(_linksListPartOnePdfTable, "Mission Patch", fontStyleBold);
            AddCellHeader(_linksListPartOnePdfTable, "Mission Small Patch", fontStyleBold);
            AddCellHeader(_linksListPartOnePdfTable, "Reddit Campaign", fontStyleBold);
            AddCellHeader(_linksListPartOnePdfTable, "Reddit Launch", fontStyleBold);

            AddCellHeader(_linksListPartTwoPdfTable, "Flight Number", fontStyleBold);
            AddCellHeader(_linksListPartTwoPdfTable, "Reddit Recovery", fontStyleBold);
            AddCellHeader(_linksListPartTwoPdfTable, "Reddit Media", fontStyleBold);
            AddCellHeader(_linksListPartTwoPdfTable, "Presskit", fontStyleBold);
            AddCellHeader(_linksListPartTwoPdfTable, "Article link", fontStyleBold);

            AddCellHeader(_linksListPartThreePdfTable, "Flight Number", fontStyleBold);
            AddCellHeader(_linksListPartThreePdfTable, "Wikipedia", fontStyleBold);
            AddCellHeader(_linksListPartThreePdfTable, "Video link", fontStyleBold);
            AddCellHeader(_linksListPartThreePdfTable, "Youtube Id", fontStyleBold);

            AddCellHeader(_detailsPdfTable, "Flight Number", fontStyleBold);
            AddCellHeader(_detailsPdfTable, "Mission Name", fontStyleBold);
            AddCellHeader(_detailsPdfTable, "Details", fontStyleBold);

            AddCellHeader(_flickerPdfTable, "Flight Number", fontStyleBold);
            AddCellHeader(_flickerPdfTable, "Mission Name", fontStyleBold);
            AddCellHeader(_flickerPdfTable, "Flickr image", fontStyleBold);

            _pdfTable.CompleteRow();
            _secondPdfTable.CompleteRow();
            _thirdPdfTable.CompleteRow();
            _fourthPdfTable.CompleteRow();
            _fifthPdfTable.CompleteRow();
            _firstStagePdfTable.CompleteRow();
            _secondStagePartOnePdfTable.CompleteRow();
            _secondStagePartTwoPdfTable.CompleteRow();
            _secondStagePartThreePdfTable.CompleteRow();
            _secondStagePartFourPdfTable.CompleteRow();
            _linksListPartOnePdfTable.CompleteRow();
            _linksListPartTwoPdfTable.CompleteRow();
            _linksListPartThreePdfTable.CompleteRow();
            _detailsPdfTable.CompleteRow();
            _flickerPdfTable.CompleteRow();
        }

        #endregion

        #region Render Data

        private void RenderData()
        {
            foreach (var plan in _launchPlans)
            {
                var missionId = string.Join(" ", plan.MissionId);
                var ships = string.Join(" ", plan.Ships);
                var altitude = string.Join(" ", plan.LaunchFailureDetails.Altitude);
                var flightClub = string.Join(" ", plan.Telemetry.FlightClub);
                var reused = string.Join(" ", plan.Rocket.Fairings?.Reused ?? null);
                var recoveryAttempt = string.Join(" ", plan.Rocket.Fairings?.RecoveryAttempt ?? null);
                var recovered = string.Join(" ", plan.Rocket.Fairings?.Recovered ?? null);
                var ship = string.Join(" ", plan.Rocket.Fairings?.Ship ?? null);
                var redditCampaing = string.Join(" ", plan.Links.RedditCampaign);
                var redditLaunch = string.Join(" ", plan.Links.RedditLaunch);
                var redditRecovery = string.Join(" ", plan.Links.RedditRecovery);
                var redditMedia = string.Join(" ", plan.Links.RedditMedia);
                var presskit = string.Join(" ", plan.Links.Presskit);
                var flickrImage = string.Join(" ", plan.Links.FlickrImages);

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
                AddCellToBody(_secondPdfTable, ships, _fontStyle);
                AddCellToBody(_secondPdfTable, plan.LaunchSuccess, _fontStyle);

                AddCellToBody(_thirdPdfTable, plan.FlightNumber, _fontStyle);
                AddCellToBody(_thirdPdfTable, plan.MissionName, _fontStyle);
                AddCellToBody(_thirdPdfTable, plan.LaunchFailureDetails.Time, _fontStyle);
                AddCellToBody(_thirdPdfTable, altitude, _fontStyle);
                AddCellToBody(_thirdPdfTable, plan.LaunchFailureDetails.Reason, _fontStyle);
                AddCellToBody(_thirdPdfTable, plan.StaticFireDateUtc.ToString(), _fontStyle);
                AddCellToBody(_thirdPdfTable, plan.StaticFireDateUnix, _fontStyle);
                AddCellToBody(_thirdPdfTable, plan.Timeline?.WebcastLiftoff ?? null, _fontStyle);

                AddCellToBody(_fourthPdfTable, plan.FlightNumber, _fontStyle);
                AddCellToBody(_fourthPdfTable, plan.MissionName, _fontStyle);
                AddCellToBody(_fourthPdfTable, flightClub, _fontStyle);
                AddCellToBody(_fourthPdfTable, plan.LaunchSite.SiteId, _fontStyle);
                AddCellToBody(_fourthPdfTable, plan.LaunchSite.SiteName, _fontStyle);
                AddCellToBody(_fourthPdfTable, plan.LaunchSite.SiteNameLong, _fontStyle);

                AddCellToBody(_fifthPdfTable, plan.FlightNumber, _fontStyle);
                AddCellToBody(_fifthPdfTable, plan.Rocket.RocketId, _fontStyle);
                AddCellToBody(_fifthPdfTable, plan.Rocket.RocketName, _fontStyle);
                AddCellToBody(_fifthPdfTable, plan.Rocket.RocketType, _fontStyle);
                AddCellToBody(_fifthPdfTable, reused, _fontStyle);
                AddCellToBody(_fifthPdfTable, recoveryAttempt, _fontStyle);
                AddCellToBody(_fifthPdfTable, recovered, _fontStyle);
                AddCellToBody(_fifthPdfTable, ship, _fontStyle);

                AddCellToBody(_linksListPartOnePdfTable, plan.FlightNumber, _fontStyle);
                AddCellToBody(_linksListPartOnePdfTable, plan.Links.MissionPatch, _fontStyle);
                AddCellToBody(_linksListPartOnePdfTable, plan.Links.MissionPatchSmall, _fontStyle);
                AddCellToBody(_linksListPartOnePdfTable, redditCampaing, _fontStyle);
                AddCellToBody(_linksListPartOnePdfTable, redditLaunch, _fontStyle);

                AddCellToBody(_linksListPartTwoPdfTable, plan.FlightNumber, _fontStyle);
                AddCellToBody(_linksListPartTwoPdfTable, redditRecovery, _fontStyle);
                AddCellToBody(_linksListPartTwoPdfTable, redditMedia, _fontStyle);
                AddCellToBody(_linksListPartTwoPdfTable, presskit, _fontStyle);
                AddCellToBody(_linksListPartTwoPdfTable, plan.Links.ArticleLink, _fontStyle);

                AddCellToBody(_linksListPartThreePdfTable, plan.FlightNumber, _fontStyle);
                AddCellToBody(_linksListPartThreePdfTable, plan.Links.Wikipedia, _fontStyle);
                AddCellToBody(_linksListPartThreePdfTable, plan.Links.VideoLink, _fontStyle);
                AddCellToBody(_linksListPartThreePdfTable, plan.Links.YoutubeId, _fontStyle);

                AddCellToBody(_detailsPdfTable, plan.FlightNumber, _fontStyle);
                AddCellToBody(_detailsPdfTable, plan.MissionName, _fontStyle);
                AddCellToBody(_detailsPdfTable, plan.Details, _fontStyle);

                AddCellToBody(_flickerPdfTable, plan.FlightNumber, _fontStyle);
                AddCellToBody(_flickerPdfTable, plan.MissionName, _fontStyle);
                AddCellToBody(_flickerPdfTable, flickrImage, _fontStyle);

                foreach (var firstStage in plan.Rocket.FirstStage.Cores)
                {
                    var block = string.Join(" ", firstStage.Block);
                    var landSuccess = string.Join(" ", firstStage.LandSuccess);
                    var landingType = string.Join(" ", firstStage.LandingType);
                    var landingVehicle = string.Join(" ", firstStage.LandingVehicle);

                    AddCellToBody(_firstStagePdfTable, plan.FlightNumber, _fontStyle);
                    AddCellToBody(_firstStagePdfTable, firstStage.CoreSerial, _fontStyle);
                    AddCellToBody(_firstStagePdfTable, firstStage.Flight, _fontStyle);
                    AddCellToBody(_firstStagePdfTable, block, _fontStyle);
                    AddCellToBody(_firstStagePdfTable, firstStage.Gridfins, _fontStyle);
                    AddCellToBody(_firstStagePdfTable, firstStage.Legs, _fontStyle);
                    AddCellToBody(_firstStagePdfTable, firstStage.Reused, _fontStyle);
                    AddCellToBody(_firstStagePdfTable, landSuccess, _fontStyle);
                    AddCellToBody(_firstStagePdfTable, firstStage.LandingIntent, _fontStyle);
                    AddCellToBody(_firstStagePdfTable, landingType, _fontStyle);
                    AddCellToBody(_firstStagePdfTable, landingVehicle, _fontStyle);
                }

                foreach (var secondStage in plan.Rocket.SecondStage.Payloads)
                {
                    var noradId = string.Join(" ", secondStage.NoradId);
                    var customers = string.Join(" ", secondStage.Customers);
                    var longitude = string.Join(" ", secondStage.OrbitParams.Longitude);
                    var axisKm = string.Join(" ", secondStage.OrbitParams.SemiMajorAxisKm);
                    var eccentricity = string.Join(" ", secondStage.OrbitParams.Eccentricity);
                    var periodMin = string.Join(" ", secondStage.OrbitParams.PeriodMin);
                    var lifespanYears = string.Join(" ", secondStage.OrbitParams.LifespanYears);
                    var epoch = string.Join(" ", secondStage.OrbitParams.Epoch);
                    var meanMotion = string.Join(" ", secondStage.OrbitParams.MeanMotion);
                    var raan = string.Join(" ", secondStage.OrbitParams.Raan);
                    var argOfPericenter = string.Join(" ", secondStage.OrbitParams.ArgOfPericenter);
                    var meanAnomaly = string.Join(" ", secondStage.OrbitParams.MeanAnomaly);

                    AddCellToBody(_secondStagePartOnePdfTable, plan.FlightNumber, _fontStyle);
                    AddCellToBody(_secondStagePartOnePdfTable, plan.Rocket.RocketName, _fontStyle);
                    AddCellToBody(_secondStagePartOnePdfTable, secondStage.PayloadId, _fontStyle);
                    AddCellToBody(_secondStagePartOnePdfTable, noradId, _fontStyle);
                    AddCellToBody(_secondStagePartOnePdfTable, secondStage.Reused, _fontStyle);
                    AddCellToBody(_secondStagePartOnePdfTable, customers, _fontStyle);
                    AddCellToBody(_secondStagePartOnePdfTable, secondStage.Nationality, _fontStyle);
                    AddCellToBody(_secondStagePartOnePdfTable, secondStage.Manufacturer, _fontStyle);

                    AddCellToBody(_secondStagePartTwoPdfTable, plan.FlightNumber, _fontStyle);
                    AddCellToBody(_secondStagePartTwoPdfTable, plan.Rocket.RocketName, _fontStyle);
                    AddCellToBody(_secondStagePartTwoPdfTable, secondStage.PayloadType, _fontStyle);
                    AddCellToBody(_secondStagePartTwoPdfTable, secondStage.PayloadMassKg, _fontStyle);
                    AddCellToBody(_secondStagePartTwoPdfTable, secondStage.PayloadMassLbs, _fontStyle);
                    AddCellToBody(_secondStagePartTwoPdfTable, secondStage.Orbit, _fontStyle);
                    AddCellToBody(_secondStagePartTwoPdfTable, secondStage.OrbitParams.ReferenceSystem, _fontStyle);
                    AddCellToBody(_secondStagePartTwoPdfTable, secondStage.OrbitParams.Regime, _fontStyle);

                    AddCellToBody(_secondStagePartThreePdfTable, plan.FlightNumber, _fontStyle);
                    AddCellToBody(_secondStagePartThreePdfTable, plan.Rocket.RocketName, _fontStyle);
                    AddCellToBody(_secondStagePartThreePdfTable, longitude, _fontStyle);
                    AddCellToBody(_secondStagePartThreePdfTable, axisKm, _fontStyle);
                    AddCellToBody(_secondStagePartThreePdfTable, eccentricity, _fontStyle);
                    AddCellToBody(_secondStagePartThreePdfTable, secondStage.OrbitParams.PeriapsisKm, _fontStyle);
                    AddCellToBody(_secondStagePartThreePdfTable, secondStage.OrbitParams.ApoapsisKm, _fontStyle);
                    AddCellToBody(_secondStagePartThreePdfTable, secondStage.OrbitParams.InclinationDeg, _fontStyle);
                    AddCellToBody(_secondStagePartThreePdfTable, periodMin, _fontStyle);

                    AddCellToBody(_secondStagePartFourPdfTable, plan.FlightNumber, _fontStyle);
                    AddCellToBody(_secondStagePartFourPdfTable, plan.Rocket.RocketName, _fontStyle);
                    AddCellToBody(_secondStagePartFourPdfTable, lifespanYears, _fontStyle);
                    AddCellToBody(_secondStagePartFourPdfTable, epoch, _fontStyle);
                    AddCellToBody(_secondStagePartFourPdfTable, meanMotion, _fontStyle);
                    AddCellToBody(_secondStagePartFourPdfTable, raan, _fontStyle);
                    AddCellToBody(_secondStagePartFourPdfTable, argOfPericenter, _fontStyle);
                    AddCellToBody(_secondStagePartFourPdfTable, meanAnomaly, _fontStyle);
                    AddCellToBody(_secondStagePartFourPdfTable, plan.Rocket.SecondStage.Block, _fontStyle);
                }

                _pdfTable.CompleteRow();
                _secondPdfTable.CompleteRow();
                _thirdPdfTable.CompleteRow();
                _fourthPdfTable.CompleteRow();
                _fifthPdfTable.CompleteRow();
                _firstStagePdfTable.CompleteRow();
                _secondStagePartOnePdfTable.CompleteRow();
                _secondStagePartTwoPdfTable.CompleteRow();
                _secondStagePartThreePdfTable.CompleteRow();
                _secondStagePartFourPdfTable.CompleteRow();
                _linksListPartOnePdfTable.CompleteRow();
                _linksListPartTwoPdfTable.CompleteRow();
                _linksListPartThreePdfTable.CompleteRow();
                _detailsPdfTable.CompleteRow();
                _flickerPdfTable.CompleteRow();
            }
        }

            #endregion

        #endregion

        #region Change Column Size

        private float[] ChangeColumnSize(int _maxColumn)
        {
            float[] sizes = new float[_maxColumn];

            for (var i = 0; i < _maxColumn; i++)
            {
                if (i == 0) sizes[i] = 25;
                else sizes[i] = 40;
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
                Colspan = 10,
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