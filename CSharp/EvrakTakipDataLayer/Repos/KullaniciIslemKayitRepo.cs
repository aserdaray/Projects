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
    public class KullaniciIslemKayitRepo : GenericRepository<KullaniciIslemKayit> 
    {
        [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, true)]
        public IQueryable<KullaniciIslemKayit> GetAll()
        {
            return base.GetAll();

        }

        [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Insert, true)]
        public KullaniciIslemKayit Add(KullaniciIslemKayit entity)
        {
            entity.Tarih = DateTime.Now;
           return  base.Add(entity);
        }

        [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Delete, true)]
        public void Delete(KullaniciIslemKayit entity)
        {
            base.Delete(entity);
        }

        [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Update, true)]
        public void Edit(KullaniciIslemKayit entity)
        {
            base.Edit(entity);
        }

        
    }

}
