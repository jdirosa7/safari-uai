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
    public class DoctorDAC : DataAccessComponent, IRepository<Doctor>
    {
        public Doctor Create(Doctor doctor)
        {
            const string SQL_STATEMENT = "INSERT INTO Medico ([Apellido],[Nombre],[TipoMatricula],[NumeroMatricula]," +
                "[Especialidad],[FechaNacimiento],[Email],[Telefono])" +
                " VALUES(@Apellido,@Nombre,@TipoMatricula,@NumeroMatricula,@Especialidad,@Email,@Telefono," +
                "@FechaNacimiento); SELECT SCOPE_IDENTITY();";

            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@Apellido", DbType.AnsiString, doctor.Name);
                db.AddInParameter(cmd, "@Nombre", DbType.AnsiString, doctor.BirthDate);
                db.AddInParameter(cmd, "@TipoMatricula", DbType.AnsiString, doctor.EnrollmentType);
                db.AddInParameter(cmd, "@NumeroMatricula", DbType.AnsiString, doctor.EnrollmentNumber);
                db.AddInParameter(cmd, "@Especialidad", DbType.AnsiString, doctor.Specialty);
                db.AddInParameter(cmd, "@Email", DbType.AnsiString, doctor.Email);
                db.AddInParameter(cmd, "@Telefono", DbType.AnsiString, doctor.Phone);
                db.AddInParameter(cmd, "@FechaNacimiento", DbType.AnsiString, doctor.BirthDate);
                doctor.Id = Convert.ToInt32(db.ExecuteScalar(cmd));
            }
            return doctor;
        }

        public List<Doctor> Read()
        {
            const string SQL_STATEMENT = "SELECT [Id],[Apellido],[Nombre],[TipoMatricula],[NumeroMatricula]," +
                "[Especialidad],[FechaNacimiento],[Email],[Telefono] FROM Medico ";

            List<Doctor> result = new List<Doctor>();
            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                using (IDataReader dr = db.ExecuteReader(cmd))
                {
                    while (dr.Read())
                    {
                        Doctor doctor = LoadDoctor(dr);
                        result.Add(doctor);
                    }
                }
            }
            return result;
        }

        public Doctor ReadBy(int id)
        {
            const string SQL_STATEMENT = "SELECT [Id],[Apellido],[Nombre],[TipoMatricula],[NumeroMatricula]," +
                "[Especialidad],[FechaNacimiento],[Email],[Telefono] FROM Medico WHERE [Id]=@Id ";
            Doctor doctor = null;

            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@Id", DbType.Int32, id);
                using (IDataReader dr = db.ExecuteReader(cmd))
                {
                    if (dr.Read())
                    {
                        doctor = LoadDoctor(dr);
                    }
                }
            }
            return doctor;
        }

        public void Update(Doctor doctor)
        {
            const string SQL_STATEMENT = "UPDATE Medico SET [Apellido]=@Apellido,[Nombre]= @Nombre," +
                "[TipoMatricula]=@TipoMatricula,[NumeroMatricula]=@NumeroMatricula,[Especialidad]=@Especialidad," +
                "[FechaNacimiento]=@FechaNacimiento,[Email]= @Email,[Telefono]= @Telefono, WHERE [Id]= @Id ";

            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@Apellido", DbType.AnsiString, doctor.Name);
                db.AddInParameter(cmd, "@Nombre", DbType.AnsiString, doctor.BirthDate);
                db.AddInParameter(cmd, "@TipoMatricula", DbType.AnsiString, doctor.EnrollmentType);
                db.AddInParameter(cmd, "@NumeroMatricula", DbType.AnsiString, doctor.EnrollmentNumber);
                db.AddInParameter(cmd, "@Especialidad", DbType.AnsiString, doctor.Specialty);
                db.AddInParameter(cmd, "@Email", DbType.AnsiString, doctor.Email);
                db.AddInParameter(cmd, "@Telefono", DbType.AnsiString, doctor.Phone);
                db.AddInParameter(cmd, "@FechaNacimiento", DbType.AnsiString, doctor.BirthDate);
                db.AddInParameter(cmd, "@Id", DbType.Int32, doctor.Id);
                db.ExecuteNonQuery(cmd);
            }
        }

        public void Delete(int id)
        {
            const string SQL_STATEMENT = "DELETE Medico WHERE [Id]= @Id ";
            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@Id", DbType.Int32, id);
                db.ExecuteNonQuery(cmd);
            }
        }

        private Doctor LoadDoctor(IDataReader dr)
        {
            Doctor doctor = new Doctor();
            doctor.Id = GetDataValue<int>(dr, "Id");
            doctor.Name = GetDataValue<string>(dr, "Nombre");
            doctor.LastName = GetDataValue<string>(dr, "Apellido");
            doctor.EnrollmentType = GetDataValue<string>(dr, "TipoMatricula");
            doctor.EnrollmentNumber = GetDataValue<string>(dr, "NumeroMatricula");
            doctor.Specialty = GetDataValue<string>(dr, "Especialidad");
            doctor.BirthDate = GetDataValue<DateTime>(dr, "FechaNacimiento");
            doctor.Email = GetDataValue<string>(dr, "Email");
            doctor.Phone = GetDataValue<string>(dr, "Telefono");
            return doctor;
        }

        public List<Doctor> ReadyByFilters(Dictionary<string, string> filters)
        {
            string SQL_STATEMENT = "SELECT [Id],[Apellido],[Nombre],[TipoMatricula],[NumeroMatricula]," +
                "[Especialidad],[FechaNacimiento],[Email],[Telefono] FROM Medico WHERE ";
            List<Doctor> doctors = null;

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
                    while(dr.Read())
                    {
                        doctors.Add(LoadDoctor(dr));
                    }
                }
            }
            return doctors;
        }
    }
}
