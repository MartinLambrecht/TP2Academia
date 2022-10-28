using Business.Entities;
using Data.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
