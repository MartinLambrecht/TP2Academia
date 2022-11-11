using System;

namespace Business.Entities
{
    public class Persona : BusinessEntity
    {
        private string _Apellido;

        public string Apellido
        { set { _Apellido = value; } get { return _Apellido; } }

        private string _Direccion;

        public string Direccion
        { set { _Direccion = value; } get { return _Direccion; } }

        private string _Email;

        public string Email
        { set { _Email = value; } get { return _Email; } }

        private DateTime _FechaNacimiento;

        public DateTime FechaNacimiento
        { set { _FechaNacimiento = value; } get { return _FechaNacimiento; } }

        private int _IDPlan;

        public int IDPlan
        { set { _IDPlan = value; } get { return _IDPlan; } }

        private int _Legajo;

        public int Legajo
        { set { _Legajo = value; } get { return _Legajo; } }

        private string _Nombre;

        public string Nombre
        { set { _Nombre = value; } get { return _Nombre; } }

        private string _Telefono;

        public string Telefono
        { set { _Telefono = value; } get { return _Telefono; } }

        private TipoPersonas _TipoPersona;

        public TipoPersonas TipoPersona
        { set { _TipoPersona = value; } get { return _TipoPersona; } }

        public enum TipoPersonas
        { Administrativo, Docente, Estudiante }
    }
}