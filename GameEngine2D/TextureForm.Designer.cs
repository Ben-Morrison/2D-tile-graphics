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
            this.radioTextureWall = new System.Windows.Forms.RadioButton();
            this.radioTextureAutotile = new System.Windows.Forms.RadioButton();
            this.radioTextureBase = new System.Windows.Forms.RadioButton();
            this.btnSelect = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.listTextures = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.picTexture = new System.Windows.Forms.PictureBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.picPreview = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.radioAnimNone = new System.Windows.Forms.RadioButton();
            this.radioAnimAutotile = new System.Windows.Forms.RadioButton();
            this.radioAnimWaterfall = new System.Windows.Forms.RadioButton();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picTexture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picPreview)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // radioTextureWall
            // 
            this.radioTextureWall.AutoSize = true;
            this.radioTextureWall.Location = new System.Drawing.Point(3, 62);
            this.radioTextureWall.Name = "radioTextureWall";
            this.radioTextureWall.Size = new System.Drawing.Size(46, 17);
            this.radioTextureWall.TabIndex = 17;
            this.radioTextureWall.TabStop = true;
            this.radioTextureWall.Text = "Wall";
            this.radioTextureWall.UseVisualStyleBackColor = true;
            this.radioTextureWall.CheckedChanged += new System.EventHandler(this.radioTextureWall_CheckedChanged);
            // 
            // radioTextureAutotile
            // 
            this.radioTextureAutotile.AutoSize = true;
            this.radioTextureAutotile.Location = new System.Drawing.Point(3, 39);
            this.radioTextureAutotile.Name = "radioTextureAutotile";
            this.radioTextureAutotile.Size = new System.Drawing.Size(64, 17);
            this.radioTextureAutotile.TabIndex = 14;
            this.radioTextureAutotile.TabStop = true;
            this.radioTextureAutotile.Text = "AutoTile";
            this.radioTextureAutotile.UseVisualStyleBackColor = true;
            this.radioTextureAutotile.CheckedChanged += new System.EventHandler(this.radioTextureAutotile_CheckedChanged);
            // 
            // radioTextureBase
            // 
            this.radioTextureBase.AutoSize = true;
            this.radioTextureBase.Location = new System.Drawing.Point(3, 16);
            this.radioTextureBase.Name = "radioTextureBase";
            this.radioTextureBase.Size = new System.Drawing.Size(88, 17);
            this.radioTextureBase.TabIndex = 13;
            this.radioTextureBase.TabStop = true;
            this.radioTextureBase.Text = "Base Texture";
            this.radioTextureBase.UseVisualStyleBackColor = true;
            this.radioTextureBase.CheckedChanged += new System.EventHandler(this.radioTextureBase_CheckedChanged);
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
            // btnExit
            // 
            this.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
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
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 13);
            this.label1.TabIndex = 21;
            this.label1.Text = "Texture Type";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(915, 230);
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
            this.listTextures.Size = new System.Drawing.Size(120, 186);
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
            this.picTexture.Click += new System.EventHandler(this.picTexture_Click);
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
            // picPreview
            // 
            this.picPreview.Location = new System.Drawing.Point(918, 246);
            this.picPreview.Name = "picPreview";
            this.picPreview.Size = new System.Drawing.Size(270, 237);
            this.picPreview.TabIndex = 0;
            this.picPreview.TabStop = false;
            this.picPreview.Paint += new System.Windows.Forms.PaintEventHandler(this.picPreview_Paint);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.radioTextureBase);
            this.panel2.Controls.Add(this.radioTextureAutotile);
            this.panel2.Controls.Add(this.radioTextureWall);
            this.panel2.Location = new System.Drawing.Point(918, 12);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(141, 100);
            this.panel2.TabIndex = 28;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.radioAnimNone);
            this.panel3.Controls.Add(this.radioAnimAutotile);
            this.panel3.Controls.Add(this.radioAnimWaterfall);
            this.panel3.Location = new System.Drawing.Point(918, 118);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(141, 100);
            this.panel3.TabIndex = 29;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 13);
            this.label4.TabIndex = 21;
            this.label4.Text = "Animation Type";
            // 
            // radioAnimNone
            // 
            this.radioAnimNone.AutoSize = true;
            this.radioAnimNone.Location = new System.Drawing.Point(3, 16);
            this.radioAnimNone.Name = "radioAnimNone";
            this.radioAnimNone.Size = new System.Drawing.Size(51, 17);
            this.radioAnimNone.TabIndex = 13;
            this.radioAnimNone.TabStop = true;
            this.radioAnimNone.Text = "None";
            this.radioAnimNone.UseVisualStyleBackColor = true;
            // 
            // radioAnimAutotile
            // 
            this.radioAnimAutotile.AutoSize = true;
            this.radioAnimAutotile.Location = new System.Drawing.Point(3, 39);
            this.radioAnimAutotile.Name = "radioAnimAutotile";
            this.radioAnimAutotile.Size = new System.Drawing.Size(64, 17);
            this.radioAnimAutotile.TabIndex = 14;
            this.radioAnimAutotile.TabStop = true;
            this.radioAnimAutotile.Text = "AutoTile";
            this.radioAnimAutotile.UseVisualStyleBackColor = true;
            // 
            // radioAnimWaterfall
            // 
            this.radioAnimWaterfall.AutoSize = true;
            this.radioAnimWaterfall.Location = new System.Drawing.Point(3, 62);
            this.radioAnimWaterfall.Name = "radioAnimWaterfall";
            this.radioAnimWaterfall.Size = new System.Drawing.Size(67, 17);
            this.radioAnimWaterfall.TabIndex = 17;
            this.radioAnimWaterfall.TabStop = true;
            this.radioAnimWaterfall.Text = "Waterfall";
            this.radioAnimWaterfall.UseVisualStyleBackColor = true;
            // 
            // TextureForm
            // 
            this.AcceptButton = this.btnSelect;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnExit;
            this.ClientSize = new System.Drawing.Size(1199, 524);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.picPreview);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.listTextures);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnSelect);
            this.Name = "TextureForm";
            this.Text = "Select Texture";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picTexture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picPreview)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton radioTextureWall;
        private System.Windows.Forms.RadioButton radioTextureAutotile;
        private System.Windows.Forms.RadioButton radioTextureBase;
        private System.Windows.Forms.Button btnSelect;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox listTextures;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox picTexture;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.PictureBox picPreview;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RadioButton radioAnimNone;
        private System.Windows.Forms.RadioButton radioAnimAutotile;
        private System.Windows.Forms.RadioButton radioAnimWaterfall;
    }
}