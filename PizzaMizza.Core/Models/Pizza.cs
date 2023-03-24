using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaMizza.Core.Models.Base
{
    public class Pizza
    {
        public int Id;
        public string Name;
        public double Price;
        public string Ingredients;
        public Size Size;
        public override string ToString()
        {
            return "ID :" + Id + "  Name : " + Name + "  Price : " + Price + "  Size : " + Size;
        }
    }
}
