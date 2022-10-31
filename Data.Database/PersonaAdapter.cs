using Business.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace Data.Database
{
    public class PersonaAdapter : Adapter
    {
        public List<Persona> GetAll()
        {
            List<Persona> personas = new List<Persona>();
            try
            {
                this.OpenConnection();

                SqlCommand cmdPersonas = new SqlCommand("Select * from personas", sqlConn);

                SqlDataReader drPersonas = cmdPersonas.ExecuteReader();

                while (drPersonas.Read())
                {
                    Persona per = new Persona();

                    per.ID = (int)drPersonas["id_persona"];
                    per.Nombre = (string)drPersonas["nombre"];
                    per.Direccion = (string)drPersonas["direccion"];
                    per.Email = (string)drPersonas["email"];
                    per.Telefono = (string)drPersonas["telefono"];
                    per.FechaNacimiento = (DateTime)drPersonas["fecha_nac"];
                    if (drPersonas["legajo"] != DBNull.Value)
                    {
                        per.Legajo = (int)drPersonas["legajo"];
                    }
                    per.TipoPersona = (Persona.TipoPersonas)drPersonas["tipo_persona"];
                    per.IDPlan = (int)drPersonas["id_plan"];

                    personas.Add(per);
                }

                drPersonas.Close();
            }
            catch (Exception Ex)
            {
                Exception excepcionManejada = new Exception("Error al recuperar la lista de Personas", Ex);
                throw excepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return personas;
        }

        public Business.Entities.Persona GetOne(int ID)
        {
            Persona personaPedida = new Persona();
            try
            {
                this.OpenConnection();

                SqlCommand cmdGetOne = new SqlCommand("Select * from personas where id_persona=@id", sqlConn);
                cmdGetOne.Parameters.Add("@id", SqlDbType.Int).Value = ID;

                SqlDataReader drPersona = cmdGetOne.ExecuteReader();
                if (drPersona.Read())
                {
                    personaPedida.ID = (int)drPersona["id_personaPedidasona"];
                    personaPedida.Nombre = (string)drPersona["nombre"];
                    personaPedida.Direccion = (string)drPersona["direccion"];
                    personaPedida.Email = (string)drPersona["email"];
                    personaPedida.Telefono = (string)drPersona["telefono"];
                    personaPedida.FechaNacimiento = (DateTime)drPersona["fecha_nac"];
                    if (drPersona["legajo"] != DBNull.Value)
                    {
                        personaPedida.Legajo = (int)drPersona["legajo"];
                    }
                    personaPedida.TipoPersona = (Persona.TipoPersonas)drPersona["tipo_persona"];
                    personaPedida.IDPlan = (int)drPersona["id_plan"];

                }
                drPersona.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al recuperar la Personas.", ex);
            }
            finally
            {
                this.CloseConnection();
            }
            return personaPedida;
        }

        public void Delete(int ID)
        {
            try
            {
                this.OpenConnection();

                SqlCommand cmdDelete = new SqlCommand("Delete personas where id_persona=@id", sqlConn);
                cmdDelete.Parameters.Add("@id", SqlDbType.Int).Value = ID;

                cmdDelete.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar una Persona.", ex);
            }
            finally
            {
                this.CloseConnection();
            }
        }

        public void Update(Persona modifiedPer)
        {
            try
            {
                this.OpenConnection();

                SqlCommand cmdUpdate = new SqlCommand("Update personas set nombre=@nombre, apellido=@apellido," +
                    "direccion=@direccion, email=@email, telefono=@telefono, fecha_nac=@fecha_nac, legajo=@legajo, tipo_persona=@tipo_persona, id_plan=@id_plan" +
                    "Where id_persona=@id", sqlConn);

                cmdUpdate.Parameters.Add("@id", SqlDbType.Int).Value = modifiedPer.ID;
                cmdUpdate.Parameters.Add("@nombre", SqlDbType.VarChar,50).Value = modifiedPer.Nombre;
                cmdUpdate.Parameters.Add("@apellido", SqlDbType.VarChar,50).Value = modifiedPer.Apellido;
                cmdUpdate.Parameters.Add("@direccion", SqlDbType.VarChar,50).Value = modifiedPer.Direccion;
                cmdUpdate.Parameters.Add("@email", SqlDbType.VarChar, 50).Value = modifiedPer.Email;
                cmdUpdate.Parameters.Add("@telefono", SqlDbType.VarChar, 50).Value = modifiedPer.Telefono;
                cmdUpdate.Parameters.Add("@fecha_nac", SqlDbType.VarChar, 50).Value = modifiedPer.FechaNacimiento;
                cmdUpdate.Parameters.Add("@legajo", SqlDbType.VarChar, 50).Value = modifiedPer.Legajo;
                cmdUpdate.Parameters.Add("@tipo_persona", SqlDbType.Int).Value = modifiedPer.TipoPersona;

                cmdUpdate.Parameters.Add("@id_plan", SqlDbType.Int).Value = modifiedPer.IDPlan;


                cmdUpdate.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al actualizar Persona.", ex);
            }
            finally
            {
                this.CloseConnection();
            }
        }

        public void Insert(Persona newPer)
        {
            try
            {
                this.OpenConnection();

                SqlCommand cmdInsert = new SqlCommand("Insert into personas(nombew, apellido, direccion, email, telefono, fecha_nac, legajo, tipo_persona, id_plan)" +
                    "values(@nombre, @apellido, @direccino, @email, @telefono, @fecha_nac, @legajo, @tipo_persona, @id_plan )" + "select @@identity", sqlConn);

                cmdInsert.Parameters.Add("@nombre", SqlDbType.VarChar, 50).Value = newPer.Nombre;
                cmdInsert.Parameters.Add("@apellido", SqlDbType.VarChar, 50).Value = newPer.Apellido;
                cmdInsert.Parameters.Add("@direccion", SqlDbType.VarChar, 50).Value = newPer.Direccion;
                cmdInsert.Parameters.Add("@email", SqlDbType.VarChar, 50).Value = newPer.Email;
                cmdInsert.Parameters.Add("@telefono", SqlDbType.VarChar, 50).Value = newPer.Telefono;
                cmdInsert.Parameters.Add("@fecha_nac", SqlDbType.VarChar, 50).Value = newPer.FechaNacimiento;
                cmdInsert.Parameters.Add("@legajo", SqlDbType.VarChar, 50).Value = newPer.Legajo;
                cmdInsert.Parameters.Add("@tipo_persona", SqlDbType.Int).Value = newPer.TipoPersona;

                cmdInsert.Parameters.Add("@id_plan", SqlDbType.Int).Value = newPer.IDPlan;

                newPer.ID = Decimal.ToInt32((decimal)cmdInsert.ExecuteScalar());
            }
            catch (Exception ex)
            {
                throw new Exception("Error al insertar el Persona.", ex);
            }
            finally
            {
                this.CloseConnection();
            }
        }


        public void Save(Persona persona)
        {
            switch (persona.State)
            {
                case BusinessEntity.States.New: this.Insert(persona); break;
                case BusinessEntity.States.Deleted: this.Delete(persona.ID); break;
                case BusinessEntity.States.Modified: this.Update(persona); break;
                case BusinessEntity.States.Unmodified: break;
            }
        }
    }
}
