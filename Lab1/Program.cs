using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    class Program
    {
        static void Main(string[] args)
        {
            ProductManager manager = new ProductManager();
            Boolean loop = true;

            string code;
            string name;
            double price;
            double quantity;
            string manufacturer;

            bool exist;

            Product p;

            while (loop)
            {
                Console.WriteLine("1. Add new Product");
                Console.WriteLine("2. Update product");
                Console.WriteLine("3. Delete product");
                Console.WriteLine("4. Search product by name");
                Console.WriteLine("5. Search product by price range");
                Console.WriteLine("6: Find products belong to a manufacturer");
                Console.WriteLine("7: Display all products");
                Console.WriteLine("8: Exit");
                Console.Write("Enter a number: ");
                int menu = int.Parse(Console.ReadLine());
                switch (menu)
                {
                    case 1:
                        #region Add
                        Console.Write("Enter code: ");
                        code = Console.ReadLine();
                        exist = manager.findByCode(code);
                        if (exist)
                        {
                            Console.WriteLine("Product exist! Try agian please");
                        }
                        else
                        {
                            Console.Write("Enter name: ");
                            name = Console.ReadLine();
                            Console.Write("Enter price: ");
                            price = double.Parse(Console.ReadLine());
                            Console.Write("Enter quantity: ");
                            quantity = double.Parse(Console.ReadLine());
                            Console.Write("Enter manufacturer: ");
                            manufacturer = Console.ReadLine();

                            p = new Product(code, name, price, quantity, manufacturer);
                            manager.addProduct(p);
                        }
                        break; 
                        #endregion
                    case 2:
                        #region Update
                        Console.Write("Enter code: ");
                        code = Console.ReadLine();
                        exist = manager.findByCode(code);
                        if (!exist)
                        {
                            Console.WriteLine("Product not found!");
                        }
                        else
                        {
                            Console.Write("Enter name: ");
                            name = Console.ReadLine();
                            Console.Write("Enter price: ");
                            price = double.Parse(Console.ReadLine());
                            Console.Write("Enter quantity: ");
                            quantity = double.Parse(Console.ReadLine());
                            Console.Write("Enter manufacturer: ");
                            manufacturer = Console.ReadLine();

                            p = new Product(code, name, price, quantity, manufacturer);
                            manager.updateProduct(p);
                        }
                        #endregion 
                        break;
                    case 3:
                        #region Delete
                        Console.Write("Enter code: ");
                        code = Console.ReadLine();
                        exist = manager.findByCode(code);
                        if (!exist)
                        {
                            Console.WriteLine("Product not found!");
                        }
                        else
                        {
                            p = new Product();
                            p.code = code;
                            manager.deleteProduct(p);
                            Console.WriteLine("Product deleted");
                        }
                        #endregion
                        break;
                    case 4:
                        #region search name
                        Console.Write("Enter name: ");
                        name = Console.ReadLine();
                        p = manager.findByName(name);
                        if (p != null)
                        {
                            Console.WriteLine(p.ToString());
                        }
                        else
                        {
                            Console.WriteLine("Product not found!");
                        }
                        #endregion
                        break;
                    case 5:
                        #region search price
		                Console.Write("Enter lowest price: ");
                        double r1 = double.Parse(Console.ReadLine());
                        Console.Write("Enter highest price: ");
                        double r2 = double.Parse(Console.ReadLine());
                        p = manager.findByPriceRange(r1, r2);
                        if (p != null)
                        {
                            Console.WriteLine(p.ToString());
                        }
                        else
                        {
                            Console.WriteLine("Product not found!");
                        }
	                    #endregion
                        break;
                    case 6:
                        #region Search manufacturer
                        Console.Write("Enter manufacturer: ");
                        manufacturer = Console.ReadLine();
                        manager.displayByManufacturer(manufacturer);
                        break; 
                        #endregion
                    case 7:
                        #region display all
                        manager.viewProducts();
                        break; 
                        #endregion
                    default:
                        loop = false;
                        break;
                }
            }
        }
    }

    class Product
    {
        string _code;
        string _name;
        double _price;
        double _quantity;
        string _manufacturer;

        public Product() { }

        public Product(string code, string name, double price, double quantity, string manufacturer)
        {
            this._code = code;
            this._name = name;
            this._price = price;
            this._quantity = quantity;
            this._manufacturer = manufacturer;
        }

        public string code
        {
            get { return _code; }
            set { _code = value; }
        }

        public string name
        {
            get { return _name; }
            set { _name = value; }
        }

        public double price
        {
            get { return _price; }
            set { _price = value; }
        }

        public double quantity
        {
            get { return _quantity; }
            set { _quantity = value; }
        }

        public string manufacturer
        {
            get { return _manufacturer; }
            set { _manufacturer = value; }
        }

        public override string ToString()
        {
            return string.Format("Code: {0} - Name: {1} - Price: {2} - Quantity: {3} - Manufacturer: {4}", _code, _name, _price, _quantity, _manufacturer);
        }

        public override bool Equals(object obj)
        {
            Product p = (Product)obj;
            return this._code == p._code;
        }
    }

    class ProductManager
    {
        LinkedList<Product> list;

        public ProductManager()
        {
            list = new LinkedList<Product>();
        }

        public void addProduct(Product p)
        {
            list.AddLast(p);
            Console.WriteLine("Added Succesfully!");
        }

        public void updateProduct(Product p)
        {
            LinkedListNode<Product> node = list.Find(p);
            if (node != null && !node.Equals(list.First))
            {
                node = node.Previous;
                list.Remove(node.Next);
                list.AddAfter(node, p);
            }
            else if (node.Equals(list.First))
            {
                list.RemoveFirst();
                list.AddFirst(p);
            }
            else if (node.Equals(list.Last))
            {
                list.RemoveLast();
                list.AddLast(p);
            }
        }

        public void deleteProduct(Product p)
        {
            list.Remove(p);
        }

        public Product findByName(string name)
        {
            LinkedListNode<Product> node = list.First;
            while (node != null)
            {
                if (node.Value.name.Equals(name)) return node.Value;
                node = node.Next;
            }

            return null;
        }

        public bool findByCode(string code)
        {
            LinkedListNode<Product> node = list.First;
            while (node != null)
            {
                if (node.Value.code.Equals(code)) return true;
                node = node.Next;
            }

            return false;
        }

        public Product findByPriceRange(double r1, double r2)
        {
            if (r1 > r2)
            {
                double tmp = r1;
                r1 = r2;
                r2 = tmp;
            }

            LinkedListNode<Product> node = list.First;
            while (node != null)
            {
                if (node.Value.price >= r1 && node.Value.price <= r2) return node.Value;
                node = node.Next;
            }

            return null;
        }

        public void viewProducts()
        {
            LinkedListNode<Product> node = list.First;
            if (node == null)
            {
                Console.WriteLine("List is empty!");
                return;
            }

            while (node != null)
            {
                Console.WriteLine(node.Value.ToString());
                node = node.Next;
            }
        }

        private List<Product> findByManufacturer(String manu)
        {
            LinkedListNode<Product> node = list.First;
            List<Product> l = new List<Product>();
            while (node != null)
            {
                if (node.Value.manufacturer.Equals(manu)) l.Add(node.Value);
                node = node.Next;
            }

            return l;
        }

        public void displayByManufacturer(String manu)
        {
            List<Product> l = findByManufacturer(manu);
            if (l.Count > 0)
            {
                foreach (Product p in l)
                {
                    Console.WriteLine(p.ToString());
                }
            }
            else
            {
                Console.WriteLine("No matches found");
            }
        }
    }
}
