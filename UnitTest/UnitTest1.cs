using ClassLibrary1;
using LAB_12;

namespace UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void AddingToBegin() //�������� �� ���������� ������ ��������
        {
            MyList<Car> list = new MyList<Car>();
            Car car = new Car();
            list.AddToBegin(car);
            Assert.AreEqual(list.FirstItem().Data, car);
        }

        [TestMethod]
        public void CheckNextAndPreviousNull() //�������� �� ��, ��� ��� ���������� ������ ��������, ��� ������ �� �����, �� �����
        {
            MyList<Car> list = new MyList<Car>();
            Car car = new Car();
            list.AddToBegin(car);
            Assert.IsTrue((list.FirstItem().Previous == null) && (list.FirstItem().Next == null) == true);
        }

        [TestMethod]
        public void CheckFirstElementWithAddingToBegin() //���������� ���� ��������� � ������. ���������, ��� ����� �� ������ �����
        {
            MyList<Car> list = new MyList<Car>();
            Car car1 = new Car();
            list.AddToBegin(car1);
            Car car2 = new Car();
            list.AddToBegin(car2);
            Assert.AreEqual(list.FirstItem().Data, car2);
        }

        [TestMethod]
        public void CheckFirstElementPrevious() //���������� ���� ���������. �������� ������ �� ���������� �������
        {
            MyList<Car> list = new MyList<Car>();
            Car car1 = new Car();
            list.AddToBegin(car1);
            Car car2 = new Car();
            list.AddToBegin(car2);
            Assert.AreEqual(list.FirstItem().Previous, null);
        }

        [TestMethod]
        public void CheckFirstElementNext() //���������� ���� ���������. �������� ������ �� ��������� �������
        {
            MyList<Car> list = new MyList<Car>();
            Car car1 = new Car();
            list.AddToBegin(car1);
            Car car2 = new Car();
            list.AddToBegin(car2);
            Assert.AreEqual(list.FirstItem().Next.Data, car2);
        }

        [TestMethod]
        public void CheckFirstElementWithAddingToEnd() //���������� ���� ��������� � �����. ���������, ��� ����� �� ������ �����
        {
            MyList<Car> list = new MyList<Car>();
            Car car1 = new Car();
            list.AddToEnd(car1);
            Car car2 = new Car();
            list.AddToEnd(car2);
            Assert.AreEqual(list.FirstItem().Data, car1);
        }

        [TestMethod]
        public void CheckFirstElementNextAddingToEnd() //���������� ���� ���������. �������� ������ �� ��������� �������
        {
            MyList<Car> list = new MyList<Car>();
            Car car1 = new Car();
            list.AddToEnd(car1);
            Car car2 = new Car();
            list.AddToEnd(car2);
            Assert.AreEqual(list.FirstItem().Next.Data, car1);
        }

        [TestMethod]
        public void CheckAddToFirst() //���������� � ������� AddTo � ������ �������
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
        public void CheckAddToMiddle() //���������� � ������� AddTo � ������� ����� 
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
        public void CheckAddToEnd() //���������� � ������� AddTo � ����� 
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
        public void CheckAddToNone() //���������� � ������� AddTo � ������� ������ ���������� ���������
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
        public void CreateListWithEmptyCollection() //������ ���� �� ������ ������ ���������
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
        public void CreateListWithNull() //������ ���� �� ������ ������ ���������
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
        public void FindFirstElement() //����� ������� ��������
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
        public void FindMiddleElement() //����� ����������� ��������
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
        public void FindEndElement() //����� ���������� ��������
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
        public void FindNoneElement() //����� ��������������� ��������
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
        public void RemoveFromNullList() //�������� �� ������� ������
        {
            try
            {
                MyList<Car> list = new MyList<Car>();
                list.RemoveItem(2000);
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                Assert.AreEqual(message, "�������� ����������, ��� ��� ������ ����");
            };
        }

        [TestMethod]
        public void RemoveNoneElement() //�������� ��������������� ��������
        {
            MyList<Car> list = new MyList<Car>();
            Car car1 = new Car();
            car1.Year = 2001;
            list.AddToEnd(car1);
            Assert.AreEqual(false, list.RemoveItem(2000));
        }

        [TestMethod]
        public void RemoveOneElementListLenghtOne() //�������� ��������. ���� ������ ���� �������
        {
            MyList<Car> list = new MyList<Car>();
            Car car1 = new Car();
            car1.Year = 2001;
            list.AddToEnd(car1);
            list.RemoveItem(2001);
            Assert.AreEqual(list.Count, 0);
        }

        [TestMethod]
        public void RemoveFirstElement() //�������� ������� ��������
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
        public void RemoveMiddleElement() //�������� ����������� ��������
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
        public void RemoveEndElement() //�������� ���������� ��������
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