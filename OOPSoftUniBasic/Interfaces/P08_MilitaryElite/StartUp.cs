using P08_MilitaryElite.Soldiers;
using P08_MilitaryElite.Soldiers.Utilities;
using System;
using System.Linq;
using System.Collections.Generic;
using P08_MilitaryElite.Interfaces.IUtilities;

namespace P08_MilitaryElite
{
    public class StartUp
    {
        static void Main()
        {
            var soldiers = new List<ISoldier>();

            string input = "";
            while ((input=Console.ReadLine())!="End")
            {
                var tokens = input.Split();
                var id = int.Parse(tokens[1]);
                var firstName = tokens[2];
                var lastName = tokens[3];
                var salary = double.Parse(tokens[4]);
                ISoldier soldier = null;
                try
                {
                    if (tokens[0] == "Private")
                    {
                        soldier = new Private(id, firstName, lastName, salary);
                    }
                    else if (tokens[0] == "LeutenantGeneral")
                    {
                        var leutenant = new LeutenantGeneral(id, firstName, lastName, salary);
                        for (int i = 5; i < tokens.Length; i++)
                        {
                            int privateID = int.Parse(tokens[i]);
                            ISoldier @private = soldiers.First(x => x.Id == privateID);
                            leutenant.AddPrivate(@private);
                        }
                        soldier = leutenant;
                    }
                    else if (tokens[0] == "Engineer")
                    {
                        var engCorp = tokens[5];
                        var engineer = new Engineer(id, firstName, lastName, salary, engCorp);
                        for (int i = 6; i < tokens.Length; i ++)
                        {
                            string partNmae = tokens[i];
                            int partHours = int.Parse(tokens[++i]);
                            try
                            {
                                IRepair repair = new Repair(partNmae, partHours);
                                engineer.AddRepairItem(repair);
                            }
                            catch
                            {
                            }
                        }
                        soldier = engineer;
                    }
                    else if (tokens[0] == "Commando")
                    {
                        var comandoCorp = tokens[5];
                        var commando = new Commando(id, firstName, lastName, salary, comandoCorp);
                        for (int i = 6; i < tokens.Length; i ++)
                        {
                            var codeName = tokens[i];
                            var missionStatus = tokens[++i];
                            try
                            {
                                IMission mission = new Mission(codeName, missionStatus);
                                commando.AddMission(mission);
                            }
                            catch
                            {
                            }
                        }
                        soldier = commando;
                    }
                    else if (tokens[0] == "Spy")
                    {
                        int codeNumber = (int)salary;
                        soldier = new Spy(id, firstName, lastName, codeNumber);
                    }
                }
                catch (Exception e)
                {

                    //Console.WriteLine(e.Message);
                }
                soldiers.Add(soldier);
            }

            foreach (var s in soldiers)
            {
                ////TAST SOLVED
                //Console.WriteLine(s);

                // to get the correct ToString if not working from Interface
                var soldiertype = s.GetType();
                var actualSoldier = Convert.ChangeType(s, soldiertype);
                Console.WriteLine(actualSoldier);
            }
        }
    }
}
