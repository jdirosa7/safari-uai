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
    public class PatientDAC : DataAccessComponent, IRepository<Patient>
    {
        public Patient Create(Patient patient)
        {
            const string SQL_STATEMENT = "INSERT INTO Paciente ([Nombre],[FechaNacimiento],[Observacion],[ClientId]," +
                "[EspecieId])" +
                " VALUES(@Nombre,@FechaNacimiento,@Observacion,@ClientId,@EspecieId); SELECT SCOPE_IDENTITY();";

            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@Nombre", DbType.AnsiString, patient.Name);
                db.AddInParameter(cmd, "@FechaNacimiento", DbType.AnsiString, patient.BirthDate);
                db.AddInParameter(cmd, "@Observacion", DbType.AnsiString, patient.Observation);
                db.AddInParameter(cmd, "@ClientId", DbType.AnsiString, patient.ClientId);
                db.AddInParameter(cmd, "@EspecieId", DbType.AnsiString, patient.SpecieId);
                patient.Id = Convert.ToInt32(db.ExecuteScalar(cmd));
            }
            return patient;
        }

        public List<Patient> Read()
        {
            const string SQL_STATEMENT = "SELECT P.Id, P.Nombre, P.FechaNacimiento, P.Observacion," +
                " P.ClienteId, P.EspecieId FROM Paciente P inner join Cliente on P.ClienteId = Cliente.Id " +
                "inner join Especie on P.EspecieId = Especie.Id";

            List<Patient> result = new List<Patient>();
            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                using (IDataReader dr = db.ExecuteReader(cmd))
                {
                    while (dr.Read())
                    {
                        Patient patient = LoadPatient(dr);
                        result.Add(patient);
                    }
                }
            }
            return result;
        }

        public Patient ReadBy(int id)
        {
            const string SQL_STATEMENT = "SELECT [Id], [Nombre], [FechaNacimiento], [Observacion]," +
                " [ClientId], [EspecieId] FROM Paciente WHERE [Id]=@Id ";
            Patient patient = null;

            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@Id", DbType.Int32, id);
                using (IDataReader dr = db.ExecuteReader(cmd))
                {
                    if (dr.Read())
                    {
                        patient = LoadPatient(dr);
                    }
                }
            }
            return patient;
        }

        public List<Patient> ReadyByFilters(Dictionary<string, string> filters)
        {
            string SQL_STATEMENT = "SELECT [Id], [Nombre], [FechaNacimiento], [Observacion]," +
                " [ClientId], [EspecieId] FROM Paciente WHERE  ";
            List<Patient> clients = null;

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
                        clients.Add(LoadPatient(dr));
                    }
                }
            }
            return clients;
        }

        public void Update(Patient patient)
        {
            const string SQL_STATEMENT = "UPDATE Paciente SET [Nombre]= @Nombre, [FechaNacimiento]=@FechaNacimiento, " +
                "[Observacion]= @Observacion, [ClientId]= @ClientId, [EspecieId]= @EspecieId WHERE [Id]= @Id ";

            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@Nombre", DbType.AnsiString, patient.Name);
                db.AddInParameter(cmd, "@FechaNacimiento", DbType.AnsiString, patient.BirthDate);
                db.AddInParameter(cmd, "@Observacion", DbType.AnsiString, patient.Observation);
                db.AddInParameter(cmd, "@ClientId", DbType.AnsiString, patient.ClientId);
                db.AddInParameter(cmd, "@EspecieId", DbType.AnsiString, patient.SpecieId);
                db.AddInParameter(cmd, "@Id", DbType.Int32, patient.Id);
                db.ExecuteNonQuery(cmd);
            }
        }

        public void Delete(int id)
        {
            const string SQL_STATEMENT = "DELETE Paciente WHERE [Id]= @Id ";
            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@Id", DbType.Int32, id);
                db.ExecuteNonQuery(cmd);
            }
        }

        private Patient LoadPatient(IDataReader dr)
        {
            Patient patient = new Patient();
            patient.Id = GetDataValue<int>(dr, "Id");
            patient.Name = GetDataValue<string>(dr, "Nombre");
            patient.BirthDate = GetDataValue<DateTime>(dr, "FechaNacimiento");
            patient.Observation = GetDataValue<string>(dr, "Observacion");
            patient.ClientId = GetDataValue<int>(dr, "ClientId");
            patient.SpecieId = GetDataValue<int>(dr, "EspecieId");
            return patient;
        }
    }
}
