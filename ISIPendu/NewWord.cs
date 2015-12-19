using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ISIPendu
{
    public partial class NewWord : Form
    {
        private string nouveauMot;
        private string[] dico;
        private System.IO.StreamWriter ajout;

        public NewWord()
        {
            InitializeComponent();
        }

        private void Annuler_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Ajouter_Click(object sender, EventArgs e)
        {
            int i = 0;
            Boolean existeDeja = false;
            string mot = null;
            dico = System.IO.File.ReadAllLines(@"C:\Users\Mel\Documents\Cours\3A info\ISI\ISI1-Pendu\Dico.txt");
            
            //On parcourt toute la collection pour vérifier que le mot n'existe pas déjà 
            while ((i < dico.Length) && (!existeDeja))
            {
                mot = dico.ElementAt(i);
                if (mot == textBox1.Text)
                    existeDeja = true;
                else
                    i = i + 1;
            }

            //Si le numéro d'assuré n'existe pas déjà 
            if (!existeDeja)
            {
                // On récupère le mot
                nouveauMot = ('\n') + textBox1.Text;

                // On l'écrit dans le fichier.
                ajout = System.IO.File.AppendText(@"C:\Users\Mel\Documents\Cours\3A info\ISI\ISI1-Pendu\Dico.txt");
                ajout.WriteLine(nouveauMot);

                ajout.Close();
                MessageBox.Show("Félicitation  ! \nVotre mot a bien été ajouté.", "Ajout",
                MessageBoxButtons.OK);

                //On vide les cases 
                textBox1.Text = "";
            }
            else
            {
                MessageBox.Show("Ce mot fait déjà parti du dictionnaire.", "Erreur",
                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}
