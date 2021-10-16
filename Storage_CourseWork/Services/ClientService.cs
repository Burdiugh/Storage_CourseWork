using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Text.RegularExpressions;

namespace Storage_CourseWork.Services
{
    public class ClientService
    {
        public Client LoginedClient { get; set; } = null;
        Storage storage = new Storage();
        string patternPassword = @"(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}";


        public void CreateAcc()
        {
            var regexPass = new Regex(patternPassword);
            Console.Write("Enter the name: ");
            string name = Console.ReadLine();
            Console.Write("Enter the surname: ");
            string surname = Console.ReadLine();
            Console.Write("How much money do you have? : ");
            double money = 0;
            while (true)
            {
                try
                {
                    money = Convert.ToDouble(Console.ReadLine());
                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex.Message);
                    continue;
                }
                break;
            }
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
                if (!regexPass.IsMatch(password))
                {
                    Console.WriteLine("\nEasy password!\n");
                }
            } while (!regexPass.IsMatch(password));
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
                if (login == "admin123" && password == "admin228")
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
                if (login == "Worker333" && password == "Workerpro")
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

        public bool RemoveClient()
        {
            Console.Clear();
            ShowClients();
            Console.Write("\n\nEnter the id of client to remove: ");
            int id = 0;
            while (true)
            {
                try
                {
                    id = Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    continue;
                }
                break;
            }
            var result = storage.Clients.Where(i => i.Id == id);
            foreach (var item in result.ToList())
            {
                Console.WriteLine($"\nDeleted: {item}\n");
                storage.Clients.Remove(item);
                return true;
            }
            return false;
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
                if (login.Length < 4)
                {
                    Console.WriteLine("\nYour Login must have more than 3 letters or digits\n");
                }
            } while (login.Length < 4);
            Console.Write("Enter password: ");
            string password = Console.ReadLine();
            Console.Clear();
            if (storage.Clients.Any(el => el.Login == login))
            {
                if (storage.Clients.Where(el => el.Login == login).First().Password == password)
                {
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
        public void ShowProductsOfClient()
        {
            int count = 0;
            foreach (var item in LoginedClient.products)
            {
                Console.WriteLine($"Product #{++count}\n");
                Console.WriteLine(item);
            }
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
            while (true)
            {
                try
                {
                    Console.Write("Enter the area of product: ");
                    area = Convert.ToDouble(Console.ReadLine());
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    continue;
                }
                break;
            }
            while (true)
            {
                try
                {
                    Console.Write("Hom much days do you want to save? : ");
                    days = Convert.ToInt32(Console.ReadLine());

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    continue;
                }
                break;
            }

            price = area * (double)days * 8;
            Product product = new Product(name, area, price, days, LoginedClient);
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
            int select = 0;
            storage.ShowProductsOfClientsOnStorage(LoginedClient);
            Console.Write("\n\nEnter id: ");
            int id = 0;
            while (true)
            {
                try
                {
                    id = Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    continue;
                }
                break;
            }
            if (!storage.Products.Any((el) => el.Id == id))
            {
                Console.WriteLine("There aren`t products with such id\n\n");
                Console.WriteLine("1. Try again\n2. Back");
                while (true)
                {
                    try
                    {
                        do
                        {
                            select = Convert.ToInt32(Console.ReadLine());
                            if (select < 0 || select > 3)
                            {
                            }
                            
                        } while (select < 0 || select > 3);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        continue;
                    }
                    break;
                }
                switch (select)
                {
                    case 1:
                        while (true)
                        {
                            try
                            {
                                id = Convert.ToInt32(Console.ReadLine());
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.Message);
                                continue;
                            }
                            break;
                        }
                        break;
                    case 2:

                        break;

                }
                
            }
            var product = storage.Products.Where((el) => el.Id == id).First();
            if (product.Owner.Login == LoginedClient.Login)
            {
                LoginedClient.products.Add(product);
                storage.Products.Remove(product);
                return;
            }
            Console.WriteLine("Please, enter correct Id!");

        }
    }

}