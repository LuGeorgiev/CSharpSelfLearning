using System;


namespace BookExamples
{
    class CustomArrayList
    {
        private object[] arr;
        private int count;

        public int Count { get { return count; }  }
        private static readonly int INITIAL_CAPACITY = 4;

        public CustomArrayList()
        {
            arr = new object[INITIAL_CAPACITY];
            count = 0;
        }
        public void Add(object item)
        {
            Insert(count, item);
        }

        public void Insert(int index, object item)
        {
            if (index>count||index<0)
            {
                throw new IndexOutOfRangeException("Invalid index:" + index);
            }
            object[] extendedArr = arr;
            if (count+1==arr.Length)
            {
                extendedArr = new object[arr.Length * 2];
            }
            Array.Copy(arr, extendedArr, index);
            count++;
            Array.Copy(arr, index, extendedArr, index + 1, count - index - 1);
            extendedArr[index] = item;
            arr = extendedArr;
        }

        static void Main()
        {
            var pesho = new CustomArrayList();
            pesho.Add(1);
            pesho.Add(2);
            
            pesho.Insert(1, 8);
            
        }
    }
}
