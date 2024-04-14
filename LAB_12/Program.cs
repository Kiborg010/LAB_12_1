using ClassLibrary1;

namespace LAB_12
{
    public class Program
    {
        static int CorrectInputInt(int left, int right)
        {
            Console.Write($"Введите целое число от {left} до {right}: ");
            string input = Console.ReadLine();
            int number;
            bool numberIsCorrect = int.TryParse(input, out number);
            while (!numberIsCorrect || !((left <= number) && (number <= right)))
            {
                Console.WriteLine($"Ошибка. Вам необходимо ввести целое число от {left} до {right}");
                Console.Write($"Введите целое число от {left} до {right}: ");
                input = Console.ReadLine();
                numberIsCorrect = int.TryParse(input, out number);
            }
            return number;
        }

        static void WriteCommands()
        {
            Console.WriteLine("1. Создать список заданной длины");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("2. Распечатать изначальный список");
            Console.ResetColor();
            Console.WriteLine("3. Добавить элемент в начало");
            Console.WriteLine("4. Добавить элемент в конец");
            Console.WriteLine("5. Добавить элемент в введённую позицию");
            Console.WriteLine("6. Удалить все элементы с введеным годом");
            Console.WriteLine("7. Выполнить глубокое клонирование");
            Console.WriteLine("8. Удалить изначальный список из памяти");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("9. Распечатать склонированный список");
            Console.ResetColor();
            Console.WriteLine("10. Завершить работу");
        }

        static void TrashAnswer()
        {
            Console.WriteLine();
            Console.Write("Введите что-нибудь, чтобы вернуться в меню: ");
            string trashAnswer = Console.ReadLine();
        }

        //Для генерации машины разного типа: базовая, грузовая, легковая, внедорожник.
        static Car CreateCarWithRandomType()
        {
            Random random = new Random();
            int type = random.Next(0, 4); //Случайное число от 0 до 3
            if (type == 0) //В зависимости от числа выибраем тип
            {
                Car car = new Car(); //Создаём машину нужного типа
                car.RandomInit(); //Заполняем случайными значениями
                return car;
            }
            else if (type == 1)
            {
                LorryCar car = new LorryCar();
                car.RandomInit();
                return car;
            }
            else if (type == 2)
            {
                PassengerCar car = new PassengerCar();
                car.RandomInit();
                return car;
            }
            else if (type == 3)
            {
                OffRoadCar car = new OffRoadCar();
                car.RandomInit();
                return car;
            }
            return null;
        }

        //Для генерации списка
        static MyList<Car> CreateList()
        {
            int count = CorrectInputInt(1, 100); //Даём запрос на количество машин
            Car[] cars = new Car[count]; //Сначала массив
            for (int i = 0; i < count; i++)
            {
                Car car = CreateCarWithRandomType(); //Генериуруем машину случайного типа
                cars[i] = car; //Добавляем в массив
            }
            MyList<Car> list = new MyList<Car>(cars); //На основе массива создаём список
            return list;
        }

        //Для добавленя в список
        static void AddingToList(ref MyList<Car> list, ref int numberCar, int typeOfAdding = 0) //Передаются: ссылка на исходный список, ссылка на изменяемый номер добавляемой машины, тип добавления
        {
            Car carToAdd = CreateCarWithRandomType(); //Генериурем случаную машину
            carToAdd.Brend = $"Добавляемая_Машина_{numberCar}"; //Для удобства опознания меняем бренд в зависимости от глобально изменяющейся переменной numberCar
            carToAdd.Year = 2000; //Для того, чтобы потом было проще удалять у всех добавляемвых делаем год 2000
            numberCar++; //Увеличиваем глобальный номер добавляемой машины
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Добавляемая машина: \n{carToAdd.ToString()}");
            Console.ResetColor();
            if (typeOfAdding == 0) //В зависимости от типа добавления добавляем нужным способом
            {
                list.AddToBegin(carToAdd);
            }
            else if (typeOfAdding == 1)
            {
                list.AddToEnd(carToAdd);
            }
            else if (typeOfAdding == 2)
            {
                Console.WriteLine("Введите позицию, куда надо добавить элемент"); 
                int index = CorrectInputInt(0, 100);
                list.AddTo(index, carToAdd);
            }
        }

        static void Main(string[] args)
        {
            WriteCommands();
            int numberAnswerOne = -1;
            MyList<Car> list = new MyList<Car>();
            MyList<Car> listClone = new MyList<Car>();
            int numberCar = 1;
            while (numberAnswerOne != 10)
            {
                Console.Clear();
                WriteCommands();
                numberAnswerOne = CorrectInputInt(1, 10);
                switch (numberAnswerOne)
                {
                    case 1:
                        {
                            Console.Clear();
                            Console.WriteLine("Введите длину списка");
                            list = CreateList();
                            TrashAnswer();
                            break;
                        }
                    case 2:
                        {
                            Console.Clear();
                            list.PrintList();
                            TrashAnswer();
                            break;
                        }
                    case 3:
                        {
                            Console.Clear();
                            Console.WriteLine("Изначальный список: ");
                            list.PrintList();
                            Console.WriteLine();
                            
                            AddingToList(ref list, ref numberCar, 0);
                            
                            Console.WriteLine("\nИзменный список");
                            list.PrintList();
                            TrashAnswer();
                            break;
                        }
                    case 4:
                        {
                            Console.Clear();
                            Console.WriteLine("Изначальный список: ");
                            list.PrintList();
                            Console.WriteLine();

                            AddingToList(ref list, ref numberCar, 1);

                            Console.WriteLine("\nИзменный список");
                            list.PrintList();
                            TrashAnswer();
                            break;
                        }
                    case 5:
                        {
                            Console.Clear();
                            Console.WriteLine("Изначальный список: ");
                            list.PrintList();
                            Console.WriteLine();

                            AddingToList(ref list, ref numberCar, 2);

                            Console.WriteLine("\nИзменный список");
                            list.PrintList();
                            TrashAnswer();
                            break;
                        }
                    case 6:
                        {
                            Console.Clear();
                            Console.WriteLine("Изначальный список: ");
                            list.PrintList();
                            Console.WriteLine();
                            Console.WriteLine("Введите год удаляемой машины");
                            int yearInput = CorrectInputInt(1950, 2024);
                            try
                            {
                                list.RemoveItem(yearInput);
                            }
                            catch (Exception exc)
                            {
                                Console.WriteLine();
                                Console.WriteLine(exc.Message);
                            }
                            Console.WriteLine("\nИзменный список");
                            list.PrintList();
                            TrashAnswer();
                            break;
                        }
                    case 7:
                        {
                            Console.Clear();
                            listClone = list.Clone();
                            Console.WriteLine("Склонированный список: ");
                            listClone.PrintList();
                            TrashAnswer();
                            break;
                        }
                    case 8:
                        {
                            Console.Clear();
                            list.Clear();
                            Console.WriteLine("Список удалён");
                            TrashAnswer();
                            break;
                        }
                    case 9:
                        {
                            Console.Clear();
                            Console.WriteLine("Склонированный список: ");
                            listClone.PrintList();
                            TrashAnswer();
                            break;
                        }
                    case 10:
                        {
                            Console.Clear();
                            Console.WriteLine("Завершение работы");
                            break;
                        }
                }
            }
        }
    }
}
