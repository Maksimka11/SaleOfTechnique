using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaleOfTechnique
{
    /// <summary>
    /// описание сделки
    /// </summary>
    public class Transaction
    {
        //Идентификатор
        public int trId { get; set; }
        //Идентификатор клиента
        public int trClient { get; set; }
        //Идентификатор техники
        public int trTechnique { get; set; }
        //Количество
        public int trCount { get; set; }
        //Дата сделки
        public DateTime trDate { get; set; }
    }
}
