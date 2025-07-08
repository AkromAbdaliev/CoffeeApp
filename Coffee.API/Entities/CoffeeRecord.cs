namespace Coffee.API.Entities
{
    public class CoffeeRecord
    {
        public int Id { get; set; }
        public string Type { get; set; } = null!;
        public string? Bean { get; set; }
        public string Location { get; set; } = null!;
        public DateTime DateCreated { get; set; }
        public int NoOfShots { get; set; }
        public int? Score { get; set; }
        public decimal Price { get; set; }
    }
}
