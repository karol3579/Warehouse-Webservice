namespace DocumentsManager.Service.Entities{
    public abstract class Document{
        public abstract int id{get; set;}
        public abstract float value{get; set;}
        public abstract string reference{get; set;}
        public abstract Customer customer {get; set;}
    }
}