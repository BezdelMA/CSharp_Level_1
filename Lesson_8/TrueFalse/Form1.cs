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
//Сам код написан криво, однако нет возможности до времени сдачи все подчистить. При этом игра работает, постарался учесть возможные исключения
//Добавлены проверки, какие только пришли в голову
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

        //Описание работы кнопки Добавления нового вопроса
        private void BtEnter_Click(object sender, EventArgs e)
        {
            if (tbQues.Text == "") MessageBox.Show("Вопрос пуст", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                Questions.Enter(tbQues.Text, rbTrue.Checked);
                nUDNumber.Maximum = questions.QList.Count;
                nUDNumber.Value = questions.QList.Count;
                tbQues.Clear();
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
            }
        }

        //Описание работы кнопки по формированию xml файла с вопросами
        private void Button1_Click(object sender, EventArgs e)
        {
            Questions.SaveFile();
            tbQues.Text = "";
            questions.QList = null;
        }

        //Описание события изменения значения выбора вопроса, осуществлена привязка вывода вопроса и значения правда/ложи при прокрутке
        private void NUDNumber_ValueChanged(object sender, EventArgs e)
        {
            if (questions != null)
            {
                nUDNumber.Maximum = questions.QList.Count;
                nUDNumber.Minimum = 1;
                tbQues.Text = questions.QList[(int)nUDNumber.Value - 1].Ques;
                rbTrue.Checked = questions.QList[(int)nUDNumber.Value - 1].Answer;
                if (tbQues != null) btChange.Enabled = true;
            }
        }

        //Кнопка запуска игры. Пропадает после нажатия, появляются 2 кнопки реакции на вопрос
        private void BtStartGame_Click(object sender, EventArgs e)
        {
            List<Questions> temp = new List<Questions>();
            OpenFileDialog dialog = new OpenFileDialog
            {
                Filter = "Десериализовать|*.xml"
            };
            dialog.ShowDialog();
            questions.LoadFile(dialog.FileName, ref temp);
            questions.Game = temp;
            temp = null;
            tSSLFileName.Text = dialog.FileName;
            btStartGame.Visible = false;
            btTrue.Visible = true;
            btFalse.Visible = true;
            point = 0;
            maxCount = 10;
            Game();
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
            List<Questions> temp = new List<Questions>();
            OpenFileDialog dialog = new OpenFileDialog
            {
                Filter = "Десериализовать|*.xml"
            };
            dialog.ShowDialog();
            questions.LoadFile(dialog.FileName, ref temp);
            questions.Game = temp;
            temp = null;
            btStartGame.Visible = false;
            btTrue.Visible = true;
            btFalse.Visible = true;
            tSSLFileName.Text = dialog.FileName;
            point = 0;
            maxCount = 10;
            Game();
        }

        //Описание кнопки открытия БД для корректировки вопросов
        private void BtOpenChange_Click(object sender, EventArgs e)
        {
            List<Questions> temp = new List<Questions>();
            OpenFileDialog dialog = new OpenFileDialog
            {
                Filter = "Десериализовать|*.xml"
            };
            dialog.ShowDialog();
            questions.LoadFile(dialog.FileName, ref temp);
            questions.QList = temp;
            temp = null;
            tbQues.Text = questions.QList[questions.QList.Count - 1].Ques;
            rbTrue.Checked = questions.QList[questions.QList.Count - 1].Answer;
            nUDNumber.Maximum = questions.QList.Count;
            nUDNumber.Value = questions.QList.Count;
            tSSLFileName.Text = dialog.FileName;
        }

        //Описание работы кнопки по изменению вопросов в БД. Становится активной ТОЛЬКО когда есть, что изменять
        private void BtChange_Click(object sender, EventArgs e)
        {
                questions.QList[(int)nUDNumber.Value - 1].Ques = tbQues.Text;
                questions.QList[(int)nUDNumber.Value - 1].Answer = rbTrue.Checked;
        }

        //Описание пункта меню прерывания игры в любой момент
        private void GameOverToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Игра закончена\nКоличество набранных Вами очков: " + point, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            btTrue.Visible = false;
            btFalse.Visible = false;
            btStartGame.Visible = true;
            lblQues.Text = "";
            lblCheck.Text = "";
        }

        //Описание пункта меню закрытия окна
        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //Описание пункта меню <О программе>
        private void AboutProgramToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Автор: Бездель М.А.\nv.1.0.\nВсе права защищены", "О программе", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
