using ClosedXML.Excel;
using SpaceX.Models;
using SpaceX.Services.Contracts;
using System.Collections.Generic;
using System.IO;

namespace SpaceX.Services
{
    public class CreateExcelFileService : ICreateExcelFileService
    {
        #region Report to Excel Method

        public byte[] ReportToExcel(List<LaunchPlan> launchPlans)
        {
            using (var workbook = new XLWorkbook())
            {
                IXLWorksheet launchPlanSheet = workbook.Worksheets.Add("Launch Plan");
                IXLWorksheet rocketSheet = workbook.Worksheets.Add("Rocket");
                IXLWorksheet rocketFirstStageSheet = workbook.Worksheets.Add("Rocket First Stage");
                IXLWorksheet rocketSecondStageSheet = workbook.Worksheets.Add("Rocket Second Stage");

                this.RenderHeader(launchPlanSheet, rocketSheet, rocketFirstStageSheet, rocketSecondStageSheet);
                this.RenderBody(launchPlans, launchPlanSheet, rocketSheet, rocketFirstStageSheet, rocketSecondStageSheet);
                this.StyleAlignment(launchPlanSheet, rocketSheet, rocketFirstStageSheet, rocketSecondStageSheet);
                            
                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    var content = stream.ToArray();
                    return content;
                }
            }
        }

        #endregion

        #region Report to Excel Extension Methods

        #region Render Header Method

        private void RenderHeader(
           IXLWorksheet launchPlanSheet,
           IXLWorksheet rocketSheet,
           IXLWorksheet rocketFirstStageSheet,
           IXLWorksheet rocketSecondStageSheet)
        {
            #region Launch Plan Sheet Headers

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

            #endregion

            #region Rocket Sheet Headers

            rocketSheet.Cell(currentRow, 1).Value = "Mission Name";
            rocketSheet.Cell(currentRow, 2).Value = "Rocket Id";
            rocketSheet.Cell(currentRow, 3).Value = "Rocket Name";
            rocketSheet.Cell(currentRow, 4).Value = "Rocket Type";
            rocketSheet.Cell(currentRow, 5).Value = "Reused";
            rocketSheet.Cell(currentRow, 6).Value = "Recovery Attempt";
            rocketSheet.Cell(currentRow, 7).Value = "Recovered";
            rocketSheet.Cell(currentRow, 8).Value = "Ship";

            #endregion

            #region Rocket First Stage Sheet Headers

            rocketFirstStageSheet.Cell(currentRow, 1).Value = "Mission Name";
            rocketFirstStageSheet.Cell(currentRow, 2).Value = "Rocket Name";
            rocketFirstStageSheet.Cell(currentRow, 3).Value = "Core Serial";
            rocketFirstStageSheet.Cell(currentRow, 4).Value = "Flight";
            rocketFirstStageSheet.Cell(currentRow, 5).Value = "Block";
            rocketFirstStageSheet.Cell(currentRow, 6).Value = "Gridfins";
            rocketFirstStageSheet.Cell(currentRow, 7).Value = "Legs";
            rocketFirstStageSheet.Cell(currentRow, 8).Value = "Reused";
            rocketFirstStageSheet.Cell(currentRow, 9).Value = "Land Success";
            rocketFirstStageSheet.Cell(currentRow, 10).Value = "Landing Intent";
            rocketFirstStageSheet.Cell(currentRow, 11).Value = "Landing Type";
            rocketFirstStageSheet.Cell(currentRow, 12).Value = "Landing Vehicle";

            #endregion

            #region Rocket Second Stage Sheet Headers

            rocketSecondStageSheet.Cell(currentRow, 1).Value = "Mission Name";
            rocketSecondStageSheet.Cell(currentRow, 2).Value = "Rocket Name";
            rocketSecondStageSheet.Cell(currentRow, 3).Value = "Payload Id";
            rocketSecondStageSheet.Cell(currentRow, 4).Value = "Norad Id";
            rocketSecondStageSheet.Cell(currentRow, 5).Value = "Reused";
            rocketSecondStageSheet.Cell(currentRow, 6).Value = "Customers";
            rocketSecondStageSheet.Cell(currentRow, 7).Value = "Nationality";
            rocketSecondStageSheet.Cell(currentRow, 8).Value = "Manufacturer";
            rocketSecondStageSheet.Cell(currentRow, 9).Value = "PayloadType";
            rocketSecondStageSheet.Cell(currentRow, 10).Value = "Payload Mass Kg";
            rocketSecondStageSheet.Cell(currentRow, 11).Value = "Payload Mass Lbs";
            rocketSecondStageSheet.Cell(currentRow, 12).Value = "Orbit";
            rocketSecondStageSheet.Cell(currentRow, 13).Value = "Reference System";
            rocketSecondStageSheet.Cell(currentRow, 14).Value = "Regime";
            rocketSecondStageSheet.Cell(currentRow, 15).Value = "Longitude";
            rocketSecondStageSheet.Cell(currentRow, 16).Value = "Semi-Major Axis Km";
            rocketSecondStageSheet.Cell(currentRow, 17).Value = "Eccentricity";
            rocketSecondStageSheet.Cell(currentRow, 18).Value = "Periapsis Km";
            rocketSecondStageSheet.Cell(currentRow, 19).Value = "Apoapsis Km";
            rocketSecondStageSheet.Cell(currentRow, 20).Value = "Inclination Deg";
            rocketSecondStageSheet.Cell(currentRow, 21).Value = "Period Min";
            rocketSecondStageSheet.Cell(currentRow, 22).Value = "Lifespan Years";
            rocketSecondStageSheet.Cell(currentRow, 23).Value = "Epoch";
            rocketSecondStageSheet.Cell(currentRow, 24).Value = "Mean Motion";
            rocketSecondStageSheet.Cell(currentRow, 25).Value = "Raan";
            rocketSecondStageSheet.Cell(currentRow, 26).Value = "Arg Of Pericenter";
            rocketSecondStageSheet.Cell(currentRow, 27).Value = "Mean Anomaly";
            rocketSecondStageSheet.Cell(currentRow, 28).Value = "Block";

            #endregion
        }

