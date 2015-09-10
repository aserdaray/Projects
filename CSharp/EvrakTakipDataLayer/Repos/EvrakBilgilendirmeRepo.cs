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
    public class EvrakBilgilendirmeRepo : GenericRepository<EvrakBilgilendirme> 
    {
        [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, true)]
        public IQueryable<EvrakBilgilendirme> GetAll()
        {
            return base.GetAll();

        }

        [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Insert, true)]
        public void Add(EvrakBilgilendirme entity)
        {
            base.Add(entity);
        }

        [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Delete, true)]
        public void Delete(EvrakBilgilendirme entity)
        {
            base.Delete(entity);
        }

        [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Update, true)]
        public void Edit(EvrakBilgilendirme entity)
        {
            base.Edit(entity);
        }

        
    }

}
