using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using System.Windows.Forms;
using System.Drawing;

namespace WindowsFormsApp2
{
    /// <summary>
    /// Класс, описывающий один экзамен, состоит из строкового поля - название дисциплины, byte-поле - оценка
    /// </summary>
    [Serializable]
    public class Cexam
    {
        //Свойство, описывающее название предмета, доступно для чтения и записи
        public string Subject { get; set; }
        //Свойство, описывающее оценку за экзамен, предусмотрено отслеживание допкстимой оценки
        public byte Mark
        {
            get{ return mark;}
            set
            {
                if (value >=2 && value <= 5)
                    mark = value;
                else
                    mark = 2;
            }
        }
        byte mark;
        //Конструктор, принимающий строку - название дисциплины и число -оченку
        public Cexam(string subject, byte mark)
        {
            Mark = mark;
            Subject = subject;
        }
        //Получение данных из строкового массива
        public Cexam(string[] vs)
        {
            TryGetFromSTArray(vs);
        }
        //Получение данных из строки
        public Cexam(string st) 
        {
            st = st.Trim();
            string[] res = st.Split(' ');
            TryGetFromSTArray(res);
        }
        //Конструктор по умолчанию
        public Cexam()
        {
            Subject = "-";
            Mark = 0;
        }
        //Вспомогательная функция для чтения информации из массива
        public void TryGetFromSTArray(string[] vs)
        {
            if (vs.Length==2)
            {
                Subject = vs[0];
                mark = Byte.Parse(vs[1]);
            }
            else
            {
                Subject = "-";
                mark = 2;
            }
        }
        public override string ToString()
        {
            return Subject+" "+mark.ToString();
        }
    }

    /// <summary>
    /// Класс, похожий на CExam, но вместо поля с оценкой логичектое значение - сдан зачет или нет
    /// </summary>
    [Serializable]
    public class Test
    {
        //Информация
        public string Disciplin { get; set; }
        public bool IsPassed { get; set; }
        //Возвращение информации о состоянии зачета в строковом виде
        public string IsPassedTests { get { return IsPassed ? "Зачтено" : "Незачтено"; } }
        //Констркутор по умолчанию
        public Test()
        {
            Disciplin = "-";
            IsPassed = false;
        }
        //Стандартный конструктор
        public Test(string disciplin, bool ispassed)
        {
            Disciplin = disciplin;
            IsPassed = ispassed;
        }
        //Получение информации из строкового массива
        public Test (string[] vs)
        {
            TryGetFromSTArray(vs);
        }
        //Плучение информации из строки
        public Test(string st)
        {
            TryGetFromSTArray(st.Trim().Split(' '));
        }
        //Вспомогательная функция парсировки массива
        public void TryGetFromSTArray (string[] arr)
        {
            if (arr.Length==2)
            {
                Disciplin = arr[0];
                if (arr[1] == "Зачтено")
                    IsPassed = true;
                else
                    IsPassed = false;
            }
            else
            {
                Disciplin = "-";
                IsPassed = false;
            }
        }
        public override string ToString()
        {
            return Disciplin + " " + (IsPassed == true ? "Зачтено" : "Незачтено");
        }
    }


    /// <summary>
    /// Класс описывающий экзамены в одной сессии
    /// </summary>
    [Serializable]
    public class CSemestrExams
    {
        //Экзамены сессии
        Cexam[] Exams { get; set; }
        //Сво-во для чтения, возвращает кол-во экзамнов сессии
        public int Count { get { return Exams.Length; } }
        //Индексатор, осуществляющий доступ только для чтения массива экзаменов
        public Cexam this[int i] { get { return Exams[i]; } }
        //Конструктор, принимающий на вход кол-во экзаменов
        public CSemestrExams(int countExams)
        {
            Exams = new Cexam[countExams];
            for (int i = 0; i < Exams.Length; i++)
                Exams[i] = new Cexam();    
        }
        //Чтения результатов сессии из строки
        public CSemestrExams (string info)
        {
            info = info.Trim();
            string[] r= info.Split(' ');
            Exams = new Cexam[r.Length/2];
            for (int i = 0; i < Exams.Length; i++)
            {
                Exams[i] = new Cexam(new string[] { r[2 * i], r[2 * i + 1] });

            }
        }
        public override string ToString()
        {
            string res = "";
            for (int i = 0; i < Exams.Length; i++)
                res += Exams[i].ToString() + " ";
            return res;
        }
        //Вспомогательная функция чтения из строки, строка имеет формат: <Дисциплина> <Оценка>{<Дисциплина> <Оценка>}
        public void Parse (string st)
        {
            st = st.Trim();
            string[] res = st.Split(' ');
            if (res.Length==Exams.Length*2)
            {
                for (int i=0; i<Exams.Length; ++i)
                Exams[i].TryGetFromSTArray(new string[] { res[2 * i], res[2 * i + 1] });
            }
        }
        //Переустановка экзаменов
        public void ReadDisciplines(string[] arr)
        {
            if (arr.Length != Exams.Length)
                throw new Exception("Несоотвествие кол-ву дисциплин");
            for (int i = 0; i < arr.Length; ++i)
                Exams[i].Subject = arr[i];
        }
        //Переустановка оценок
        public void ReadMarks (string[] arr)
        {
            if (arr.Length != Exams.Length)
                throw new Exception("Несоотвествие кол-ву дисциплин");
            for (int i = 0; i < arr.Length; ++i)
                Exams[i].Mark = Byte.Parse(arr[i]);
        }
        
    }

