namespace ISIPendu
{
    partial class Pendu
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Pendu));
            this.labelTitle = new System.Windows.Forms.Label();
            this.groupBox_letters = new System.Windows.Forms.GroupBox();
            this.groupBox_menu = new System.Windows.Forms.GroupBox();
            this.button_quit = new System.Windows.Forms.Button();
            this.button_surrend = new System.Windows.Forms.Button();
            this.button_generate = new System.Windows.Forms.Button();
            this.button_word = new System.Windows.Forms.Button();
            this.dgv_alphabet = new System.Windows.Forms.DataGridView();
            this.tsplb_information = new System.Windows.Forms.Label();
            this.label_letters = new System.Windows.Forms.Label();
            this.label_used_letters = new System.Windows.Forms.Label();
            this.groupBox_letters.SuspendLayout();
            this.groupBox_menu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_alphabet)).BeginInit();
            this.SuspendLayout();
            // 
            // labelTitle
            // 
            resources.ApplyResources(this.labelTitle, "labelTitle");
            this.labelTitle.Name = "labelTitle";
            // 
            // groupBox_letters
            // 
            this.groupBox_letters.Controls.Add(this.label_used_letters);
            resources.ApplyResources(this.groupBox_letters, "groupBox_letters");
            this.groupBox_letters.Name = "groupBox_letters";
            this.groupBox_letters.TabStop = false;
            // 
            // groupBox_menu
            // 
            this.groupBox_menu.Controls.Add(this.button_quit);
            this.groupBox_menu.Controls.Add(this.button_surrend);
            this.groupBox_menu.Controls.Add(this.button_generate);
            this.groupBox_menu.Controls.Add(this.button_word);
            resources.ApplyResources(this.groupBox_menu, "groupBox_menu");
            this.groupBox_menu.Name = "groupBox_menu";
            this.groupBox_menu.TabStop = false;
            // 
            // button_quit
            // 
            resources.ApplyResources(this.button_quit, "button_quit");
            this.button_quit.Name = "button_quit";
            this.button_quit.UseVisualStyleBackColor = true;
            // 
            // button_surrend
            // 
            resources.ApplyResources(this.button_surrend, "button_surrend");
            this.button_surrend.Name = "button_surrend";
            this.button_surrend.UseVisualStyleBackColor = true;
            // 
            // button_generate
            // 
            resources.ApplyResources(this.button_generate, "button_generate");
            this.button_generate.Name = "button_generate";
            this.button_generate.UseVisualStyleBackColor = true;
            // 
            // button_word
            // 
            resources.ApplyResources(this.button_word, "button_word");
            this.button_word.Name = "button_word";
            this.button_word.UseVisualStyleBackColor = true;
            // 
            // dgv_alphabet
            // 
            this.dgv_alphabet.AllowUserToAddRows = false;
            this.dgv_alphabet.AllowUserToDeleteRows = false;
            this.dgv_alphabet.AllowUserToResizeColumns = false;
            this.dgv_alphabet.AllowUserToResizeRows = false;
            this.dgv_alphabet.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_alphabet.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgv_alphabet.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgv_alphabet.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_alphabet.ColumnHeadersVisible = false;
            resources.ApplyResources(this.dgv_alphabet, "dgv_alphabet");
            this.dgv_alphabet.MultiSelect = false;
            this.dgv_alphabet.Name = "dgv_alphabet";
            this.dgv_alphabet.ReadOnly = true;
            this.dgv_alphabet.RowHeadersVisible = false;
            this.dgv_alphabet.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_alphabet_CellClick);
            // 
            // tsplb_information
            // 
            resources.ApplyResources(this.tsplb_information, "tsplb_information");
            this.tsplb_information.Name = "tsplb_information";
            // 
            // label_letters
            // 
            resources.ApplyResources(this.label_letters, "label_letters");
            this.label_letters.Name = "label_letters";
            // 
            // label_used_letters
            // 
            resources.ApplyResources(this.label_used_letters, "label_used_letters");
            this.label_used_letters.Name = "label_used_letters";
            this.label_used_letters.UseMnemonic = false;
            // 
            // Pendu
            // 
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.label_letters);
            this.Controls.Add(this.tsplb_information);
            this.Controls.Add(this.dgv_alphabet);
            this.Controls.Add(this.groupBox_menu);
            this.Controls.Add(this.groupBox_letters);
            this.Controls.Add(this.labelTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Pendu";
            this.groupBox_letters.ResumeLayout(false);
            this.groupBox_menu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_alphabet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.GroupBox groupBox_letters;
        private System.Windows.Forms.GroupBox groupBox_menu;
        private System.Windows.Forms.DataGridView dgv_alphabet;
        private System.Windows.Forms.Label tsplb_information;
        private System.Windows.Forms.Button button_quit;
        private System.Windows.Forms.Button button_surrend;
        private System.Windows.Forms.Button button_generate;
        private System.Windows.Forms.Button button_word;
        private System.Windows.Forms.Label label_letters;
        private System.Windows.Forms.Label label_used_letters;
    }
}

