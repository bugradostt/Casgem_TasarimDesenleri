using Casgem_CQRS.CQRSPattern.Queries;
using Casgem_CQRS.CQRSPattern.Results;
using Casgem_CQRS.Dal;

namespace Casgem_CQRS.CQRSPattern.Handlers
{
    public class GetProductIdQueryHandler
    {
        readonly Context _context;

        public GetProductIdQueryHandler(Context context)
        {
            _context = context;
        }

        public GetProductByIdQueryResult Handle(GetProductIdQuery query)
        {
            var values = _context.Products.Find(query.Id);
            return new GetProductByIdQueryResult
            {
                ProductId = values.ProductId,
                Name= values.Name,  
                Brand = values.Brand

            };
        }
    }
}
