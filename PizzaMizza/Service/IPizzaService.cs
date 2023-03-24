using PizzaMizza.Core.Models;
using PizzaMizza.Core.Models.Base;
using PizzaMizza.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace PizzaMizza.Service
{
    internal class IPizzaService : IPizza
    {
        List<Pizza> pizzas = new List<Pizza>();
        int count = 0;
        public void Create(Pizza pizza)
        {
            count++;
            pizza.Id = count;
            foreach (Pizza p in pizzas)
            {
                if (pizza.Name == p.Name)
                {
                    pizza.Id = p.Id;
                    pizza.Ingredients = p.Ingredients;
                    count--;
                    break;
                }
            }
            if (pizza.Ingredients == null)
            {
                Console.Write("Ingredients : ");
                pizza.Ingredients = Console.ReadLine();
            }
            pizzas.Add(pizza);
        }
        public void InfoPizza(int id)
        {
            foreach (Pizza pizza in pizzas)
            {
                if (id == pizza.Id)
                {
                    Console.WriteLine("Igredients : " + pizza.Ingredients);
                    break;
                }
            }
            foreach (Pizza pizza in pizzas)
            {
                if (id == pizza.Id)
                {
                    Console.WriteLine("Size : " + pizza.Size + "  Price : " + pizza.Price);
                }
            }
        }
        public bool ListCheck()
        {
            if (pizzas.Count == 0)
            {
                return false;
            }
            return true;
        }
        public void Remove(int id, Size size)
        {
            foreach (Pizza pizza in pizzas)
            {
                if(id == pizza.Id && size == pizza.Size)
                {
                    pizzas.Remove(pizza);
                    return;
                }
            }
            Console.WriteLine("Not Finding...");
        }
        public void ShowAll()
        {
            if (!ListCheck())
            {
                Console.WriteLine("Please add any Pizzas");
            }
            else
            {
                foreach (Pizza pizza in pizzas)
                {
                    Console.WriteLine(pizza);
                }
            }
        }
    }
}
