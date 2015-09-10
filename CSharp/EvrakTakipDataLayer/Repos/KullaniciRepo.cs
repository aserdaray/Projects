using EvrakTakipDataLayer.DbModel;
using EvrakTakipDataLayer.Generic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvrakTakipDataLayer.Repos
{
    [DataObject(true)]
    public class KullaniciRepo : GenericRepository<Kullanici>
    {
        [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, true)]
        public IQueryable<Kullanici> GetAll()
        {
            return base.GetAll();

        }

        [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Insert, true)]
        public Kullanici Add(Kullanici entity)
        {
            return base.Add(entity);
        }

        [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Delete, true)]
        public void Delete(Kullanici entity)
        {
            base.Delete(entity);
        }

        [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Update, true)]
        public void Edit(Kullanici entity)
        {
            base.Edit(entity);
        }

        public void GetAllWihtDepartman()
        {
           // return _entities.KullaniciView;

          /*  var x = (from k in _entities.Kullanici
                     join d in _entities.Departman on k.DepartmanId equals d.departmanId
                     select new { 
                    k.KullaniciId, 
                    k.AdiSoyadi ,
                    k.Adi ,
                    k.Mail ,
                    k.SilindiMi ,
                    k.DepartmanId ,
                    
                    d.departmanId ,
                    d.departmanAdi ,
                    d.deptNo ,
                    d.deptTur ,
                    d.bmKodAdi 
                      });
            

            return x;*/
        }
        


    }

}
