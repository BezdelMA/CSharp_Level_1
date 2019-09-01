using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TrueFalse
{
    public partial class Password : Form
    {
        public Password()
        {
            InitializeComponent();
        }

        private void Password_Load(object sender, EventArgs e)
        {
            
        }

        //Обработка нажатия кнопки <Авторизация> (по сути проверка логина и пароля), при желании можно создать и БД логинов-паролей
        private void BtAdmin_Click(object sender, EventArgs e)
        {
            if (tbLogin.Text == "admin" & tbPassword.Text == "admin")
            {
                MessageBox.Show("Авторизация пройдена успешно", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                MessageBox.Show("Авторизация не пройдена", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                DialogResult = DialogResult.Cancel;
            }
        }
    }
}
