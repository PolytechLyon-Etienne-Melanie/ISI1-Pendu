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
    public partial class Pendu : Form
    {
        // déclaration et instanciation d’une collection pour le dictionnaire
        private List<String> dictionnaire = new List<String>();

        public Pendu()
        {
            InitializeComponent();
            initComposants();
        }

        

        private void selectionnerFichier()
         {
           OpenFileDialog ofd = new OpenFileDialog();
          // on initalise la boîte de dialogue
           ofd.Filter = "txt files (*.txt)|*.txt";
           ofd.FileName = "";
           if (ofd.ShowDialog() == DialogResult.OK)
            {   // on ouvre le fichier
                FileStream fs = new FileStream(ofd.FileName, FileMode.Open, FileAccess.Read);
                StreamReader sr = new StreamReader(fs);
                String ligne;
                while ((ligne = sr.ReadLine()) != null)
                    // Insertion de chaque ligne dans le dictionnaire
                    dictionnaire.Add(ligne);
                // Renseignement de la propriété Mot_secret d'un mot tiré au hasard dans le dictionnaire
                fs.Close();
                sr.Close();
                //Mot_secret = dictionnaire[new Random().Next(dictionnaire.Count)];
                //tsplb_information.Text = "Mot secret chargé, choisissez votre première lettre.";
                //rafraichirSecret();
                //bt_verifier.Enabled = true;
            }
        }

        // Initialise les composants graphiques du formulaire
        private void initComposants()
        {
            // Charge les cellules du DataGridView
            dgv_alphabet.ColumnCount = 13;
            dgv_alphabet.RowCount = 2;
            dgv_alphabet.Rows[0].Height = 30;
            dgv_alphabet.Rows[1].Height = 30;
            for (int i = 0; i < 13; i++)
            {
                dgv_alphabet.Columns[i].Width = 30;
                dgv_alphabet.Rows[0].Cells[i].Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                // Type casting du code ascii (entier) vers sa représentation en caractère (wrapper Char)
                // Les lettres de l'alphabet se suivent de 65 à 91 dans la table, ce qui rend facile la manipulation
                dgv_alphabet.Rows[0].Cells[i].Value = ((Char)(i + 65)).ToString();
                // Traitement de la deuxieme partie de l'alphabet pour la seconde ligne
                dgv_alphabet.Rows[1].Cells[i].Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgv_alphabet.Rows[1].Cells[i].Value = ((Char)(i + (65 + 13))).ToString();
            }
            tsplb_information.Text = "Veuillez charger un fichier de dictionnaire de mots.";
        }

        private void dgv_alphabet_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            String l = (String)this.dgv_alphabet.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
            MessageBox.Show(l);
        }

    }
}
