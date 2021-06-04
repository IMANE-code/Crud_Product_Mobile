using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace PRODUIT
{
    public class Produit
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public int quantity { get; set; }
        //public string Image { get; set; }
    }
}
