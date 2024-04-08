using MediatR;
using Packgroup.Ecommerce.Aplication.DTO;
using Packgroup.Ecommerce.Transversal.Common;

namespace Packgroup.Ecommerce.Aplication.UseCases.Customers.Queries.GetCustomerQuery
{
    public sealed record class GetCustomerQuery : IRequest<Response<CustomerDTO>>
    {
        public string CustomerId { get; set; }
    }
}
