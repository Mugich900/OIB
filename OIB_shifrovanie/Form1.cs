using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OIB_shifrovanie
{
    public partial class Form1 : Form
    {
        string textForEncryption = "";
        string keyPhrase = "Без предисловий, сей же час Позвольте познакомить вас: а, б, в, г, д, е, ж, з, и, й, к, л, м, н, о, п, р, с, т, у, ф, х, ц, ч, ш, щ, ъ, ы, ь, э, ю, я.";
        EncryptionMethod ob;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = ob.Encryption(textForEncryption);
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            textForEncryption = "Местами эти дома казались затерянными среди широкой, как поле, улицы и нескончаемых деревянных заборов; местами сбивались в кучу, и здесь было заметно более движения народа и живости. Попадались почти смытые дождем вывески с кренделями и сапогами, кое - где с нарисованными синими брюками и подписью какого - то Аршавского портного";
            keyPhrase = "Без предисловий, сей же час Позвольте познакомить вас: а, б, в, г, д, е, ж, з, и, й, к, л, м, н, о, п, р, с, т, у, ф, х, ц, ч, ш, щ, ъ, ы, ь, э, ю, я.";
            ob = new Monoalphabet(keyPhrase);
            ob.CreateSubstitutionAlphabet();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = ob.Uncryption(textBox1.Text);
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            textForEncryption = "Без предисловий, сей же час Позвольте познакомить вас:";
            ob = new Transposition(textForEncryption);
            ob.CreateSubstitutionAlphabet();
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            textForEncryption = "Местами эти дома казались затерянными среди широкой, как поле, улицы и нескончаемых деревянных заборов; местами сбивались в кучу, и здесь было заметно более движения народа и живости. Попадались почти смытые дождем вывески с кренделями и сапогами, кое-где с нарисованными синими брюками и подписью какого-то Аршавского портного";
            ob = new Fraction(keyPhrase);
            ob.CreateSubstitutionAlphabet();
        }
    }
}
