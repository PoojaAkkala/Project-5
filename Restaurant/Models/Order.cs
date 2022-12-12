using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Models;

using SQLite;



public class Order
{
    [PrimaryKey, AutoIncrement]
    public int ID { get; set; }
    public string Calc { get; set; }
   
}
