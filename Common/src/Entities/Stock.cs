namespace Common.Entities{
    public class Stock{
        public Guid id { get; set; }

        public Product product { get; set; }
        public float quantity { get; set; }



    }
}