using Casgem_CQRS.CQRSPattern.Commands;
using Casgem_CQRS.CQRSPattern.Handlers;
using Casgem_CQRS.CQRSPattern.Queries;
using Casgem_CQRS.CQRSPattern.Results;
using Microsoft.AspNetCore.Mvc;

namespace Casgem_CQRS.Controllers
{
    public class DefaultController : Controller
    {
        readonly GetProductQueryHandler _getProductQueryHandler;
        readonly CreateProductHandler _createProductHandler;
        readonly RemoveProductCommandHandler _removeProductCommandHandler;
        readonly GetProductIdQueryHandler _getProductIdQueryHandler;
        readonly GetProductUpdateByIdQueryHander _getProductUpdateByIdQueryHander;
        readonly UpdateProductCommandHandler _updateProductCommandHandler;

        public DefaultController(GetProductQueryHandler getProductQueryHandler, CreateProductHandler createProductHandler, RemoveProductCommandHandler removeProductCommandHandler, GetProductIdQueryHandler getProductIdQueryHandler, GetProductUpdateByIdQueryHander getProductUpdateByIdQueryHander, UpdateProductCommandHandler updateProductCommandHandler)
        {
            _getProductQueryHandler = getProductQueryHandler;
            _createProductHandler = createProductHandler;
            _removeProductCommandHandler = removeProductCommandHandler;
            _getProductIdQueryHandler = getProductIdQueryHandler;
            _getProductUpdateByIdQueryHander = getProductUpdateByIdQueryHander;
            _updateProductCommandHandler = updateProductCommandHandler;
        }

        public IActionResult Index()
        {
            var values = _getProductQueryHandler.Handle();
            return View(values);
        }

        [HttpGet]
        public IActionResult AddProduct()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddProduct(CreateProductCommand p)
        {
            _createProductHandler.Handle(p);
            return RedirectToAction("Index");
        }


        public IActionResult DeleteProduct(RemoveProductCommand p)
        {
            _removeProductCommandHandler.Handle(p);
            return RedirectToAction("Index");
        }

        public IActionResult GetProduct(GetProductIdQuery p)
        {
            var values = _getProductIdQueryHandler.Handle(p);
            return View(values);
        }

        [HttpGet]
        public IActionResult EditProduct(int id)
        {
            var foundId = _getProductUpdateByIdQueryHander.Handle(new GetProductUpdateByIdQuery(id));
            return View(foundId);
        }

        [HttpPost]
        public IActionResult EditProduct(UpdateProductCommand p)
        {
             _updateProductCommandHandler.Handle(p);
            return RedirectToAction("Index");
        }
    }
}
