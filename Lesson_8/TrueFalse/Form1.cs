using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//Исполнил Бездель М.А. БУДУ РАД ВСЕВОЗМОЖНОЙ КРИТИКЕ, ТАК КАК ОПЫТА НЕТ, А ЖЕЛАНИЕ И МОТИВАЦИЯ <ДЕЛАТЬ ПРАВИЛЬНО> ЕСТЬ
//Добавлены проверки, какие только пришли в голову
//Вопросы генерировать, изменять, удалять может только пользователь, прошедший авторизацию
//Во время игры предлагается ответить на 10 вопросов, ведется подсчет очков
//По поводу внешнего вида решил пока не переживать

namespace TrueFalse
{
    public partial class Form1 : Form
    {
        //Объявление глобальных переменных
        Questions questions;
        Random rnd = new Random();
        int index;
        int point;
        int maxCount;
        bool flag = true;
        int countChange = 0;
        int passwordCount = 0;
        
        //Инициализация необходимых компонентов
        public Form1()
        {
            InitializeComponent();
            nUDNumber.Maximum = 0;
            questions = new Questions();
            rbTrue.Tag = false;
            btTrue.Visible = false;
            btFalse.Visible = false;
            btChange.Enabled = false;
            Timer timer = new Timer
            {
                Interval = 1000,
                Enabled = true
            };
            timer.Tick += Timer_Tick;
        }

        //Добавление на форму текущего времени
        private void Timer_Tick(object sender, EventArgs e)
        {
            tSSLTime.Text = DateTime.Now.ToLongTimeString();
        }

