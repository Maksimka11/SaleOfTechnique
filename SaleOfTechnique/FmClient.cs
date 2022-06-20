using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SaleOfTechnique
{
    public partial class FmClient : Form
    {
        /// <summary>
        /// форма ввода  и редактирования клиента
        /// </summary>
        public FmClient()
        {
            InitializeComponent();
        }

        public Client Client = new Client();
        private void FmClient_Load(object sender, EventArgs e)
        {
            //устанавливаем значения компонентов при редактировании
            tbName.Text = Client.cName;
            tbSurname.Text = Client.cSurname;
            tbPatronymic.Text = Client.cPatronymic;
            tbAddress.Text = Client.cAddress;
            tbPhone.Text = Client.cPhone.ToString();
            tbEmail.Text = Client.cEmail;

        }

        /// <summary>
        /// обработка кнопки ОК
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOK_Click(object sender, EventArgs e)
        {
            //проверяем на заполненность имени 
            if (string.IsNullOrEmpty(tbName.Text))
            {
                //сообщение
                MessageBox.Show(@"Введите имя!");
                //устанавливаем фокус
                tbName.Focus();
                //не закрываем форму
                DialogResult = DialogResult.None;
                return;
            }
            //проверяем на заполненность фамилии 
            if (string.IsNullOrEmpty(tbSurname.Text))
            {
                MessageBox.Show(@"Введите фамилию!");
                tbSurname.Focus();
                DialogResult = DialogResult.None;
                return;
            }
            //проверяем на заполненность отчества 
            if (string.IsNullOrEmpty(tbPatronymic.Text))
            {
                MessageBox.Show(@"Введите отчество!");
                tbPatronymic.Focus();
                DialogResult = DialogResult.None;
                return;
            }

            //проверяем на заполненность адреса 
            if (string.IsNullOrEmpty(tbAddress.Text))
            {
                MessageBox.Show(@"Введите адрес проживания!");
                tbAddress.Focus();
                DialogResult = DialogResult.None;
                return;
            }

            //проверяем правильность ввода телефона 
            double f = 0;
            if (!Double.TryParse(tbPhone.Text, out f))
            {
                MessageBox.Show(@"Неправильно введено значение!");
                tbPhone.Focus();
                DialogResult = DialogResult.None;
                return;
            }
            //присваиваем данные из компонентов объекту классса Client
            Client.cName = tbName.Text;
            Client.cSurname = tbSurname.Text;
            Client.cPatronymic = tbPatronymic.Text;
            Client.cAddress = tbAddress.Text;
            Client.cPhone = Convert.ToDouble(tbPhone.Text);
            Client.cEmail = tbEmail.Text;


        }
    }
}
