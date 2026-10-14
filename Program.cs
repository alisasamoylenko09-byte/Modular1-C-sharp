using System;
using System.Collections.Generic;

namespace GraphTaskMenu
{
    class Program
    {
        static void Main(string[] args)
        {
            // Налаштування для коректного відображення українських літер в консолі
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.InputEncoding = System.Text.Encoding.UTF8;

            bool isRunning = true;

            while (isRunning)
            {
                Console.WriteLine("\n==========================================");
                Console.WriteLine("                 АНАЛІЗ ГРАФА            ");
                Console.WriteLine("==========================================");
                Console.WriteLine("1. Провести аналіз суміжних вершин для 'C'");
                Console.WriteLine("0. Вихід з програми");
                Console.WriteLine("==========================================");
                Console.Write("Виберіть пункт меню: ");

                string choice = Console.ReadLine();
                Console.WriteLine();

                if (choice == "1")
                {
                    RunGraphAnalysis();
                }
                else if (choice == "0")
                {
                    Console.WriteLine("Дякую за використання програми! До побачення.");
                    isRunning = false;
                }
                else
                {
                    Console.WriteLine("Невірний вибір! Будь ласка, введіть 1 або 0.");
                }
            }
        }

        static void RunGraphAnalysis()
        {
            Console.WriteLine("--- Виконання аналізу матриці суміжності ---");

            // Вершини графа
            char[] vertices = { 'A', 'B', 'C', 'D', 'E' };

            // Матриця суміжності згідно із завданням
            int[,] matrix = {
                { 0, 0, 1, 0, 0 }, // A
                { 0, 0, 0, 1, 1 }, // B
                { 1, 0, 0, 0, 0 }, // C
                { 0, 1, 1, 0, 0 }, // D
                { 0, 0, 0, 0, 1 }  // E
            };

            // Виводимо саму матрицю для наочності
            Console.WriteLine("\nЗадана матриця суміжності:");
            Console.WriteLine("    A  B  C  D  E");
            for (int i = 0; i < vertices.Length; i++)
            {
                Console.Write($"{vertices[i]} | ");
                for (int j = 0; j < vertices.Length; j++)
                {
                    Console.Write($"{matrix[i, j]}  ");
                }
                Console.WriteLine();
            }

            int targetIndex = Array.IndexOf(vertices, 'C');

            List<char> outgoing = new List<char>(); // Виходячі ребра (рядок C)
            List<char> incoming = new List<char>(); // Вхідні ребра (стовпець C)

            // Аналізуємо рядок C (виходячі)
            for (int j = 0; j < vertices.Length; j++)
            {
                if (matrix[targetIndex, j] == 1)
                {
                    outgoing.Add(vertices[j]);
                }
            }

            // Аналізуємо стовпець C (вхідні)
            for (int i = 0; i < vertices.Length; i++)
            {
                if (matrix[i, targetIndex] == 1)
                {
                    incoming.Add(vertices[i]);
                }
            }

            // Виводимо результати
            Console.WriteLine("\n---------------------------------------------");
            Console.WriteLine("Результати для вершини C:");
            Console.WriteLine("Вихідні суміжні вершини: " + (outgoing.Count > 0 ? string.Join(", ", outgoing) : "немає"));
            Console.WriteLine("Вхідні суміжні вершини: " + (incoming.Count > 0 ? string.Join(", ", incoming) : "немає"));

            // Загальний об'єднаний список
            List<char> allAdjacent = new List<char>(outgoing);
            foreach (var v in incoming)
            {
                if (!allAdjacent.Contains(v)) allAdjacent.Add(v);
            }
            Console.WriteLine("Загалом суміжні вершини до C: " + string.Join(", ", allAdjacent));
            Console.WriteLine("---------------------------------------------");
        }
    }
}