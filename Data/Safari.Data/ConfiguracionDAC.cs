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
    public class ConfiguracionDAC : DataAccessComponent
    {
        public Configuration ReadBy(string name)
        {
            const string SQL_STATEMENT = "SELECT [Id], [Nombre], [Valor] FROM Configuracion WHERE [Nombre]=@Nombre ";
            Configuration config = null;

            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@Nombre", DbType.Int32, name);
                using (IDataReader dr = db.ExecuteReader(cmd))
                {
                    if (dr.Read())
                    {
                        config = LoadConfiguration(dr);
                    }
                }
            }
            return config;
        }

        private Configuration LoadConfiguration(IDataReader dr)
        {
            Configuration config = new Configuration
            {
                Id = GetDataValue<int>(dr, "Id"),
                Name = GetDataValue<string>(dr, "Nombre"),
                Value = GetDataValue<string>(dr, "Valor")
            };
            return config;
        }
    }
}
