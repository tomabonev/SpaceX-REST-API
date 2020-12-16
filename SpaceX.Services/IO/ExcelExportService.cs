using ClosedXML.Excel;
using SpaceX.Services.DTO;
using SpaceX.Services.IO;
using System.Collections.Generic;
using System.IO;

namespace SpaceX.Services
{
    /// <summary>
    /// This class expose functionality for exporting data into .xlsx format
    /// </summary>
    public class ExcelExportService : IExportService
    {
        #region Public Methods

        public byte[] Export(List<LaunchPlan> launchPlans)
        {
            using (var workbook = new XLWorkbook())
            {
                IXLWorksheet launchPlanSheet = workbook.Worksheets.Add("Launch Plan");

                this.RenderHeader(launchPlanSheet);
                this.RenderBody(launchPlans, launchPlanSheet);
                this.StyleAlignment(launchPlanSheet);

                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    var content = stream.ToArray();
                    return content;
                }
            }
        }

        #endregion

        #region Private Methods

        private void RenderHeader(IXLWorksheet launchPlanSheet)
        {
            int currentRow = 1;
            int currentCol = 1;

            launchPlanSheet.Cell(currentRow, currentCol++).Value = "Flight Number";
            launchPlanSheet.Cell(currentRow, currentCol++).Value = "Mission Name";
            launchPlanSheet.Cell(currentRow, currentCol++).Value = "Mission Id";
            launchPlanSheet.Cell(currentRow, currentCol++).Value = "Upcoming";
            launchPlanSheet.Cell(currentRow, currentCol++).Value = "Launch Year";
            launchPlanSheet.Cell(currentRow, currentCol++).Value = "Launch Date Unix";
            launchPlanSheet.Cell(currentRow, currentCol++).Value = "Launch Date Utc";
            launchPlanSheet.Cell(currentRow, currentCol++).Value = "Launch Date Local";
            launchPlanSheet.Cell(currentRow, currentCol++).Value = "Is Tentative";
            launchPlanSheet.Cell(currentRow, currentCol++).Value = "Tentative Max Precision";
            launchPlanSheet.Cell(currentRow, currentCol++).Value = "Tbd";
            launchPlanSheet.Cell(currentRow, currentCol++).Value = "LaunchWindow";
            launchPlanSheet.Cell(currentRow, currentCol++).Value = "Ships";
            launchPlanSheet.Cell(currentRow, currentCol++).Value = "Flight Club";
            launchPlanSheet.Cell(currentRow, currentCol++).Value = "Site Id";
            launchPlanSheet.Cell(currentRow, currentCol++).Value = "Site Name";
            launchPlanSheet.Cell(currentRow, currentCol++).Value = "Site Name Long";
            launchPlanSheet.Cell(currentRow, currentCol++).Value = "Launch Success";
            launchPlanSheet.Cell(currentRow, currentCol++).Value = "Fail Time";
            launchPlanSheet.Cell(currentRow, currentCol++).Value = "Fail Altitude";
            launchPlanSheet.Cell(currentRow, currentCol++).Value = "Fail Reason";
            launchPlanSheet.Cell(currentRow, currentCol++).Value = "Mission Patch";
            launchPlanSheet.Cell(currentRow, currentCol++).Value = "Mission Patch Small";
            launchPlanSheet.Cell(currentRow, currentCol++).Value = "Reddit Campaign";
            launchPlanSheet.Cell(currentRow, currentCol++).Value = "Reddit Launch";
            launchPlanSheet.Cell(currentRow, currentCol++).Value = "Reddit Recovery";
            launchPlanSheet.Cell(currentRow, currentCol++).Value = "Reddit Media";
            launchPlanSheet.Cell(currentRow, currentCol++).Value = "Press Kit";
            launchPlanSheet.Cell(currentRow, currentCol++).Value = "Article Link";
            launchPlanSheet.Cell(currentRow, currentCol++).Value = "Wikipedia";
            launchPlanSheet.Cell(currentRow, currentCol++).Value = "Video Link";
            launchPlanSheet.Cell(currentRow, currentCol++).Value = "Youtube Id";
            launchPlanSheet.Cell(currentRow, currentCol++).Value = "Flickr Images";
            launchPlanSheet.Cell(currentRow, currentCol++).Value = "Details";
            launchPlanSheet.Cell(currentRow, currentCol++).Value = "Static Fire Date";
            launchPlanSheet.Cell(currentRow, currentCol++).Value = "Static Fire Date Unix";
            launchPlanSheet.Cell(currentRow, currentCol++).Value = "Webcast Liftoff";

            launchPlanSheet.Cell(currentRow, currentCol++).Value = "Rocket Id";
            launchPlanSheet.Cell(currentRow, currentCol++).Value = "Rocket Name";
            launchPlanSheet.Cell(currentRow, currentCol++).Value = "Rocket Type";
            launchPlanSheet.Cell(currentRow, currentCol++).Value = "Reused";
            launchPlanSheet.Cell(currentRow, currentCol++).Value = "Recovery Attempt";
            launchPlanSheet.Cell(currentRow, currentCol++).Value = "Recovered";
            launchPlanSheet.Cell(currentRow, currentCol++).Value = "Ship";
                                             
            launchPlanSheet.Cell(currentRow, currentCol++).Value = "Core Serial";
            launchPlanSheet.Cell(currentRow, currentCol++).Value = "Flight";
            launchPlanSheet.Cell(currentRow, currentCol++).Value = "Block";
            launchPlanSheet.Cell(currentRow, currentCol++).Value = "Gridfins";
            launchPlanSheet.Cell(currentRow, currentCol++).Value = "Legs";
            launchPlanSheet.Cell(currentRow, currentCol++).Value = "Reused";
            launchPlanSheet.Cell(currentRow, currentCol++).Value = "Land Success";
            launchPlanSheet.Cell(currentRow, currentCol++).Value = "Landing Intent";
            launchPlanSheet.Cell(currentRow, currentCol++).Value = "Landing Type";
            launchPlanSheet.Cell(currentRow, currentCol++).Value = "Landing Vehicle";
                                             
            launchPlanSheet.Cell(currentRow, currentCol++).Value = "Payload Id";
            launchPlanSheet.Cell(currentRow, currentCol++).Value = "Norad Id";
            launchPlanSheet.Cell(currentRow, currentCol++).Value = "Reused";
            launchPlanSheet.Cell(currentRow, currentCol++).Value = "Customers";
            launchPlanSheet.Cell(currentRow, currentCol++).Value = "Nationality";
            launchPlanSheet.Cell(currentRow, currentCol++).Value = "Manufacturer";
            launchPlanSheet.Cell(currentRow, currentCol++).Value = "PayloadType";
            launchPlanSheet.Cell(currentRow, currentCol++).Value = "Payload Mass Kg";
            launchPlanSheet.Cell(currentRow, currentCol++).Value = "Payload Mass Lbs";
            launchPlanSheet.Cell(currentRow, currentCol++).Value = "Orbit";
            launchPlanSheet.Cell(currentRow, currentCol++).Value = "Reference System";
            launchPlanSheet.Cell(currentRow, currentCol++).Value = "Regime";
            launchPlanSheet.Cell(currentRow, currentCol++).Value = "Longitude";
            launchPlanSheet.Cell(currentRow, currentCol++).Value = "Semi-Major Axis Km";
            launchPlanSheet.Cell(currentRow, currentCol++).Value = "Eccentricity";
            launchPlanSheet.Cell(currentRow, currentCol++).Value = "Periapsis Km";
            launchPlanSheet.Cell(currentRow, currentCol++).Value = "Apoapsis Km";
            launchPlanSheet.Cell(currentRow, currentCol++).Value = "Inclination Deg";
            launchPlanSheet.Cell(currentRow, currentCol++).Value = "Period Min";
            launchPlanSheet.Cell(currentRow, currentCol++).Value = "Lifespan Years";
            launchPlanSheet.Cell(currentRow, currentCol++).Value = "Epoch";
            launchPlanSheet.Cell(currentRow, currentCol++).Value = "Mean Motion";
            launchPlanSheet.Cell(currentRow, currentCol++).Value = "Raan";
            launchPlanSheet.Cell(currentRow, currentCol++).Value = "Arg Of Pericenter";
            launchPlanSheet.Cell(currentRow, currentCol++).Value = "Mean Anomaly";
            launchPlanSheet.Cell(currentRow, currentCol++).Value = "Block";
        }

