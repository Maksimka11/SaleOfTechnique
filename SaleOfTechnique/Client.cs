using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaleOfTechnique
{
    /// <summary>
    /// описание клиента
    /// </summary>
    public class Client
    {
        //Идентификатор
        public int cId { get; set; }
        //Имя
        public string cName { get; set; }
        //Фамилия
        public string cSurname { get; set; }
        //Отчество
        public string cPatronymic { get; set; }
        //Адрес проживания
        public string cAddress { get; set; }
        //Контактный телефон
        public double cPhone { get; set; }
        //Адрес электронной почты
        public string cEmail { get; set; }
    }
}
