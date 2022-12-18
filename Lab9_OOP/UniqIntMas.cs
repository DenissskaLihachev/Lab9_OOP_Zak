using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab9_OOP
{
    internal class UniqIntMas
    {

        public int?[] arr;
        public int size;
        public delegate void HandlerEvent(string mes);
        public event HandlerEvent? Notify;

        public UniqIntMas(int size)
        {
            this.size = size;
            arr = new int?[size];
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = null;
            }
        }

        public void Add(int num)
        {
            int i;
            for (i = 0; arr[i].HasValue && i < arr.Length; i++)
            {
                if (arr[i] == num)
                {
                    Console.WriteLine($"Такой элемент уже существует");
                    return;
                }
            }
            if (i == arr.Length - 1) Console.WriteLine($"Массив заполнен");
            else
            {
                arr[i] = num;
                if (Notify != null)
                    Notify.Invoke($"Добавлен новый элемент [{num}]");
            }
        }
        public void Remove(int num)
        {
            int i;
            for (i = 0; i < arr.Length; i++)
            {
                if (arr[i] == num)
                {
                    arr[i] = null;
                    if (Notify != null)
                        Notify.Invoke($"Удалён элемент [{num}]");
                    return;
                }
            }
            if (i == arr.Length)
            {
                Console.WriteLine($"Такого элемента не существует");
            }
        }
        public void Print()
        {
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i].HasValue)
                {
                    Console.Write($"{arr[i]} ");
                }
            }
        }
    }
}
