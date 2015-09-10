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
    public class EvrakKullaniciRepo : GenericRepository<EvrakKullanici> 
    {
        [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, true)]
        public IQueryable<EvrakKullanici> GetAll()
        {
            return base.GetAll();

        }

        [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Insert, true)]
        public void Add(EvrakKullanici entity)
        {
            base.Add(entity);
        }

        [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Delete, true)]
        public void Delete(EvrakKullanici entity)
        {
            base.Delete(entity);
        }

        [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Update, true)]
        public void Edit(EvrakKullanici entity)
        {
            base.Edit(entity);
        }


        public IQueryable<EvrakKullanici> FindBy(System.Linq.Expressions.Expression<Func<EvrakKullanici, bool>> predicate)
        {

            IQueryable<EvrakKullanici> query = _entities.Set<EvrakKullanici>().Where(predicate);
            return query;
        }

        
    }

}
