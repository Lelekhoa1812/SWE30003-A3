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

        public void ShowMenu(int menuchoice)
        {
            // Switch upon customer request by Type / All
            switch(menuchoice)
            {
                case 1:
                    var typeChosen1 = menuItems.Where(m => m.Type == "Entree").ToList();
                    foreach (var menuItem in typeChosen1)
                    {
                        Console.WriteLine($"Name: {menuItem.Name}, Description: {menuItem.Desc}, Price: {menuItem.Price}");
                    }
                    break;
                case 2:
                    var typeChosen2 = menuItems.Where(m => m.Type == "Main Dish").ToList();
                    foreach (var menuItem in typeChosen2)
                    {
                        Console.WriteLine($"Name: {menuItem.Name}, Description: {menuItem.Desc}, Price: {menuItem.Price}");
                    }
                    break;
                case 3:
                    var typeChosen3 = menuItems.Where(m => m.Type == "Dessert").ToList();
                    foreach (var menuItem in typeChosen3)
                    {
                        Console.WriteLine($"Name: {menuItem.Name}, Description: {menuItem.Desc}, Price: {menuItem.Price}");
                    }
                    break;
                case 4:
                    var typeChosen4 = menuItems.Where(m => m.Type == "Drink").ToList();
                    foreach (var menuItem in typeChosen4)
                    {
                        Console.WriteLine($"Name: {menuItem.Name}, Description: {menuItem.Desc}, Price: {menuItem.Price}");
                    }
                    break;
                case 5:
                    foreach (var m in menuItems)
                    {
                        Console.WriteLine($"Name: {m.Name}, Type: {m.Type}, Description: {m.Desc}, Price: {m.Price}");
                    }
                    break;
                default:
                    Console.WriteLine("Invalid menu option");
                    break;
            }
        }
    }
}