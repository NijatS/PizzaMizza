using PizzaMizza.Core.Models;
using PizzaMizza.Core.Models.Base;
using PizzaMizza.Service;
using System.Threading.Channels;
internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Welcome to PizzaMizza");
        bool status = true;
        IPizzaService service = new IPizzaService();

        while (status)
        {
            Console.WriteLine("1.Show All Pizzas\n" +
                "2.Add Pizza\n" +
                "3.Remove\n" +
                "4.Clear Console\n" +
                "q Quit");
            Console.Write("Enter Step : ");
            string step = Console.ReadLine();
            switch (step)
            {
                case "1":
                    service.ShowAll();
                    if (service.ListCheck())
                    {
                        Console.Write("Pizza haqqinda etraflı melumat almaq" +
                         " isteyirsizse pizzanin İd -sini ,istemirsizse 0 daxil edin : ");
                        int id = int.Parse(Console.ReadLine());
                        if (id != 0)
                        {
                            Console.Clear();
                            service.InfoPizza(id);
                        }
                    }
                    break;
                case "2":
                    Pizza pizza = new Pizza();
                    Console.Write("Pizza Name : ");
                    pizza.Name = Console.ReadLine();
                    userSize:
                    Console.Write("Pizza Sizes :");
                    foreach (string item in Enum.GetNames(typeof(Size)))
                    {
                        Console.Write(item + ",");
                    }
                    Console.Write("\nSelect of them : ");
                    string userSize = Console.ReadLine();
                    try
                    {
                        pizza.Size = (Size)Enum.Parse(typeof(Size), userSize);
                    }
                    catch {
                        Console.WriteLine("Enter correct Size...");
                        goto userSize;
                    }                  
                    Console.Write("Price : ");
                    pizza.Price = double.Parse(Console.ReadLine());
                    service.Create(pizza);
                    break;
                case "3":
                    if (service.ListCheck())
                    {
                        Console.Write("ID :");
                        int id = int.Parse(Console.ReadLine());
                        Console.Write("Size : ");
                        string sizeRemove = Console.ReadLine();
                        Size size = (Size)Enum.Parse(typeof(Size), sizeRemove);
                        service.Remove(id, size);
                    }
                    else { Console.WriteLine("Please add any Pizzas"); }
                    break;
                case "4":
                    Console.Clear();
                    break;
                case "q":
                    status = false;
                    break;
                default:
                    break;
            }
        }
    }
}