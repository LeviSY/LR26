using System;

namespace LR26
{
    class Program
    {
        static void Main(string[] args)
        {
            Main main = new Main();

        a:
            main.menu();

            while (true)
            {
                string command = Console.ReadLine();
                if (command == "Exit")
                {
                    break;
                }

                switch (command)
                {
                    case "1":
                        {
                            main.datas();
                            Console.ReadKey();
                            goto a;
                        }
                    case "2":
                        {
                            main.output();
                            Console.ReadKey();
                            goto a;
                        }
                }
            }
        }
    }
}
