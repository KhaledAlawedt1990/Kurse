using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Runtime.Remoting.Messaging;
using System.Runtime.CompilerServices;
using System.Net.Http.Headers;
using System.CodeDom;

namespace ConsoleApp4
{



    public class CustomColliction<T> : IEnumerable<T>
    {
        List<T> items = new List<T>();
        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < items.Count; i++)
            {
                //es wird nur ein item zurückgegeben in jedem mal.
                yield return items[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Add(T item)
        {
            items.Add(item);
        }
    }

    public class SimpleCollection<T> : ICollection<T>
    {

        T[] orginalArry;
        T[] tempArry;
        int Size = 0;

        public int Count => Size;
        public bool IsReadOnly => false;

        public SimpleCollection()
        {
            orginalArry = new T[1];
        }

        private void _Add(T item)
        {
            tempArry = new T[Size + 1];
            Array.Copy(orginalArry, tempArry, orginalArry.Length);

            tempArry[Size - 1] = item;

            orginalArry = tempArry;
        }

        public void Add(T item)
        {
             Size++;
            _Add(item);
        }
        public bool Remove(T item)
        {
            T[] tempArry = new T[orginalArry.Length - 1];
            bool isFound = false;
            int tempSize = 0;

            for(int i = 0; i < orginalArry.Length - 1; i++)
            {
                if (!orginalArry[i].Equals(item))
                {
                    tempArry[tempSize] = orginalArry[i];
                    tempSize++;
                }
                else
                {
                    Size--;
                    isFound = true;
                }
                    
            }
            orginalArry = tempArry;
            return isFound;
        }
     

        public IEnumerator<T> GetEnumerator()
        {
            for(int i = 0; i < orginalArry.Length - 1; i++)
            {
                yield return orginalArry[i];
            }
          
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        public void Clear()
        {
            orginalArry = new T[1];
            this.Size = 0;
        }

        public bool Contains(T item)
        {
            return true;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            orginalArry.CopyTo(array, arrayIndex);
        }
    }

    public class IListe<T> : IList<T>
    {
        List<T> items = new List<T>();
        public T this[int index]
        {
            get { return items[index]; }
            set { items[index] = value; }
        }
        public void Add(T item) => items.Add(item);
        public void Clear() => items.Clear();
        public bool Remove(T item) => items.Remove(item);
        public void  RemoveAt(int index) => items.RemoveAt(index);
        public bool Contains(T item) => item.Equals(item);
        public int Count => items.Count;
        public bool IsReadOnly => false;

        public void Insert(int index, T item) => items.Insert(index, item);
        public int IndexOf(T item) => (int)items.IndexOf(item);
        public void CopyTo(T[] array, int arrayIndex) => items.CopyTo(array, arrayIndex);

        public IEnumerator<T> GetEnumerator()
        {
            foreach (var item in items)
                yield return item;
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

       
  
    }

    public class Person : IComparable<Person>
    {
        public string name { get; set; }
        public int age { get; set; }

        public  Person(string name, int age)
        {
            this.name = name;
            this.age = age;
        }
        public int CompareTo(Person other)
        {
            if (other == null) return 1;

            return this.age.CompareTo(other.age);
        }

        public override string ToString()
        {
            return $"{name} is {age} years old.";
        }
    }


    public class TreeNode<T>
    {
        public T daten { get; set; }

        public List<TreeNode<T>> kinder = new List<TreeNode<T>>();

        public TreeNode(T daten)
        {
            this.daten = daten;
            kinder = new List<TreeNode<T>>();
        }

       
    }

    public class Familie
    {
        public int x1 { get; set; }
        public static int x2 { get; set; }

        public int Method1()
        {
            return x1 + x2;
        }

        public static int Method2()
        {
            return x2;
        }
   
    }
    class Program
    {
        static void Main(string[] args)
        {
            Familie fx1 = new Familie();
            Familie fx2 = new Familie();

            fx1.x1 = 1;
            fx2.x1 = 10;
            Familie.x2 = 100;
            Console.WriteLine(fx1.Method1());
            Console.WriteLine(fx2.Method1());
            Console.WriteLine(Familie.Method2());


            Console.ReadLine();
        }

        public static async Task task()
        {
            await Task.Delay(5000);
            Console.WriteLine("\n\nArbeit ist abgeschlosssen");
        }
        
        public static void PrintTree(TreeNode<Familie> node, string indent = "    ")
        {
         
            foreach(var kind in node.kinder)
            {
                PrintTree(kind, indent + "       ");
            }
            //Console.WriteLine("Hallo");
        }
    }
}
