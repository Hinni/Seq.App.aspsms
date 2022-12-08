namespace Seq.App.aspsms.Models
{
    /// <summary>
    /// Needed JSON object to receive status results
    /// </summary>
    public class Result
    {
        public string StatusCode { get; set; }
        public string StatusInfo { get; set; }
        public decimal? Credits { get; set; }
    }
}
