using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    //Состояние ячейки в хеш-таблице
    public enum Filling { Free, Full, Deleted }
    /// <summary>
    /// Класс, характеризующий одно поле в хеш-таблице
    /// </summary>
    public class OneField
    {
        //Информационная часть
        public CStudent info { get; set; }
        //Состояние ячейки
        public Filling filling { get; set; }
        //Указатель на следующий элемент с таким же хешом, если есть
        public int? next;
        //Заполнение при наличиии информационной части
        public OneField(CStudent info)
        {
            this.info = info;
            filling = Filling.Full;
            next = null;
        }
        //Автоматическое заполнение ячейки
        public OneField()
        {
            filling = Filling.Free;
            next = null;
        }
        
        
        
    }
    
    /// <summary>
    /// Класс хеш-таблицы
    /// </summary>
    public class MyHashTable
    {
        const float coef1 = 0.61f;
        const float coef2 = 0.5f;
        //Вместимость таблицы
        public readonly int Capacity;
        //Кол-ыо элементов на текущий момент
        public int Count { get; private set; }
        //Хеш-таблица
        OneField[] records;
        //Хеш-функция
        Func<string, int> HashFunc;
        //Загрузка таблицы из списка студентов, хеш-фукция передается в объект как параметр
        public MyHashTable(List<CStudent> cs, Func<string, int> func, int capacity =19):this(func, capacity)
        {
            for (int i = 0; i < cs.Count; ++i)
                Add(cs.ElementAt(i), cs.ElementAt(i).StudTicket);
        }
        //Загрузка из текстового файла
        public MyHashTable (string FileName,  Func<string, int> func, int capacity=19) : this(func, capacity)
        {
            LoadFromFile(FileName);
        }
        //Конструктор, создающий пустую таблицу
        public MyHashTable(Func<string, int> func, int capacity=19)
        {
            HashFunc = func;
            records = new OneField[capacity];
            //Инициализация начальными значениями
            for (int i = 0; i < capacity; ++i)
                records[i] = new OneField();
            Count = 0;
            Capacity = capacity;
        }
        //Добавить элемент
        public void Add (CStudent info, string key)
        {
            //Если таблица полна - исключение
            if (Count == Capacity)
                throw new Exception("Таблица полна");
            //Находим позицию вставки
            int pos = (HashFunc(key)) % records.Length;
            //если она занята - находим следующую свободную позицию методом линейного опробования
            //Исправлено, теперь поиск следющий ячейки начинается с ячейки вычисленной хеш-функцией
            //Так как использовано линейное опробование, элементы будут заполнятся подряд, поэтому мы сначала доходим
            //до последнего элемента цепочки по указателям (не подряд т.к. между ними уже все ячейки забиты)
            //и ищем следующую свободную за последней ячейкой цепочки
            while (records[pos].next != null)
                pos = (int)records[pos].next;
            int last = pos;
            while (records[last].filling == Filling.Full)
                last = (last + 1) % Capacity;
            if (last == pos)
            {
                records[pos].info = info;
                records[pos].filling = Filling.Full;
            }
            else
            {
                records[last].info = info;
                records[pos].next = last;
                records[last].filling = Filling.Full;
            }
            Count++;
        }
        //Поиск студента с указанными ФИО и номером студенческого
        public CStudent Search (CStudent example)
        {
            //Вычисляем значение, по которому будем искать
            int p = HashFunc(example.StudTicket);
            bool isEnd = false;
            //Пока не нашли совпадение и цепочка не закончилась, продолжаем поиск
            while (records[p].filling != Filling.Free && !isEnd)
            {
                //Если ячейка полна - сверяем ее, и, если все поля совпали - возвращаем этого студента
                if (records[p].filling == Filling.Full)
                    if (records[p].info.StudTicket.CompareTo(example.StudTicket) == 0)
                        return records[p].info;
                    else
                    //иначе, если указателей на последующие эл-ты нет - конец цепочки
                    if (records[p].next == null)
                        isEnd = true;
                    else
                        p = (int)records[p].next;
            }
            return null;
        }
        //Удаление эл-та из таблицы
        public void Delete (CStudent student)
        {
            //Находим индекс по ключу
            int p = HashFunc(student.StudTicket);
            bool isEnd = false;
            //Пока не удалили или не долши до конца цепочки продолжаем поиск удаляемого эл-та
            while (records[p].filling!=Filling.Free && !isEnd)
            {
                //Если ячекйка заполнена, то сверяем, при совпадении меняем состояние
                if (records[p].filling == Filling.Full)
                    if (records[p].info.CompareTo(student) == 0)
                    {
                        records[p].filling = Filling.Deleted;
                        isEnd = true;
                        Count--;
                    }
                    else
                    if (records[p].next == null)
                        isEnd = true;
                    else
                        p =(int)records[p].next;
            }
        }
        //Главная задача - по номеру студенческого ищем студента
        public CStudent MainTask (string TicketNumber)
        {
            //Если номер билета некорректен - исключение
            if (!CStudent.IsCorrectTicket(TicketNumber))
                throw new Exception("Некорректный номер билета");
            //Находим позицию
            int p = HashFunc(TicketNumber);
            //Пока не дошли до конца или номера студ. билетов не совпали - ищем по цепочке
            while (records[p].filling!=Filling.Free)
            {
                if (records[p].filling == Filling.Full)
                    if (records[p].info.StudTicket.CompareTo(TicketNumber) == 0)
                        return records[p].info;
                if (records[p].next != null)
                    p = (int)records[p].next;
            }
            return null;
        }
        //Список всех студентов, хранящихся в таблице
        public List<CStudent> AllStudents()
        {
            List<CStudent> res = new List<CStudent>();
            for (int i = 0; i < Capacity; ++i)
                if (records[i].filling == Filling.Full)
                    res.Add(records[i].info);
            return res;
        }
        //Очистка таблицы
        public void Clear()
        {
            for (int i=0; i<records.Length; ++i)
            {
                records[i].filling = Filling.Free;
                records[i].info = null;
                records[i].next = null;
            }
        }
        //Считывание списка студентов из файла
        public void LoadFromFile(string path)
        {
            using (StreamReader reader = new StreamReader(path))
            {
                CStudent student;
                while (!reader.EndOfStream)
                {
                    student = new CStudent(reader);
                    Add(student, student.StudTicket);
                }
            }
        }
        //Запись студетов в файл
        public void TableToTextFile(string FileName)
        {   
            //буфер
            string[] buff;
            using (StreamWriter file = new StreamWriter(FileName, false))
            {
                //Получение всх студентов
                List<CStudent> all = AllStudents();
                //Преобразование каждого студента к массиву строк и их запись в файл
                for (int i = 0; i < all.Count; i++)
                {
                    buff = all.ElementAt(i).ToStrArr();
                    for (int j = 0; j < buff.Length; j++)
                        file.WriteLine(buff[j]);
                    file.WriteLine();
                }
            }
        }
        
        //Отображение таблицы в новой форме
        public Form LoadToScreen ()
        {
            Form res = new Form();
            Panel panel = new Panel();
            Button Ok = new Button();
            Ok.Text = "Выйти";
            Ok.Width = 80;
            Ok.Click += Ok_Click;
            Ok.Location = new System.Drawing.Point(10, 630);
            res.Width = 1400;
            res.Height = 700;
            panel.Width = 1250;
            panel.Height = 600;
            panel.Location = new System.Drawing.Point(10, 10);
            panel.AutoScroll = true;
            res.Controls.Add(panel);
            res.Controls.Add(Ok);
            COneRecord.InitCapt(panel, new System.Drawing.Point(10, 0));
            System.Drawing.Point point = new System.Drawing.Point(10, 30);
            for (int i=0; i< Capacity; ++i)
            {
                COneRecord  r= new COneRecord(records[i], i);
                if (i >= 15)
                    panel.VerticalScroll.Value = panel.VerticalScroll.Minimum;
                r.AddToPanel(panel, point.X, point.Y);
                point.Y += 30;

            }
            return res;
        }

        private void Ok_Click(object sender, EventArgs e)
        {
            ((Form)(((Button)sender).Parent)).Close();
        }
    }
}
