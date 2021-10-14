using System;
using System.Collections.Generic;
using System.Text;

namespace Storage_CourseWork.Services
{ interface IProduct
    {
        public void ShowProductInfo();
    }
    [Serializable]
    public class Product : IProduct
    {
        public Client Owner { get; set; }
        public Product()
        {
            Name = "";
            Area = 0;
            TimeSave =0;
            Price = 0;
            Id = new Random().Next(1,100000000);
        }
        public Product(string name,double area,double price,int dt,Client owner)
        {
            Name = name;
            Area = area;
            Price = price;
            TimeSave = dt;
            Owner = owner;
            Id = new Random().Next(1, 100000000);
        }
        public int Id { get; set; }
        public string Name { get; set; }
        private double area;
        public double Area {
            get{return area;}
            set { area = value < 0 ? 0 : value; }
        }
        private int timeSave;
        public int TimeSave
        {
            get { return timeSave; }
            set { timeSave = value; }
        }
        private DateTime expiredDate;
        public DateTime ExpiredDate
        {
            get { return expiredDate; }
            set { expiredDate = value; }
        }
        private double price;
        public double Price
        {
            get { return price; }
            set { price = value<0?0:value; }
        }
        public void ShowProductInfo()
        {
            Console.WriteLine($"Name: {Name}\n" +
                $"Area: {Area}\n" +
                $"Time save: {TimeSave}\n" +
                $"Price of save: {Price}\n");
        }
        public override string ToString()
        {
            return $"Name: {Name}\n" +
                $"Area: {Area}\n" +
                $"Time save: {TimeSave} days\n" +
                $"Price of save: {Price}\n" +
                $"Expired date on {expiredDate}\n" +
                $"Id: {Id}\n" +
                $"Login of owner: {Owner.Login}";
        }
    }
}
