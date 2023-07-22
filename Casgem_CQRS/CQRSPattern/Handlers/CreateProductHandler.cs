using Casgem_CQRS.CQRSPattern.Commands;
using Casgem_CQRS.Dal;

namespace Casgem_CQRS.CQRSPattern.Handlers
{
    public class CreateProductHandler
    {
        readonly Context _context;

        public CreateProductHandler(Context context)
        {
            _context = context;
        }

        public void Handle(CreateProductCommand  command)
        {
            _context.Products.Add(new Product
            {
                Brand = command.Brand,
                Category = command.Category,
                Name = command.Name,
                Price = command.Price,
                Stock = command.Stock
            });
            _context.SaveChanges();
        }
    }
}
