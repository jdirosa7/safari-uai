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
            serviceType.Doctor = new Doctor
            {
                Id = GetDataValue<int>(dr, "Id"),
                Name = GetDataValue<string>(dr, "MedicoNombre"),
                LastName = GetDataValue<string>(dr, "MedicoApellido"),
                BirthDate = GetDataValue<DateTime>(dr, "MedicoFechaNacimiento"),
                Phone = GetDataValue<string>(dr, "MedicoTelefono"),
                Email = GetDataValue<string>(dr, "MedicoEmail"),
                Specialty = GetDataValue<string>(dr, "Especialidad"),
                EnrollmentType = GetDataValue<string>(dr, "TipoMatricula"),
                EnrollmentNumber = GetDataValue<string>(dr, "NumeroMatricula")
            };
            serviceType.Patient = new Patient
            {
                Id = GetDataValue<int>(dr, "Id"),
                Name = GetDataValue<string>(dr, "PacienteNombre"),
                BirthDate = GetDataValue<DateTime>(dr, "PacienteFechaNacimiento"),
                Client = new Client
                {
                    Id = GetDataValue<int>(dr, "Id"),
                    Name = GetDataValue<string>(dr, "ClienteNombre"),
                    BirthDate = GetDataValue<DateTime>(dr, "ClienteFechaNacimiento"),
                    Address = GetDataValue<string>(dr, "Direccion"),
                    LastName = GetDataValue<string>(dr, "ClienteApellido"),
                    Email = GetDataValue<string>(dr, "ClienteEmail"),
                    Phone = GetDataValue<string>(dr, "ClienteTelefono"),
                    URL = GetDataValue<string>(dr, "URL"),
                },
                Specie = new Species
                {
                    Id = GetDataValue<int>(dr, "Id"),
                    Nombre = GetDataValue<string>(dr, "EspecieNombre")
                },
                Observation = GetDataValue<string>(dr, "Observacion")
            };
            serviceType.Room = new Room
            {
                Id = GetDataValue<int>(dr, "Id"),
                Name = GetDataValue<string>(dr, "SalaNombre"),
                RoomType = GetDataValue<string>(dr, "TipoSala")
            };
            serviceType.ServiceType = new ServiceType
            {
                Id = GetDataValue<int>(dr, "Id"),
                Name = GetDataValue<string>(dr, "TipoServicioNombre")
            };
            serviceType.Status = GetDataValue<string>(dr, "Estado");
            serviceType.CreatedDate = GetDataValue<DateTime>(dr, "CreatedDate");
            serviceType.CreatedBy = GetDataValue<string>(dr, "CreatedBy");
            serviceType.UpdatedDate = GetDataValue<DateTime>(dr, "ChangedDate");
            serviceType.UpdatedBy = GetDataValue<string>(dr, "ChangedBy");
            serviceType.DeletedDate = GetDataValue<DateTime>(dr, "DeletedDate");
            serviceType.DeletedBy = GetDataValue<string>(dr, "DeletedBy");
            serviceType.Deleted = GetDataValue<bool>(dr, "Deleted");
            return serviceType;
        }

        public List<Appointment> Read()
        {
            const string SQL_STATEMENT = "SELECT Cita.Id as CitaId, [Fecha], [MedicoId], [PacienteId], " +
                "[SalaId], [TipoServicioId],[Estado], [CreatedBy], [CreatedDate], [ChangedBy], [ChangedDate]," +
                " [DeletedBy], [DeletedDate],[Deleted], M.Nombre as MedicoNombre, M.Apellido as MedicoApellido," +
                " M.FechaNacimiento as MedicoFechaNacimiento,M.Telefono as MedicoTelefono, M.Email as MedicoEmail," +
                " M.Especialidad, M.TipoMatricula, M.NumeroMatricula,P.Nombre as PacienteNombre, P.FechaNacimiento " +
                "as PacienteFechaNacimiento, P.Observacion,C.Nombre as ClienteNombre, C.Apellido as ClienteApellido," +
                " C.FechaNacimiento as ClienteFechaNacimiento,C.Domicilio, C.Telefono as ClienteTelefono, C.Email " +
                "as ClienteEmail, C.Url,E.Nombre as EspecieNombre,S.Nombre as SalaNombre, S.TipoSala,TS.Nombre " +
                "as TipoServicioNombre FROM Cita inner join Medico M on MedicoId = M.Id inner join Paciente P " +
                "on PacienteId = P.Id inner join Cliente C on C.Id = P.ClienteId inner join Especie E on E.Id" +
                " = P.EspecieId inner join Sala S on S.Id = Cita.SalaId inner join TipoServicio TS on TS.Id" +
                " = Cita.TipoServicioId";

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
            const string SQL_STATEMENT = "SELECT Cita.Id as CitaId, [Fecha], [MedicoId], [PacienteId], " +
                "[SalaId], [TipoServicioId],[Estado], [CreatedBy], [CreatedDate], [ChangedBy], [ChangedDate]," +
                " [DeletedBy], [DeletedDate],[Deleted], M.Nombre as MedicoNombre, M.Apellido as MedicoApellido," +
                " M.FechaNacimiento as MedicoFechaNacimiento,M.Telefono as MedicoTelefono, M.Email as MedicoEmail," +
                " M.Especialidad, M.TipoMatricula, M.NumeroMatricula,P.Nombre as PacienteNombre, P.FechaNacimiento " +
                "as PacienteFechaNacimiento, P.Observacion,C.Nombre as ClienteNombre, C.Apellido as ClienteApellido," +
                " C.FechaNacimiento as ClienteFechaNacimiento,C.Domicilio, C.Telefono as ClienteTelefono, C.Email " +
                "as ClienteEmail, C.Url,E.Nombre as EspecieNombre,S.Nombre as SalaNombre, S.TipoSala,TS.Nombre " +
                "as TipoServicioNombre FROM Cita inner join Medico M on MedicoId = M.Id inner join Paciente P " +
                "on PacienteId = P.Id inner join Cliente C on C.Id = P.ClienteId inner join Especie E on E.Id" +
                " = P.EspecieId inner join Sala S on S.Id = Cita.SalaId inner join TipoServicio TS on TS.Id" +
                " = Cita.TipoServicioId WHERE Cita.Id= @Id";

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

        public void Update(Appointment entity)
        {
            const string SQL_STATEMENT = "UPDATE Cita SET [Fecha]= @Fecha, [MedicoId]= @MedicoId," +
                "[PacienteId]= @PacienteId, [SalaId]= @SalaId, [TipoServicioId]= @TipoServicioId," +
                "[Estado]= @Estado, [UpdatedBy]= @UpdatedBy, [UpdatedDate]= @UpdatedDate WHERE [Id]= @Id ";

            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@Id", DbType.AnsiString, entity.Id);
                db.AddInParameter(cmd, "@Fecha", DbType.AnsiString, entity.Date);
                db.AddInParameter(cmd, "@MedicoId", DbType.AnsiString, entity.Doctor.Id);
                db.AddInParameter(cmd, "@PacienteId", DbType.AnsiString, entity.Patient.Id);
                db.AddInParameter(cmd, "@SalaId", DbType.AnsiString, entity.Room.Id);
                db.AddInParameter(cmd, "@TipoServicioId", DbType.AnsiString, entity.ServiceType.Id);
                db.AddInParameter(cmd, "@Estado", DbType.AnsiString, entity.Status);
                db.AddInParameter(cmd, "@UpdatedBy", DbType.AnsiString, entity.UpdatedBy);
                db.AddInParameter(cmd, "@UpdatedDate", DbType.AnsiString, entity.UpdatedDate);
                db.ExecuteNonQuery(cmd);
            }
        }

        public List<Appointment> ReadyByFilters(Dictionary<string, string> filters)
        {
            string SQL_STATEMENT = "SELECT Cita.Id as CitaId, [Fecha], [MedicoId], [PacienteId], " +
                "[SalaId], [TipoServicioId],[Estado], [CreatedBy], [CreatedDate], [ChangedBy], [ChangedDate]," +
                " [DeletedBy], [DeletedDate],[Deleted], M.Nombre as MedicoNombre, M.Apellido as MedicoApellido," +
                " M.FechaNacimiento as MedicoFechaNacimiento,M.Telefono as MedicoTelefono, M.Email as MedicoEmail," +
                " M.Especialidad, M.TipoMatricula, M.NumeroMatricula,P.Nombre as PacienteNombre, P.FechaNacimiento " +
                "as PacienteFechaNacimiento, P.Observacion,C.Nombre as ClienteNombre, C.Apellido as ClienteApellido," +
                " C.FechaNacimiento as ClienteFechaNacimiento,C.Domicilio, C.Telefono as ClienteTelefono, C.Email " +
                "as ClienteEmail, C.Url,E.Nombre as EspecieNombre,S.Nombre as SalaNombre, S.TipoSala,TS.Nombre " +
                "as TipoServicioNombre FROM Cita inner join Medico M on MedicoId = M.Id inner join Paciente P " +
                "on PacienteId = P.Id inner join Cliente C on C.Id = P.ClienteId inner join Especie E on E.Id" +
                " = P.EspecieId inner join Sala S on S.Id = Cita.SalaId inner join TipoServicio TS on TS.Id" +
                " = Cita.TipoServicioId WHERE ";

            List<Appointment> appointments = null;

            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                List<KeyValuePair<string, string>> values = filters.ToList();
                for (int i = 0; i < filters.Count; i++)
                {
                    SQL_STATEMENT += values[i].Key + " = @" + values[i].Value;

                    db.AddInParameter(cmd, "@" + values[i].Key, values[i].Value.GetType().Equals(typeof(int)) ? DbType.Int32 : DbType.String, values[i].Value);

                    if (i != filters.Count)
                        SQL_STATEMENT += " AND ";

                }

                using (IDataReader dr = db.ExecuteReader(cmd))
                {
                    if (dr.Read())
                    {
                        appointments.Add(LoadAppointment(dr));
                    }
                }
            }
            return appointments;
        }
    }
}
