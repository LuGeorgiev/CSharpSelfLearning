using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomAdvertisement
{
    class Program
    {
        private static readonly string[] Praise = {"Продуктът е отличен! ", "Това е стархотен прдукт! ", "Той направи чудо! ", "Той направо ме разцепи! ",
            "Продуктът кърти миФки! ","Препоръчвам ви го! "};
        private static readonly string[] Heppening = {"Вече се чувствам отлично. ", "НЕ бих го заменила за нищо. ", "Успях да се променя. ",
            "Пробвайте го. Незабравимо е. ", "Не го вярвам ","Вече направо летя. "};
        private static readonly string[] FirstName = {"Маргарита ", "Геновева ", "Хортензия ", "Катя ", "Смръдла ","Кифла "};
        private static readonly string[] SecondName = { "Иваново ", "Горчева ", "Саздова ", "Куцова ", "Общата ", "Гадова " };
        private static readonly string[] City= { "Злокучане ", "Българско Словово ", "Надежда ", "Обеля ", "Орландовци ", "Кърлежи " };

        static void Main(string[] args)
        {
            StringBuilder adv = new StringBuilder();
            Random rng = new Random();

            adv = adv.Append(Praise[rng.Next(Praise.Length)]);
            adv = adv.Append(Heppening[rng.Next(Heppening.Length)]);
            adv = adv.Append(FirstName[rng.Next(FirstName.Length)]);
            adv = adv.Append(SecondName[rng.Next(SecondName.Length)]);
            adv = adv.Append(City[rng.Next(City.Length)]);

            Console.WriteLine(adv);
        }
    }
}
