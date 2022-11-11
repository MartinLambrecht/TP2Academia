namespace Business.Entities
{
    public class Especialidad : BusinessEntity
    {
        private string _Descripcion;

        public string Descripcion
        { set { _Descripcion = value; } get { return _Descripcion; } }
    }
}