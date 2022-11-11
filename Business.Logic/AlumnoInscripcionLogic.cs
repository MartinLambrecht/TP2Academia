using Business.Entities;
using Data.Database;
using Data.Database.DSInscripcionesTableAdapters;
using System.Collections.Generic;
using static Data.Database.DSInscripciones;

namespace Business.Logic
{
    public class AlumnoInscripcionLogic : BusinessLogic
    {
        private AlumnoInscripcionAdapter AlumnoInscripcionAdapter;

        public AlumnoInscripcionLogic()
        {
            AlumnoInscripcionAdapter = new AlumnoInscripcionAdapter();
        }

        public AlumnoInscripcion GetOne(int id)
        {
            return AlumnoInscripcionAdapter.GetOne(id);
        }

        public List<AlumnoInscripcion> GetAll()
        {
            return AlumnoInscripcionAdapter.GetAll();
        }

        public void Delete(int id)
        {
            AlumnoInscripcionAdapter.Delete(id);
        }

        public InscripcionesDataTable GetInscripciones()
        {
            var inscripciones = new InscripcionesTableAdapter().GetData();
            return inscripciones;
        }

        public void Save(AlumnoInscripcion alumnoInscripcion)
        {
            AlumnoInscripcionAdapter.Save(alumnoInscripcion);
        }
    }
}