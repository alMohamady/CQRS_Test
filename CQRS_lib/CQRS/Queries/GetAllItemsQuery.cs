using CQRS_lib.Data.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS_lib.CQRS.Queries
{
    public record GetAllItemsQuery : IRequest<List<Items>>; 
}
