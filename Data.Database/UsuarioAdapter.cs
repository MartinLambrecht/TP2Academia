using Business.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace Data.Database
{
    public class UsuarioAdapter : Adapter
    {
        public List<Usuario> GetAll()
        {
            List<Usuario> usuarios = new List<Usuario>();
            try
            {
                this.OpenConnection();

                SqlCommand cmdUsuarios = new SqlCommand("Select * from usuarios", sqlConn);

                SqlDataReader drUsuarios = cmdUsuarios.ExecuteReader();

                while (drUsuarios.Read())
                {
                    Usuario usr = new Usuario();

                    usr.ID = (int)drUsuarios["id_usuario"];
                    usr.NombreUsuario = (string)drUsuarios["nombre_usuario"];
                    usr.Clave = (string)drUsuarios["clave"];
                    usr.Habilitado = (bool)drUsuarios["habilitado"];
                    usr.Nombre = (string)drUsuarios["nombre"];
                    usr.Apellido = (string)drUsuarios["apellido"];
                    usr.Email = (string)drUsuarios["email"];
                    if (drUsuarios["id_persona"] != DBNull.Value)
                    {
                        usr.IDPersona = (int)drUsuarios["id_persona"];
                    }

                    usuarios.Add(usr);
                }

                drUsuarios.Close();
            }
            catch (Exception Ex)
            {
                Exception excepcionManejada = new Exception("Error al recuperar la lista de Usuarios", Ex);
                throw excepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return usuarios;
        }

        public Business.Entities.Usuario GetOne(int ID)
        {
            Usuario usuarioPedido = new Usuario();
            try
            {
                this.OpenConnection();

                SqlCommand cmdGetOne = new SqlCommand("Select * from usuarios where id_usuario=@id", sqlConn);
                cmdGetOne.Parameters.Add("@id", SqlDbType.Int).Value = ID;

                SqlDataReader drUsuario = cmdGetOne.ExecuteReader();
                if (drUsuario.Read())
                {
                    usuarioPedido.ID = (int)drUsuario["id_usuario"];
                    usuarioPedido.NombreUsuario = (string)drUsuario["nombre_usuario"];
                    usuarioPedido.Clave = (string)drUsuario["clave"];
                    usuarioPedido.Habilitado = (bool)drUsuario["habilitado"];
                    usuarioPedido.Nombre = (string)drUsuario["nombre"];
                    usuarioPedido.Apellido = (string)drUsuario["apellido"];
                    usuarioPedido.Email = (string)drUsuario["email"];
                    if (drUsuario["id_persona"] != DBNull.Value)
                    {
                        usuarioPedido.IDPersona = (int)drUsuario["id_persona"];
                    }
                }
                drUsuario.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al recuperar el usuario.", ex);
            }
            finally
            {
                this.CloseConnection();
            }
            return usuarioPedido;
        }

        public void Delete(int ID)
        {
            try
            {
                this.OpenConnection();

                SqlCommand cmdDelete = new SqlCommand("Delete usuarios where id_usuario=@id", sqlConn);
                cmdDelete.Parameters.Add("@id", SqlDbType.Int).Value = ID;

                cmdDelete.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar un usuario.", ex);
            }
            finally
            {
                this.CloseConnection();
            }
        }

        public void Update(Usuario modifiedUsr)
        {
            try
            {
                this.OpenConnection();

                SqlCommand cmdUpdate = new SqlCommand("Update usuarios set nombre_usuario=@nombre_usuario, clave=@clave," +
                    "habilitado=@habilitado, nombre=@nombre, apellido=@apellido, email=@email, id_persona=@id_persona  " +
                    "Where id_usuario=@id", sqlConn);

                cmdUpdate.Parameters.Add("@id", SqlDbType.Int).Value = modifiedUsr.ID;
                cmdUpdate.Parameters.Add("@nombre_usuario", SqlDbType.VarChar).Value = modifiedUsr.NombreUsuario;
                cmdUpdate.Parameters.Add("@clave", SqlDbType.VarChar).Value = modifiedUsr.Clave;
                cmdUpdate.Parameters.Add("@habilitado", SqlDbType.Bit).Value = modifiedUsr.Habilitado;
                cmdUpdate.Parameters.Add("@nombre", SqlDbType.VarChar).Value = modifiedUsr.Nombre;
                cmdUpdate.Parameters.Add("@apellido", SqlDbType.VarChar).Value = modifiedUsr.Apellido;
                cmdUpdate.Parameters.Add("@email", SqlDbType.VarChar).Value = modifiedUsr.Email;

                if (modifiedUsr.IDPersona is 0)
                {
                    cmdUpdate.Parameters.Add("@id_persona", SqlDbType.Int).Value = DBNull.Value;
                }
                else
                {
                    cmdUpdate.Parameters.Add("@id_persona", SqlDbType.Int).Value = modifiedUsr.IDPersona;
                }

                cmdUpdate.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al actualizar Usuario.", ex);
            }
            finally
            {
                this.CloseConnection();
            }
        }

        public void Insert(Usuario newUsr)
        {
            try
            {
                this.OpenConnection();

                SqlCommand cmdInsert = new SqlCommand("Insert into usuarios(nombre_usuario, clave, habilitado, nombre, apellido, email, id_persona)" +
                    "values(@nombre_usuario, @clave, @habilitado, @nombre, @apellido, @email, @id_persona)" + "select @@identity", sqlConn);

                cmdInsert.Parameters.Add("@nombre_usuario", SqlDbType.VarChar).Value = newUsr.NombreUsuario;
                cmdInsert.Parameters.Add("@clave", SqlDbType.VarChar).Value = newUsr.Clave;
                cmdInsert.Parameters.Add("@habilitado", SqlDbType.Bit).Value = newUsr.Habilitado;
                cmdInsert.Parameters.Add("@nombre", SqlDbType.VarChar).Value = newUsr.Nombre;
                cmdInsert.Parameters.Add("@apellido", SqlDbType.VarChar).Value = newUsr.Apellido;
                cmdInsert.Parameters.Add("@email", SqlDbType.VarChar).Value = newUsr.Email;

                if (newUsr.IDPersona is 0)
                {
                    cmdInsert.Parameters.Add("@id_persona", SqlDbType.Int).Value = DBNull.Value;
                }
                else
                {
                    cmdInsert.Parameters.Add("@id_persona", SqlDbType.Int).Value = newUsr.IDPersona;
                }


                newUsr.ID = Decimal.ToInt32((decimal)cmdInsert.ExecuteScalar());
            }
            catch (Exception ex)
            {
                throw new Exception("Error al insertar el Usuario.", ex);
            }
            finally
            {
                this.CloseConnection();
            }
        }


        public void Save(Usuario usuario)
        {
            switch (usuario.State)
            {
                case BusinessEntity.States.New: this.Insert(usuario); break;
                case BusinessEntity.States.Deleted: this.Delete(usuario.ID); break;
                case BusinessEntity.States.Modified: this.Update(usuario); break;
                case BusinessEntity.States.Unmodified: break;
            }
        }
    }
}
