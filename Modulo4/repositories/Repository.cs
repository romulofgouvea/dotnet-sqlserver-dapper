using System.Collections.Generic;
using System.Data.SqlClient;
using Dapper.Contrib.Extensions;
using Modulo4.Models;

namespace Modulo4.Repositories
{
    public class Repository<TModel> where TModel : BaseModel
    {
        private readonly SqlConnection _connection;

        public Repository(SqlConnection connection)
        {
            _connection = connection;
        }

        public TModel Get(int id) => _connection.Get<TModel>(id);
        public virtual IEnumerable<TModel> GetAll() => _connection.GetAll<TModel>();
        public void Create(TModel tModel)
        {
            tModel.Id = 0;
            _connection.Insert(tModel);
        }
        public void Update(TModel tModel)
        {
            if (tModel.Id != 0)
                _connection.Update(tModel);
        }
        public void Delete(TModel tModel)
        {
            if (tModel.Id != 0)
                _connection.Delete(tModel);
        }
        public void Delete(int id)
        {
            if (id == 0)
            {
                return;
            }
            var tModel = _connection.Get<TModel>(id);
            _connection.Delete(tModel);
        }

    }
}