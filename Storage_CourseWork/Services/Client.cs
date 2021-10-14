using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Text;


namespace Storage_CourseWork.Services
{
    interface IClient
    {
        public void ShowClient();
    }
    [Serializable]
    public class Client : IClient
    {
        public string Name { get; set; }
        public  string Surname { get; set; }
        public List<Product> products = new List<Product>();
        public string Login { get; set; }
        [Required(ErrorMessage = "Confirm Password is required")]
        [StringLength(255, ErrorMessage = "Must be between 5 and 255 characters", MinimumLength = 5)]
        public string Password { get; set; }
        static private int counter=0;
        private double money;
        int id;
        public int Id {
            get { return id; }
        }
        public string  FileName { get; set; }
        public Client()
        {
            Name = "";
            Surname = "";
            Money = 0;
            id = new Random().Next(1,1000000);
        }
        public Client(string name,string surname,double money,string log,string pass)
        {
            Name = name;
            Surname = surname;
            Money = money;
            Login = log;
            Password = pass;
            id = new Random().Next(1, 1000000);
        }
        public double Money
        {
            get { return money; }
            set { money = value<0?0:value; }
        }
        public void ShowClient()
        {
            Console.WriteLine($"Name: {Name} " +
                $"Surname {Surname} / " +
                $"Money: {Money} / " +
                $"Id: {id}");
        }
        public override string ToString()
        {
            return $"Name: {Name}, " +
                $"Surname: {Surname} / " +
                $"Money: {Money} / " +
                $"Id: {id}";
        }

        public void ShowMyProducts()
        {
            counter = 0;
            foreach (var item in products)
            {
                Console.WriteLine($"\nProduct #{++counter}\n");
                Console.WriteLine(item);
            }
        }
       


    }
}
