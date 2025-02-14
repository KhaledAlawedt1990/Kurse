using System.Collections.ObjectModel;
using System.Collections;
using System;
using System.Collections.Specialized;

namespace Kurse23_DataStruktur
{
    internal class Program
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
            for (int i = 0; i < st.Length; i++)
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

            while (stack.Count > 0)
            {
                invalidIndies.Add(stack.Pop());
            }

            char[] result = new char[st.Length - invalidIndies.Count];
            int index = 0;
            for (int i = 0; i < st.Length; i++)
            {
                if (!invalidIndies.Contains(i))
                {
                    result[index++] = st[i];
                }
            }

            return new string(result);
        }

        static Dictionary<string, int> SearchAfterStudentGrade(Dictionary<string, int> studentGrade, string name)
        {
            Dictionary<string, int> keyValuePairs = new Dictionary<string, int>();

            foreach (var student in studentGrade)
            {
                if (student.Key == name)
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

            foreach (var word in input.Split(' '))
            {
                if (wordCount.ContainsKey(word))
                    wordCount[word]++;
                else
                    wordCount[word] = 1;
            }

            foreach (var word in wordCount)
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
            foreach (var entry in entries)
            {
                if (!stEntries.Add(entry))
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

        static List<int> FindDuplicateElements(int[] numbers)
        {
            Dictionary<int, int> counts = new Dictionary<int, int>();
            List<int> duplicates = new List<int>();

            foreach (int num in numbers)
            {
                if (counts.ContainsKey(num))
                {
                    counts[num]++;
                    if (counts[num] == 2)
                        duplicates.Add(num);
                }
                else
                    counts[num] = 1;
            }
            return duplicates;
        }

        static List<int> FindUniqueElements(int[] numbers)
        {
            Dictionary<int, int> counts = new Dictionary<int, int>();
            List<int> unique = new List<int>();

            foreach (int num in numbers)
            {
                if (counts.ContainsKey(num))
                {
                    counts[num]++;

                    if (unique.Contains(num))
                        unique.Remove(num);
                }
                else
                {
                    counts[num] = 1;
                    unique.Add(num);
                }
            }
            return unique;
        }
        static void FindWords()
        {
            //المشكلة: نريد كتابة دالة تأخذ مجموعة من الكلمات كمدخل وتعيد فقط الكلمات التي يمكن كتابتها باستخدام صف واحد من لوحة مفاتيح QWERTY.
            string[] rows = { "qwertyuiop", "asdfghjkl", "zxcvbnm" };
            Dictionary<char, int> charRow = new Dictionary<char, int>();

            for (int i = 0; i < rows.Length; i++)
            {
                foreach (char c in rows[i])
                {
                    charRow[c] = i;
                }
            }

            string[] words = { "Hello", "Alaska", "Dad", "Peace", "ADDFGGHHJK" };

            List<string> result = new List<string>();
            foreach (string word in words)
            {
                int row = charRow[char.ToLower(word[0])];
                bool isValid = true;

                foreach (char c in word)
                {
                    if (charRow[char.ToLower(c)] != row)
                    {
                        isValid = false;
                        break;
                    }
                }
                if (isValid)
                {
                    result.Add(word);
                }
            }
            Console.WriteLine(string.Join(",", result));
        }
        static List<int> FindMissingNumberWithHash(int[] nums)
        {
            HashSet<int> set = new HashSet<int>(nums);
            List<int> missingNums = new List<int>();

            int n = nums.Length;
            for (int i = 0; i <= n; i++)
            {
                if (!set.Contains(i))
                    missingNums.Add(i);
            }
            return missingNums;
        }

        static List<int> FindMissingNumberWithDictionary(int[] nums)
        {
            Dictionary<int, bool> presenz = new Dictionary<int, bool>();
            List<int> missingNums = new List<int>();

            int n = nums.Length;

            foreach (int num in nums)
            {
                presenz[num] = true;
            }
            for (int i = 0; i <= 10; i++)
            {
                if (!presenz.ContainsKey(i))
                {
                    missingNums.Add(i);
                }
            }
            return missingNums;
        }
        static void FindCommonChars()
        {
            string[] words = { "bella", "label", "roller" };
            int[] miniFreq = new int[26];
            Array.Fill(miniFreq, int.MaxValue);
            foreach (string word in words)
            {
                int[] charFreq = new int[26];
                foreach (char c in word)
                {
                    charFreq[c - 'a']++;
                }

                for (int i = 0; i < 26; i++)
                {
                    miniFreq[i] = Math.Min(miniFreq[i], charFreq[i]);
                }
            }

            List<string> result = new List<string>();
            for (int i = 0; i < 26; i++)
            {
                for (int j = 0; j < miniFreq[i]; j++)
                {
                    result.Add(((char)(i + 'a')).ToString());
                }
            }

            Console.WriteLine(string.Join(",", result));
        }
        static void FindCommonCharsWithDictionary()
        {
            string[] words = { "bella", "label", "roller" };
            Dictionary<char, int> commonChars = new Dictionary<char, int>();
            foreach (char c in words[0])
            {
                if (commonChars.ContainsKey(c))
                    commonChars[c]++;
                else
                    commonChars[c] = 1;
            }
            for (int i = 1; i < words.Length; i++)
            {
                Dictionary<char, int> currentChars = new Dictionary<char, int>();
                foreach (char c in words[i])
                {
                    if (currentChars.ContainsKey(c))
                        currentChars[c]++;
                    else
                        currentChars[c] = 1;
                }
                foreach (var item in commonChars.Keys.ToList())
                {
                    if (currentChars.ContainsKey(item))
                    {
                        commonChars[item] = Math.Min(commonChars[item], currentChars[item]);
                    }
                    else
                        commonChars.Remove(item);
                }
            }
            List<string> result = new List<string>();
            foreach (var item in commonChars)
            {
                for (int i = 0; i < item.Value; i++)
                {
                    result.Add(item.Key.ToString());
                }
            }
            Console.WriteLine(string.Join(",", result));
        }
        static void ElementsNotInSecondArray()
        {
            int[] num1 = { 1, 2, 3, 5, 9, 10, 20 };
            int[] num2 = { 1, 2, 3, 4, 5 };
            HashSet<int> set = new HashSet<int>(num2);
            List<int> result = new List<int>();
            foreach (int num in num1)
            {
                if (set.Contains(num))
                    set.Remove(num);
                else
                    result.Add(num);
            }

            Console.WriteLine(string.Join(",", result));
        }
        static void WordsNotInSecondArray()
        {
            string[] words1 = { "bella", "label", "roller", "hello", "khaled" };
            string[] words2 = { "bella", "label", "roller", "fofo" };
            HashSet<string> set = new HashSet<string>(words2);
            List<string> result = new List<string>();
            foreach (string word in words1)
            {
                if (set.Contains(word))
                    set.Remove(word);
                else
                    result.Add(word);
            }
            Console.WriteLine(string.Join(",", result));
        }
        static void FindDisappearedNumbers()
        {
            int[] numbers = { 4, 3, 2, 7, 8, 2, 3, 1 };
            List<int> result = new List<int>();
            HashSet<int> set = new HashSet<int>(numbers);
            int n = numbers.Length;

            for (int i = 0; i < n; i++)
            {
                if (!set.Contains(i + 1))
                {
                    result.Add(i + 1);
                }
            }
            Console.WriteLine(string.Join(",", result));
        }
        static void AreDisjointSets()
        {
            int[] number1 = { 1, 2, 3, 4, 5 }, number2 = { 6, 7, 8, 9, 10 };
            int n1 = number1.Length;
            int n2 = number2.Length;

            bool Disjoint = true;
            for (int i = 0; i < n1; i++)
            {
                for (int j = 0; j < n2; j++)
                {
                    if (number1[i] == number2[j])
                    {
                        Disjoint = false;
                        break;
                    }
                }
            }
            if (Disjoint)
            {
                Console.WriteLine("Disjoint");
            }
            else
            {
                Console.WriteLine("Not Disjoint");
            }
        }
        static void AreDisjointSetsWithHashSet()
        {
            int[] number1 = { 1, 2, 3, 4, 5 }, number2 = { 5, 7, 8, 9, 10 };
            int n1 = number1.Length;
            bool DisJoint = true;
            HashSet<int> set = new HashSet<int>(number2);

            for (int i = 0; i < n1; i++)
            {
                if (set.Contains(number1[i]))
                {
                    DisJoint = false;
                    break;
                }
            }
            if (DisJoint)
            {
                Console.WriteLine("Disjoint");
            }
            else
            {
                Console.WriteLine("Not Disjoint");
            }
        }
        static void IsPangram()
        {
            string st = "The quick brown fox jumps over the lazy dog";
            HashSet<char> letters = new HashSet<char>();
            foreach (char c in st)
            {
                if (char.IsLetter(c))
                {
                    letters.Add(char.ToLower(c));
                }
            }

            if (letters.Count == 26)
            {
                Console.WriteLine("Pangram");
            }
            else
            {
                Console.WriteLine("Not Pangram");
            }
        }
        static void GetViewBetween(int num1, int num2)
        {
            //Problem: Find all elements in a SortedSet within a given range [low, high].

            SortedSet<int> sortedSet = new SortedSet<int> { 1, 2, 3, 4, 5, 6, 7 };
            var range = sortedSet.GetViewBetween(num1, num2);
            Console.WriteLine(string.Join(",", range));
        }
        static void FindSmallestLargestElement()
        {
            //Problem: Find the smallest and largest element in a SortedSet.

            SortedSet<int> sortedSet = new SortedSet<int> { 4, 2, 5, 1, 3 };
            int smallesValue = sortedSet.Min;
            int largestValue = sortedSet.Max;

            Console.WriteLine($"Smallest: {smallesValue}, Largest: {largestValue}");
        }
        static void UnionTwoSortedSets()
        {
            //Problem: Union of two SortedSets.

            SortedSet<int> sortedSet1 = new SortedSet<int> { 1, 2, 3, 4, 5 };
            SortedSet<int> sortedSet2 = new SortedSet<int> { 4, 5, 6, 7, 8 };
            sortedSet1.UnionWith(sortedSet2);
            Console.WriteLine(string.Join(",", sortedSet1));
        }

        static void GetAllGreaterElementsThan(int num)
        {
            //Problem: Remove an element from a SortedSet.
            SortedSet<int> sortedSet = new SortedSet<int> { 1, 2, 3, 4, 5 };
            var newSortedSet = sortedSet.Where(num => num <= 3);
            Console.WriteLine(string.Join(",", newSortedSet));
        }
        static void GetAllGreaterGreaterElementsThan_AnotherMehtode(int num)
        {
            //Problem: Remove an element from a SortedSet.
            SortedSet<int> sortedSet = new SortedSet<int> { 1, 2, 3, 4, 5 };
            var rang = sortedSet.GetViewBetween(int.MinValue, num);
            Console.WriteLine(string.Join(",", rang));
        }
        static void FindAllElementLessThan(int num)
        {
            //Problem:Get
            SortedSet<int> sortedSet = new SortedSet<int> { 1, 2, 3, 4, 5 };
            var rang = sortedSet.GetViewBetween(int.MinValue, num - 1);

            Console.WriteLine(string.Join(",", rang));
        }
        static void CountNumberOfElementGreaterThan(int num)
        {
            //Problem: Count the number of elements greater than a given element in a SortedSet.
            SortedSet<int> sortedSet = new SortedSet<int> { 1, 2, 3, 4, 5 };
            var rang = sortedSet.GetViewBetween(num + 1, int.MaxValue);
            Console.WriteLine(rang.Count);
        }
        static void RemoveElementInSpecifiedRange(int num1, int num2)
        {
            //Problem: Remove all elements within a specified range from a SortedSet.

            SortedSet<int> sortedSet = new SortedSet<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            sortedSet.GetViewBetween(num1, num2).Clear();

            Console.WriteLine(string.Join(",", sortedSet));
        }
        static IEnumerable<int> RemoveElementOutsideGivenRange(SortedSet<int> set, int low, int high)
        {
            //Problem: Find all elements in a SortedSet that are outside a given range [low, high].

            var range = set.GetViewBetween(low, high);
            SortedSet<int> result = new SortedSet<int>(set);
            result.ExceptWith(range);

            return result;
        }
        static void CountElementNumberLessThen(int num)
        {
            //Problem: Count the number of elements less than a given element in a SortedSet.

            SortedSet<int> sortedSet = new SortedSet<int> { 1, 2, 3, 4, 5 };
            var rang = sortedSet.GetViewBetween(int.MinValue, num).Count;

            Console.WriteLine(rang);
        }
        static bool ContainsElementsFromRange(SortedSet<int> sortedSet, List<(int start, int end)> ranges)
        {
            foreach (var range in ranges)
            {
                bool found = false;
                foreach (int element in sortedSet.GetViewBetween(range.start, range.end))
                {
                    found = true;
                    break;
                }
                if (!found)
                    return false;
            }
            return true;
        }
        static bool ContainsAllRanges(SortedSet<int> set, List<(int, int)> ranges)
        {
            foreach (var (low, high) in ranges)
            {
                var range = set.GetViewBetween(low, high);
                if (range.Count != (high - low + 1))
                    return false;
            }
            return true;
        }

        static void DynamicLListOfStudentInClassroom()
        {
            ObservableCollection<string> students = new ObservableCollection<string>();
            students.CollectionChanged += (sender, e) =>
            {
                //this will be fired on any change (Add or Remove)

                if (e.Action == NotifyCollectionChangedAction.Add)
                    Console.WriteLine($"New Student added: {e.NewItems[0]}");
                if (e.Action == NotifyCollectionChangedAction.Remove)
                    Console.WriteLine($"Student removed: {e.OldItems[0]}");
            };

            students.Add("Khaled");
            students.Add("Mohammad");
            students.Add("Suher");

            students.Remove("Khaled");
            students.Remove("Mohammad");
        }
        static void ShoppingCart()
        {
            ObservableCollection<string> cart = new ObservableCollection<string>();

            cart.CollectionChanged += (sender, e) =>
            {
                if (e.Action == NotifyCollectionChangedAction.Add)
                    Console.WriteLine($"Product added: {e.NewItems[0]}");
                if (e.Action == NotifyCollectionChangedAction.Remove)
                    Console.WriteLine($"Product removed: {e.OldItems[0]}");
                if (e.Action == NotifyCollectionChangedAction.Replace)
                    Console.WriteLine($"Product replaced: {e.OldItems[0]} with {e.NewItems[0]}");
            };

            cart.Add("Laptop");
            cart.Add("Mobile");

            cart.Remove("Laptop");
            cart.Add("Tablet");

            if (cart.Contains("Laptop"))
            {
                cart[cart.IndexOf("Laptop")] = "Smart Watch";
            }
            else
                Console.WriteLine("Laptop not found");
        }
        static void MenageTask()
        {
            ObservableCollection<string> tasks = new ObservableCollection<string>();
            tasks.CollectionChanged += (sender, e) =>
            {
                if (e.Action == NotifyCollectionChangedAction.Add)
                    Console.WriteLine($"Task added: {e.NewItems[0]}");
                if (e.Action == NotifyCollectionChangedAction.Remove)
                    Console.WriteLine($"Task removed: {e.OldItems[0]}");
            };

            tasks.Add("Task 1");
            tasks.Add("Task 2");
            tasks.Add("Task 3");
            tasks.Remove("Task 2");
        }
        static void GetFirstCharWithLessNumb()
        {
            string input = "HelloWorldHello";

            Dictionary<char, int> charFrequencies = new Dictionary<char, int>();

            for (int i = 0; i < input.Length; i++)
            {
                if (charFrequencies.ContainsKey(input[i]))
                {
                    charFrequencies[input[i]]++;
                }
                else
                    charFrequencies[input[i]] = 1;
            }
            foreach (var item in charFrequencies)
            {
                if (item.Key != ' ' && item.Value == 5)
                {
                    Console.WriteLine($"{item.Key} : {item.Value}");
                    break;
                }
            }
            // Or 
            //var uniqueChar = input.Where(c => c != ' ').GroupBy(c => c).Where(g => g.Count() == 5).Select(g => g.Key).FirstOrDefault();
            //if (uniqueChar != default)
            //    Console.WriteLine($"{uniqueChar} : 5");
            //else
            //    Console.WriteLine("No unique char");
        }
        static Tuple<string, int> GetNameAndAlter()
        {
            string name;
            int alter;
            Console.Write("Enter Name: ");
            name = Console.ReadLine();
            Console.Write("Enter Alter: ");
            alter = int.Parse(Console.ReadLine());

            Tuple<string, int> personDaten = new Tuple<string, int>(name, alter);
            return personDaten;

            //Oder
            //return Tuple.Create(name, alter);
        }
        static (string name, int age, double grade) GetStudentDetails()
        {
            return ("Khaled", 33, 52.3);
        }
        static (string, string, string) GetPlayerDetails()
        {
            List<string[]> daten = new List<string[]>();

            daten.Add(new string[] { "Khaled", "100", "200" });
            daten.Add(new string[] { "Mohammad", "200", "300" });
            daten.Add(new string[] { "Suher", "300", "400" });
            daten.Add(new string[] { "Marah", "400", "500" });

            return (daten[3][0], daten[2][1], daten[0][2]);
        }

        static void GetEmployeeDetails()
        {
            var employee1 = (Name: "Khaled", Salary: 5000);
            var employee2 = (Name: "Mohammad", Salary: 6000);

            Console.WriteLine($"{employee2.Name} hat {(employee2.Salary > employee1.Salary ? "hihger" : "lower")}  salary than {employee1.Name}");
            Console.WriteLine($"{employee1.Name} hat {(employee1.Salary > employee2.Salary ? "mehr" : "weniger")} Gehalt als {employee2.Name}");
        }

        struct Address
        {
            public string street;
            public string housNumber;
            public string city;
            public string ilCity;
        }
        static (string, Address) GetStudentDetails1(string name)
        {
            Dictionary<string, Address> studentDetails = new Dictionary<string, Address>()
        {
                {"khaled", new Address{street = "Uhlandstr", housNumber = "20", city = "Mosbach", ilCity = "74821"} },
                {"Mohammad", new Address{street = "Uhlandstr", housNumber = "30", city = "Mosbach", ilCity = "74830"} },
                {"Suher", new Address{street = "Uhlandstr", housNumber = "40", city = "Mosbach", ilCity = "74830"} },
                {"Marah", new Address{street = "Uhlandstr", housNumber = "50", city = "Mosbach", ilCity = "80821"} }
        };

            if (studentDetails.ContainsKey(name))
            {
                return (name, studentDetails[name]);
            }
            else
                return ("No ONe", new Address());
        }

        public class User
        {
            public string username { get; set; }
            public string status { get; set; }
            List<Message> messageBox;
            HashSet<string> userId = new HashSet<string>();

            public User(string username, string status)
            {
                if (!userId.Contains(username))
                {
                    this.username = username;
                    this.status = status;
                    messageBox = new List<Message>();
                    userId.Add(username);
                }
            }
            public void ReceiveMessage(Message message)
            {
                messageBox.Add(message);
            }
            public void ShowMessages()
            {
                Console.WriteLine($"Username: {this.username}, Status: {this.status}");
                foreach (var message in messageBox)
                {
                    Console.WriteLine($"Received -->  {message.content}");
                }
            }
        }
        public class Message
        {
            public User sender { get; private set; }
            public User receiver { get; private set; }
            public string content { get; private set; }
            public Message(User sender, User receiver, string content)
            {
                this.sender = sender;
                this.receiver = receiver;
                this.content = content;
            }
        }

        public class MessegingSystem
        {
            public static void SendMessage(User sender, User receiver, string content)
            {
                Message message = new Message(sender, receiver, content);
                receiver.ReceiveMessage(message);
                Console.WriteLine($"Message sent from {sender.username} to {receiver.username}");
            }
        }
        static (int trueBit, int falseBit) CountBits()
        {
            BitArray bits = new BitArray(new bool[] { true, false, true, false, false, false, true, true, false });
            int trueBit = 0;
            int falseBit = 0;
            foreach (bool bit in bits)
            {
                if (bit)
                    trueBit++;
                else
                    falseBit++;
            }
            return (trueBit, falseBit);
        }

        static BitArray GetBitArr()
        {
            BitArray bits1 = new BitArray(new bool[] { true, false, true, false, false, false, true, true, false });
            BitArray bits2 = new BitArray(new bool[] { true, false, true, false, false, false, true, true, false });

            return bits1.And(bits2);
        }

        static bool IstSortiert(string[] words, string order)
        {
            // Dictionary<char, int> orderMap = new Dictionary<char, int>();
            //foreach(char c in order)
            //{
            //    orderMap[c] = orderMap.Count;
            //}

            if (words == null || order == null)
            {
                return false;
            }
            int wordsLength = words.Length;
            if (wordsLength == 1)
            {
                return true;
            }

            for (int i = 0; i < wordsLength - 1; i++)
            {
                string word1 = words[i];
                string word2 = words[i + 1];
                //int minLength = Math.Min(word1.Length, word2.Length);

                for (int j = 0; j < word1.Length; j++)
                {
                    if (j == word2.Length)
                        return false;

                    char c1 = word1[j];
                    char c2 = word2[j];

                    if (c1 == c2)
                        continue;

                    if (order.IndexOf(c1) < order[c2])
                    {
                        break;
                    }
                    else if (order[word1[j]] > order[word2[j]])
                    {
                        return false;
                    }

                }

            }
            return true;
        }
        static void DisplayQuestion(Questions questions)
        {
            Console.WriteLine(questions.question);
            for (int i = 0; i < questions.options.Length; i++)
            {
                Console.WriteLine($" {i + 1}- {questions.options[i]}");
            }

            Console.Write("\nAnswer: ");
            int answer = Convert.ToInt32(Console.ReadLine());
            if (answer - 1 == questions.answer)
                Console.WriteLine("The Answer was right :-) perfekt");
            else
                Console.WriteLine("The Answer was fault :-( not perfekt");

            Console.WriteLine("____________");
        }

        class Questions
        {
            public string question { get; set; }
            public string[] options { get; set; }
            public int? answer { get; set; }

            public Questions(string question, string[] options, int answer)
            {
                this.question = question;
                this.options = options;
                this.answer = answer;
            }
        }
        static void Main(string[] args)
        {



            Console.WriteLine("Presse any Key to close the Console.....");
            Console.ReadLine();
        }
    }
}
