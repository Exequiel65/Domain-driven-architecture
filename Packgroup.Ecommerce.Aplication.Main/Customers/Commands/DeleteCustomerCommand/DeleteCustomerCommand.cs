using MediatR;
using Packgroup.Ecommerce.Transversal.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Packgroup.Ecommerce.Aplication.UseCases.Customers.Commands.DeleteCustomerCommand
{
    public sealed record class DeleteCustomerCommand : IRequest<Response<bool>>
    {
        public string CustomerId { get; set; }
    }
}
