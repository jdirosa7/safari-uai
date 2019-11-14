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
    public class RoomDAC : DataAccessComponent, IRepository<Room>
    {
        public Room Create(Room room)
        {
            const string SQL_STATEMENT = "INSERT INTO Sala ([Nombre],[TipoSala]) VALUES(@Nombre,@TipoSala);" +
                " SELECT SCOPE_IDENTITY();";

            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@Nombre", DbType.AnsiString, room.Name);
                db.AddInParameter(cmd, "@TipoSala", DbType.AnsiString, room.RoomType);
                room.Id = Convert.ToInt32(db.ExecuteScalar(cmd));
            }
            return room;
        }

        public List<Room> Read()
        {
            const string SQL_STATEMENT = "SELECT [Id], [Nombre], [TipoSala] FROM Sala ";

            List<Room> result = new List<Room>();
            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                using (IDataReader dr = db.ExecuteReader(cmd))
                {
                    while (dr.Read())
                    {
                        Room room = LoadRoom(dr);
                        result.Add(room);
                    }
                }
            }
            return result;
        }

        public Room ReadBy(int id)
        {
            const string SQL_STATEMENT = "SELECT [Id], [Nombre], [TipoSala] FROM Sala WHERE [Id]=@Id ";
            Room room = null;

            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@Id", DbType.Int32, id);
                using (IDataReader dr = db.ExecuteReader(cmd))
                {
                    if (dr.Read())
                    {
                        room = LoadRoom(dr);
                    }
                }
            }
            return room;
        }

        public void Update(Room room)
        {
            const string SQL_STATEMENT = "UPDATE Sala SET [Nombre]= @Nombre, [TipoSala]=@TipoSala WHERE [Id]= @Id ";

            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@Nombre", DbType.AnsiString, room.Name);
                db.AddInParameter(cmd, "@TipoSala", DbType.AnsiString, room.RoomType);
                db.AddInParameter(cmd, "@Id", DbType.Int32, room.Id);
                db.ExecuteNonQuery(cmd);
            }
        }

        public void Delete(int id)
        {
            const string SQL_STATEMENT = "DELETE Sala WHERE [Id]= @Id ";
            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@Id", DbType.Int32, id);
                db.ExecuteNonQuery(cmd);
            }
        }

        private Room LoadRoom(IDataReader dr)
        {
            Room room = new Room();
            room.Id = GetDataValue<int>(dr, "Id");
            room.Name = GetDataValue<string>(dr, "Nombre");
            room.RoomType = GetDataValue<string>(dr, "TipoSala");
            return room;
        }

        public List<Room> ReadyByFilters(Dictionary<string, string> filters)
        {
            throw new NotImplementedException();
        }
    }
}
