using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Security.Cryptography;

namespace LIST_OF_THINGS {
    
    internal class Class1 {

      delegate void chengeColor();
       static  void Main(string[] args)
        {
            chengeColor change;
            static void printBlack() => Console.ForegroundColor = ConsoleColor.Black;
            static void printDarkBlue() => Console.ForegroundColor = ConsoleColor.DarkBlue;
            static void printDarkGreen() => Console.ForegroundColor = ConsoleColor.DarkGreen;
            static void printDarkCyan() => Console.ForegroundColor = ConsoleColor.DarkCyan;
            static void printDarkRed() => Console.ForegroundColor = ConsoleColor.DarkRed;
            static void printDarkMagenta() => Console.ForegroundColor = ConsoleColor.DarkMagenta;
            static void printDarkYellow() => Console.ForegroundColor = ConsoleColor.DarkYellow;
            static void printGray() => Console.ForegroundColor = ConsoleColor.Gray;
            static void printDarkGray() => Console.ForegroundColor = ConsoleColor.DarkGray;
            static void printBlue() => Console.ForegroundColor = ConsoleColor.Blue;
            static void printGeen()=> Console.ForegroundColor = ConsoleColor.Green;
            static void printCyan() => Console.ForegroundColor = ConsoleColor.Cyan;
            static void printRed() => Console.ForegroundColor = ConsoleColor.Red;
            static void printMagenta() => Console.ForegroundColor = ConsoleColor.Magenta;
            static void printYellow() => Console.ForegroundColor = ConsoleColor.Yellow;
            static void printWhite() => Console.ForegroundColor = ConsoleColor.White;
            string path_list = "main_list.txt";
            List<string> strings = new List<string>();
            List<List_of_things> list_ = new List<List_of_things>(); 
            int count = 0;
            string exit1 = "";
            while (exit1 != "4")
            {
                Console.WriteLine(
                    "[1]Основной список\n" +
                    "[2]Готовые списки\n" +
                    "[3]Выбор цвета текста консоли\n" +
                    "[4]Выход");
                exit1 = Console.ReadLine();
                if (exit1 == "4")
                {
                    return;
                }
                switch (exit1)
                {                                         
                   case "1":
                        Console.Clear();
                        string exit3 = "";
                        while (exit3 != "3")
                        {
                            Console.WriteLine("[1]Добавить в основной список\n[2]Количество в основном списке\n[3]Выход");
                            exit3 = Console.ReadLine();
                            Console.Clear();
                            if (exit3 == "3")
                            {
                                break;
                            }
                            switch (exit3)
                            {
                                case "1":
                                    using (StreamWriter sw = new StreamWriter(path_list, true))
                                    {
                                        Console.WriteLine("Если закончили добавление, нажмите 0");
                                        string ex = " ";
                                        
                                        while (ex != "0")
                                        {

                                            ex = Console.ReadLine();
                                            if (ex == "0")
                                            {
                                                Console.Clear();
                                                break;
                                            }
                                            sw.WriteLine(ex);
                                        }           
                                    }
                                    break ;
                                    case "2":                             
                                    using (StreamReader reader = new StreamReader (path_list))
                                    {
                                        count = 0;
                                        string? line;
                                        while ((line = reader.ReadLine()) != null)
                                        {
                                           strings.Add(line);
                                           Console.WriteLine(line);
                                           count++;                                                         
                                        }                                        
                                    }
                                    Console.WriteLine($"В основном списке: {count} вещей");
                                   
                                   
                                    break ;
                                case "3":
                                    Console.Clear();
                                break ;
                                default:break ;
                            }
                        }
                        break;
                        case "2":
                        string exit2 = "";
                        while (exit2 != "7")
                        {
                           
                            Console.WriteLine("" +
                           "[1] Новый список\n"+
                           "[2] Добавить элемент в список\n" +
                           "[3] Копирование файла\n"+
                           "[4] Удалить файл\n"+
                           "[5] Очистить список\n"+
                           "[6] Вывести список на экран\n"+
                           "[7] Выход\n");
                           exit2 = Console.ReadLine();
                                            
                            Console.Clear();
                            if (exit2 == "7")
                            {
                                break;
                            }
                            switch (exit2)
                            {
                                case "1":
                                    Console.WriteLine("введите название списка: ");
                                    string path_new_list = (Console.ReadLine()) + ".txt";
                                    using (StreamWriter writer = new StreamWriter(path_new_list, true)) ;

                                    break;
                                case "2":
                                    using (StreamReader reader = new StreamReader(path_list))
                                    {
                                        string? line;
                                        while ((line = reader.ReadLine()) != null)
                                        {
                                            strings.Add(line);
                                        }
                                    }
                                    Console.WriteLine("Введите название списка: ");
                                    string path_spisok = (Console.ReadLine()) + ".txt";
                                    Console.WriteLine("Введите номер предмета который,хотите добавить в список и нажмите Enter," +
                                        "\nДля выхода нажмите '0'");
                                    for (int i = 0; i < strings.Count(); i++)
                                    {
                                        Console.WriteLine("[" + (i + 1) + "]" + strings[i]);
                                    }
                                    using (StreamWriter writer = new(path_spisok, true))
                                    {
                                        while (true)
                                        {
                                            int num = int.Parse(Console.ReadLine());
                                            try
                                            {
                                                if (num == 0)
                                                {
                                                    break;
                                                }
                                                writer.WriteLine(strings[num - 1]);
                                            }
                                            catch
                                            {
                                                Console.WriteLine("Ой, что то пошло не так");
                                            }
                                        }
                                        writer.Close();

                                    }

                                    break;
                                case "3":
                                    Console.WriteLine("Введите название файла который хотите скопировать: ");
                                    string path_copy1 = (Console.ReadLine()) + ".txt";
                                    string path_copy = "Копия_" + path_copy1;
                                    File.Copy(path_copy1, path_copy, true);
                                    Console.WriteLine("готово");
                                    break;
                                case "4":
                                    Console.WriteLine("Введите название файла который хотите удалить: ");
                                    string path_delete = (Console.ReadLine()) + ".txt";
                                    File.Delete(path_delete);
                                    Console.WriteLine("Файл " + path_delete + " удален");
                                    break;


                                case "5":
                                    Console.WriteLine("введите название списка: ");
                                    string path_clear = (Console.ReadLine()) + ".txt";
                                    using (StreamWriter writer = new StreamWriter(path_clear, false));
                                    break;

                                case "6":
                                    string path_txt=(Directory.GetCurrentDirectory());
                                    DirectoryInfo dir = new DirectoryInfo(path_txt);
                                    foreach (FileInfo files in dir.GetFiles("*.txt"))
                                    {

                                        Console.WriteLine("---> " + files.Name);

                                    }


                                    Console.WriteLine("введите название списка: ");
                                    string path_read = (Console.ReadLine()) + ".txt";
                                    
                                   
                                        using (StreamReader op = new StreamReader(path_read))
                                        {
                                            string? line;
                                            while ((line = op.ReadLine()) != null)
                                            {
                                                strings.Add(line);
                                            }

                                        }

                                        for (int i = 0; i < strings.Count(); i++)
                                        {
                                            Console.WriteLine((i + 1) + " - " + strings[i]);
                                        }

                                        strings.Clear();
                                    Console.WriteLine("Для выхода нажмите --> 0");
                                        string ex2 = "";
                                        ex2 = Console.ReadLine();
                                        if (ex2 == "0")
                                        {
                                            Console.Clear();
                                            break;
                                        }
                                      
                                    
                                    
                                    
                                    break;
                                case "7":
                                   
                                    break;
                                //Console.Clear();
                                default: break;
                            }

                        }
                        break ;
                        ///
                    case "3":
                        string exit_color = "";
                        while (exit_color != "0")
                        {
                            Console.WriteLine(
                                "[1] Black\n" +
                                "[2] DarkBlue\n" +
                                "[3] DarkGreen\n" +
                                "[4] DarkCyan\n" +
                                "[5] DarkRed\n" +
                                "[6] DarkMagenta\n" +
                                "[7] DarkYellow\n" +
                                "[8] Gray\n" +
                                "[9] DarkGray\n" +
                                "[10] Blue\n" +
                                "[11] Green\n" +
                                "[12] Cyan\n" +
                                "[13] Red\n" +
                                "[14] Magenta\n" +
                                "[15] Yellow\n" +
                                "[16] White\n" +
                                "[0] Выход\n");
                            exit_color = Console.ReadLine();
                            Console.Clear();
                            if (exit_color == "0")
                            {
                                Console.Clear();
                                break;
                            }
                            switch (exit_color)
                            {
                                case "1":
                                    change = printBlack;
                                    change();
                                    Console.Clear();
                                    break;
                                case "2":
                                    change = printDarkBlue;
                                    change();
                                    Console.Clear();
                                    break;
                                case "3":
                                    change = printDarkGreen;
                                    change();
                                    Console.Clear();
                                    break;
                                case "4":
                                    change = printDarkCyan;
                                    change();
                                    Console.Clear();
                                    break;
                                case "5":
                                    change = printDarkRed;
                                    change();
                                    Console.Clear();
                                    break;
                                case "6":
                                    change = printDarkMagenta;
                                    change();
                                    Console.Clear();
                                    break;
                                case "7":
                                    change = printDarkYellow;
                                    change();
                                    Console.Clear();
                                    break;
                                case "8":
                                    change = printGray;
                                    change();
                                    Console.Clear();
                                    break;
                                case "9":
                                    change = printDarkGray;
                                    change();
                                    Console.Clear();
                                    break;
                                case "10":
                                    change = printBlue;
                                    change();
                                    Console.Clear();
                                    break;
                                case "11":
                                    change = printGeen;
                                    change();
                                    Console.Clear();
                                    break;
                                case "12":
                                    change = printCyan;
                                    change();
                                    Console.Clear();
                                    break;
                                case "13":
                                    change = printRed;
                                    change();
                                    Console.Clear();
                                    break;
                                case "14":
                                    change = printMagenta;
                                    change();
                                    Console.Clear();
                                    break;
                                case "15":
                                    change = printYellow;
                                    change();
                                    Console.Clear();
                                    break;
                                case "16":
                                    change = printWhite;
                                    change();
                                    Console.Clear();
                                    break;
                                case "0":
                                    break;
                           }

                        }
                        break;
                    case "4":

                       break;
                       default:break;

                }

            }

        }

    }

}