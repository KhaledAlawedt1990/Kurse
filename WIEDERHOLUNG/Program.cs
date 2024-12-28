using System;
using System.Collections;
using System.Net.Sockets;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata.Ecma335;
using System.ComponentModel.Design;

class Client
{

    static Queue<int> reverseQueue(Queue<int> queue)
    {
        Stack<int> stack = new Stack<int>();

        while (queue.Count > 0)
        {
            stack.Push(queue.Dequeue());
        }
        while (stack.Count > 0)
        {
            queue.Enqueue(stack.Pop());
        }
        return queue;
    }

    static bool isPalandrom(Queue<int> queue)
    {
        Stack<int> stack = new Stack<int>(queue);

        foreach (var item in queue)
        {
            if (stack.Pop() != item) return false;

        }
        return true;
    }

    static void GenerateBinaryNumber(int n)
    {
        Queue<string> queue = new Queue<string>();
        queue.Enqueue("1");
        for (int i = 0; i < 50; i++)
        {
            string binary = queue.Dequeue();
            Console.WriteLine(binary);
            queue.Enqueue(binary + "0");
            queue.Enqueue(binary + "1");
        }
    }

    static Queue<int> SortQueue(Queue<int> queue)
    {
        List<int> list = new List<int>(queue);
        list.Sort();

        return new Queue<int>(list);
    }

    static void InterleaveQueue(Queue<int> queue)
    {
        int halbsize = queue.Count / 2;
        Stack<int> stack = new Stack<int>();

        for (int i = 0; i < halbsize; i++)
        {
            stack.Push(queue.Dequeue());
        }
        while (stack.Count > 0)
        {
            queue.Enqueue(stack.Pop());
        }
        for (int i = 0; i < halbsize; i++)
        {
            queue.Enqueue(queue.Dequeue());
        }

        for (int i = 0; i < halbsize; i++)
        {
            stack.Push(queue.Dequeue());
        }

        while (stack.Count > 0)
        {
            queue.Enqueue(stack.Pop());
            queue.Enqueue(queue.Dequeue());
        }

    }

    static Queue<int> RotatQueue(Queue<int> queue, int K)
    {
        for (int i = 0; i < K; i++)
        {
            queue.Enqueue(queue.Dequeue());
        }
        return queue;
    }

    static Queue<int> MergedQueue(Queue<int> q1, Queue<int> q2)
    {
        Queue<int> mereged = new Queue<int>();

        while (q1.Count > 0 && q2.Count > 0)
        {
            if (q1.Peek() <= q2.Peek())
                mereged.Enqueue(q1.Dequeue());
            else
                mereged.Enqueue(q2.Dequeue());
        }

        while (q1.Count > 0)
            mereged.Enqueue(q1.Dequeue());
        while (q2.Count > 0)
            mereged.Enqueue(q2.Dequeue());
        return mereged;
    }

    class myQueue
    {
        Stack<int> stack1 = new Stack<int>();
        Stack<int> stack2 = new Stack<int>();

        public void Enqueue(int x)
        {
            stack1.Push(x);
        }

        public int Dequeue()
        {
            if (stack2.Count == 0)
            {
                while (stack1.Count > 0)
                {
                    stack2.Push(stack1.Pop());
                }

            }
            return stack2.Pop();
        }

        public bool IsEmpty()
        {
            return (stack1.Count == 0 && stack2.Count == 0);
        }
    }

    static Queue<int> QueueAlternatly(Queue<int> q)
    {
        List<int> list = new List<int>(q);
        Queue<int> result = new Queue<int>();

        int n = list.Count;
        for (int i = 0; i < n / 2; i++)
        {
            result.Enqueue(list[i]);
            result.Enqueue(list[n - i - 1]);
        }

        if (n % 2 != 0)
        {
            result.Enqueue(list[n / 2]);
        }
        return result;
    }

    class PriorityQueueWithSortedDictionery
    {
        private SortedDictionary<int, Queue<int>> queue = new SortedDictionary<int, Queue<int>>();

        public void Enqueue(int value, int priority)
        {
            if (!queue.ContainsKey(priority))
            {
                queue[priority] = new Queue<int>();
            }
            queue[priority].Enqueue(value);
        }

        public int? Dequeue()
        {
            if (queue.Count == 0) return null;

            int hightestPriority = queue.Keys.Min();
            int value = queue[hightestPriority].Dequeue();

            if (queue[hightestPriority].Count == 0)
                queue.Remove(hightestPriority);

            return value;
        }
    }

    class PriorityQueueWithSortedList
    {
        private SortedList<int, Queue<int>> queue = new SortedList<int, Queue<int>>();

        public void Enqueue(int value, int priority)
        {
            if (!queue.ContainsKey(priority))
            {
                queue[priority] = new Queue<int>();
            }
            queue[priority].Enqueue(value);
        }

        public int? Dequeue()
        {
            if (queue.Count == 0) return null;

            int hightestPriority = queue.Keys.Min();
            int value = queue[hightestPriority].Dequeue();

            if (queue[hightestPriority].Count == 0)
                queue.Remove(hightestPriority);

            return value;
        }
    }

    static void RearrangeQueue(Queue<int> orginalQueue)
    {
        Queue<int> Evenqueue = new Queue<int>();
        Queue<int> Oddqueue = new Queue<int>();

        while (orginalQueue.Count > 0)
        {
            if (orginalQueue.Peek() % 2 == 0)
                Evenqueue.Enqueue(orginalQueue.Dequeue());
            else
                Oddqueue.Enqueue(orginalQueue.Dequeue());
        }

        while (Evenqueue.Count > 0)
            orginalQueue.Enqueue(Evenqueue.Dequeue());

        while (Oddqueue.Count > 0)
            orginalQueue.Enqueue(Oddqueue.Dequeue());
    }

