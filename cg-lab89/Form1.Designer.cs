namespace cg_lab89
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            groupSettings = new GroupBox();
            panel2 = new Panel();
            radioRenderZbuffer = new RadioButton();
            radioRenderPruning = new RadioButton();
            radioRenderDefault = new RadioButton();
            label4 = new Label();
            panelObject = new Panel();
            panelRotate = new Panel();
            radioRotateZ = new RadioButton();
            radioRotateY = new RadioButton();
            radioRotateX = new RadioButton();
            buttonR = new Button();
            label18 = new Label();
            textR = new TextBox();
            label19 = new Label();
            panelResize = new Panel();
            buttonResize = new Button();
            label13 = new Label();
            label14 = new Label();
            label15 = new Label();
            textMZ = new TextBox();
            textMY = new TextBox();
            textMX = new TextBox();
            label16 = new Label();
            panelShift = new Panel();
            buttonShift = new Button();
            label9 = new Label();
            label10 = new Label();
            label11 = new Label();
            textSZ = new TextBox();
            textSY = new TextBox();
            textSX = new TextBox();
            label12 = new Label();
            labelObjectInfo = new Label();
            label2 = new Label();
            panelCamera = new Panel();
            label3 = new Label();
            trackBar2 = new TrackBar();
            label1 = new Label();
            trackBar1 = new TrackBar();
            labelCamera = new Label();
            contextMenuCreate = new ContextMenuStrip(components);
            объектToolStripMenuItem = new ToolStripMenuItem();
            contextMenuCreateTetrahedron = new ToolStripMenuItem();
            contextMenuCreateHexahedron = new ToolStripMenuItem();
            contextMenuCreateDodecahedron = new ToolStripMenuItem();
            икосаэдрToolStripMenuItem = new ToolStripMenuItem();
            октаэдрToolStripMenuItem = new ToolStripMenuItem();
            pictureBox1 = new PictureBox();
            toolStrip1 = new ToolStrip();
            toolStripComboBox1 = new ToolStripComboBox();
            label5 = new Label();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            textBox3 = new TextBox();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            buttonRotate = new Button();
            графикToolStripMenuItem = new ToolStripMenuItem();
            groupSettings.SuspendLayout();
            panel2.SuspendLayout();
            panelObject.SuspendLayout();
            panelRotate.SuspendLayout();
            panelResize.SuspendLayout();
            panelShift.SuspendLayout();
            panelCamera.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)trackBar2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trackBar1).BeginInit();
            contextMenuCreate.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            toolStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // groupSettings
            // 
            groupSettings.Controls.Add(panel2);
            groupSettings.Controls.Add(panelObject);
            groupSettings.Controls.Add(panelCamera);
            groupSettings.ForeColor = SystemColors.Window;
            groupSettings.Location = new Point(12, 34);
            groupSettings.Name = "groupSettings";
            groupSettings.Size = new Size(256, 611);
            groupSettings.TabIndex = 0;
            groupSettings.TabStop = false;
            groupSettings.Text = "Свойства";
            // 
            // panel2
            // 
            panel2.Controls.Add(radioRenderZbuffer);
            panel2.Controls.Add(radioRenderPruning);
            panel2.Controls.Add(radioRenderDefault);
            panel2.Controls.Add(label4);
            panel2.Location = new Point(6, 22);
            panel2.Name = "panel2";
            panel2.Size = new Size(244, 118);
            panel2.TabIndex = 3;
            // 
            // radioRenderZbuffer
            // 
            radioRenderZbuffer.AutoSize = true;
            radioRenderZbuffer.Location = new Point(6, 68);
            radioRenderZbuffer.Name = "radioRenderZbuffer";
            radioRenderZbuffer.Size = new Size(81, 19);
            radioRenderZbuffer.TabIndex = 6;
            radioRenderZbuffer.TabStop = true;
            radioRenderZbuffer.Text = "Z-буффер";
            radioRenderZbuffer.UseVisualStyleBackColor = true;
            // 
            // radioRenderPruning
            // 
            radioRenderPruning.AutoSize = true;
            radioRenderPruning.Location = new Point(6, 43);
            radioRenderPruning.Name = "radioRenderPruning";
            radioRenderPruning.Size = new Size(141, 19);
            radioRenderPruning.TabIndex = 5;
            radioRenderPruning.TabStop = true;
            radioRenderPruning.Text = "Удаление нелицевых";
            radioRenderPruning.UseVisualStyleBackColor = true;
            // 
            // radioRenderDefault
            // 
            radioRenderDefault.AutoSize = true;
            radioRenderDefault.Checked = true;
            radioRenderDefault.Location = new Point(6, 18);
            radioRenderDefault.Name = "radioRenderDefault";
            radioRenderDefault.Size = new Size(105, 19);
            radioRenderDefault.TabIndex = 4;
            radioRenderDefault.TabStop = true;
            radioRenderDefault.Text = "Без обработки";
            radioRenderDefault.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(6, 0);
            label4.Name = "label4";
            label4.Size = new Size(46, 15);
            label4.TabIndex = 3;
            label4.Text = "Рендер";
            // 
            // panelObject
            // 
            panelObject.Controls.Add(panelRotate);
            panelObject.Controls.Add(panelResize);
            panelObject.Controls.Add(panelShift);
            panelObject.Controls.Add(labelObjectInfo);
            panelObject.Controls.Add(label2);
            panelObject.Location = new Point(6, 270);
            panelObject.Name = "panelObject";
            panelObject.Size = new Size(244, 335);
            panelObject.TabIndex = 1;
            // 
            // panelRotate
            // 
            panelRotate.Controls.Add(radioRotateZ);
            panelRotate.Controls.Add(radioRotateY);
            panelRotate.Controls.Add(radioRotateX);
            panelRotate.Controls.Add(buttonR);
            panelRotate.Controls.Add(label18);
            panelRotate.Controls.Add(textR);
            panelRotate.Controls.Add(label19);
            panelRotate.Location = new Point(3, 43);
            panelRotate.Name = "panelRotate";
            panelRotate.Size = new Size(229, 74);
            panelRotate.TabIndex = 9;
            // 
            // radioRotateZ
            // 
            radioRotateZ.AutoSize = true;
            radioRotateZ.Location = new Point(131, 47);
            radioRotateZ.Name = "radioRotateZ";
            radioRotateZ.Size = new Size(32, 19);
            radioRotateZ.TabIndex = 5;
            radioRotateZ.TabStop = true;
            radioRotateZ.Text = "Z";
            radioRotateZ.UseVisualStyleBackColor = true;
            // 
            // radioRotateY
            // 
            radioRotateY.AutoSize = true;
            radioRotateY.Location = new Point(93, 47);
            radioRotateY.Name = "radioRotateY";
            radioRotateY.Size = new Size(32, 19);
            radioRotateY.TabIndex = 4;
            radioRotateY.TabStop = true;
            radioRotateY.Text = "Y";
            radioRotateY.UseVisualStyleBackColor = true;
            // 
            // radioRotateX
            // 
            radioRotateX.AutoSize = true;
            radioRotateX.Location = new Point(55, 47);
            radioRotateX.Name = "radioRotateX";
            radioRotateX.Size = new Size(32, 19);
            radioRotateX.TabIndex = 3;
            radioRotateX.TabStop = true;
            radioRotateX.Text = "X";
            radioRotateX.UseVisualStyleBackColor = true;
            // 
            // buttonR
            // 
            buttonR.BackColor = SystemColors.AppWorkspace;
            buttonR.FlatAppearance.BorderSize = 0;
            buttonR.Location = new Point(140, 18);
            buttonR.Name = "buttonR";
            buttonR.Size = new Size(75, 23);
            buttonR.TabIndex = 3;
            buttonR.Text = "Повернуть";
            buttonR.UseVisualStyleBackColor = false;
            buttonR.Click += buttonR_Click;
            // 
            // label18
            // 
            label18.AutoSize = true;
            label18.Location = new Point(3, 21);
            label18.Name = "label18";
            label18.Size = new Size(14, 15);
            label18.TabIndex = 3;
            label18.Text = "V";
            // 
            // textR
            // 
            textR.Location = new Point(23, 18);
            textR.Name = "textR";
            textR.Size = new Size(102, 23);
            textR.TabIndex = 3;
            textR.Text = "0";
            // 
            // label19
            // 
            label19.AutoSize = true;
            label19.Location = new Point(81, 0);
            label19.Name = "label19";
            label19.Size = new Size(64, 15);
            label19.TabIndex = 3;
            label19.Text = "Вращение";
            // 
            // panelResize
            // 
            panelResize.Controls.Add(buttonResize);
            panelResize.Controls.Add(label13);
            panelResize.Controls.Add(label14);
            panelResize.Controls.Add(label15);
            panelResize.Controls.Add(textMZ);
            panelResize.Controls.Add(textMY);
            panelResize.Controls.Add(textMX);
            panelResize.Controls.Add(label16);
            panelResize.Location = new Point(3, 229);
            panelResize.Name = "panelResize";
            panelResize.Size = new Size(229, 100);
            panelResize.TabIndex = 8;
            // 
            // buttonResize
            // 
            buttonResize.BackColor = SystemColors.AppWorkspace;
            buttonResize.FlatAppearance.BorderSize = 0;
            buttonResize.Location = new Point(131, 73);
            buttonResize.Name = "buttonResize";
            buttonResize.Size = new Size(95, 23);
            buttonResize.TabIndex = 3;
            buttonResize.Text = "Масштаб";
            buttonResize.UseVisualStyleBackColor = false;
            buttonResize.Click += buttonResize_Click;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(3, 77);
            label13.Name = "label13";
            label13.Size = new Size(14, 15);
            label13.TabIndex = 7;
            label13.Text = "Z";
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Location = new Point(3, 50);
            label14.Name = "label14";
            label14.Size = new Size(14, 15);
            label14.TabIndex = 6;
            label14.Text = "Y";
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Location = new Point(3, 21);
            label15.Name = "label15";
            label15.Size = new Size(14, 15);
            label15.TabIndex = 3;
            label15.Text = "X";
            // 
            // textMZ
            // 
            textMZ.Location = new Point(23, 74);
            textMZ.Name = "textMZ";
            textMZ.Size = new Size(102, 23);
            textMZ.TabIndex = 5;
            textMZ.Text = "1";
            // 
            // textMY
            // 
            textMY.Location = new Point(23, 47);
            textMY.Name = "textMY";
            textMY.Size = new Size(102, 23);
            textMY.TabIndex = 4;
            textMY.Text = "1";
            // 
            // textMX
            // 
            textMX.Location = new Point(23, 18);
            textMX.Name = "textMX";
            textMX.Size = new Size(102, 23);
            textMX.TabIndex = 3;
            textMX.Text = "1";
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Location = new Point(86, 0);
            label16.Name = "label16";
            label16.Size = new Size(59, 15);
            label16.TabIndex = 3;
            label16.Text = "Масштаб";
            // 
            // panelShift
            // 
            panelShift.Controls.Add(buttonShift);
            panelShift.Controls.Add(label9);
            panelShift.Controls.Add(label10);
            panelShift.Controls.Add(label11);
            panelShift.Controls.Add(textSZ);
            panelShift.Controls.Add(textSY);
            panelShift.Controls.Add(textSX);
            panelShift.Controls.Add(label12);
            panelShift.Location = new Point(3, 123);
            panelShift.Name = "panelShift";
            panelShift.Size = new Size(229, 100);
            panelShift.TabIndex = 8;
            // 
            // buttonShift
            // 
            buttonShift.BackColor = SystemColors.AppWorkspace;
            buttonShift.FlatAppearance.BorderSize = 0;
            buttonShift.Location = new Point(140, 73);
            buttonShift.Name = "buttonShift";
            buttonShift.Size = new Size(75, 23);
            buttonShift.TabIndex = 3;
            buttonShift.Text = "Сдвинуть";
            buttonShift.UseVisualStyleBackColor = false;
            buttonShift.Click += buttonShift_Click;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(3, 77);
            label9.Name = "label9";
            label9.Size = new Size(14, 15);
            label9.TabIndex = 7;
            label9.Text = "Z";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(3, 50);
            label10.Name = "label10";
            label10.Size = new Size(14, 15);
            label10.TabIndex = 6;
            label10.Text = "Y";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(3, 21);
            label11.Name = "label11";
            label11.Size = new Size(14, 15);
            label11.TabIndex = 3;
            label11.Text = "X";
            // 
            // textSZ
            // 
            textSZ.Location = new Point(23, 74);
            textSZ.Name = "textSZ";
            textSZ.Size = new Size(102, 23);
            textSZ.TabIndex = 5;
            textSZ.Text = "0";
            // 
            // textSY
            // 
            textSY.Location = new Point(23, 47);
            textSY.Name = "textSY";
            textSY.Size = new Size(102, 23);
            textSY.TabIndex = 4;
            textSY.Text = "0";
            // 
            // textSX
            // 
            textSX.Location = new Point(23, 18);
            textSX.Name = "textSX";
            textSX.Size = new Size(102, 23);
            textSX.TabIndex = 3;
            textSX.Text = "0";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(96, 0);
            label12.Name = "label12";
            label12.Size = new Size(39, 15);
            label12.TabIndex = 3;
            label12.Text = "Сдвиг";
            // 
            // labelObjectInfo
            // 
            labelObjectInfo.AutoSize = true;
            labelObjectInfo.Location = new Point(3, 25);
            labelObjectInfo.Name = "labelObjectInfo";
            labelObjectInfo.Size = new Size(122, 15);
            labelObjectInfo.TabIndex = 3;
            labelObjectInfo.Text = "Координаты центра: ";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(3, 0);
            label2.Name = "label2";
            label2.Size = new Size(47, 15);
            label2.TabIndex = 0;
            label2.Text = "Объект";
            // 
            // panelCamera
            // 
            panelCamera.Controls.Add(label3);
            panelCamera.Controls.Add(trackBar2);
            panelCamera.Controls.Add(label1);
            panelCamera.Controls.Add(trackBar1);
            panelCamera.Controls.Add(labelCamera);
            panelCamera.Location = new Point(6, 146);
            panelCamera.Name = "panelCamera";
            panelCamera.Size = new Size(244, 118);
            panelCamera.TabIndex = 0;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(99, 64);
            label3.Name = "label3";
            label3.Size = new Size(39, 15);
            label3.TabIndex = 4;
            label3.Text = "Zoom";
            // 
            // trackBar2
            // 
            trackBar2.Location = new Point(3, 82);
            trackBar2.Maximum = 180;
            trackBar2.Name = "trackBar2";
            trackBar2.Size = new Size(229, 45);
            trackBar2.TabIndex = 5;
            trackBar2.Value = 70;
            trackBar2.Scroll += trackBar1_Scroll;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(99, 13);
            label1.Name = "label1";
            label1.Size = new Size(29, 15);
            label1.TabIndex = 3;
            label1.Text = "FOV";
            // 
            // trackBar1
            // 
            trackBar1.Location = new Point(3, 31);
            trackBar1.Maximum = 180;
            trackBar1.Name = "trackBar1";
            trackBar1.Size = new Size(229, 45);
            trackBar1.TabIndex = 3;
            trackBar1.Value = 70;
            trackBar1.Scroll += trackBar1_Scroll;
            // 
            // labelCamera
            // 
            labelCamera.AutoSize = true;
            labelCamera.Location = new Point(3, 0);
            labelCamera.Name = "labelCamera";
            labelCamera.Size = new Size(48, 15);
            labelCamera.TabIndex = 0;
            labelCamera.Text = "Камера";
            // 
            // contextMenuCreate
            // 
            contextMenuCreate.Items.AddRange(new ToolStripItem[] { объектToolStripMenuItem });
            contextMenuCreate.Name = "contextMenuCreate";
            contextMenuCreate.Size = new Size(181, 48);
            contextMenuCreate.Opening += contextMenuCreate_Opening;
            // 
            // объектToolStripMenuItem
            // 
            объектToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { contextMenuCreateTetrahedron, contextMenuCreateHexahedron, contextMenuCreateDodecahedron, икосаэдрToolStripMenuItem, октаэдрToolStripMenuItem, графикToolStripMenuItem });
            объектToolStripMenuItem.Name = "объектToolStripMenuItem";
            объектToolStripMenuItem.Size = new Size(180, 22);
            объектToolStripMenuItem.Text = "Создать";
            // 
            // contextMenuCreateTetrahedron
            // 
            contextMenuCreateTetrahedron.Name = "contextMenuCreateTetrahedron";
            contextMenuCreateTetrahedron.Size = new Size(180, 22);
            contextMenuCreateTetrahedron.Text = "Тетраэдр";
            contextMenuCreateTetrahedron.Click += contextMenuCreateFigure;
            // 
            // contextMenuCreateHexahedron
            // 
            contextMenuCreateHexahedron.Name = "contextMenuCreateHexahedron";
            contextMenuCreateHexahedron.Size = new Size(180, 22);
            contextMenuCreateHexahedron.Text = "Гексаэдр";
            contextMenuCreateHexahedron.Click += contextMenuCreateFigure;
            // 
            // contextMenuCreateDodecahedron
            // 
            contextMenuCreateDodecahedron.Name = "contextMenuCreateDodecahedron";
            contextMenuCreateDodecahedron.Size = new Size(180, 22);
            contextMenuCreateDodecahedron.Text = "Додекаэдр";
            contextMenuCreateDodecahedron.Click += contextMenuCreateFigure;
            // 
            // икосаэдрToolStripMenuItem
            // 
            икосаэдрToolStripMenuItem.Name = "икосаэдрToolStripMenuItem";
            икосаэдрToolStripMenuItem.Size = new Size(180, 22);
            икосаэдрToolStripMenuItem.Text = "Икосаэдр";
            икосаэдрToolStripMenuItem.Click += contextMenuCreateFigure;
            // 
            // октаэдрToolStripMenuItem
            // 
            октаэдрToolStripMenuItem.Name = "октаэдрToolStripMenuItem";
            октаэдрToolStripMenuItem.Size = new Size(180, 22);
            октаэдрToolStripMenuItem.Text = "Октаэдр";
            октаэдрToolStripMenuItem.Click += contextMenuCreateFigure;
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(274, 22);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(1237, 617);
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            pictureBox1.Paint += graphicPanel_Paint;
            pictureBox1.MouseClick += panel1_MouseClick;
            // 
            // toolStrip1
            // 
            toolStrip1.BackColor = SystemColors.ControlDarkDark;
            toolStrip1.Items.AddRange(new ToolStripItem[] { toolStripComboBox1 });
            toolStrip1.Location = new Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(1555, 25);
            toolStrip1.TabIndex = 2;
            toolStrip1.Text = "toolStrip1";
            // 
            // toolStripComboBox1
            // 
            toolStripComboBox1.BackColor = SystemColors.ControlDark;
            toolStripComboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            toolStripComboBox1.ForeColor = SystemColors.Window;
            toolStripComboBox1.Name = "toolStripComboBox1";
            toolStripComboBox1.Size = new Size(121, 25);
            toolStripComboBox1.SelectedIndexChanged += toolStripComboBox1_SelectedIndexChanged;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(49, 0);
            label5.Name = "label5";
            label5.Size = new Size(129, 15);
            label5.TabIndex = 3;
            label5.Text = "Поворт вокруг центра";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(23, 18);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(102, 23);
            textBox1.TabIndex = 3;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(23, 47);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(102, 23);
            textBox2.TabIndex = 4;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(23, 74);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(102, 23);
            textBox3.TabIndex = 5;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(3, 21);
            label6.Name = "label6";
            label6.Size = new Size(14, 15);
            label6.TabIndex = 3;
            label6.Text = "X";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(3, 50);
            label7.Name = "label7";
            label7.Size = new Size(14, 15);
            label7.TabIndex = 6;
            label7.Text = "Y";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(3, 77);
            label8.Name = "label8";
            label8.Size = new Size(14, 15);
            label8.TabIndex = 7;
            label8.Text = "Z";
            // 
            // buttonRotate
            // 
            buttonRotate.BackColor = SystemColors.AppWorkspace;
            buttonRotate.FlatAppearance.BorderSize = 0;
            buttonRotate.Location = new Point(140, 73);
            buttonRotate.Name = "buttonRotate";
            buttonRotate.Size = new Size(75, 23);
            buttonRotate.TabIndex = 3;
            buttonRotate.Text = "Повернуть";
            buttonRotate.UseVisualStyleBackColor = false;
            // 
            // графикToolStripMenuItem
            // 
            графикToolStripMenuItem.Name = "графикToolStripMenuItem";
            графикToolStripMenuItem.Size = new Size(180, 22);
            графикToolStripMenuItem.Text = "График";
            графикToolStripMenuItem.Click += contextMenuCreateFigure;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlDarkDark;
            ClientSize = new Size(1555, 663);
            Controls.Add(toolStrip1);
            Controls.Add(pictureBox1);
            Controls.Add(groupSettings);
            KeyPreview = true;
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            KeyDown += Form1_KeyDown;
            groupSettings.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panelObject.ResumeLayout(false);
            panelObject.PerformLayout();
            panelRotate.ResumeLayout(false);
            panelRotate.PerformLayout();
            panelResize.ResumeLayout(false);
            panelResize.PerformLayout();
            panelShift.ResumeLayout(false);
            panelShift.PerformLayout();
            panelCamera.ResumeLayout(false);
            panelCamera.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)trackBar2).EndInit();
            ((System.ComponentModel.ISupportInitialize)trackBar1).EndInit();
            contextMenuCreate.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private GroupBox groupSettings;
        private Panel panelObject;
        private Panel panelCamera;
        private Label labelCamera;
        private Label label2;
        private ContextMenuStrip contextMenuCreate;
        private ToolStripMenuItem объектToolStripMenuItem;
        private ToolStripMenuItem contextMenuCreateTetrahedron;
        private ToolStripMenuItem contextMenuCreateHexahedron;
        private PictureBox pictureBox1;
        private ToolStrip toolStrip1;
        private ToolStripComboBox toolStripComboBox1;
        private Label label1;
        private TrackBar trackBar1;
        private Label label3;
        private TrackBar trackBar2;
        private Panel panel1;
        private Label labelObjectInfo;
        private Panel panelResize;
        private Button buttonResize;
        private Label label13;
        private Label label14;
        private Label label15;
        private TextBox textMZ;
        private TextBox textMY;
        private TextBox textMX;
        private Label label16;
        private Panel panelShift;
        private Button buttonShift;
        private Label label9;
        private Label label10;
        private Label label11;
        private TextBox textSZ;
        private TextBox textSY;
        private TextBox textSX;
        private Label label12;
        private Button buttonRotate;
        private Label label8;
        private Label label7;
        private Label label6;
        private TextBox textBox3;
        private TextBox textBox2;
        private TextBox textBox1;
        private Label label5;
        private Panel panelRotate;
        private Button buttonR;
        private Label label18;
        private TextBox textR;
        private Label label19;
        private RadioButton radioRotateZ;
        private RadioButton radioRotateY;
        private RadioButton radioRotateX;
        private Panel panel2;
        private RadioButton radioRenderZbuffer;
        private RadioButton radioRenderPruning;
        private RadioButton radioRenderDefault;
        private Label label4;
        private ToolStripMenuItem contextMenuCreateDodecahedron;
        private ToolStripMenuItem икосаэдрToolStripMenuItem;
        private ToolStripMenuItem октаэдрToolStripMenuItem;
        private ToolStripMenuItem графикToolStripMenuItem;
    }
}