﻿using Microsoft.Practices.EnterpriseLibrary.Data;
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
                db.AddInParameter(cmd, "@MedicoId", DbType.AnsiString, entity.DoctorId);
                db.AddInParameter(cmd, "@PacienteId", DbType.AnsiString, entity.PatientId);
                db.AddInParameter(cmd, "@SalaId", DbType.AnsiString, entity.RoomId);
                db.AddInParameter(cmd, "@TipoServicioId", DbType.AnsiString, entity.ServiceTypeId);
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
            Appointment app = new Appointment();
            app.Id = GetDataValue<int>(dr, "CitaId");
            app.Date = GetDataValue<DateTime>(dr, "Fecha");
            app.Doctor = new Doctor
            {
                Id = GetDataValue<int>(dr, "MedicoId"),
                Name = GetDataValue<string>(dr, "MedicoNombre"),
                LastName = GetDataValue<string>(dr, "MedicoApellido"),
                BirthDate = GetDataValue<DateTime>(dr, "MedicoFechaNacimiento"),
                Phone = GetDataValue<string>(dr, "MedicoTelefono"),
                Email = GetDataValue<string>(dr, "MedicoEmail"),
                Specialty = GetDataValue<string>(dr, "Especialidad"),
                EnrollmentType = GetDataValue<string>(dr, "TipoMatricula"),
                EnrollmentNumber = GetDataValue<int>(dr, "NumeroMatricula")
            };
            app.Patient = new Patient
            {
                Id = GetDataValue<int>(dr, "PacienteId"),
                Name = GetDataValue<string>(dr, "PacienteNombre"),
                BirthDate = GetDataValue<DateTime>(dr, "PacienteFechaNacimiento"),
                Client = new Client
                {
                    Id = GetDataValue<int>(dr, "ClienteId"),
                    Name = GetDataValue<string>(dr, "ClienteNombre"),
                    BirthDate = GetDataValue<DateTime>(dr, "ClienteFechaNacimiento"),
                    Address = GetDataValue<string>(dr, "Domicilio"),
                    LastName = GetDataValue<string>(dr, "ClienteApellido"),
                    Email = GetDataValue<string>(dr, "ClienteEmail"),
                    Phone = GetDataValue<string>(dr, "ClienteTelefono"),
                    URL = GetDataValue<string>(dr, "URL"),
                },
                Specie = new Species
                {
                    Id = GetDataValue<int>(dr, "EspecieId"),
                    Nombre = GetDataValue<string>(dr, "EspecieNombre")
                },
                Observation = GetDataValue<string>(dr, "Observacion")
            };
            app.Room = new Room
            {
                Id = GetDataValue<int>(dr, "SalaId"),
                Name = GetDataValue<string>(dr, "SalaNombre"),
                RoomType = GetDataValue<string>(dr, "TipoSala")
            };
            app.ServiceType = new ServiceType
            {
                Id = GetDataValue<int>(dr, "TipoServicioId"),
                Name = GetDataValue<string>(dr, "TipoServicioNombre")
            };
            app.Status = GetDataValue<string>(dr, "Estado");
            app.CreatedDate = GetDataValue<DateTime>(dr, "CreatedDate");
            app.CreatedBy = GetDataValue<string>(dr, "CreatedBy");
            app.UpdatedDate = GetDataValue<DateTime>(dr, "ChangedDate");
            app.UpdatedBy = GetDataValue<string>(dr, "ChangedBy");
            app.DeletedDate = GetDataValue<DateTime>(dr, "DeletedDate");
            app.DeletedBy = GetDataValue<string>(dr, "DeletedBy");
            app.Deleted = GetDataValue<bool>(dr, "Deleted");
            return app;
        }

        public List<Appointment> Read()
        {
            const string SQL_STATEMENT = "SELECT Cita.Id as CitaId, [Fecha], [MedicoId], [PacienteId], " +
                "[SalaId], [TipoServicioId],[Estado], [CreatedBy], [CreatedDate], [ChangedBy], [ChangedDate]," +
                " [DeletedBy], [DeletedDate],[Deleted], M.Id as MedicoId, M.Nombre as MedicoNombre, M.Apellido as MedicoApellido," +
                " M.FechaNacimiento as MedicoFechaNacimiento,M.Telefono as MedicoTelefono, M.Email as MedicoEmail," +
                " M.Especialidad, M.TipoMatricula, M.NumeroMatricula, P.Id as PacienteId, P.Nombre as PacienteNombre, P.FechaNacimiento " +
                "as PacienteFechaNacimiento, P.Observacion,C.Id as ClienteId, C.Nombre as ClienteNombre, C.Apellido as ClienteApellido," +
                " C.FechaNacimiento as ClienteFechaNacimiento,C.Domicilio, C.Telefono as ClienteTelefono, C.Email " +
                "as ClienteEmail, C.Url, E.Id as EspecieId, E.Nombre as EspecieNombre, S.Id as SalaId, S.Nombre as SalaNombre," +
                " S.TipoSala, TS.Id as TipoServicioId, TS.Nombre " +
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
                " [DeletedBy], [DeletedDate],[Deleted], M.Id as MedicoId, M.Nombre as MedicoNombre, M.Apellido as MedicoApellido," +
                " M.FechaNacimiento as MedicoFechaNacimiento,M.Telefono as MedicoTelefono, M.Email as MedicoEmail," +
                " M.Especialidad, M.TipoMatricula, M.NumeroMatricula, P.Id as PacienteId, P.Nombre as PacienteNombre, P.FechaNacimiento " +
                "as PacienteFechaNacimiento, P.Observacion,C.Id as ClienteId, C.Nombre as ClienteNombre, C.Apellido as ClienteApellido," +
                " C.FechaNacimiento as ClienteFechaNacimiento,C.Domicilio, C.Telefono as ClienteTelefono, C.Email " +
                "as ClienteEmail, C.Url, E.Id as EspecieId, E.Nombre as EspecieNombre, S.Id as SalaId, S.Nombre as SalaNombre," +
                " S.TipoSala, TS.Id as TipoServicioId, TS.Nombre " +
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
                "[Estado]= @Estado, [ChangedBy]= @ChangedBy, [ChangedDate]= @ChangedDate WHERE [Id]= @Id ";

            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@Id", DbType.AnsiString, entity.Id);
                db.AddInParameter(cmd, "@Fecha", DbType.AnsiString, entity.Date);
                db.AddInParameter(cmd, "@MedicoId", DbType.AnsiString, entity.DoctorId);
                db.AddInParameter(cmd, "@PacienteId", DbType.AnsiString, entity.PatientId);
                db.AddInParameter(cmd, "@SalaId", DbType.AnsiString, entity.RoomId);
                db.AddInParameter(cmd, "@TipoServicioId", DbType.AnsiString, entity.ServiceTypeId);
                db.AddInParameter(cmd, "@Estado", DbType.AnsiString, entity.Status);
                db.AddInParameter(cmd, "@ChangedBy", DbType.AnsiString, entity.UpdatedBy);
                db.AddInParameter(cmd, "@ChangedDate", DbType.AnsiString, entity.UpdatedDate);
                db.ExecuteNonQuery(cmd);
            }
        }

        public void LogicDelete(Appointment entity)
        {
            const string SQL_STATEMENT = "UPDATE Cita SET [Estado]= @Estado, [DeletedBy]= @DeletedBy, " +
                "[DeletedDate]= @DeletedDate, [Deleted]= @Deleted WHERE [Id]= @Id ";

            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@Id", DbType.AnsiString, entity.Id);                
                db.AddInParameter(cmd, "@Estado", DbType.AnsiString, entity.Status);
                db.AddInParameter(cmd, "@DeletedBy", DbType.AnsiString, entity.DeletedBy);
                db.AddInParameter(cmd, "@DeletedDate", DbType.AnsiString, entity.DeletedDate);
                db.AddInParameter(cmd, "@Deleted", DbType.AnsiString, entity.Deleted);
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
                        appointments.Add(LoadAppointment(dr));
                    }
                }
            }
            return appointments;
        }
    }
}
