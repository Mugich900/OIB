using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OIB_shifrovanie
{
    class Transposition : EncryptionMethod
    {
        string DeleteExcess(string str, string c)
        {
            while (str.Contains(c))
            {
                str = str.Replace(c, "");
            }
            return str;
        }
        string key = "";

        public Transposition(string formolizeText)
        {
            key = formolizeText.ToUpper().Trim();
            //key = DeleteExcess(key, " ");
            key = DeleteExcess(key, ".");
            key = DeleteExcess(key, ",");
            key = DeleteExcess(key, "?");
            key = DeleteExcess(key, "!");
            key = DeleteExcess(key, ":");
            key = DeleteExcess(key, ";");
            key = DeleteExcess(key, "-");
        }

        public override void CreateSubstitutionAlphabet()
        {

        }

        public override string Encryption(string text)
        {
            throw new NotImplementedException();
        }

        public override string Uncryption(string text)
        {
            throw new NotImplementedException();
        }
    }
}
