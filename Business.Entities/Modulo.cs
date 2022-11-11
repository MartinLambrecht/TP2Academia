namespace Business.Entities
{
    public class Modulo : BusinessEntity
    {
        private string _Descripcion;

        public string Descripcion
        { set { _Descripcion = value; } get { return _Descripcion; } }
    }
}