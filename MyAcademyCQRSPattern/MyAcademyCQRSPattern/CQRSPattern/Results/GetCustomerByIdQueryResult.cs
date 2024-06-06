namespace MyAcademyCQRSPattern.CQRSPattern.Results
{
    public class GetCustomerByIdQueryResult
    {
        public int CustomerID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string City { get; set; }
    }
}
