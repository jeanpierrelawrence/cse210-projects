using System;

class Program
{
    static void Main(string[] args)
    {
        Address add1 = new Address("742 Evergreen Terrace", "Springfield", "IL", "USA");
        Address add2 = new Address("Rua Augusta 1500", "São Paulo", "SP", "Brazil");
        Address add3 = new Address("1-1 Chiyoda", "Chiyoda City", "Tokyo", "Japan");

        Product item1 = new Product("Wireless Mouse", "W-202", 15.99, 1);
        Product item2 = new Product("AA Batteries (4pk)", "B-004", 5.50, 2);
        Product item3 = new Product("Desk Mat", "D-101", 12.00, 1);
        Product item4 = new Product("Noise Cancelling Headphones", "N-700", 199.99, 1);
        Product item5 = new Product("USB-C Charging Cable", "C-012", 10.00, 3);
        Product item6 = new Product("Mechanical Keyboard", "K-880", 120.00, 1);
        Product item7 = new Product("Keycap Puller", "T-009", 4.50, 1);
        Product item8 = new Product("Compressed Air Can", "A-302", 6.00, 2);

        Customer sarahJenkins = new Customer("Sarah Jenkins", add1);
        Customer lucasSilva = new Customer("Lucas Silva", add2);
        Customer hanaTanaka = new Customer("Hana Tanaka", add3);

        Order sarahOrder = new Order(sarahJenkins);
        Order lucasOrder = new Order(lucasSilva);
        Order hanaOrder = new Order(hanaTanaka);

        sarahOrder.AddToOrder(item1);
        sarahOrder.AddToOrder(item2);
        sarahOrder.AddToOrder(item3);

        lucasOrder.AddToOrder(item4);
        lucasOrder.AddToOrder(item5);

        hanaOrder.AddToOrder(item6);
        hanaOrder.AddToOrder(item7);
        hanaOrder.AddToOrder(item8);

        Console.WriteLine(sarahOrder.GetPackingLabel());
        Console.WriteLine(sarahOrder.GetShippingLabel());
        Console.WriteLine($"Total Price: ${sarahOrder.GetTotalCost():F2}");
        Console.WriteLine("-----------------------");

        Console.WriteLine(lucasOrder.GetPackingLabel());
        Console.WriteLine(lucasOrder.GetShippingLabel());
        Console.WriteLine($"Total Price: ${lucasOrder.GetTotalCost():F2}");
        Console.WriteLine("-----------------------");

        Console.WriteLine(hanaOrder.GetPackingLabel());
        Console.WriteLine(hanaOrder.GetShippingLabel());
        Console.WriteLine($"Total Price: ${hanaOrder.GetTotalCost():F2}");
        Console.WriteLine("-----------------------");
    }
}