        private void RenderBody(List<LaunchPlan> launchPlans, IXLWorksheet launchPlanSheet)
        {
            int currentRow = 1;

            foreach (var launchPlanItem in launchPlans)
            {
                int currcol = 1;
                currentRow++;

                launchPlanSheet.Cell(currentRow, currcol++).Value = launchPlanItem.FlightNumber;
                launchPlanSheet.Cell(currentRow, currcol++).Value = launchPlanItem.MissionName;
                launchPlanSheet.Cell(currentRow, currcol++).Value = launchPlanItem.MissionId;
                launchPlanSheet.Cell(currentRow, currcol++).Value = launchPlanItem.Upcoming;
                launchPlanSheet.Cell(currentRow, currcol++).Value = launchPlanItem.LaunchYear;
                launchPlanSheet.Cell(currentRow, currcol++).Value = launchPlanItem.LaunchDateUnix;
                launchPlanSheet.Cell(currentRow, currcol++).Value = launchPlanItem.LaunchDateUtc.UtcDateTime;
                launchPlanSheet.Cell(currentRow, currcol++).Value = launchPlanItem.LaunchDateLocal.LocalDateTime;
                launchPlanSheet.Cell(currentRow, currcol++).Value = launchPlanItem.IsTentative;
                launchPlanSheet.Cell(currentRow, currcol++).Value = launchPlanItem.TentativeMaxPrecision;
                launchPlanSheet.Cell(currentRow, currcol++).Value = launchPlanItem.Tbd;
                launchPlanSheet.Cell(currentRow, currcol++).Value = launchPlanItem.LaunchWindow;
                launchPlanSheet.Cell(currentRow, currcol++).Value = launchPlanItem.Ships;
                launchPlanSheet.Cell(currentRow, currcol++).Value = launchPlanItem.Telemetry.FlightClub;
                launchPlanSheet.Cell(currentRow, currcol++).Value = launchPlanItem.LaunchSite.SiteId;
                launchPlanSheet.Cell(currentRow, currcol++).Value = launchPlanItem.LaunchSite.SiteName;
                launchPlanSheet.Cell(currentRow, currcol++).Value = launchPlanItem.LaunchSite.SiteNameLong;
                launchPlanSheet.Cell(currentRow, currcol++).Value = launchPlanItem.LaunchSuccess;
                launchPlanSheet.Cell(currentRow, currcol++).Value = launchPlanItem.LaunchFailureDetails.Time;
                launchPlanSheet.Cell(currentRow, currcol++).Value = launchPlanItem.LaunchFailureDetails.Altitude;
                launchPlanSheet.Cell(currentRow, currcol++).Value = launchPlanItem.LaunchFailureDetails.Reason;
                launchPlanSheet.Cell(currentRow, currcol++).Value = launchPlanItem.Links.MissionPatch;
                launchPlanSheet.Cell(currentRow, currcol++).Value = launchPlanItem.Links.MissionPatchSmall;
                launchPlanSheet.Cell(currentRow, currcol++).Value = launchPlanItem.Links.RedditCampaign;
                launchPlanSheet.Cell(currentRow, currcol++).Value = launchPlanItem.Links.RedditLaunch;
                launchPlanSheet.Cell(currentRow, currcol++).Value = launchPlanItem.Links.RedditRecovery;
                launchPlanSheet.Cell(currentRow, currcol++).Value = launchPlanItem.Links.RedditMedia;
                launchPlanSheet.Cell(currentRow, currcol++).Value = launchPlanItem.Links.Presskit;
                launchPlanSheet.Cell(currentRow, currcol++).Value = launchPlanItem.Links.ArticleLink;
                launchPlanSheet.Cell(currentRow, currcol++).Value = launchPlanItem.Links.Wikipedia;
                launchPlanSheet.Cell(currentRow, currcol++).Value = launchPlanItem.Links.VideoLink;
                launchPlanSheet.Cell(currentRow, currcol++).Value = launchPlanItem.Links.YoutubeId;
                launchPlanSheet.Cell(currentRow, currcol++).Value = launchPlanItem.Links.FlickrImages;
                launchPlanSheet.Cell(currentRow, currcol++).Value = launchPlanItem.Details;
                launchPlanSheet.Cell(currentRow, currcol++).Value = launchPlanItem.StaticFireDateUtc;
                launchPlanSheet.Cell(currentRow, currcol++).Value = launchPlanItem.StaticFireDateUnix;
                launchPlanSheet.Cell(currentRow, currcol++).Value = launchPlanItem.Timeline?.WebcastLiftoff ?? null;

                launchPlanSheet.Cell(currentRow, currcol++).Value = launchPlanItem.Rocket.RocketId;
                launchPlanSheet.Cell(currentRow, currcol++).Value = launchPlanItem.Rocket.RocketName;
                launchPlanSheet.Cell(currentRow, currcol++).Value = launchPlanItem.Rocket.RocketType;
                launchPlanSheet.Cell(currentRow, currcol++).Value = launchPlanItem.Rocket.Fairings?.Reused ?? null;
                launchPlanSheet.Cell(currentRow, currcol++).Value = launchPlanItem.Rocket.Fairings?.RecoveryAttempt ?? null;
                launchPlanSheet.Cell(currentRow, currcol++).Value = launchPlanItem.Rocket.Fairings?.Recovered ?? null;
                launchPlanSheet.Cell(currentRow, currcol++).Value = launchPlanItem.Rocket.Fairings?.Ship ?? null;

                foreach (var firstStage in launchPlanItem.Rocket.FirstStage.Cores)
                {
                    int firstStageCol = 45;

                    launchPlanSheet.Cell(currentRow, firstStageCol++).Value = firstStage.CoreSerial;
                    launchPlanSheet.Cell(currentRow, firstStageCol++).Value = firstStage.Flight;
                    launchPlanSheet.Cell(currentRow, firstStageCol++).Value = firstStage.Block;
                    launchPlanSheet.Cell(currentRow, firstStageCol++).Value = firstStage.Gridfins;
                    launchPlanSheet.Cell(currentRow, firstStageCol++).Value = firstStage.Legs;
                    launchPlanSheet.Cell(currentRow, firstStageCol++).Value = firstStage.Reused;
                    launchPlanSheet.Cell(currentRow, firstStageCol++).Value = firstStage.LandSuccess;
                    launchPlanSheet.Cell(currentRow, firstStageCol++).Value = firstStage.LandingIntent;
                    launchPlanSheet.Cell(currentRow, firstStageCol++).Value = firstStage.LandingType;
                    launchPlanSheet.Cell(currentRow, firstStageCol++).Value = firstStage.LandingVehicle;
                }

                foreach (var secondStage in launchPlanItem.Rocket.SecondStage.Payloads)
                {
                    int secondStageCol = 55;

                    launchPlanSheet.Cell(currentRow, secondStageCol++).Value = secondStage.PayloadId;
                    launchPlanSheet.Cell(currentRow, secondStageCol++).Value = secondStage.NoradId;
                    launchPlanSheet.Cell(currentRow, secondStageCol++).Value = secondStage.Reused;
                    launchPlanSheet.Cell(currentRow, secondStageCol++).Value = secondStage.Customers;
                    launchPlanSheet.Cell(currentRow, secondStageCol++).Value = secondStage.Nationality;
                    launchPlanSheet.Cell(currentRow, secondStageCol++).Value = secondStage.Manufacturer;
                    launchPlanSheet.Cell(currentRow, secondStageCol++).Value = secondStage.PayloadType;
                    launchPlanSheet.Cell(currentRow, secondStageCol++).Value = secondStage.PayloadMassKg;
                    launchPlanSheet.Cell(currentRow, secondStageCol++).Value = secondStage.PayloadMassLbs;
                    launchPlanSheet.Cell(currentRow, secondStageCol++).Value = secondStage.Orbit;
                    launchPlanSheet.Cell(currentRow, secondStageCol++).Value = secondStage.OrbitParams.ReferenceSystem;
                    launchPlanSheet.Cell(currentRow, secondStageCol++).Value = secondStage.OrbitParams.Regime;
                    launchPlanSheet.Cell(currentRow, secondStageCol++).Value = secondStage.OrbitParams.Longitude;
                    launchPlanSheet.Cell(currentRow, secondStageCol++).Value = secondStage.OrbitParams.SemiMajorAxisKm;
                    launchPlanSheet.Cell(currentRow, secondStageCol++).Value = secondStage.OrbitParams.Eccentricity;
                    launchPlanSheet.Cell(currentRow, secondStageCol++).Value = secondStage.OrbitParams.PeriapsisKm;
                    launchPlanSheet.Cell(currentRow, secondStageCol++).Value = secondStage.OrbitParams.ApoapsisKm;
                    launchPlanSheet.Cell(currentRow, secondStageCol++).Value = secondStage.OrbitParams.InclinationDeg;
                    launchPlanSheet.Cell(currentRow, secondStageCol++).Value = secondStage.OrbitParams.PeriodMin;
                    launchPlanSheet.Cell(currentRow, secondStageCol++).Value = secondStage.OrbitParams.LifespanYears;
                    launchPlanSheet.Cell(currentRow, secondStageCol++).Value = secondStage.OrbitParams.Epoch;
                    launchPlanSheet.Cell(currentRow, secondStageCol++).Value = secondStage.OrbitParams.MeanMotion;
                    launchPlanSheet.Cell(currentRow, secondStageCol++).Value = secondStage.OrbitParams.Raan;
                    launchPlanSheet.Cell(currentRow, secondStageCol++).Value = secondStage.OrbitParams.ArgOfPericenter;
                    launchPlanSheet.Cell(currentRow, secondStageCol++).Value = secondStage.OrbitParams.MeanAnomaly;
                    launchPlanSheet.Cell(currentRow, secondStageCol++).Value = launchPlanItem.Rocket.SecondStage.Block;
                }
            }
        }

        private void StyleAlignment(IXLWorksheet launchPlanSheet)
        {
            launchPlanSheet.Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
            launchPlanSheet.Columns().AdjustToContents();
            launchPlanSheet.FirstRow().Style.Fill.BackgroundColor = XLColor.Orange;
            launchPlanSheet.FirstRow().Style.Font.Bold = true;
            launchPlanSheet.TabColor = XLColor.Orange;
        }

        #endregion
    }
}