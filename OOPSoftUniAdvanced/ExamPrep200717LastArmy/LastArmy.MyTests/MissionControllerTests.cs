using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LastArmy.MyTests
{
    
    public class MissionControllerTests
    {
        [Test]
        public void MissionControllDispalysFailMessage()
        {
            var army = new Army();
            var wareHouse = new WareHouse();

            var missionController = new MissionController(army,wareHouse);

            var mission = new Easy(1);
            string result=null;
            for (int i = 0; i < 4; i++)
            {
                result = missionController.PerformMission(mission);
            }

            Assert.IsTrue(result.StartsWith("Mission declined"));
        }

        [Test]
        public void MissionControllDispalysSuccessMessage()
        {
            var army = new Army();
            var wareHouse = new WareHouse();

            var missionController = new MissionController(army, wareHouse);

            var mission = new Easy(0);
            string result = missionController.PerformMission(mission);
            
            Assert.IsTrue(result.StartsWith("Mission completed"));
        }
    }
}
