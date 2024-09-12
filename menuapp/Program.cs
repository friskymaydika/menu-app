using System;
using System.Collections.Generic;
using System.Globalization;

namespace FoodOrderApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define food menu items and their prices in IDR
            Dictionary<int, string> foodMenu = new Dictionary<int, string>
            {
                { 1, ". Nasi Goreng" },
                { 2, ". Nasi Uduk" },
                { 3, ". Nasi Kucing" },
                { 4, ". Mie Rebus" },
                { 5, ". Mie Goreng" },
                { 6, ". Mie Ayam" },
            };

            Dictionary<int, decimal> foodPrices = new Dictionary<int, decimal>
            {
                { 1, 12000M }, //Nasi Goreng
                { 2, 9000M }, //Nasi Uduk
                { 3, 8000M }, //nasi Kucing
                { 4, 8000M }, //Mie Rebus
                { 5, 9000M }, //Mie Gioreng
                { 6, 13000M }, //Mie Ayam
            };

            // Define drink menu items and their prices in IDR
            Dictionary<int, string> drinkMenu = new Dictionary<int, string>
            {
                { 7, ". Teh Botol" },
                { 8, ". Teh pucuk" },
                { 9, ". Susu jahe" },
                { 10, ". kopi jahe" },
                { 11, ". Kopi+Susu"},
                { 12, ". tea Jus"},
            };

            Dictionary<int, decimal> drinkPrices = new Dictionary<int, decimal>
            {
                { 7, 5000M }, // TEH Botol
                { 8, 4000M }, // Teh Pucuk
                { 9, 4000M }, // Teh Jahe
                { 10, 3000M }, // Kopi Jahe
                { 11, 5000M }, // Kopi+susu
                { 12, 0m }, // TeaJus
            };

            decimal itemTotal = 0M; // Initialize item total

            // Add some space for clarity
            Console.WriteLine("\n----------------------------------------\n");

            Console.WriteLine("MENU APP");
            while (true)

            {
                // Add some space for clarity
                Console.WriteLine("\n----------------------------------------\n");

                // Display food menu
                Console.WriteLine("Food Menu:");
                foreach (var item in foodMenu)
                {
                    Console.WriteLine($"{item.Key}. {item.Value} - {foodPrices[item.Key].ToString("C", CultureInfo.GetCultureInfo("id-ID"))}");
                }

                // Display drink menu
                Console.WriteLine("\nDrink Menu:");
                foreach (var item in drinkMenu)
                {
                    Console.WriteLine($"{item.Key}. {item.Value} - {drinkPrices[item.Key].ToString("C", CultureInfo.GetCultureInfo("id-ID"))}");
                }

                // Add some space for clarity
                Console.WriteLine("\n----------------------------------------\n");

                // Take user input for item
                Console.Write("\nEnter the number corresponding to your choice: ");
                if (int.TryParse(Console.ReadLine(), out int userChoice))

                {
                    decimal price;
                    string selectedName;

                    if (foodMenu.ContainsKey(userChoice))
                    {
                        selectedName = foodMenu[userChoice];
                        price = foodPrices[userChoice];
                    }
                    else if (drinkMenu.ContainsKey(userChoice))
                    {
                        selectedName = drinkMenu[userChoice];
                        price = drinkPrices[userChoice];
                    }
                    else
                    {
                        Console.WriteLine("Invalid choice. Please select a valid item number.");
                        continue;
                    }

                    Console.WriteLine($"You selected {selectedName}.");
                    Console.WriteLine($"The price is {price.ToString("C", CultureInfo.GetCultureInfo("id-ID"))}.");

                    // Ask for quantity
                    Console.Write("Enter the quantity: ");
                    if (int.TryParse(Console.ReadLine(), out int quantity))
                    {
                        decimal totalCost = price * quantity;
                        itemTotal += totalCost; // Add to item total
                        Console.WriteLine($"Total cost for {quantity} {selectedName}(s): {totalCost.ToString("C", CultureInfo.GetCultureInfo("id-ID"))}");
                    }
                    else
                    {
                        Console.WriteLine("Invalid quantity. Please enter a valid number.");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a valid number.");
                }

                // Add some space for clarity
                Console.WriteLine("\n----------------------------------------\n");

                // Ask if the user wants to order another item
                Console.Write("Do you want to order another item? (yes/no): ");
                string anotherOrder = Console.ReadLine().Trim().ToLower();
                if (anotherOrder != "yes")
                {
                    Console.WriteLine($"Your total order cost is {itemTotal.ToString("C", CultureInfo.GetCultureInfo("id-ID"))}. Thank you for using our food ordering app!");
                    break; // Exit the loop
                }
            }
        }
    }
}
