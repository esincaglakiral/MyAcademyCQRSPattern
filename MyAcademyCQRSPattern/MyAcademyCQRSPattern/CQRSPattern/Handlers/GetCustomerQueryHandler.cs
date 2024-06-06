using AutoMapper;
using MyAcademyCQRSPattern.CQRSPattern.Results;
using MyAcademyCQRSPattern.DataAccess.Context;

namespace MyAcademyCQRSPattern.CQRSPattern.Handlers
{
    public class GetCustomerQueryHandler
    {
        private readonly Context _context;
        private readonly IMapper _mapper;
        public GetCustomerQueryHandler(Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<GetCustomerQueryResult> Handle()
        {
            var values = _context.Customers.ToList();

            var mappedResult = _mapper.Map<List<GetCustomerQueryResult>>(values);

            return mappedResult;


            //return values.Select(x => new GetCustomerQueryResult   //eski yöntem
            //{
            //    City = x.City,
            //    Name = x.Name,
            //    Surname = x.Surname

            //}).ToList();
        }
    }
}
