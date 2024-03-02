using Dapper;
using Packgroup.Ecommerce.Domain.Entity;
using Packgroup.Ecommerce.Persistence.Contexts;
using Packgroup.Ecommerce.Aplication.Interface.Persistence;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Packgroup.Ecommerce.Persistence.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly DapperContext _context;

        public CustomerRepository(DapperContext context)
        {
            _context = context;
        }

        #region Metodos Sincronicos

        public bool Insert(Customer customers)
        {
            using (var conection = _context.CreateConnection())
            {

                var query = "CustomersInsert";
                var parameters = new DynamicParameters();

                parameters.Add("CustomerId", customers.CustomerId);
                parameters.Add("CompanyName", customers.CompanyName);
                parameters.Add("ContactName", customers.ContactName);
                parameters.Add("ContactTitle", customers.ContactTitle);
                parameters.Add("Address", customers.Address);
                parameters.Add("City", customers.City);
                parameters.Add("Region", customers.Region);
                parameters.Add("PostalCode", customers.PostalCode);
                parameters.Add("Country", customers.Country);
                parameters.Add("Phone", customers.Phone);
                parameters.Add("Fax", customers.Fax);

                var result = conection.Execute(query, param: parameters, commandType: System.Data.CommandType.StoredProcedure);
                return result > 0;
            };
        }

        public bool Update(Customer customers)
        {
            using (var conection = _context.CreateConnection())
            {

                var query = "CustomersUpdate";
                var parameters = new DynamicParameters();

                parameters.Add("CustomerId", customers.CustomerId);
                parameters.Add("CompanyName", customers.CompanyName);
                parameters.Add("ContactName", customers.ContactName);
                parameters.Add("ContactTitle", customers.ContactTitle);
                parameters.Add("Address", customers.Address);
                parameters.Add("City", customers.City);
                parameters.Add("Region", customers.Region);
                parameters.Add("PostalCode", customers.PostalCode);
                parameters.Add("Country", customers.Country);
                parameters.Add("Phone", customers.Phone);
                parameters.Add("Fax", customers.Fax);

                var result = conection.Execute(query, param: parameters, commandType: System.Data.CommandType.StoredProcedure);
                return result > 0;
            };
        }

        public bool Delete(string customersId)
        {
            using (var conection = _context.CreateConnection())
            {

                var query = "CustomersDelete";
                var parameters = new DynamicParameters();

                parameters.Add("CustomerId", customersId);

                var result = conection.Execute(query, param: parameters, commandType: System.Data.CommandType.StoredProcedure);
                return result > 0;
            };
        }

        public Customer Get(string customersId)
        {
            using (var conection = _context.CreateConnection())
            {

                var query = "CustomersGetById";
                var parameters = new DynamicParameters();

                parameters.Add("CustomerId", customersId);

                var customer = conection.QuerySingle<Customer>(query, param: parameters, commandType: System.Data.CommandType.StoredProcedure);
                return customer;
            };
        }

        public IEnumerable<Customer> GetAll()
        {
            using (var conection = _context.CreateConnection())
            {

                var query = "CustomersList";
                var parameters = new DynamicParameters();

                var customers = conection.Query<Customer>(query, commandType: System.Data.CommandType.StoredProcedure);
                return customers;
            };
        }

        public IEnumerable<Customer> GetAllWithPagination(int pageNumber, int pageSize)
        {
            using var conection = _context.CreateConnection();
            var query = "CustomersListWithPagination";
            var parameters = new DynamicParameters();
            parameters.Add("PageNumber", pageNumber);
            parameters.Add("PageSize", pageSize);

            var customers = conection.Query<Customer>(query, parameters, commandType: System.Data.CommandType.StoredProcedure);
            return customers;


        }
        public int Count()
        {
            using var connection = _context.CreateConnection();
            var query = "Select Count(*) from Customers";
            var count = connection.ExecuteScalar<int>(query, commandType: System.Data.CommandType.Text);
            return count;
        }
        #endregion

        #region Metodos Asincronicos

        public async Task<bool> InsertAsync(Customer customers)
        {
            using (var conection = _context.CreateConnection())
            {

                var query = "CustomersInsert";
                var parameters = new DynamicParameters();

                parameters.Add("CustomerId", customers.CustomerId);
                parameters.Add("CompanyName", customers.CompanyName);
                parameters.Add("ContactName", customers.ContactName);
                parameters.Add("ContactTitle", customers.ContactTitle);
                parameters.Add("Address", customers.Address);
                parameters.Add("City", customers.City);
                parameters.Add("Region", customers.Region);
                parameters.Add("PostalCode", customers.PostalCode);
                parameters.Add("Country", customers.Country);
                parameters.Add("Phone", customers.Phone);
                parameters.Add("Fax", customers.Fax);

                var result = await conection.ExecuteAsync(query, param: parameters, commandType: System.Data.CommandType.StoredProcedure);
                return result > 0;
            };
        }

        public async Task<bool> UpdateAsync(Customer customers)
        {
            using (var conection = _context.CreateConnection())
            {

                var query = "CustomersUpdate";
                var parameters = new DynamicParameters();

                parameters.Add("CustomerId", customers.CustomerId);
                parameters.Add("CompanyName", customers.CompanyName);
                parameters.Add("ContactName", customers.ContactName);
                parameters.Add("ContactTitle", customers.ContactTitle);
                parameters.Add("Address", customers.Address);
                parameters.Add("City", customers.City);
                parameters.Add("Region", customers.Region);
                parameters.Add("PostalCode", customers.PostalCode);
                parameters.Add("Country", customers.Country);
                parameters.Add("Phone", customers.Phone);
                parameters.Add("Fax", customers.Fax);

                var result = await conection.ExecuteAsync(query, param: parameters, commandType: System.Data.CommandType.StoredProcedure);
                return result > 0;
            };
        }

        public async Task<bool> DeleteAsync(string customersId)
        {
            using (var conection = _context.CreateConnection())
            {

                var query = "CustomersDelete";
                var parameters = new DynamicParameters();

                parameters.Add("CustomerId", customersId);

                var result = await conection.ExecuteAsync(query, param: parameters, commandType: System.Data.CommandType.StoredProcedure);
                return result > 0;
            };
        }

        public async Task<Customer> GetAsync(string customersId)
        {
            using (var conection = _context.CreateConnection())
            {

                var query = "CustomersGetById";
                var parameters = new DynamicParameters();

                parameters.Add("CustomerId", customersId);

                var customer = await conection.QuerySingleAsync<Customer>(query, param: parameters, commandType: System.Data.CommandType.StoredProcedure);
                return customer;
            };
        }

        public async Task<IEnumerable<Customer>> GetAllAsync()
        {
            using (var conection = _context.CreateConnection())
            {

                var query = "CustomersList";
                var parameters = new DynamicParameters();

                var customers = await conection.QueryAsync<Customer>(query, commandType: System.Data.CommandType.StoredProcedure);
                return customers;
            };
        }

        public async Task<IEnumerable<Customer>> GetAllWithPaginationAsync(int pageNumber, int pageSize)
        {
            using var conection = _context.CreateConnection();
            var query = "CustomersListWithPagination";
            var parameters = new DynamicParameters();
            parameters.Add("PageNumber", pageNumber);
            parameters.Add("PageSize", pageSize);

            var customers = await conection.QueryAsync<Customer>(query, parameters, commandType: System.Data.CommandType.StoredProcedure);
            return customers;

        }

        public Task<int> CountAsync()
        {
            using var connection = _context.CreateConnection();
            var query = "Select Count(*) from Customers";
            var count = connection.ExecuteScalarAsync<int>(query, commandType: System.Data.CommandType.Text);
            return count;
        }

        #endregion
    }
}
