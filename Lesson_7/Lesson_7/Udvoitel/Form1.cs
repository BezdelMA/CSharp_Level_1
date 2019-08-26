using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//Бездель М.А.
//При запуске новой игры сначала идет проверка не запущена ли игра уже и пользователю дается выбор: начать новую или продолжить старую
//Ведется подсчет очков

namespace Lesson_7
{
    public partial class Form1 : Form
    {
        Udvoitel udvoitel;

        public Form1()
        {
            InitializeComponent();
        }

        private void NewGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (udvoitel != null)
            {
                DialogResult dialog = new DialogResult();
                dialog = MessageBox.Show("Вы не закончили предыдущую игру\n\nВы уверены, что хотите начать новую?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (dialog == DialogResult.Yes)
                {
                    udvoitel = new Udvoitel(new Random().Next(1, 101));
                }
            }
            else
            {
                udvoitel = new Udvoitel(new Random().Next(1, 101));
            }
                lblanswer.Text = "Составьте число: " + udvoitel.Answer.ToString();
                lbluserAnswer.Text = "Ваш ответ: " + udvoitel.UserAnswer.ToString();
                lblStep.Text = "Количество совершенных шагов " + udvoitel.Step.ToString();
                lblMin.Text = "Количество шагов для решения: " + udvoitel.StepMin.ToString();
        }

        private void ResetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (udvoitel == null) MessageBox.Show("Игра еще не началась", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                udvoitel.Reset();
                lblStep.Text = "Количество совершенных шагов " + udvoitel.Step.ToString();
                lbluserAnswer.Text = "Ваш ответ: " + udvoitel.UserAnswer.ToString();
            }
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnPlus_Click(object sender, EventArgs e)
        {
            if (udvoitel == null) MessageBox.Show("Игра еще не началась", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                udvoitel.Plus();
                lblStep.Text = "Количество совершенных шагов " + udvoitel.Step.ToString();
                lbluserAnswer.Text = "Ваш ответ: " + udvoitel.UserAnswer.ToString();
                if (udvoitel.IsHit())
                {
                    udvoitel.NewGame();
                    lbluserAnswer.Text = "Ваш ответ: " + udvoitel.UserAnswer.ToString();
                    lblStep.Text = "Количество совершенных шагов " + udvoitel.Step.ToString();
                    lblanswer.Text = "Составьте число: " + udvoitel.Answer.ToString();
                    lblMin.Text = "Количество шагов для решения: " + udvoitel.StepMin.ToString();
                }
            }
        }

        private void BtnMulti_Click(object sender, EventArgs e)
        {
            if (udvoitel == null) MessageBox.Show("Игра еще не началась", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                udvoitel.Multi();
                lbluserAnswer.Text = "Ваш ответ: " + udvoitel.UserAnswer.ToString();
                lblStep.Text = "Количество совершенных шагов " + udvoitel.Step.ToString();
                if (udvoitel.IsHit())
                {
                    udvoitel.NewGame();
                    lbluserAnswer.Text = "Ваш ответ: " + udvoitel.UserAnswer.ToString();
                    lblStep.Text = "Количество совершенных шагов " + udvoitel.Step.ToString();
                    lblanswer.Text = "Составьте число: " + udvoitel.Answer.ToString();
                    lblMin.Text = "Количество шагов для решения: " + udvoitel.StepMin.ToString();
                }
            }
        }

            private void BtnReset_Click(object sender, EventArgs e)
        {
            if (udvoitel == null) MessageBox.Show("Игра еще не началась", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                udvoitel.Reset();
                lblStep.Text = "Количество совершенных шагов " + udvoitel.Step.ToString();
                lbluserAnswer.Text = "Ваш ответ: " + udvoitel.UserAnswer.ToString();
            }
        }

        private void BtnBack_Click(object sender, EventArgs e)
        {
            if (udvoitel == null) MessageBox.Show("Игра еще не началась", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                udvoitel.Back();
                lblStep.Text = "Количество совершенных шагов " + udvoitel.Step.ToString();
                lbluserAnswer.Text = "Ваш ответ: " + udvoitel.UserAnswer.ToString();
            }
        }

        private void AboutProgramToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string txt = "Игра <Удвоитель> v.1.0.\nВаша задача достигнуть загаданного числа за минимальное количество шагов\nЕсли не уложиться в заданное количество шагов - Вы проиграли\nЕсли превысить загаданное число - вы проиграли";
            MessageBox.Show("" + txt, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void OverGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (udvoitel == null) MessageBox.Show("Игра еще не началась", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else MessageBox.Show("Игра закончена\nКоличество набранных очков: " + udvoitel.AnswerCount, "Game over", MessageBoxButtons.OK, MessageBoxIcon.Information);
            udvoitel = null;
            lblanswer.Text = null;
            lbluserAnswer.Text = null;
            lblStep.Text = "Количество совершенных шагов: ";
            lblMin.Text = "Количество шагов для решения: ";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.MinimumSize = new Size(500, 200);
            this.MaximumSize = new Size(500, 250);
        }
    }
}
