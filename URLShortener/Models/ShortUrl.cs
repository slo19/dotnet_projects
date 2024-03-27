namespace URLShortener.Models
{
    public class ShortUrl
    {
        public Guid Id { get; set; }
        public string Original { get; set; } = "";
        public string Short { get; set; } = "";
        public DateTime Duration { get; set; } = DateTime.Now;
    }
}
