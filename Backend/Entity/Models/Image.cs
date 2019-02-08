namespace AppEntity.Models
{
    public class Image
    {
        public int Id { get; set; }

        public string ImageLink { get; set; }

        public ArticleImages ArticleImages { get; set; }
    }
}
