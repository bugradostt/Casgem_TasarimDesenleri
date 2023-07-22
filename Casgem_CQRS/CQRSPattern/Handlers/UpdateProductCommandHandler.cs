using Casgem_CQRS.CQRSPattern.Commands;
using Casgem_CQRS.CQRSPattern.Results;
using Casgem_CQRS.Dal;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Casgem_CQRS.CQRSPattern.Handlers
{
    public class UpdateProductCommandHandler
    {
        readonly Context _context;

        public UpdateProductCommandHandler(Context context) 
        {
            _context = context;
        }

        public void Handle(UpdateProductCommand p)
        {
            var value = _context.Products.Find(p.ProductId);
           
            value.Brand = p.Brand;
            value.Price = p.Price;
            value.Stock = p.Stock;
            value.Category = p.Category;
            value.Name = p.Name;
            _context.SaveChanges();
           
        }


    }
}
