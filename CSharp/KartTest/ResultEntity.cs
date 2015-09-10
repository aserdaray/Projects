using KartTest.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KartTest
{
    public class ResultEntity
    {

        public IHeader header { get; set; }
        public List<KartEntity> list { get; set; }
        public Dictionary<IHeader, List<KartEntity>> map { get; set; }


        public ResultEntity()
        {
            this.list = new List <KartEntity>();
            this.map = new Dictionary<IHeader,List<KartEntity>>();


        }

        public void Add(IHeader key, List<KartEntity> value)
        {
            if (map.ContainsKey(key))
            {
                map.Remove(key);
            }
            key.KayitSayisi = list.Count;
            
            this.map.Add(key, value);

        }
    }
}