    static Queue<int> CloneQueue(Queue<int> queue)
    {
        if (queue.Count == 0) return new Queue<int>();


        int front = queue.Dequeue();

        Queue<int> clone = CloneQueue(queue);
        queue.Enqueue(front);
        clone.Enqueue(front);

        return clone;
    }

    static int FindMiddle(Queue<int> queue)
    {
        List<int> list = new List<int>(queue);

        return list[list.Count / 2];
    }

    static string ReverseString(string st)
    {
        string newString = "";

        Stack<char> stack = new Stack<char>();

        foreach (char c in st)
            stack.Push(c);

        while (stack.Count > 0)
            newString += stack.Pop();
        return newString;
    }

    static bool IsPalandrom(string input)
    {
        Stack<char> stack = new Stack<char>();

        foreach (char c in input)
        {
            stack.Push(c);
        }

        foreach (char c in input)
        {
            if (stack.Pop() != c) return false;
        }
        return true;
    }

    //static int EvaluatePostfix(string input)
    //{
    //    Stack<int> stack = new Stack<int>();
    //    foreach (char c in input)
    //    {
    //        if (char.IsDigit(c))
    //            stack.Push(c - '0');
    //        else
    //        {
    //            int a = stack.Pop();
    //            int b = stack.Pop();

    //            switch (c)
    //            {
    //                case '+': stack.Push(a + b); break;
    //                case '-': stack.Push(a - b); break;
    //                case '*': stack.Push(a * b); break;
    //                case '/': stack.Push(a / b); break;
    //            }
    //        }

    //    }
    //    return stack.Pop();


    //}

    static int EvaluatePostfix(string expression)
    {
        Stack<int> stack = new Stack<int>();


        foreach (char c in expression)
        {
            if (char.IsDigit(c))
            {
                stack.Push(c - '0');
            }
            else
            {
                int b = stack.Pop();
                int a = stack.Pop();
                switch (c)
                {
                    case '+': stack.Push(a + b); break;
                    case '-': stack.Push(a - b); break;
                    case '*': stack.Push(a * b); break;
                    case '/': stack.Push(a / b); break;
                }
            }
        }

        return stack.Pop();
    }

    static string RemoveInvalidParenthese(string st)
    {
        Stack<int> stack = new Stack<int>();
        HashSet<int> invalidIndies = new HashSet<int>();
        for(int i = 0; i < st.Length; i++)
        {
            if (st[i] == '(')
                stack.Push(i);
            else if (st[i] == ')')
            {
                if (stack.Count == 0)
                {
                    invalidIndies.Add(i);
                }
                else
                    stack.Pop();
            }
        }

        while(stack.Count > 0)
        {
           invalidIndies.Add(stack.Pop());
        }

        char[] result = new char[st.Length - invalidIndies.Count];
        int index = 0;
        for(int i = 0; i < st.Length; i++)
        {
            if(!invalidIndies.Contains(i))
            {
                result[index++] = st[i];
            }
        }

        return new string(result);
    }

    static Dictionary<string, int> SearchAfterStudentGrade(Dictionary<string, int> studentGrade, string name)
    {
        Dictionary<string, int> keyValuePairs = new Dictionary<string, int>();

        foreach(var student in studentGrade)
        {
            if(student.Key == name)
            {
                keyValuePairs.Add(student.Key, student.Value);
            }
        }
        return keyValuePairs;
    }

    static Dictionary<string, string> TranslateWord()
    {
        Dictionary<string, string> translate = new Dictionary<string, string>
        {
            {"Hello", "Hallo" },
            {"World", "Welt" },
            {"Good by", "Auf wiedersehen" }
        };

        return translate;
    }

    static void WordCountInText(string input)
    {
        Dictionary<string, int> wordCount = new Dictionary<string, int>();

        foreach(var word in input.Split(' '))
        {
            if (wordCount.ContainsKey(word))
                wordCount[word]++;
            else
                wordCount[word] = 1;
        }

        foreach(var word in wordCount)
        {
            Console.WriteLine($"{word.Key} : {word.Value}");
        }
    }

    static void PhoneBook(string input)
    {
        Dictionary<string, string> phoneNumber = new Dictionary<string, string>
        {
            {"Khaled Alawedat", "012455555" },
            {"Mohammad Alawedat", "012555444488" },
            {"Suher Alawedat", "01112555555" },
            {"Marah", "0112555258878" }
        };


        Console.WriteLine("Phone Number: " + phoneNumber[input]);
    }

    static void CheckDuplikateEntries()
    {

        string[] entries = { "A", "B", "C", "A" };
   

        HashSet<string> stEntries = new HashSet<string>();
        foreach(var entry in entries)
        {
            if(!stEntries.Add(entry))
            {
                Console.WriteLine("Duplicate detected: " + entry);
            }
        }
    }

    static void SkillMatching(HashSet<string> candidatsSkill)
    {
        HashSet<string> requerments = new HashSet<string> { "C#", "Sql", "JavaScript" };

        candidatsSkill.IntersectWith(requerments);
        Console.WriteLine("Matching Skills " + string.Join(",", candidatsSkill));
    }
    static void Main()
    {
        HashSet<string> uniqVisitore = new HashSet<string>();
        uniqVisitore.Add("C#");
        uniqVisitore.Add("Sql");
        uniqVisitore.Add("React");

        SkillMatching(uniqVisitore);

        Console.ReadLine();
    }
} 