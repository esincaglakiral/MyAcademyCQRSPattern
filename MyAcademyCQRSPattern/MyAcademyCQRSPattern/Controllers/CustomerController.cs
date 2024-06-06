using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MyAcademyCQRSPattern.CQRSPattern.Commands;
using MyAcademyCQRSPattern.CQRSPattern.Handlers;
using MyAcademyCQRSPattern.CQRSPattern.Queries;

namespace MyAcademyCQRSPattern.Controllers
{
    public class CustomerController : Controller
    {
        private readonly CreateCustomerCommandHandler _createCustomerCommandHandler;
        private readonly GetCustomerQueryHandler _getCustomerQueryHandler;
        private readonly GetCustomerByIdQueryHandler _getCustomerByIdQueryHandler;
        private readonly UpdateCustomerCommandHandler _updateCustomerCommandHandler;
        private readonly RemoveCustomerCommandHandler _removeCustomerCommandHandler;
        private readonly IMapper _mapper;
        public CustomerController(CreateCustomerCommandHandler createCustomerCommandHandler, GetCustomerQueryHandler getCustomerQueryHandler, GetCustomerByIdQueryHandler getCustomerByIdQueryHandler, UpdateCustomerCommandHandler updateCustomerCommandHandler, RemoveCustomerCommandHandler removeCustomerCommandHandler, IMapper mapper)
        {
            _createCustomerCommandHandler = createCustomerCommandHandler;
            _getCustomerQueryHandler = getCustomerQueryHandler;
            _getCustomerByIdQueryHandler = getCustomerByIdQueryHandler;
            _updateCustomerCommandHandler = updateCustomerCommandHandler;
            _removeCustomerCommandHandler = removeCustomerCommandHandler;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            var values = _getCustomerQueryHandler.Handle();
            return View(values);
        }

        public IActionResult DeleteCustomer(int id)
        {
            _removeCustomerCommandHandler.Handle(new RemoveCustomerCommand(id));
            return RedirectToAction("Index");           
        }

        [HttpGet]
        public IActionResult CreateCustomer()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateCustomer(CreateCustomerCommand command)
        {
            _createCustomerCommandHandler.Handle(command);
            return RedirectToAction("Index");
        }



        [HttpGet]
        public IActionResult UpdateCustomer(int id)
        {
           var customer = _getCustomerByIdQueryHandler.Handle(new GetCustomerByIdQuery(id));
            var updateCustomer = _mapper.Map<UpdateCustomerCommand>(customer);
            return View(updateCustomer);
        }


        [HttpPost]
        public IActionResult UpdateCustomer(UpdateCustomerCommand command)
        {
            _updateCustomerCommandHandler.Handle(command);
            return RedirectToAction("Index");
        }



    }
}
