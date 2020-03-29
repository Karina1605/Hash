using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Runtime.Serialization;
using System.Xml;
using System.Xml.Serialization;
using System.Windows.Forms;


namespace WindowsFormsApp2
{
    /// <summary>
    /// Класс студента, поддерживает IComparable
    /// </summary>
    [Serializable] 
    public class CStudent: IComparable
    {
        //ФИО
        public CFIO FIO {get; set;}
        //Номер студенческого билета
        public string StudTicket { get; set; }
        //Результаты последней сессии
        public Semestr Semestr { get; set; }
        //Попытка считать ФИО и номер студ. билета из строки
        bool tryParseMainInfo(string st)
        {
            bool ok;
            st = st.Trim();
            //Разбиваем на массив
            string[] res = st.Split(' ');
            ok = res.Length == 4;
            //Если кол-во элементов совпадает (ФИО - 3 строки и студ. билет - 1 строка)
            if (ok)
            {
                //Присваиваем ФИО
                for (int i = 0; i < 3; i++)
                    FIO[i] = res[i];
                //Проверяем билет на корректность
                if (IsCorrectTicket(res[3]))
                {
                    StudTicket = res[3];
                }
                else
                    throw new Exception("Incorrect student ticket");
            }  
            return ok;
        }
        //Номер билета корректен, если состоит из 8 символов и преобразуем к целому положительному числу
        public static bool IsCorrectTicket(string ticket)
        {
            uint t;
            return (ticket.Length == 8 && uint.TryParse(ticket, out t) && t != 0);
        }

        //Хэш-функция для объекта CStudent
        public static int HashForStudent(string StudTicket)
        {
            if (IsCorrectTicket(StudTicket))
            {
                int res = 0;
                for (int i=0; i<StudTicket.Length; ++i)
                {
                    res = (res + Int32.Parse(StudTicket[i].ToString()) * 16) / 32;
                    
                }
                return res;
            }
            return -1;
        }

        //Считывание информации из строк
        public CStudent(string main, string tests, string diftests, string exams) 
        {
            if (tryParseMainInfo(main))
                Semestr = new Semestr(tests, diftests, exams);
        }
        

        //Чтение и текстового файла
        public CStudent (StreamReader reader)
        {
            FIO = new CFIO();
            readBlockFromText(reader); 
        }

        //Вспомогательная функция чтения из файла
        public void readBlockFromText(StreamReader reader)
        {
            //Чтение основоной инфы
            string main = reader.ReadLine();
            //Чтение зачетов
            string tests = reader.ReadLine();
            //Чтение дифференцированных зачетов
            string diftests = reader.ReadLine();
            //Чтение экзаменов
            string exasms = reader.ReadLine();
            //Получение основной информации
            tryParseMainInfo(main);
            //Заполнения информации о семестрах
            Semestr = new Semestr(tests, diftests, exasms);
            //Пропуск пустой строки
            reader.ReadLine();
        }
        //Конструктор получающий информацию о кол-ве каждого вида контролей
        public CStudent (int countTests, int countDIfTests, int countExams)
        {
            FIO = new CFIO();
            StudTicket = "-";
            Semestr = new Semestr(countExams, countTests, countDIfTests);
        }
        //Преобразование к массиву строк
        public string[] ToStrArr()
        {
            string[] res = new string[4];
            res[0] = FIO.ToString() + " " + StudTicket;
            res[1] = Semestr.TestsToString();
            res[2] = Semestr.DifTestsToString();
            res[3] = Semestr.ExamsToString();
            return res;
        }
        //Перегрузка CompareTo, возращает 0 при совпадении ФИО и номера студенческого, иначе - 1
        public int CompareTo(object obj)
        {
            CStudent ob = (CStudent)obj;
            if (ob.FIO.CompareTo(FIO) == 0 && ob.StudTicket.CompareTo(StudTicket) == 0)
                return 0;
            return 1;
        }
    }
}