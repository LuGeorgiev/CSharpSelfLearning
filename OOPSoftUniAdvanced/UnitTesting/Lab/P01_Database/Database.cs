using System;
using System.Collections.Generic;
using System.Text;

namespace P01_Database
{
    public class Database
    {
        private int[] myArr;
        private int index = 0;

        public Database()
        {
            this.MyArr = new int[16];
        }
        public Database(params int[] intArr):base()
        {
            this.MyArr = new int[16];
            if (intArr.Length>16)
            {
                throw new InvalidOperationException("Array should be 16 ints maximum");
            }

            for (int i = 0; i < intArr.Length; i++)
            {
                MyArr[i] = intArr[i];
                index++;
            }
        }
        public int[] MyArr
        {
            get
            {
                return myArr;
            }
            private set
            {               
                myArr = value;
            }
        }

        public void Add(int element)
        {
            if (this.index>=15)
            {
                throw new InvalidOperationException("Cannot add more alements");
            }
            this.MyArr[index] = element;
            this.index++;
        }

        public void Remove()
        {
            if (this.index<=0)
            {
                throw new InvalidOperationException("Array is already empty");
            }
            this.index--;
            this.MyArr[index] = 0;
        }

        public int[] Fetch()
        {
            return this.MyArr;
        }
    }
}
