using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace WindowsFormsApp2
{
    /// <summary>
    /// Класс описывающий ФИО студента, поддерживающий ICompaable, т.к. поиск в таблице будет осущесвлятся по инициалам
    /// </summary>
    [Serializable]
    public class CFIO : IComparable
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Pathronymic { get; set; }
        
        //Конструктор, принимающий информацию в виде массива
        public CFIO(string[] Init)
        {
            InitByArr(Init);
        }
        //Констуктор, принимающий ФИО одной строкой
        public CFIO (string st)
        {
            st = st.Trim();
            string[] parced = st.Split(' ');
            InitByArr(parced);
        }
        //Конструктор по умолчанию
        public CFIO()
        {
            Default();
        }
        //Инициализация массивом
        void InitByArr (string[] st)
        {   
            if (st.Length != 3)
                Default();
            else
                for (int i = 0; i < 3; i++)
                {
                    this[i] = st[i];
                }
        }
        //Метод, устанавливающий значения по умолчанию для полей класса 
        public void Default ()
        {
            LastName = FirstName = "";
            Pathronymic = "-";
        }
        //Индексатор для доступа к ФИО по индексу (от 1 до 3)
        public string this[int i]
        {
            get
            {
                switch(i)
                {
                    case 0: return LastName;
                    case 1: return FirstName;
                    case 2: return Pathronymic;
                    default: return "";
                }
            }
            set
            {
                switch(i)
                {
                    case 0: LastName=value;
                        break;
                    case 1: FirstName=value;
                        break;
                    case 2: Pathronymic = value;
                        break;
                    default: Default();
                        break;
                }
                
            }
        }

        public override string ToString()
        {
            string res = LastName + " " + FirstName + " " + Pathronymic;
            return res;
        }

        //Перегрузка метода Compare 0, если инициалы полностью совпадают, иначе - 1
        public int CompareTo(object obj)
        {
            CFIO fIO = (CFIO)obj;
            if (fIO.LastName.CompareTo(LastName) == 0 && fIO.FirstName.CompareTo(FirstName) == 0 && fIO.Pathronymic.CompareTo(Pathronymic) == 0)
                return 0;
            return 1;
        }
    }
}
