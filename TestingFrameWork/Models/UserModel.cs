using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingFrameWork.Models
{
    class UserModel
    {
        public string name;
        public string lastname;
        public string thirdname;
        public string birthday;
        public string pasport;
        public string phoneNumber;
        public string mail;
        public CardModel card;

        public UserModel(string n, string ln, string tn, string b, string p, string ph, string m, CardModel card)
        {
            name = n;
            lastname = ln;
            thirdname = tn;
            birthday = b;
            pasport = p;
            phoneNumber = ph;
            mail = m;
            this.card = card;
        }

        public static UserModel UserWithoutNumber()
        {
            return new UserModel("Гаргарин", "Дмитрий", "Станиславович", "25.05.2000", "3803818", null, "dgargarin@mail.ru",
                new CardModel("INSTANT CARD", "4255 2003 0160 1662", "454", 2, 20));
        }

        public static UserModel UserWithoutCard()
        {
            return new UserModel("Гаргарин", "Дмитрий", "Станиславович", "25.05.2000", "3803818", "375292783083", "dgargarin@mail.ru", null);
        }

        public static UserModel DefaultUser()
        {
            return new UserModel("Гаргарин", "Дмитрий", "Станиславович", "25.05.2000", "3803818", "375292783083", "dgargarin@mail.ru",
                new CardModel("INSTANT CARD", "4255 2003 0160 1662", "454", 2, 20));
        }
    }
}
