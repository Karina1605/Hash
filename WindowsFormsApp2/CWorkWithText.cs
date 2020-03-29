using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;
using Microsoft.VisualBasic;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace WindowsFormsApp2
{
    //Класс для работы с файлами
    class WorkWithFile
    {
        //Имя файла
        public static string FileName="";
        //Расширенние
        public static string Ext = "";

        //Открытие существующего файла
        public static void ChoseFileDialog ()
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Multiselect = false;
            openFile.Filter ="Текстовые файлы (*.txt)|*.txt| BIN файлы (*.bin)|*.bin";
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                FileName = openFile.FileName;
                Ext = Path.GetExtension(FileName);
            }
            else
            {
                FileName = "";
                Ext = ".txt";
            }
                
        }
        //Сохранение файла
        public static bool SaveFileDialog()
        {
            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.Filter = "Текстовые файлы (*.txt)|*.txt | BIN файлы (*.bin)|*.bin";
            if (saveFile.ShowDialog() == DialogResult.OK)
            {
                FileName = saveFile.FileName;
                Ext = Path.GetExtension(FileName);
                return true;
            }
            else
            {
                FileName = "";
                return false;
            }
        }
        
        //Считать файл
        public bool GetInfoFromFile (string ext, ref MyHashTable cs)
        {
            bool res = true;
            ext = ext.Trim();
            ext = ext.ToLower();
            switch (ext)
            {
                case ".bin":
                    WorkWithBinary work = new WorkWithBinary();
                    res = work.GetAllFromFile(ref cs);
                    break;
                case ".txt":
                    WorkWithText text = new WorkWithText();
                    res = text.GetAllFromFile(ref cs);
                    break;
            }
            return res;
        }
        //Записать в файл
        public bool PutInfoToFile (MyHashTable cs, string ext)
        {
            ext = ext.Trim();
            ext = ext.ToLower();
            switch (ext)
            {
                case ".bin":
                    WorkWithBinary work = new WorkWithBinary();
                    work.PutAllToFile(cs);
                    break;
                case ".txt":
                default:
                    WorkWithText text = new WorkWithText();
                    text.PutAllToFile(cs);
                    break;
            }
            return true;
        } 

        
        //Класс для работы с бинарным файлом
        public class WorkWithBinary
        {
            BinaryFormatter formatter;
            public void PutAllToFile( MyHashTable c)
            {
                formatter = new BinaryFormatter();
                using (FileStream file = new FileStream(FileName, FileMode.OpenOrCreate))
                { 
                    formatter.Serialize(file, c.AllStudents());
                }
            }
            public bool GetAllFromFile(ref MyHashTable cs)
            {
                formatter = new BinaryFormatter();
                FileStream file = null;
                bool res = true ;
                try
                {
                    file = new FileStream(FileName, FileMode.Open);
                    cs = new MyHashTable((List<CStudent>)formatter.Deserialize(file), CStudent.HashForStudent);
                }
                catch
                {
                    res = false;
                }
                finally
                {
                    if (file != null)
                        file.Close();
                }
               return res;
            }
        }
        //Класс для работы с текстовым файлом
        public class WorkWithText
        {
            public void PutAllToFile (MyHashTable cs)
            {
                cs.TableToTextFile(FileName);
            }
            public bool GetAllFromFile (ref MyHashTable c)
            {
                
                bool res = true;
                try
                {
                    c = new MyHashTable(FileName, CStudent.HashForStudent);
                }
                catch
                {
                    res = false;
                }
                return res;
            }
        }
    }
}