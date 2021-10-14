using Storage_CourseWork.Services;
using System;

namespace Storage_CourseWork
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                new Menu();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
