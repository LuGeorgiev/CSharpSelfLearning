using System;

namespace GenereicConstarinsLab03
{
    class Program
    {
        static void Main(string[] args)
        {
            //var jar = new Jar<int>();
            //var jar2 = new Jar<string>();

            var scale = new Scale<string>("Gosho", "Pesho");
            var heavier = scale.GetHavier();

            Console.WriteLine(heavier);
        }
    }

    //public class Jar<T>
    //    where T:struct // or class instaead struct
    //    // where T: IEnumerable<T> - or any other interfaces
    //{

    //}

    public class Scale<T>
        where T:IComparable<T>
    {
        private T left;
        private T right;

        public Scale(T left, T right)
        {
            this.left=left;
            this.right = right; 
        }

        public T GetHavier()
        {
            if (this.left.CompareTo(this.right)>0)
            {
                return this.left;
            }
            if(this.left.CompareTo(this.right) < 0)
            {
                return this.right;    
            }

            return default(T);
        }
    }
}
