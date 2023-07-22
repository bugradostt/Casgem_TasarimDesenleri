using Casgem_CQRS.CQRSPattern.Commands;
using Casgem_CQRS.Dal;

namespace Casgem_CQRS.CQRSPattern.Handlers
{
    public class RemoveProductCommandHandler
    {
        readonly Context _context;

        public RemoveProductCommandHandler(Context context)
        {
            _context = context;
        }

        public void Handle(RemoveProductCommand command) 
        {
            var foundId = _context.Products.Find(command.Id);
            _context.Products.Remove(foundId);  
            _context.SaveChanges();
             
        }
    }
}
