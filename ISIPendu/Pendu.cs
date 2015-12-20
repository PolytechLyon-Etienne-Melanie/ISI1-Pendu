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
        private List<String> used_letters = new List<String>();
        private String Mot_secret;
        private MysteryWord mysteryWord;
        private bool onGame;

        static int nbTry = 10;
        private int currentTry;
        private Image[] images;

        public Pendu()
        {
            InitializeComponent();
            initComposants();
            //selectionnerFichier();
            dicoAuto();
            onGame = true;
            currentTry = 0;
            initMot();
        }

        private void initMot()
        {
            mysteryWord = new MysteryWord(Mot_secret);
            updateWord();
            this.label_used_letters.Text = "";
        }

        private void loadImages()
        {
            int n = 11;
            images = new Image[n];
            for(int i = 0; i < n; i++)
            {
                images[i] = Image.FromFile(@"../../images/pendu_" + i + ".png");
            }
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
                Mot_secret = dictionnaire[new Random().Next(dictionnaire.Count)];
                info("Mot secret chargé, choisissez votre première lettre.");
                //rafraichirSecret();
                this.button_word.Enabled = true;
            }
        }

        private void dicoAuto()
        {
            string[] dico = File.ReadAllLines(@"../../Dico.txt");
            dictionnaire = dico.ToList();
            Mot_secret = dictionnaire[new Random().Next(dictionnaire.Count)];
            info("Mot secret chargé, choisissez votre première lettre.");
           
            //rafraichirSecret();
            this.button_word.Enabled = true;
        }

        private void selectionnerMot()
        {
                Mot_secret = dictionnaire[new Random().Next(dictionnaire.Count)];
                info("Mot secret chargé, choisissez votre première lettre.");
                //rafraichirSecret();
                this.button_word.Enabled = true;
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
            info("Veuillez charger un fichier de dictionnaire de mots.");
            loadImages();
            updateImage();
        }

        private void reinitComposants()
        {
            // Charge les cellules du DataGridView
            dgv_alphabet.ColumnCount = 13;
            dgv_alphabet.RowCount = 2;
            dgv_alphabet.Rows[0].Height = 30;
            dgv_alphabet.Rows[1].Height = 30;
            for (int i = 0; i < 13; i++)
            {
                this.dgv_alphabet.Rows[0].Cells[i].Style.BackColor = Color.White;
                this.dgv_alphabet.Rows[1].Cells[i].Style.BackColor = Color.White;
            }
            info("");
            updateWord();
            this.label_used_letters.Text = "";
            used_letters = new List<String>();
            this.button_generate.Enabled = false;
            this.button_surrend.Enabled = true;
            this.button_word.Enabled = true;
            
        }

        private void dgv_alphabet_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            String l = (String)this.dgv_alphabet.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
            click_letter(l[0], e.RowIndex, e.ColumnIndex);
        }

        private void click_letter(char c, int row, int col)
        {
            if (!onGame)
                return;

            updateUsedLetters(c);
            if(mysteryWord.checkLetter(c))
            {
                updateWord();
                rightLetter(row, col);
            }
            else
            {
                wrongLetter(row, col);
            }
        }

        private void updateWord()
        {
            this.label_letters.Text = mysteryWord.getMysteryWord();
        }

        private void updateUsedLetters(char c)
        {
            this.used_letters.Add(c.ToString());
            String w = "";
            foreach(String l in used_letters)
            {
                w += l + ", ";
            }
            this.label_used_letters.Text = w;
        }

        private void rightLetter(int r, int c)
        {
            this.dgv_alphabet.Rows[r].Cells[c].Style.BackColor = Color.Green;
            if (mysteryWord.discovered())
                onWin();
        }

        private void wrongLetter(int r, int c)
        {
            this.dgv_alphabet.Rows[r].Cells[c].Style.BackColor = Color.Red;
            addOneTry();
        }

        private void addOneTry()
        {
            currentTry++;
            updateImage();
            if (currentTry == nbTry)
                onLoose();
        }

        private void onWin()
        {
            onGame = false;
            MessageBox.Show("Félicitaion vous avez gagné !");
            this.button_generate.Enabled = true;
            this.button_surrend.Enabled = false;
            this.button_word.Enabled = true;
        }

        private void onLoose()
        {
            onGame = false;
            MessageBox.Show("Dommage, c'est perdu. \nLe mot était "+Mot_secret+".");
            this.button_generate.Enabled = true;
            this.button_surrend.Enabled = false;
            this.button_word.Enabled = true;
        }

        private void reinit()
        {

            reinitComposants();
            selectionnerMot();
            onGame = true;
            currentTry = 0;
            updateImage();
            initMot();
        }

        private void button_quit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Voulez-vous vraiment quitter ?", "Quitter", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                System.Windows.Forms.Application.Exit();
            }
            else
            {
                this.Activate();
            }   
        }

        private void button_generate_Click(object sender, EventArgs e)
        {
            reinit();
        }

        private void button_surrend_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Vous avez perdu ! Le mot était "+Mot_secret+". \nVoulez-vous recommencer ?", "Abandon", MessageBoxButtons.YesNo) == DialogResult.No)
            {
                System.Windows.Forms.Application.Exit();
            }
            else
            {
                reinit();
            }   
        }

        private void info(string s)
        {
            tsplb_information.Text = s;
        }

        private void updateImage()
        {
            this.picture_Pendu.Image = images[currentTry];
        }

        private void button_word_Click(object sender, EventArgs e)
        {
            NewWord w = new NewWord();
            w.ShowDialog();
        }    

    }
}
