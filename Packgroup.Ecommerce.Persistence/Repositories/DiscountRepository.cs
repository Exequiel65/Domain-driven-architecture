using Microsoft.EntityFrameworkCore;
using Packgroup.Ecommerce.Aplication.Interface.Persistence;
using Packgroup.Ecommerce.Domain.Entities;
using Packgroup.Ecommerce.Persistence.Contexts;
using static Dapper.SqlMapper;

namespace Packgroup.Ecommerce.Persistence.Repositories
{
    public class DiscountRepository : IDiscountRepository
    {
        protected readonly ApplicationDbContext _context;

        public DiscountRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        #region Metodos Sincronicos
        public int Count()
        {
            throw new NotImplementedException();
        }

        
        public bool Delete(string id)
        {
            throw new NotImplementedException();
        }


        public Discount Get(string id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Discount> GetAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Discount> GetAllWithPagination(int pageNumber, int pageSize)
        {
            throw new NotImplementedException();
        }

        public bool Update(Discount entity)
        {
            throw new NotImplementedException();
        }
        public bool Insert(Discount entity)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Metodos Asincronicos

        public async Task<bool> InsertAsync(Discount entity)
        {
            _context.Add(entity);
            return await Task.FromResult(true);
        }
        public async Task<bool> UpdateAsync(Discount discount)
        {
            var entity = await _context.Set<Discount>().AsNoTracking().SingleOrDefaultAsync(x => x.Id.Equals(discount.Id));
            if (entity == null) return await Task.FromResult(false);
            entity.Name = discount.Name;
            entity.Description = discount.Description;
            entity.Percent = discount.Percent;
            entity.Status = discount.Status;

            _context.Update(entity);
            return await Task.FromResult(true);
        }


        public async Task<bool> DeleteAsync(string id)
        {
            var entity = await _context.Set<Discount>().AsNoTracking().SingleOrDefaultAsync(x => x.Id.Equals(int.Parse(id)));
            if (entity == null) return await Task.FromResult(false);

            _context.Remove(entity);
            return await Task.FromResult(true);
        }

        public Task<IEnumerable<Discount>> GetAllWithPaginationAsync(int pageNumber, int pageSize)
        {
            throw new NotImplementedException();
        }
        public async Task<List<Discount>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await _context.Set<Discount>().AsNoTracking().AsNoTracking().ToListAsync(cancellationToken);
        }
        public async Task<Discount> GetAsync(int id, CancellationToken cancellationToken)
        {
            return await _context.Set<Discount>().AsNoTracking().SingleOrDefaultAsync(x => x.Id.Equals(id), cancellationToken);
        }

        public Task<int> CountAsync()
        {
            throw new NotImplementedException();
        }
        public Task<IEnumerable<Discount>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Discount> GetAsync(string id)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
