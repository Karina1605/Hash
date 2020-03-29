using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using System.IO;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        //Хеш-таблица
        MyHashTable table;
        //визуализация для ввода результатов сессии
        SemestrVisualization visualization;
        //Буфер при считывании с формы
        CStudent current;
        //работа с файлми
        WorkWithFile work;
        public Form1()
        {
            InitializeComponent();
           
            current = null;
            work = new WorkWithFile();
        }
        //Вывод в MessageBox текста задания
        private void TaskTextToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("По номеру студ. билета вывести информацию о студенте");
        }

        //Кнопка ввода, в зависимости от текста на ней выполняет разные действия
        private void Addbutton_Click(object sender, EventArgs e)
        {
            switch (Addbutton.Text)
            {
                //Считывание студента и его сесси, добавление в таблицу
                case "Добавить":
                    current.FIO = new CFIO(new string[] { LastNametextBox.Text, FirstNametextBox.Text, PathronymictextBox.Text });
                    current.StudTicket = StudTickettextBox.Text;
                    current.Semestr.ReadFromScreen(visualization);
                    table.Add(current, current.StudTicket);
                    break;
                //Считывание ФИО и билета, поиск и удаление
                case "Удалить":
                    current = new CStudent(3, 1, 3);
                    current.FIO = new CFIO(new string[] { LastNametextBox.Text, FirstNametextBox.Text, PathronymictextBox.Text });
                    current.StudTicket = StudTickettextBox.Text;
                    table.EndEnter();
                    current.Semestr = null;
                    table.Delete(current);
                    break;
                //Считывание ФИО и билета, поиск
                case "Найти":
                    current = new CStudent(3, 1, 3);
                    current.FIO = new CFIO(new string[] { LastNametextBox.Text, FirstNametextBox.Text, PathronymictextBox.Text });
                    current.StudTicket = StudTickettextBox.Text;
                    table.EndEnter();
                    current.Semestr = null;
                    if (table.Search(current)!=null)
                        MessageBox.Show("Есть такой студент");
                    else
                        MessageBox.Show("Нет такого студента");
                    break;
            }
            //Очистка полей ввода
            Clear();
        }
        //Очистка полей ввода
        void Clear()
        {
            LastNametextBox.Clear();
            FirstNametextBox.Clear();
            PathronymictextBox.Clear();
            StudTickettextBox.Clear();
            TestscomboBox.Text = DifTestscomboBox2.Text = ExamscomboBox3.Text = "";
            if (visualization!=null)
                visualization.Clear();
            setgroupBox1.Enabled = false;
            FillingOneStudent.Enabled = false;
        }
        //Установка кол-ва экзаменов и зачетов
        private void Setbutton_Click(object sender, EventArgs e)
        {
            if (TestscomboBox.Text == "" || DifTestscomboBox2.Text == "" || ExamscomboBox3.Text == "")
                MessageBox.Show("Выберите параметры");
            else
            {
                //Если все корректно - Зполняем панели с экзаменами и зачетами
                if (visualization != null)
                    visualization.Dispose();
                visualization = new SemestrVisualization(Testspanel, DifTestspanel, Examspanel,
                    Int32.Parse(TestscomboBox.Text), Int32.Parse(DifTestscomboBox2.Text), Int32.Parse(ExamscomboBox3.Text));
                current = new CStudent(Int32.Parse(TestscomboBox.Text), Int32.Parse(DifTestscomboBox2.Text), Int32.Parse(ExamscomboBox3.Text));
                FillingOneStudent.Enabled = true;
                
            }
        }
        //Создание нового файла
        private void откытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string s = Interaction.InputBox("Введите имя нового файла", "Новый файл");
            if  (s!="")
            {
                CurrentToolStripMenuItem.Enabled = true;
                this.TaskToolStripMenuItem.Enabled = true;
                GetHashToolStripMenuItem.Enabled = true;
                table = new MyHashTable(CStudent.HashForStudent);
            }
                
        }

        //Добавить эл-т в таблицу, сначала активируется только окно заполнения кол-ва дисциплин
        private void добавитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            setgroupBox1.Enabled = true;
            Addbutton.Text = "Добавить";
            
        }

        //Кнопка отмены - сброс всех введенных эол-тов
        private void Backbutton_Click(object sender, EventArgs e)
        {
            current = null;
            LastNametextBox.Text = FirstNametextBox.Text = PathronymictextBox.Text = StudTickettextBox.Text = "";
            visualization.Clear();
            FillingOneStudent.Enabled = false;
            setgroupBox1.Enabled = false;
        }

        
        //Активация ввода ФИО и номера студенческого
        private void удалитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //setgroupBox1.Enabled = true;
            Addbutton.Text = "Удалить";
            FillingOneStudent.Enabled = true;
            Testspanel.Enabled = false;
            DifTestspanel.Enabled = false;
            Examspanel.Enabled = false;
        }

        //Аналогично удалению
        private void поискToolStripMenuItem_Click(object sender, EventArgs e)
        {
            setgroupBox1.Enabled = false;
            Addbutton.Text = "Найти";
            FillingOneStudent.Enabled = true;
          
            Testspanel.Enabled = false;
            DifTestspanel.Enabled = false;
            Examspanel.Enabled = false;
        }
        
        //Выполнение основной задачи - вводится номер студенческого, если студент найден, вся информация о нем выводится в textbox
        private void TaskToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!table.IsCompleted)
                table.EndEnter();
            setgroupBox1.Enabled = false;
            string r = Interaction.InputBox("Введите номер студенческого билета");
            if (r!="")
            {
                if (!CStudent.IsCorrectTicket(r))
                    MessageBox.Show("Некорректный формат билета");
                else
                {
                    CStudent res = table.MainTask(r);
                    if (res == null)
                        MessageBox.Show("Нет студента с таким номером студ. билета");
                    else
                    {
                        string st = res.FIO.ToString() + " " + res.StudTicket + Environment.NewLine +
                            "Зачеты" + Environment.NewLine + res.Semestr.tests.ToString() + Environment.NewLine +
                            "Дифференуированные зачеты" + Environment.NewLine + res.Semestr.testsWithMark.ToString() +
                            Environment.NewLine + "Экзамены" + Environment.NewLine + res.Semestr.exams.ToString();
                        MessageBox.Show(st);
                    }
                }
            }
        }

        //Отображение таблицы
        private void GetHashToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!table.IsCompleted)
                table.EndEnter();
            table.LoadToScreen().Show();
        }

        //Открытие существующего файла
        private void OpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WorkWithFile.ChoseFileDialog();
            if (WorkWithFile.FileName!="")
            {
                if (!work.GetInfoFromFile(WorkWithFile.Ext, ref table))
                    MessageBox.Show("Ошибка чтения файла");
                else
                {
                    CurrentToolStripMenuItem.Enabled = true;
                    this.TaskToolStripMenuItem.Enabled = true;
                    GetHashToolStripMenuItem.Enabled = true;
                }
            }
        }

        //Сохранить файл
        private void SaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string ext = Path.GetExtension(WorkWithFile.FileName);
            if (ext == String.Empty)
            {
                if (WorkWithFile.SaveFileDialog())
                {
                    ext = Path.GetExtension(WorkWithFile.FileName);
                    work.PutInfoToFile(table, ext);
                }
            }
            else
                work.PutInfoToFile(table, ext);
        }

        //Сохранить файл как...
        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (WorkWithFile.SaveFileDialog())
            {
                string ext = Path.GetExtension(WorkWithFile.FileName);
                work.PutInfoToFile(table, ext);
            }
        }
    }
}
