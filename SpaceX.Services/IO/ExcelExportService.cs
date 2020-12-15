using ClosedXML.Excel;
using SpaceX.Services.DTO;
using SpaceX.Services.IO;
using System.Collections.Generic;
using System.IO;

namespace SpaceX.Services
{
    /// <summary>
    /// A service class which contains methods for populating data into an Excel file
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

            launchPlanSheet.Cell(currentRow, 1).Value = "Flight Number";
            launchPlanSheet.Cell(currentRow, 2).Value = "Mission Name";
            launchPlanSheet.Cell(currentRow, 3).Value = "Mission Id";
            launchPlanSheet.Cell(currentRow, 4).Value = "Upcoming";
            launchPlanSheet.Cell(currentRow, 5).Value = "Launch Year";
            launchPlanSheet.Cell(currentRow, 6).Value = "Launch Date Unix";
            launchPlanSheet.Cell(currentRow, 7).Value = "Launch Date Utc";
            launchPlanSheet.Cell(currentRow, 8).Value = "Launch Date Local";
            launchPlanSheet.Cell(currentRow, 9).Value = "Is Tentative";
            launchPlanSheet.Cell(currentRow, 10).Value = "Tentative Max Precision";
            launchPlanSheet.Cell(currentRow, 11).Value = "Tbd";
            launchPlanSheet.Cell(currentRow, 12).Value = "LaunchWindow";
            launchPlanSheet.Cell(currentRow, 13).Value = "Ships";
            launchPlanSheet.Cell(currentRow, 14).Value = "Flight Club";
            launchPlanSheet.Cell(currentRow, 15).Value = "Site Id";
            launchPlanSheet.Cell(currentRow, 16).Value = "Site Name";
            launchPlanSheet.Cell(currentRow, 17).Value = "Site Name Long";
            launchPlanSheet.Cell(currentRow, 18).Value = "Launch Success";
            launchPlanSheet.Cell(currentRow, 19).Value = "Fail Time";
            launchPlanSheet.Cell(currentRow, 20).Value = "Fail Altitude";
            launchPlanSheet.Cell(currentRow, 21).Value = "Fail Reason";
            launchPlanSheet.Cell(currentRow, 22).Value = "Mission Patch";
            launchPlanSheet.Cell(currentRow, 23).Value = "Mission Patch Small";
            launchPlanSheet.Cell(currentRow, 24).Value = "Reddit Campaign";
            launchPlanSheet.Cell(currentRow, 25).Value = "Reddit Launch";
            launchPlanSheet.Cell(currentRow, 26).Value = "Reddit Recovery";
            launchPlanSheet.Cell(currentRow, 27).Value = "Reddit Media";
            launchPlanSheet.Cell(currentRow, 28).Value = "Press Kit";
            launchPlanSheet.Cell(currentRow, 29).Value = "Article Link";
            launchPlanSheet.Cell(currentRow, 30).Value = "Wikipedia";
            launchPlanSheet.Cell(currentRow, 31).Value = "Video Link";
            launchPlanSheet.Cell(currentRow, 32).Value = "Youtube Id";
            launchPlanSheet.Cell(currentRow, 33).Value = "Flickr Images";
            launchPlanSheet.Cell(currentRow, 34).Value = "Details";
            launchPlanSheet.Cell(currentRow, 35).Value = "Static Fire Date";
            launchPlanSheet.Cell(currentRow, 36).Value = "Static Fire Date Unix";
            launchPlanSheet.Cell(currentRow, 37).Value = "Webcast Liftoff";

            launchPlanSheet.Cell(currentRow, 38).Value = "Rocket Id";
            launchPlanSheet.Cell(currentRow, 39).Value = "Rocket Name";
            launchPlanSheet.Cell(currentRow, 40).Value = "Rocket Type";
            launchPlanSheet.Cell(currentRow, 41).Value = "Reused";
            launchPlanSheet.Cell(currentRow, 42).Value = "Recovery Attempt";
            launchPlanSheet.Cell(currentRow, 43).Value = "Recovered";
            launchPlanSheet.Cell(currentRow, 44).Value = "Ship";

