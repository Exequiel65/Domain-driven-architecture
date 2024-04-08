using MediatR;
using Packgroup.Ecommerce.Transversal.Common;
namespace Packgroup.Ecommerce.Aplication.UseCases.Customers.Commands.UpdateCustomerCommand
{
    public sealed record class UpdateCustomerCommand: IRequest<Response<bool>>
    {
        public string CustomerId { get; set; }
        public string CompanyName { get; set; }
        public string ContactName { get; set; }
        public string ContactTitle { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
    }
}
