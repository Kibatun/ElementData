using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItemData
{
    internal class ParamProps       //Класс, куда записаны два поля из параметров
    {
        private string name;
        private string val;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public string Value
        {
            get { return val; }
            set { val = value; }
        }
    }
}
