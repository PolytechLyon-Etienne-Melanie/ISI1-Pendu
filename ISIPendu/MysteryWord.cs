using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ISIPendu
{
    class MysteryWord
    {
        private List<Letter> word = new List<Letter>();

        public MysteryWord(string w)
        {
            initWord(w);
        }

        private void initWord(string w)
        {
            for(int i = 0; i < w.Length; i++)
            {
                word.Add(new Letter(w[i]));
            }
        }

        public Boolean checkLetter(char c)
        {
            bool b = false;
            foreach(Letter letter in word)
            {
                if (letter.isThisLetter(c))
                    b = true;
            }
            return b;
        }

        public String getMysteryWord()
        {
            String w = " ";
            foreach (Letter letter in word)
            {
                w += letter.getLetter() + " ";
            }
            return w;
        }

        public bool discovered()
        {
            foreach (Letter letter in word)
            {
                if (!letter.isDiscovered())
                    return false;
            }
            return true;
        }
    }
}
