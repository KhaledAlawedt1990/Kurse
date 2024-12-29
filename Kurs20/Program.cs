using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection.PortableExecutable;
using System.Runtime.CompilerServices;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;


namespace Kurs20
{
    public class Logger
    {
        public delegate void LogAction(string message);
        private LogAction _logAction;

        public Logger(LogAction logAction)
        {
            _logAction = logAction;
        }

        public void Log(string message)
        {
            _logAction(message);
        }
    }
    public delegate void myDelegate(string message);
    internal class Program
    {
        static void LogToFile(string message)
        {
            string filename = "log.txt";
            using(StreamWriter writer = new StreamWriter(filename))
            {
                writer.WriteLine(message);
            }
        }
        static void LogToScreen(string message)
        {
            Console.WriteLine(message);
        }
        public class OrderArgs : EventArgs
        {
            public int orderID { get; set; }
            public int orderNummer { get; set; }
            public string email { get; set; }

            public OrderArgs(int orderID, int orderNummer, string email)
            {
                this.orderID = orderID;
                this.orderNummer = orderNummer;
                this.email = email;
            }

        }

        public class Order
        {
            public event EventHandler<OrderArgs> OnOrderCereated;

            public void Cereate(int orderID, int orderNummer, string email)
            {
                if (OnOrderCereated != null)
                    OnOrderCereated(this, new OrderArgs(orderID, orderNummer, email));
            }
        }

       public class SendEmail
       {
            public void Subscribe(Order order)
            {
                order.OnOrderCereated += HandleNeweEmail;
            }
            protected void HandleNeweEmail (object sender, OrderArgs e)
            {
                Console.WriteLine("Email will be sent .....");
                Console.WriteLine("OrderID: " + e.orderID);
                Console.WriteLine("OrderNummer: " + e.orderNummer);
                Console.WriteLine("Email: " + e.email);
                Console.WriteLine("--------------------------------");
            }
       }

        public class SendEms
        {
            public void Subscribe(Order order)
            {
                order.OnOrderCereated += HandleNeweSms;
            }
            protected void HandleNeweSms(object sender, OrderArgs e)
            {
                Console.WriteLine("Sms will be sent .....");
                Console.WriteLine("OrderID: " + e.orderID);
                Console.WriteLine("OrderNummer: " + e.orderNummer);
                Console.WriteLine("Email: " + e.email);
            }
        }

        static void Methode1(string message)
        {
            Console.WriteLine("Methode1: " + message);
        }
        static void Methode2(string message)
        {
            Console.WriteLine("Methode2: " + message);
        }

        delegate int SquerDelegate (int x);

        static int SquerMethode(int x)
        {
            return x * x;
        }

        static Func<string, bool> checkName = CheckName;
        static bool CheckName(string name)
        {
            if (name == "khaled")
                return true;
            else
                return false;
        }
        static Func<int, int> squere = SquerMethode;

        static Predicate<int> IsEventNumber = IsEvent;

        static bool IsEvent(int x)
        {
            return (x % 2 == 0);
        }

        static Func<int, int> squere1 = x => x * x;
        static int SquerFunktion(int x)
        {
            return x * x;
        }

        delegate int Operation(int x, int y);
        static void ExecuteOperation(int x, int y, Func<int, int, int> operation)
        {
            int result = operation(x, y);
            Console.WriteLine(result);
        }
        static int Add(int x, int y)
        { return x + y; }
        static int Substraxt(int x, int y)
        { return x - y; }

        static void Procedure(string? name, int? age)
        {
            if (name == null)
            {
                Console.WriteLine("Name is Null");
            }
            else
                Console.WriteLine("Name is: " + name);
            if (!age.HasValue)
            {
                Console.WriteLine("Age is Null");
            }
            else
                Console.WriteLine("Age is: " + age.Value); 
        }

        static void SerializationAndDeserialization(Person person)
        {

            XmlSerializer serializer = new XmlSerializer(typeof(Person));
            using(TextWriter writer = new StreamWriter("person.xml"))
            {
                serializer.Serialize(writer, person);
            }

            using(TextReader reader = new StreamReader("person.xml"))
            {
                Person deserializer = (Person)serializer.Deserialize(reader);
                Console.WriteLine($"Name: {deserializer.name} \nAge: {deserializer.age} \nAktuelles Datum: {deserializer.currentDate}");
            }
        }
        static void Main(string[] args)
        {
            Person person = new Person
            {
                name = "Khaled Alawedat",
                age = 34,
                currentDate = DateTime.Now
            };

            SerializationAndDeserialization(person);
            Console.ReadKey();
        }

    }

    public class Person
    {
        public string name { get; set; }
        public int age { get; set; }
        public DateTime currentDate { get; set; }
    }
}
