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
    public partial class FmTechnique : Form
    {
        /// <summary>
        /// форма ввода  и редактирования техники
        /// </summary>
        public FmTechnique()
        {
            InitializeComponent();
        }
        //объект класса Technique
        public Technique Technique = new Technique();

        private void FmTechnique_Load(object sender, EventArgs e)
        {
            //устанавливаем значения компонентов при редактировании
            tbName.Text = Technique.tName;
            tbPrice.Text = Technique.tPrice.ToString();
            tbWeight.Text = Technique.tWeight.ToString();
        }


        /// <summary>
        /// обработка кнопки ОК
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOK_Click(object sender, EventArgs e)
        {
            //проверяем на заполненность названия 
            if (string.IsNullOrEmpty(tbName.Text))
            {
                //сообщение
                MessageBox.Show(@"Введите название!");
                //устанавливаем фокус
                tbName.Focus();
                //не закрываем форму
                DialogResult = DialogResult.None;
                return;
            }

            //проверяем правильность ввода стоимости 
            int f = 0;
            if (!Int32.TryParse(tbPrice.Text, out f))
            {
                MessageBox.Show(@"Неправильно введено значение!");
                tbPrice.Focus();
                DialogResult = DialogResult.None;
                return;
            }

            //проверяем правильность ввода веса 
            float d = 0;
            if (!Single.TryParse(tbWeight.Text, out d))
            {
                MessageBox.Show(@"Неправильно введено значение!");
                tbWeight.Focus();
                DialogResult = DialogResult.None;
                return;
            }

            //присваиваем данные из компонентов объекту классса Technique
            Technique.tName = tbName.Text;
            Technique.tPrice = Convert.ToInt32(tbPrice.Text);
            Technique.tWeight = Convert.ToSingle(tbWeight.Text);
        }
    }
}
