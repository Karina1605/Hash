namespace WindowsFormsApp2
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.FileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.NewFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.OpenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CurrentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.добавитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.удалитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.поискToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TaskToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TaskTextToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.GetHashToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.FillingOneStudent = new System.Windows.Forms.GroupBox();
            this.Backbutton = new System.Windows.Forms.Button();
            this.StudTickettextBox = new System.Windows.Forms.TextBox();
            this.PathronymictextBox = new System.Windows.Forms.TextBox();
            this.FirstNametextBox = new System.Windows.Forms.TextBox();
            this.LastNametextBox = new System.Windows.Forms.TextBox();
            this.Addbutton = new System.Windows.Forms.Button();
            this.LastSessionlabel = new System.Windows.Forms.Label();
            this.StudTicketlabel = new System.Windows.Forms.Label();
            this.Pathronymiclabel = new System.Windows.Forms.Label();
            this.FirstNamelabel = new System.Windows.Forms.Label();
            this.LastNamelabel = new System.Windows.Forms.Label();
            this.CountTestslabel = new System.Windows.Forms.Label();
            this.DifTestslabel = new System.Windows.Forms.Label();
            this.examslabel3 = new System.Windows.Forms.Label();
            this.TestscomboBox = new System.Windows.Forms.ComboBox();
            this.DifTestscomboBox2 = new System.Windows.Forms.ComboBox();
            this.ExamscomboBox3 = new System.Windows.Forms.ComboBox();
            this.Setbutton = new System.Windows.Forms.Button();
            this.setgroupBox1 = new System.Windows.Forms.GroupBox();
            this.Testspanel = new System.Windows.Forms.Panel();
            this.DifTestspanel = new System.Windows.Forms.Panel();
            this.Examspanel = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.FillingOneStudent.SuspendLayout();
            this.setgroupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FileToolStripMenuItem,
            this.CurrentToolStripMenuItem,
            this.TaskToolStripMenuItem,
            this.TaskTextToolStripMenuItem,
            this.GetHashToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(913, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // FileToolStripMenuItem
            // 
            this.FileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.NewFileToolStripMenuItem,
            this.OpenToolStripMenuItem,
            this.SaveToolStripMenuItem,
            this.SaveAsToolStripMenuItem});
            this.FileToolStripMenuItem.Name = "FileToolStripMenuItem";
            this.FileToolStripMenuItem.Size = new System.Drawing.Size(66, 24);
            this.FileToolStripMenuItem.Text = "Файл...";
            // 
            // NewFileToolStripMenuItem
            // 
            this.NewFileToolStripMenuItem.Name = "NewFileToolStripMenuItem";
            this.NewFileToolStripMenuItem.Size = new System.Drawing.Size(201, 26);
            this.NewFileToolStripMenuItem.Text = "Новый документ";
            this.NewFileToolStripMenuItem.Click += new System.EventHandler(this.откытьToolStripMenuItem_Click);
            // 
            // OpenToolStripMenuItem
            // 
            this.OpenToolStripMenuItem.Name = "OpenToolStripMenuItem";
            this.OpenToolStripMenuItem.Size = new System.Drawing.Size(201, 26);
            this.OpenToolStripMenuItem.Text = "Открыть";
            this.OpenToolStripMenuItem.Click += new System.EventHandler(this.OpenToolStripMenuItem_Click);
            // 
            // SaveToolStripMenuItem
            // 
            this.SaveToolStripMenuItem.Name = "SaveToolStripMenuItem";
            this.SaveToolStripMenuItem.Size = new System.Drawing.Size(201, 26);
            this.SaveToolStripMenuItem.Text = "Сохранить";
            this.SaveToolStripMenuItem.Click += new System.EventHandler(this.SaveToolStripMenuItem_Click);
            // 
            // SaveAsToolStripMenuItem
            // 
            this.SaveAsToolStripMenuItem.Name = "SaveAsToolStripMenuItem";
            this.SaveAsToolStripMenuItem.Size = new System.Drawing.Size(201, 26);
            this.SaveAsToolStripMenuItem.Text = "Сохранить как";
            this.SaveAsToolStripMenuItem.Click += new System.EventHandler(this.SaveAsToolStripMenuItem_Click);
            // 
            // CurrentToolStripMenuItem
            // 
            this.CurrentToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.добавитьToolStripMenuItem,
            this.удалитьToolStripMenuItem,
            this.поискToolStripMenuItem});
            this.CurrentToolStripMenuItem.Enabled = false;
            this.CurrentToolStripMenuItem.Name = "CurrentToolStripMenuItem";
            this.CurrentToolStripMenuItem.Size = new System.Drawing.Size(159, 24);
            this.CurrentToolStripMenuItem.Text = "Текущий документ...";
            // 
            // добавитьToolStripMenuItem
            // 
            this.добавитьToolStripMenuItem.Name = "добавитьToolStripMenuItem";
            this.добавитьToolStripMenuItem.Size = new System.Drawing.Size(151, 26);
            this.добавитьToolStripMenuItem.Text = "Добавить";
            this.добавитьToolStripMenuItem.Click += new System.EventHandler(this.добавитьToolStripMenuItem_Click);
            // 
            // удалитьToolStripMenuItem
            // 
            this.удалитьToolStripMenuItem.Name = "удалитьToolStripMenuItem";
            this.удалитьToolStripMenuItem.Size = new System.Drawing.Size(151, 26);
            this.удалитьToolStripMenuItem.Text = "Удалить";
            this.удалитьToolStripMenuItem.Click += new System.EventHandler(this.удалитьToolStripMenuItem_Click);
            // 
            // поискToolStripMenuItem
            // 
            this.поискToolStripMenuItem.Name = "поискToolStripMenuItem";
            this.поискToolStripMenuItem.Size = new System.Drawing.Size(151, 26);
            this.поискToolStripMenuItem.Text = "Поиск";
            this.поискToolStripMenuItem.Click += new System.EventHandler(this.поискToolStripMenuItem_Click);
            // 
            // TaskToolStripMenuItem
            // 
            this.TaskToolStripMenuItem.Enabled = false;
            this.TaskToolStripMenuItem.Name = "TaskToolStripMenuItem";
            this.TaskToolStripMenuItem.Size = new System.Drawing.Size(232, 24);
            this.TaskToolStripMenuItem.Text = "Выполнить основное задание";
            this.TaskToolStripMenuItem.Click += new System.EventHandler(this.TaskToolStripMenuItem_Click);
            // 
            // TaskTextToolStripMenuItem
            // 
            this.TaskTextToolStripMenuItem.Name = "TaskTextToolStripMenuItem";
            this.TaskTextToolStripMenuItem.Size = new System.Drawing.Size(140, 24);
            this.TaskTextToolStripMenuItem.Text = "Условие задания";
            this.TaskTextToolStripMenuItem.Click += new System.EventHandler(this.TaskTextToolStripMenuItem_Click);
            // 
            // GetHashToolStripMenuItem
            // 
            this.GetHashToolStripMenuItem.Enabled = false;
            this.GetHashToolStripMenuItem.Name = "GetHashToolStripMenuItem";
            this.GetHashToolStripMenuItem.Size = new System.Drawing.Size(196, 24);
            this.GetHashToolStripMenuItem.Text = "Отобразить хеш-таблицу";
            this.GetHashToolStripMenuItem.Click += new System.EventHandler(this.GetHashToolStripMenuItem_Click);
            // 
            // FillingOneStudent
            // 
            this.FillingOneStudent.Controls.Add(this.label3);
            this.FillingOneStudent.Controls.Add(this.label2);
            this.FillingOneStudent.Controls.Add(this.label1);
            this.FillingOneStudent.Controls.Add(this.Examspanel);
            this.FillingOneStudent.Controls.Add(this.DifTestspanel);
            this.FillingOneStudent.Controls.Add(this.Testspanel);
            this.FillingOneStudent.Controls.Add(this.Backbutton);
            this.FillingOneStudent.Controls.Add(this.StudTickettextBox);
            this.FillingOneStudent.Controls.Add(this.PathronymictextBox);
            this.FillingOneStudent.Controls.Add(this.FirstNametextBox);
            this.FillingOneStudent.Controls.Add(this.LastNametextBox);
            this.FillingOneStudent.Controls.Add(this.Addbutton);
            this.FillingOneStudent.Controls.Add(this.LastSessionlabel);
            this.FillingOneStudent.Controls.Add(this.StudTicketlabel);
            this.FillingOneStudent.Controls.Add(this.Pathronymiclabel);
            this.FillingOneStudent.Controls.Add(this.FirstNamelabel);
            this.FillingOneStudent.Controls.Add(this.LastNamelabel);
            this.FillingOneStudent.Enabled = false;
            this.FillingOneStudent.Location = new System.Drawing.Point(11, 156);
            this.FillingOneStudent.Name = "FillingOneStudent";
            this.FillingOneStudent.Size = new System.Drawing.Size(890, 568);
            this.FillingOneStudent.TabIndex = 9;
            this.FillingOneStudent.TabStop = false;
            this.FillingOneStudent.Text = "Студент";
            // 
            // Backbutton
            // 
            this.Backbutton.Location = new System.Drawing.Point(736, 210);
            this.Backbutton.Name = "Backbutton";
            this.Backbutton.Size = new System.Drawing.Size(146, 33);
            this.Backbutton.TabIndex = 18;
            this.Backbutton.TabStop = false;
            this.Backbutton.Text = "Отмена";
            this.Backbutton.UseVisualStyleBackColor = true;
            this.Backbutton.Click += new System.EventHandler(this.Backbutton_Click);
            // 
            // StudTickettextBox
            // 
            this.StudTickettextBox.Location = new System.Drawing.Point(532, 60);
            this.StudTickettextBox.Name = "StudTickettextBox";
            this.StudTickettextBox.Size = new System.Drawing.Size(135, 22);
            this.StudTickettextBox.TabIndex = 13;
            // 
            // PathronymictextBox
            // 
            this.PathronymictextBox.Location = new System.Drawing.Point(348, 60);
            this.PathronymictextBox.Name = "PathronymictextBox";
            this.PathronymictextBox.Size = new System.Drawing.Size(135, 22);
            this.PathronymictextBox.TabIndex = 12;
            // 
            // FirstNametextBox
            // 
            this.FirstNametextBox.Location = new System.Drawing.Point(176, 60);
            this.FirstNametextBox.Name = "FirstNametextBox";
            this.FirstNametextBox.Size = new System.Drawing.Size(135, 22);
            this.FirstNametextBox.TabIndex = 11;
            // 
            // LastNametextBox
            // 
            this.LastNametextBox.Location = new System.Drawing.Point(6, 60);
            this.LastNametextBox.Name = "LastNametextBox";
            this.LastNametextBox.Size = new System.Drawing.Size(135, 22);
            this.LastNametextBox.TabIndex = 10;
            // 
            // Addbutton
            // 
            this.Addbutton.Location = new System.Drawing.Point(736, 134);
            this.Addbutton.Name = "Addbutton";
            this.Addbutton.Size = new System.Drawing.Size(146, 33);
            this.Addbutton.TabIndex = 17;
            this.Addbutton.Text = "Добавить";
            this.Addbutton.UseVisualStyleBackColor = true;
            this.Addbutton.Click += new System.EventHandler(this.Addbutton_Click);
            // 
            // LastSessionlabel
            // 
            this.LastSessionlabel.AutoSize = true;
            this.LastSessionlabel.Location = new System.Drawing.Point(6, 113);
            this.LastSessionlabel.Name = "LastSessionlabel";
            this.LastSessionlabel.Size = new System.Drawing.Size(210, 17);
            this.LastSessionlabel.TabIndex = 0;
            this.LastSessionlabel.Text = "Результаты последней сессии";
            // 
            // StudTicketlabel
            // 
            this.StudTicketlabel.AutoSize = true;
            this.StudTicketlabel.Location = new System.Drawing.Point(529, 40);
            this.StudTicketlabel.Name = "StudTicketlabel";
            this.StudTicketlabel.Size = new System.Drawing.Size(110, 17);
            this.StudTicketlabel.TabIndex = 0;
            this.StudTicketlabel.Text = "№ студ. билета";
            // 
            // Pathronymiclabel
            // 
            this.Pathronymiclabel.AutoSize = true;
            this.Pathronymiclabel.Location = new System.Drawing.Point(345, 40);
            this.Pathronymiclabel.Name = "Pathronymiclabel";
            this.Pathronymiclabel.Size = new System.Drawing.Size(71, 17);
            this.Pathronymiclabel.TabIndex = 0;
            this.Pathronymiclabel.Text = "Отчество";
            // 
            // FirstNamelabel
            // 
            this.FirstNamelabel.AutoSize = true;
            this.FirstNamelabel.Location = new System.Drawing.Point(173, 40);
            this.FirstNamelabel.Name = "FirstNamelabel";
            this.FirstNamelabel.Size = new System.Drawing.Size(35, 17);
            this.FirstNamelabel.TabIndex = 0;
            this.FirstNamelabel.Text = "Имя";
            // 
            // LastNamelabel
            // 
            this.LastNamelabel.AutoSize = true;
            this.LastNamelabel.Location = new System.Drawing.Point(7, 40);
            this.LastNamelabel.Name = "LastNamelabel";
            this.LastNamelabel.Size = new System.Drawing.Size(70, 17);
            this.LastNamelabel.TabIndex = 0;
            this.LastNamelabel.Text = "Фамилия";
            // 
            // CountTestslabel
            // 
            this.CountTestslabel.AutoSize = true;
            this.CountTestslabel.Location = new System.Drawing.Point(7, 30);
            this.CountTestslabel.Name = "CountTestslabel";
            this.CountTestslabel.Size = new System.Drawing.Size(58, 17);
            this.CountTestslabel.TabIndex = 2;
            this.CountTestslabel.Text = "Зачеты";
            // 
            // DifTestslabel
            // 
            this.DifTestslabel.AutoSize = true;
            this.DifTestslabel.Location = new System.Drawing.Point(150, 30);
            this.DifTestslabel.Name = "DifTestslabel";
            this.DifTestslabel.Size = new System.Drawing.Size(94, 17);
            this.DifTestslabel.TabIndex = 3;
            this.DifTestslabel.Text = "Диф. зачеты";
            // 
            // examslabel3
            // 
            this.examslabel3.AutoSize = true;
            this.examslabel3.Location = new System.Drawing.Point(287, 30);
            this.examslabel3.Name = "examslabel3";
            this.examslabel3.Size = new System.Drawing.Size(74, 17);
            this.examslabel3.TabIndex = 4;
            this.examslabel3.Text = "Экзамены";
            // 
            // TestscomboBox
            // 
            this.TestscomboBox.FormattingEnabled = true;
            this.TestscomboBox.Items.AddRange(new object[] {
            "3",
            "4",
            "5",
            "6",
            "7"});
            this.TestscomboBox.Location = new System.Drawing.Point(6, 50);
            this.TestscomboBox.Name = "TestscomboBox";
            this.TestscomboBox.Size = new System.Drawing.Size(121, 24);
            this.TestscomboBox.TabIndex = 5;
            // 
            // DifTestscomboBox2
            // 
            this.DifTestscomboBox2.FormattingEnabled = true;
            this.DifTestscomboBox2.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4"});
            this.DifTestscomboBox2.Location = new System.Drawing.Point(153, 50);
            this.DifTestscomboBox2.Name = "DifTestscomboBox2";
            this.DifTestscomboBox2.Size = new System.Drawing.Size(121, 24);
            this.DifTestscomboBox2.TabIndex = 6;
            // 
            // ExamscomboBox3
            // 
            this.ExamscomboBox3.FormattingEnabled = true;
            this.ExamscomboBox3.Items.AddRange(new object[] {
            "3",
            "4",
            "5"});
            this.ExamscomboBox3.Location = new System.Drawing.Point(290, 50);
            this.ExamscomboBox3.Name = "ExamscomboBox3";
            this.ExamscomboBox3.Size = new System.Drawing.Size(121, 24);
            this.ExamscomboBox3.TabIndex = 7;
            // 
            // Setbutton
            // 
            this.Setbutton.Location = new System.Drawing.Point(446, 41);
            this.Setbutton.Name = "Setbutton";
            this.Setbutton.Size = new System.Drawing.Size(146, 33);
            this.Setbutton.TabIndex = 8;
            this.Setbutton.Text = "Установить";
            this.Setbutton.UseVisualStyleBackColor = true;
            this.Setbutton.Click += new System.EventHandler(this.Setbutton_Click);
            // 
            // setgroupBox1
            // 
            this.setgroupBox1.Controls.Add(this.Setbutton);
            this.setgroupBox1.Controls.Add(this.examslabel3);
            this.setgroupBox1.Controls.Add(this.ExamscomboBox3);
            this.setgroupBox1.Controls.Add(this.DifTestslabel);
            this.setgroupBox1.Controls.Add(this.DifTestscomboBox2);
            this.setgroupBox1.Controls.Add(this.CountTestslabel);
            this.setgroupBox1.Controls.Add(this.TestscomboBox);
            this.setgroupBox1.Enabled = false;
            this.setgroupBox1.Location = new System.Drawing.Point(5, 40);
            this.setgroupBox1.Name = "setgroupBox1";
            this.setgroupBox1.Size = new System.Drawing.Size(890, 94);
            this.setgroupBox1.TabIndex = 1;
            this.setgroupBox1.TabStop = false;
            this.setgroupBox1.Text = "Установить кол-во";
            // 
            // Testspanel
            // 
            this.Testspanel.AutoScroll = true;
            this.Testspanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Testspanel.Location = new System.Drawing.Point(9, 164);
            this.Testspanel.Name = "Testspanel";
            this.Testspanel.Size = new System.Drawing.Size(690, 100);
            this.Testspanel.TabIndex = 14;
            // 
            // DifTestspanel
            // 
            this.DifTestspanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DifTestspanel.Location = new System.Drawing.Point(10, 309);
            this.DifTestspanel.Name = "DifTestspanel";
            this.DifTestspanel.Size = new System.Drawing.Size(690, 100);
            this.DifTestspanel.TabIndex = 15;
            // 
            // Examspanel
            // 
            this.Examspanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Examspanel.Location = new System.Drawing.Point(10, 461);
            this.Examspanel.Name = "Examspanel";
            this.Examspanel.Size = new System.Drawing.Size(690, 100);
            this.Examspanel.TabIndex = 16;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 144);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 17);
            this.label1.TabIndex = 22;
            this.label1.Text = "Зачеты";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 286);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(214, 17);
            this.label2.TabIndex = 23;
            this.label2.Text = "Дифференцированные зачеты";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 441);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 17);
            this.label3.TabIndex = 0;
            this.label3.Text = "Экзамены";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(913, 729);
            this.Controls.Add(this.setgroupBox1);
            this.Controls.Add(this.FillingOneStudent);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.FillingOneStudent.ResumeLayout(false);
            this.FillingOneStudent.PerformLayout();
            this.setgroupBox1.ResumeLayout(false);
            this.setgroupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem FileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem NewFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem OpenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SaveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SaveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem CurrentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem добавитьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem удалитьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem поискToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem TaskToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem TaskTextToolStripMenuItem;
        private System.Windows.Forms.GroupBox FillingOneStudent;
        private System.Windows.Forms.TextBox StudTickettextBox;
        private System.Windows.Forms.TextBox PathronymictextBox;
        private System.Windows.Forms.TextBox FirstNametextBox;
        private System.Windows.Forms.TextBox LastNametextBox;
        private System.Windows.Forms.Button Addbutton;
        private System.Windows.Forms.Label LastSessionlabel;
        private System.Windows.Forms.Label StudTicketlabel;
        private System.Windows.Forms.Label Pathronymiclabel;
        private System.Windows.Forms.Label FirstNamelabel;
        private System.Windows.Forms.Label LastNamelabel;
        private System.Windows.Forms.ToolStripMenuItem GetHashToolStripMenuItem;
        private System.Windows.Forms.Label CountTestslabel;
        private System.Windows.Forms.Label DifTestslabel;
        private System.Windows.Forms.Label examslabel3;
        private System.Windows.Forms.ComboBox TestscomboBox;
        private System.Windows.Forms.ComboBox DifTestscomboBox2;
        private System.Windows.Forms.ComboBox ExamscomboBox3;
        private System.Windows.Forms.Button Setbutton;
        private System.Windows.Forms.GroupBox setgroupBox1;
        private System.Windows.Forms.Button Backbutton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel Examspanel;
        private System.Windows.Forms.Panel DifTestspanel;
        private System.Windows.Forms.Panel Testspanel;
    }
}

