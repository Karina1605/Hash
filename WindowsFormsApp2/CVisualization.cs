using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Drawing;

namespace WindowsFormsApp2
{
    //Одна запись в форме с таблицей
    public class COneRecord
    {
        //Индекс массива, ФИО, номер билета, следующий элемент
        TextBox[] Info;
        //Результаты последней сессии
        TextBox[] Session;
            
       //На вход подается один эл-т из хеш-таблицы
        public COneRecord( OneField one, int pos)
        {
            Info = new TextBox[8];
            for (int i = 0; i < Info.Length; ++i)
            {
                Info[i] = new TextBox();
                Info[i].ReadOnly = true;
            }
                
            Info[0].Text = pos.ToString();
            Info[1].Text = one.filling.ToString();
            if (one.filling==Filling.Full)
            {
                Info[2].Text = one.info.FIO.ToString();
                Info[3].Text = one.info.StudTicket;
            }
            
            if (one.next != null)
                Info[4].Text = one.next.ToString();
            Info[0].Width = Info[1].Width = 30;
            Info[2].Width = 150;
            Info[3].Width = 100;
            Info[4].Width = 30;
            Session = new TextBox[3];
            for (int i=0; i<Session.Length; ++i)
            {
                Session[i] = new TextBox();
                Session[i].Width = 300;
                Session[i].ReadOnly = true;
            }
            if (one.filling==Filling.Full && one.info.Semestr!=null)
            {
                Session[0].Text = one.info.Semestr.TestsToString();
                Session[1].Text = one.info.Semestr.DifTestsToString();
                Session[2].Text = one.info.Semestr.ExamsToString();
            }
        }

       
        //Добаление элемента на панель
        public void AddToPanel (Panel panel, int x, int y)
        {
            System.Drawing.Point loc = new System.Drawing.Point(x, y);
            for (int i = 0; i<2; i++)
            {         
                Info[i].Location = loc;
                panel.Controls.Add(Info[i]);
                loc.X += 30;
            }
            Info[2].Location = loc;
            panel.Controls.Add(Info[2]);
            loc.X += 150;
            Info[3].Location = loc;
            panel.Controls.Add(Info[3]);
            loc.X += 100;
            Info[4].Location = loc;
            panel.Controls.Add(Info[4]);
            loc.X += 30;
            for (int i=0; i<Session.Length; ++i)
            {
                Session[i].Location = loc;
                panel.Controls.Add(Session[i]);
                loc.X += 300;
            }
        }
        //Инициализация заголовка
        public static void InitCapt(Panel panel, System.Drawing.Point loc)
        {
            Label[] labels = new Label[8];
            for (int i = 0; i < labels.Length; ++i)
                labels[i] = new Label();
            labels[0].Width = 30; labels[0].Text = "№";
            labels[0].Location = loc; loc.X += 30;

            labels[1].Width = 30; labels[1].Text = "Cond";
            labels[1].Location = loc; loc.X += 30;

            labels[2].Width = 150; labels[2].Text = "ФИО";
            labels[2].Location = loc; loc.X += 150;

            labels[3].Width = 100; labels[3].Text = "Студ. билет";
            labels[3].Location = loc; loc.X += 100;

            labels[4].Width = 30; labels[4].Text = "След.";
            labels[4].Location = loc; loc.X += 30;

            labels[5].Width = labels[6].Width = labels[7].Width = 300;
            labels[5].Text = "Зачеты";
            labels[6].Text = "Дифференцированные зачеты";
            labels[7].Text = "Экзамены";
            labels[5].Location = loc; loc.X += 300;
            labels[6].Location = loc; loc.X += 300;
            labels[7].Location = loc;
            for (int i = 0; i < labels.Length; ++i)
                panel.Controls.Add(labels[i]);
        }

    }
   
    //Перечисление типов контроля
    public enum Disciplines { Test, Exam, DiffTest }
     
    //Визуализация ввода зачетов и экзаменов одного студента
    public class SemestrVisualization
    {
        //Визуализация одной дисциплины
        public class OneDiscipline
        {
            //Название дисциплины
            public TextBox Discipline;
            //Оценка
            public ComboBox Mark;
            //Конструктор, на вход  - вид контроля, по ему определяется содержимое combobox
            public OneDiscipline(Disciplines discipline)
            {
                Discipline = new TextBox();
                Mark = new ComboBox();
                Discipline.Width = 100;
                Mark.Width = 100;
                //Заполнение вариантов оценивания
                switch (discipline)
                {
                    case Disciplines.Test:
                        Mark.Items.Add("Зачтено");
                        Mark.Items.Add("Незачтено");
                        break;
                    case Disciplines.DiffTest:
                    case Disciplines.Exam:
                        for (byte b = 2; b <= 5; b++)
                            Mark.Items.Add(b.ToString());
                        break;
                }

            }
           //Получить строковое представление дисциплины
            public string getSubject() { return Discipline.Text; }
            //Получить строковое представление оценки
            public string getMark() { return Mark.Text; }
            //Добавить на панель
            public void AddToPanel(Panel box, Point location)
            {
                Discipline.Location = location;
                Mark.Location = new Point(location.X, location.Y + 20);
                box.Controls.Add(Discipline);
                box.Controls.Add(Mark);
            }
            //Очистить поля
            public void Clear()
            {
                Discipline.Text = Mark.Text = "";
            }

        }
        //Панель для ввода набора дисциплин одного вида контроля
        public class PanelForEntering
        {
            //Родительский эл-т для всех OneDiscipline
            Panel Results;
            //Массив из предметов и оценок
            public OneDiscipline[] lastSem { get; private set; }
            //Конструктор, параметры - groupbox, на котором будут размещены поля, дисциплина и кол-во
            public PanelForEntering(Panel box, Disciplines discipline, int count)
            {
                Point locS = new Point(1, 20);
                Results = box;
                Results.Enabled = true;
                lastSem = new OneDiscipline[count];
                for (int i = 0; i < count; ++i)
                {
                    lastSem[i] = new OneDiscipline(discipline);
                    lastSem[i].AddToPanel(Results, locS);
                    locS.X += 100;
                }
            }
            //Очистка полей
            public void Clear()
            {
                for (int i = 0; i < lastSem.Length; ++i)
                    lastSem[i].Clear();
            }
            //Удаление полей с results
            public void Dispose()
            {
               for (int i=0; i<lastSem.Length; ++i)
               {
                    lastSem[i].Discipline.Visible = false;
                    lastSem[i].Mark.Visible = false;
                    Results.Controls.Remove(lastSem[i].Discipline);
                    Results.Controls.Remove(lastSem[i].Mark);
               }
                    

            }
           
        }
        //Массив из все видов контроля
        public PanelForEntering[] semestr { get; private set; }
        //Параметры - родительские эл-ты и кол-во каждого вида контролей
        public SemestrVisualization(Panel tests, Panel diftests, Panel exams, int counttests, int countdiftests, int countexams)
        {
            semestr = new PanelForEntering[3];
            //Зачеты
            semestr[0] = new PanelForEntering(tests, Disciplines.Test, counttests);
            //Диф. зачеты
            semestr[1] = new PanelForEntering(diftests, Disciplines.DiffTest, countdiftests);
            //Экзамены
            semestr[2] = new PanelForEntering(exams, Disciplines.Exam, countexams);
        }
        //Очистка всех полей
        public void Clear()
        {
            for (int i = 0; i < semestr.Length; ++i)
                semestr[i].Clear();
        }
        //Удаление всех полей
        public void Dispose()
        {
            for (int i = 0; i < semestr.Length; ++i)
                semestr[i].Dispose();
        }
    }
    
}