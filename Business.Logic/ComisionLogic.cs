using Business.Entities;
using Data.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Business.Logic
{
    public class ComisionLogic : BusinessLogic
    {
        private ComisionAdapter ComisionData;

        public ComisionLogic()
        {
            ComisionData = new ComisionAdapter();
        }
        public Comision GetOne(int id)
        {
            return ComisionData.GetOne(id);
        }

        public List<Comision> GetAll()
        {
            return ComisionData.GetAll();
        }

        public void Delete(int id)
        {
            ComisionData.Delete(id);
        }

        public void Save(Comision comision)
        {
            ComisionData.Save(comision);
        }
    }
}
