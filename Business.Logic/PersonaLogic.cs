using Business.Entities;
using Data.Database;
using Data.Database.DSInscripcionesTableAdapters;
using Data.Database.DSPersonasTableAdapters;
using System.Collections.Generic;
using static Data.Database.DSInscripciones;
using static Data.Database.DSPersonas;

namespace Business.Logic
{
    public class PersonaLogic : BusinessLogic
    {
        private PersonaAdapter PersonaData;

        public PersonaLogic()
        {
            PersonaData = new PersonaAdapter();
        }

        public Persona GetOne(int id)
        {
            return PersonaData.GetOne(id);
        }

        public List<Persona> GetAll()
        {
            return PersonaData.GetAll();
        }

        public PersonasConDescripcionDataTable GetPersonasConDescripcion()
        {
            return new PersonasConDescripcionTableAdapter().GetData();
        }

        public AlumnosConDescripcionDataTable GetAlumnosConDescripcion()
        {
            return new AlumnosConDescripcionTableAdapter().GetData();
        }

        public void Delete(int id)
        {
            PersonaData.Delete(id);
        }

        public void Save(Persona usuario)
        {
            PersonaData.Save(usuario);
        }
    }
}