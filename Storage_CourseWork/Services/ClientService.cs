﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace Storage_CourseWork.Services
{
    public class ClientService
    {
        public Client LoginedClient { get; set; } = null;
        Storage storage = new Storage();


        public void CreateAcc()
        {
            Console.Write("Enter the name: ");
            string name = Console.ReadLine();
            Console.Write("Enter the surname: ");
            string surname = Console.ReadLine();
            Console.Write("How much money do you have? : ");
            double money = Convert.ToDouble(Console.ReadLine()); ;
            Console.Write("Enter the login: ");
            string login;
            do
            {
                login = Console.ReadLine();
                if (login.Length < 4)
                {
                    Console.WriteLine("\nYour Login must have more than 3 letters or digits\n");
                }
            } while (login.Length < 4);
            Console.Write("Enter the password ");
            string password;
            do
            {
                password = Console.ReadLine();
                if (password.Length < 7)
                {
                    Console.WriteLine("\nYour Login must have more than 6 letters or digits\n");
                }
            } while (password.Length < 7);
            Client client = new Client(name, surname, money, login, password);
            storage.AddClient(client);
        }

        public bool SingInManager()
        {
            do
            {
            Console.Write("Enter login: ");
            string login = Console.ReadLine();
              Console.Write("Enter password: ");
            string password = Console.ReadLine();
            if (login=="admin123"&&password=="admin228")
            {
                    Console.WriteLine("You logined as Manager.");
                return true;
            }
            else
            {
                Console.WriteLine("\nWrong!\n");
                return false;
            }
            } while (true);
        }
        public bool SingInWorker()
        {
            do
            {
            Console.Write("Enter login: ");
            string login = Console.ReadLine();
              Console.Write("Enter password: ");
            string password = Console.ReadLine();
            if (login=="workerAdd"&&password=="thebestjobintheworld")
            {
                    Console.WriteLine("You logined as Worker.");
                return true;
            }
            else
            {
                Console.WriteLine("\nWrong!\n");
                return false;
            }
            } while (true);
        }

        public void RemoveClient()
        {
            Console.Clear();
            ShowClients();
            Console.Write("\n\nEnter the id of client to remove: ");
            int id = Convert.ToInt32(Console.ReadLine());
            var result = storage.Clients.Where(i => i.Id == id);
                foreach (var item in result.ToList())
                {
                    Console.WriteLine($"\n--- Deleted: {item}\n ---");
                    storage.Clients.Remove(item);
                }
            Console.WriteLine("Press any button to continue...");
            Console.ReadKey();
        }
        public bool SignIn()
        {
            Console.Write("Enter login: ");
            string login;
            do
            {
                login = Console.ReadLine();
                if (login.Length<4)
                {
                    Console.WriteLine("\nYour Login must have more than 3 letters or digits\n");
                }
            } while (login.Length < 4);
            Console.Write("Enter password: ");
            string password = Console.ReadLine();
            Console.Clear();
            if (storage.Clients.Any(el => el.Login == login)) {
                if (storage.Clients.Where(el => el.Login == login).First().Password == password) {
                    Console.WriteLine($"\n\t\t\tYou logined as {login}\n\n");
                    var user = storage.Clients.Where(el => el.Login == login).First();
                    LoginedClient = user;
                    return true;
                }
            }
            Console.WriteLine($"Incorrect login or password!");
            return false;
        }
        public int PlacesLeft()
        {
            return storage.PlacesLeft();
        }
        public void SaveStat()
        {
            storage.SaveStat();
        }
        public void LoadStat()
        {
            storage.LoadStat();
        }
        public void ShowStatOfStorage()
        {
            storage.ShowStat();
        }
        public void ShowProductsOfClients()
        {
            storage.ShowProductsOfClients();
        }
        public void ShowClients()
        {
            storage.ShowClients();
        }
        public void LoadClients()
        {
            storage.LoadClients(); 
        }
        public void LoadProducts()
        {
            storage.LoadProduct();
        }
        public void SaveProducts()
        {
            storage.SaveProduct();
        }
        public void SaveClients()
        {
            storage.SaveClients();
        }

        public void ShowProductsOnStorage()
        {
            storage.ShowProducts();
        }
        public void GiveProductForSaving()
        {
            string name;
            double area;
            double price;
            int days;
            Console.Write("Enter the name of product: ");
            name = Console.ReadLine();
            Console.Write("Enter the area of product: ");
            area = Convert.ToDouble(Console.ReadLine());
            Console.Write("Hom much days do you want to save? : ");
            days = Convert.ToInt32(Console.ReadLine());
            price = area * (double)days * 8;
            Product product = new Product(name, area, price, days);
            product.ExpiredDate = (DateTime.Now).AddDays(days);
            storage.AddProduct(product);
            LoginedClient.Money -= price;
            storage.Cash += price;
        }
        public bool IsFull()
        {
            if (storage.IsFull())
            {
                return true;
            }
            return false;
        }
        public void TakeProduct()
        {
            storage.ShowProducts();
            Console.Write("\n\nEnter id: ");
            int id = Convert.ToInt32(Console.ReadLine());
            var product = storage.Products.Where((el) =>el.Id == id).First();
            LoginedClient.products.Add(product);
            storage.Products.Remove(product);
        }
    }

}