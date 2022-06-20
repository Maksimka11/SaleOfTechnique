using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace SaleOfTechnique
{
    /// <summary>
    /// форма ввода и редактирования сделки
    /// </summary>
    public partial class FmTransaction : Form
    {
        public FmTransaction()
        {
            InitializeComponent();
            //заполняем комбобокс клиента
            LoadClient();
            //заполняем комбобокс техники
            LoadTechnique();
            //по-умолчанию дата записи - сегодняшнее число
            Transaction.trDate = DateTime.Today; 
        }
        //объект класса Transaction
        public Transaction Transaction = new Transaction();

        /// <summary>
        /// метод загрузки комбобокса с клиентами
        /// </summary>
        private void LoadClient()
        {
            //пишем SQL по отбору данных по клиентам, сортируем по фамилии
            var sql = @"select * from Client order by cSurname";
            var da = new OleDbDataAdapter(sql, Db.Connection);
            var ds = new DataSet();
            da.Fill(ds);
            //свзяываем отобанные данные с компонентом комбобокс
            cbClient.DataSource = ds.Tables[0];
            cbClient.DisplayMember = "csurname";
            cbClient.ValueMember = "cId";
        }

        /// <summary>
        /// метод загрузки комбобокса с техникой
        /// </summary>
        private void LoadTechnique()
        {
            //пишем SQL по отбору данных по технике, сортируем по названию
            var sql = @"select * from Technique order by tName";
            var da = new OleDbDataAdapter(sql, Db.Connection);
            var ds = new DataSet();
            da.Fill(ds);
            //свзяываем отобанные данные с компонентом комбобокс
            cbTechnique.DataSource = ds.Tables[0];
            cbTechnique.DisplayMember = "tName";
            cbTechnique.ValueMember = "tId";
        }


        private void FmTransaction_Load(object sender, EventArgs e)
        {
            //устанавливаем значения компонентов при редактировании
            cbClient.SelectedValue = Transaction.trClient;
            cbTechnique.SelectedValue = Transaction.trTechnique;
            dtpDate.Value = Transaction.trDate;
            tbCount.Text = Transaction.trCount.ToString();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            //проверяем выбор клиента
            if (cbClient.SelectedIndex < 0)
            {
                //сообщение
                MessageBox.Show(@"Выберите клиента!");
                //устанавливаем фокус
                cbClient.Focus();
                //не закрываем форму
                DialogResult = DialogResult.None;
                return;
            }
            //проверяем выбор техники
            if (cbTechnique.SelectedIndex < 0)
            {
                MessageBox.Show(@"Выберите технику!");
                cbTechnique.Focus();
                DialogResult = DialogResult.None;
                return;
            }

            int d = 0;
            if (!Int32.TryParse(tbCount.Text, out d))
            {
                MessageBox.Show(@"Неправильно введено значение!");
                tbCount.Focus();
                DialogResult = DialogResult.None;
                return;
            }
            //присваиваем данные из компонентов объекту классса Transaction
            Transaction.trClient = (int)cbClient.SelectedValue;
            Transaction.trTechnique = (int)cbTechnique.SelectedValue;
            Transaction.trDate = dtpDate.Value;
            Transaction.trCount = Convert.ToInt32(tbCount.Text);
        }
    }
}
