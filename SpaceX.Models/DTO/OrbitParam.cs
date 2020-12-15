using Newtonsoft.Json;

namespace SpaceX.Models
{
    /// <summary>
    /// A dto class which contains properties of the orbit parameters
    /// </summary>
    public class OrbitParam
    {
        #region Properties

        [JsonProperty("reference_system")]
        public string ReferenceSystem { get; set; }

        [JsonProperty("regime")]
        public string Regime { get; set; }

        [JsonProperty("longitude")]
        public object Longitude { get; set; }

        [JsonProperty("semi_major_axis_km")]
        public object SemiMajorAxisKm { get; set; }

        [JsonProperty("eccentricity")]
        public object Eccentricity { get; set; }

        [JsonProperty("periapsis_km")]
        public string PeriapsisKm { get; set; }

        [JsonProperty("apoapsis_km")]
        public string ApoapsisKm { get; set; }

        [JsonProperty("inclination_deg")]
        public string InclinationDeg { get; set; }

        [JsonProperty("period_min")]
        public object PeriodMin { get; set; }

        [JsonProperty("lifespan_years")]
        public object LifespanYears { get; set; }

        [JsonProperty("epoch")]
        public object Epoch { get; set; }

        [JsonProperty("mean_motion")]
        public object MeanMotion { get; set; }

        [JsonProperty("raan")]
        public object Raan { get; set; }

        [JsonProperty("arg_of_pericenter")]
        public object ArgOfPericenter { get; set; }

        [JsonProperty("mean_anomaly")]
        public object MeanAnomaly { get; set; }

        #endregion
    }
}