using Business.Entities;
using Data.Database.DSInscripcionesTableAdapters;
using Data.Database.DSNotasPorMateriaTableAdapters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using static Data.Database.DSInscripciones;
using static Data.Database.DSNotasPorMateria;

namespace Data.Database
{
    public class AlumnoInscripcionAdapter : Adapter
    {
        public List<AlumnoInscripcion> GetAll()
        {
            List<AlumnoInscripcion> inscripcions = new List<AlumnoInscripcion>();
            try
            {
                this.OpenConnection();

                SqlCommand cmdAlumnoInscripcions = new SqlCommand("Select * from alumnos_inscripciones", sqlConn);

                SqlDataReader drAlumnoInscripcions = cmdAlumnoInscripcions.ExecuteReader();

                while (drAlumnoInscripcions.Read())
                {
                    AlumnoInscripcion inscripcion = new AlumnoInscripcion();

                    inscripcion.ID = (int)drAlumnoInscripcions["id_inscripcion"];
                    inscripcion.IDAlumno = (int)drAlumnoInscripcions["id_alumno"];
                    inscripcion.IDCurso = (int)drAlumnoInscripcions["id_curso"];
                    inscripcion.Condicion = (string)drAlumnoInscripcions["condicion"];
                    if (drAlumnoInscripcions["nota"] != DBNull.Value)
                    {
                        inscripcion.Nota = (int)drAlumnoInscripcions["nota"];
                    }

                    inscripcions.Add(inscripcion);
                }

                drAlumnoInscripcions.Close();
            }
            catch (Exception Ex)
            {
                Exception excepcionManejada = new Exception("Error al recuperar la lista de AlumnoInscripciones", Ex);
                throw excepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return inscripcions;
        }

        public Business.Entities.AlumnoInscripcion GetOne(int ID)
        {
            AlumnoInscripcion inscripcionPedido = new AlumnoInscripcion();
            try
            {
                this.OpenConnection();

                SqlCommand cmdGetOne = new SqlCommand("Select * from alumnos_inscripciones where id_inscripcion=@id", sqlConn);
                cmdGetOne.Parameters.Add("@id", SqlDbType.Int).Value = ID;

                SqlDataReader drAlumnoInscripcion = cmdGetOne.ExecuteReader();
                if (drAlumnoInscripcion.Read())
                {
                    inscripcionPedido.ID = (int)drAlumnoInscripcion["id_inscripcion"];
                    inscripcionPedido.IDAlumno = (int)drAlumnoInscripcion["id_alumno"];
                    inscripcionPedido.IDCurso = (int)drAlumnoInscripcion["id_curso"];
                    inscripcionPedido.Condicion = (string)drAlumnoInscripcion["condicion"];

                    //inscripcionPedido.Nota = drAlumnoInscripcion["nota"] == DBNull.Value ? null : (int)drAlumnoInscripcion["nota"];
                    if (drAlumnoInscripcion["nota"] != DBNull.Value)
                    {
                        inscripcionPedido.Nota = (int)drAlumnoInscripcion["nota"];
                    }
                }
                drAlumnoInscripcion.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al recuperar el AlumnoInscripcion.", ex);
            }
            finally
            {
                this.CloseConnection();
            }
            return inscripcionPedido;
        }

        public DSNotasPorMateria GetDSNotasPorMateria()
        {
            var dataSet = new DSNotasPorMateria();

            NotasPorMateriaTableAdapter da = new NotasPorMateriaTableAdapter();
            da.Fill((NotasPorMateriaDataTable)dataSet.Tables["NotasPorMateria"]);

            return dataSet;
        }

        public DSInscripciones GetDSInscripciones()
        {
            var dataSet = new DSInscripciones();

            InscripcionesTableAdapter daInscripcion = new InscripcionesTableAdapter();
            daInscripcion.Fill((InscripcionesDataTable)dataSet.Tables["Inscripciones"]);

            CursoDisponiblesConDescripcionTableAdapter daCursoDisponibleConDescripcion = new CursoDisponiblesConDescripcionTableAdapter();
            daCursoDisponibleConDescripcion.Fill((CursoDisponiblesConDescripcionDataTable)dataSet.Tables["CursoDisponiblesConDescripcion"]);

            CupoPorMateriaTableAdapter daCupoPorMateria = new CupoPorMateriaTableAdapter();
            daCupoPorMateria.Fill((CupoPorMateriaDataTable)dataSet.Tables["CupoPorMateria"]);

            return dataSet;
        }

        public void Delete(int ID)
        {
            try
            {
                this.OpenConnection();

                SqlCommand cmdDelete = new SqlCommand("Delete alumnos_inscripciones where id_inscripcion=@id", sqlConn);
                cmdDelete.Parameters.Add("@id", SqlDbType.Int).Value = ID;

                cmdDelete.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar un AlumnoInscripcion.", ex);
            }
            finally
            {
                this.CloseConnection();
            }
        }

        public void Update(AlumnoInscripcion modifiedInscripcion)
        {
            try
            {
                this.OpenConnection();

                SqlCommand cmdUpdate = new SqlCommand("Update alumnos_inscripciones set id_alumno=@id_alumno," +
                    "id_curso=@id_curso, condicion=@condicion, nota=@nota " +
                    "Where id_inscripcion=@id", sqlConn);

                cmdUpdate.Parameters.Add("@id", SqlDbType.Int).Value = modifiedInscripcion.ID;
                cmdUpdate.Parameters.Add("@id_alumno", SqlDbType.Int).Value = modifiedInscripcion.IDAlumno;
                cmdUpdate.Parameters.Add("@id_curso", SqlDbType.Int).Value = modifiedInscripcion.IDCurso;
                cmdUpdate.Parameters.Add("@condicion", SqlDbType.VarChar, 50).Value = modifiedInscripcion.Condicion;

                //cmdUpdate.Parameters.Add("@nota", SqlDbType.Int).Value = modifiedInscripcion.Nota is null ? DBNull.Value : modifiedInscripcion.Nota;
                if (modifiedInscripcion.Nota is null)
                {
                    cmdUpdate.Parameters.Add("@nota", SqlDbType.Int).Value = DBNull.Value;
                }
                else
                {
                    cmdUpdate.Parameters.Add("@nota", SqlDbType.Int).Value = modifiedInscripcion.Nota;
                }

                cmdUpdate.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al actualizar AlumnoInscripcion.", ex);
            }
            finally
            {
                this.CloseConnection();
            }
        }

        public void Insert(AlumnoInscripcion newInscripcion)
        {
            try
            {
                this.OpenConnection();

                SqlCommand cmdInsert = new SqlCommand("Insert into alumnos_inscripciones(id_alumno, id_curso, condicion, nota)" +
                    "values(@id_alumno, @id_curso, @condicion, @nota )" + "select @@identity", sqlConn);

                cmdInsert.Parameters.Add("@id", SqlDbType.Int).Value = newInscripcion.ID;
                cmdInsert.Parameters.Add("@id_alumno", SqlDbType.Int).Value = newInscripcion.IDAlumno;
                cmdInsert.Parameters.Add("@id_curso", SqlDbType.Int).Value = newInscripcion.IDCurso;
                cmdInsert.Parameters.Add("@condicion", SqlDbType.VarChar, 50).Value = newInscripcion.Condicion;
                if (newInscripcion.Nota is null)
                {
                    cmdInsert.Parameters.Add("@nota", SqlDbType.Int).Value = DBNull.Value;
                }
                else
                {
                    cmdInsert.Parameters.Add("@nota", SqlDbType.Int).Value = newInscripcion.Nota;
                }

                newInscripcion.ID = Decimal.ToInt32((decimal)cmdInsert.ExecuteScalar());
            }
            catch (Exception ex)
            {
                throw new Exception("Error al insertar el AlumnoInscripcion.", ex);
            }
            finally
            {
                this.CloseConnection();
            }
        }

        public void Save(AlumnoInscripcion inscripcion)
        {
            switch (inscripcion.State)
            {
                case BusinessEntity.States.New: this.Insert(inscripcion); break;
                case BusinessEntity.States.Deleted: this.Delete(inscripcion.ID); break;
                case BusinessEntity.States.Modified: this.Update(inscripcion); break;
                case BusinessEntity.States.Unmodified: break;
            }
        }
    }
}