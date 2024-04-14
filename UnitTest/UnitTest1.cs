using ClassLibrary1;
using LAB_12;

namespace UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void AddingToBegin() //Проверка на добавление одного элемента
        {
            MyList<Car> list = new MyList<Car>();
            Car car = new Car();
            list.AddToBegin(car);
            Assert.AreEqual(list.FirstItem().Data, car);
        }

        [TestMethod]
        public void CheckNextAndPreviousNull() //Проверка на то, что при добавлении одного элемента, нет ничего ни перед, ни после
        {
            MyList<Car> list = new MyList<Car>();
            Car car = new Car();
            list.AddToBegin(car);
            Assert.IsTrue((list.FirstItem().Previous == null) && (list.FirstItem().Next == null) == true);
        }

        [TestMethod]
        public void CheckFirstElementWithAddingToBegin() //Добавление двух элементов в начало. Проверяем, что будет на первом месте
        {
            MyList<Car> list = new MyList<Car>();
            Car car1 = new Car();
            list.AddToBegin(car1);
            Car car2 = new Car();
            list.AddToBegin(car2);
            Assert.AreEqual(list.FirstItem().Data, car2);
        }

        [TestMethod]
        public void CheckFirstElementPrevious() //Добавление двух элементов. Проверка ссылку на предыдущий элемент
        {
            MyList<Car> list = new MyList<Car>();
            Car car1 = new Car();
            list.AddToBegin(car1);
            Car car2 = new Car();
            list.AddToBegin(car2);
            Assert.AreEqual(list.FirstItem().Previous, null);
        }

        [TestMethod]
        public void CheckFirstElementNext() //Добавление двух элементов. Проверка ссылку на следующий элемент
        {
            MyList<Car> list = new MyList<Car>();
            Car car1 = new Car();
            list.AddToBegin(car1);
            Car car2 = new Car();
            list.AddToBegin(car2);
            Assert.AreEqual(list.FirstItem().Next.Data, car2);
        }

        [TestMethod]
        public void CheckFirstElementWithAddingToEnd() //Добавление двух элементов в конец. Проверяем, что будет на первом месте
        {
            MyList<Car> list = new MyList<Car>();
            Car car1 = new Car();
            list.AddToEnd(car1);
            Car car2 = new Car();
            list.AddToEnd(car2);
            Assert.AreEqual(list.FirstItem().Data, car1);
        }

        [TestMethod]
        public void CheckFirstElementNextAddingToEnd() //Добавление двух элементов. Проверка ссылку на следующий элемент
        {
            MyList<Car> list = new MyList<Car>();
            Car car1 = new Car();
            list.AddToEnd(car1);
            Car car2 = new Car();
            list.AddToEnd(car2);
            Assert.AreEqual(list.FirstItem().Next.Data, car1);
        }

        [TestMethod]
        public void CheckAddToFirst() //Добавление с помощью AddTo в первую позицию
        {
            MyList<Car> list = new MyList<Car>();
            Car car1 = new Car();
            Car car2 = new Car();
            Car car3 = new Car();
            Car car4 = new Car();
            list.AddToEnd(car1);
            list.AddToEnd(car2);
            list.AddToEnd(car3);
            list.AddTo(0, car4);
            Assert.AreEqual(list.FirstItem().Data, car4);
        }

        [TestMethod]
        public void CheckAddToMiddle() //Добавление с помощью AddTo в средную часть 
        {
            MyList<Car> list = new MyList<Car>();
            Car car1 = new Car();
            Car car2 = new Car();
            Car car3 = new Car();
            Car car4 = new Car();
            list.AddToEnd(car1);
            list.AddToEnd(car2);
            list.AddToEnd(car3);
            list.AddTo(1, car4);
            Assert.AreEqual(list.FirstItem().Next.Data, car4);
        }

        [TestMethod]
        public void CheckAddToEnd() //Добавление с помощью AddTo в конец 
        {
            MyList<Car> list = new MyList<Car>();
            Car car1 = new Car();
            Car car2 = new Car();
            Car car3 = new Car();
            Car car4 = new Car();
            list.AddToEnd(car1);
            list.AddToEnd(car2);
            list.AddToEnd(car3);
            list.AddTo(2, car4);
            Assert.AreEqual(list.FirstItem().Next.Next.Data, car4);
        }

        [TestMethod]
        public void CheckAddToNone() //Добавление с помощью AddTo в позицию больше количества элементов
        {
            MyList<Car> list = new MyList<Car>();
            Car car1 = new Car();
            Car car2 = new Car();
            Car car3 = new Car();
            Car car4 = new Car();
            list.AddToEnd(car1);
            list.AddToEnd(car2);
            list.AddToEnd(car3);
            list.AddTo(10, car4);
            Assert.AreEqual(list.FirstItem().Next.Next.Next.Data, car4);
        }

        [TestMethod]
        public void CreateListWithEmptyCollection() //Создаём лист на основе пустой коллекции
        {
            Car[] cars = new Car[0];
            try
            {
                MyList<Car> list = new MyList<Car>(cars);
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                Assert.AreEqual(message, "empty collection");
            };
        }

        [TestMethod]
        public void CreateListWithNull() //Создаём лист на основе пустой коллекции
        {
            Car[] cars = new Car[1];
            cars[0] = new Car();
            try
            {
                MyList<Car> list = new MyList<Car>(cars);
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                Assert.AreEqual(message, "empty collection: null");
            };
        }

        [TestMethod]
        public void FindFirstElement() //Поиск первого элемента
        {
            MyList<Car> list = new MyList<Car>();
            Car car1 = new Car();
            car1.Year = 2001;
            Car car2 = new Car();
            car2.Year = 2002;
            Car car3 = new Car();
            car3.Year = 2003;
            list.AddToEnd(car3);
            list.AddToEnd(car2);
            list.AddToEnd(car1);
            Point<Car> car = list.FindItem(2001);
            Assert.AreEqual(car1, car.Data);
        }

        [TestMethod]
        public void FindMiddleElement() //Поиск серединного элемента
        {
            MyList<Car> list = new MyList<Car>();
            Car car1 = new Car();
            car1.Year = 2001;
            Car car2 = new Car();
            car2.Year = 2002;
            Car car3 = new Car();
            car3.Year = 2003;
            list.AddToEnd(car3);
            list.AddToEnd(car2);
            list.AddToEnd(car1);
            Point<Car> car = list.FindItem(2002);
            Assert.AreEqual(car2, car.Data);
        }

        [TestMethod]
        public void FindEndElement() //Поиск последнего элемента
        {
            MyList<Car> list = new MyList<Car>();
            Car car1 = new Car();
            car1.Year = 2001;
            Car car2 = new Car();
            car2.Year = 2002;
            Car car3 = new Car();
            car3.Year = 2003;
            list.AddToEnd(car3);
            list.AddToEnd(car2);
            list.AddToEnd(car1);
            Point<Car> car = list.FindItem(2003);
            Assert.AreEqual(car3, car.Data);
        }

        [TestMethod]
        public void FindNoneElement() //Поиск несуществующего элемента
        {
            MyList<Car> list = new MyList<Car>();
            Car car1 = new Car();
            car1.Year = 2001;
            Car car2 = new Car();
            car2.Year = 2002;
            Car car3 = new Car();
            car3.Year = 2003;
            list.AddToEnd(car3);
            list.AddToEnd(car2);
            list.AddToEnd(car1);
            Point<Car> car = list.FindItem(2005);
            Assert.AreEqual(car, null);
        }

        [TestMethod]
        public void RemoveFromNullList() //Удаление из пустого списка
        {
            try
            {
                MyList<Car> list = new MyList<Car>();
                list.RemoveItem(2000);
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                Assert.AreEqual(message, "Удаление невозможно, так как список пуст");
            };
        }

        [TestMethod]
        public void RemoveNoneElement() //Удаление несуществующего элемента
        {
            MyList<Car> list = new MyList<Car>();
            Car car1 = new Car();
            car1.Year = 2001;
            list.AddToEnd(car1);
            Assert.AreEqual(false, list.RemoveItem(2000));
        }

        [TestMethod]
        public void RemoveOneElementListLenghtOne() //Удаление элемента. Есть только один элемент
        {
            MyList<Car> list = new MyList<Car>();
            Car car1 = new Car();
            car1.Year = 2001;
            list.AddToEnd(car1);
            list.RemoveItem(2001);
            Assert.AreEqual(list.Count, 0);
        }

        [TestMethod]
        public void RemoveFirstElement() //Удаление первого элемента
        {
            MyList<Car> list = new MyList<Car>();
            Car car1 = new Car();
            car1.Year = 2001;
            Car car2 = new Car();
            car2.Year = 2002;
            Car car3 = new Car();
            car3.Year = 2003;
            list.AddToEnd(car3);
            list.AddToEnd(car2);
            list.AddToEnd(car1);
            list.RemoveItem(2003);
            Assert.AreEqual(list.FirstItem().Data, car2);
        }

        [TestMethod]
        public void RemoveMiddleElement() //Удаление серединного элемента
        {
            MyList<Car> list = new MyList<Car>();
            Car car1 = new Car();
            car1.Year = 2001;
            Car car2 = new Car();
            car2.Year = 2002;
            Car car3 = new Car();
            car3.Year = 2003;
            list.AddToEnd(car3);
            list.AddToEnd(car2);
            list.AddToEnd(car1);
            list.RemoveItem(2002);
            Assert.AreEqual(list.FirstItem().Next.Data, car1);
        }

        [TestMethod]
        public void RemoveEndElement() //Удаление последнего элемента
        {
            MyList<Car> list = new MyList<Car>();
            Car car1 = new Car();
            car1.Year = 2001;
            Car car2 = new Car();
            car2.Year = 2002;
            Car car3 = new Car();
            car3.Year = 2003;
            list.AddToEnd(car3);
            list.AddToEnd(car2);
            list.AddToEnd(car1);
            list.RemoveItem(2001);
            Assert.AreEqual(list.FirstItem().Next.Next, null);
        }
    }
}