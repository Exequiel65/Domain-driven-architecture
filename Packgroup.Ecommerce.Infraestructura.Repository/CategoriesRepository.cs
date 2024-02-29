using Dapper;
using Packgroup.Ecommerce.Domain.Entity;
using Packgroup.Ecommerce.Infraestructura.Data;
using PackGroup.Ecommerce.Infrastructura.Interface;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace Packgroup.Ecommerce.Infraestructura.Repository
{
    public class CategoriesRepository : ICategoriesRepository
    {
        private readonly DapperContext _context;

        public CategoriesRepository(DapperContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Categories>> GetAllAsync()
        {
            using var connection = _context.CreateConnection();
            var query = "Select * From Categories";

            var categories = await connection.QueryAsync<Categories>(query, commandType: CommandType.Text);
            return categories;
        }
    }
}
