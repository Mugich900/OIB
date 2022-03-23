using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OIB_shifrovanie
{
    abstract class EncryptionMethod
    {
        public abstract void CreateSubstitutionAlphabet();
        public abstract string Encryption(string text);
        public abstract string Uncryption(string text);
    }
}