        #endregion

        #region Render Body Method

        private void RenderBody(
            List<LaunchPlan> launchPlans,
            IXLWorksheet launchPlanSheet,
            IXLWorksheet rocketSheet,
            IXLWorksheet rocketFirstStageSheet,
            IXLWorksheet rocketSecondStageSheet)
        {
            #region Launch Plan Sheet Body

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

                rocketSheet.Cell(currentRow, 1).Value = launchPlanItem.MissionName;
                rocketSheet.Cell(currentRow, 2).Value = launchPlanItem.Rocket.RocketId;
                rocketSheet.Cell(currentRow, 3).Value = launchPlanItem.Rocket.RocketName;
                rocketSheet.Cell(currentRow, 4).Value = launchPlanItem.Rocket.RocketType;
                rocketSheet.Cell(currentRow, 5).Value = launchPlanItem.Rocket.Fairings?.Reused ?? null;
                rocketSheet.Cell(currentRow, 6).Value = launchPlanItem.Rocket.Fairings?.RecoveryAttempt ?? null;
                rocketSheet.Cell(currentRow, 7).Value = launchPlanItem.Rocket.Fairings?.Recovered ?? null;
                rocketSheet.Cell(currentRow, 8).Value = launchPlanItem.Rocket.Fairings?.Ship ?? null;

                #endregion

                #region Rocket First Stage Sheet Body

                foreach (var firstStage in launchPlanItem.Rocket.FirstStage.Cores)
                {
                    rocketFirstStageSheet.Cell(currentRow, 1).Value = launchPlanItem.MissionName;
                    rocketFirstStageSheet.Cell(currentRow, 2).Value = launchPlanItem.Rocket.RocketName;
                    rocketFirstStageSheet.Cell(currentRow, 3).Value = firstStage.CoreSerial;
                    rocketFirstStageSheet.Cell(currentRow, 4).Value = firstStage.Flight;
                    rocketFirstStageSheet.Cell(currentRow, 5).Value = firstStage.Block;
                    rocketFirstStageSheet.Cell(currentRow, 6).Value = firstStage.Gridfins;
                    rocketFirstStageSheet.Cell(currentRow, 7).Value = firstStage.Legs;
                    rocketFirstStageSheet.Cell(currentRow, 8).Value = firstStage.Reused;
                    rocketFirstStageSheet.Cell(currentRow, 9).Value = firstStage.LandSuccess;
                    rocketFirstStageSheet.Cell(currentRow, 10).Value = firstStage.LandingIntent;
                    rocketFirstStageSheet.Cell(currentRow, 11).Value = firstStage.LandingType;
                    rocketFirstStageSheet.Cell(currentRow, 12).Value = firstStage.LandingVehicle;
                }

                #endregion

                #region Rocket Second Stage Sheet Body

                foreach (var secondStage in launchPlanItem.Rocket.SecondStage.Payloads)
                {
                    rocketSecondStageSheet.Cell(currentRow, 1).Value = launchPlanItem.MissionName;
                    rocketSecondStageSheet.Cell(currentRow, 2).Value = launchPlanItem.Rocket.RocketName;
                    rocketSecondStageSheet.Cell(currentRow, 3).Value = secondStage.PayloadId;
                    rocketSecondStageSheet.Cell(currentRow, 4).Value = secondStage.NoradId;
                    rocketSecondStageSheet.Cell(currentRow, 5).Value = secondStage.Reused;
                    rocketSecondStageSheet.Cell(currentRow, 6).Value = secondStage.Customers;
                    rocketSecondStageSheet.Cell(currentRow, 7).Value = secondStage.Nationality;
                    rocketSecondStageSheet.Cell(currentRow, 8).Value = secondStage.Manufacturer;
                    rocketSecondStageSheet.Cell(currentRow, 9).Value = secondStage.PayloadType;
                    rocketSecondStageSheet.Cell(currentRow, 10).Value = secondStage.PayloadMassKg;
                    rocketSecondStageSheet.Cell(currentRow, 11).Value = secondStage.PayloadMassLbs;
                    rocketSecondStageSheet.Cell(currentRow, 12).Value = secondStage.Orbit;
                    rocketSecondStageSheet.Cell(currentRow, 13).Value = secondStage.OrbitParams.ReferenceSystem;
                    rocketSecondStageSheet.Cell(currentRow, 14).Value = secondStage.OrbitParams.Regime;
                    rocketSecondStageSheet.Cell(currentRow, 15).Value = secondStage.OrbitParams.Longitude;
                    rocketSecondStageSheet.Cell(currentRow, 16).Value = secondStage.OrbitParams.SemiMajorAxisKm;
                    rocketSecondStageSheet.Cell(currentRow, 17).Value = secondStage.OrbitParams.Eccentricity;
                    rocketSecondStageSheet.Cell(currentRow, 18).Value = secondStage.OrbitParams.PeriapsisKm;
                    rocketSecondStageSheet.Cell(currentRow, 19).Value = secondStage.OrbitParams.ApoapsisKm;
                    rocketSecondStageSheet.Cell(currentRow, 20).Value = secondStage.OrbitParams.InclinationDeg;
                    rocketSecondStageSheet.Cell(currentRow, 21).Value = secondStage.OrbitParams.PeriodMin;
                    rocketSecondStageSheet.Cell(currentRow, 22).Value = secondStage.OrbitParams.LifespanYears;
                    rocketSecondStageSheet.Cell(currentRow, 23).Value = secondStage.OrbitParams.Epoch;
                    rocketSecondStageSheet.Cell(currentRow, 24).Value = secondStage.OrbitParams.MeanMotion;
                    rocketSecondStageSheet.Cell(currentRow, 25).Value = secondStage.OrbitParams.Raan;
                    rocketSecondStageSheet.Cell(currentRow, 26).Value = secondStage.OrbitParams.ArgOfPericenter;
                    rocketSecondStageSheet.Cell(currentRow, 27).Value = secondStage.OrbitParams.MeanAnomaly;
                    rocketSecondStageSheet.Cell(currentRow, 28).Value = launchPlanItem.Rocket.SecondStage.Block;
                }

                #endregion
            }
        }

        #endregion

        #region StyleAlignment Method

        private void StyleAlignment(
           IXLWorksheet launchPlanSheet,
           IXLWorksheet rocketSheet,
           IXLWorksheet rocketFirstStageSheet,
           IXLWorksheet rocketSecondStageSheet)
        {
            launchPlanSheet.Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
            launchPlanSheet.Columns().AdjustToContents();
            launchPlanSheet.FirstRow().Style.Fill.BackgroundColor = XLColor.Orange;
            launchPlanSheet.FirstRow().Style.Font.Bold = true;
            launchPlanSheet.TabColor = XLColor.Orange;

            rocketSheet.Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
            rocketSheet.Columns().AdjustToContents();
            rocketSheet.FirstRow().Style.Fill.BackgroundColor = XLColor.BabyBlue;
            rocketSheet.FirstRow().Style.Font.Bold = true;
            rocketSheet.TabColor = XLColor.BabyBlue;

            rocketFirstStageSheet.Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
            rocketFirstStageSheet.Columns().AdjustToContents();
            rocketFirstStageSheet.FirstRow().Style.Fill.BackgroundColor = XLColor.AppleGreen;
            rocketFirstStageSheet.FirstRow().Style.Font.Bold = true;
            rocketFirstStageSheet.TabColor = XLColor.AppleGreen;

            rocketSecondStageSheet.Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
            rocketSecondStageSheet.Columns().AdjustToContents();
            rocketSecondStageSheet.FirstRow().Style.Fill.BackgroundColor = XLColor.BananaMania;
            rocketSecondStageSheet.FirstRow().Style.Font.Bold = true;
            rocketSecondStageSheet.TabColor = XLColor.BananaMania;
        }

        #endregion

        #endregion
    }
}