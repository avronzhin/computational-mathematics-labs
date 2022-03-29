namespace ComputationalMathematic
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
      this.textBoxA = new System.Windows.Forms.TextBox();
      this.label1 = new System.Windows.Forms.Label();
      this.label2 = new System.Windows.Forms.Label();
      this.textBoxB = new System.Windows.Forms.TextBox();
      this.labelResult = new System.Windows.Forms.Label();
      this.buttonStart = new System.Windows.Forms.Button();
      this.groupBox1 = new System.Windows.Forms.GroupBox();
      this.radioButtonIteration = new System.Windows.Forms.RadioButton();
      this.radioButtonCombined = new System.Windows.Forms.RadioButton();
      this.radioButtonModifiedNewton = new System.Windows.Forms.RadioButton();
      this.radioButtonNewton = new System.Windows.Forms.RadioButton();
      this.radioButtonChord = new System.Windows.Forms.RadioButton();
      this.radioButtonDichotomy = new System.Windows.Forms.RadioButton();
      this.label3 = new System.Windows.Forms.Label();
      this.textBoxE = new System.Windows.Forms.TextBox();
      this.groupBox1.SuspendLayout();
      this.SuspendLayout();
      // 
      // textBoxA
      // 
      this.textBoxA.Location = new System.Drawing.Point(257, 63);
      this.textBoxA.Margin = new System.Windows.Forms.Padding(4);
      this.textBoxA.Name = "textBoxA";
      this.textBoxA.Size = new System.Drawing.Size(115, 32);
      this.textBoxA.TabIndex = 0;
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(74, 66);
      this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(169, 26);
      this.label1.TabIndex = 1;
      this.label1.Text = "Левая граница:";
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(74, 116);
      this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(181, 26);
      this.label2.TabIndex = 3;
      this.label2.Text = "Правая граница:";
      // 
      // textBoxB
      // 
      this.textBoxB.Location = new System.Drawing.Point(257, 113);
      this.textBoxB.Margin = new System.Windows.Forms.Padding(4);
      this.textBoxB.Name = "textBoxB";
      this.textBoxB.Size = new System.Drawing.Size(115, 32);
      this.textBoxB.TabIndex = 2;
      // 
      // labelResult
      // 
      this.labelResult.AutoSize = true;
      this.labelResult.Location = new System.Drawing.Point(74, 168);
      this.labelResult.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.labelResult.Name = "labelResult";
      this.labelResult.Size = new System.Drawing.Size(0, 26);
      this.labelResult.TabIndex = 5;
      // 
      // buttonStart
      // 
      this.buttonStart.Location = new System.Drawing.Point(177, 220);
      this.buttonStart.Margin = new System.Windows.Forms.Padding(4);
      this.buttonStart.Name = "buttonStart";
      this.buttonStart.Size = new System.Drawing.Size(182, 43);
      this.buttonStart.TabIndex = 6;
      this.buttonStart.Text = "Рассчитать";
      this.buttonStart.UseVisualStyleBackColor = true;
      this.buttonStart.Click += new System.EventHandler(this.ButtonStart_Click);
      // 
      // groupBox1
      // 
      this.groupBox1.Controls.Add(this.radioButtonIteration);
      this.groupBox1.Controls.Add(this.radioButtonCombined);
      this.groupBox1.Controls.Add(this.radioButtonModifiedNewton);
      this.groupBox1.Controls.Add(this.radioButtonNewton);
      this.groupBox1.Controls.Add(this.radioButtonChord);
      this.groupBox1.Controls.Add(this.radioButtonDichotomy);
      this.groupBox1.Location = new System.Drawing.Point(448, 16);
      this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
      this.groupBox1.Size = new System.Drawing.Size(423, 268);
      this.groupBox1.TabIndex = 7;
      this.groupBox1.TabStop = false;
      this.groupBox1.Text = "Метод решения";
      // 
      // radioButtonIteration
      // 
      this.radioButtonIteration.AutoSize = true;
      this.radioButtonIteration.Location = new System.Drawing.Point(9, 227);
      this.radioButtonIteration.Margin = new System.Windows.Forms.Padding(4);
      this.radioButtonIteration.Name = "radioButtonIteration";
      this.radioButtonIteration.Size = new System.Drawing.Size(203, 30);
      this.radioButtonIteration.TabIndex = 5;
      this.radioButtonIteration.Text = "Метод итераций";
      this.radioButtonIteration.UseVisualStyleBackColor = true;
      this.radioButtonIteration.Click += new System.EventHandler(this.ButtonStart_Click);
      // 
      // radioButtonCombined
      // 
      this.radioButtonCombined.AutoSize = true;
      this.radioButtonCombined.Location = new System.Drawing.Point(9, 188);
      this.radioButtonCombined.Margin = new System.Windows.Forms.Padding(4);
      this.radioButtonCombined.Name = "radioButtonCombined";
      this.radioButtonCombined.Size = new System.Drawing.Size(298, 30);
      this.radioButtonCombined.TabIndex = 4;
      this.radioButtonCombined.Text = "Комбинированный метод";
      this.radioButtonCombined.UseVisualStyleBackColor = true;
      this.radioButtonCombined.Click += new System.EventHandler(this.ButtonStart_Click);
      // 
      // radioButtonModifiedNewton
      // 
      this.radioButtonModifiedNewton.AutoSize = true;
      this.radioButtonModifiedNewton.Location = new System.Drawing.Point(9, 150);
      this.radioButtonModifiedNewton.Margin = new System.Windows.Forms.Padding(4);
      this.radioButtonModifiedNewton.Name = "radioButtonModifiedNewton";
      this.radioButtonModifiedNewton.Size = new System.Drawing.Size(413, 30);
      this.radioButtonModifiedNewton.TabIndex = 3;
      this.radioButtonModifiedNewton.Text = "Модифицированный метод Ньютона";
      this.radioButtonModifiedNewton.UseVisualStyleBackColor = true;
      this.radioButtonModifiedNewton.Click += new System.EventHandler(this.ButtonStart_Click);
      // 
      // radioButtonNewton
      // 
      this.radioButtonNewton.AutoSize = true;
      this.radioButtonNewton.Location = new System.Drawing.Point(9, 110);
      this.radioButtonNewton.Margin = new System.Windows.Forms.Padding(4);
      this.radioButtonNewton.Name = "radioButtonNewton";
      this.radioButtonNewton.Size = new System.Drawing.Size(198, 30);
      this.radioButtonNewton.TabIndex = 2;
      this.radioButtonNewton.Text = "Метод Ньютона";
      this.radioButtonNewton.UseVisualStyleBackColor = true;
      this.radioButtonNewton.Click += new System.EventHandler(this.ButtonStart_Click);
      // 
      // radioButtonChord
      // 
      this.radioButtonChord.AutoSize = true;
      this.radioButtonChord.Location = new System.Drawing.Point(9, 72);
      this.radioButtonChord.Margin = new System.Windows.Forms.Padding(4);
      this.radioButtonChord.Name = "radioButtonChord";
      this.radioButtonChord.Size = new System.Drawing.Size(156, 30);
      this.radioButtonChord.TabIndex = 1;
      this.radioButtonChord.Text = "Метод хорд";
      this.radioButtonChord.UseVisualStyleBackColor = true;
      this.radioButtonChord.Click += new System.EventHandler(this.ButtonStart_Click);
      // 
      // radioButtonDichotomy
      // 
      this.radioButtonDichotomy.AutoSize = true;
      this.radioButtonDichotomy.Checked = true;
      this.radioButtonDichotomy.Location = new System.Drawing.Point(9, 32);
      this.radioButtonDichotomy.Margin = new System.Windows.Forms.Padding(4);
      this.radioButtonDichotomy.Name = "radioButtonDichotomy";
      this.radioButtonDichotomy.Size = new System.Drawing.Size(218, 30);
      this.radioButtonDichotomy.TabIndex = 0;
      this.radioButtonDichotomy.TabStop = true;
      this.radioButtonDichotomy.Text = "Метод дихотомии";
      this.radioButtonDichotomy.UseVisualStyleBackColor = true;
      this.radioButtonDichotomy.Click += new System.EventHandler(this.ButtonStart_Click);
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(74, 16);
      this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(153, 26);
      this.label3.TabIndex = 9;
      this.label3.Text = "Погрешность:";
      // 
      // textBoxE
      // 
      this.textBoxE.Location = new System.Drawing.Point(257, 13);
      this.textBoxE.Margin = new System.Windows.Forms.Padding(4);
      this.textBoxE.Name = "textBoxE";
      this.textBoxE.Size = new System.Drawing.Size(115, 32);
      this.textBoxE.TabIndex = 8;
      this.textBoxE.Text = "0,0001";
      // 
      // MainForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 26F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(884, 303);
      this.Controls.Add(this.label3);
      this.Controls.Add(this.textBoxE);
      this.Controls.Add(this.groupBox1);
      this.Controls.Add(this.buttonStart);
      this.Controls.Add(this.labelResult);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.textBoxB);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.textBoxA);
      this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.Margin = new System.Windows.Forms.Padding(4);
      this.Name = "MainForm";
      this.Text = "Form1";
      this.groupBox1.ResumeLayout(false);
      this.groupBox1.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxA;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxB;
        private System.Windows.Forms.Label labelResult;
        private System.Windows.Forms.Button buttonStart;
    private System.Windows.Forms.GroupBox groupBox1;
    private System.Windows.Forms.RadioButton radioButtonIteration;
    private System.Windows.Forms.RadioButton radioButtonCombined;
    private System.Windows.Forms.RadioButton radioButtonModifiedNewton;
    private System.Windows.Forms.RadioButton radioButtonNewton;
    private System.Windows.Forms.RadioButton radioButtonChord;
    private System.Windows.Forms.RadioButton radioButtonDichotomy;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.TextBox textBoxE;
  }
}

