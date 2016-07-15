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
            ProductManager p = new ProductManager();
            p.addProduct(new Product("A1", "1", 1, 1, "A1"));
            p.addProduct(new Product("A2", "2", 2, 2, "A2"));
            p.addProduct(new Product("A3", "3", 3, 3, "A3"));
            p.viewProducts();
            Console.ReadLine();
            p.updateProduct(new Product("A2", "6", 6, 6, "A6"));
            p.viewProducts();
            Console.ReadLine();
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
            return string.Format("{0} - {1} - {2} - {3} - {4}", _code, _name, _price, _quantity, _manufacturer);
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
        }

        public void updateProduct(Product p)
        {
            LinkedListNode<Product> node = list.Find(p);
            if (node != null)
            {
                node = node.Previous;
                list.Remove(node.Next);
                list.AddAfter(node, p);
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
                if (node.Value.name.Equals(code)) return true;
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
            while (node != null)
            {
                Console.WriteLine(node.Value.ToString());
                node = node.Next;
            }
        }

        public List
    }
}
