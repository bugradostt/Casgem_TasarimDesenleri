using Casgem_CQRS.CQRSPattern.Results;
using Casgem_CQRS.Dal;
using System.Collections.Generic;
using System.Linq;

namespace Casgem_CQRS.CQRSPattern.Handlers
{
    public class GetProductQueryHandler
    {
        readonly Context _context;

        public GetProductQueryHandler(Context context)
        {
            _context = context;
        }

        public List<GetProductQueryResult> Handle()
        {
            var values = _context.Products.Select(x => new GetProductQueryResult
            {
                Brand = x.Brand,
                Category = x.Category,
                Name = x.Name,
                Price = x.Price,
                ProductId = x.ProductId,
                Stock = x.Stock

            }).ToList();
            return values;
        }
    }
}
