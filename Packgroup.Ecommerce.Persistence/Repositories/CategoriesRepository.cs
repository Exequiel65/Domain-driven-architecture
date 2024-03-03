using Dapper;
using Packgroup.Ecommerce.Persistence.Contexts;
using Packgroup.Ecommerce.Aplication.Interface.Persistence;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Packgroup.Ecommerce.Domain.Entities;

namespace Packgroup.Ecommerce.Persistence.Repositories
{
    public class CategoriesRepository : ICategoriesRepository
    {
        private readonly DapperContext _context;

        public CategoriesRepository(DapperContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Categorie>> GetAllAsync()
        {
            using var connection = _context.CreateConnection();
            var query = "Select * From Categories";

            var categories = await connection.QueryAsync<Categorie>(query, commandType: CommandType.Text);
            return categories;
        }
    }
}
