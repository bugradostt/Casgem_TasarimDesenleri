using Casgem_CQRS.CQRSPattern.Queries;
using Casgem_CQRS.CQRSPattern.Results;
using Casgem_CQRS.Dal;

namespace Casgem_CQRS.CQRSPattern.Handlers
{
    public class GetProductUpdateByIdQueryHander
    {
        readonly Context _context;

        public GetProductUpdateByIdQueryHander(Context context)
        {
            _context = context;
        }

        public GetProductUpdateByIdQueryResult Handle(GetProductUpdateByIdQuery query)
        {
            var value = _context.Products.Find(query.Id);
            return new GetProductUpdateByIdQueryResult
            {
                Brand = value.Brand,
                Category = value.Category,
                Name = value.Name,
                Price = value.Price,
                ProductId = value.ProductId,
                Stock = value.Stock,
            };
        }
    }
}
