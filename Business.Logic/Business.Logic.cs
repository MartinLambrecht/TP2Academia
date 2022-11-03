using System.Linq;

namespace Business.Logic
{
    public class BusinessLogic
    {
    }

    public static class Validaciones
    {
        public static bool IsValidEmail(string email)
        {
            var trimmedEmail = email.Trim();

            if (trimmedEmail.EndsWith("."))
            {
                return false;
            }
            try
            {
                new System.Net.Mail.MailAddress(email);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool IsValidPassword(string password)
        {
            return password.Trim().Length > 8;
        }

        public static bool HasAuthorization(int idUsuario, int idModulo, Permisos permiso)
        {
            var listModuloUsuario = new ModuloUsuarioLogic().GetAll();
            listModuloUsuario = listModuloUsuario.FindAll(mu => mu.IDUsuario == idUsuario && mu.IDModulo == idModulo);

            switch (permiso)
            {
                case Permisos.Alta:
                    return listModuloUsuario.Any(mu => mu.PermiteAlta);
                case Permisos.Baja:
                    return listModuloUsuario.Any(mu => mu.PermiteBaja);
                case Permisos.Modificacion:
                    return listModuloUsuario.Any(mu => mu.PermiteModificacion);
                case Permisos.Consulta:
                    return listModuloUsuario.Any(mu => mu.PermiteConsulta);
                default:
                    return false;
            }
        }

        public enum Permisos
        {
            Alta, Baja, Modificacion, Consulta
        }
    }
}