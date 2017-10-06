namespace GameEngine2D
{
    partial class TextureForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.radioBrush3 = new System.Windows.Forms.RadioButton();
            this.radioBrush2 = new System.Windows.Forms.RadioButton();
            this.radioBrush1 = new System.Windows.Forms.RadioButton();
            this.btnSelect = new System.Windows.Forms.Button();
            this.panelPreview = new System.Windows.Forms.Panel();
            this.picPreview = new System.Windows.Forms.PictureBox();
            this.btnExit = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.listTextures = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.picTexture = new System.Windows.Forms.PictureBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.panelPreview.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picPreview)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picTexture)).BeginInit();
            this.SuspendLayout();
            // 
            // radioBrush3
            // 
            this.radioBrush3.AutoSize = true;
            this.radioBrush3.Location = new System.Drawing.Point(917, 78);
            this.radioBrush3.Name = "radioBrush3";
            this.radioBrush3.Size = new System.Drawing.Size(46, 17);
            this.radioBrush3.TabIndex = 17;
            this.radioBrush3.TabStop = true;
            this.radioBrush3.Text = "Wall";
            this.radioBrush3.UseVisualStyleBackColor = true;
            // 
            // radioBrush2
            // 
            this.radioBrush2.AutoSize = true;
            this.radioBrush2.Location = new System.Drawing.Point(917, 55);
            this.radioBrush2.Name = "radioBrush2";
            this.radioBrush2.Size = new System.Drawing.Size(64, 17);
            this.radioBrush2.TabIndex = 14;
            this.radioBrush2.TabStop = true;
            this.radioBrush2.Text = "AutoTile";
            this.radioBrush2.UseVisualStyleBackColor = true;
            this.radioBrush2.CheckedChanged += new System.EventHandler(this.radioBrush2_CheckedChanged);
            // 
            // radioBrush1
            // 
            this.radioBrush1.AutoSize = true;
            this.radioBrush1.Location = new System.Drawing.Point(917, 32);
            this.radioBrush1.Name = "radioBrush1";
            this.radioBrush1.Size = new System.Drawing.Size(88, 17);
            this.radioBrush1.TabIndex = 13;
            this.radioBrush1.TabStop = true;
            this.radioBrush1.Text = "Base Texture";
            this.radioBrush1.UseVisualStyleBackColor = true;
            this.radioBrush1.CheckedChanged += new System.EventHandler(this.radioBrush1_CheckedChanged);
            // 
            // btnSelect
            // 
            this.btnSelect.Location = new System.Drawing.Point(1031, 489);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(75, 23);
            this.btnSelect.TabIndex = 18;
            this.btnSelect.Text = "Select";
            this.btnSelect.UseVisualStyleBackColor = true;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // panelPreview
            // 
            this.panelPreview.AutoScroll = true;
            this.panelPreview.Controls.Add(this.picPreview);
            this.panelPreview.Location = new System.Drawing.Point(917, 175);
            this.panelPreview.Name = "panelPreview";
            this.panelPreview.Size = new System.Drawing.Size(270, 308);
            this.panelPreview.TabIndex = 19;
            // 
            // picPreview
            // 
            this.picPreview.Location = new System.Drawing.Point(0, 0);
            this.picPreview.Name = "picPreview";
            this.picPreview.Size = new System.Drawing.Size(270, 308);
            this.picPreview.TabIndex = 0;
            this.picPreview.TabStop = false;
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(1112, 489);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 20;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(918, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 13);
            this.label1.TabIndex = 21;
            this.label1.Text = "Texture Type";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(917, 152);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 13);
            this.label2.TabIndex = 22;
            this.label2.Text = "Preview";
            // 
            // listTextures
            // 
            this.listTextures.FormattingEnabled = true;
            this.listTextures.Location = new System.Drawing.Point(1068, 36);
            this.listTextures.Name = "listTextures";
            this.listTextures.Size = new System.Drawing.Size(120, 134);
            this.listTextures.TabIndex = 23;
            this.listTextures.SelectedIndexChanged += new System.EventHandler(this.listTextures_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(1065, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 13);
            this.label3.TabIndex = 24;
            this.label3.Text = "Textures";
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.picTexture);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(900, 500);
            this.panel1.TabIndex = 25;
            // 
            // picTexture
            // 
            this.picTexture.Location = new System.Drawing.Point(0, 0);
            this.picTexture.Name = "picTexture";
            this.picTexture.Size = new System.Drawing.Size(900, 500);
            this.picTexture.TabIndex = 26;
            this.picTexture.TabStop = false;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(950, 489);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 26;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // TextureForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1199, 524);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.listTextures);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnSelect);
            this.Controls.Add(this.panelPreview);
            this.Controls.Add(this.radioBrush3);
            this.Controls.Add(this.radioBrush2);
            this.Controls.Add(this.radioBrush1);
            this.Name = "TextureForm";
            this.Text = "Select Texture";
            this.panelPreview.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picPreview)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picTexture)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton radioBrush3;
        private System.Windows.Forms.RadioButton radioBrush2;
        private System.Windows.Forms.RadioButton radioBrush1;
        private System.Windows.Forms.Button btnSelect;
        private System.Windows.Forms.Panel panelPreview;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox listTextures;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox picTexture;
        private System.Windows.Forms.PictureBox picPreview;
        private System.Windows.Forms.Button btnAdd;
    }
}