using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KartTest
{
    public interface IKartFactoryDb
    {
        bool KeyCheck(string key);
        KartEntity Get(string key);
        bool Add(string key, KartEntity value);
        void Edit(string key, KartEntity value);
        void EditSize(string key, short value);

    }
}
