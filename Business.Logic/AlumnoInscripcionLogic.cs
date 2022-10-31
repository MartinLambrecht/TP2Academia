using Business.Entities;
using Data.Database;
using System.Collections.Generic;

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

        public void Save(AlumnoInscripcion alumnoInscripcion)
        {
            AlumnoInscripcionAdapter.Save(alumnoInscripcion);
        }
    }
}