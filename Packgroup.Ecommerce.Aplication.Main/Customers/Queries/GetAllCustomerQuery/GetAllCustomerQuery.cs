using MediatR;
using Packgroup.Ecommerce.Aplication.DTO;
using Packgroup.Ecommerce.Transversal.Common;

namespace Packgroup.Ecommerce.Aplication.UseCases.Customers.Queries.GetAllCustomerQuery
{
    public sealed record class GetAllCustomerQuery : IRequest<Response<IEnumerable<CustomerDTO>>>
    {
    }
}
