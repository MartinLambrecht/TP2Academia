using Business.Entities;
using Data.Database.DSMateriasTableAdapters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Data.Database.DSMaterias;

namespace Data.Database
{
    public class MateriaAdapter : Adapter
    {
        
        public List<Materia> GetAll()
        {

            List<Materia> materias = new List<Materia>();
            try
            {
                this.OpenConnection();

                SqlCommand cmdMaterias = new SqlCommand("select * from materias", sqlConn);

                SqlDataReader drMaterias = cmdMaterias.ExecuteReader();

                while (drMaterias.Read())
                {
                    Materia mat = new Materia();

                    mat.ID = (int)drMaterias["id_materia"];
                    mat.HSSemanales = (int)drMaterias["hs_semanales"];
                    mat.HSTotales = (int)drMaterias["hs_totales"];
                    mat.Descripcion = (string)drMaterias["desc_materia"];

                    materias.Add(mat);
                }

                drMaterias.Close();
                this.CloseConnection();

                return materias;
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar lista de materias", Ex);
                throw ExcepcionManejada;
            }
        }

        public Business.Entities.Materia GetOne(int ID)
        {

            Materia materia = new Materia();

            try
            {
                this.OpenConnection();

                SqlCommand cmdMateria = new SqlCommand("select * from materias where id_materia = @id", sqlConn);

                cmdMateria.Parameters.Add("@id", SqlDbType.Int).Value = ID;

                SqlDataReader drMateria = cmdMateria.ExecuteReader();

                if (drMateria.Read())
                {
                    materia.ID = (int)drMateria["id_materia"];
                    materia.HSSemanales = (int)drMateria["hs_semanales"];
                    materia.HSTotales = (int)drMateria["hs_totales"];
                    materia.Descripcion = (string)drMateria["desc_materia"];
                }

                drMateria.Close();
            }

            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar datos de la materia", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return materia;
        }


        public DSMaterias GetDSMaterias()
        {
            var dataSet = new DSMaterias();

            MateriasPorPlanTableAdapter daInscripcion = new MateriasPorPlanTableAdapter();
            daInscripcion.Fill((MateriasPorPlanDataTable)dataSet.Tables["MateriasPorPlan"]);

            return dataSet;
        }

        public void Delete(int ID)
        {

            try
            {
                this.OpenConnection();

                SqlCommand cmdDelete = new SqlCommand("delete materias where id_materia=@id", sqlConn);
                cmdDelete.Parameters.Add("@id", SqlDbType.Int).Value = ID;

                cmdDelete.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al eliminar materia", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        public void Update(Materia materia)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdSave = new SqlCommand("UPDATE materias SET hs_semanales = @hs_semanales, hs_totales = @hs_totales, desc_materia = @desc_materia" +
                "WHERE id_materia=@id", sqlConn);

                cmdSave.Parameters.Add("@id", SqlDbType.Int).Value = materia.ID;
                cmdSave.Parameters.Add("@hs_semanales", SqlDbType.Int).Value = materia.HSSemanales;
                cmdSave.Parameters.Add("@hs_totales", SqlDbType.Int).Value = materia.HSTotales;
                cmdSave.Parameters.Add("@desc_materia", SqlDbType.VarChar).Value = materia.Descripcion;
                cmdSave.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al modificar datos de la materia", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        public void Insert(Materia materia)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdSave = new SqlCommand("insert into materias(hs_semanales,hs_totales,desc_materia, id_plan)" +
                 "values (@hs_semanales, @hs_totales, @desc_materia, @id_plan)" +
                  "select @@identity", sqlConn);
                cmdSave.Parameters.Add("hs_semanales", SqlDbType.Int).Value = materia.HSSemanales;
                cmdSave.Parameters.Add("hs_totales", SqlDbType.Int).Value = materia.HSTotales;
                cmdSave.Parameters.Add("desc_materia", SqlDbType.VarChar).Value = materia.Descripcion;
                cmdSave.Parameters.Add("id_plan", SqlDbType.Int).Value = materia.IDPlan;
                materia.ID = decimal.ToInt32((decimal)cmdSave.ExecuteScalar());
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al crear materia", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }

        }

        public void Save(Materia materia)
        {
            if (materia.State == BusinessEntity.States.Deleted)
            {
                this.Delete(materia.ID);
            }

            else if (materia.State == BusinessEntity.States.New)
            {
                this.Insert(materia);
            }

            else if (materia.State == BusinessEntity.States.Modified)
            {
                this.Update(materia);
            }
            materia.State = BusinessEntity.States.Unmodified;

        }
    }
}
