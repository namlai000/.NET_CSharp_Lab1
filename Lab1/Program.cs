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

        public void addProduct(Product p);
    }
}
