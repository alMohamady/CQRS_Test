using CQRS_lib.CQRS.Queries;
using CQRS_lib.Data;
using CQRS_lib.Data.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS_lib.CQRS.Handelers
{
    public class GetItemsListHandler : IRequestHandler<GetAllItemsQuery, List<Items>>
    {
        AppDbContext _db;

        public GetItemsListHandler(AppDbContext db)
        {
            _db = db;
        }

        public async Task<List<Items>> Handle(GetAllItemsQuery request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(_db.Items.ToList());
        }
    }
}
