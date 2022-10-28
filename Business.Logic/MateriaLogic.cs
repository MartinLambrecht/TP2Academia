using Business.Entities;
using Data.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Logic
{
    public class MateriaLogic : BusinessLogic
    {
        private MateriaAdapter MateriaData;

        public MateriaLogic()
        {
            MateriaData = new MateriaAdapter();
        }
        public Materia GetOne(int id)
        {
            return MateriaData.GetOne(id);
        }

        public List<Materia> GetAll()
        {
            return MateriaData.GetAll();
        }

        public void Delete(int id)
        {
            MateriaData.Delete(id);
        }

        public void Save(Materia materia)
        {
            MateriaData.Save(materia);
        }
    }
}
