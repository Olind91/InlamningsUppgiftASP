namespace OskarLAspNet.Models.Interfaces
{
    public interface IProduct
    {
        public string ArticleNumber { get; set; }
        public string ProductName { get; set; }
        public string? ProductDescription { get; set; }

        public decimal? Price { get; set; }


        public int ProductCategoryId { get; set; }
    }
}
