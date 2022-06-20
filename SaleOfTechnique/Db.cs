using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Configuration;
using System.Windows.Forms;

namespace SaleOfTechnique
{
    /// <summary>
    /// класс для создания коннекции к БД
    /// </summary>
    public static class Db
    {
        //коннекция к БД
        public static OleDbConnection Connection = new OleDbConnection();
        /// <summary>
        /// процедура соеднинения с БД
        /// </summary>
        /// <returns></returns>
        public static bool Connect()
        {
            //читаем строку коннекции к БД из файла конфиг
            var connectionString = ConfigurationManager.AppSettings["db"];
            try
            {
                //присваиваем строку коннекции
                Connection.ConnectionString = connectionString;
                //открываем соединение с БД
                Connection.Open();
                return true;
            }
            catch (Exception e)
            {
                //обработка ошибки при коннекции к БД. вызываем сообщение с ошибкой
                MessageBox.Show(@"Ошибка соединения с БД. " + e.Message, @"Ошибка",
               MessageBoxButtons.OK,
                MessageBoxIcon.Error);
                return false;
            }
        }
    }
}
