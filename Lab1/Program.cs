﻿using System;
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
                        string code;
                        string name;
                        double price;
                        double quantity;
                        string manufacturer;

                        Console.Write("Enter code: ");
                        code = Console.ReadLine();
                        bool exist = manager.findByCode(code);
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

                            Product p = new Product(code, name, price, quantity, manufacturer);
                            manager.addProduct(p);
                        }
                        break;
                    case 2:
                        
                        break;
                    case 3:
                        
                        break;
                    case 4:
                        
                        break;
                    case 5:
                        
                        break;
                    case 6:
                        
                        break;
                    case 7:

                        break;
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

        public List<Product> findByManufacturer(String manu)
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

        public void displayProduct(Product p)
        {
            Console.WriteLine(p.ToString());
        }
    }
}
