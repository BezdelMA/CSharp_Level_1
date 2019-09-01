using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace TrueFalse
{
    [Serializable]
    public class Questions
    {
        string ques;
        bool answer;
        static List<Questions> qList = new List<Questions>();
        static List<Questions> game = new List<Questions>();

        public string Ques
        {
            get => ques;
            set => ques = value;
        }

        public bool Answer
        {
            get => answer;
            set => answer = value;
        }
        [XmlIgnore]
        public List <Questions> QList
        {
            get => qList;
            set => qList = value;
        }
        [XmlIgnore]
        public List<Questions> Game
        {
            get => game;
            set => game = value;
        }

        public Questions()
        {

        }

        public Questions (string ques, bool answer)
        {
            this.ques = ques;
            this.answer = answer;
        }

        //Метод формирования новой пары вопрос-ответ
        public static void Enter (string ques, bool answer)
        {
            qList.Add(new Questions(ques, answer));
        }

        //Метод удаления вопроса из БД
        public static void Remove (int index)
        {
            if (qList.Count > 0)
                qList.RemoveAt(index);
            else MessageBox.Show("Нет элементов для удаления", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        //Метод загрузки файла
        public void LoadFile(string fileName, string temp)
        {
            FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            XmlSerializer xmlFormat = new XmlSerializer(typeof(List<Questions>));
            if (temp == "игра") game = (List<Questions>)xmlFormat.Deserialize(fs);
            if (temp == "изменение") qList = (List<Questions>)xmlFormat.Deserialize(fs);
            fs.Close();
        }
        
        //Метод сохранения файла
        public static bool SaveFile()
        {
            SaveFileDialog dialog = new SaveFileDialog
            {
                Filter = "Сериализовать|*.xml"
            };
            if (qList.Count == 0)
            {
                MessageBox.Show("Вы не задали ни одного вопроса", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    FileStream fs = new FileStream(dialog.FileName, FileMode.Create, FileAccess.Write);
                    XmlSerializer xmlFormat = new XmlSerializer(typeof(List<Questions>));
                    xmlFormat.Serialize(fs, qList);
                    fs.Close();
                    MessageBox.Show("База данных вопросов успешно сохранена", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return true;
                }
            }
            return false;
        }

        //Метод проверки правильности ответа
        public static bool Check (int index, bool flag) => game[index].answer == flag;
    }
}
