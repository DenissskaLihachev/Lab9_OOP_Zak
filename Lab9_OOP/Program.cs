using System;
using System.ComponentModel.DataAnnotations;
using System.Net.NetworkInformation;

namespace Lab9_OOP
{
	class Program
	{
		delegate bool CheckNum(int num);
		static void Main(string[] args)
		{
			while(true)
			{
				Console.Write("1) Задание 1\n2) Задание 2\nВвод: ");
				int choice = Convert.ToInt32(Console.ReadLine());
				Console.Clear();
				switch(choice)
				{
					case 1:
						{
							Task1();
							break;
						}
					case 2:
						{
							Task2();
							break;
						}
				}
			}
			
		}

		static void Task1()
		{
			CheckNum checkNum;
			bool GetEven(int num) => num % 2 == 0 ? true : false;
			bool GetPositive(int num) => num > 0 ? true : false;
			int Counting(int[] masNum, CheckNum checkNum, out int count)
			{
				count = 0;
				for (int i = 0; i < masNum.Length; i++)
				{
					if (checkNum(masNum[i]))
					{
						count++;
					}
				}
				return count;
			}
			CheckNum GetPrevious()
			{
				Console.Write("Числа меньше заданного (введите число): ");
				int numLess = Convert.ToInt32(Console.ReadLine());
				bool check;
				bool Less(int num)
				{
					check = false;
					check = num < numLess ? true : false;
					return check;
				}
				return Less;
			}

			checkNum = GetEven;
			int[] mas = new int[10];
			Random rand = new Random();

			Console.Write("Массив [");
			for (int i = 0; i < mas.Length; i++)
			{
				mas[i] = rand.Next(-10, 10);
				Console.Write($" {mas[i]} ");
			}
			Console.WriteLine("]");


			Console.WriteLine("Чётных чисел: " + Counting(mas, checkNum, out int count));
			checkNum = GetPositive;
			Console.WriteLine($"Положительные числа: " + Counting(mas, checkNum, out count));
			checkNum = GetPrevious();
			Console.WriteLine("Числа меньше введенного: " + Counting(mas, checkNum, out count));
			Console.ReadKey(); Console.Clear();
		}
		static void Task2()
		{
			void PrintEvent(string message) => Console.WriteLine(message);
			int size;

			Console.Write("Введите размер массива: "); size = Convert.ToInt32(Console.ReadLine());
			Console.Clear();

			UniqIntMas obj = new UniqIntMas(size);

			Console.Write("Хотите ли вы получать уведомления о действиях?\n1) Да\n2) Нет\nВвод: "); int eve = Convert.ToInt32(Console.ReadLine()); Console.Clear();
			switch(eve)
			{
				case 1:
					{
                        obj.Notify += PrintEvent;
                        break;
					}
				case 2:
					{

						break;
					}
			}

			while (true)
			{
				Console.Clear();

				Console.Write("1) Добавить элемент\n2) Удалить элемент\n3) Вывести массив\n0) Выйти\nВвод: ");
				int choice = Convert.ToInt32(Console.ReadLine()); Console.Clear();

                switch (choice)
				{
					case 1:
						{							
							Console.Write("Введите число: ");
							int num = Convert.ToInt32(Console.ReadLine());
							obj.Add(num);
							Console.ReadKey();
							break;
						}
					case 2:
						{
							Console.Write("Введите число: ");
							int num = Convert.ToInt32(Console.ReadLine());
							obj.Remove(num);
							Console.ReadKey();
							break;
						}
					case 3:
						{
							Console.Write("Массив: [ ");
							obj.Print();
                            Console.Write("]");
                            Console.ReadKey();
							break;
						}
				}
				if (choice == 0)
					break;
			}
            Console.Clear();
        }
	}
}
