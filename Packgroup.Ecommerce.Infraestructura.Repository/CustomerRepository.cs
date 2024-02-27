using Dapper;
using Packgroup.Ecommerce.Domain.Entity;
using Packgroup.Ecommerce.Infraestructura.Data;
using PackGroup.Ecommerce.Infrastructura.Interface;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Packgroup.Ecommerce.Infraestructura.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly DapperContext _context;

        public CustomerRepository(DapperContext context)
        {
            _context = context;
        }

        #region Metodos Sincronicos

        public bool Insert(Customers customers)
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

        public bool Update(Customers customers)
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

        public Customers Get(string customersId)
        {
            using (var conection = _context.CreateConnection())
            {

                var query = "CustomersGetById";
                var parameters = new DynamicParameters();

                parameters.Add("CustomerId", customersId);

                var customer = conection.QuerySingle<Customers>(query, param: parameters, commandType: System.Data.CommandType.StoredProcedure);
                return customer;
            };
        }

        public IEnumerable<Customers> GetAll()
        {
            using (var conection = _context.CreateConnection())
            {

                var query = "CustomersList";
                var parameters = new DynamicParameters();

                var customers = conection.Query<Customers>(query, commandType: System.Data.CommandType.StoredProcedure);
                return customers;
            };
        }

        #endregion

        #region Metodos Asincronicos

        public async Task<bool> InsertAsync(Customers customers)
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

        public async Task<bool> UpdateAsync(Customers customers)
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

        public async Task<Customers> GetAsync(string customersId)
        {
            using (var conection = _context.CreateConnection())
            {

                var query = "CustomersGetById";
                var parameters = new DynamicParameters();

                parameters.Add("CustomerId", customersId);

                var customer = await conection.QuerySingleAsync<Customers>(query, param: parameters, commandType: System.Data.CommandType.StoredProcedure);
                return customer;
            };
        }

        public async Task<IEnumerable<Customers>> GetAllAsync()
        {
            using (var conection = _context.CreateConnection())
            {

                var query = "CustomersList";
                var parameters = new DynamicParameters();

                var customers = await conection.QueryAsync<Customers>(query, commandType: System.Data.CommandType.StoredProcedure);
                return customers;
            };
        }

        #endregion
    }
}
