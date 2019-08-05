using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using Dapper;

namespace DapperGenericRepository.Repositories
{
    public abstract class BaseRepository<T>
    {
        protected string connectionString = @"<your Database Connection String>";

        public virtual void Insert(T entity)
        {
            var columns = GetColumns();
            var stringOfColumns = string.Join(", ", columns);
            var stringOfParameters = string.Join(", ", columns.Select(e => "@" + e));
            var query = $"insert into {typeof(T).Name}s ({stringOfColumns}) values ({stringOfParameters})";

            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                conn.Execute(query, entity);
            }
        }

        public virtual void Delete(T entity)
        {
            var query = $"delete from {typeof(T).Name}s where Id = @Id";

            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                conn.Execute(query, entity);
            }
        }

        public virtual void Update(T entity)
        {
            var columns = GetColumns();
            var stringOfColumns = string.Join(", ", columns.Select(e => $"{e} = @{e}"));
            var query = $"update {typeof(T).Name}s set {stringOfColumns} where Id = @Id";

            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                conn.Execute(query, entity);
            }
        }

        public virtual IEnumerable<T> Query(string where = null)
        {
            var query = $"select * from {typeof(T).Name}s ";

            if (!string.IsNullOrWhiteSpace(where))
                query += where;

            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                return conn.Query<T>(query);
            }
        }

        private IEnumerable<string> GetColumns()
        {
            return typeof(T)
                    .GetProperties()
                    .Where(e => e.Name != "Id" && !e.PropertyType.GetTypeInfo().IsGenericType)
                    .Select(e => e.Name);
        }
    }
}
