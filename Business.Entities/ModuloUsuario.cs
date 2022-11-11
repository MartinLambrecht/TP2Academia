namespace Business.Entities
{
    public class ModuloUsuario : BusinessEntity
    {
        private int _IDModulo;

        public int IDModulo
        { set { _IDModulo = value; } get { return _IDModulo; } }

        private int _IDUsuario;

        public int IDUsuario
        { set { _IDUsuario = value; } get { return _IDUsuario; } }

        private bool _PermiteBaja;

        public bool PermiteBaja
        { set { _PermiteBaja = value; } get { return _PermiteBaja; } }

        private bool _PermiteAlta;

        public bool PermiteAlta
        { set { _PermiteAlta = value; } get { return _PermiteAlta; } }

        private bool _PermiteModificacion;

        public bool PermiteModificacion
        { set { _PermiteModificacion = value; } get { return _PermiteModificacion; } }

        private bool _PermiteConsulta;

        public bool PermiteConsulta
        { set { _PermiteConsulta = value; } get { return _PermiteConsulta; } }
    }
}