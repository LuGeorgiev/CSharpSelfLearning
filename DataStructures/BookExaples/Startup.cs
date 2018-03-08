using System;
using System.Collections.Generic;
using System.IO;
using System.Text;


namespace BookExaples
{
    class Startup
    {
        static void Main( )
        {
            string[] words = { "море", "бира", "пари" };
            // GenerateMultitude(words); //not working proprly because ther are multitudes with same members
            // GenerateSubsets(words); // Generate properly. Subset is made from 
            FillInStudents(@"..\..\Students.txt");
        }

        public static void GenerateMultitude(string[] words)
        {
            Queue<HashSet<string>> subsetsQueue = new Queue<HashSet<string>>();
            HashSet<string> emptySet = new HashSet<string>();
            subsetsQueue.Enqueue(emptySet);
            while (subsetsQueue.Count>0)
            {
                HashSet<String> subset = subsetsQueue.Dequeue();
                Console.Write("{");
                foreach (string word in subset)
                {
                    Console.Write("{0} ", word);
                }
                Console.WriteLine("}");
                foreach (string element in words)
                {
                    if (!subset.Contains(element))
                    {
                        HashSet<string> newSubset = new HashSet<string>();
                        newSubset.UnionWith(subset);
                        newSubset.Add(element);
                        subsetsQueue.Enqueue(newSubset);
                    }
                }

            }

        }
        public static void GenerateSubsets(string[] words)
        {
            Queue<List<int>> subsetsQueue = new Queue<List<int>>();
            List<int> emptySet = new List<int>();
            subsetsQueue.Enqueue(emptySet);
            while (subsetsQueue.Count>0)
            {
                List<int> subset = subsetsQueue.Dequeue();
                Print(subset, words);
                int start = -1;
                if (subset.Count>0)
                {
                    start = subset[subset.Count - 1];
                }
                for (int i = start+1; i < words.Length; i++)
                {
                    List<int> newSubset = new List<int>();
                    newSubset.AddRange(subset);
                    newSubset.Add(i);
                    subsetsQueue.Enqueue(newSubset);
                }
            }
        }
        static void Print(List<int> subset, string[] words)
        {
            Console.Write("[ ");
            for (int i = 0; i < subset.Count; i++)
            {
                int index = subset[i];
                Console.Write("{0} ", words[index]);
            }
            Console.WriteLine("]");
        }
        static void FillInStudents(string file)
        {
            Dictionary<string, List<Student>> courses = new Dictionary<string, List<Student>>();
            StreamReader reader = new StreamReader(file, Encoding.Unicode);
            using (reader)
            {
                while (true)
                {
                    string line = reader.ReadLine();
                    if (line==null)
                    {
                        break;
                    }
                    string[] entry = line.Split(new char[] { '!' });
                    string firstName = entry[0].Trim();
                    string lastName = entry[1].Trim();
                    string course = entry[2].Trim();

                    List<Student> students;
                    if (!courses.TryGetValue(course, out students))
                    {
                        students = new List<Student>();
                        courses.Add(course, students);
                    }
                    Student student = new Student(firstName, lastName);
                    students.Add(student);
                }
            }

            foreach (string course in courses.Keys)
            {
                Console.WriteLine("Coures"+ course+": ");
                List<Student> students = courses[course];
                students.Sort();
                foreach (Student student in students)
                {
                    Console.WriteLine("\t{0}",student);
                }
            }
        }
    }
}
