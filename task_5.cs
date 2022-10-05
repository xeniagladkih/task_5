using System;
using System.Collections.Generic;
using System.Data;

namespace ConsoleApp5
{
    public class Goods
    {
        private double price;
        private string country = " ";
        private string name = " ";
        private string date = " ";
        private string description = " ";
        public double Price
        {
            get { return price; }
            set { price = value; }
        }
        public string Country
        {
            get { return country; }
            set { country = value; }
        }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public string Date
        {
            get { return date; }
            set { date = value; }
        }
        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        public virtual void Display()
        {
            Console.WriteLine(price);
            Console.WriteLine(country);
            Console.WriteLine(name);
            Console.WriteLine(date);
            Console.WriteLine(description);
        }

        public virtual void Add()
        {
            Console.WriteLine("Enter name: ");
#pragma warning disable CS8601 // Possible null reference assignment.
            name = Console.ReadLine();
#pragma warning restore CS8601 // Possible null reference assignment.
            Console.WriteLine("Enter price: ");
            string str = price.ToString();
            str = Console.ReadLine();
            Console.WriteLine("Enter country: ");
            country = Console.ReadLine();
            Console.WriteLine("Enter date: ");
            date = Console.ReadLine();
            Console.WriteLine("Enter description: ");
            description = Console.ReadLine();
        }
    }
    public class Products : Goods
    {
        private string term = " ";
        private int quantity;
        private string measurement = " ";

        public override void Display()
        {
            base.Display();
            Console.WriteLine(term);
            Console.WriteLine(quantity);
            Console.WriteLine(measurement);
        }

        public override void Add()
        {
            base.Add();
        }

        public string Term
        {
            get { return term; }
            set { term = value; }
        }
        public int Quantity
        {
            get { return quantity; }
            set { quantity = value; }
        }
        public string Measurement
        {
            get { return measurement; }
            set { measurement = value; }
        }
    }
    public class Books : Goods
    {
        private int pages;
        private string publishing = " ";
        private string list = " ";
        public override void Display()
        {
            base.Display();
            Console.WriteLine(pages);
            Console.WriteLine(publishing);
            Console.WriteLine(list);
        }

        public override void Add()
        {
            base.Add();
        }
        public int Pages
        {
            get { return pages; }
            set { pages = value; }
        }
        public string Publishing
        {
            get { return publishing; }
            set { publishing = value; }
        }
        public string List
        {
            get { return list; }
            set { list = value; }
        }
    }
    public class Program
    {
        static void Main(string[] args)
        {
            List<Goods> goods = new();
            Products cheese = new()
            {
                Name = "Camembert",
                Price = 476.0,
                Country = "France",
                Date = "26/10/22",
                Description = "Cremiere de France Laita Camembert cheese 45% from cow's milk",
                Term = "26/01/23",
                Quantity = 1,
                Measurement = "kg"
            };
            goods.Add(cheese);

            Books books = new()
            {
                Name = "Jane Eyre",
                Price = 290.0,
                Country = "UK",
                Date = "16/10/1847",
                Description = "The novel follows the story of Jane, a seemingly plain and simple girl as she battles through life's struggles. Jane has many obstacles in her life - her cruel and abusive Aunt Reed, the grim conditions at Lowood school, her love for Rochester and Rochester's marriage to Bertha.",
                Pages = 672,
                Publishing = "Exclusive classic",
                List = "Charlotte Bronte"
            };
            goods.Add(books);

            Console.WriteLine("Would you like to look at some goods? y/n");
            string check = Console.ReadLine();
            if (check!="y")
            {
                Environment.Exit(0);
            }
            Console.WriteLine("");

            foreach (Goods good in goods)
            {
                good.Display();
                Console.WriteLine("");
            }
            Console.WriteLine("Do you want to add some goods? y/n");
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
            check = Console.ReadLine();
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
            if (check == "y")
            {
                Console.WriteLine("Do you want to add a product? y/n");
                check = Console.ReadLine();
                if (check == "y")
                {
                    Products product1 = new();
                    product1.Add();
                    goods.Add(product1);
                }

                Console.WriteLine("Do you want to add a book? y/n");
                check = Console.ReadLine();
                if (check == "y")
                {
                    Books book1 = new();
                    book1.Add();
                    goods.Add(book1);
                }
            }

            Console.WriteLine("Do you want to delete some goods? y/n");
            check = Console.ReadLine();
            if (check == "y")
            {
                Console.WriteLine("Do you want to delete Camembert? y/n");
                check = Console.ReadLine();
                if (check == "y")
                {
                    goods.Remove(cheese);
                }
                Console.WriteLine("Do you want to delete Jane Eyre? y/n");
                check = Console.ReadLine();
                if (check == "y")
                {
                    goods.Remove(books);
                }
            }

            if (goods.Count != 0)
            {
                foreach (Goods good in goods)
                {
                    good.Display();
                    Console.WriteLine("");
                }
            }
            else
            {
                Console.WriteLine("There is no goods");
                Console.WriteLine("");
            }
        }
    }
}
