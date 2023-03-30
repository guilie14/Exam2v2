using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ConsoleApp2.Class1;

namespace ConsoleApp2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Hashtable enemies = new Hashtable();
            while (true)
            {
                Console.WriteLine("\nPlease select an option:");
                Console.WriteLine("==================================");
                Console.WriteLine("1. Insert new enemy...");
                Console.WriteLine("2. Display all the enemy list...");
                Console.WriteLine("3. Calculate the enemy damage....");
                Console.WriteLine("4. Find enemy...");
                Console.WriteLine("5. Exit");
                Console.WriteLine("==================================");
                Console.Write("Option: ");

                int choice;
                if (!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.WriteLine("Invalid choice! Please enter a number between 1 and 5.");
                    continue;
                }

                switch (choice)
                {
                    case 1:
                        Enemy newEnemy = new Enemy();

                        Console.WriteLine("Insert new enemy...");

                        Console.Write("Input new ID: ");
                        newEnemy.Id = Convert.ToInt64(Console.ReadLine());

                        Console.Write("Input enemy name: ");
                        newEnemy.Name = Console.ReadLine();

                        Console.Write("Input enemy type: ");
                        newEnemy.Type = (Enemy_Type)Convert.ToInt32(Console.ReadLine());

                        Console.Write("Input enemy health: ");
                        newEnemy.Health = int.Parse(Console.ReadLine());

                        Console.Write("Input enemy AttackType: ");
                        newEnemy.Attack = (Attack_Type)Convert.ToInt32(Console.ReadLine());
                     
                        for (int i = 0; i < 4; i++)
                        {
                            Console.Write("Input Damge {0}: ", i + 1);
                            newEnemy[i] = float.Parse(Console.ReadLine());
                        }
                        enemies.Add(newEnemy.Id, newEnemy);

                        break;
                    case 2:
                        Console.WriteLine("========== List of Enemy ==========");
                        foreach (Enemy e in Enemy.Values)
                        {
                            e.ShowInfo();
                        }
                        break;
                    case 3:
                        Console.WriteLine("========== Calculate the enemy damage ==========");
                        foreach (Enemy e in Enemy.Values)
                        {
                            e.CalDamage();
                            e.ShowInfo();
                        }
                        break;
                    case 4:
                        Console.WriteLine("=======================Find====================");
                        Console.WriteLine("1. Find by ID...");
                        Console.WriteLine("2. Health <50...");
                        Console.WriteLine("3. 30<Damge<100...");
                        Console.WriteLine("4. Not Boss type and not range...");
                        Console.WriteLine("5. Quit...");
                        Console.WriteLine("===============================================");
                        Console.Write("Choice: ");

                        int choice2 = int.Parse(Console.ReadLine());
                        if (!int.TryParse(Console.ReadLine(), out choice2))
                        {
                            Console.WriteLine("Invalid choice! Please enter a number between 1 and 5.");
                            continue;
                        }
                        if (choice2 == 1)
                        {
                                int ID = Convert.ToInt32(Console.ReadLine());
                                foreach (Enemy e in enemies.Values)
                                {
                                    if (e.Id == ID)
                                    {
                                        e.ShowInfo();
                                    }
                                }
                        }
                        if (choice2 == 2)
                        {
                            foreach (Enemy e in enemies.Values)
                            {
                                if (e.Health < 50)
                                {
                                    e.ShowInfo();
                                }
                            }
                        }
                        if (choice2 == 3)
                        {
                            foreach (Enemy e in enemies.Values)
                            {
                                if (e.Damage < 100 & e.Damage > 30)
                                {
                                    e.ShowInfo();
                                }
                            }
                        }
                        if (choice2 == 4)
                        {
                            foreach (Enemy e in enemies.Values)
                            {
                                if (e.Type != Enemy_Type.BOSS & e.Attack != Attack_Type.RANGE)
                                {
                                    e.ShowInfo();
                                }
                            }
                        }
                        if (choice == 5)
                        {
                            break;
                        }
                        break;
                    case 5:
                        Console.WriteLine("Exiting program...");
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid choice! Please enter a number between 1 and 5.");
                        break;
                }
                var Type = (Enemy_Type)Convert.ToInt32(Console.ReadLine());

            }
        }
    }
}