using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OIB_shifrovanie
{
    class Monoalphabet : EncryptionMethod
    {
        string DeleteExcess(string str, string c)
        {
            while(str.Contains(c))
            {
                str = str.Replace(c, "");
            }
            return str;
        }
        string key = "";
        public Monoalphabet(string formolizeText)
        {
            key = formolizeText.ToUpper().Trim();
            key = DeleteExcess(key, " ");
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
            for (int i = 0; i < key.Length; i++)
            {
                for (int j = 0; j < key.Length; j++)
                {
                    if(key[i] == key[j] && i!=j)
                    {
                        key = key.Remove(j, 1);
                    }
                }
            }
            int g = key.Length;
        }

        public override string Encryption(string text)
        {
            text = text.ToUpper().Trim();
            text = DeleteExcess(text, ".");
            text = DeleteExcess(text, ",");
            text = DeleteExcess(text, "?");
            text = DeleteExcess(text, "!");
            text = DeleteExcess(text, ":");
            text = DeleteExcess(text, ";");
            text = DeleteExcess(text, "-");
            string str = "";
            for (int i = 0; i < text.Length; i++)
            {
                if (text[i] != ' ')
                {
                    int j = Convert.ToInt32(Convert.ToChar(text[i]) - 1040);
                    str += key[j];
                }
                else
                    str += ' ';
            }
            return str;
        }

        public override string Uncryption(string text)
        {
            string str = "";
            for (int i = 0; i < text.Length; i++)
            {
                for (int j = 0; j < key.Length; j++)
                {
                    if (text[i] == ' ')
                    {
                        str += ' ';
                        break;
                    }
                    else if (text[i] == key[j])
                    {
                        str += Convert.ToChar(1040 + j);
                    }
                }
            }
            return str;
        }
    }
}
