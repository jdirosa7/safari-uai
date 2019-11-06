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
    public class AppointmentDAC : DataAccessComponent, IRepository<Appointment>
    {
        public Appointment Create(Appointment entity)
        {
            const string SQL_STATEMENT = "INSERT INTO Cita ([Fecha], [MedicoId], [PacienteId], [SalaId], " +
                "[TipoServicioId], [Estado], [CreatedBy], [CreatedDate]) VALUES(@Fecha, @MedicoId, @PacienteId, @SalaId, " +
                "@TipoServicioId, @Estado, @CreatedBy, @CreatedDate);" +
                " SELECT SCOPE_IDENTITY();";

            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@Fecha", DbType.AnsiString, entity.Date);
                db.AddInParameter(cmd, "@MedicoId", DbType.AnsiString, entity.Doctor.Id);
                db.AddInParameter(cmd, "@PacienteId", DbType.AnsiString, entity.Patient.Id);
                db.AddInParameter(cmd, "@SalaId", DbType.AnsiString, entity.Room.Id);
                db.AddInParameter(cmd, "@TipoServicioId", DbType.AnsiString, entity.ServiceType.Id);
                db.AddInParameter(cmd, "@Estado", DbType.AnsiString, entity.Status);
                db.AddInParameter(cmd, "@CreatedBy", DbType.AnsiString, entity.CreatedBy);
                db.AddInParameter(cmd, "@CreatedDate", DbType.AnsiString, entity.CreatedDate);
                entity.Id = Convert.ToInt32(db.ExecuteScalar(cmd));
            }
            return entity;
        }

        public void Delete(int id)
        {
            const string SQL_STATEMENT = "DELETE Cita WHERE [Id]= @Id ";
            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@Id", DbType.Int32, id);
                db.ExecuteNonQuery(cmd);
            }
        }

        private Appointment LoadAppointment(IDataReader dr)
        {
            Appointment serviceType = new Appointment();
            serviceType.Id = GetDataValue<int>(dr, "Id");
            serviceType.Date = GetDataValue<DateTime>(dr, "Fecha");
            //serviceType.Doctor = new Doctor({GetDataValue<string>(dr, "");
            //serviceType.Patient = GetDataValue<string>(dr, "");
            serviceType.Patient = new Patient
            {
                Id = GetDataValue<int>(dr, "Id"),
                Name = GetDataValue<string>(dr, "Nombre"),
                BirthDate = GetDataValue<DateTime>(dr, "FechaNacimiento"),
                Client = new Client
                {
                    Id = GetDataValue<int>(dr, "Id"),
                    Name = GetDataValue<string>(dr, "Nombre"),
                    BirthDate = GetDataValue<DateTime>(dr, "FechaNacimiento"),
                    Address = GetDataValue<string>(dr, "Direccion"),
                    LastName = GetDataValue<string>(dr, "Apellido"),
                    Email = GetDataValue<string>(dr, "Email"),
                    Phone = GetDataValue<string>(dr, "Telefono"),
                    URL = GetDataValue<string>(dr, "URL"),
                },
                Specie = new Species
                {
                    Id = GetDataValue<int>(dr, "Id"),
                    Nombre = GetDataValue<string>(dr, "Nombre")
                },
                Observation = GetDataValue<string>(dr, "Observacion")
            };
            serviceType.Room = new Room
            {
                Id = GetDataValue<int>(dr, "Id"),
                Name = GetDataValue<string>(dr, "Nombre"),
                RoomType = GetDataValue<string>(dr, "TipoServicio")
            };
            serviceType.ServiceType = new ServiceType
            {
                Id = GetDataValue<int>(dr, "Id"),
                Name = GetDataValue<string>(dr, "Nombre")
            };
            serviceType.Status = GetDataValue<string>(dr, "Estado");
            serviceType.CreatedDate = GetDataValue<DateTime>(dr, "CreatedDate");
            serviceType.CreatedBy = GetDataValue<string>(dr, "CreatedBy");
            serviceType.UpdatedDate = GetDataValue<DateTime>(dr, "UpdatedDate");
            serviceType.UpdatedBy = GetDataValue<string>(dr, "UpdatedBy");
            serviceType.DeletedDate = GetDataValue<DateTime>(dr, "DeletedDate");
            serviceType.DeletedBy = GetDataValue<string>(dr, "DeletedBy");
            serviceType.Deleted = GetDataValue<bool>(dr, "Deleted");
            return serviceType;
        }

        public List<Appointment> Read()
        {
            const string SQL_STATEMENT = "SELECT [Id], [Nombre] FROM Cita ";

            List<Appointment> result = new List<Appointment>();
            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                using (IDataReader dr = db.ExecuteReader(cmd))
                {
                    while (dr.Read())
                    {
                        Appointment serviceType = LoadAppointment(dr);
                        result.Add(serviceType);
                    }
                }
            }
            return result;
        }

        public Appointment ReadBy(int id)
        {
            const string SQL_STATEMENT = "SELECT [Id], [Nombre] FROM Cita WHERE [Id]=@Id ";
            Appointment serviceType = null;

            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@Id", DbType.Int32, id);
                using (IDataReader dr = db.ExecuteReader(cmd))
                {
                    if (dr.Read())
                    {
                        serviceType = LoadAppointment(dr);
                    }
                }
            }
            return serviceType;
        }

        public void Update(Appointment serviceType)
        {
            const string SQL_STATEMENT = "UPDATE Cita SET [Nombre]= @Nombre WHERE [Id]= @Id ";

            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                //db.AddInParameter(cmd, "@Nombre", DbType.AnsiString, serviceType.Name);
                //db.AddInParameter(cmd, "@Id", DbType.Int32, serviceType.Id);
                db.ExecuteNonQuery(cmd);
            }
        }
    }
}
