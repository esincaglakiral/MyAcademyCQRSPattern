using AutoMapper;
using MyAcademyCQRSPattern.CQRSPattern.Queries;
using MyAcademyCQRSPattern.CQRSPattern.Results;
using MyAcademyCQRSPattern.DataAccess.Context;

namespace MyAcademyCQRSPattern.CQRSPattern.Handlers
{
    public class GetCustomerByIdQueryHandler
    {
        private readonly Context _context;
        private readonly IMapper _mapper;

        public GetCustomerByIdQueryHandler(IMapper mapper, Context context)
        {
            _mapper = mapper;
            _context = context;
        }

        public GetCustomerByIdQueryResult Handle(GetCustomerByIdQuery query)
        {
            var customer = _context.Customers.FirstOrDefault(x => x.CustomerID == query.Id);

            var mappedCustomer = _mapper.Map<GetCustomerByIdQueryResult>(customer);

            return mappedCustomer;
        }
    }
}
