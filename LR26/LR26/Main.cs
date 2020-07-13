using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace LR26
{
    class Main
    {
        string BirthPath = @"C:\Users\Levi\source\repos\LR26\LR26\data\BirthDate.txt";
        string NamePath = @"C:\Users\Levi\source\repos\LR26\LR26\data\NameSurname.txt";
        string ZodiacPath = @"C:\Users\Levi\source\repos\LR26\LR26\data\Zodiac.txt";

        public int Z = 0;
        public void datas()
        {
            ZNAK[] znaks = new ZNAK[1];
            for (int i = 0; i < znaks.Length; i++)
            {
                Console.Clear();
                ZNAK znk = new ZNAK();
                Console.WriteLine("Введите имя и фамилию: ");
                znk.NameSurname = Console.ReadLine();
                a:
                Console.WriteLine("Введите знак зодиака: ");
                string zs = Console.ReadLine();
                switch (zs)
                {
                    case "Овен":
                        znk.ZodiacSign = Zodiacs.Aries;
                        break;
                    case "Телец":
                        znk.ZodiacSign = Zodiacs.Taurus;
                        break;
                    case "Близнецы":
                        znk.ZodiacSign = Zodiacs.Gemini;
                        break;
                    case "Рак":
                        znk.ZodiacSign = Zodiacs.Cancer;
                        break;
                    case "Лев":
                        znk.ZodiacSign = Zodiacs.Leo;
                        break;
                    case "Дева":
                        znk.ZodiacSign = Zodiacs.Virgo;
                        break;
                    case "Весы":
                        znk.ZodiacSign = Zodiacs.Libra;
                        break;
                    case "Скорпион":
                        znk.ZodiacSign = Zodiacs.Scorpio;
                        break;
                    case "Стрелец":
                        znk.ZodiacSign = Zodiacs.Sagittarius;
                        break;
                    case "Козерог":
                        znk.ZodiacSign = Zodiacs.Capricorn;
                        break;
                    case "Водолей":
                        znk.ZodiacSign = Zodiacs.Aquarius;
                        break;
                    case "Рыбы":
                        znk.ZodiacSign = Zodiacs.Pisces;
                        break;
                    default:
                        Console.Write("НЕПРАВИЛЬНЫЙ ЗОДИАК");
                        goto a;
                }
                znk.DateOfdBirth = new int[3];
                Console.Write("Введите год: ");
                znk.DateOfdBirth[0] = Convert.ToInt32(Console.ReadLine());
                string Y = Convert.ToString(znk.DateOfdBirth[0]);
                Console.Write("Введите месяц: ");
                znk.DateOfdBirth[1] = Convert.ToInt32(Console.ReadLine());
                string M = Convert.ToString(znk.DateOfdBirth[1]);
                Console.Write("Введите день: ");
                znk.DateOfdBirth[2] = Convert.ToInt32(Console.ReadLine());
                string D = Convert.ToString(znk.DateOfdBirth[2]);
                znaks[i] = znk;

                using (StreamWriter sw = new StreamWriter(BirthPath, true))
                {
                    sw.WriteLine(Y + "." + M + "." + D);
                }
                using (StreamWriter sw = new StreamWriter(NamePath, true))
                {
                    sw.WriteLine(znk.NameSurname);
                }
                using (StreamWriter sw = new StreamWriter(ZodiacPath, true))
                {
                    sw.WriteLine(zs);
                }
            }
        }

        public void output()
        {
            int Z = 0;

            StreamReader sr1 = new StreamReader(BirthPath);
            List<string> Birth = new List<string>();
            while (!sr1.EndOfStream)
            {
                Birth.Add(sr1.ReadLine());
            }

            StreamReader sr2 = new StreamReader(NamePath);
            List<string> Name = new List<string>();
            while (!sr2.EndOfStream)
            {
                Name.Add(sr2.ReadLine());
            }

            StreamReader sr3 = new StreamReader(ZodiacPath);
            List<string> Zodiac = new List<string>();
            while (!sr3.EndOfStream)
            {
                Z++;
                 Zodiac.Add(sr3.ReadLine());
            }
            

            Console.WriteLine("Введите зодиак: ");
            string Sign = Console.ReadLine();
            for (int i = 0; i < Z; i++)
            {
                if(Sign == Zodiac[i])
                {
                    Console.WriteLine(Name[i] + ", " + Birth[i] + ", " + Zodiac[i]);
                }
            } 

        } 

        public void menu()
        {
            Console.Clear();
            Console.WriteLine("        Выберите действие!          ");
            Console.WriteLine("====================================");
            Console.WriteLine("1) Внести свои данные");
            Console.WriteLine("2) Получить информацию пользователях");
            Console.WriteLine("====================================");
            Console.WriteLine("      Для выхода введите - Exit     ");
        }

        public enum Zodiacs
        {
            Aries,
            Taurus,
            Gemini,
            Cancer,
            Leo,
            Virgo,
            Libra,
            Scorpio,
            Sagittarius,
            Capricorn,
            Aquarius,
            Pisces
        }

        public struct ZNAK : IComparable
        {
            public string NameSurname;
            public Zodiacs ZodiacSign;
            public int[] DateOfdBirth;

            public int CompareTo(object obj)
            {
                ZNAK com = (ZNAK)obj;
                DateTime dt1 = new DateTime(this.DateOfdBirth[0], this.DateOfdBirth[1], this.DateOfdBirth[2]);
                DateTime dt2 = new DateTime(com.DateOfdBirth[0], com.DateOfdBirth[1], com.DateOfdBirth[2]);
                return dt1.CompareTo(dt2);
            }
        }

    }
}
