using System;
using System.Collections.Generic;
using System.Text;

namespace Storage_CourseWork.Services
{
    class Menu
    {
        ClientService autorization = new ClientService();
        public Menu()
        {
            GlobalMenu();
        }
        public void GlobalMenu()
        {
            autorization.LoadProducts();
            autorization.LoadClients();
            autorization.LoadStat();
            Console.WriteLine(@"                                                                                                    
                       ░██████╗████████╗░█████╗░██████╗░░█████╗░░██████╗░███████╗  ░█████╗░██████╗░██████╗░
                       ██╔════╝╚══██╔══╝██╔══██╗██╔══██╗██╔══██╗██╔════╝░██╔════╝  ██╔══██╗██╔══██╗██╔══██╗
                       ╚█████╗░░░░██║░░░██║░░██║██████╔╝███████║██║░░██╗░█████╗░░  ███████║██████╔╝██████╔╝
                       ░╚═══██╗░░░██║░░░██║░░██║██╔══██╗██╔══██║██║░░╚██╗██╔══╝░░  ██╔══██║██╔═══╝░██╔═══╝░
                       ██████╔╝░░░██║░░░╚█████╔╝██║░░██║██║░░██║╚██████╔╝███████╗  ██║░░██║██║░░░░░██║░░░░░
                       ╚═════╝░░░░╚═╝░░░░╚════╝░╚═╝░░╚═╝╚═╝░░╚═╝░╚═════╝░╚══════╝  ╚═╝░░╚═╝╚═╝░░░░░╚═╝░░░░░");
            int select = 0;
            do
            {
                Console.WriteLine("\n\n\t\t\t You are in Storage Terminal\n\n\t\t\tWho are you?\n\n1. Client\n" +
                    "2. Manager\n" +
                    "3. Worker\n" +
                    "0. Exit\n");
                while (true)
                {
                    try
                    {
                        do
                        {
                            select = Convert.ToInt32(Console.ReadLine());
                            if (select < 0 || select > 3)
                            {
                                Console.WriteLine("Incorrect case of menu, try again!\n");
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
                        Console.Clear();
                        ClientMenu();
                        break;
                    case 2:
                        Console.Clear();
                        if (autorization.SingInManager())
                        {
                            ManagerMenu();
                        }
                        break;
                    case 3:
                        Console.Clear();
                        if (autorization.SingInWorker())
                        {
                            WorkerMenu();
                        }
                        break;
                }
            } while (select != 0);
            autorization.SaveClients();
            autorization.SaveProducts();
            autorization.SaveStat();
        }
        public void WorkerMenu()
        {
            Console.Clear();
            int select = 0;
            do
            {
                Console.WriteLine("1. How much places left?\n" +
                    "2. Show products on storage\n" +
                    "0. Exit\n\n");
                while (true)
                {
                    try
                    {
                        do
                        {
                            select = Convert.ToInt32(Console.ReadLine());
                            if (select < 0 || select > 2)
                            {
                                Console.WriteLine("Incorrect case of menu, try again!\n");
                            }
                        } while (select < 0 || select > 2);
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
                        Console.Clear();
                        Console.WriteLine($"Places left: {autorization.PlacesLeft()}");
                        Console.WriteLine("\nPress any button to continue \"instead turn off button :)\"");
                        Console.ReadKey();
                        Console.WriteLine("\n\n");
                        break;
                    case 2:
                        Console.Clear();
                        autorization.ShowProductsOnStorage();
                        Console.WriteLine("\nPress any button to continue \"instead turn off button :)\"");
                        Console.ReadKey();
                        Console.WriteLine("\n\n");
                        break;
                }


            } while (select != 0);
            Console.Clear();
        }
        public void ClientMenu()
        {
            int select = 0;
            do
            {
                Console.Clear();
                Console.WriteLine("Select option:\n" +
                    "1. Create accountn\n" +
                    "2. Sign in\n" +
                    "0. Back to main menu\n");
                while (true)
                {
                    try
                    {
                        do
                        {
                            select = Convert.ToInt32(Console.ReadLine());
                            if (select < 0 || select > 3)
                            {
                                Console.WriteLine("Incorrect case of menu, try again!\n");
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
                        Console.Clear();
                        autorization.CreateAcc();
                        break;
                    case 2:
                        RepeatMenu();
                        break;
                }

            } while (select != 0);
            Console.Clear();
        }
        public void ManagerMenu()
        {
            int select = 0;
            do
            {
                Console.Clear();
                Console.WriteLine("Select option:\n" +
                    "1. Show Clients\n" +
                    "2. Show products on storage \n" +
                    "3. Show stat\n" +
                    "4. Remove Client\n" +
                    "0. Back to main menu\n");
                while (true)
                {
                    try
                    {
                        do
                        {
                            select = Convert.ToInt32(Console.ReadLine());
                            if (select < 0 || select > 4)
                            {
                                Console.WriteLine("Incorrect case of menu, try again!\n");
                            }
                        } while (select < 0 || select > 4);
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
                        Console.Clear();
                        autorization.ShowClients();
                        Console.WriteLine("\nPress any button to continue \"instead turn off button :)\"");
                        Console.ReadKey();
                        break;
                    case 2:
                        Console.Clear();
                        autorization.ShowProductsOnStorage();
                        Console.WriteLine("\nPress any button to continue \"instead turn off button :)\"");
                        Console.ReadKey();
                        break;
                    case 3:
                        Console.Clear();
                        autorization.ShowStatOfStorage();
                        Console.WriteLine("\nPress any button to continue \"instead turn off button :)\"");
                        Console.ReadKey();
                        break;
                    case 4:
                        Console.Clear();
                        autorization.RemoveClient();
                        break;
                }

            } while (select != 0);
            Console.Clear();
        }
        public void RepeatMenu()
        {
            Console.Clear();
            int select = 0;
            if (autorization.SignIn())
            {
                do
                {
                    Console.WriteLine("1. Give product\n2. Take product\n3. Show my products\n0. Back to main menu\n\n");
                    while (true)
                    {
                        try
                        {
                            do
                            {
                                select = Convert.ToInt32(Console.ReadLine());
                                if (select < 0 || select > 3)
                                {
                                    Console.WriteLine("Incorrect case of menu, try again!\n");
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
                            Console.Clear();
                            if (autorization.IsFull())
                            {
                                Console.WriteLine("Sory, we dont have place for your product, try again later...");
                            }
                            else
                            {
                                autorization.GiveProductForSaving();
                                Console.WriteLine("\nPress any button to continue \"instead turn off button :)\"");
                                Console.ReadKey();
                                Console.WriteLine("\n\n");
                            }
                            break;
                        case 2:
                            Console.Clear();
                            autorization.TakeProduct();
                            Console.Clear();
                            Console.WriteLine("\nPress any button to continue \"instead turn off button :)\"");
                            Console.ReadKey();
                            Console.WriteLine("\n\n");
                            break;
                        case 3:
                            Console.Clear();
                            autorization.ShowProductsOfClient();
                            Console.WriteLine("\nPress any button to continue \"instead turn off button :)\"");
                            Console.ReadKey();
                            Console.WriteLine("\n\n");
                            break;
                    }
                } while (select != 0);
            }
            else
            {
                Console.Clear();
                Console.WriteLine("1. Try again\n" +
                    "2. Back\n");
                while (true)
                {
                    try
                    {
                        do
                        {
                            select = Convert.ToInt32(Console.ReadLine());
                            if (select < 0 || select > 2)
                            {
                                Console.WriteLine("Incorrect case of menu, try again!\n");
                            }
                        } while (select < 0 || select > 2);
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
                        Console.Clear();
                        RepeatMenu();
                        break;
                    case 2:
                        select = 0;
                        break;

                }
            }
        }


    }
}