            launchPlanSheet.Cell(currentRow, 45).Value = "Core Serial";
            launchPlanSheet.Cell(currentRow, 46).Value = "Flight";
            launchPlanSheet.Cell(currentRow, 47).Value = "Block";
            launchPlanSheet.Cell(currentRow, 48).Value = "Gridfins";
            launchPlanSheet.Cell(currentRow, 49).Value = "Legs";
            launchPlanSheet.Cell(currentRow, 50).Value = "Reused";
            launchPlanSheet.Cell(currentRow, 51).Value = "Land Success";
            launchPlanSheet.Cell(currentRow, 52).Value = "Landing Intent";
            launchPlanSheet.Cell(currentRow, 53).Value = "Landing Type";
            launchPlanSheet.Cell(currentRow, 54).Value = "Landing Vehicle";

            launchPlanSheet.Cell(currentRow, 55).Value = "Payload Id";
            launchPlanSheet.Cell(currentRow, 56).Value = "Norad Id";
            launchPlanSheet.Cell(currentRow, 57).Value = "Reused";
            launchPlanSheet.Cell(currentRow, 58).Value = "Customers";
            launchPlanSheet.Cell(currentRow, 59).Value = "Nationality";
            launchPlanSheet.Cell(currentRow, 60).Value = "Manufacturer";
            launchPlanSheet.Cell(currentRow, 61).Value = "PayloadType";
            launchPlanSheet.Cell(currentRow, 62).Value = "Payload Mass Kg";
            launchPlanSheet.Cell(currentRow, 63).Value = "Payload Mass Lbs";
            launchPlanSheet.Cell(currentRow, 64).Value = "Orbit";
            launchPlanSheet.Cell(currentRow, 65).Value = "Reference System";
            launchPlanSheet.Cell(currentRow, 66).Value = "Regime";
            launchPlanSheet.Cell(currentRow, 67).Value = "Longitude";
            launchPlanSheet.Cell(currentRow, 68).Value = "Semi-Major Axis Km";
            launchPlanSheet.Cell(currentRow, 69).Value = "Eccentricity";
            launchPlanSheet.Cell(currentRow, 70).Value = "Periapsis Km";
            launchPlanSheet.Cell(currentRow, 71).Value = "Apoapsis Km";
            launchPlanSheet.Cell(currentRow, 72).Value = "Inclination Deg";
            launchPlanSheet.Cell(currentRow, 73).Value = "Period Min";
            launchPlanSheet.Cell(currentRow, 74).Value = "Lifespan Years";
            launchPlanSheet.Cell(currentRow, 75).Value = "Epoch";
            launchPlanSheet.Cell(currentRow, 76).Value = "Mean Motion";
            launchPlanSheet.Cell(currentRow, 77).Value = "Raan";
            launchPlanSheet.Cell(currentRow, 78).Value = "Arg Of Pericenter";
            launchPlanSheet.Cell(currentRow, 79).Value = "Mean Anomaly";
            launchPlanSheet.Cell(currentRow, 80).Value = "Block";
        }

        private void RenderBody(List<LaunchPlan> launchPlans, IXLWorksheet launchPlanSheet)
        {
            int currentRow = 1;

            foreach (var launchPlanItem in launchPlans)
            {
                currentRow++;

                launchPlanSheet.Cell(currentRow, 1).Value = launchPlanItem.FlightNumber;
                launchPlanSheet.Cell(currentRow, 2).Value = launchPlanItem.MissionName;
                launchPlanSheet.Cell(currentRow, 3).Value = launchPlanItem.MissionId;
                launchPlanSheet.Cell(currentRow, 4).Value = launchPlanItem.Upcoming;
                launchPlanSheet.Cell(currentRow, 5).Value = launchPlanItem.LaunchYear;
                launchPlanSheet.Cell(currentRow, 6).Value = launchPlanItem.LaunchDateUnix;
                launchPlanSheet.Cell(currentRow, 7).Value = launchPlanItem.LaunchDateUtc.UtcDateTime;
                launchPlanSheet.Cell(currentRow, 8).Value = launchPlanItem.LaunchDateLocal.LocalDateTime;
                launchPlanSheet.Cell(currentRow, 9).Value = launchPlanItem.IsTentative;
                launchPlanSheet.Cell(currentRow, 10).Value = launchPlanItem.TentativeMaxPrecision;
                launchPlanSheet.Cell(currentRow, 11).Value = launchPlanItem.Tbd;
                launchPlanSheet.Cell(currentRow, 12).Value = launchPlanItem.LaunchWindow;
                launchPlanSheet.Cell(currentRow, 13).Value = launchPlanItem.Ships;
                launchPlanSheet.Cell(currentRow, 14).Value = launchPlanItem.Telemetry.FlightClub;
                launchPlanSheet.Cell(currentRow, 15).Value = launchPlanItem.LaunchSite.SiteId;
                launchPlanSheet.Cell(currentRow, 16).Value = launchPlanItem.LaunchSite.SiteName;
                launchPlanSheet.Cell(currentRow, 17).Value = launchPlanItem.LaunchSite.SiteNameLong;
                launchPlanSheet.Cell(currentRow, 18).Value = launchPlanItem.LaunchSuccess;
                launchPlanSheet.Cell(currentRow, 19).Value = launchPlanItem.LaunchFailureDetails.Time;
                launchPlanSheet.Cell(currentRow, 20).Value = launchPlanItem.LaunchFailureDetails.Altitude;
                launchPlanSheet.Cell(currentRow, 21).Value = launchPlanItem.LaunchFailureDetails.Reason;
                launchPlanSheet.Cell(currentRow, 22).Value = launchPlanItem.Links.MissionPatch;
                launchPlanSheet.Cell(currentRow, 23).Value = launchPlanItem.Links.MissionPatchSmall;
                launchPlanSheet.Cell(currentRow, 24).Value = launchPlanItem.Links.RedditCampaign;
                launchPlanSheet.Cell(currentRow, 25).Value = launchPlanItem.Links.RedditLaunch;
                launchPlanSheet.Cell(currentRow, 26).Value = launchPlanItem.Links.RedditRecovery;
                launchPlanSheet.Cell(currentRow, 27).Value = launchPlanItem.Links.RedditMedia;
                launchPlanSheet.Cell(currentRow, 28).Value = launchPlanItem.Links.Presskit;
                launchPlanSheet.Cell(currentRow, 29).Value = launchPlanItem.Links.ArticleLink;
                launchPlanSheet.Cell(currentRow, 30).Value = launchPlanItem.Links.Wikipedia;
                launchPlanSheet.Cell(currentRow, 31).Value = launchPlanItem.Links.VideoLink;
                launchPlanSheet.Cell(currentRow, 32).Value = launchPlanItem.Links.YoutubeId;
                launchPlanSheet.Cell(currentRow, 33).Value = launchPlanItem.Links.FlickrImages;
                launchPlanSheet.Cell(currentRow, 34).Value = launchPlanItem.Details;
                launchPlanSheet.Cell(currentRow, 35).Value = launchPlanItem.StaticFireDateUtc;
                launchPlanSheet.Cell(currentRow, 36).Value = launchPlanItem.StaticFireDateUnix;
                launchPlanSheet.Cell(currentRow, 37).Value = launchPlanItem.Timeline?.WebcastLiftoff ?? null;

                launchPlanSheet.Cell(currentRow, 38).Value = launchPlanItem.Rocket.RocketId;
                launchPlanSheet.Cell(currentRow, 39).Value = launchPlanItem.Rocket.RocketName;
                launchPlanSheet.Cell(currentRow, 40).Value = launchPlanItem.Rocket.RocketType;
                launchPlanSheet.Cell(currentRow, 41).Value = launchPlanItem.Rocket.Fairings?.Reused ?? null;
                launchPlanSheet.Cell(currentRow, 42).Value = launchPlanItem.Rocket.Fairings?.RecoveryAttempt ?? null;
                launchPlanSheet.Cell(currentRow, 43).Value = launchPlanItem.Rocket.Fairings?.Recovered ?? null;
                launchPlanSheet.Cell(currentRow, 44).Value = launchPlanItem.Rocket.Fairings?.Ship ?? null;

                foreach (var firstStage in launchPlanItem.Rocket.FirstStage.Cores)
                {
                    launchPlanSheet.Cell(currentRow, 45).Value = firstStage.CoreSerial;
                    launchPlanSheet.Cell(currentRow, 46).Value = firstStage.Flight;
                    launchPlanSheet.Cell(currentRow, 47).Value = firstStage.Block;
                    launchPlanSheet.Cell(currentRow, 48).Value = firstStage.Gridfins;
                    launchPlanSheet.Cell(currentRow, 49).Value = firstStage.Legs;
                    launchPlanSheet.Cell(currentRow, 50).Value = firstStage.Reused;
                    launchPlanSheet.Cell(currentRow, 51).Value = firstStage.LandSuccess;
                    launchPlanSheet.Cell(currentRow, 52).Value = firstStage.LandingIntent;
                    launchPlanSheet.Cell(currentRow, 53).Value = firstStage.LandingType;
                    launchPlanSheet.Cell(currentRow, 54).Value = firstStage.LandingVehicle;
                }

                foreach (var secondStage in launchPlanItem.Rocket.SecondStage.Payloads)
                {
                    launchPlanSheet.Cell(currentRow, 55).Value = secondStage.PayloadId;
                    launchPlanSheet.Cell(currentRow, 56).Value = secondStage.NoradId;
                    launchPlanSheet.Cell(currentRow, 57).Value = secondStage.Reused;
                    launchPlanSheet.Cell(currentRow, 58).Value = secondStage.Customers;
                    launchPlanSheet.Cell(currentRow, 59).Value = secondStage.Nationality;
                    launchPlanSheet.Cell(currentRow, 60).Value = secondStage.Manufacturer;
                    launchPlanSheet.Cell(currentRow, 61).Value = secondStage.PayloadType;
                    launchPlanSheet.Cell(currentRow, 62).Value = secondStage.PayloadMassKg;
                    launchPlanSheet.Cell(currentRow, 63).Value = secondStage.PayloadMassLbs;
                    launchPlanSheet.Cell(currentRow, 64).Value = secondStage.Orbit;
                    launchPlanSheet.Cell(currentRow, 65).Value = secondStage.OrbitParams.ReferenceSystem;
                    launchPlanSheet.Cell(currentRow, 66).Value = secondStage.OrbitParams.Regime;
                    launchPlanSheet.Cell(currentRow, 67).Value = secondStage.OrbitParams.Longitude;
                    launchPlanSheet.Cell(currentRow, 68).Value = secondStage.OrbitParams.SemiMajorAxisKm;
                    launchPlanSheet.Cell(currentRow, 69).Value = secondStage.OrbitParams.Eccentricity;
                    launchPlanSheet.Cell(currentRow, 70).Value = secondStage.OrbitParams.PeriapsisKm;
                    launchPlanSheet.Cell(currentRow, 71).Value = secondStage.OrbitParams.ApoapsisKm;
                    launchPlanSheet.Cell(currentRow, 72).Value = secondStage.OrbitParams.InclinationDeg;
                    launchPlanSheet.Cell(currentRow, 73).Value = secondStage.OrbitParams.PeriodMin;
                    launchPlanSheet.Cell(currentRow, 74).Value = secondStage.OrbitParams.LifespanYears;
                    launchPlanSheet.Cell(currentRow, 75).Value = secondStage.OrbitParams.Epoch;
                    launchPlanSheet.Cell(currentRow, 76).Value = secondStage.OrbitParams.MeanMotion;
                    launchPlanSheet.Cell(currentRow, 77).Value = secondStage.OrbitParams.Raan;
                    launchPlanSheet.Cell(currentRow, 78).Value = secondStage.OrbitParams.ArgOfPericenter;
                    launchPlanSheet.Cell(currentRow, 79).Value = secondStage.OrbitParams.MeanAnomaly;
                    launchPlanSheet.Cell(currentRow, 80).Value = launchPlanItem.Rocket.SecondStage.Block;
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