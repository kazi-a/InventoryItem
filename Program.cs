using System;

namespace OperatorOverloadingExercise
{
    public class InventoryItem
    {
        public string Name { get; set; }
        public int Quantity { get; set; }

        public InventoryItem(string name, int quantity)
        {
            Name = name;
            Quantity = quantity;
        }

        // Unary overloaded operators
        public static InventoryItem operator +(InventoryItem item)
        {
            return new InventoryItem(item.Name, +item.Quantity);
        }

        public static InventoryItem operator -(InventoryItem item)
        {
            return new InventoryItem(item.Name, -item.Quantity);
        }

        public static InventoryItem operator !(InventoryItem item)
        {
            return new InventoryItem(item.Name, item.Quantity == 0 ? 1 : 0);
        }

        // Comparison overloaded operators
        public static bool operator ==(InventoryItem item1, InventoryItem item2)
        {
            return item1.Name == item2.Name && item1.Quantity == item2.Quantity;
        }

        public static bool operator !=(InventoryItem item1, InventoryItem item2)
        {
            return !(item1 == item2);
        }

        public static bool operator >(InventoryItem item1, InventoryItem item2)
        {
            return item1.Quantity > item2.Quantity;
        }

        public static bool operator <(InventoryItem item1, InventoryItem item2)
        {
            return item1.Quantity < item2.Quantity;
        }

        // Binary overloaded operators
        public static InventoryItem operator +(InventoryItem item1, InventoryItem item2)
        {
            return new InventoryItem(item1.Name + " and " + item2.Name, item1.Quantity + item2.Quantity);
        }

        public static InventoryItem operator -(InventoryItem item1, InventoryItem item2)
        {
            return new InventoryItem(item1.Name + " without " + item2.Name, item1.Quantity - item2.Quantity);
        }

        public static InventoryItem operator *(InventoryItem item1, int multiplier)
        {
            return new InventoryItem(item1.Name, item1.Quantity * multiplier);
        }

        public static InventoryItem operator /(InventoryItem item1, int divisor)
        {
            return new InventoryItem(item1.Name, item1.Quantity / divisor);
        }

        public static InventoryItem operator %(InventoryItem item1, int divisor)
        {
            return new InventoryItem(item1.Name, item1.Quantity % divisor);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter details for Item 1:");
            Console.Write("Name: ");
            string name1 = Console.ReadLine();
            Console.Write("Quantity: ");
            int quantity1 = int.Parse(Console.ReadLine());
            InventoryItem item1 = new InventoryItem(name1, quantity1);

            Console.WriteLine("Enter details for Item 2:");
            Console.Write("Name: ");
            string name2 = Console.ReadLine();
            Console.Write("Quantity: ");
            int quantity2 = int.Parse(Console.ReadLine());
            InventoryItem item2 = new InventoryItem(name2, quantity2);

            // Unary operators
            Console.WriteLine($"Original quantity of {item1.Name}: {item1.Quantity}");
            Console.WriteLine($"Positive quantity of {item1.Name}: {(+item1).Quantity}");
            Console.WriteLine($"Negative quantity of {item1.Name}: {(-item1).Quantity}");
            Console.WriteLine($"Inverted quantity of {item1.Name}: {(!item1).Quantity}");

            // Comparison operators
            Console.WriteLine($"Are {item1.Name} and {item2.Name} equal? {(item1 == item2 ? "Yes" : "No")}");
            Console.WriteLine($"Are {item1.Name} and {item2.Name} not equal? {(item1 != item2 ? "Yes" : "No")}");
            Console.WriteLine($"Is {item1.Name} greater than {item2.Name}? {(item1 > item2 ? "Yes" : "No")}");
            Console.WriteLine($"Is {item1.Name} less than {item2.Name}? {(item1 < item2 ? "Yes" : "No")}");

            // Binary operators
            InventoryItem sum = item1 + item2;
            Console.WriteLine($"Sum of {item1.Name} and {item2.Name}: {sum.Quantity} items ({sum.Name})");

            InventoryItem difference = item1 - item2;
            Console.WriteLine($"Difference between {item1.Name} and {item2.Name}: {difference.Quantity} items ({difference.Name})");

            InventoryItem scaledItem = item1 * 3;
            Console.WriteLine($"Three times the quantity of {item1.Name}: {scaledItem.Quantity}");

            InventoryItem dividedItem = item1 / 2;
            Console.WriteLine($"Half the quantity of {item1.Name}: {dividedItem.Quantity}");

            InventoryItem remainderItem = item1 % 3;
            Console.WriteLine($"Remainder of dividing the quantity of {item1.Name} by 3: {remainderItem.Quantity}");
        }
    }
}
