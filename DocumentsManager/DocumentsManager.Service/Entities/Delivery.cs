namespace DocumentsManager.Service.Entities{
    public class Delivery : Document
    {
        public override int id { get; set; }
        public override float value { get; set; }
        public override string reference { get; set; }
        public override Customer customer { get; set; }
    }
}