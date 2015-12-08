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
    class Letter
    {
        private char letter;
        private bool discovered;

        public Letter(string l)
        {
            letter = l[0];
            discovered = false;
        }

        public Letter(char p)
        {
            letter = p;
            discovered = false;
        }

        public Boolean isThisLetter(string l)
        {
            if (letter == l[0])
            {
                discovered = true;
                return true;
            }
            else
                return false;
        }

        public bool isThisLetter(char c)
        {
            if (letter == c)
            {
                discovered = true;
                return true;
            }
            else
                return false;
        }

        public String getLetter()
        {
            if (discovered)
            {
                return letter.ToString();
            }
            else
            {
                return "_";
            }
        }
    }
}
