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
        Point<Car>? begin = null;
        Point<Car>? end = null;

        int count = 0;
        
        static string lineLong = new string('-', 150);

        public int Count => count;

        public void AddToBegin(Car item)
        {
            Car newData = (Car)item.Clone();
            Point<Car> newItem = new Point<Car>(newData);
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

        public void AddToEnd(Car item)
        {
            Car newData = (Car)item.Clone();
            Point<Car> newItem = new Point<Car>(newData);
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

        public void AddTo(int index, Car item)
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
                Point<Car>? current = begin;
                Car newData = (Car)item.Clone();
                Point<Car> addition = new Point<Car>(newData);
                for (int i = 0; (current != null) && (i != index); i++)
                {
                    current = current.Next;
                }
                Point<Car>? previous = current.Previous;
                addition.Previous = previous;
                previous.Next = addition;
                current.Previous = addition;
                addition.Next = current;
            }
        }

        public MyList() { }

        public MyList(Car[] collection)
        {
            if (collection == null)
            {
                throw new Exception("empty collection: null");
            }
            if (collection.Length == 0)
            {
                throw new Exception("empty collection");
            }
            Car newData = (Car)collection[0].Clone();
            begin = new Point<Car>(newData);
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
            Point<Car>? current = begin;
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

        public Point<Car>? FirstItem()
        {
            return begin;
        }

        public Point<Car>? FindItem(int year)
        {
            Point<Car>? current = begin;
            while (current != null)
            {
                if (current.Data == null)
                {
                    throw new Exception("Data is null");
                }
                if (current.Data.Year == year)
                {
                    return current;
                }
                current = current.Next;
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
                Point<Car>? pos = FindItem(year);
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
                        Point<Car> next = pos.Next;
                        Point<Car> previous = pos.Previous;
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

        public MyList<Car> Clone()
        {
            Point<Car>? current = begin;
            MyList<Car> listClone = new MyList<Car>();
            for (int i = 0; current != null; i++)
            {
                listClone.AddToEnd(current.Data);
                current = current.Next;
            }
            return listClone;
        }
    }
}
