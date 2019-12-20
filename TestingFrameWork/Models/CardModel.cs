using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingFrameWork.Models
{
    class CardModel
    {
        public string name;
        public string number;
        public string code;
        public int month;
        public int year;

        public CardModel(string name, string n, string c, int m, int y)
        {
            this.name = name;
            number = n;
            code = c;
            month = m;
            year = y;
        }
    }
}
