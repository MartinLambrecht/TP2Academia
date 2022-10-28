using Business.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Database
{
    public class ComisionAdapter : Adapter
    {
        private static List<Comision> _Comisiones;

        private static List<Comision> Comisiones
        {
            get
            {
                if (_Comisiones == null)
                {
                    _Comisiones = new List<Business.Entities.Comision>();
                    Business.Entities.Comision com;
                    com = new Business.Entities.Comision();
                    com.ID = 1;
                    com.State = Business.Entities.BusinessEntity.States.Unmodified;
                    com.AnioEspecialidad = 2022;
                    com.Descripcion = "gggg";
                    com.IDPlan = 5;
                }
                return _Comisiones;
            }
        }

        public List<Comision> GetAll()
        {
            // return new List<Comision>(Comisiones);

            List<Comision> comisiones = new List<Comision>();
            try
            {
                this.OpenConnection();

                SqlCommand cmdComisiones = new SqlCommand("select * from comisiones", sqlConn);

                SqlDataReader drComisiones = cmdComisiones.ExecuteReader();

                while (drComisiones.Read())
                {
                    Comision com = new Comision();

                    com.ID = (int)drComisiones["id_comision"];
                    com.AnioEspecialidad = (int)drComisiones["anio_especialidad"];
                    com.Descripcion = (string)drComisiones["desc_comision"];

                    comisiones.Add(com);
                }

                drComisiones.Close();
                this.CloseConnection();

                return comisiones;
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar lista de comisiones", Ex);
                throw ExcepcionManejada;
            }
        }

        public Business.Entities.Comision GetOne(int ID)
        {
            // return Comisiones.Find(delegate (Comision c) { return c.ID == ID; });

            Comision comision = new Comision();

            try
            {
                this.OpenConnection();

                SqlCommand cmdComision = new SqlCommand("select * from comisiones where id_comision = @id", sqlConn);

                cmdComision.Parameters.Add("@id", SqlDbType.Int).Value = ID;

                SqlDataReader drComision = cmdComision.ExecuteReader();

                if (drComision.Read())
                {
                    comision.ID = (int)drComision["id_comision"];
                    comision.AnioEspecialidad = (int)drComision["anio_especialidad"];
                    comision.Descripcion = (string)drComision["desc_comision"];
                }

                drComision.Close();
            }

            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar datos de la comision", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return comision;
        }

        public void Delete(int ID)
        {
            // Comisiones.Remove(this.GetOne(ID));

            try
            {
                this.OpenConnection();

                SqlCommand cmdDelete = new SqlCommand("delete comisiones where id_comision=@id", sqlConn);
                cmdDelete.Parameters.Add("@id", SqlDbType.Int).Value = ID;

                cmdDelete.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al eliminar comision", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        public void Update(Comision comision)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdSave = new SqlCommand("UPDATE comisiones SET anio_especialidad = @anio_especialidad, desc_comision = @desc_comision" +
                "WHERE id_comision=@id", sqlConn);

                cmdSave.Parameters.Add("@id", SqlDbType.Int).Value = comision.ID;
                cmdSave.Parameters.Add("@anio_especialidad", SqlDbType.Int).Value = comision.AnioEspecialidad;
                cmdSave.Parameters.Add("@desc_comision", SqlDbType.VarChar).Value = comision.Descripcion;
                cmdSave.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al modificar datos del comision", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        public void Insert(Comision comision)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdSave = new SqlCommand("insert into comisiones(anio_especialidad,desc_comision)" +
                 "values (@anio_especialidad, @desc_comision)" +
                  "select @@identity", sqlConn);
                cmdSave.Parameters.Add("anio_especialidad", SqlDbType.Int).Value = comision.AnioEspecialidad;
                cmdSave.Parameters.Add("desc_comision", SqlDbType.VarChar).Value = comision.Descripcion;
                comision.ID = decimal.ToInt32((decimal)cmdSave.ExecuteScalar());
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al crear comision", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }

        }

        public void Save(Comision comision)
        {
            if (comision.State == BusinessEntity.States.Deleted)
            {
                this.Delete(comision.ID);
            }

            else if (comision.State == BusinessEntity.States.New)
            {
                this.Insert(comision);
            }

            else if (comision.State == BusinessEntity.States.Modified)
            {
                this.Update(comision);
            }
            comision.State = BusinessEntity.States.Unmodified;

        }

    }
}
