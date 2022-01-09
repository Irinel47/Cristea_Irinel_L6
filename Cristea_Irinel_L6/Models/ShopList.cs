using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace Cristea_Irinel_L6.Models
{
    public class ShopList
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
    }
}
