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
    public class ProgramHataRepo : GenericRepository<ProgramHata> 
    {
        [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, true)]
        public IQueryable<ProgramHata> GetAll()
        {
            return base.GetAll();

        }

        [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Insert, true)]
        public ProgramHata Add(ProgramHata entity)
        {
           return  base.Add(entity);
        }

        [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Delete, true)]
        public void Delete(ProgramHata entity)
        {
            base.Delete(entity);
        }

        [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Update, true)]
        public void Edit(ProgramHata entity)
        {
            base.Edit(entity);
        }

        
    }

}
