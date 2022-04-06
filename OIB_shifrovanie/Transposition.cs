using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OIB_shifrovanie
{
    class Transposition : EncryptionMethod
    {
        string alp = "абвгдежзийклмнопрстуфхцчшщъыьэюя".ToUpper();
        string DeleteExcess(string str, string c)
        {
            while (str.Contains(c))
            {
                str = str.Replace(c, "");
            }
            return str;
        }
        string key = "";
        string text = "";
        public Transposition(string text, string key)
        {
            this.text = text.ToUpper();
            this.text = DeleteExcess(this.text, " ");
            this.text = DeleteExcess(this.text, ".");
            this.text = DeleteExcess(this.text, ",");
            this.text = DeleteExcess(this.text, "?");
            this.text = DeleteExcess(this.text, "!");
            this.text = DeleteExcess(this.text, ":");
            this.text = DeleteExcess(this.text, ";");
            this.text = DeleteExcess(this.text, "-");
            this.key = key.ToUpper();
        }
        char[,] letterArray = new char[8, 6];

        public override void CreateSubstitutionAlphabet()
        {
            int q = 0;
            for (int i = 0; i <= text.Length / key.Length; i++)
            {
                for (int j = 0; j < key.Length; j++)
                {
                    if (q < text.Length)
                        letterArray[i, j] = text[q];
                    else
                        letterArray[i, j] = ' ';
                    q++;
                }
            }
        }

        public override string Encryption(string text)
        {
            text = text.ToUpper().Trim();
            text = DeleteExcess(text, " ");
            text = DeleteExcess(text, ".");
            text = DeleteExcess(text, ",");
            text = DeleteExcess(text, "?");
            text = DeleteExcess(text, "!");
            text = DeleteExcess(text, ":");
            text = DeleteExcess(text, ";");
            text = DeleteExcess(text, "-");
            string str = "";
            int n = 0;
            string[] pos = new string[key.Length];
            for (int i = 0; i < alp.Length; i++)
            {
                for (int j = 0; j < key.Length; j++)
                {
                    if (alp[i] == key[j])
                    {
                        pos[j] = n.ToString();
                        n++;
                    }

                }
            }
            string a = "";
            for (int i = 0; i < pos.Length; i++)
            {
                a += pos[i];
            }
            int c = 0;
            for (int i = 0; i < key.Length; i++)
            {
                string word = "";
                for (int j = 0; j <= text.Length / key.Length; j++)
                {
                    word += letterArray[j,a.IndexOf(c.ToString())];
                }
                c++;
                str += word+" ";
            }
            return str;
        }

        public override string Uncryption(string text)
        {
            string str = "";
            string[] temp = text.Split(' ');

            string[] pos = new string[key.Length];
            int n = 0;
            for (int i = 0; i < alp.Length; i++)
            {
                for (int j = 0; j < key.Length; j++)
                {
                    if (alp[i] == key[j])
                    {
                        pos[j] = n.ToString();
                        n++;
                    }

                }
            }

            for (int i = 0; i < temp[0].Length; i++)
            {
                for (int j = 0; j < temp.Length-1; j++)
                {
                    str += temp[Convert.ToInt32(pos[j])][i];
                }
            }

            return str;
        }
    }
}
