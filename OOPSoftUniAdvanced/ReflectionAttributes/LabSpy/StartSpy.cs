using System;

namespace LabSpy
{
    [SoftUni("Gosho",Year =2010)]
    public class StartSpy
    {
        [SoftUni("Petkan")]
        [SoftUni("Stefan",Year =2011)]
        [SoftUni("Momchil",Year =2013)]
        static void Main(string[] args)
        {
            
            var sbType= Type.GetType("Console");

            var spy = new Spy();
            //var result = spy.StealFieldInfo("Hacker", "username", "password");            

            //var result = spy.AnalyzeAcessModifiers("Hacker");

            //var result = spy.RevealPrivateMethods("Hacker");

            //var result = spy.CollectGettersAndSetters("Hacker");
            //Console.WriteLine(result);

            var tracker = new Tracker();            
            tracker.PrintMethodsByAuthor();

        }
    }
}
