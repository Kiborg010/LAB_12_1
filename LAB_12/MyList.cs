using ClassLibrary1;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB_12
{
    public class MyList<T> where T : IInit, ICloneable, new()
    {
        Point<T>? begin = null;
        Point<T>? end = null;

        int count = 0;
        
        static string lineLong = new string('-', 150);

        public int Count => count;

        public void AddToBegin(T item)
        {
            T newData = (T)item.Clone();
            Point<T> newItem = new Point<T>(newData);
            count++;
            if (begin != null)
            {
                begin.Previous = newItem;
                newItem.Next = begin;
                begin = newItem;
            }
            else
            {
                begin = newItem;
                end = begin;
            }
        }

        public void AddToEnd(T item)
        {
            T newData = (T)item.Clone();
            Point<T> newItem = new Point<T>(newData);
            count++;
            if (end != null)
            {
                end.Next = newItem;
                newItem.Previous = end;
                end = newItem;
            }
            else
            {
                end = newItem;
                begin = end;
            }
        }

        public void AddTo(int index, T item)
        {
            if (index == 0)
            {
                AddToBegin(item);
            }
            else if (index >= count - 1)
            {
                AddToEnd(item);
            }
            else
            {
                count++;
                Point<T>? current = begin;
                T newData = (T)item.Clone();
                Point<T> addition = new Point<T>(newData);
                for (int i = 0; (current != null) && (i != index); i++)
                {
                    current = current.Next;
                }
                Point<T>? previous = current.Previous;
                addition.Previous = previous;
                previous.Next = addition;
                current.Previous = addition;
                addition.Next = current;
            }
        }

        public MyList() { }

        public MyList(T[] collection)
        {
            if (collection == null)
            {
                throw new Exception("empty collection: null");
            }
            if (collection.Length == 0)
            {
                throw new Exception("empty collection");
            }
            T newData = (T)collection[0].Clone();
            begin = new Point<T>(newData);
            count++;
            for (int i = 0; i < collection.Length; i++)
            {
                AddToEnd(collection[i]);
            }
        }

        public void PrintList()
        {
            if (count == 0)
            {
                Console.WriteLine("Список пуст");
            }
            Point<T>? current = begin;
            for (int i = 0; current != null; i++)
            {
                if (current.Data == null)
                {
                    Console.WriteLine("<Здесь пустой элемент>");
                }
                else
                {
                    if (current.Data is Car)
                    {
                        Car car = current.Data as Car;
                        Console.WriteLine($"Машина №{car.id.Number}");
                    }
                    Console.WriteLine(lineLong);
                    Console.WriteLine(current.Data.ToString());
                    Console.WriteLine(lineLong);
                }
                current = current.Next;
            }
        }

        public Point<T>? FirstItem()
        {
            return begin;
        }

        public Point<T>? FindItem(int year)
        {
            Point<T>? current = begin;
            while (current != null)
            {
                if (current.Data == null)
                {
                    throw new Exception("Data is null");
                }
                if (current.Data is Car)
                {
                    Car car = current.Data as Car;
                    if (car.Year == year)
                    {
                        return current;
                    }
                    current = current.Next;
                }
            }
            return null;
        }

        public bool RemoveItem(int year)
        {
            if (begin == null)
            {
                throw new Exception("Удаление невозможно, так как список пуст");
            }
            bool isDelite = false;
            while (FindItem(year) != null) 
            {
                Point<T>? pos = FindItem(year);
                if (pos == null)
                {
                    isDelite = false;
                }
                else
                {
                    count--;
                    if (begin == end)
                    {
                        begin = end = null;
                        isDelite = true;
                    }
                    else if (pos.Previous == null)
                    {
                        begin = begin?.Next;
                        begin.Previous = null;
                        isDelite = true;
                    }
                    else if (pos.Next == null)
                    {
                        end = end.Previous;
                        end.Next = null;
                        isDelite = true;
                    }
                    else
                    {
                        Point<T> next = pos.Next;
                        Point<T> previous = pos.Previous;
                        pos.Next.Previous = previous;
                        pos.Previous.Next = next;
                        isDelite = true;
                    }
                }
                
            }
            return isDelite;
        }

        public void Clear()
        {
            begin = null;
            end = null;
            count = 0;
        }

        public MyList<T> Clone()
        {
            Point<T>? current = begin;
            MyList<T> listClone = new MyList<T>();
            for (int i = 0; current != null; i++)
            {
                listClone.AddToEnd(current.Data);
                current = current.Next;
            }
            return listClone;
        }
    }
}
