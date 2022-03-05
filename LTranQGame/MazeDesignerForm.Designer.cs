
namespace LTranQGame
{
    partial class MazeDesignerForm
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
            this.btnGenerate = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtRowNumber = new System.Windows.Forms.TextBox();
            this.txtColumnNumber = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnWall = new System.Windows.Forms.Button();
            this.btnNone = new System.Windows.Forms.Button();
            this.btnDoor1 = new System.Windows.Forms.Button();
            this.btnBox2 = new System.Windows.Forms.Button();
            this.btnDoor2 = new System.Windows.Forms.Button();
            this.btnBox1 = new System.Windows.Forms.Button();
            this.dlgSave = new System.Windows.Forms.SaveFileDialog();
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnGenerate
            // 
            this.btnGenerate.Location = new System.Drawing.Point(479, 12);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(218, 27);
            this.btnGenerate.TabIndex = 0;
            this.btnGenerate.Text = "Generate";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Row #:";
            // 
            // txtRowNumber
            // 
            this.txtRowNumber.Location = new System.Drawing.Point(68, 14);
            this.txtRowNumber.Name = "txtRowNumber";
            this.txtRowNumber.Size = new System.Drawing.Size(144, 22);
            this.txtRowNumber.TabIndex = 2;
            // 
            // txtColumnNumber
            // 
            this.txtColumnNumber.Location = new System.Drawing.Point(311, 14);
            this.txtColumnNumber.Name = "txtColumnNumber";
            this.txtColumnNumber.Size = new System.Drawing.Size(144, 22);
            this.txtColumnNumber.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(234, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Column #:";
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1110, 28);
            this.menuStrip1.TabIndex = 19;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveToolStripMenuItem,
            this.closeToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(46, 24);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.saveToolStripMenuItem.Text = "&Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.closeToolStripMenuItem.Text = "&Close";
            this.closeToolStripMenuItem.Click += new System.EventHandler(this.closeToolStripMenuItem_Click);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.txtRowNumber);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtColumnNumber);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.btnGenerate);
            this.panel1.Location = new System.Drawing.Point(0, 31);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1110, 50);
            this.panel1.TabIndex = 20;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnWall);
            this.groupBox1.Controls.Add(this.btnNone);
            this.groupBox1.Controls.Add(this.btnDoor1);
            this.groupBox1.Controls.Add(this.btnBox2);
            this.groupBox1.Controls.Add(this.btnDoor2);
            this.groupBox1.Controls.Add(this.btnBox1);
            this.groupBox1.Location = new System.Drawing.Point(0, 87);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(167, 412);
            this.groupBox1.TabIndex = 21;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "ToolBox";
            // 
            // btnWall
            // 
            this.btnWall.Image = global::LTranQGame.Properties.Resources.wall;
            this.btnWall.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnWall.Location = new System.Drawing.Point(15, 92);
            this.btnWall.Name = "btnWall";
            this.btnWall.Size = new System.Drawing.Size(110, 52);
            this.btnWall.TabIndex = 8;
            this.btnWall.Text = "Wall";
            this.btnWall.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnWall.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnWall.UseVisualStyleBackColor = true;
            this.btnWall.Click += new System.EventHandler(this.btnWall_Click);
            // 
            // btnNone
            // 
            this.btnNone.Image = global::LTranQGame.Properties.Resources.none;
            this.btnNone.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNone.Location = new System.Drawing.Point(15, 32);
            this.btnNone.Name = "btnNone";
            this.btnNone.Size = new System.Drawing.Size(110, 54);
            this.btnNone.TabIndex = 16;
            this.btnNone.Text = "None";
            this.btnNone.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnNone.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnNone.UseVisualStyleBackColor = true;
            this.btnNone.Click += new System.EventHandler(this.btnNone_Click);
            // 
            // btnDoor1
            // 
            this.btnDoor1.Image = global::LTranQGame.Properties.Resources.greenDoor;
            this.btnDoor1.Location = new System.Drawing.Point(15, 150);
            this.btnDoor1.Name = "btnDoor1";
            this.btnDoor1.Size = new System.Drawing.Size(110, 52);
            this.btnDoor1.TabIndex = 9;
            this.btnDoor1.Text = "Door1";
            this.btnDoor1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDoor1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDoor1.UseVisualStyleBackColor = true;
            this.btnDoor1.Click += new System.EventHandler(this.btnDoor1_Click);
            // 
            // btnBox2
            // 
            this.btnBox2.Image = global::LTranQGame.Properties.Resources.zhongliYellow;
            this.btnBox2.Location = new System.Drawing.Point(15, 324);
            this.btnBox2.Name = "btnBox2";
            this.btnBox2.Size = new System.Drawing.Size(110, 52);
            this.btnBox2.TabIndex = 14;
            this.btnBox2.Text = "Box2";
            this.btnBox2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnBox2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnBox2.UseVisualStyleBackColor = true;
            this.btnBox2.Click += new System.EventHandler(this.btnBox2_Click);
            // 
            // btnDoor2
            // 
            this.btnDoor2.Image = global::LTranQGame.Properties.Resources.yellowDoor;
            this.btnDoor2.Location = new System.Drawing.Point(15, 208);
            this.btnDoor2.Name = "btnDoor2";
            this.btnDoor2.Size = new System.Drawing.Size(110, 52);
            this.btnDoor2.TabIndex = 10;
            this.btnDoor2.Text = "Door2";
            this.btnDoor2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDoor2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDoor2.UseVisualStyleBackColor = true;
            this.btnDoor2.Click += new System.EventHandler(this.btnDoor2_Click);
            // 
            // btnBox1
            // 
            this.btnBox1.Image = global::LTranQGame.Properties.Resources.xiaoGreen;
            this.btnBox1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBox1.Location = new System.Drawing.Point(15, 266);
            this.btnBox1.Name = "btnBox1";
            this.btnBox1.Size = new System.Drawing.Size(110, 52);
            this.btnBox1.TabIndex = 12;
            this.btnBox1.Text = "Box1";
            this.btnBox1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnBox1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnBox1.UseVisualStyleBackColor = true;
            this.btnBox1.Click += new System.EventHandler(this.btnBox1_Click);
            // 
            // MazeDesignerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1110, 553);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MazeDesignerForm";
            this.Text = "MazeDesignerForm";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtRowNumber;
        private System.Windows.Forms.TextBox txtColumnNumber;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnWall;
        private System.Windows.Forms.Button btnDoor1;
        private System.Windows.Forms.Button btnDoor2;
        private System.Windows.Forms.Button btnBox1;
        private System.Windows.Forms.Button btnBox2;
        private System.Windows.Forms.Button btnNone;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.SaveFileDialog dlgSave;
    }
}