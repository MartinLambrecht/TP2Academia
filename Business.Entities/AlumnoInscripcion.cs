namespace Business.Entities
{
    public class AlumnoInscripcion : BusinessEntity
    {
        private string _Condicion;
        public string Condicion
        { set { _Condicion = value; } get { return _Condicion; } }

        private int _IDAlumno;
        public int IDAlumno
        { set { _IDAlumno = value; } get { return _IDAlumno; } }

        private int _IDCurso;
        public int IDCurso
        { set { _IDCurso = value; } get { return _IDCurso; } }

        private int? _Nota;
        public int? Nota
        { set { _Nota = value; } get { return _Nota; } }
    }
}