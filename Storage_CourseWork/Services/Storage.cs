﻿
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace Storage_CourseWork.Services
{
    [Serializable]
    class Storage
    {
        private double cash;

        public double Cash
        {
            get { return cash; }
            set { cash = value; }
        }
        int maxPlaces = 20;
        public List<Product> Products = new List<Product>();
        public List<Client> Clients = new List<Client>();
        int valueOfClients;
        BinaryFormatter binary = new BinaryFormatter();
        static string path = "Clients.dat";

        public void AddClient(Client client)
        {
            Clients.Add(client);
        }
        public void AddProduct(Product product)
        {
            Products.Add(product);
        }
       public void ShowClients()
        {
            foreach (var item in Clients)
            {
                Console.WriteLine(item);
            }
        }

        public bool IsFull()
        {
            if (Products.Count>=maxPlaces)
            {
                return true;
            }
            return false;
        }
        public int PlacesLeft()
        {
            return maxPlaces - Products.Count;
        }
        public void ShowProductsOfClients()
        {
            foreach (var item in Clients)
            {
                item.ShowMyProducts();
            }
        }
        public void ShowProducts()
        {
            int count = 0;
            foreach (var item in Products)
            {
                Console.WriteLine($"\nProduct #{++count}\n");
                Console.WriteLine(item);
            }
        }
        public void SaveProduct()
        {
            using (FileStream fs = new FileStream("Products.dat", FileMode.OpenOrCreate))
            {
                binary.Serialize(fs, Products);
                Console.WriteLine("Serelized!");
            }
        }
        public void LoadProduct()
        {
            using (FileStream fs = new FileStream("Products.dat", FileMode.OpenOrCreate))
            {
                List<Product> deserilizeProducts = (List<Product>)binary.Deserialize(fs);
                Products = deserilizeProducts;
                Console.WriteLine("Deserelized!");

            }
        }
        public void SaveStat()
        {
            using (FileStream fs = new FileStream("Stat.dat", FileMode.OpenOrCreate))
            {
                binary.Serialize(fs, Cash);
                binary.Serialize(fs, Clients.Count);
                Console.WriteLine("Serelized!");
            }
        }
        public void LoadStat()
        {
            using (FileStream fs = new FileStream("Stat.dat", FileMode.OpenOrCreate))
            {
                double deserilizeCash = (double)binary.Deserialize(fs);
                int deserilizeCount = (int)binary.Deserialize(fs);
                Cash = deserilizeCash;
                valueOfClients = deserilizeCount;
                Console.WriteLine("Deserelized!");

            }
        }
        public void ShowStat()
        {
            double sum = 0;
            Console.WriteLine($"Value of money: {Cash}");
            foreach (var item in Products)
            {
                sum += item.Price;
            }
            Console.WriteLine($"Sum of all produts on storage: {sum}");
            Console.WriteLine($"Value of clients: {Clients.Count}");
            Console.WriteLine("Clients: ");
            foreach (var item in Clients)
            {
                Console.WriteLine(item);
            }
        }
        public void SaveClients()
        {
            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
                {
                   binary.Serialize(fs, Clients);
                    Console.WriteLine("Serelized!");
                }
        }
         public void LoadClients()
        {
            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
                {
                   List<Client>deserilizeClients = (List<Client>)binary.Deserialize(fs);
                Clients = deserilizeClients;
                Console.WriteLine("Deserelized!");
            }
        }



    }
}