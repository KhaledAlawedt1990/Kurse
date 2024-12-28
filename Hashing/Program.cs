


using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;



    public abstract class UserType
    {
    public abstract void GetUserType();
    public abstract void GetUserAge(int Age);
       

    }

public class Admin : UserType
{
    public override void GetUserType()
    {
        Console.WriteLine("This is an Admin");
    }

    public override void GetUserAge(int Age)
    {
        Console.WriteLine("Er ist " + Age + " Jahre Alt");
    }
}

    public class User1 : UserType
    {
        public override void GetUserType()
        {
            Console.WriteLine("This is a User1");
        }
    public override void GetUserAge(int Age)
    {
        Console.WriteLine("Er ist " + Age + " Jahre Alt");
    }
}

    public class MarktingUser : UserType
    {
        public override void GetUserType()
        {
            Console.WriteLine("This is a Markting User.");
        }
    public override void GetUserAge(int Age)
    {
        Console.WriteLine("Er ist " + Age + " Jahre Alt");
    }
}

    public class SystemUser: UserType
    {
        public override void GetUserType()
        {
            Console.WriteLine("This is SystemUser");
        }
    public override void GetUserAge(int Age)
    {
        Console.WriteLine("Er ist " + Age + " Jahre Alt");
    }
}

//    class Program
//{
//    public static  void GetUserType(UserType userType)
//    {
//        userType.GetUserType();
//    }

//    public static void GetUserAge(UserType userType, int age)
//    {
//        userType.GetUserAge(age);
//    }
//    static void Main(string[] args)
//    {
//        Admin admin = new Admin();
//        GetUserType(admin);
//        GetUserAge(admin, 20);
//        MarktingUser user = new MarktingUser();
//        GetUserAge(user, 50);
//        GetUserType(user);
//        User1 user1 = new User1();
//        GetUserType(user1);
//    }
//}



//class Program
//{
//    private static readonly object _lockObject = new object();
//    private static int _sharedResource = 0;

//    static void Main()
//    {
//        Thread thread1 = new Thread(IncrementResource);
//        Thread thread2 = new Thread(IncrementResource);

//        thread1.Start();
//        thread2.Start();

//        thread1.Join();
//        thread2.Join();

//        Console.WriteLine("Final value of shared resource: " + _sharedResource);
//    }

//    private static void IncrementResource()
//    {
//        for (int i = 0; i < 1000; i++)
//        { 
//            // بدء المقطع المحمي
//            lock (_lockObject)
//            {
//                _sharedResource++;
//            }

//            Thread.Sleep(500);
//            Console.WriteLine(_sharedResource);
//            // نهاية المقطع المحمي
//        }
//    }
//}

class AsyncProgram
{
    static async Task Main()
    {
        Console.WriteLine("Starting Tasks....");

        Task task1 = DownloadAndPrinAsync("https://www.cnn.com");
        Console.WriteLine("\nTask 1 started..");

        Task task2 = DownloadAndPrinAsync("https://www.amazon.com");
        Console.WriteLine("Task 2 started...");

        Task task3 = DownloadAndPrinAsync("https://www.ProgrammingAdvices.com");
        Console.WriteLine("Task 3 started...");

        await Task.WhenAll(task1, task2, task3);

        Console.WriteLine("\nDone, all Tasks finisched Executing..");
    }

    static async Task DownloadAndPrinAsync(string url)
    {
        string content;
        //Using statemnt ensures that the webClient disposed of properly 
        using (WebClient client = new WebClient())
        {
            await Task.Delay(200);
            // asynchrocouly  download
            content = await client.DownloadStringTaskAsync(url);
        }
        Console.WriteLine($"{url}: {content.Length} Characters downloaded.");

        Console.ReadKey();
    }
}
