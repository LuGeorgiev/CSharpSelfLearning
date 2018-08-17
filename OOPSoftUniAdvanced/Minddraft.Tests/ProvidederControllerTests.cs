using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace Minddraft.Tests
{
   [TestFixture]
    public class ProvidederControllerTests
    {
        [Test]
        public void ProduceCorrectAmountEnergy()
        {
            List<string> provider1 = new List<string>{"Solar", "1", "100"};
            List<string> provider2 = new List<string>{"Solar", "2", "100"};
            var energyRep = new EnergyRepository();
            var providerController = new ProviderController(energyRep);
            providerController.Register(provider1);
            providerController.Register(provider2);

            for (int i = 0; i < 3; i++)
            {
                providerController.Produce();
            }

            Assert.That(providerController.TotalEnergyProduced, Is.EqualTo(600));
        }

        [Test]
        public void ProduceReturnCorrectMessage()
        {
            List<string> provider1 = new List<string> { "Solar", "1", "100" };
            List<string> provider2 = new List<string> { "Solar", "2", "100" };
            var energyRep = new EnergyRepository();
            var providerController = new ProviderController(energyRep);
            providerController.Register(provider1);
            providerController.Register(provider2);
                       
            //Due to this thest some tests do NOT pass in JUDGE
            Assert.That(providerController.Produce(), Is.EqualTo("Produced 200 energy today!"));
        }

        [Test]
        public void BrokenProviderIsDeleted()
        {
            List<string> provider1 = new List<string> { "Pressure", "1", "100" };
            
            var energyRep = new EnergyRepository();
            var providerController = new ProviderController(energyRep);
            providerController.Register(provider1);

            for (int i = 0; i < 8; i++)
            {
                providerController.Produce();
            }


            Assert.That(providerController.Entities.Count, Is.EqualTo(0));
        }

        [Test]
        public void ProvidersGetRapair()
        {
            List<string> provider1 = new List<string> { "Pressure", "1", "100" };

            var energyRep = new EnergyRepository();
            var providerController = new ProviderController(energyRep);
            providerController.Register(provider1);

            providerController.Repair(100);

            Assert.That(providerController.Entities.First().Durability, Is.EqualTo(800));
        }
    }
}
