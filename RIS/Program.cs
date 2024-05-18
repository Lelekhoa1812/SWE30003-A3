using System;
using System.Collections.Generic;
namespace RIS
{
    class Program
    {
        static void Main(string[] args)
        {
            // Hard-code customer data as name, number
            List<Customer> customers = new List<Customer>
            {
                new Customer("Jade", "103795587"),
                new Customer("Henry", "103795561"),
                new Customer("Nam", "103541023"),
                new Customer("Khoa", "103844421"),
                new Customer("John", "123456789")
            };

            // Hard-code table data as id, size, time and occupied boolean value
            List<Table> tables = new List<Table>
            {
                new Table("a01", 2, "lunch", "empty"),
                new Table("a02", 4, "lunch", "empty"),
                new Table("a03", 8, "lunch", "empty"),
                new Table("a04", 10, "lunch", "empty"),
                new Table("b01", 2, "dinner", "empty"),
                new Table("b02", 4, "dinner", "empty"),
                new Table("b03", 8, "dinner", "empty"),
                new Table("b04", 10, "dinner", "empty")
            };

            // Hard-code menuItem data as name, type, description and price
            List<menuItem> menuItems = new List<menuItem>
            {
                // Entree
                new menuItem("Spring rolls", "Entree", "Rice paper wrapping shredded veggie, meat or seafood", 8),
                new menuItem("Dumpling", "Entree", " Pieces of cooked dough often wrapped around a filling", 12),
                new menuItem("Carbonara", "Entree", "Pasta made with eggs, cheese, guanciale (bacon), and black pepper", 18),
                // Main
                new menuItem("Pho", "Main Dish", "Vietnamese soup dish consisting of broth, rice noodles, herbs, and meat", 20),
                new menuItem("Tartare", "Main Dish", "Raw ground beef served with onions, capers, mushrooms, pepper", 18),
                new menuItem("Neapolitan pizza", "Main Dish", "Pizza made with tomatoes and mozzarella cheese", 24),
                // Dessert
                new menuItem("Cake", "Dessert", "Cheese, Chocolate and Strawberry cake", 14),
                new menuItem("Ice cream", "Dessert", "Mango, Coconut and Mint flavour", 6),
                // Drink
                new menuItem("Coffee", "Drink", "Latte, Flat white, Cappuccino and Mocha", 6),
                new menuItem("Smoothie", "Drink", "Tropical, Avocado, Watermelon, Banana", 8),
            };

            // Set boolean value simulate user exit the app/website
            bool exit = false;
            while (!exit)
            {
                Console.WriteLine(""); // A gap space
                // List customer's detail
                Console.WriteLine("List of signed Customers:");
                foreach (var cust in customers)
                {
                    Console.WriteLine($"{cust.Name}: {cust.Number}");
                }

                // Request name input for validation
                Console.WriteLine("Enter your name here:");
                string name = Console.ReadLine();
                Customer customer = customers.Find(c => c.Name.ToLower() == name.ToLower());

                // Unavailable user
                if (customer == null)
                {
                    Console.WriteLine("Error, you haven't signed in with us.");
                    Main(args);
                }

                // Valid customer
                Console.WriteLine($"Welcome, {customer.Name}!");

                // Request choice 
                Console.WriteLine("How may I help you today? Enter the number as your request.");
                Console.WriteLine("1. Make reservation");
                Console.WriteLine("2. Place order");
                Console.WriteLine("3. Browse menu");
                Console.WriteLine("4. Exit");

                int choice = int.Parse(Console.ReadLine());

                // Set new reservation
                Reservation reservation = new Reservation(tables);

                // Set Menu application
                Menu menu = new Menu(menuItems);

                // Switching case Order / Reservation
                switch (choice)
                {
                    // Making Reservation, the reservation data 'reservationDetail' from user input consist of partySize, time (l/d) preference
                    case 1:
                        reservation.PlaceReservation(customer.Name);
                        break;
                    // Place Order
                    case 2:
                        Console.WriteLine("Come back later");
                        break;
                    // Browsing menu
                    case 3:
                        menu.ShowMenu();
                        break;
                    // Invalid choice
                    case 4:
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid choice");
                        break;
                }
            }
        }
    }
}