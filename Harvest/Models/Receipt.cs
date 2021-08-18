namespace Harvest.Models
{
    public class Receipt
    {
        public string Url { get; set; }
        public string FileName { get; set; }
        public int FileSize { get; set; }
        public string ContentType { get; set; }
    }
}