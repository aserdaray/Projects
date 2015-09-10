using EvrakTakipDataLayer.DbModel;
using EvrakTakipDataLayer.Generic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvrakTakipDataLayer.Repos
{
    [DataObject(true)]
    public class BirimRepo : GenericRepository<Birim>
    {

        public IQueryable<Birim> GetAll()
        {
            return base.GetAll();

        }

        public void Add(Birim entity)
        {
            base.Add(entity);
        }

        public void Delete(Birim entity)
        {
            base.Delete(entity);
        }

        public void Edit(Birim entity)
        {
            base.Edit(entity);
        }

        public Birim getByBirimId(int birimId)
        {
            return base.FindBy(k => k.BirimId == birimId).FirstOrDefault();
           
        }




    }

}
