using MediatR;
using Packgroup.Ecommerce.Aplication.DTO;
using Packgroup.Ecommerce.Transversal.Common;

namespace Packgroup.Ecommerce.Aplication.UseCases.Customers.Queries.GetAllWithPaginationQuery
{
    public sealed record class GetAllWithPaginationCustomerQuery : IRequest<ResponsePagination<IEnumerable<CustomerDTO>>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}
