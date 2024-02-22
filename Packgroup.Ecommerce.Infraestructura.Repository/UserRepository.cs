using Dapper;
using Packgroup.Ecommerce.Domain.Entity;
using Packgroup.Ecommerce.Transversal.Common;
using PackGroup.Ecommerce.Infrastructura.Interface;
using System.Data;

namespace Packgroup.Ecommerce.Infraestructura.Repository
{
    public class UserRepository: IUsers
    {
        private readonly IConectionFactory _conectionFactory;

        public UserRepository(IConectionFactory conection)
        {
            _conectionFactory = conection;
        }
        public Users Authenticate(string username, string password)
        {
            using (var connection = _conectionFactory.GetConnection)
            {
                var query = "UsersGetByUserAndPassword";
                var parameters = new DynamicParameters();
                parameters.Add("Username", username);
                parameters.Add("Password", password);

                var user = connection.QuerySingle<Users>(query, param: parameters, commandType: CommandType.StoredProcedure);
                return user;

            }
        }
    }
}
