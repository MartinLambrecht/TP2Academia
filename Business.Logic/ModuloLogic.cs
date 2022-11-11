using Business.Entities;
using Data.Database;
using System.Collections.Generic;

namespace Business.Logic
{
    public class ModulosLogic : BusinessLogic
    {
        private ModuloAdapter ModuloData;

        public ModulosLogic()
        {
            ModuloData = new ModuloAdapter();
        }

        public Modulo GetOne(int id)
        {
            return ModuloData.GetOne(id);
        }

        public List<Modulo> GetAll()
        {
            return ModuloData.GetAll();
        }

        public void Delete(int id)
        {
            ModuloData.Delete(id);
        }

        public void Save(Modulo usuario)
        {
            ModuloData.Save(usuario);
        }
    }
}