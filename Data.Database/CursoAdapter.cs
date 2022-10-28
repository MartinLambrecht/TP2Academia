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
    public class CursoAdapter : Adapter
    {

        private static List<Curso> _Cursos;

        private static List<Curso> Cursos
        {
            get
            {
                if (_Cursos == null)
                {
                    _Cursos = new List<Business.Entities.Curso>();
                    Business.Entities.Curso cur;
                    cur = new Business.Entities.Curso();
                    cur.ID = 1;
                    cur.State = Business.Entities.BusinessEntity.States.Unmodified;
                    cur.AnioCalendario = 2022;
                    cur.Cupo = 20;
                    cur.Descripcion = "Tecnologia de Desarrollos de Software .NET";
                    cur.IDComision = 5;
                    cur.IDMateria = 3;
                    _Cursos.Add(cur);

                    cur = new Business.Entities.Curso();
                    cur.ID = 2;
                    cur.State = Business.Entities.BusinessEntity.States.Unmodified;
                    cur.AnioCalendario = 2022;
                    cur.Cupo = 22;
                    cur.Descripcion = "Paradigma";
                    cur.IDComision = 4;
                    cur.IDMateria = 2;
                    _Cursos.Add(cur);

                }
                return _Cursos;
            }
        }

        public List<Curso> GetAll()
        {
            // return new List<Curso>(Cursos);
            List<Curso> cursos = new List<Curso>();
            try
            {
                this.OpenConnection();

                SqlCommand cmdCursos = new SqlCommand("select * from cursos", sqlConn);

                SqlDataReader drCursos = cmdCursos.ExecuteReader();

                while (drCursos.Read())
                {
                    Curso cur = new Curso();

                    cur.AnioCalendario = (int)drCursos["anio_calendario"];
                    cur.Cupo = (int)drCursos["cupo"];
                    // cur.Descripcion = (string)drCursos["descripcion"];

                    cursos.Add(cur);
                }

                drCursos.Close();
                this.CloseConnection();

                return cursos;
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar lista de cursos", Ex);
                throw ExcepcionManejada;
            }
        }

        public Business.Entities.Curso GetOne(int ID)
        {
            // return Cursos.Find(delegate (Curso c) { return c.ID == ID; });
            Curso curso = new Curso();

            try
            {
                this.OpenConnection();

                SqlCommand cmdCurso = new SqlCommand("select * from cursos where id_curso = @id", sqlConn);

                cmdCurso.Parameters.Add("@id", SqlDbType.Int).Value = ID;

                SqlDataReader drCurso = cmdCurso.ExecuteReader();

                if (drCurso.Read())
                {
                    curso.AnioCalendario = (int)drCurso["anio_calendario"];
                    curso.Cupo = (int)drCurso["cupo"];
                }
                drCurso.Close();
            }

            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar datos del curso", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return curso;
        }

        public void Delete(int ID)
        {
            //Cursos.Remove(this.GetOne(ID));
            try
            {
                this.OpenConnection();

                SqlCommand cmdDelete = new SqlCommand("delete cursos where id_curso=@id", sqlConn);
                cmdDelete.Parameters.Add("@id", SqlDbType.Int).Value = ID;

                cmdDelete.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al eliminar curso", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        public void Update(Curso curso)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdSave = new SqlCommand("UPDATE cursos SET anio_calendario = @anio_calendario, cupo = @cupo" +
                "WHERE id_curso=@id", sqlConn);

                cmdSave.Parameters.Add("@id", SqlDbType.Int).Value = curso.ID;
                cmdSave.Parameters.Add("@anio_calendario", SqlDbType.Int).Value = curso.AnioCalendario;
                cmdSave.Parameters.Add("@cupo", SqlDbType.Int).Value = curso.Cupo;
                cmdSave.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al modificar datos del curso", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        public void Insert(Curso curso)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdSave = new SqlCommand("insert into cursos(anio_calendario,cupo)" +
                 "values (@anio_calendario, @cupo)" +
                  "select @@identity", sqlConn);
                cmdSave.Parameters.Add("anio_calendario", SqlDbType.Int).Value = curso.AnioCalendario;
                cmdSave.Parameters.Add("cupo", SqlDbType.Int).Value = curso.Cupo;
                curso.ID = decimal.ToInt32((decimal)cmdSave.ExecuteScalar());
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al crear curso", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }

        }


        public void Save(Curso curso)
        {
            if (curso.State == BusinessEntity.States.Deleted)
            {
                this.Delete(curso.ID);
            }

            else if (curso.State == BusinessEntity.States.New)
            {
                this.Insert(curso);
            }

            else if (curso.State == BusinessEntity.States.Modified)
            {
                this.Update(curso);
            }
            curso.State = BusinessEntity.States.Unmodified;
        }

    }
}
