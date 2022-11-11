using Business.Entities;
using Data.Database;
using Data.Database.DSInscripcionesTableAdapters;
using System.Collections.Generic;
using static Data.Database.DSInscripciones;

namespace Business.Logic
{
    public class CursoLogic : BusinessLogic
    {
        private CursoAdapter CursoData;

        public CursoLogic()
        {
            CursoData = new CursoAdapter();
        }

        public Curso GetOne(int id)
        {
            return CursoData.GetOne(id);
        }

        public List<Curso> GetAll()
        {
            return CursoData.GetAll();
        }

        public CursoDisponiblesConDescripcionDataTable GetCursosDisponiblesConDescripcion()
        {
            var cursos = new CursoDisponiblesConDescripcionTableAdapter().GetData();
            return cursos;
        }

        public void Delete(int id)
        {
            CursoData.Delete(id);
        }

        public void Save(Curso curso)
        {
            CursoData.Save(curso);
        }
    }
}