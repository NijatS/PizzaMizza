using PizzaMizza.Core.Models;
using PizzaMizza.Core.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaMizza.Interfaces
{
    internal interface IPizza
    {
        public void Create(Pizza pizza);
        public void InfoPizza(int id);
        public void ShowAll();
        public void Remove(int id, Size size);
        public bool ListCheck();
    }
}
