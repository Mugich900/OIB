using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OIB_shifrovanie
{
    class Fraction : EncryptionMethod
    {
        //массив букв на 30 символов (выбрешенны символы щ и ъ)
        char[,] letterArray = new char[5, 6];
        string DeleteExcess(string str, string c, string a)
        {
            while (str.Contains(c))
            {
                str = str.Replace(c, a);
            }
            return str;
        }
        string key = "";
        public Fraction(string formolizeText)
        {
            key = formolizeText.ToUpper().Trim();
            key = DeleteExcess(key, " ", "");
            key = DeleteExcess(key, ".", "");
            key = DeleteExcess(key, ",", "");
            key = DeleteExcess(key, "?", "");
            key = DeleteExcess(key, "!", "");
            key = DeleteExcess(key, ":", "");
            key = DeleteExcess(key, ";", "");
            key = DeleteExcess(key, "-", "");
            key = DeleteExcess(key, "Ъ", "Ь");
            key = DeleteExcess(key, "Щ", "Ш");
        }

        public override void CreateSubstitutionAlphabet()
        {
            for (int i = 0; i < key.Length; i++)
            {
                for (int j = 0; j < key.Length; j++)
                {
                    if (key[i] == key[j] && i != j)
                    {
                        key = key.Remove(j, 1);
                    }
                }
            }
            int g = key.Length;
            int q = 0;
            for (int i = 0; i < letterArray.GetLength(0); i++)
            {
                for (int j = 0; j < letterArray.GetLength(1); j++)
                {
                    letterArray[i, j] = key[q];
                    q++;
                }
            }
        }

        public override string Encryption(string text)
        {
            text = text.ToUpper().Trim();
            key = DeleteExcess(key, " ", "");
            key = DeleteExcess(key, ".", "");
            key = DeleteExcess(key, ",", "");
            key = DeleteExcess(key, "?", "");
            key = DeleteExcess(key, "!", "");
            key = DeleteExcess(key, ":", "");
            key = DeleteExcess(key, ";", "");
            key = DeleteExcess(key, "-", "");
            string str = "";

            for (int l = 0; l < text.Length; l++)
            {
                for (int i = 0; i < letterArray.GetLength(0); i++)
                {
                    for (int j = 0; j < letterArray.GetLength(1); j++)
                    {
                        if (text[l] == letterArray[i, j])
                            str += i + " " + j + " ";
                    }
                }
            }

            return str;
        }

        public override string Uncryption(string text)
        {
            string str = "";
            text = DeleteExcess(text, " ", "");
            for (int i = 0; i < text.Length-1; i+=2)
            {
                str += letterArray[Convert.ToInt32(text[i].ToString()), Convert.ToInt32(text[i + 1].ToString())];
            }
            return str;
        }
    }
}