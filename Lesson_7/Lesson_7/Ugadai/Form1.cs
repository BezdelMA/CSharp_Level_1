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
//Ввод данных в TextBox возможет только после начала игры
//Ведется подсчет очков

namespace Ugadai
{
    public partial class Form1 : Form
    {
        Ugadai ugadai;
        public Form1()
        {
            InitializeComponent();
        }

        private void NewGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ugadai != null)
            {
                DialogResult dialog = new DialogResult();
                dialog = MessageBox.Show("Вы не закончили предыдущую игру\n\nВы уверены, что хотите начать новую?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (dialog == DialogResult.Yes)
                {
                    ugadai = new Ugadai(new Random().Next(1, 101));
                }
            }
            else
            {
                ugadai = new Ugadai(new Random().Next(1, 100));
            }
            tbUserAnswer.ReadOnly = false;
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtCheck_Click(object sender, EventArgs e)
        {
            if (ugadai == null) MessageBox.Show("Игра еще не началась", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
             
            else
            {
                if (Ugadai.CheckAnswer(tbUserAnswer.Text))
                {
                    ugadai.UserAnswer = Convert.ToInt32(tbUserAnswer.Text);
                    int temp = ugadai.Check();
                    if (temp == 1) lblAnswer.Text = "Загаданное число МЕНЬШЕ";
                    else if (temp == 2) lblAnswer.Text = "Загаданное число БОЛЬШЕ";
                    else if (temp == 0)
                    {
                        MessageBox.Show("Поздравляю!\nВы победили!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ugadai.NewGame();
                        tbUserAnswer.Clear();
                        lblAnswer.Text = "Отношение ответа к загаданному числу";
                    }
                    else if (temp == 3)
                    {
                        tbUserAnswer.Clear();
                        lblMaxStep.Text = "Количество оставшихся попыток: " + ugadai.MaxStep;
                        MessageBox.Show("Вы исчерпали максимальное количество попыток...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        ugadai.NewGame();
                    }
                    lblMaxStep.Text = "Количество оставшихся попыток: " + ugadai.MaxStep;
                }
                else MessageBox.Show("Введите число в диапазоне от 1 до 100", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void AboutProgramToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string txt = "Игра <Угадай число> v.1.0.\nКомпьютер загадывает случайное число от 1 до 100\nЗадача игрока угадать его за 10 попыток";
            MessageBox.Show("" + txt, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void закончитьИгруToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ugadai == null) MessageBox.Show("Игра еще не началась", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else MessageBox.Show("Игра закончена\nПравильно отгаданных чисел: " + ugadai.AnswerCount, "Game Over", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ugadai = null;
            tbUserAnswer.Clear();
            lblAnswer.Text = "Отношение ответа к загаданному числу";
            lblMaxStep.Text = "Количество оставшихся попыток: ";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.MinimumSize = new Size(300, 175);
            this.MaximumSize = new Size(300, 175);
        }
    }
}
