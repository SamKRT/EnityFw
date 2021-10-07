using FirstContactWithEFCore.Data;
using SamuelsShop.Logic;
using SamuelsShop.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace SamuelsShop
{
    class Program
    {
        
        static void Main(string[] args)
        {
            Console.WriteLine(">>> Welcome <<<\n");
            
            while (true)
            {
                Employee employee = SignIn();
                if (employee is Employee)
                {
                    Console.WriteLine($"Hello {employee.FirstName}!");
                    if (employee.WorkPostion == 'S') // S = Saler
                    {
                        Console.WriteLine("You are a saler.\n");
                    }
                    else if (employee.WorkPostion == 'C') // C = Clearer
                    {
                        Console.WriteLine("You are a clearer.\n");
                    }
                    else if(employee.WorkPostion == 'A') // A = Acceptor
                    {
                        Console.WriteLine("You are a goods acceptor.\n");
                        GoodsReceiptLogic goodsReceiptLogic = new GoodsReceiptLogic();
                        
                        if (goodsReceiptLogic.Selection("Create a new goods receipt? (yes/no)"))
                        {
                            GoodsReceipt goodsReceipt = goodsReceiptLogic.CreateTask();
                            if (goodsReceipt != null)
                                goodsReceiptLogic.SaveDataToDatabase(true, goodsReceipt);
                            
                        }
                        else
                            break;
                    }
                    break;
                }
                else
                {
                    Console.WriteLine("You entered the false username or passowrd. Repeat your enter, please.\n");
                }

            }



            //using (SamuelsShopContext context = new SamuelsShopContext())
            //{
            //    Employee employee = new Employee()
            //    {
            //        FirstName = "Bernhard",
            //        LastName = "Kraut",
            //        Birthday = new DateTime(1968, 3, 26),
            //        City = "Weikersheim",
            //        PostalCode = 97990,
            //        Street = "Kirchstraße",
            //        HouseNumber = 23,
            //        Username = "BernhardK",
            //        Password = "Hallo123",
            //        WorkPostion = 'A',
            //        VacationLength = 24,
            //        VacationTaken = 19
            //    };
            //    context.Employees.Add(employee);
            //    context.SaveChanges();
            //}

            //using (SamuelsShopContext context = new SamuelsShopContext())
            //{
            //    Producer producer = new Producer()
            //    {
            //        Name = "Intersnack Knabber-Gebäck GmbH & Co. KG",
            //        Street = "Erna-Scheffler-Straße",
            //        HouseNumber = 3,
            //        PostalCode = 51103,
            //        City = "Köln",
            //        PhoneNumber = "0221-4894-0"
            //    };
            //    context.Producers.Add(producer);
            //    context.SaveChanges();
            //}

            //using (SamuelsShopContext context = new SamuelsShopContext())
            //{
            //    Product product = new Product()
            //    {
            //        Name = "Chipsfrisch - Oriental",
            //        DailyConsumption = 35,
            //        Price = 1.59m,
            //        ProducerID = 2,
            //        Stock = 0
            //    };
            //    context.Products.Add(product);
            //    context.SaveChanges();
            //}


            //using (SamuelsShopContext context = new SamuelsShopContext())
            //{
            //    var chipsungarisch = from p in context.Products
            //                         where p.ProductID == 19
            //                         select p;

            //    chipsungarisch.First().TargetTemperature = null;
            //    context.SaveChanges();
            //}

            // == INSERT == \\








            // == READ == \\
            /*
            var products = from product in context.Products
                           where product.Price > 12.0m
                           orderby product.Name
                           select product;

            foreach (var product in products)
            {
                Console.WriteLine($"Id:     {product.Id}");
                Console.WriteLine($"Name:   {product.Name}");
                Console.WriteLine($"Price:  {product.Price}");
                Console.WriteLine($"-----------------------");
                Console.WriteLine();
            }
            */



            // == UPDATE == \\

            /*
            var bodenEiche = context.Products
                                .Where(p => p.Name == "Viniylboden Eiche m^2")
                                .FirstOrDefault();

            if(bodenEiche is Product)
            {
                bodenEiche.Price = 17.99m;
            }
            context.SaveChanges();

            var products = from product in context.Products
                           where product.Price < 17.0m
                           orderby product.Name
                           select product;

            foreach (var product in products)
            {
                Console.WriteLine($"Id:     {product.Id}");
                Console.WriteLine($"Name:   {product.Name}");
                Console.WriteLine($"Price:  {product.Price}");
                Console.WriteLine($"-----------------------");
                Console.WriteLine();
            }



            */
            // == DELETE == \\

            //using(SamuelsShopContext context = new SamuelsShopContext())
            //{


            //    var employee = from employee1 in context.Employees
            //                where employee1.FirstName == "Febri"
            //                select employee1;


            //    context.Remove(employee.First());

            //    context.SaveChanges();
            //};



        }

        private static Employee SignIn()
        {
            Console.WriteLine("Username:");
            string username = Console.ReadLine();
            Console.WriteLine("Password:");
            string password = Console.ReadLine();
            Console.WriteLine();


            using(SamuelsShopContext context = new SamuelsShopContext())
            {
                var employee = from employee1 in context.Employees
                                    where employee1.Username == username && employee1.Password == password
                                    select employee1;

                if (employee.Count() > 0 && employee.Count() < 2)
                {
                    return employee.FirstOrDefault();
                }
                else
                    return null;

            }
        }
    }
}
