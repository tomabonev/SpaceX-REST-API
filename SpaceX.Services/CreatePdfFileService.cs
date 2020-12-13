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
    public class CreatePdfFileService : ICreatePdfFileService
    {
        #region Declarations

        private Document _document;
        private Font _fontStyle;

        private PdfPTable _pdfTable = new PdfPTable(8);
        private PdfPTable _secondPdfTable = new PdfPTable(8);
        private PdfPTable _thirdPdfTable = new PdfPTable(8);
        private PdfPTable _fourthPdfTable = new PdfPTable(6);
        private PdfPTable _fifthPdfTable = new PdfPTable(8);
        private PdfPTable _firstStagePdfTable = new PdfPTable(11);
        private PdfPTable _secondStagePartOnePdfTable = new PdfPTable(8);
        private PdfPTable _secondStagePartTwoPdfTable = new PdfPTable(8);
        private PdfPTable _secondStagePartThreePdfTable = new PdfPTable(9);
        private PdfPTable _secondStagePartFourPdfTable = new PdfPTable(9);
        private PdfPTable _linksListPartOnePdfTable = new PdfPTable(5);
        private PdfPTable _linksListPartTwoPdfTable = new PdfPTable(5);
        private PdfPTable _linksListPartThreePdfTable = new PdfPTable(4);
        private PdfPTable _detailsPdfTable = new PdfPTable(3);
        private PdfPTable _flickerPdfTable = new PdfPTable(3);

        private PdfPCell _pdfCell;
        private MemoryStream _memoryStream = new MemoryStream();

        private List<LaunchPlan> _launchPlans = new List<LaunchPlan>();

        #endregion

        #region Export To PDF Method

        /// <summary>
        /// Visualizes the SpaceX API launch plan data
        /// </summary>
        /// <param name="launchPlans">A collection of SpaceX launch data</param>
        /// <returns>Pdf file containing all the SpaceX launch data</returns>
        public byte[] ExportToPdf(List<LaunchPlan> launchPlans)
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

            _pdfTable.SetWidths(this.ChangeColumnSize(8));
            _secondPdfTable.SetWidths(this.ChangeColumnSize(8));
            _thirdPdfTable.SetWidths(this.ChangeColumnSize(8));
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

            RenderHeaders();
            AddSpaceBetweenTables(2);
            RenderPdfDocument();

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

        #endregion

        #region Report To PDF Extension Methods

        #region Render Headers Method

        /// <summary>
        /// Reders the pdf file headers
        /// </summary>
        private void RenderHeaders()
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

        #region Add Spacing for Table Header Method

        /// <summary>
        /// Adds empty rows for the pdf table header
        /// </summary>
        /// <param name="_pdfTable"></param>
        private void AddTableHeader(PdfPTable _pdfTable)
        {
            _pdfTable.HeaderRows = 2;
            this.AddSpaceBetweenTables(2);
        }

        #endregion

        #region Add Logo Method

        /// <summary>
        /// Adds logo to the pdf header
        /// </summary>
        /// <returns>the updated pdf table</returns>
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

        #region Set Page Title Method

        /// <summary>
        /// Sets the pdf page title
        /// </summary>
        /// <returns>the updated pdf table</returns>
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

            return pdfPTable;
        }

        #endregion

        #region Set Table Alignment Method

        /// <summary>
        /// Sets alignments for the pdf file
        /// </summary>
        /// <param name="_pdfTable">The Pdf table which will be configured</param>
        private void SetAlignment(PdfPTable _pdfTable)
        {
            _pdfTable.WidthPercentage = 100;
            _pdfTable.HorizontalAlignment = Element.ALIGN_LEFT;
            _pdfTable.KeepTogether = true;
        }

        #endregion

        #region Set Empty Row Method

        /// <summary>
        /// Adds spacing between the tables
        /// </summary>
        private void AddSpaceBetweenTables(int numCount)
        {
            for (int i = 1; i < numCount; i++)
            {
                AddEmptyRow(_pdfTable, string.Empty, _fontStyle, 8);
                AddEmptyRow(_secondPdfTable, string.Empty, _fontStyle, 8);
                AddEmptyRow(_thirdPdfTable, string.Empty, _fontStyle, 8);
                AddEmptyRow(_fourthPdfTable, string.Empty, _fontStyle, 6);
                AddEmptyRow(_fifthPdfTable, string.Empty, _fontStyle, 8);
                AddEmptyRow(_firstStagePdfTable, string.Empty, _fontStyle, 11);
                AddEmptyRow(_secondStagePartOnePdfTable, string.Empty, _fontStyle, 8);
                AddEmptyRow(_secondStagePartTwoPdfTable, string.Empty, _fontStyle, 8);
                AddEmptyRow(_secondStagePartThreePdfTable, string.Empty, _fontStyle, 9);
                AddEmptyRow(_secondStagePartFourPdfTable, string.Empty, _fontStyle, 9);
                AddEmptyRow(_linksListPartOnePdfTable, string.Empty, _fontStyle, 5);
                AddEmptyRow(_linksListPartTwoPdfTable, string.Empty, _fontStyle, 5);
                AddEmptyRow(_linksListPartThreePdfTable, string.Empty, _fontStyle, 4);
                AddEmptyRow(_detailsPdfTable, string.Empty, _fontStyle, 3);
                AddEmptyRow(_flickerPdfTable, string.Empty, _fontStyle, 3);
            }
        }

        #endregion

        #region Render Pdf Document Method

        /// <summary>
        /// Populates the pdf document with data
        /// </summary>
        private void RenderPdfDocument()
        {
            this.RenderHeader();
            this.RenderBody();
        }

        #region Render Header

        /// <summary>
        /// Renders the pdf file headers
        /// </summary>
        private void RenderHeader()
        {
            var fontStyleBold = FontFactory.GetFont("Tahoma", 9f, 1);
            _fontStyle = FontFactory.GetFont("Tahoma", 9f, 0);

            StyleTableHeader(_pdfTable, "Flight Number", fontStyleBold);
            StyleTableHeader(_pdfTable, "Mission Name", fontStyleBold);
            StyleTableHeader(_pdfTable, "Mission Id", fontStyleBold);
            StyleTableHeader(_pdfTable, "Upcoming", fontStyleBold);
            StyleTableHeader(_pdfTable, "Launch Year", fontStyleBold);
            StyleTableHeader(_pdfTable, "Launch Date", fontStyleBold);
            StyleTableHeader(_pdfTable, "Launch UTC Time", fontStyleBold);
            StyleTableHeader(_pdfTable, "Local Time", fontStyleBold);

            StyleTableHeader(_secondPdfTable, "Flight Number", fontStyleBold);
            StyleTableHeader(_secondPdfTable, "Mission Name", fontStyleBold);
            StyleTableHeader(_secondPdfTable, "Is Tentative", fontStyleBold);
            StyleTableHeader(_secondPdfTable, "Max Precision", fontStyleBold);
            StyleTableHeader(_secondPdfTable, "TBD", fontStyleBold);
            StyleTableHeader(_secondPdfTable, "Launch Window", fontStyleBold);
            StyleTableHeader(_secondPdfTable, "Ships", fontStyleBold);
            StyleTableHeader(_secondPdfTable, "Launch Success", fontStyleBold);

            StyleTableHeader(_thirdPdfTable, "Flight Number", fontStyleBold);
            StyleTableHeader(_thirdPdfTable, "Mission Name", fontStyleBold);
            StyleTableHeader(_thirdPdfTable, "Failure Time", fontStyleBold);
            StyleTableHeader(_thirdPdfTable, "Failure Altitude", fontStyleBold);
            StyleTableHeader(_thirdPdfTable, "Failure Reason", fontStyleBold);
            StyleTableHeader(_thirdPdfTable, "Fire Date UTC", fontStyleBold);
            StyleTableHeader(_thirdPdfTable, "Fire Date Unix", fontStyleBold);
            StyleTableHeader(_thirdPdfTable, "Webcast LiftOff", fontStyleBold);

            StyleTableHeader(_fourthPdfTable, "Flight Number", fontStyleBold);
            StyleTableHeader(_fourthPdfTable, "Mission Name", fontStyleBold);
            StyleTableHeader(_fourthPdfTable, "Flight Club", fontStyleBold);
            StyleTableHeader(_fourthPdfTable, "Site Id", fontStyleBold);
            StyleTableHeader(_fourthPdfTable, "Site Name", fontStyleBold);
            StyleTableHeader(_fourthPdfTable, "Site Full Name", fontStyleBold);

            StyleTableHeader(_fifthPdfTable, "Flight Number", fontStyleBold);
            StyleTableHeader(_fifthPdfTable, "Rocket Id", fontStyleBold);
            StyleTableHeader(_fifthPdfTable, "Rocket Name", fontStyleBold);
            StyleTableHeader(_fifthPdfTable, "Rocket Type", fontStyleBold);
            StyleTableHeader(_fifthPdfTable, "Reused", fontStyleBold);
            StyleTableHeader(_fifthPdfTable, "Recovery Attempt", fontStyleBold);
            StyleTableHeader(_fifthPdfTable, "Recovered", fontStyleBold);
            StyleTableHeader(_fifthPdfTable, "Ship", fontStyleBold);

            StyleTableHeader(_firstStagePdfTable, "Flight Number", fontStyleBold);
            StyleTableHeader(_firstStagePdfTable, "Core Serial", fontStyleBold);
            StyleTableHeader(_firstStagePdfTable, "Flight", fontStyleBold);
            StyleTableHeader(_firstStagePdfTable, "Block", fontStyleBold);
            StyleTableHeader(_firstStagePdfTable, "GridFins", fontStyleBold);
            StyleTableHeader(_firstStagePdfTable, "Legs", fontStyleBold);
            StyleTableHeader(_firstStagePdfTable, "Reused", fontStyleBold);
            StyleTableHeader(_firstStagePdfTable, "Land", fontStyleBold);
            StyleTableHeader(_firstStagePdfTable, "Landing intent", fontStyleBold);
            StyleTableHeader(_firstStagePdfTable, "Landing type", fontStyleBold);
            StyleTableHeader(_firstStagePdfTable, "Landing vehicle", fontStyleBold);

            StyleTableHeader(_secondStagePartOnePdfTable, "Flight Number", fontStyleBold);
            StyleTableHeader(_secondStagePartOnePdfTable, "Rocket Name", fontStyleBold);
            StyleTableHeader(_secondStagePartOnePdfTable, "Payload Id", fontStyleBold);
            StyleTableHeader(_secondStagePartOnePdfTable, "Norad Id", fontStyleBold);
            StyleTableHeader(_secondStagePartOnePdfTable, "Reused", fontStyleBold);
            StyleTableHeader(_secondStagePartOnePdfTable, "Customers", fontStyleBold);
            StyleTableHeader(_secondStagePartOnePdfTable, "Nationality", fontStyleBold);
            StyleTableHeader(_secondStagePartOnePdfTable, "Manufacturer", fontStyleBold);

            StyleTableHeader(_secondStagePartTwoPdfTable, "Flight Number", fontStyleBold);
            StyleTableHeader(_secondStagePartTwoPdfTable, "Rocket Name", fontStyleBold);
            StyleTableHeader(_secondStagePartTwoPdfTable, "Payload Type", fontStyleBold);
            StyleTableHeader(_secondStagePartTwoPdfTable, "Mass kg", fontStyleBold);
            StyleTableHeader(_secondStagePartTwoPdfTable, "Mass lbs", fontStyleBold);
            StyleTableHeader(_secondStagePartTwoPdfTable, "Orbit", fontStyleBold);
            StyleTableHeader(_secondStagePartTwoPdfTable, "Reference System", fontStyleBold);
            StyleTableHeader(_secondStagePartTwoPdfTable, "Regime", fontStyleBold);

            StyleTableHeader(_secondStagePartThreePdfTable, "Flight Number", fontStyleBold);
            StyleTableHeader(_secondStagePartThreePdfTable, "Rocket Name", fontStyleBold);
            StyleTableHeader(_secondStagePartThreePdfTable, "Longtitude", fontStyleBold);
            StyleTableHeader(_secondStagePartThreePdfTable, "Axis km", fontStyleBold);
            StyleTableHeader(_secondStagePartThreePdfTable, "Eccentricity", fontStyleBold);
            StyleTableHeader(_secondStagePartThreePdfTable, "Periapsis Km", fontStyleBold);
            StyleTableHeader(_secondStagePartThreePdfTable, "Apoapsis Km", fontStyleBold);
            StyleTableHeader(_secondStagePartThreePdfTable, "InclinationDeg", fontStyleBold);
            StyleTableHeader(_secondStagePartThreePdfTable, "PeriodMin", fontStyleBold);

            StyleTableHeader(_secondStagePartFourPdfTable, "Flight Number", fontStyleBold);
            StyleTableHeader(_secondStagePartFourPdfTable, "Rocket Name", fontStyleBold);
            StyleTableHeader(_secondStagePartFourPdfTable, "Lifespan Years", fontStyleBold);
            StyleTableHeader(_secondStagePartFourPdfTable, "Epoch", fontStyleBold);
            StyleTableHeader(_secondStagePartFourPdfTable, "Mean Motion", fontStyleBold);
            StyleTableHeader(_secondStagePartFourPdfTable, "Raan", fontStyleBold);
            StyleTableHeader(_secondStagePartFourPdfTable, "Arg Of Pericenter", fontStyleBold);
            StyleTableHeader(_secondStagePartFourPdfTable, "Mean Anomaly", fontStyleBold);
            StyleTableHeader(_secondStagePartFourPdfTable, "Block", fontStyleBold);

            StyleTableHeader(_linksListPartOnePdfTable, "Flight Number", fontStyleBold);
            StyleTableHeader(_linksListPartOnePdfTable, "Mission Patch", fontStyleBold);
            StyleTableHeader(_linksListPartOnePdfTable, "Mission Small Patch", fontStyleBold);
            StyleTableHeader(_linksListPartOnePdfTable, "Reddit Campaign", fontStyleBold);
            StyleTableHeader(_linksListPartOnePdfTable, "Reddit Launch", fontStyleBold);

            StyleTableHeader(_linksListPartTwoPdfTable, "Flight Number", fontStyleBold);
            StyleTableHeader(_linksListPartTwoPdfTable, "Reddit Recovery", fontStyleBold);
            StyleTableHeader(_linksListPartTwoPdfTable, "Reddit Media", fontStyleBold);
            StyleTableHeader(_linksListPartTwoPdfTable, "Presskit", fontStyleBold);
            StyleTableHeader(_linksListPartTwoPdfTable, "Article link", fontStyleBold);

            StyleTableHeader(_linksListPartThreePdfTable, "Flight Number", fontStyleBold);
            StyleTableHeader(_linksListPartThreePdfTable, "Wikipedia", fontStyleBold);
            StyleTableHeader(_linksListPartThreePdfTable, "Video link", fontStyleBold);
            StyleTableHeader(_linksListPartThreePdfTable, "Youtube Id", fontStyleBold);

            StyleTableHeader(_detailsPdfTable, "Flight Number", fontStyleBold);
            StyleTableHeader(_detailsPdfTable, "Mission Name", fontStyleBold);
            StyleTableHeader(_detailsPdfTable, "Details", fontStyleBold);

            StyleTableHeader(_flickerPdfTable, "Flight Number", fontStyleBold);
            StyleTableHeader(_flickerPdfTable, "Mission Name", fontStyleBold);
            StyleTableHeader(_flickerPdfTable, "Flickr image", fontStyleBold);

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

        #region Render Body

        /// <summary>
        /// Renders the pdf file body
        /// </summary>
        private void RenderBody()
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

                StyleTableBody(_pdfTable, plan.FlightNumber, _fontStyle);
                StyleTableBody(_pdfTable, plan.MissionName, _fontStyle);
                StyleTableBody(_pdfTable, missionId, _fontStyle);
                StyleTableBody(_pdfTable, plan.Upcoming, _fontStyle);
                StyleTableBody(_pdfTable, plan.LaunchYear, _fontStyle);
                StyleTableBody(_pdfTable, plan.LaunchDateUnix, _fontStyle);
                StyleTableBody(_pdfTable, plan.LaunchDateUtc.UtcDateTime.ToString(), _fontStyle);
                StyleTableBody(_pdfTable, plan.LaunchDateLocal.LocalDateTime.ToString(), _fontStyle);

                StyleTableBody(_secondPdfTable, plan.FlightNumber, _fontStyle);
                StyleTableBody(_secondPdfTable, plan.MissionName, _fontStyle);
                StyleTableBody(_secondPdfTable, plan.IsTentative, _fontStyle);
                StyleTableBody(_secondPdfTable, plan.TentativeMaxPrecision, _fontStyle);
                StyleTableBody(_secondPdfTable, plan.Tbd, _fontStyle);
                StyleTableBody(_secondPdfTable, plan.LaunchWindow, _fontStyle);
                StyleTableBody(_secondPdfTable, ships, _fontStyle);
                StyleTableBody(_secondPdfTable, plan.LaunchSuccess, _fontStyle);

                StyleTableBody(_thirdPdfTable, plan.FlightNumber, _fontStyle);
                StyleTableBody(_thirdPdfTable, plan.MissionName, _fontStyle);
                StyleTableBody(_thirdPdfTable, plan.LaunchFailureDetails.Time, _fontStyle);
                StyleTableBody(_thirdPdfTable, altitude, _fontStyle);
                StyleTableBody(_thirdPdfTable, plan.LaunchFailureDetails.Reason, _fontStyle);
                StyleTableBody(_thirdPdfTable, plan.StaticFireDateUtc.ToString(), _fontStyle);
                StyleTableBody(_thirdPdfTable, plan.StaticFireDateUnix, _fontStyle);
                StyleTableBody(_thirdPdfTable, plan.Timeline?.WebcastLiftoff ?? null, _fontStyle);

                StyleTableBody(_fourthPdfTable, plan.FlightNumber, _fontStyle);
                StyleTableBody(_fourthPdfTable, plan.MissionName, _fontStyle);
                StyleTableBody(_fourthPdfTable, flightClub, _fontStyle);
                StyleTableBody(_fourthPdfTable, plan.LaunchSite.SiteId, _fontStyle);
                StyleTableBody(_fourthPdfTable, plan.LaunchSite.SiteName, _fontStyle);
                StyleTableBody(_fourthPdfTable, plan.LaunchSite.SiteNameLong, _fontStyle);

                StyleTableBody(_fifthPdfTable, plan.FlightNumber, _fontStyle);
                StyleTableBody(_fifthPdfTable, plan.Rocket.RocketId, _fontStyle);
                StyleTableBody(_fifthPdfTable, plan.Rocket.RocketName, _fontStyle);
                StyleTableBody(_fifthPdfTable, plan.Rocket.RocketType, _fontStyle);
                StyleTableBody(_fifthPdfTable, reused, _fontStyle);
                StyleTableBody(_fifthPdfTable, recoveryAttempt, _fontStyle);
                StyleTableBody(_fifthPdfTable, recovered, _fontStyle);
                StyleTableBody(_fifthPdfTable, ship, _fontStyle);

                StyleTableBody(_linksListPartOnePdfTable, plan.FlightNumber, _fontStyle);
                StyleTableBody(_linksListPartOnePdfTable, plan.Links.MissionPatch, _fontStyle);
                StyleTableBody(_linksListPartOnePdfTable, plan.Links.MissionPatchSmall, _fontStyle);
                StyleTableBody(_linksListPartOnePdfTable, redditCampaing, _fontStyle);
                StyleTableBody(_linksListPartOnePdfTable, redditLaunch, _fontStyle);

                StyleTableBody(_linksListPartTwoPdfTable, plan.FlightNumber, _fontStyle);
                StyleTableBody(_linksListPartTwoPdfTable, redditRecovery, _fontStyle);
                StyleTableBody(_linksListPartTwoPdfTable, redditMedia, _fontStyle);
                StyleTableBody(_linksListPartTwoPdfTable, presskit, _fontStyle);
                StyleTableBody(_linksListPartTwoPdfTable, plan.Links.ArticleLink, _fontStyle);

                StyleTableBody(_linksListPartThreePdfTable, plan.FlightNumber, _fontStyle);
                StyleTableBody(_linksListPartThreePdfTable, plan.Links.Wikipedia, _fontStyle);
                StyleTableBody(_linksListPartThreePdfTable, plan.Links.VideoLink, _fontStyle);
                StyleTableBody(_linksListPartThreePdfTable, plan.Links.YoutubeId, _fontStyle);

                StyleTableBody(_detailsPdfTable, plan.FlightNumber, _fontStyle);
                StyleTableBody(_detailsPdfTable, plan.MissionName, _fontStyle);
                StyleTableBody(_detailsPdfTable, plan.Details, _fontStyle);

                StyleTableBody(_flickerPdfTable, plan.FlightNumber, _fontStyle);
                StyleTableBody(_flickerPdfTable, plan.MissionName, _fontStyle);
                StyleTableBody(_flickerPdfTable, flickrImage, _fontStyle);

                foreach (var firstStage in plan.Rocket.FirstStage.Cores)
                {
                    var block = string.Join(" ", firstStage.Block);
                    var landSuccess = string.Join(" ", firstStage.LandSuccess);
                    var landingType = string.Join(" ", firstStage.LandingType);
                    var landingVehicle = string.Join(" ", firstStage.LandingVehicle);

                    StyleTableBody(_firstStagePdfTable, plan.FlightNumber, _fontStyle);
                    StyleTableBody(_firstStagePdfTable, firstStage.CoreSerial, _fontStyle);
                    StyleTableBody(_firstStagePdfTable, firstStage.Flight, _fontStyle);
                    StyleTableBody(_firstStagePdfTable, block, _fontStyle);
                    StyleTableBody(_firstStagePdfTable, firstStage.Gridfins, _fontStyle);
                    StyleTableBody(_firstStagePdfTable, firstStage.Legs, _fontStyle);
                    StyleTableBody(_firstStagePdfTable, firstStage.Reused, _fontStyle);
                    StyleTableBody(_firstStagePdfTable, landSuccess, _fontStyle);
                    StyleTableBody(_firstStagePdfTable, firstStage.LandingIntent, _fontStyle);
                    StyleTableBody(_firstStagePdfTable, landingType, _fontStyle);
                    StyleTableBody(_firstStagePdfTable, landingVehicle, _fontStyle);
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

                    StyleTableBody(_secondStagePartOnePdfTable, plan.FlightNumber, _fontStyle);
                    StyleTableBody(_secondStagePartOnePdfTable, plan.Rocket.RocketName, _fontStyle);
                    StyleTableBody(_secondStagePartOnePdfTable, secondStage.PayloadId, _fontStyle);
                    StyleTableBody(_secondStagePartOnePdfTable, noradId, _fontStyle);
                    StyleTableBody(_secondStagePartOnePdfTable, secondStage.Reused, _fontStyle);
                    StyleTableBody(_secondStagePartOnePdfTable, customers, _fontStyle);
                    StyleTableBody(_secondStagePartOnePdfTable, secondStage.Nationality, _fontStyle);
                    StyleTableBody(_secondStagePartOnePdfTable, secondStage.Manufacturer, _fontStyle);

                    StyleTableBody(_secondStagePartTwoPdfTable, plan.FlightNumber, _fontStyle);
                    StyleTableBody(_secondStagePartTwoPdfTable, plan.Rocket.RocketName, _fontStyle);
                    StyleTableBody(_secondStagePartTwoPdfTable, secondStage.PayloadType, _fontStyle);
                    StyleTableBody(_secondStagePartTwoPdfTable, secondStage.PayloadMassKg, _fontStyle);
                    StyleTableBody(_secondStagePartTwoPdfTable, secondStage.PayloadMassLbs, _fontStyle);
                    StyleTableBody(_secondStagePartTwoPdfTable, secondStage.Orbit, _fontStyle);
                    StyleTableBody(_secondStagePartTwoPdfTable, secondStage.OrbitParams.ReferenceSystem, _fontStyle);
                    StyleTableBody(_secondStagePartTwoPdfTable, secondStage.OrbitParams.Regime, _fontStyle);

                    StyleTableBody(_secondStagePartThreePdfTable, plan.FlightNumber, _fontStyle);
                    StyleTableBody(_secondStagePartThreePdfTable, plan.Rocket.RocketName, _fontStyle);
                    StyleTableBody(_secondStagePartThreePdfTable, longitude, _fontStyle);
                    StyleTableBody(_secondStagePartThreePdfTable, axisKm, _fontStyle);
                    StyleTableBody(_secondStagePartThreePdfTable, eccentricity, _fontStyle);
                    StyleTableBody(_secondStagePartThreePdfTable, secondStage.OrbitParams.PeriapsisKm, _fontStyle);
                    StyleTableBody(_secondStagePartThreePdfTable, secondStage.OrbitParams.ApoapsisKm, _fontStyle);
                    StyleTableBody(_secondStagePartThreePdfTable, secondStage.OrbitParams.InclinationDeg, _fontStyle);
                    StyleTableBody(_secondStagePartThreePdfTable, periodMin, _fontStyle);

                    StyleTableBody(_secondStagePartFourPdfTable, plan.FlightNumber, _fontStyle);
                    StyleTableBody(_secondStagePartFourPdfTable, plan.Rocket.RocketName, _fontStyle);
                    StyleTableBody(_secondStagePartFourPdfTable, lifespanYears, _fontStyle);
                    StyleTableBody(_secondStagePartFourPdfTable, epoch, _fontStyle);
                    StyleTableBody(_secondStagePartFourPdfTable, meanMotion, _fontStyle);
                    StyleTableBody(_secondStagePartFourPdfTable, raan, _fontStyle);
                    StyleTableBody(_secondStagePartFourPdfTable, argOfPericenter, _fontStyle);
                    StyleTableBody(_secondStagePartFourPdfTable, meanAnomaly, _fontStyle);
                    StyleTableBody(_secondStagePartFourPdfTable, plan.Rocket.SecondStage.Block, _fontStyle);
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

        #region Change Column Size Method

        /// <summary>
        /// Changes the column size of the pdf file
        /// </summary>
        /// <param name="_maxColumn"></param>
        /// <returns>The updated column size</returns>
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

        #endregion

        #region Style Header Method

        /// <summary>
        /// Adds style to the document header
        /// </summary>
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

        #region Add Empty Row Method

        /// <summary>
        /// Adds empty row for each cell
        /// </summary>
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

        #region Style Table Header Method

        /// <summary>
        /// Style table headers
        /// </summary>
        private void StyleTableHeader(PdfPTable _pdfTable, string cellText, Font fontStyleBold)
        {
            _pdfTable.AddCell(new PdfPCell(new Phrase(cellText, fontStyleBold))
            {
                HorizontalAlignment = Element.ALIGN_CENTER,
                VerticalAlignment = Element.ALIGN_MIDDLE,
                BackgroundColor = BaseColor.Gray
            });
        }

        #endregion

        #region Style Table Body Method

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

        #endregion
    }
}