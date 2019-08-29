namespace TrueFalse
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.открытьФайлИгрыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.закончитьИгруToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.выходToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.справкаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.оПрограммеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.lblCheck = new System.Windows.Forms.Label();
            this.btFalse = new System.Windows.Forms.Button();
            this.btTrue = new System.Windows.Forms.Button();
            this.btStartGame = new System.Windows.Forms.Button();
            this.lblQues = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btOpenChange = new System.Windows.Forms.Button();
            this.btChange = new System.Windows.Forms.Button();
            this.tbQues = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.nUDNumber = new System.Windows.Forms.NumericUpDown();
            this.rbTrue = new System.Windows.Forms.RadioButton();
            this.btRemove = new System.Windows.Forms.Button();
            this.btEnter = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tSSLTime = new System.Windows.Forms.ToolStripStatusLabel();
            this.tSSLFileName = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nUDNumber)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem,
            this.справкаToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.открытьФайлИгрыToolStripMenuItem,
            this.закончитьИгруToolStripMenuItem,
            this.toolStripMenuItem1,
            this.выходToolStripMenuItem});
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(57, 24);
            this.файлToolStripMenuItem.Text = "Файл";
            // 
            // открытьФайлИгрыToolStripMenuItem
            // 
            this.открытьФайлИгрыToolStripMenuItem.Name = "открытьФайлИгрыToolStripMenuItem";
            this.открытьФайлИгрыToolStripMenuItem.Size = new System.Drawing.Size(220, 26);
            this.открытьФайлИгрыToolStripMenuItem.Text = "Открыть файл игры";
            this.открытьФайлИгрыToolStripMenuItem.Click += new System.EventHandler(this.OpenFileGameToolStripMenuItem_Click);
            // 
            // закончитьИгруToolStripMenuItem
            // 
            this.закончитьИгруToolStripMenuItem.Name = "закончитьИгруToolStripMenuItem";
            this.закончитьИгруToolStripMenuItem.Size = new System.Drawing.Size(220, 26);
            this.закончитьИгруToolStripMenuItem.Text = "Закончить игру";
            this.закончитьИгруToolStripMenuItem.Click += new System.EventHandler(this.GameOverToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(217, 6);
            // 
            // выходToolStripMenuItem
            // 
            this.выходToolStripMenuItem.Name = "выходToolStripMenuItem";
            this.выходToolStripMenuItem.Size = new System.Drawing.Size(220, 26);
            this.выходToolStripMenuItem.Text = "Выход";
            this.выходToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItem_Click);
            // 
            // справкаToolStripMenuItem
            // 
            this.справкаToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.оПрограммеToolStripMenuItem});
            this.справкаToolStripMenuItem.Name = "справкаToolStripMenuItem";
            this.справкаToolStripMenuItem.Size = new System.Drawing.Size(79, 24);
            this.справкаToolStripMenuItem.Text = "Справка";
            // 
            // оПрограммеToolStripMenuItem
            // 
            this.оПрограммеToolStripMenuItem.Name = "оПрограммеToolStripMenuItem";
            this.оПрограммеToolStripMenuItem.Size = new System.Drawing.Size(179, 26);
            this.оПрограммеToolStripMenuItem.Text = "О программе";
            this.оПрограммеToolStripMenuItem.Click += new System.EventHandler(this.AboutProgramToolStripMenuItem_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(0, 32);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(800, 340);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.lblCheck);
            this.tabPage1.Controls.Add(this.btFalse);
            this.tabPage1.Controls.Add(this.btTrue);
            this.tabPage1.Controls.Add(this.btStartGame);
            this.tabPage1.Controls.Add(this.lblQues);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(792, 311);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Игра";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // lblCheck
            // 
            this.lblCheck.AutoSize = true;
            this.lblCheck.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblCheck.Location = new System.Drawing.Point(8, 241);
            this.lblCheck.Name = "lblCheck";
            this.lblCheck.Size = new System.Drawing.Size(0, 38);
            this.lblCheck.TabIndex = 4;
            this.lblCheck.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btFalse
            // 
            this.btFalse.Location = new System.Drawing.Point(431, 165);
            this.btFalse.Name = "btFalse";
            this.btFalse.Size = new System.Drawing.Size(203, 43);
            this.btFalse.TabIndex = 3;
            this.btFalse.Text = "Ложь";
            this.btFalse.UseVisualStyleBackColor = true;
            this.btFalse.Click += new System.EventHandler(this.BtFalse_Click);
            // 
            // btTrue
            // 
            this.btTrue.Location = new System.Drawing.Point(104, 165);
            this.btTrue.Name = "btTrue";
            this.btTrue.Size = new System.Drawing.Size(203, 43);
            this.btTrue.TabIndex = 2;
            this.btTrue.Text = "Верно";
            this.btTrue.UseVisualStyleBackColor = true;
            this.btTrue.Click += new System.EventHandler(this.BtTrue_Click);
            // 
            // btStartGame
            // 
            this.btStartGame.Location = new System.Drawing.Point(269, 116);
            this.btStartGame.Name = "btStartGame";
            this.btStartGame.Size = new System.Drawing.Size(203, 43);
            this.btStartGame.TabIndex = 1;
            this.btStartGame.Text = "Начать игру";
            this.btStartGame.UseVisualStyleBackColor = true;
            this.btStartGame.Click += new System.EventHandler(this.BtStartGame_Click);
            // 
            // lblQues
            // 
            this.lblQues.AutoSize = true;
            this.lblQues.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblQues.Location = new System.Drawing.Point(8, 38);
            this.lblQues.MaximumSize = new System.Drawing.Size(780, 0);
            this.lblQues.Name = "lblQues";
            this.lblQues.Size = new System.Drawing.Size(0, 25);
            this.lblQues.TabIndex = 0;
            this.lblQues.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.btOpenChange);
            this.tabPage2.Controls.Add(this.btChange);
            this.tabPage2.Controls.Add(this.tbQues);
            this.tabPage2.Controls.Add(this.button1);
            this.tabPage2.Controls.Add(this.nUDNumber);
            this.tabPage2.Controls.Add(this.rbTrue);
            this.tabPage2.Controls.Add(this.btRemove);
            this.tabPage2.Controls.Add(this.btEnter);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(792, 311);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Редакция вопросов";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // btOpenChange
            // 
            this.btOpenChange.Location = new System.Drawing.Point(198, 250);
            this.btOpenChange.Name = "btOpenChange";
            this.btOpenChange.Size = new System.Drawing.Size(183, 53);
            this.btOpenChange.TabIndex = 8;
            this.btOpenChange.Text = "Открыть список вопросов";
            this.btOpenChange.UseVisualStyleBackColor = true;
            this.btOpenChange.Click += new System.EventHandler(this.BtOpenChange_Click);
            // 
            // btChange
            // 
            this.btChange.Location = new System.Drawing.Point(198, 222);
            this.btChange.Name = "btChange";
            this.btChange.Size = new System.Drawing.Size(89, 23);
            this.btChange.TabIndex = 7;
            this.btChange.Text = "Изменить";
            this.btChange.UseVisualStyleBackColor = true;
            this.btChange.Click += new System.EventHandler(this.BtChange_Click);
            // 
            // tbQues
            // 
            this.tbQues.Location = new System.Drawing.Point(9, 7);
            this.tbQues.Multiline = true;
            this.tbQues.Name = "tbQues";
            this.tbQues.Size = new System.Drawing.Size(775, 209);
            this.tbQues.TabIndex = 6;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(9, 250);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(183, 53);
            this.button1.TabIndex = 5;
            this.button1.Text = "Закончить формирование";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // nUDNumber
            // 
            this.nUDNumber.Location = new System.Drawing.Point(334, 220);
            this.nUDNumber.Name = "nUDNumber";
            this.nUDNumber.Size = new System.Drawing.Size(47, 22);
            this.nUDNumber.TabIndex = 4;
            this.nUDNumber.ValueChanged += new System.EventHandler(this.NUDNumber_ValueChanged);
            // 
            // rbTrue
            // 
            this.rbTrue.AutoCheck = false;
            this.rbTrue.AutoSize = true;
            this.rbTrue.Location = new System.Drawing.Point(706, 222);
            this.rbTrue.Name = "rbTrue";
            this.rbTrue.Size = new System.Drawing.Size(78, 21);
            this.rbTrue.TabIndex = 3;
            this.rbTrue.TabStop = true;
            this.rbTrue.Text = "Правда";
            this.rbTrue.UseVisualStyleBackColor = true;
            this.rbTrue.CheckedChanged += new System.EventHandler(this.RbTrue_Click);
            this.rbTrue.Click += new System.EventHandler(this.RbTrue_Click);
            // 
            // btRemove
            // 
            this.btRemove.Location = new System.Drawing.Point(103, 222);
            this.btRemove.Name = "btRemove";
            this.btRemove.Size = new System.Drawing.Size(89, 23);
            this.btRemove.TabIndex = 2;
            this.btRemove.Text = "Удалить";
            this.btRemove.UseVisualStyleBackColor = true;
            this.btRemove.Click += new System.EventHandler(this.BtRemove_Click);
            // 
            // btEnter
            // 
            this.btEnter.Location = new System.Drawing.Point(9, 222);
            this.btEnter.Name = "btEnter";
            this.btEnter.Size = new System.Drawing.Size(88, 23);
            this.btEnter.TabIndex = 1;
            this.btEnter.Text = "Добавить";
            this.btEnter.UseVisualStyleBackColor = true;
            this.btEnter.Click += new System.EventHandler(this.BtEnter_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tSSLTime,
            this.tSSLFileName});
            this.statusStrip1.Location = new System.Drawing.Point(0, 377);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(800, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tSSLTime
            // 
            this.tSSLTime.Name = "tSSLTime";
            this.tSSLTime.Size = new System.Drawing.Size(0, 17);
            // 
            // tSSLFileName
            // 
            this.tSSLFileName.Name = "tSSLFileName";
            this.tSSLFileName.Size = new System.Drawing.Size(0, 17);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(800, 399);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Игра <Верю/Не верю>";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nUDNumber)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.RadioButton rbTrue;
        private System.Windows.Forms.Button btRemove;
        private System.Windows.Forms.Button btEnter;
        private System.Windows.Forms.NumericUpDown nUDNumber;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox tbQues;
        private System.Windows.Forms.Button btStartGame;
        private System.Windows.Forms.Label lblQues;
        private System.Windows.Forms.Button btFalse;
        private System.Windows.Forms.Button btTrue;
        private System.Windows.Forms.Label lblCheck;
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem открытьФайлИгрыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem закончитьИгруToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem выходToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem справкаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem оПрограммеToolStripMenuItem;
        private System.Windows.Forms.Button btOpenChange;
        private System.Windows.Forms.Button btChange;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tSSLTime;
        private System.Windows.Forms.ToolStripStatusLabel tSSLFileName;
    }
}