    /// <summary>
    /// Класс, описывающий зачетную сессию, аналогичен CSemestrsExams
    /// </summary>
    [Serializable]
    public class CSemestrTests
    {
        Test[] Tests { get; set; }
        public int Count { get { return Tests.Length; } }
        public Test this[int i] { get { return Tests[i]; } }
        public CSemestrTests(int countTests = 7)
        {
            Tests = new Test[countTests];
            for (int i = 0; i < Tests.Length; i++)
                Tests[i] = new Test();
        }
        public CSemestrTests(string info)
        {
            info = info.Trim();
            string[] r = info.Split(' ');
            Tests = new Test[r.Length / 2];
            for (int i = 0; i < Tests.Length; i++)
            {
                Tests[i] = new Test(new string[] { r[2 * i], r[2 * i + 1] });

            }
        }
        public override string ToString()
        {
            string res = "";
            for (int i = 0; i < Tests.Length; i++)
                res += Tests[i].ToString() + " ";
            return res;
        }
        public void Parse(string st)
        {
            st = st.Trim();
            string[] res = st.Split(' ');
            if (res.Length == Tests.Length * 2)
            {
                for (int i = 0; i < Tests.Length; i++)
                {
                    Tests[i].TryGetFromSTArray(new string[] { res[2 * i], res[2 * i + 1] });
                }
            }
        }
        public void ReadDisciplines(string[] arr)
        {
            if (arr.Length != Tests.Length)
                throw new Exception("Несоотвествие кол-ву дисциплин");
            for (int i = 0; i < arr.Length; ++i)
                Tests[i].Disciplin= arr[i];
        }
        public void ReadMarks(string[] arr)
        {
            if (arr.Length != Tests.Length)
                throw new Exception("Несоотвествие кол-ву дисциплин");
            for (int i = 0; i < arr.Length; ++i)
                Tests[i].IsPassed = arr[i].ToLower() == "зачет" ? true : false;
        }
    }
    /// <summary>
    /// Класс описывающий одну сессию
    /// </summary>
    [Serializable]
    public class Semestr
    {
        //Экзамены
        public CSemestrExams exams { get; private set; }
        //Зачеты
        public CSemestrTests tests { get; private set; }
        //Дифференцированные зачеты
        public CSemestrExams testsWithMark { get; private set; }
        //Получение информации о кол-ве каждого вида контроля
        public int CountOfTests { get { return tests.Count; } }
        public int CountOfExams { get { return exams.Count; } }
        public int CountOfDiffTests { get { return testsWithMark.Count; } }

        //Конструктор, принимающий на вход информацию о кол-ве каждого вида контроля
        public Semestr (int countex, int counttests, int countMarkTests)
        {
            exams = new CSemestrExams(countex);
            tests = new CSemestrTests(counttests);
            testsWithMark = new CSemestrExams(countMarkTests);
        }
        //Получение информации из строк
        public Semestr (string Tests, string DifTests, string Exams)
        {
            exams = new CSemestrExams(Exams);
            tests = new CSemestrTests(Tests);
            testsWithMark = new CSemestrExams(DifTests);
        }
        //Преобразование к строковому формату каждого вида контроля
        public string TestsToString() { return tests.ToString(); }
        public string ExamsToString() { return exams.ToString(); }
        public string DifTestsToString() { return testsWithMark.ToString(); }
        //Чтения информации с экрана (класс SemestrVisualization содержит 3 groupbox в каждом хранится набор объекта типа textbox и combobox 
        public void ReadFromScreen (SemestrVisualization semestr)
        {
            //буферы для хранения инфы об предметах и оценках
            string[] disciplines, marks;
            //Считывание информации о зачетах
            disciplines = new string[semestr.semestr[0].lastSem.Length];
            marks = new string[disciplines.Length];
            for (int i=0; i< marks.Length; ++i)
            {
                disciplines[i] = semestr.semestr[0].lastSem[i].getSubject();
                marks[i] = semestr.semestr[0].lastSem[i].getMark();
            }
            tests.ReadDisciplines(disciplines);
            tests.ReadMarks(marks);

            //Считывание информации о дифференцированных зачетах
            disciplines = new string[semestr.semestr[1].lastSem.Length];
            marks = new string[disciplines.Length];
            for (int i = 0; i < marks.Length; ++i)
            {
                disciplines[i] = semestr.semestr[1].lastSem[i].getSubject();
                marks[i] = semestr.semestr[1].lastSem[i].getMark();
            }
            testsWithMark.ReadDisciplines(disciplines);
            testsWithMark.ReadMarks(marks);

            //Считывание информации об экзаменах
            disciplines = new string[semestr.semestr[2].lastSem.Length];
            marks = new string[disciplines.Length];
            for (int i = 0; i < marks.Length; ++i)
            {
                disciplines[i] = semestr.semestr[2].lastSem[i].getSubject();
                marks[i] = semestr.semestr[2].lastSem[i].getMark();
            }
            exams.ReadDisciplines(disciplines);
            exams.ReadMarks(marks);
        }
        
    }
}