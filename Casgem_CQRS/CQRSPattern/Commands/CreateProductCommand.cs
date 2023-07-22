namespace Casgem_CQRS.CQRSPattern.Commands
{
    public class CreateProductCommand
    {
        public string Name { get; set; }
        public string Price { get; set; }
        public string Brand { get; set; }
        public string Category { get; set; }
        public string Stock { get; set; }
    }
}
