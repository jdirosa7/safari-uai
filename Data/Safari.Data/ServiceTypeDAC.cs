using Microsoft.Practices.EnterpriseLibrary.Data;
using Safari.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Safari.Data
{
    public partial class ServiceTypeDAC : DataAccessComponent, IRepository<ServiceType>
    {
        public ServiceType Create(ServiceType entity)
        {
            const string SQL_STATEMENT = "INSERT INTO TipoServicio ([Nombre]) VALUES(@Nombre);" +
                " SELECT SCOPE_IDENTITY();";

            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@Nombre", DbType.AnsiString, entity.Name);
                entity.Id = Convert.ToInt32(db.ExecuteScalar(cmd));
            }
            return entity;
        }

        public void Delete(int id)
        {
            const string SQL_STATEMENT = "DELETE TipoServicio WHERE [Id]= @Id ";
            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@Id", DbType.Int32, id);
                db.ExecuteNonQuery(cmd);
            }
        }

        private ServiceType LoadServiceType(IDataReader dr)
        {
            ServiceType serviceType = new ServiceType();
            serviceType.Id = GetDataValue<int>(dr, "Id");
            serviceType.Name = GetDataValue<string>(dr, "Nombre");
            return serviceType;
        }

        public List<ServiceType> Read()
        {
            const string SQL_STATEMENT = "SELECT [Id], [Nombre] FROM TipoServicio ";

            List<ServiceType> result = new List<ServiceType>();
            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                using (IDataReader dr = db.ExecuteReader(cmd))
                {
                    while (dr.Read())
                    {
                        ServiceType serviceType = LoadServiceType(dr);
                        result.Add(serviceType);
                    }
                }
            }
            return result;
        }

        public ServiceType ReadBy(int id)
        {
            const string SQL_STATEMENT = "SELECT [Id], [Nombre] FROM TipoServicio WHERE [Id]=@Id ";
            ServiceType serviceType = null;

            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@Id", DbType.Int32, id);
                using (IDataReader dr = db.ExecuteReader(cmd))
                {
                    if (dr.Read())
                    {
                        serviceType = LoadServiceType(dr);
                    }
                }
            }
            return serviceType;
        }

        public void Update(ServiceType serviceType)
        {
            const string SQL_STATEMENT = "UPDATE TipoServicio SET [Nombre]= @Nombre WHERE [Id]= @Id ";

            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@Nombre", DbType.AnsiString, serviceType.Name);
                db.AddInParameter(cmd, "@Id", DbType.Int32, serviceType.Id);
                db.ExecuteNonQuery(cmd);
            }
        }

        public List<ServiceType> ReadyByFilters(Dictionary<string, string> filters)
        {
            throw new NotImplementedException();
        }
    }
}
