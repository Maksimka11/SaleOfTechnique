using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Deployment.Internal;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SaleOfTechnique
{
    /// <summary>
    /// главная форма приложения
    /// </summary>
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            //загружаем данные по клиентам
            LoadСlient();
            //загружаем данные по технике
            LoadTechnique();
            //загружаем данные по сделкам
            LoadTransaction();
        }
        /// <summary>
        /// загрузка клиентов
        /// </summary>
        private void LoadСlient()
        {
            //пишем SQL по отбору данных по клиентам, сортируем по фамилии
            var sql = @"select * from Client order by cSurname ";
            var da = new OleDbDataAdapter(sql, Db.Connection);
            var ds = new DataSet();
            da.Fill(ds);
            //свзяываем отобанные данные с компонентом datagridview
            dgvClient.DataSource = ds;
            dgvClient.DataMember = ds.Tables[0].TableName;
            //не показываем столбец с ИД
            dgvClient.Columns["cId"].Visible = false;
            //устанавливаем заголовок столбца
            dgvClient.Columns["cName"].HeaderText = @"Имя";
            //устанавдиваем ширину столбца
            dgvClient.Columns["cName"].Width = 200;
            dgvClient.Columns["cSurname"].HeaderText = @"Фамилия";
            dgvClient.Columns["cSurname"].Width = 200;
            dgvClient.Columns["cPatronimyc"].HeaderText = @"Отчество";
            dgvClient.Columns["cPatronimyc"].Width = 200;
            dgvClient.Columns["cAddress"].HeaderText = @"Адрес проживания";
            dgvClient.Columns["cAddress"].Width = 150;
            dgvClient.Columns["cPhone"].HeaderText = @"Контактный телефон";
            dgvClient.Columns["cPhone"].Width = 150;
            dgvClient.Columns["cEmail"].HeaderText = @"Электронная почта";
            dgvClient.Columns["cEmail"].Width = 150;
        }

        /// <summary>
        /// загрузка техники
        /// </summary>
        private void LoadTechnique()
        {
            //пишем SQL по отбору данных по технике, сортируем по названию
            var sql = @"select * from Technique order by tName ";
            var da = new OleDbDataAdapter(sql, Db.Connection);
            var ds = new DataSet();
            da.Fill(ds);
            //свзяываем отобанные данные с компонентом datagridview
            dgvTechnique.DataSource = ds;
            dgvTechnique.DataMember = ds.Tables[0].TableName;
            //не показываем столбец с ИД
            dgvTechnique.Columns["tId"].Visible = false;
            //устанавливаем заголовок столбца
            dgvTechnique.Columns["tName"].HeaderText = @"Название";
            //устанавдиваем ширину столбца
            dgvTechnique.Columns["tName"].Width = 200;
            dgvTechnique.Columns["tPrice"].HeaderText = @"Цена";
            dgvTechnique.Columns["tPrice"].Width = 200;
            dgvTechnique.Columns["tWeight"].HeaderText = @"Вес";
            dgvTechnique.Columns["tWeight"].Width = 200;
        }
        /// <summary>
        /// загрузка сделок
        /// </summary>
        private void LoadTransaction()
        {
            //пишем SQL по отбору данных по сделкам, сортируем по дате
            var sql = @"select [cId],[tId], [trId], [trClient], [trTechnique], [trCount], [trDate] from [Client], [Technique], [Transaction] where trClient=cId and trTechnique=tId order by trDate desc";
            var da = new OleDbDataAdapter(sql, Db.Connection);
            var ds = new DataSet();
            da.Fill(ds);
            //свзяываем отобанные данные с компонентом datagridview
            dgvTransaction.DataSource = ds;
            dgvTransaction.DataMember = ds.Tables[0].TableName;
            //не показываем столбец с ИД
            dgvTransaction.Columns["trId"].Visible = false;
            dgvTransaction.Columns["tId"].Visible = false;
            dgvTransaction.Columns["cId"].Visible = false;
            //устанавливаем заголовок столбца
            dgvTransaction.Columns["trClient"].HeaderText = @"Клиент";
            //устанавдиваем ширину столбца
            dgvTransaction.Columns["trClient"].Width = 200;
            dgvTransaction.Columns["trTechnique"].HeaderText = @"Техника";
            dgvTransaction.Columns["trTechnique"].Width = 200;
            dgvTransaction.Columns["trCount"].HeaderText = @"Количество";
            dgvTransaction.Columns["trCount"].Width = 200;
            dgvTransaction.Columns["trDate"].HeaderText = @"Дата сделки";
            dgvTransaction.Columns["trDate"].Width = 200;
        }

        /// <summary>
        /// добавление сделок
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnTr1_Click(object sender, EventArgs e)
        {
            //создаем форму редактирования
            var f = new FmTransaction();
            //показываем диалог с редактированием 
            if (f.ShowDialog() == DialogResult.OK)
            {
                //если нажали кнопку ОК пишем SQL по добавлению данных о сделке
                var cmd = new OleDbCommand(@"insert into [Transaction] (trClient, trTechnique, trCount, trDate) values (?,?,?,?)")
                {
                    Connection = Db.Connection,
                    CommandType = CommandType.Text
                };
                //запоняем параметры для добавления данных
                cmd.Parameters.AddWithValue(@"trClient", f.Transaction.trClient);
                cmd.Parameters.AddWithValue(@"trTechnique", f.Transaction.trTechnique);
                cmd.Parameters.AddWithValue(@"trCount", f.Transaction.trCount);
                cmd.Parameters.AddWithValue(@"trDate", f.Transaction.trDate);
                //выполняем запрос по добавлению
                cmd.ExecuteNonQuery();
                //обновляем данные в datagridview
                LoadTransaction();
            }

        }

        /// <summary>
        /// редактирование сделки
        /// </summary>
        private void btnTr2_Click(object sender, EventArgs e)
        {
            //если нет выделенной ячейки, то выходим
            if (dgvTransaction.CurrentCell == null) return;
            //индекс выделенной ячейки
            var i = dgvTransaction.CurrentCell.RowIndex;
            //создаем форму редактирования
            var f = new FmTransaction();
            //заплняем объект класса Transaction данными из datagridview
            f.Transaction.trId = (int)dgvTransaction.Rows[i].Cells["trId"].Value;
            f.Transaction.trClient = (int)dgvTransaction.Rows[i].Cells["cId"].Value;
            f.Transaction.trTechnique = (int)dgvTransaction.Rows[i].Cells["tId"].Value;
            f.Transaction.trDate = Convert.ToDateTime(dgvTransaction.Rows[i].Cells["trDate"].Value);
            f.Transaction.trCount = Convert.ToInt32(dgvTransaction.Rows[i].Cells["trCount"].Value);
            //показываем диалог с редактированием 
            if (f.ShowDialog() == DialogResult.OK)
            {
                //если нажали кнопку ОК пишем SQL по изменению данных о сделке
                var cmd = new OleDbCommand(@"update [Transaction] set trClient=?, trTechnique=?, trCount=?, trDate=? where trId=?")
                {
                    Connection = Db.Connection,
                    CommandType = CommandType.Text
                };
                //запоняем параметры для изменения данных
                cmd.Parameters.AddWithValue(@"trClient", f.Transaction.trClient);
                cmd.Parameters.AddWithValue(@"trTechnique", f.Transaction.trTechnique);
                cmd.Parameters.AddWithValue(@"trCount", f.Transaction.trCount);
                cmd.Parameters.AddWithValue(@"trDate", f.Transaction.trDate);
                cmd.Parameters.AddWithValue(@"trId", f.Transaction.trId);
                //выполняем запрос по изменению
                cmd.ExecuteNonQuery();
                //обновляем данные в datagridview
                LoadTransaction();
            }

        }

        /// <summary>
        /// удаление сделки
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnTr3_Click(object sender, EventArgs e)
        {
            //если нет выделенной ячейки, то выходим
            if (dgvTransaction.CurrentCell == null) return;
            //диалог подтверждения удаления
            if (MessageBox.Show(@"Удалить?", @"Удалить", MessageBoxButtons.YesNo) != DialogResult.Yes)
                return;
            //индекс выделенной ячейки
            var i = dgvTransaction.CurrentCell.RowIndex;
            //идентификатор записи
            var id = dgvTransaction.Rows[i].Cells["trId"].Value;
            //sql по удалению сделки
            var cmd = new OleDbCommand(@"delete from [Transaction] where trId=?")
            {
                Connection = Db.Connection,
                CommandType = CommandType.Text
            };
            //запоняем параметры для удаления данных
            cmd.Parameters.AddWithValue(@"trId", id);
            //выполняем запрос по удалению
            cmd.ExecuteNonQuery();
            //обновляем данные в datagridview
            LoadTransaction();

        }

        /// <summary>
        /// добавление клиента
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCl1_Click(object sender, EventArgs e)
        {
            //создаем форму редактирования
            var f = new FmClient();
            //показываем диалог с редактированием 
            if (f.ShowDialog() == DialogResult.OK)
            {
                //если нажали кнопку ОК пишем SQL по добавлению данных о клиенте
                var cmd = new OleDbCommand(@"insert into Client (cName, cSurname, cPatronimyc, cAddress, cPhone, cEmail) values (?,?,?,?,?,?)")
                {
                    Connection = Db.Connection,
                    CommandType = CommandType.Text
                };
                //запоняем параметры для добавления данных
                cmd.Parameters.AddWithValue(@"cName", f.Client.cName);
                cmd.Parameters.AddWithValue(@"cSurname", f.Client.cSurname);
                cmd.Parameters.AddWithValue(@"cPatronimyc", f.Client.cPatronymic);
                cmd.Parameters.AddWithValue(@"cAddress", f.Client.cAddress);
                cmd.Parameters.AddWithValue(@"cPhone", f.Client.cPhone);
                cmd.Parameters.AddWithValue(@"cEmail", f.Client.cEmail);
                //выполняем запрос по добавлению
                cmd.ExecuteNonQuery();
                //обновляем данные в datagridview
                LoadСlient();
            }

        }

        /// <summary>
        /// редватирование клиента
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCl2_Click(object sender, EventArgs e)
        {
            
            //если нет выделенной ячейки, то выходим
            if (dgvClient.CurrentCell == null) return;
            //индекс выделенной ячейки
            var i = dgvClient.CurrentCell.RowIndex;
            //создаем форму редактирования
            var f = new FmClient();
            //заплняем объект класса Client данными из datagridview
            f.Client.cId = (int)dgvClient.Rows[i].Cells["cId"].Value;
            f.Client.cName = Convert.ToString(dgvClient.Rows[i].Cells["cName"].Value);
            f.Client.cSurname = Convert.ToString(dgvClient.Rows[i].Cells["cSurname"].Value);
            f.Client.cPatronymic = Convert.ToString(dgvClient.Rows[i].Cells["cPatronimyc"].Value);
            f.Client.cAddress = Convert.ToString(dgvClient.Rows[i].Cells["cAddress"].Value);
            f.Client.cPhone = Convert.ToDouble(dgvClient.Rows[i].Cells["cPhone"].Value);
            f.Client.cEmail = Convert.ToString(dgvClient.Rows[i].Cells["cEmail"].Value);
            //показываем диалог с редактированием
            if (f.ShowDialog() == DialogResult.OK)
            {
                //если нажали кнопку ОК пишем SQL по изменению данных о клиенте
                var cmd = new OleDbCommand(@"update client set =?, cSurname=?, cPatronimyc=?, cAddress=?, cPhone=?, cEmail=? where cId=?")
                {
                    Connection = Db.Connection,
                    CommandType = CommandType.Text
                };
                //запоняем параметры для изменения данных
                cmd.Parameters.AddWithValue(@"cName", Convert.ToString(dgvClient.Rows[i].Cells["cName"].Value));
                cmd.Parameters.AddWithValue(@"cSurname", f.Client.cSurname);
                cmd.Parameters.AddWithValue(@"cPatronimyc", f.Client.cPatronymic);
                cmd.Parameters.AddWithValue(@"cAddress", f.Client.cAddress);
                cmd.Parameters.AddWithValue(@"cPhone", f.Client.cPhone);
                cmd.Parameters.AddWithValue(@"cEmail", f.Client.cEmail);
                cmd.Parameters.AddWithValue(@"cId", f.Client.cId);
                //выполняем запрос по изменению
                cmd.ExecuteNonQuery();
                //обновляем данные в datagridview
                LoadСlient();
                
            }            

        }

        /// <summary>
        /// удаление клиента
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCl3_Click(object sender, EventArgs e)
        {
            //если нет выделенной ячейки, то выходим
            if (dgvClient.CurrentCell == null) return;
            //диалог подтверждения удаления
            if (MessageBox.Show(@"Удалить?", @"Удалить", MessageBoxButtons.YesNo) != DialogResult.Yes)
                return;
            //индекс выделенной ячейки
            var i = dgvClient.CurrentCell.RowIndex;
            //идентификатор записи
            var id = dgvClient.Rows[i].Cells["cId"].Value;
            //sql по удалению клиента
            var cmd = new OleDbCommand(@"delete from Client where cId=?")
            {
                Connection = Db.Connection,
                CommandType = CommandType.Text
            };
            //запоняем параметры для удаления данных
            cmd.Parameters.AddWithValue(@"cId", id);
            //выполняем запрос по удалению
            cmd.ExecuteNonQuery();
            //обновляем данные в datagridview
            LoadСlient();

        }
        /// <summary>
        /// добавление техники
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnTech1_Click(object sender, EventArgs e)
        {
            //создаем форму редактирования
            var f = new FmTechnique();
            //показываем диалог с редактированием 
            if (f.ShowDialog() == DialogResult.OK)
            {
                //если нажали кнопку ОК пишем SQL по добавлению данных о техники
                var cmd = new OleDbCommand(@"insert into Technique (tName, tPrice,tWeight) values (?,?,?)")
                {
                    Connection = Db.Connection,
                    CommandType = CommandType.Text
                };
                //запоняем параметры для добавления данных
                cmd.Parameters.AddWithValue(@"tName", f.Technique.tName);
                cmd.Parameters.AddWithValue(@"tPrice", f.Technique.tPrice);
                cmd.Parameters.AddWithValue(@"tWeight", f.Technique.tWeight);
                //выполняем запрос по добавлению
                cmd.ExecuteNonQuery();
                //обновляем данные в datagridview
                LoadTechnique();
            }

        }

        /// <summary>
        /// редватирование техники
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnTech2_Click(object sender, EventArgs e)
        {
            //если нет выделенной ячейки, то выходим
            if (dgvTechnique.CurrentCell == null) return;
            //индекс выделенной ячейки
            var i = dgvTechnique.CurrentCell.RowIndex;
            //создаем форму редактирования
            var f = new FmTechnique();
            //заплняем объект класса Technique данными из datagridview
            f.Technique.tId = (int)dgvTechnique.Rows[i].Cells["tId"].Value;
            f.Technique.tName = Convert.ToString(dgvTechnique.Rows[i].Cells["tName"].Value);
            f.Technique.tPrice = Convert.ToInt32(dgvTechnique.Rows[i].Cells["tPrice"].Value);
            f.Technique.tWeight = Convert.ToInt32(dgvTechnique.Rows[i].Cells["tWeight"].Value);
            //показываем диалог с редактированием 
            if (f.ShowDialog() == DialogResult.OK)
            {
                //если нажали кнопку ОК пишем SQL по изменению данных о технике
                var cmd = new OleDbCommand(@"update Technique set tName=?, tPrice=?, tWeight=? where tId=?")
                {
                    Connection = Db.Connection,
                    CommandType = CommandType.Text
                };
                //запоняем параметры для изменения данных
                cmd.Parameters.AddWithValue(@"tName", f.Technique.tName);
                cmd.Parameters.AddWithValue(@"tPrice", f.Technique.tPrice);
                cmd.Parameters.AddWithValue(@"tWeight", f.Technique.tWeight);
                cmd.Parameters.AddWithValue(@"tId", f.Technique.tId);
                //выполняем запрос по изменению
                cmd.ExecuteNonQuery();
                //обновляем данные в datagridview
                LoadTechnique();
            }

        }

        /// <summary>
        /// удаление техники
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnTech3_Click(object sender, EventArgs e)
        {
            //если нет выделенной ячейки, то выходим
            if (dgvTechnique.CurrentCell == null) return;
            //диалог подтверждения удаления
            if (MessageBox.Show(@"Удалить?", @"Удалить", MessageBoxButtons.YesNo) != DialogResult.Yes)
                return;
            //индекс выделенной ячейки
            var i = dgvTechnique.CurrentCell.RowIndex;
            //идентификатор записи
            var id = dgvTechnique.Rows[i].Cells["tId"].Value;
            //sql по удалению техники
            var cmd = new OleDbCommand(@"delete from Technique where tId=?")
            {
                Connection = Db.Connection,
                CommandType = CommandType.Text
            };
            //запоняем параметры для удаления данных
            cmd.Parameters.AddWithValue(@"tId", id);
            //выполняем запрос по удалению
            cmd.ExecuteNonQuery();
            //обновляем данные в datagridview
            LoadTechnique();
        }
        
        private void dgvClient_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //btnCl2_Click(sender, e);

        }

        private void dgvTechnique_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //btnTech2_Click(sender, e);
        }

        private void dgvTransaction_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //btnTr2_Click(sender, e);
        }
    }
}
