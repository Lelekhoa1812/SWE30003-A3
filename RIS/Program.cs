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
            new Table("a01", 2, "lunch", false),
            new Table("a02", 4, "lunch", false),
            new Table("a03", 8, "lunch", false),
            new Table("a04", 10, "lunch", false),
            new Table("b01", 2, "dinner", false),
            new Table("b02", 4, "dinner", false),
            new Table("b03", 8, "dinner", false),
            new Table("b04", 10, "dinner", false)
        };

            // Hard-code menuItem data as name, type, description and price
            List<menuItem> menuItems = new List<menuItem>
        {
            // Entree
            new menuItem("Spring rolls", "Entree", "Rice paper wrapping shredded veggie, meat or seafood", "$8.00"),
            new menuItem("Dumpling", "Entree", " Pieces of cooked dough often wrapped around a filling", "$12.00"),
            new menuItem("Carbonara", "Entree", "Pasta made with eggs, cheese, guanciale (bacon), and black pepper", "$18.00"),
            // Main
            new menuItem("Pho", "Main Dish", "Vietnamese soup dish consisting of broth, rice noodles, herbs, and meat", "$20.00"),
            new menuItem("Tartare", "Main Dish", "Raw ground beef served with onions, capers, mushrooms, pepper", "$18.00"),
            new menuItem("Neapolitan pizza", "Main Dish", "Pizza made with tomatoes and mozzarella cheese", "$24.00"),
            // Dessert
            new menuItem("Cake", "Dessert", "Cheese, Chocolate and Strawberry cake", "$14.00"),
            new menuItem("Ice cream", "Dessert", "Mango, Coconut and Mint flavour", "$6.00"),
            // Drink
            new menuItem("Coffee", "Drink", "Latte, Flat white, Cappuccino and Mocha", "$6.00"),
            new menuItem("Smoothie", "Drink", "Tropical, Avocado, Watermelon, Banana", "$8.00"),
        };

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
                    Console.WriteLine("Please enter your reservation detail as this format: Party Size, Lunch/Dinner");
                    string[] reservationDetail = Console.ReadLine().Split(','); // Split reservationDetail from input by a comma 
                    int partySize = int.Parse(reservationDetail[0]); // partySize int on index 0
                    string time = reservationDetail[1]; // time string on index 1
                    reservation.MakeReservation(customer.Name, partySize, time); // Call the MakeReservation function
                    break;
                // Place Order
                case 2:
                    Console.WriteLine("Come back later");
                    break;
                // Browsing menu
                case 3:
                    Console.WriteLine("Relaxing Koala Restaurant Menu");
                    Console.WriteLine("1. Entrees");
                    Console.WriteLine("2. Main Dishes");
                    Console.WriteLine("3. Desserts");
                    Console.WriteLine("4. Drinks");
                    Console.WriteLine("5. Browse all");
                    int menuchoice = int.Parse(Console.ReadLine());
                    menu.ShowMenu(menuchoice);
                    break;
                // Invalid choice
                default:
                    Console.WriteLine("Invalid choice");
                    break;
            }
        }
    }
}