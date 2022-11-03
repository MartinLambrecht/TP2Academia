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
    public class ModuloUsuarioAdapter : Adapter
    {
        public List<ModuloUsuario> GetAll()
        {
            try
            {
                List<ModuloUsuario> listaModuloUsuario = new List<ModuloUsuario>();

                this.OpenConnection();
                SqlCommand cmdGetAll = new SqlCommand("SELECT * From modulos_usuarios", sqlConn);
                SqlDataReader drModuloUsuario = cmdGetAll.ExecuteReader();

                while (drModuloUsuario.Read())
                {
                    ModuloUsuario moduloUsuarioActual = new ModuloUsuario();

                    moduloUsuarioActual.ID = (int)drModuloUsuario["id_modulo_usuario"];
                    moduloUsuarioActual.IDModulo = (int)drModuloUsuario["id_modulo"];
                    moduloUsuarioActual.IDUsuario = (int)drModuloUsuario["id_usuario"];

                    moduloUsuarioActual.PermiteAlta = (bool)drModuloUsuario["alta"];
                    moduloUsuarioActual.PermiteBaja = (bool)drModuloUsuario["baja"];
                    moduloUsuarioActual.PermiteModificacion = (bool)drModuloUsuario["modificacion"];
                    moduloUsuarioActual.PermiteConsulta = (bool)drModuloUsuario["consulta"];

                    listaModuloUsuario.Add(moduloUsuarioActual);
                }
                drModuloUsuario.Close();

                return listaModuloUsuario;

            }
            catch (Exception ex)
            {
                throw new Exception("Error al recuperar ModuloUsuario.", ex);
            }
            finally
            {
                this.CloseConnection();
            }
        }

       

        public Business.Entities.ModuloUsuario GetOne(int ID)
        {
            try
            {
                ModuloUsuario moduloUsuarioActual = new ModuloUsuario();

                this.OpenConnection();
                SqlCommand cmdGetOne = new SqlCommand("SELECT * from modulos_usuarios WHERE id_modulo_usuario = @id", sqlConn);
                cmdGetOne.Parameters.Add("@id", SqlDbType.Int).Value = ID;

                SqlDataReader drModuloUsuario = cmdGetOne.ExecuteReader();

                if (drModuloUsuario.Read())
                {
                    moduloUsuarioActual.ID = (int)drModuloUsuario["id_modulo_usuario"];
                    moduloUsuarioActual.IDModulo = (int)drModuloUsuario["id_modulo"];
                    moduloUsuarioActual.IDUsuario = (int)drModuloUsuario["id_usuario"];

                    moduloUsuarioActual.PermiteAlta = (bool)drModuloUsuario["alta"];
                    moduloUsuarioActual.PermiteBaja = (bool)drModuloUsuario["baja"];
                    moduloUsuarioActual.PermiteModificacion = (bool)drModuloUsuario["modificacion"];
                    moduloUsuarioActual.PermiteConsulta = (bool)drModuloUsuario["consulta"];
                }
                drModuloUsuario.Close();

                return moduloUsuarioActual;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al recuperar el moduloUsuario.", ex);
            }
            finally
            {
                this.CloseConnection();
            }
        }

        public void Delete(int ID)
        {
            try
            {
                this.OpenConnection();

                SqlCommand cmdDelete = new SqlCommand("DELETE modulos_usuarios FROM modulos_usuarios WHERE id_modulo_usuario = @id", sqlConn);
                cmdDelete.Parameters.Add("@id", SqlDbType.Int).Value = ID;

                cmdDelete.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar el moduloUsuarios.", ex);
            }
            finally
            {
                this.CloseConnection();
            }
        }

        public void Update(ModuloUsuario moduloUsuarioActual)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdUpdate = new SqlCommand("Update modulos_usuarios set id_modulo=@id_modulo, id_usuario=@id_usuario, alta=@alta, baja=@baja, modificacion=@modificacion, consulta=@consulta Where id_modulo_usuario=@id", sqlConn);
                cmdUpdate.Parameters.Add("@id", SqlDbType.Int).Value = moduloUsuarioActual.ID;
                cmdUpdate.Parameters.Add("@id_modulo", SqlDbType.Int).Value = moduloUsuarioActual.IDModulo;
                cmdUpdate.Parameters.Add("@id_usuario", SqlDbType.Int).Value = moduloUsuarioActual.IDUsuario;

                cmdUpdate.Parameters.Add("@alta", SqlDbType.Bit).Value = moduloUsuarioActual.PermiteAlta;
                cmdUpdate.Parameters.Add("@baja", SqlDbType.Bit).Value = moduloUsuarioActual.PermiteBaja;
                cmdUpdate.Parameters.Add("@modificacion", SqlDbType.Bit).Value = moduloUsuarioActual.PermiteModificacion;
                cmdUpdate.Parameters.Add("@consulta", SqlDbType.Bit).Value = moduloUsuarioActual.PermiteConsulta;

                cmdUpdate.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al actualizar el moduloUsuario.", ex);
            }
            finally
            {
                this.CloseConnection();
            }
        }

        public void Insert(ModuloUsuario moduloUsuarioActual)
        {
            try
            {
                this.OpenConnection();

                SqlCommand cmdInsert = new SqlCommand("Insert into modulos_usuarios(id_modulo,id_usuario,alta,baja,modificacion,consulta)" +
                        "values(@id_modulo,@id_usuario, @alta,@baja,@modificacion,@consulta)" + "select @@identity", sqlConn);

                cmdInsert.Parameters.Add("@id_modulo", SqlDbType.Int).Value = moduloUsuarioActual.IDModulo;
                cmdInsert.Parameters.Add("@id_usuario", SqlDbType.Int).Value = moduloUsuarioActual.IDUsuario;

                cmdInsert.Parameters.Add("@alta", SqlDbType.Bit).Value = moduloUsuarioActual.PermiteAlta;
                cmdInsert.Parameters.Add("@baja", SqlDbType.Bit).Value = moduloUsuarioActual.PermiteBaja;
                cmdInsert.Parameters.Add("@modificacion", SqlDbType.Bit).Value = moduloUsuarioActual.PermiteModificacion;
                cmdInsert.Parameters.Add("@consulta", SqlDbType.Bit).Value = moduloUsuarioActual.PermiteConsulta;

                moduloUsuarioActual.ID = Decimal.ToInt32((decimal)cmdInsert.ExecuteScalar());
            }
            catch (Exception ex)
            {
                throw new Exception("Error al insertar moduloUsuario.", ex);
            }
            finally
            {
                this.CloseConnection();
            }
        }

        public void Save(ModuloUsuario modulo)
        {
            switch (modulo.State)
            {
                case BusinessEntity.States.New: this.Insert(modulo); break;
                case BusinessEntity.States.Deleted: this.Delete(modulo.ID); break;
                case BusinessEntity.States.Modified: this.Update(modulo); break;
                case BusinessEntity.States.Unmodified: break;
            }
        }
    }
}
