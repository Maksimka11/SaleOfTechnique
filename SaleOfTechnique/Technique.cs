using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaleOfTechnique
{
    /// <summary>
    /// описание техники
    /// </summary>
    public class Technique
    {
        // Идентификатор
        public int tId { get; set; }
        //Название
        public string tName { get; set; }
        //Стоимость
        public int tPrice { get; set; }
        //Вес
        public float tWeight { get; set; }
    }
}