        /// <summary>
        /// Метод проверки правильности выбора ответа
        /// </summary>
        /// <param name="flag"></param>
        void CheckResult(bool flag)
        {
            maxCount--;
            if (Questions.Check(index, flag))
            {
                lblCheck.ForeColor = Color.Green;
                lblCheck.Text = "Верно";
                point++;
            }
            else
            {
                lblCheck.ForeColor = Color.Red;
                lblCheck.Text = "Не правильно";
            }
            if (maxCount == 0)
            {
                MessageBox.Show("Игра закончена\nКоличество набранных Вами очков: " + point, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btTrue.Visible = false;
                btFalse.Visible = false;
                btStartGame.Visible = true;
                lblQues.Text = "";
                lblCheck.Text = "";
                questions.Game.Clear();
            }
        }

        /// <summary>
        /// Выбор из БД и вывод на экран очередного вопроса
        /// </summary>
        void Game()
        {
            index = rnd.Next(0, questions.Game.Count);
            lblQues.Text = questions.Game[index].Ques;
        }

        /// <summary>
        /// Поведение клавишь, если удачно начата игра
        /// </summary>
        void OKResultLoad()
        {
            btStartGame.Visible = false;
            btTrue.Visible = true;
            btFalse.Visible = true;
            point = 0;
            maxCount = 10;
        }
        
        //Описание работы кнопки Добавления нового вопроса
        private void BtEnter_Click(object sender, EventArgs e)
        {
            if (tbQues.Text == "") MessageBox.Show("Вопрос пуст", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                Questions.Enter(tbQues.Text, rbTrue.Checked);
                nUDNumber.Maximum = questions.QList.Count + 1;
                nUDNumber.Value = questions.QList.Count + 1;
                tbQues.Clear();
                flag = false;
                btRemove.Enabled = true;
                countChange++;
            }
        }

        //Описание работы РадиоКнопки выбора правда/ложь
        private void RbTrue_Click(object sender, EventArgs e)
        {
            if ((bool)rbTrue.Tag) rbTrue.Checked = false;
            else rbTrue.Checked = true;
            rbTrue.Tag = rbTrue.Checked;
        }

        //Описание работы кнопки Удаления вопроса. Добавлено дополнительное сообщение об удалении
        //Добавлены проверки на наличие информации для удаления и т.д.
        private void BtRemove_Click(object sender, EventArgs e)
        {
            DialogResult dr = new DialogResult();
            if (questions.QList.Count == 0) MessageBox.Show("Нет элементов для удаления", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            else if (nUDNumber.Value > questions.QList.Count) MessageBox.Show("Вы создали " + questions.QList.Count + " вопросов, а пытаетесь удалить вопрос под индексом " + nUDNumber.Value + ", который еще не создан", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {
                dr = MessageBox.Show("Вы уверены, что хотите удалить вопрос?", "Attention", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                if (dr == DialogResult.OK)
                {
                    Questions.Remove((int)nUDNumber.Value - 1);
                    if (questions.QList.Count > 0)
                    {
                        nUDNumber.Maximum = questions.QList.Count;
                        tbQues.Text = questions.QList[(int)nUDNumber.Value - 1].Ques;
                    }
                    else
                    {
                        tbQues.Text = "";
                        btChange.Enabled = false;
                    }
                    flag = false;
                    countChange++;
                }
            }
        }

        //Описание работы кнопки по формированию xml файла с вопросами
        private void Button1_Click(object sender, EventArgs e)
        {
            if (countChange > 0)
            {
                if (Questions.SaveFile())
                {
                    tbQues.Text = "";
                    questions.QList.Clear();
                    flag = true;
                    btChange.Enabled = false;
                    btEnter.Enabled = false;
                    btRemove.Enabled = false;
                }
            }
            else
            {
                DialogResult dr = new DialogResult();
                dr = MessageBox.Show("Вы не произвели ни одного изменения. Вы действительно хотите закончить работу с вопросами?", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                if (dr == DialogResult.OK)
                {
                    tbQues.Text = "";
                    questions.QList.Clear();
                    flag = true;
                    btChange.Enabled = false;
                    btEnter.Enabled = false;
                    btRemove.Enabled = false;
                }
                else { }
            }
        }

        //Описание события изменения значения выбора вопроса, осуществлена привязка вывода вопроса и значения правда/ложи при прокрутке
        private void NUDNumber_ValueChanged(object sender, EventArgs e)
        {
            if (questions != null)
            {
                nUDNumber.Maximum = questions.QList.Count + 1;
                nUDNumber.Minimum = 1;
                if (nUDNumber.Value > questions.QList.Count)
                {
                    tbQues.Text = "";
                    rbTrue.Checked = false;
                }
                else
                {
                    tbQues.Text = questions.QList[(int)nUDNumber.Value - 1].Ques;
                    rbTrue.Checked = questions.QList[(int)nUDNumber.Value - 1].Answer;
                    if (tbQues != null) btChange.Enabled = true;
                }
            }
        }

        //Кнопка запуска игры. Пропадает после нажатия, появляются 2 кнопки реакции на вопрос
        //Убрал объявление и заполнение временной колекции List, что уменьшило затрачиваемую оперативную память в 2 раза
        private void BtStartGame_Click(object sender, EventArgs e)
        {
            if (flag == false) MessageBox.Show("Невозможно начать игру, пока не сохранен файл с вопросами", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                OpenFileDialog dialog = new OpenFileDialog
                {
                    Filter = "Десериализовать|*.xml"
                };
                //Загрузка файлов с вопросами по умолчанию
                try
                {
                    questions.LoadFile(@"Questions(2)().xml", "игра");
                    tSSLFileName.Text = "Questions(2)().xml";
                    OKResultLoad();
                    Game();
                }
                //В случае отсутствия файла, предлогается найти его самостоятельно
                catch
                {
                    MessageBox.Show("Файл игры по-умолчанию не найден\nВыберете другой", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    if (dialog.ShowDialog() == DialogResult.OK)
                    {
                        questions.LoadFile(dialog.FileName, "игра");
                        tSSLFileName.Text = dialog.FileName;
                        OKResultLoad();
                        Game();
                    }
                }
            }
        }

        //Кнопка <верю>
        private void BtTrue_Click(object sender, EventArgs e)
        {
            CheckResult(true);
            if (maxCount > 0) Game();
        }

        //Кнопка <НЕ верю>
        private void BtFalse_Click(object sender, EventArgs e)
        {
            CheckResult(false);
            if (maxCount > 0) Game();
        }

        //Открытие файла с вопросами в формате *.xml
        private void OpenFileGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog
            {
                Filter = "Десериализовать|*.xml"
            };
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                questions.LoadFile(dialog.FileName, "игра");
                btStartGame.Visible = false;
                btTrue.Visible = true;
                btFalse.Visible = true;
                tSSLFileName.Text = dialog.FileName;
                point = 0;
                maxCount = 10;
                Game();
            }
        }

        //Описание кнопки открытия БД для корректировки вопросов
        //Убрал объявление и заполнение временной колекции List, что уменьшило затрачиваемую оперативную память в 2 раза
        private void BtOpenChange_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog
            {
                Filter = "Десериализовать|*.xml"
            };
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                questions.LoadFile(dialog.FileName, "изменение");
                if (questions.Game.Count != 0 && questions.Game[1].Ques == questions.QList[1].Ques)
                {
                    MessageBox.Show("Невозможно изменять список вопросов во время их использования в запущенной игре", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    questions.QList.Clear();
                }
                else
                {
                    tbQues.Text = questions.QList[questions.QList.Count - 1].Ques;
                    rbTrue.Checked = questions.QList[questions.QList.Count - 1].Answer;
                    nUDNumber.Maximum = questions.QList.Count;
                    nUDNumber.Value = questions.QList.Count;
                    tSSLFileName.Text = dialog.FileName;
                    btChange.Enabled = true;
                }
            }
            flag = false;
            countChange = 0;
        }

        //Описание работы кнопки по изменению вопросов в БД. Становится активной ТОЛЬКО когда есть, что изменять
        private void BtChange_Click(object sender, EventArgs e)
        {
            questions.QList[(int)nUDNumber.Value - 1].Ques = tbQues.Text;
            questions.QList[(int)nUDNumber.Value - 1].Answer = rbTrue.Checked;
            flag = false;
            countChange++;
        }

        //Описание пункта меню прерывания игры в любой момент
        private void GameOverToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (questions.Game == null || questions.Game.Count == 0) MessageBox.Show("Игра еще не началась", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
            {
                MessageBox.Show("Игра закончена\nКоличество набранных Вами очков: " + point, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btTrue.Visible = false;
                btFalse.Visible = false;
                btStartGame.Visible = true;
                lblQues.Text = "";
                lblCheck.Text = "";
                questions.Game.Clear();
            }
        }

        //Описание пункта меню закрытия окна
        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (flag == false)
            {
                DialogResult dialog = new DialogResult();
                dialog = MessageBox.Show("Вы не сохранили вопросы в файл. Продолжить?", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                if (dialog == DialogResult.OK) this.Close();
            }
            else
            this.Close();
        }

        //Описание пункта меню <О программе>
        private void AboutProgramToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Автор: Бездель М.А.\nv.1.0.\nВсе права защищены", "О программе", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        //При ненулевом значении текстбокса кнопка <Добавить> становится активна
        private void TbQues_TextChanged(object sender, EventArgs e)
        {
            if (tbQues.Text != "") btEnter.Enabled = true;
            else btEnter.Enabled = false;
        }

        //Открытие новой формы для прохождения авторизации для изменения вопросов
        //авторизация проходится единожды, но при каждом запуске программы
        private void TabControl1_Selected(object sender, TabControlEventArgs e)
        {
            if (passwordCount == 0)
            {
                if (tabControl1.SelectedIndex == 1)
                {
                    Password Password = new Password();
                    DialogResult dr = Password.ShowDialog();
                    if (dr == DialogResult.OK)
                    {
                        tabControl1.SelectedIndex = 1;
                        passwordCount++;
                    }
                    else if (dr != DialogResult.OK) tabControl1.SelectedIndex = 0;
                }
            }
        }
    }
}
