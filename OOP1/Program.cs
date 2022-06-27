

namespace Lab1
{

    class Product
    {
        // getter and setter
        public string Name { get; set; }
        public double Price { get; set; }
        public string Code { get; set; }

        // constructor 
        public Product(string name, double price, string code)
        {
            Name = name;
            Price = price;
            Code = code;
        }
    }

    class vendingMachine
    {
        // getter and setter
        public int SerialNumber { get; set; }
        public Dictionary<int, int> MoneyFloat { get; set; }
        public Dictionary<Product, int> Inventory { get; set; }

        // constructor
        public vendingMachine(int serialNumber)
        {
            SerialNumber = serialNumber;
            MoneyFloat = new Dictionary<int, int>();
            Inventory = new Dictionary<Product, int>();
        }

        // method for stocking item
        public string StockItem(Product product, int quantity)
        {
            // check if the product is already in the inventory
            if (Inventory.ContainsKey(product))
            {
                Inventory[product] += quantity;
            }
            else
            {
                Inventory.Add(product, quantity);
            }
            return "Product " + product.Name + " " + product.Code + " " + product.Price + " " + quantity;
        }

        // method for stocking float
        public string StockFloat(int moneyDenomination, int quantity)
        {
            // check if the money denomination is valid
            if (MoneyFloat.ContainsKey(moneyDenomination))
            {
                MoneyFloat[moneyDenomination] += quantity;
            }
            else
            {
                MoneyFloat.Add(moneyDenomination, quantity);
            }
            return "Money " + moneyDenomination + " " + quantity;
        }

        // method for stocking float
        public string VendItem(string code, List<int> money)
        {
            // check if the product is already in the inventory
            Product product = Inventory.Keys.FirstOrDefault(x => x.Code == code);
            if (product == null)
            {
                return "Error, no item with code " + code;
            }
            if (Inventory[product] == 0)
            {
                return "Error: Item is out of stock";
            }
            if (money.Sum() < product.Price)
            {
                return "Error: insufficient money provided";
            }
            double change = money.Sum() - product.Price;
            Inventory[product]--;
            return "Please enjoy your " + product.Name + " and take your change of $" + change;
        }

        // main method
        static void Main(string[] args)
        {
            vendingMachine vm = new vendingMachine(12345);
            Product p1 = new Product("Coke", 1.50, "C001");
            Product p2 = new Product("Pepsi", 1.50, "P002");
            Product p3 = new Product("Sprite", 1.50, "S003");

            vm.StockItem(p1, 10);
            vm.StockItem(p2, 10);
            vm.StockItem(p3, 10);

            vm.StockFloat(1, 10);
            vm.StockFloat(5, 10);
            vm.StockFloat(10, 10);
            vm.StockFloat(20, 10);
            vm.StockFloat(50, 10);

            //print product details
            Console.WriteLine(vm.StockItem(p1, 10));
            Console.WriteLine(vm.StockItem(p2, 10));
            Console.WriteLine(vm.StockItem(p3, 10));
            Console.WriteLine(vm.SerialNumber);
            Console.WriteLine(vm.MoneyFloat[1]);
            Console.WriteLine(vm.MoneyFloat[5]);
            Console.WriteLine(vm.MoneyFloat[10]);
            Console.WriteLine(vm.MoneyFloat[20]);

            //print vending machine details
            Console.WriteLine(vm.VendItem("C001", new List<int> { 10, 0, 0, 0, 0, 0, 0, 0, 0, 0 }));


        }
    }
}

