namespace Business.Entities
{
    public class Usuario : BusinessEntity
    {
        private string _Apellido;

        public string Apellido
        { set { _Apellido = value; } get { return _Apellido; } }

        private string _Clave;

        public string Clave
        { set { _Clave = value; } get { return _Clave; } }

        private string _Email;

        public string Email
        { set { _Email = value; } get { return _Email; } }

        private bool _Habilitado;

        public bool Habilitado
        { set { _Habilitado = value; } get { return _Habilitado; } }

        private string _Nombre;

        public string Nombre
        { set { _Nombre = value; } get { return _Nombre; } }

        private string _NombreUsuario;

        public string NombreUsuario
        { set { _NombreUsuario = value; } get { return _NombreUsuario; } }

        private int _IDPersona;

        public int IDPersona
        { set { _IDPersona = value; } get { return _IDPersona; } }
    }
}