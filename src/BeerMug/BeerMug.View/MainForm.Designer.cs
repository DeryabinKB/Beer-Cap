namespace BeerMug.View
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.buildButton = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.OuterDiametrLabel = new System.Windows.Forms.Label();
            this.ThicknessLabel = new System.Windows.Forms.Label();
            this.outerDiametrTextBox = new System.Windows.Forms.TextBox();
            this.thicknessTextBox = new System.Windows.Forms.TextBox();
            this.highTextBox = new System.Windows.Forms.TextBox();
            this.HighLabel = new System.Windows.Forms.Label();
            this.upperRadiusOfTheBottomTextBox = new System.Windows.Forms.TextBox();
            this.UpperRadiusOfTheBottomLabel = new System.Windows.Forms.Label();
            this.lowerRadiusOfTheBottomTextBox = new System.Windows.Forms.TextBox();
            this.LowerRadiusOfTheBottomLabel = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.bottomThicknessTextBox = new System.Windows.Forms.TextBox();
            this.BottomThicknessLabel = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.MinimumSizeButtom = new System.Windows.Forms.Button();
            this.MaximumSizeButton = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // buildButton
            // 
            this.buildButton.Location = new System.Drawing.Point(154, 363);
            this.buildButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.buildButton.Name = "buildButton";
            this.buildButton.Size = new System.Drawing.Size(122, 27);
            this.buildButton.TabIndex = 0;
            this.buildButton.Text = "Build model";
            this.buildButton.UseVisualStyleBackColor = true;
            this.buildButton.Click += new System.EventHandler(this.buildButton_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(461, 12);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(383, 398);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // OuterDiametrLabel
            // 
            this.OuterDiametrLabel.AutoSize = true;
            this.OuterDiametrLabel.Location = new System.Drawing.Point(14, 33);
            this.OuterDiametrLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.OuterDiametrLabel.Name = "OuterDiametrLabel";
            this.OuterDiametrLabel.Size = new System.Drawing.Size(100, 15);
            this.OuterDiametrLabel.TabIndex = 2;
            this.OuterDiametrLabel.Text = "Outer diametr (A)";
            // 
            // ThicknessLabel
            // 
            this.ThicknessLabel.AutoSize = true;
            this.ThicknessLabel.Location = new System.Drawing.Point(14, 92);
            this.ThicknessLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.ThicknessLabel.Name = "ThicknessLabel";
            this.ThicknessLabel.Size = new System.Drawing.Size(76, 15);
            this.ThicknessLabel.TabIndex = 3;
            this.ThicknessLabel.Text = "Thickness (B)";
            // 
            // outerDiametrTextBox
            // 
            this.outerDiametrTextBox.Location = new System.Drawing.Point(337, 30);
            this.outerDiametrTextBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.outerDiametrTextBox.Name = "outerDiametrTextBox";
            this.outerDiametrTextBox.Size = new System.Drawing.Size(116, 23);
            this.outerDiametrTextBox.TabIndex = 4;
            this.outerDiametrTextBox.TextChanged += new System.EventHandler(this.TextBoxValidator_TextChanged);
            this.outerDiametrTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.IntegerCheck_KeyPress);
            // 
            // thicknessTextBox
            // 
            this.thicknessTextBox.Location = new System.Drawing.Point(337, 89);
            this.thicknessTextBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.thicknessTextBox.Name = "thicknessTextBox";
            this.thicknessTextBox.Size = new System.Drawing.Size(116, 23);
            this.thicknessTextBox.TabIndex = 5;
            this.thicknessTextBox.TextChanged += new System.EventHandler(this.TextBoxValidator_TextChanged);
            this.thicknessTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.IntegerCheck_KeyPress);
            // 
            // highTextBox
            // 
            this.highTextBox.Location = new System.Drawing.Point(337, 143);
            this.highTextBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.highTextBox.Name = "highTextBox";
            this.highTextBox.Size = new System.Drawing.Size(116, 23);
            this.highTextBox.TabIndex = 6;
            this.highTextBox.TextChanged += new System.EventHandler(this.TextBoxValidator_TextChanged);
            this.highTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.IntegerCheck_KeyPress);
            // 
            // HighLabel
            // 
            this.HighLabel.AutoSize = true;
            this.HighLabel.Location = new System.Drawing.Point(14, 146);
            this.HighLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.HighLabel.Name = "HighLabel";
            this.HighLabel.Size = new System.Drawing.Size(52, 15);
            this.HighLabel.TabIndex = 7;
            this.HighLabel.Text = "High (C)";
            // 
            // upperRadiusOfTheBottomTextBox
            // 
            this.upperRadiusOfTheBottomTextBox.Location = new System.Drawing.Point(337, 250);
            this.upperRadiusOfTheBottomTextBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.upperRadiusOfTheBottomTextBox.Name = "upperRadiusOfTheBottomTextBox";
            this.upperRadiusOfTheBottomTextBox.Size = new System.Drawing.Size(116, 23);
            this.upperRadiusOfTheBottomTextBox.TabIndex = 8;
            this.upperRadiusOfTheBottomTextBox.TextChanged += new System.EventHandler(this.TextBoxValidator_TextChanged);
            this.upperRadiusOfTheBottomTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.IntegerCheck_KeyPress);
            // 
            // UpperRadiusOfTheBottomLabel
            // 
            this.UpperRadiusOfTheBottomLabel.AutoSize = true;
            this.UpperRadiusOfTheBottomLabel.Location = new System.Drawing.Point(14, 254);
            this.UpperRadiusOfTheBottomLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.UpperRadiusOfTheBottomLabel.Name = "UpperRadiusOfTheBottomLabel";
            this.UpperRadiusOfTheBottomLabel.Size = new System.Drawing.Size(168, 15);
            this.UpperRadiusOfTheBottomLabel.TabIndex = 9;
            this.UpperRadiusOfTheBottomLabel.Text = "Upper radius of the bottom (E)";
            // 
            // lowerRadiusOfTheBottomTextBox
            // 
            this.lowerRadiusOfTheBottomTextBox.Location = new System.Drawing.Point(337, 303);
            this.lowerRadiusOfTheBottomTextBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.lowerRadiusOfTheBottomTextBox.Name = "lowerRadiusOfTheBottomTextBox";
            this.lowerRadiusOfTheBottomTextBox.Size = new System.Drawing.Size(116, 23);
            this.lowerRadiusOfTheBottomTextBox.TabIndex = 10;
            this.lowerRadiusOfTheBottomTextBox.TextChanged += new System.EventHandler(this.TextBoxValidator_TextChanged);
            this.lowerRadiusOfTheBottomTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.IntegerCheck_KeyPress);
            // 
            // LowerRadiusOfTheBottomLabel
            // 
            this.LowerRadiusOfTheBottomLabel.AutoSize = true;
            this.LowerRadiusOfTheBottomLabel.Location = new System.Drawing.Point(14, 306);
            this.LowerRadiusOfTheBottomLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LowerRadiusOfTheBottomLabel.Name = "LowerRadiusOfTheBottomLabel";
            this.LowerRadiusOfTheBottomLabel.Size = new System.Drawing.Size(168, 15);
            this.LowerRadiusOfTheBottomLabel.TabIndex = 11;
            this.LowerRadiusOfTheBottomLabel.Text = "Lower radius of the bottom (F)";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(122, 33);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(75, 15);
            this.label6.TabIndex = 12;
            this.label6.Text = "(80-100 mm)";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(98, 92);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(57, 15);
            this.label7.TabIndex = 13;
            this.label7.Text = "(5-7 mm)";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(74, 146);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(81, 15);
            this.label8.TabIndex = 14;
            this.label8.Text = "(100-165 mm)";
            // 
            // bottomThicknessTextBox
            // 
            this.bottomThicknessTextBox.Location = new System.Drawing.Point(337, 193);
            this.bottomThicknessTextBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.bottomThicknessTextBox.Name = "bottomThicknessTextBox";
            this.bottomThicknessTextBox.Size = new System.Drawing.Size(116, 23);
            this.bottomThicknessTextBox.TabIndex = 15;
            this.bottomThicknessTextBox.TextChanged += new System.EventHandler(this.TextBoxValidator_TextChanged);
            this.bottomThicknessTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CheckForCommasAndNumbers_KeyPress);
            // 
            // BottomThicknessLabel
            // 
            this.BottomThicknessLabel.AutoSize = true;
            this.BottomThicknessLabel.Location = new System.Drawing.Point(14, 196);
            this.BottomThicknessLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.BottomThicknessLabel.Name = "BottomThicknessLabel";
            this.BottomThicknessLabel.Size = new System.Drawing.Size(118, 15);
            this.BottomThicknessLabel.TabIndex = 16;
            this.BottomThicknessLabel.Text = "Bottom thickness (D)";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(140, 196);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(78, 15);
            this.label10.TabIndex = 17;
            this.label10.Text = "(10-16,5 mm)";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(190, 253);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(75, 15);
            this.label11.TabIndex = 18;
            this.label11.Text = "(80-100 mm)";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(190, 306);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(69, 15);
            this.label12.TabIndex = 19;
            this.label12.Text = "(50-70 mm)";
            // 
            // MinimumSizeButtom
            // 
            this.MinimumSizeButtom.Location = new System.Drawing.Point(14, 363);
            this.MinimumSizeButtom.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MinimumSizeButtom.Name = "MinimumSizeButtom";
            this.MinimumSizeButtom.Size = new System.Drawing.Size(122, 27);
            this.MinimumSizeButtom.TabIndex = 31;
            this.MinimumSizeButtom.Text = "Minimum size";
            this.MinimumSizeButtom.UseVisualStyleBackColor = true;
            this.MinimumSizeButtom.Click += new System.EventHandler(this.MinimumSizeButtom_Click);
            // 
            // MaximumSizeButton
            // 
            this.MaximumSizeButton.Location = new System.Drawing.Point(296, 363);
            this.MaximumSizeButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximumSizeButton.Name = "MaximumSizeButton";
            this.MaximumSizeButton.Size = new System.Drawing.Size(122, 27);
            this.MaximumSizeButton.TabIndex = 32;
            this.MaximumSizeButton.Text = "Maximum size";
            this.MaximumSizeButton.UseVisualStyleBackColor = true;
            this.MaximumSizeButton.Click += new System.EventHandler(this.MaximumSizeButton_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(852, 12);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(385, 397);
            this.pictureBox2.TabIndex = 34;
            this.pictureBox2.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(264, 33);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 15);
            this.label1.TabIndex = 35;
            this.label1.Text = "A : E = 1 : 1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(256, 146);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 15);
            this.label2.TabIndex = 36;
            this.label2.Text = "C : D = 10 : 1";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(273, 254);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 15);
            this.label3.TabIndex = 37;
            this.label3.Text = "E - F = 30";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.ClientSize = new System.Drawing.Size(1244, 424);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.MaximumSizeButton);
            this.Controls.Add(this.MinimumSizeButtom);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.BottomThicknessLabel);
            this.Controls.Add(this.bottomThicknessTextBox);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.LowerRadiusOfTheBottomLabel);
            this.Controls.Add(this.lowerRadiusOfTheBottomTextBox);
            this.Controls.Add(this.UpperRadiusOfTheBottomLabel);
            this.Controls.Add(this.upperRadiusOfTheBottomTextBox);
            this.Controls.Add(this.HighLabel);
            this.Controls.Add(this.highTextBox);
            this.Controls.Add(this.thicknessTextBox);
            this.Controls.Add(this.outerDiametrTextBox);
            this.Controls.Add(this.ThicknessLabel);
            this.Controls.Add(this.OuterDiametrLabel);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.buildButton);
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "MainForm";
            this.Text = "Beer mug";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buildButton;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label OuterDiametrLabel;
        private System.Windows.Forms.Label ThicknessLabel;
        private System.Windows.Forms.TextBox outerDiametrTextBox;
        private System.Windows.Forms.TextBox thicknessTextBox;
        private System.Windows.Forms.TextBox highTextBox;
        private System.Windows.Forms.Label HighLabel;
        private System.Windows.Forms.TextBox upperRadiusOfTheBottomTextBox;
        private System.Windows.Forms.Label UpperRadiusOfTheBottomLabel;
        private System.Windows.Forms.TextBox lowerRadiusOfTheBottomTextBox;
        private System.Windows.Forms.Label LowerRadiusOfTheBottomLabel;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox bottomThicknessTextBox;
        private System.Windows.Forms.Label BottomThicknessLabel;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button MinimumSizeButtom;
        private System.Windows.Forms.Button MaximumSizeButton;
        private System.Windows.Forms.PictureBox pictureBox2;
        private Label label1;
        private Label label2;
        private Label label3;
    }
}
