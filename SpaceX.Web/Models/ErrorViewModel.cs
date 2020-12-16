namespace SpaceX.Web.Models
{
    /// <summary>
    /// The class handles the errors
    /// </summary>
    public class ErrorViewModel
    {
        #region Properties

        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);

        #endregion
    }
}