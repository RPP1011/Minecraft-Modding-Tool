namespace Minecraft_Modding_Tool
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.itemListBox = new System.Windows.Forms.ListBox();
            this.outputPathPicker = new System.Windows.Forms.FolderBrowserDialog();
            this.modidText = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.outputPathSelectionButton = new System.Windows.Forms.Button();
            this.outputPathText = new System.Windows.Forms.TextBox();
            this.jsonGenerateButton = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.variantLabel = new System.Windows.Forms.Label();
            this.chestVariantRealText = new System.Windows.Forms.TextBox();
            this.fenceVariantRealText = new System.Windows.Forms.TextBox();
            this.wallVariantRealText = new System.Windows.Forms.TextBox();
            this.slabVariantRealText = new System.Windows.Forms.TextBox();
            this.stairsVariantRealText = new System.Windows.Forms.TextBox();
            this.itemVariantRealText = new System.Windows.Forms.TextBox();
            this.blockVariantRealText = new System.Windows.Forms.TextBox();
            this.chestVariantDisplayText = new System.Windows.Forms.TextBox();
            this.fenceVariantDisplayText = new System.Windows.Forms.TextBox();
            this.wallVariantDisplayText = new System.Windows.Forms.TextBox();
            this.slabVariantDisplayText = new System.Windows.Forms.TextBox();
            this.stairsVariantDisplayText = new System.Windows.Forms.TextBox();
            this.itemVariantDisplayText = new System.Windows.Forms.TextBox();
            this.blockVariantDisplayText = new System.Windows.Forms.TextBox();
            this.slabCheckBox = new System.Windows.Forms.CheckBox();
            this.wallCheckBox = new System.Windows.Forms.CheckBox();
            this.chestCheckBox = new System.Windows.Forms.CheckBox();
            this.fenceCheckBox = new System.Windows.Forms.CheckBox();
            this.stairsCheckBox = new System.Windows.Forms.CheckBox();
            this.itemCheckBox = new System.Windows.Forms.CheckBox();
            this.blockCheckBox = new System.Windows.Forms.CheckBox();
            this.realNameText = new System.Windows.Forms.TextBox();
            this.realNameLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textureFileChooseButton = new System.Windows.Forms.Button();
            this.textureFileText = new System.Windows.Forms.TextBox();
            this.displayNameText = new System.Windows.Forms.TextBox();
            this.itemNameText = new System.Windows.Forms.TextBox();
            this.textureLabel = new System.Windows.Forms.Label();
            this.displayNameLabel = new System.Windows.Forms.Label();
            this.itemNameLabel = new System.Windows.Forms.Label();
            this.refreshButton = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // itemListBox
            // 
            this.itemListBox.FormattingEnabled = true;
            this.itemListBox.Location = new System.Drawing.Point(15, 38);
            this.itemListBox.Name = "itemListBox";
            this.itemListBox.Size = new System.Drawing.Size(202, 368);
            this.itemListBox.TabIndex = 0;
            this.itemListBox.SelectedIndexChanged += new System.EventHandler(this.itemListBox_SelectedIndexChanged);
            // 
            // modidText
            // 
            this.modidText.Enabled = false;
            this.modidText.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.modidText.Location = new System.Drawing.Point(292, 9);
            this.modidText.Name = "modidText";
            this.modidText.Size = new System.Drawing.Size(508, 23);
            this.modidText.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(230, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "Mod ID:";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(15, 412);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(35, 34);
            this.button1.TabIndex = 4;
            this.button1.Text = "-";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.RemoveElement);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(182, 410);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(35, 34);
            this.button2.TabIndex = 5;
            this.button2.Text = "+";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.AddElement);
            // 
            // outputPathSelectionButton
            // 
            this.outputPathSelectionButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.outputPathSelectionButton.Location = new System.Drawing.Point(579, 421);
            this.outputPathSelectionButton.Name = "outputPathSelectionButton";
            this.outputPathSelectionButton.Size = new System.Drawing.Size(145, 23);
            this.outputPathSelectionButton.TabIndex = 6;
            this.outputPathSelectionButton.Text = "Choose";
            this.outputPathSelectionButton.UseVisualStyleBackColor = true;
            this.outputPathSelectionButton.Click += new System.EventHandler(this.ChooseOutput);
            // 
            // outputPathText
            // 
            this.outputPathText.Enabled = false;
            this.outputPathText.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.outputPathText.Location = new System.Drawing.Point(223, 421);
            this.outputPathText.Name = "outputPathText";
            this.outputPathText.Size = new System.Drawing.Size(350, 23);
            this.outputPathText.TabIndex = 7;
            this.outputPathText.Text = "Resources.Assets.MODID folder";
            // 
            // jsonGenerateButton
            // 
            this.jsonGenerateButton.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.jsonGenerateButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.jsonGenerateButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.jsonGenerateButton.Location = new System.Drawing.Point(731, 421);
            this.jsonGenerateButton.Name = "jsonGenerateButton";
            this.jsonGenerateButton.Size = new System.Drawing.Size(82, 23);
            this.jsonGenerateButton.TabIndex = 8;
            this.jsonGenerateButton.Text = "Generate";
            this.jsonGenerateButton.UseVisualStyleBackColor = true;
            this.jsonGenerateButton.Click += new System.EventHandler(this.GenerateJSON);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.variantLabel);
            this.panel1.Controls.Add(this.chestVariantRealText);
            this.panel1.Controls.Add(this.fenceVariantRealText);
            this.panel1.Controls.Add(this.wallVariantRealText);
            this.panel1.Controls.Add(this.slabVariantRealText);
            this.panel1.Controls.Add(this.stairsVariantRealText);
            this.panel1.Controls.Add(this.itemVariantRealText);
            this.panel1.Controls.Add(this.blockVariantRealText);
            this.panel1.Controls.Add(this.chestVariantDisplayText);
            this.panel1.Controls.Add(this.fenceVariantDisplayText);
            this.panel1.Controls.Add(this.wallVariantDisplayText);
            this.panel1.Controls.Add(this.slabVariantDisplayText);
            this.panel1.Controls.Add(this.stairsVariantDisplayText);
            this.panel1.Controls.Add(this.itemVariantDisplayText);
            this.panel1.Controls.Add(this.blockVariantDisplayText);
            this.panel1.Controls.Add(this.slabCheckBox);
            this.panel1.Controls.Add(this.wallCheckBox);
            this.panel1.Controls.Add(this.chestCheckBox);
            this.panel1.Controls.Add(this.fenceCheckBox);
            this.panel1.Controls.Add(this.stairsCheckBox);
            this.panel1.Controls.Add(this.itemCheckBox);
            this.panel1.Controls.Add(this.blockCheckBox);
            this.panel1.Controls.Add(this.realNameText);
            this.panel1.Controls.Add(this.realNameLabel);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.textureFileChooseButton);
            this.panel1.Controls.Add(this.textureFileText);
            this.panel1.Controls.Add(this.displayNameText);
            this.panel1.Controls.Add(this.itemNameText);
            this.panel1.Controls.Add(this.textureLabel);
            this.panel1.Controls.Add(this.displayNameLabel);
            this.panel1.Controls.Add(this.itemNameLabel);
            this.panel1.Location = new System.Drawing.Point(223, 39);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(590, 367);
            this.panel1.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(353, 123);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(140, 17);
            this.label3.TabIndex = 36;
            this.label3.Text = "Object Display Name";
            // 
            // variantLabel
            // 
            this.variantLabel.AutoSize = true;
            this.variantLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.variantLabel.Location = new System.Drawing.Point(112, 123);
            this.variantLabel.Name = "variantLabel";
            this.variantLabel.Size = new System.Drawing.Size(123, 17);
            this.variantLabel.TabIndex = 35;
            this.variantLabel.Text = "Object Real Name";
            // 
            // chestVariantRealText
            // 
            this.chestVariantRealText.Location = new System.Drawing.Point(99, 289);
            this.chestVariantRealText.Name = "chestVariantRealText";
            this.chestVariantRealText.Size = new System.Drawing.Size(236, 20);
            this.chestVariantRealText.TabIndex = 34;
            this.chestVariantRealText.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.chestVariantRealText_TextChanged);
            // 
            // fenceVariantRealText
            // 
            this.fenceVariantRealText.Location = new System.Drawing.Point(99, 266);
            this.fenceVariantRealText.Name = "fenceVariantRealText";
            this.fenceVariantRealText.Size = new System.Drawing.Size(236, 20);
            this.fenceVariantRealText.TabIndex = 33;
            this.fenceVariantRealText.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.fenceVariantRealText_TextChanged);
            // 
            // wallVariantRealText
            // 
            this.wallVariantRealText.Location = new System.Drawing.Point(99, 243);
            this.wallVariantRealText.Name = "wallVariantRealText";
            this.wallVariantRealText.Size = new System.Drawing.Size(236, 20);
            this.wallVariantRealText.TabIndex = 32;
            this.wallVariantRealText.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.wallVariantRealText_TextChanged);
            // 
            // slabVariantRealText
            // 
            this.slabVariantRealText.Location = new System.Drawing.Point(99, 220);
            this.slabVariantRealText.Name = "slabVariantRealText";
            this.slabVariantRealText.Size = new System.Drawing.Size(236, 20);
            this.slabVariantRealText.TabIndex = 31;
            this.slabVariantRealText.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.slabVariantRealText_TextChanged);
            // 
            // stairsVariantRealText
            // 
            this.stairsVariantRealText.Location = new System.Drawing.Point(99, 197);
            this.stairsVariantRealText.Name = "stairsVariantRealText";
            this.stairsVariantRealText.Size = new System.Drawing.Size(236, 20);
            this.stairsVariantRealText.TabIndex = 30;
            this.stairsVariantRealText.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.stairsVariantRealText_TextChanged);
            // 
            // itemVariantRealText
            // 
            this.itemVariantRealText.Location = new System.Drawing.Point(99, 174);
            this.itemVariantRealText.Name = "itemVariantRealText";
            this.itemVariantRealText.Size = new System.Drawing.Size(236, 20);
            this.itemVariantRealText.TabIndex = 29;
            this.itemVariantRealText.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.itemVariantRealText_TextChanged);
            // 
            // blockVariantRealText
            // 
            this.blockVariantRealText.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower;
            this.blockVariantRealText.HideSelection = false;
            this.blockVariantRealText.Location = new System.Drawing.Point(99, 151);
            this.blockVariantRealText.Name = "blockVariantRealText";
            this.blockVariantRealText.Size = new System.Drawing.Size(236, 20);
            this.blockVariantRealText.TabIndex = 28;
            this.blockVariantRealText.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.blockVariantRealText_TextChanged);
            // 
            // chestVariantDisplayText
            // 
            this.chestVariantDisplayText.Location = new System.Drawing.Point(341, 289);
            this.chestVariantDisplayText.Name = "chestVariantDisplayText";
            this.chestVariantDisplayText.Size = new System.Drawing.Size(236, 20);
            this.chestVariantDisplayText.TabIndex = 27;
            this.chestVariantDisplayText.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.chestVariantDisplayText_TextChanged);
            // 
            // fenceVariantDisplayText
            // 
            this.fenceVariantDisplayText.Location = new System.Drawing.Point(341, 266);
            this.fenceVariantDisplayText.Name = "fenceVariantDisplayText";
            this.fenceVariantDisplayText.Size = new System.Drawing.Size(236, 20);
            this.fenceVariantDisplayText.TabIndex = 26;
            this.fenceVariantDisplayText.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.fenceVariantDisplayText_TextChanged);
            // 
            // wallVariantDisplayText
            // 
            this.wallVariantDisplayText.Location = new System.Drawing.Point(341, 243);
            this.wallVariantDisplayText.Name = "wallVariantDisplayText";
            this.wallVariantDisplayText.Size = new System.Drawing.Size(236, 20);
            this.wallVariantDisplayText.TabIndex = 25;
            this.wallVariantDisplayText.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.wallVariantDisplayText_TextChanged);
            // 
            // slabVariantDisplayText
            // 
            this.slabVariantDisplayText.Location = new System.Drawing.Point(341, 220);
            this.slabVariantDisplayText.Name = "slabVariantDisplayText";
            this.slabVariantDisplayText.Size = new System.Drawing.Size(236, 20);
            this.slabVariantDisplayText.TabIndex = 24;
            this.slabVariantDisplayText.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.slabVariantDisplayText_TextChanged);
            // 
            // stairsVariantDisplayText
            // 
            this.stairsVariantDisplayText.Location = new System.Drawing.Point(341, 197);
            this.stairsVariantDisplayText.Name = "stairsVariantDisplayText";
            this.stairsVariantDisplayText.Size = new System.Drawing.Size(236, 20);
            this.stairsVariantDisplayText.TabIndex = 23;
            this.stairsVariantDisplayText.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.stairsVariantRealText_TextChanged);
            // 
            // itemVariantDisplayText
            // 
            this.itemVariantDisplayText.Location = new System.Drawing.Point(341, 174);
            this.itemVariantDisplayText.Name = "itemVariantDisplayText";
            this.itemVariantDisplayText.Size = new System.Drawing.Size(236, 20);
            this.itemVariantDisplayText.TabIndex = 22;
            this.itemVariantDisplayText.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.itemVariantRealText_TextChanged);
            // 
            // blockVariantDisplayText
            // 
            this.blockVariantDisplayText.Location = new System.Drawing.Point(341, 151);
            this.blockVariantDisplayText.Name = "blockVariantDisplayText";
            this.blockVariantDisplayText.Size = new System.Drawing.Size(236, 20);
            this.blockVariantDisplayText.TabIndex = 21;
            this.blockVariantDisplayText.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.blockVariantDisplayText_TextChanged);
            // 
            // slabCheckBox
            // 
            this.slabCheckBox.AutoSize = true;
            this.slabCheckBox.Location = new System.Drawing.Point(33, 222);
            this.slabCheckBox.Name = "slabCheckBox";
            this.slabCheckBox.Size = new System.Drawing.Size(47, 17);
            this.slabCheckBox.TabIndex = 20;
            this.slabCheckBox.Text = "Slab";
            this.slabCheckBox.UseVisualStyleBackColor = true;
            this.slabCheckBox.CheckedChanged += new System.EventHandler(this.slabCheckBox_CheckedChanged);
            // 
            // wallCheckBox
            // 
            this.wallCheckBox.AutoSize = true;
            this.wallCheckBox.Location = new System.Drawing.Point(33, 245);
            this.wallCheckBox.Name = "wallCheckBox";
            this.wallCheckBox.Size = new System.Drawing.Size(47, 17);
            this.wallCheckBox.TabIndex = 19;
            this.wallCheckBox.Text = "Wall";
            this.wallCheckBox.UseVisualStyleBackColor = true;
            this.wallCheckBox.CheckedChanged += new System.EventHandler(this.wallCheckBox_CheckedChanged);
            // 
            // chestCheckBox
            // 
            this.chestCheckBox.AutoSize = true;
            this.chestCheckBox.Location = new System.Drawing.Point(32, 291);
            this.chestCheckBox.Name = "chestCheckBox";
            this.chestCheckBox.Size = new System.Drawing.Size(53, 17);
            this.chestCheckBox.TabIndex = 18;
            this.chestCheckBox.Text = "Chest";
            this.chestCheckBox.UseVisualStyleBackColor = true;
            this.chestCheckBox.CheckedChanged += new System.EventHandler(this.chestCheckBox_CheckedChanged);
            // 
            // fenceCheckBox
            // 
            this.fenceCheckBox.AutoSize = true;
            this.fenceCheckBox.Location = new System.Drawing.Point(33, 268);
            this.fenceCheckBox.Name = "fenceCheckBox";
            this.fenceCheckBox.Size = new System.Drawing.Size(56, 17);
            this.fenceCheckBox.TabIndex = 17;
            this.fenceCheckBox.Text = "Fence";
            this.fenceCheckBox.UseVisualStyleBackColor = true;
            this.fenceCheckBox.CheckedChanged += new System.EventHandler(this.fenceCheckBox_CheckedChanged);
            // 
            // stairsCheckBox
            // 
            this.stairsCheckBox.AutoSize = true;
            this.stairsCheckBox.Location = new System.Drawing.Point(33, 199);
            this.stairsCheckBox.Name = "stairsCheckBox";
            this.stairsCheckBox.Size = new System.Drawing.Size(52, 17);
            this.stairsCheckBox.TabIndex = 16;
            this.stairsCheckBox.Text = "Stairs";
            this.stairsCheckBox.UseVisualStyleBackColor = true;
            this.stairsCheckBox.CheckedChanged += new System.EventHandler(this.stairsCheckBox_CheckedChanged);
            // 
            // itemCheckBox
            // 
            this.itemCheckBox.AutoSize = true;
            this.itemCheckBox.Location = new System.Drawing.Point(33, 176);
            this.itemCheckBox.Name = "itemCheckBox";
            this.itemCheckBox.Size = new System.Drawing.Size(46, 17);
            this.itemCheckBox.TabIndex = 15;
            this.itemCheckBox.Text = "Item";
            this.itemCheckBox.UseVisualStyleBackColor = true;
            this.itemCheckBox.CheckedChanged += new System.EventHandler(this.itemCheckBox_CheckedChanged);
            // 
            // blockCheckBox
            // 
            this.blockCheckBox.AutoSize = true;
            this.blockCheckBox.Location = new System.Drawing.Point(33, 153);
            this.blockCheckBox.Name = "blockCheckBox";
            this.blockCheckBox.Size = new System.Drawing.Size(53, 17);
            this.blockCheckBox.TabIndex = 14;
            this.blockCheckBox.Text = "Block";
            this.blockCheckBox.UseVisualStyleBackColor = true;
            this.blockCheckBox.CheckedChanged += new System.EventHandler(this.blockCheckBox_CheckedChanged);
            // 
            // realNameText
            // 
            this.realNameText.Enabled = false;
            this.realNameText.Location = new System.Drawing.Point(115, 72);
            this.realNameText.Name = "realNameText";
            this.realNameText.Size = new System.Drawing.Size(462, 20);
            this.realNameText.TabIndex = 13;
            // 
            // realNameLabel
            // 
            this.realNameLabel.AutoSize = true;
            this.realNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.realNameLabel.Location = new System.Drawing.Point(19, 73);
            this.realNameLabel.Name = "realNameLabel";
            this.realNameLabel.Size = new System.Drawing.Size(78, 17);
            this.realNameLabel.TabIndex = 12;
            this.realNameLabel.Text = "Real Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 123);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 17);
            this.label2.TabIndex = 8;
            this.label2.Text = "Object Type";
            // 
            // textureFileChooseButton
            // 
            this.textureFileChooseButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textureFileChooseButton.Location = new System.Drawing.Point(502, 326);
            this.textureFileChooseButton.Name = "textureFileChooseButton";
            this.textureFileChooseButton.Size = new System.Drawing.Size(75, 23);
            this.textureFileChooseButton.TabIndex = 6;
            this.textureFileChooseButton.Text = "Choose";
            this.textureFileChooseButton.UseVisualStyleBackColor = true;
            this.textureFileChooseButton.Click += new System.EventHandler(this.textureFileChooseButton_Click);
            // 
            // textureFileText
            // 
            this.textureFileText.Enabled = false;
            this.textureFileText.Location = new System.Drawing.Point(115, 328);
            this.textureFileText.Name = "textureFileText";
            this.textureFileText.Size = new System.Drawing.Size(381, 20);
            this.textureFileText.TabIndex = 5;
            // 
            // displayNameText
            // 
            this.displayNameText.Location = new System.Drawing.Point(115, 46);
            this.displayNameText.Name = "displayNameText";
            this.displayNameText.Size = new System.Drawing.Size(462, 20);
            this.displayNameText.TabIndex = 4;
            this.displayNameText.TextChanged += new System.EventHandler(this.displayNameText_TextChanged);
            // 
            // itemNameText
            // 
            this.itemNameText.Location = new System.Drawing.Point(115, 21);
            this.itemNameText.Name = "itemNameText";
            this.itemNameText.Size = new System.Drawing.Size(462, 20);
            this.itemNameText.TabIndex = 3;
            this.itemNameText.TextChanged += new System.EventHandler(this.itemNameText_TextChanged);
            // 
            // textureLabel
            // 
            this.textureLabel.AutoSize = true;
            this.textureLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textureLabel.Location = new System.Drawing.Point(19, 329);
            this.textureLabel.Name = "textureLabel";
            this.textureLabel.Size = new System.Drawing.Size(82, 17);
            this.textureLabel.TabIndex = 2;
            this.textureLabel.Text = "Texture File";
            this.textureLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // displayNameLabel
            // 
            this.displayNameLabel.AutoSize = true;
            this.displayNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.displayNameLabel.Location = new System.Drawing.Point(19, 47);
            this.displayNameLabel.Name = "displayNameLabel";
            this.displayNameLabel.Size = new System.Drawing.Size(95, 17);
            this.displayNameLabel.TabIndex = 1;
            this.displayNameLabel.Text = "Display Name";
            // 
            // itemNameLabel
            // 
            this.itemNameLabel.AutoSize = true;
            this.itemNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.itemNameLabel.Location = new System.Drawing.Point(19, 21);
            this.itemNameLabel.Name = "itemNameLabel";
            this.itemNameLabel.Size = new System.Drawing.Size(75, 17);
            this.itemNameLabel.TabIndex = 0;
            this.itemNameLabel.Text = "Item Name";
            // 
            // refreshButton
            // 
            this.refreshButton.Location = new System.Drawing.Point(56, 418);
            this.refreshButton.Name = "refreshButton";
            this.refreshButton.Size = new System.Drawing.Size(120, 23);
            this.refreshButton.TabIndex = 10;
            this.refreshButton.Text = "Refresh";
            this.refreshButton.UseVisualStyleBackColor = true;
            this.refreshButton.Click += new System.EventHandler(this.refreshButton_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(825, 457);
            this.Controls.Add(this.refreshButton);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.jsonGenerateButton);
            this.Controls.Add(this.outputPathText);
            this.Controls.Add(this.outputPathSelectionButton);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.modidText);
            this.Controls.Add(this.itemListBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Json Mod Tool";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox itemListBox;
        private System.Windows.Forms.FolderBrowserDialog outputPathPicker;
        private System.Windows.Forms.TextBox modidText;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button outputPathSelectionButton;
        private System.Windows.Forms.TextBox outputPathText;
        private System.Windows.Forms.Button jsonGenerateButton;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button textureFileChooseButton;
        private System.Windows.Forms.TextBox textureFileText;
        private System.Windows.Forms.TextBox displayNameText;
        private System.Windows.Forms.TextBox itemNameText;
        private System.Windows.Forms.Label textureLabel;
        private System.Windows.Forms.Label displayNameLabel;
        private System.Windows.Forms.Label itemNameLabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button refreshButton;
        private System.Windows.Forms.TextBox realNameText;
        private System.Windows.Forms.Label realNameLabel;
        private System.Windows.Forms.CheckBox slabCheckBox;
        private System.Windows.Forms.CheckBox wallCheckBox;
        private System.Windows.Forms.CheckBox chestCheckBox;
        private System.Windows.Forms.CheckBox fenceCheckBox;
        private System.Windows.Forms.CheckBox stairsCheckBox;
        private System.Windows.Forms.CheckBox itemCheckBox;
        private System.Windows.Forms.CheckBox blockCheckBox;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.TextBox blockVariantDisplayText;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label variantLabel;
        private System.Windows.Forms.TextBox chestVariantRealText;
        private System.Windows.Forms.TextBox fenceVariantRealText;
        private System.Windows.Forms.TextBox wallVariantRealText;
        private System.Windows.Forms.TextBox slabVariantRealText;
        private System.Windows.Forms.TextBox stairsVariantRealText;
        private System.Windows.Forms.TextBox itemVariantRealText;
        private System.Windows.Forms.TextBox blockVariantRealText;
        private System.Windows.Forms.TextBox chestVariantDisplayText;
        private System.Windows.Forms.TextBox fenceVariantDisplayText;
        private System.Windows.Forms.TextBox wallVariantDisplayText;
        private System.Windows.Forms.TextBox slabVariantDisplayText;
        private System.Windows.Forms.TextBox stairsVariantDisplayText;
        private System.Windows.Forms.TextBox itemVariantDisplayText;
    }
}

