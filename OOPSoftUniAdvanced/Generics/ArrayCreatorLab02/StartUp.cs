using System;
using System.Collections.Generic;

namespace ArrayCreatorLab02
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var arr = ArrayCreator.Create<string>(4, "Gosho");            
        }

        //public static List<T> CreateList<T>()
        //{
        //    return new List<T>();
        //}
    }

    public static class ArrayCreator
    {
        public static T[] Create<T>(int length, T item )
        {
            var arr = new T[length];

            for (int i = 0; i < length; i++)
            {
                arr[i] = item;
            }    
            return arr;
        }
    }
}
