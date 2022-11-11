namespace Business.Entities
{
    public class Materia : BusinessEntity
    {
        private string _Descripcion;

        public string Descripcion
        { set { _Descripcion = value; } get { return _Descripcion; } }

        private int _HSSemanales;

        public int HSSemanales
        { set { _HSSemanales = value; } get { return _HSSemanales; } }

        private int _HSTotales;

        public int HSTotales
        { set { _HSTotales = value; } get { return _HSTotales; } }

        private int _IDPlan;

        public int IDPlan
        { set { _IDPlan = value; } get { return _IDPlan; } }
    }
}