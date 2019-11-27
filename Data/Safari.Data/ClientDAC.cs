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
    public class ClientDAC : DataAccessComponent, IRepository<Client>
    {
        public Client Create(Client client)
        {
            const string SQL_STATEMENT = "INSERT INTO Cliente ([Apellido],[Nombre],[Email],[Telefono],[Url]," +
                "[FechaNacimiento],[Domicilio]) VALUES(@Apellido,@Nombre,@Email,@Telefono,@Url,@FechaNacimiento,@Domicilio); SELECT SCOPE_IDENTITY();";

            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@Apellido", DbType.AnsiString, client.LastName);
                db.AddInParameter(cmd, "@Nombre", DbType.AnsiString, client.Name);
                db.AddInParameter(cmd, "@Email", DbType.AnsiString, client.Email);
                db.AddInParameter(cmd, "@Telefono", DbType.AnsiString, client.Phone);
                db.AddInParameter(cmd, "@Url", DbType.AnsiString, client.URL);
                db.AddInParameter(cmd, "@FechaNacimiento", DbType.AnsiString, client.BirthDate);
                db.AddInParameter(cmd, "@Domicilio", DbType.AnsiString, client.Address);
                client.Id = Convert.ToInt32(db.ExecuteScalar(cmd));
            }
            return client;
        }

        public List<Client> Read()
        {
            const string SQL_STATEMENT = "SELECT [Id], [Nombre], [Apellido], [Telefono], [Email], [Url]," +
                " [FechaNacimiento], [Domicilio] FROM Cliente ";

            List<Client> result = new List<Client>();
            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                using (IDataReader dr = db.ExecuteReader(cmd))
                {
                    while (dr.Read())
                    {
                        Client client = LoadCliente(dr);
                        result.Add(client);
                    }
                }
            }
            return result;
        }

        public Client ReadBy(int id)
        {
            const string SQL_STATEMENT = "SELECT [Id], [Nombre], [Apellido], [Email], [Telefono], [Url]," +
                "[FechaNacimiento], [Domicilio] FROM Cliente WHERE [Id]=@Id ";
            Client client = null;

            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@Id", DbType.Int32, id);
                using (IDataReader dr = db.ExecuteReader(cmd))
                {
                    if (dr.Read())
                    {
                        client = LoadCliente(dr);
                    }
                }
            }
            return client;
        }

        public List<Client> ReadyByFilters(Dictionary<string, string> filters)
        {
            string SQL_STATEMENT = "SELECT [Id], [Nombre], [Apellido], [Email], [Telefono], [Url]," +
                "[FechaNacimiento], [Domicilio] FROM Cliente WHERE ";
            List<Client> clients = null;

            List<KeyValuePair<string, string>> values = filters.ToList();
            for (int i = 0; i < filters.Count; i++)
            {
                SQL_STATEMENT += values[i].Key + " = @" + values[i].Key;                

                if (i + 1 != filters.Count)
                    SQL_STATEMENT += " AND ";

            }

            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                for (int i = 0; i < filters.Count; i++)
                {
                    var isTypeInt = values[i].Value.GetType().Equals(typeof(int));
                    db.AddInParameter(cmd, "@" + values[i].Key, isTypeInt ? DbType.Int32 : DbType.AnsiString, values[i].Value);

                }

                using (IDataReader dr = db.ExecuteReader(cmd))
                {
                    if (dr.Read())
                    {
                        clients.Add(LoadCliente(dr));
                    }
                }
            }
            return clients;
        }

        public void Update(Client client)
        {
            const string SQL_STATEMENT = "UPDATE Cliente SET [Nombre]= @Nombre, [Apellido]=@Apellido, " +
                "[Email]= @Email, [Telefono]= @Telefono, [Url]= @Url, [FechaNacimiento]= @FechaNacimiento," +
                "[Domicilio]= @Domicilio WHERE [Id]= @Id ";

            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@Apellido", DbType.AnsiString, client.LastName);
                db.AddInParameter(cmd, "@Nombre", DbType.AnsiString, client.Name);
                db.AddInParameter(cmd, "@Email", DbType.AnsiString, client.Email);
                db.AddInParameter(cmd, "@Telefono", DbType.AnsiString, client.Phone);
                db.AddInParameter(cmd, "@Url", DbType.AnsiString, client.URL);
                db.AddInParameter(cmd, "@FechaNacimiento", DbType.AnsiString, client.BirthDate);
                db.AddInParameter(cmd, "@Domicilio", DbType.AnsiString, client.Address);
                db.AddInParameter(cmd, "@Id", DbType.Int32, client.Id);
                db.ExecuteNonQuery(cmd);
            }
        }

        public void Delete(int id)
        {
            const string SQL_STATEMENT = "DELETE Cliente WHERE [Id]= @Id ";
            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@Id", DbType.Int32, id);
                db.ExecuteNonQuery(cmd);
            }
        }

        private Client LoadCliente(IDataReader dr)
        {
            Client client = new Client();
            client.Id = GetDataValue<int>(dr, "Id");
            client.Name = GetDataValue<string>(dr, "Nombre");
            client.LastName = GetDataValue<string>(dr, "Apellido");
            client.Email = GetDataValue<string>(dr, "Email");
            client.Phone = GetDataValue<string>(dr, "Telefono");
            client.URL = GetDataValue<string>(dr, "Url");
            client.BirthDate = GetDataValue<DateTime>(dr, "FechaNacimiento");
            client.Address = GetDataValue<string>(dr, "Domicilio");
            return client;
        }
    }
}
