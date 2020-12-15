namespace SpaceX.Web.Models
{
    /// <summary>
    /// An error view model class
    /// </summary>
    public class ErrorViewModel
    {
        #region Properties

        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);

        #endregion
    }
}