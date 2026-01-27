using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShoppingCartApp
{
    public record Product(string Name, decimal Price);

    internal class Program
    {
        static readonly Dictionary<string, decimal> _catalog = new()
        {
            { "iphone", 1220m },
            { "ipad", 1320m },
            { "macbook", 1256m }
        };

        static List<Product> _cartItems = new();
        static Stack<(string ItemName, bool IsAdded)> _actionHistory = new();

        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.Title = "Youssef's Smart Shop";

            while (true)
            {
                Console.Clear();
                Console.WriteLine("=================================");
                Console.WriteLine("🛒 Welcome to the Store");
                Console.WriteLine("=================================");
                Console.WriteLine("1. Add Item to Cart");
                Console.WriteLine("2. View Cart");
                Console.WriteLine("3. Remove Item from Cart");
                Console.WriteLine("4. Checkout");
                Console.WriteLine("5. Undo Last Action");
                Console.WriteLine("6. Exit");
                Console.WriteLine("=================================");
                Console.Write("👉 Please enter your choice: ");

                if (!int.TryParse(Console.ReadLine(), out int userChoice))
                {
                    PrintMessage("❌ Invalid input! Please enter a number.", ConsoleColor.Red);
                    continue;
                }

                switch (userChoice)
                {
                    case 1:
                        AddItem();
                        break;
                    case 2:
                        ViewCart();
                        WaitUser();
                        break;
                    case 3:
                        RemoveItem();
                        break;
                    case 4:
                        Checkout();
                        break;
                    case 5:
                        UndoAction();
                        break;
                    case 6:
                        Console.WriteLine("👋 See you soon!");
                        Environment.Exit(0);
                        break;
                    default:
                        PrintMessage("⚠️ Wrong choice, try again.", ConsoleColor.Yellow);
                        break;
                }
            }
        }

        static void AddItem()
        {
            Console.WriteLine("\n📋 Available Items:");
            foreach (var item in _catalog)
            {
                Console.WriteLine($"- {item.Key} \t [{item.Value:C}]");
            }

            Console.Write("\n⌨️ Type the item name to add: ");
            string inputName = Console.ReadLine()?.Trim().ToLower();

            if (_catalog.ContainsKey(inputName))
            {
                decimal price = _catalog[inputName];
                _cartItems.Add(new Product(inputName, price));
                _actionHistory.Push((inputName, true));
                PrintMessage("✅ Item added successfully!", ConsoleColor.Green);
            }
            else
            {
                PrintMessage("❌ Item not found!", ConsoleColor.Red);
            }
            WaitUser();
        }

        static void ViewCart()
        {
            Console.WriteLine("\n🛒 Your Cart Content:");
            if (!_cartItems.Any())
            {
                Console.WriteLine("  (The cart is empty)");
                return;
            }

            foreach (var product in _cartItems)
            {
                Console.WriteLine($"  📦 {product.Name} - {product.Price:C}");
            }
        }

        static void RemoveItem()
        {
            ViewCart();
            if (!_cartItems.Any())
            {
                WaitUser();
                return;
            }

            Console.Write("\n⌨️ Type the item name to remove: ");
            string inputName = Console.ReadLine()?.Trim().ToLower();

            var productToRemove = _cartItems.FirstOrDefault(p => p.Name == inputName);

            if (productToRemove != null)
            {
                _cartItems.Remove(productToRemove);
                _actionHistory.Push((inputName, false));
                PrintMessage("🗑️ Item removed successfully.", ConsoleColor.Green);
            }
            else
            {
                PrintMessage("⚠️ Item not in cart!", ConsoleColor.Yellow);
            }
            WaitUser();
        }

        static void UndoAction()
        {
            if (_actionHistory.Count > 0)
            {
                var lastAction = _actionHistory.Pop();
                string itemName = lastAction.ItemName;
                bool wasAdded = lastAction.IsAdded;

                Console.WriteLine($"\n🔄 Undoing: {(wasAdded ? "Add" : "Remove")} {itemName}...");

                if (wasAdded)
                {
                    var itemToDelete = _cartItems.LastOrDefault(x => x.Name == itemName);
                    if (itemToDelete != null) _cartItems.Remove(itemToDelete);
                }
                else
                {
                    if (_catalog.ContainsKey(itemName))
                    {
                        _cartItems.Add(new Product(itemName, _catalog[itemName]));
                    }
                }
                PrintMessage("✅ Undo completed.", ConsoleColor.Blue);
            }
            else
            {
                PrintMessage("ℹ️ Nothing to undo!", ConsoleColor.Gray);
            }
            WaitUser();
        }

        static void Checkout()
        {
            if (!_cartItems.Any())
            {
                PrintMessage("🛒 Cart is empty! Add items first.", ConsoleColor.Yellow);
            }
            else
            {
                decimal total = _cartItems.Sum(x => x.Price);
                ViewCart();
                Console.WriteLine("---------------------------------");
                Console.WriteLine($"💰 Total Price: {total:C}");
                Console.WriteLine("---------------------------------");
                Console.WriteLine("🎉 Proceeding to payment... Done!");

                _cartItems.Clear();
                _actionHistory.Clear();
            }
            WaitUser();
        }

        static void PrintMessage(string message, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine($"\n{message}");
            Console.ResetColor();
        }

        static void WaitUser()
        {
            Console.WriteLine("\nPress [Enter] to continue...");
            Console.ReadLine();
        }
    }
}