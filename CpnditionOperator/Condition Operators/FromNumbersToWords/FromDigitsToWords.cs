using System;


namespace FromNumbersToWords
{
    class FromDigitsToWords
    {
        static void Main()
        {
            int num, edenici, destici, stotici;
            string ede, des, sto;

            Console.WriteLine("Моля въведете цяло чисно между 0 и 999 ");
            while (!(int.TryParse(Console.ReadLine(), out num)&&num>=0&&num<=999))
            {
                Console.WriteLine("Опитай пак");
            }

            stotici = num / 100;
            destici = (num % 100) / 10;
            edenici = (num % 100) % 10;

            if (num==0)
            {
                Console.WriteLine("Написаното число е нула");
            }

            else if (edenici==0) 
            {
                switch (destici)
                {
                    case 1: des = "десет"; break;
                    case 2: des = "двaдесет"; break;
                    case 3: des = "тридесет"; break;
                    case 4: des = "четирдесет"; break;
                    case 5: des = "петдесет"; break;
                    case 6: des = "шесдесет"; break;
                    case 7: des = "седемдесет"; break;
                    case 8: des = "осемдесет"; break;
                    case 9: des = "деветдесет"; break;
                    default: des = ""; break;
                }

                switch (stotici)
                {
                    case 1: sto = "сто и "; break;
                    case 2: sto = "двеста и "; break;
                    case 3: sto = "триста и "; break;
                    case 4: sto = "четистотин и "; break;
                    case 5: sto = "петстотин и "; break;
                    case 6: sto = "шесстотин и "; break;
                    case 7: sto = "седемстотин и "; break;
                    case 8: sto = "осемстотин и "; break;
                    case 9: sto = "деветстотин и "; break;
                    default: sto = ""; break;
                }

                Console.WriteLine("Написаното число е {0}{1}", sto, des);

            }


            else if (destici==1&&edenici!=0)
            {
                switch (edenici)
                {
                    case 1: ede = "единадесет"; break;
                    case 2: ede = "дванадесет"; break;
                    case 3: ede = "тринадесет"; break;
                    case 4: ede = "четиринадесет"; break;
                    case 5: ede = "петнадесет"; break;
                    case 6: ede = "шестнадесет"; break;
                    case 7: ede = "седемнадесет"; break;
                    case 8: ede = "осемнадесет"; break;
                    case 9: ede = "деветнадесет"; break;
                    

                    default:ede = "";break;
                }

                switch (stotici)
                {
                    case 1: sto = "сто и"; break;
                    case 2: sto = "двеста и"; break;
                    case 3: sto = "триста и"; break;
                    case 4: sto = "четистотин и"; break;
                    case 5: sto = "петстотин и"; break;
                    case 6: sto = "шесстотин и"; break;
                    case 7: sto = "седемстотин и"; break;
                    case 8: sto = "осемстотин и"; break;
                    case 9: sto = "деветстотин и"; break;
                    default: sto = ""; break;
                }
                Console.WriteLine("Написаното число е {0}{1}", sto, ede);
            }

            else if (destici == 0 && edenici != 0&&stotici!=0)
            {
                switch (edenici)
                {
                    case 1: ede = "едно"; break;
                    case 2: ede = "две"; break;
                    case 3: ede = "три"; break;
                    case 4: ede = "четири"; break;
                    case 5: ede = "пет"; break;
                    case 6: ede = "шест"; break;
                    case 7: ede = "седем"; break;
                    case 8: ede = "осем"; break;
                    case 9: ede = "девет"; break;


                    default: ede = ""; break;
                }

                switch (stotici)
                {
                    case 1: sto = "сто и "; break;
                    case 2: sto = "двеста и "; break;
                    case 3: sto = "триста и"; break;
                    case 4: sto = "четистотин и "; break;
                    case 5: sto = "петстотин и "; break;
                    case 6: sto = "шесстотин и "; break;
                    case 7: sto = "седемстотин и "; break;
                    case 8: sto = "осемстотин и "; break;
                    case 9: sto = "деветстотин и "; break;
                    default: sto = ""; break;
                }
                Console.WriteLine("Написаното число е {0}{1}", sto, ede);
            }

            else
            {
                switch (edenici)
                {
                    case 1: ede= "едно"; break;
                    case 2: ede = "две"; break;
                    case 3: ede = "три"; break;
                    case 4: ede = "четири"; break;
                    case 5: ede = "пет"; break;
                    case 6: ede = "шест"; break;
                    case 7: ede = "седем"; break;
                    case 8: ede = "осем"; break;
                    case 9: ede = "девет"; break;
                    default:ede = ""; break;
                }

                switch (destici)
                {
                    case 2: des = "двaдесет и "; break;
                    case 3: des = "тридесет и "; break;
                    case 4: des = "четирдесет и "; break;
                    case 5: des = "петдесет и "; break;
                    case 6: des = "шесдесет и "; break;
                    case 7: des = "седемдесет и "; break;
                    case 8: des = "осемдесет и "; break;
                    case 9: des = "деветдесет и "; break;
                    default:des = ""; break;
                }

                switch (stotici)
                {
                    case 1: sto = "сто "; break;
                    case 2: sto = "двеста "; break;
                    case 3: sto = "триста "; break;
                    case 4: sto = "четистотин "; break;
                    case 5: sto = "петстотин "; break;
                    case 6: sto = "шесстотин "; break;
                    case 7: sto = "седемстотин "; break;
                    case 8: sto = "осемстотин "; break;
                    case 9: sto = "деветстотин "; break;
                    default: sto = ""; break;
                }

                Console.WriteLine("Написаното число е {0}{1}{2}", sto, des, ede);
            }

           

            
        }
    }
}
