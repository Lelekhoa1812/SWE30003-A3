using System;
using System.Collections.Generic;
using System.Linq;

namespace RIS
{
    public class Menu
    {
        // List menuItem
        private List<menuItem> menuItems;

        public Menu(List<menuItem> menuItems)
        {
            this.menuItems = menuItems;
        }

        // Show menu interface with the menuItem's name, description and prices (Also show type if user choose to show all)
        public void ShowMenu()
        {
            // Customer choosing betwwen showing menu by types, or display all
            Console.WriteLine("Relaxing Koala Restaurant Menu");
            Console.WriteLine("1. Entrees");
            Console.WriteLine("2. Main Dishes");
            Console.WriteLine("3. Desserts");
            Console.WriteLine("4. Drinks");
            Console.WriteLine("5. Browse all");
            int menuchoice = int.Parse(Console.ReadLine());

            // Switch upon customer request by Type / All
            switch (menuchoice)
            {
                case 1:
                    var typeChosen1 = menuItems.Where(m => m.Type == "Entree").ToList();
                    foreach (var menuItem in typeChosen1)
                    {
                        Console.WriteLine($"Name: {menuItem.Name}, Description: {menuItem.Desc}, Price: ${menuItem.Price}");
                    }
                    break;
                case 2:
                    var typeChosen2 = menuItems.Where(m => m.Type == "Main Dish").ToList();
                    foreach (var menuItem in typeChosen2)
                    {
                        Console.WriteLine($"Name: {menuItem.Name}, Description: {menuItem.Desc}, Price: ${menuItem.Price}");
                    }
                    break;
                case 3:
                    var typeChosen3 = menuItems.Where(m => m.Type == "Dessert").ToList();
                    foreach (var menuItem in typeChosen3)
                    {
                        Console.WriteLine($"Name: {menuItem.Name}, Description: {menuItem.Desc}, Price: ${menuItem.Price}");
                    }
                    break;
                case 4:
                    var typeChosen4 = menuItems.Where(m => m.Type == "Drink").ToList();
                    foreach (var menuItem in typeChosen4)
                    {
                        Console.WriteLine($"Name: {menuItem.Name}, Description: {menuItem.Desc}, Price: ${menuItem.Price}");
                    }
                    break;
                case 5:
                    foreach (var m in menuItems)
                    {
                        Console.WriteLine($"Name: {m.Name}, Type: {m.Type}, Description: {m.Desc}, Price: ${m.Price}");
                    }
                    break;
                default:
                    Console.WriteLine("Invalid menu option");
                    break;
            }
        }
    }
}